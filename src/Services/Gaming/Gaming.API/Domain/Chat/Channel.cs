using EmberKernel.Services.EventBus;
using Gaming.API.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.API.Domain.Chat
{
    public class Channel
    {
        public IEventBus EventBus { get; set; }

        public IMessageRepository MessageRepository { get; set; }
        public int Id { get; set; }
        public Chatter Owner { get; set; }
        public HashSet<Chatter> Chatters { get; set; } = new HashSet<Chatter>();
        public string Password { get; set; } = null;
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public Channel(IEventBus eventBus)
        {
            this.EventBus = eventBus;
        }

        public async ValueTask BoradcastMessage(Chatter from, Message message)
        {
            if (!Chatters.Contains(from))
            {
                throw new ChatterNotJoinChannelException();
            }
            await MessageRepository.SaveMessage(this, from, message);
        }

        public async ValueTask PrivateMessage(Chatter from, Chatter to, Message message)
        {
            if (!Chatters.Contains(from) || !Chatters.Contains(to))
            {
                throw new ChatterNotJoinChannelException();
            }
            await MessageRepository.SaveMessage(this, from, to, message);
        }

        public Chatter Join(User user, string password = null)
        {
            var chatter = new Chatter(this, user);
            if (Password != password)
            {
                throw new ChatterPasswordIncorrectException();
            }
            if (Chatters.Contains(chatter))
            {
                throw new ChatterAlreadyJoinedException();
            }
            Chatters.Add(chatter);
            return chatter;
        }

        public void Leave(User user)
        {
            Leave(new Chatter(this, user));
        }
        public void Leave(Chatter chatter)
        {
            if (!Chatters.Contains(chatter))
            {
                throw new ChatterNotJoinChannelException();
            }
            Chatters.Remove(chatter);
            EventBus.Publish(new ChatterLeavedEvent()
            {
                Chatter = chatter,
                Channel = this,
            });
        }
    }
}
