using System.Threading.Tasks;

namespace Gaming.API.Domain.Lobby
{
    public interface IPlayerRepository
    {
        ValueTask<string> GetPlayerNicknameById(string id);
        ValueTask<bool> IsPlayerRegistered(string id);
        ValueTask SavePlayer(Player player);
    }
}
