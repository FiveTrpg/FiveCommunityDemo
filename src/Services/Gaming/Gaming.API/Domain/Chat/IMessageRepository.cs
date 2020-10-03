using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.API.Domain.Chat
{
    public interface IMessageRepository
    {
        IAsyncEnumerable<Message> GetRecentHistory(Channel channel);
        IAsyncEnumerable<Message> GetRecentHistory(Channel channel, Chatter chatter);
        IAsyncEnumerable<Message> SearchMessage(Channel channel, string keyword);
        ValueTask SaveMessage(Channel channel, Chatter from, Message message);
        ValueTask SaveMessage(Channel channel, Chatter from, Chatter to, Message message);
    }
}
