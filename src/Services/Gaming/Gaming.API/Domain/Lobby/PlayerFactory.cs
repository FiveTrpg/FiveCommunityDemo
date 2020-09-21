using System;
using System.Threading.Tasks;

namespace Gaming.API.Domain.Lobby
{
    public class PlayerFactory
    {
        public IPlayerRepository Repository { get; }
        public PlayerFactory(IPlayerRepository repo)
        {
            this.Repository = repo;
        }

        public async ValueTask<Player> Create(string nickName, string id = null)
        {
            var user = new Player() { Id = id ?? Guid.NewGuid().ToString(), Nickname = nickName };
            await Repository.SavePlayer(user);
            return user;
        }

        public async ValueTask<Player> CreateOrGet(string id, string name = "")
        {
            if (await Repository.IsPlayerRegistered(id))
            {
                return new Player()
                {
                    Id = id,
                    Nickname = await Repository.GetPlayerNicknameById(id)
                };
            }
            else
            {
                return await Create(name, id);
            }
        }
    }
}
