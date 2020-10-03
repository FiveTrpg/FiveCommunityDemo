using Autofac;
using EmberKernel.Services.EventBus.Handlers;
using Gaming.API.Domain.Users;
using Gaming.API.Infrastructure.Data.Community.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.API.Domain.Chat
{
    public class ChannelKanban : IEventHandler<ChatterLeavedEvent>
    {
        public Dictionary<string, Channel> Channels { get; set; }

        private ILifetimeScope Scope { get; }
        private IChannelRepository ChannelRepository { get; }
        public ChannelKanban(ILifetimeScope scope, IChannelRepository channelRepository)
        {
            this.Scope = scope;
            this.ChannelRepository = channelRepository;
        }

        public async ValueTask RestoreChannel()
        {
            await foreach (var rawChannel in ChannelRepository.GetAllChannels())
            {
                CreateChannel(rawChannel);
            }
        }

        public async ValueTask<Channel> CreateNewChannel(User user, string name, string password = null)
        {
            if (Channels.ContainsKey(name))
            {
                throw new ChannelAlreadyExistException();
            }
            var raw = await ChannelRepository.PersistChannel(user, name, password);
            return CreateChannel(raw);
        }

        public Channel CreateChannel(PersistedChannel rawChannel)
        {
            var channel = Scope.Resolve<Channel>();
            var owner = rawChannel.Owner.ToDomainUser();
            channel.Id = rawChannel.Id;
            channel.Name = rawChannel.Name;
            channel.Password = rawChannel.Password;
            channel.Owner = new Chatter(channel, owner);
            channel.CreatedAt = rawChannel.CreatedAt;
            channel.Join(owner, rawChannel.Password);
            Channels.Add(rawChannel.Name, channel);
            return channel;
        }

        public async ValueTask RemoveChannel(User user, Channel channel)
        {
            if (!Channels.ContainsKey(channel.Name))
            {
                throw new ChannelNotExistException();
            }
            if (new Chatter(channel, user).Equals(channel.Owner))
            {
                throw new AccessViolationException();
            }
            foreach (var chatter in channel.Chatters)
            {
                channel.Leave(chatter);
            }
            Channels.Remove(channel.Name);
            await ChannelRepository.DeleteChannel(channel.Id);
        }

        public IEnumerable<Channel> GetChannels()
        {
            return Channels.Values;
        }

        public Channel GetChannel(string name)
        {
            if (Channels.ContainsKey(name))
            {
                return Channels[name];
            }
            throw new ChannelNotExistException();
        }

        public ValueTask Handle(ChatterLeavedEvent @event)
        {
            if (@event.Channel.Chatters.Count == 0)
            {
                Channels.Remove(@event.Channel.Name);
            }
            return default;
        }
    }
}
