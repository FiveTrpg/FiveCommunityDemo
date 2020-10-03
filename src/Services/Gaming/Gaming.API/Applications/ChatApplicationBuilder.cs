using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gaming.API.Domain.Chat;
using Microsoft.Extensions.DependencyInjection;

namespace Gaming.API.Applications
{
    public class ChatApplicationBuilder
    {
        private IServiceCollection Services { get; }
        public ChatApplicationBuilder(IServiceCollection services)
        {
            this.Services = services;
        }
        public ChatApplicationBuilder UseMessageRepository<TRepository>() where TRepository : class, IMessageRepository
        {
            Services.AddSingleton<IMessageRepository, TRepository>();
            return this;
        }

        public ChatApplicationBuilder UseChannelRepsitory<TRepository>() where TRepository : class, IChannelRepository
        {
            Services.AddSingleton<IChannelRepository, TRepository>();
            return this;
        }

        public ChatApplication Build()
        {
            Services.AddTransient<Channel>();
            Services.AddSingleton<ChannelKanban>();


            var builder = new ContainerBuilder();
            builder.Populate(Services);

            return new ChatApplication(builder);
        }
    }
}
