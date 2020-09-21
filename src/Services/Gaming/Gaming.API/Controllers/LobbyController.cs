using Gaming.API.Application;
using Gaming.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gaming.API.Controllers
{
    [Authorize(AuthenticationSchemes = UserController.CookieScheme)]
    [ApiController]
    [Route("api/lobby")]
    public class LobbyController : ControllerBase
    {
        public LobbyApplication Domain { get; set; }
        public LobbyController(LobbyApplication domainAccessor)
        {
            this.Domain = domainAccessor;
        }

        [Route("ping")]
        [HttpGet]
        public async ValueTask<IActionResult> Ping()
        {
            var player = await HttpContext.GetLoginPlayerFromLogin();
            return Ok($"{player.Nickname}, Pong!");
        }
    }
}
