using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gaming.API.Domain.Lobby;
using Microsoft.Extensions.DependencyInjection;

namespace Gaming.API.Application
{
    public class LobbyApplicationBuilder
    {
        private IServiceCollection Services { get; }
        public LobbyApplicationBuilder(IServiceCollection services)
        {
            Services = services;
        }
        public LobbyApplicationBuilder UsePlayerRepository<TRepository>() where TRepository : class, IPlayerRepository
        {
            Services.AddSingleton<IPlayerRepository, TRepository>();
            return this;
        }
        public LobbyApplication Build()
        {
            Services.AddSingleton<Lobby>();
            Services.AddSingleton<PlayerFactory>();
            var container = new ContainerBuilder();
            container.Populate(Services);

            return new LobbyApplication(container);
        }
    }
}
