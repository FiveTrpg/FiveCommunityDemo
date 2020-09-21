using Gaming.API.Application;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gaming.API.Applications
{
    public static class LobbyConfigureHelper
    {
        public static IServiceCollection AddLobbyApplication(this IServiceCollection services)
        {
            return AddLobbyApplication(services, (_) => _);
        }

        public static IServiceCollection AddLobbyApplication(this IServiceCollection services, Func<LobbyApplicationBuilder, LobbyApplicationBuilder> option)
        {
            var builder = new LobbyApplicationBuilder();
            services.AddSingleton(option(builder).Build());
            return services;
        }
    }
}
