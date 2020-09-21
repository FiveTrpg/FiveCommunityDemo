using Gaming.API.Domain.Lobby;
using Gaming.API.Utils;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gaming.API.Infrastructure.Repository
{
    public class MemoryPlayerRepository : IPlayerRepository
    {
        private Dictionary<string, MemoryPlayer> Players { get; set; } = new Dictionary<string, MemoryPlayer>();
        public ValueTask<string> GetPlayerNicknameById(string id)
        {
            if (Players.ContainsKey(id)) return ValueTasks.Of(Players[id].Name);
            throw new KeyNotFoundException();
        }

        public ValueTask<bool> IsPlayerRegistered(string id)
        {
            return ValueTasks.Of(Players.ContainsKey(id));
        }

        public ValueTask SavePlayer(Player player)
        {
            if (Players.Any(p => p.Value.Name == player.Nickname)) throw new DuplicateNameException();
            if (!Players.TryAdd(player.Id, new MemoryPlayer() { Id = player.Id, Name = player.Nickname }))
                throw new DuplicateNameException();
            return default;
        }
    }
}
