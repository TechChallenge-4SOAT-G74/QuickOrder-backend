using FluentValidation.Results;
using QuickOrder.Adapters.Driven.ServiceBus.Messaging;

namespace QuickOrder.Adapters.Driven.ServiceBus
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
