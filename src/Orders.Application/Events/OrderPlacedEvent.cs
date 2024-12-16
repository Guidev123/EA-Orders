using EA.CommonLib.Messages;

namespace Orders.Application.Events
{
    public class OrderPlacedEvent : Event
    {
        public OrderPlacedEvent(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
    }
}
