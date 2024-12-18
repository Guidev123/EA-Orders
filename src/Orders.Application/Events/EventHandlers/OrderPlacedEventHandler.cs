using MediatR;
using SharedLib.Domain.Messages.Integration.OrderPlaced;
using SharedLib.MessageBus;

namespace Orders.Application.Events.EventHandlers
{
    public class OrderPlacedEventHandler(IMessageBus bus) : INotificationHandler<OrderPlacedEvent>
    {
        private readonly IMessageBus _bus = bus;
        public async Task Handle(OrderPlacedEvent @event, CancellationToken cancellationToken) =>
            await _bus.PublishAsync(new OrderPlacedIntegrationEvent(@event.CustomerId));
    }
}
