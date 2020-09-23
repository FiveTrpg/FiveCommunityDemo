using Autofac;
using Gaming.API.Application;
using Gaming.API.Controllers.Models;
using Gaming.API.Domain.Lobby;
using Gaming.API.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gaming.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        public LobbyApplication Domain { get; set; }
        public UserController(LobbyApplication domain)
        {
            this.Domain = domain;
        }
        public const string CookieScheme = "PLAYER_COOKIE";
        private static readonly AuthenticationProperties AuthProperties = new AuthenticationProperties()
        {
            AllowRefresh = true,
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.Now.AddYears(2),
        };

        [HttpPost]
        [Route("login")]
        public async ValueTask<IActionResult> Login([FromBody] LoginParam param)
        {
            if (!await HttpContext.IsLogin())
            {

                var player = await Domain.Resolve<PlayerFactory>().Create(param.NickName);
                var claims = new[]
                {
                    new Claim("id", player.Id),
                    new Claim("nickName", player.Nickname),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieScheme);
                var user = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieScheme, user, AuthProperties);
                return Ok();
            }
            return Ok(new { Message = "Already logged" });
        }
    }
}
