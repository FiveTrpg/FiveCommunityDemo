using Gaming.API.Utils;
using Microsoft.AspNetCore.Builder;

namespace Gaming.API.Controllers.Middlewares
{
    public static class LoginRedirectMiddleware
    {
        public static IApplicationBuilder UseSimpleLoginRedirectMiddleware(this IApplicationBuilder builder)
        {
            return builder.Use(async (ctx, next) =>
            {
                if (!await ctx.IsLogin())
                {
                    ctx.Response.Redirect("/");
                    return;
                }
                await next();
            });
        }

    }
}
