using Autofac;
using Gaming.API.Utils;

namespace Gaming.API.Application
{
    public class LobbyApplication : AutofacSelfContainer<LobbyApplication>
    {
        public LobbyApplication(ContainerBuilder builder) : base(builder)
        {
        }
    }
}
