using EmberKernel.Services.EventBus;

namespace Gaming.API.Domain.Chat
{
    public class ChatterLeavedEvent : Event<ChatterLeavedEvent>
    {
        public Chatter Chatter { get; set; }
        public Channel Channel { get; set; }
    }
}
