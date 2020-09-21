using Autofac;
using Gaming.API.Application;
using Gaming.API.Domain.Lobby;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Gaming.API.Utils
{
    public static class HttpContextHelper
    {
        public static async ValueTask<bool> IsLogin(this HttpContext ctx)
        {
            if ((ctx.User?.Identity?.IsAuthenticated ?? false))
            {
                var id = string.Empty;
                var name = string.Empty;
                foreach (var cliam in ctx.User.Claims)
                {
                    if (cliam.Type == "id") { id = cliam.Value; }
                    if (cliam.Type == "nickName") { name = cliam.Value; }
                }
                if (id != string.Empty && name != string.Empty)
                {
                    var repo = ctx.RequestServices.GetRequiredService<LobbyApplication>().Resolve<IPlayerRepository>();
                    return await repo.IsPlayerRegistered(id);
                }

            }
            return false;
        }

        public static async ValueTask<Player> GetLoginPlayerFromLogin(this HttpContext ctx)
        {
            var id = string.Empty;
            var name = string.Empty;
            foreach (var cliam in ctx.User.Claims)
            {
                if (cliam.Type == "id") { id = cliam.Value; }
                if (cliam.Type == "nickName") { name = cliam.Value; }
            }
            if (id == string.Empty) throw new ArgumentNullException();
            var facory = ctx.RequestServices.GetRequiredService<LobbyApplication>().Resolve<PlayerFactory>();
            return await facory.CreateOrGet(id, name);
        }
    }
}
