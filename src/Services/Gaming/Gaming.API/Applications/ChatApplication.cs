using Autofac;
using Gaming.API.Utils;

namespace Gaming.API.Applications
{
    public class ChatApplication : AutofacSelfContainer<ChatApplication>
    {
        public ChatApplication(ContainerBuilder builder) : base(builder)
        {
        }


    }
}
