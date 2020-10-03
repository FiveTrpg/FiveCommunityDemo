using Gaming.API.Domain.Users;
using Gaming.API.Infrastructure.Data.Community.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.API.Domain.Chat
{
    public interface IChannelRepository
    {
        IAsyncEnumerable<PersistedChannel> GetAllChannels();
        ValueTask<PersistedChannel> PersistChannel(User user, string name, string password);
        ValueTask<PersistedChannel> GetChannel(string name);
        ValueTask DeleteChannel(int id);
    }
}
