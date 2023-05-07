using SimpleEventBus;
using SimpleEventBus.Interfaces;

namespace SellerTestScripts.Events
{
    public static class EventStreams
    {
        public static IEventBus Game { get; } = new EventBus();
    }
}