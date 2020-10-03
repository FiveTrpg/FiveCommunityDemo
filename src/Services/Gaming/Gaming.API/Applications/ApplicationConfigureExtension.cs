using Gaming.API.Application;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gaming.API.Applications
{
    public static class ApplicationConfigureExtension
    {
        public static IServiceCollection AddLobbyApplication(this IServiceCollection services)
        {
            return AddLobbyApplication(services, (_) => _);
        }

        public static IServiceCollection AddLobbyApplication(this IServiceCollection services, Func<LobbyApplicationBuilder, LobbyApplicationBuilder> option)
        {
            var builder = new LobbyApplicationBuilder(services);
            services.AddSingleton(option(builder).Build());
            return services;
        }

        public static IServiceCollection AddChatApplication(this IServiceCollection services)
        {
            return AddChatApplication(services, (_) => _);
        }

        public static IServiceCollection AddChatApplication(this IServiceCollection services, Func<ChatApplicationBuilder, ChatApplicationBuilder> option)
        {
            var builder = new ChatApplicationBuilder(services);
            services.AddSingleton(option(builder).Build());
            return services;
        }
    }
}
