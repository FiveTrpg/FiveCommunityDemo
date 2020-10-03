using Gaming.API.Domain.Chat;
using Gaming.API.Domain.Users;
using Gaming.API.Infrastructure.Data.Community;
using Gaming.API.Infrastructure.Data.Community.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaming.API.Infrastructure.Repository
{
    public class ChannelRepository : IChannelRepository
    {
        private FiveCommunityContext Db { get; }
        public ChannelRepository(FiveCommunityContext db)
        {
            this.Db = db;
        }
        public async ValueTask DeleteChannel(int id)
        {
            var channel = await Db.PersistedChannels
                .Where(ch => ch.Id == id).FirstOrDefaultAsync();
            Db.Remove(channel);
            await Db.SaveChangesAsync();
        }

        public IAsyncEnumerable<PersistedChannel> GetAllChannels()
        {
            return Db.PersistedChannels;
        }

        public async ValueTask<PersistedChannel> GetChannel(string name)
        {
            return await Db.PersistedChannels
                .Where(ch => ch.Name == name).FirstOrDefaultAsync();
        }

        public async ValueTask<PersistedChannel> PersistChannel(User user, string name, string password)
        {
            var rawUser = await Db.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            var ent = await Db.PersistedChannels.AddAsync(new PersistedChannel()
            {
                Name = name,
                Password = password,
                Owner = rawUser,
            });
            await Db.SaveChangesAsync();
            return ent.Entity;
        }
    }
}
