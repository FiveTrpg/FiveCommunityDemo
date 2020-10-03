using Gaming.API.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Gaming.API.Domain.Chat
{
    public readonly struct Chatter
    {
        public Channel Channel { get; }
        public User User { get; }

        public Chatter(Channel channel, User user)
        {
            this.Channel = channel;
            this.User = user;
        }

        public async ValueTask Say(Message message)
        {
            await Channel.BoradcastMessage(this, message);
        }

        public async ValueTask SayTo(Chatter to, Message message)
        {
            await Channel.PrivateMessage(this, to, message);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Channel, User.Id);
        }
    }
}
