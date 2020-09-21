using Autofac;
using Gaming.API.Domain.Lobby;

namespace Gaming.API.Application
{
    public class LobbyApplicationBuilder
    {
        private readonly ContainerBuilder _builder = new ContainerBuilder();
        public LobbyApplicationBuilder UsePlayerRepository<TRepository>() where TRepository : IPlayerRepository
        {
            _builder.RegisterType<TRepository>().As<IPlayerRepository>().SingleInstance();
            return this;
        }
        public LobbyApplication Build()
        {
            _builder.RegisterType<Lobby>().AsSelf().SingleInstance();
            _builder.RegisterType<PlayerFactory>().AsSelf().SingleInstance();
            return new LobbyApplication(_builder);
        }
    }
}
