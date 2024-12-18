using SharedLib.Domain.Messages;

namespace Orders.Application.Events
{
    public class OrderPlacedEvent : Event
    {
        public OrderPlacedEvent(Guid orderId, string customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

        public Guid OrderId { get; private set; }
        public string CustomerId { get; private set; }
    }
}
