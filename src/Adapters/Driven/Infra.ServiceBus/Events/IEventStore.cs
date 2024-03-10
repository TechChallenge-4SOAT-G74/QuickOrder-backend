using QuickOrder.Adapters.Driven.ServiceBus.Messaging;

namespace QuickOrder.Adapters.Driven.ServiceBus.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
