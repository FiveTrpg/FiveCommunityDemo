using EmberKernel.Services.EventBus;

namespace Gaming.API.Domain.Chat
{
    public class ChatterJoinedEvent : Event<ChatterJoinedEvent>
    {
        public Chatter Chatter { get; set; }
        public Channel Channel { get; set; }
    }
}
