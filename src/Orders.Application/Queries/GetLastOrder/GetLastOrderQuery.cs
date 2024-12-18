using Orders.Application.DTOs;
using SharedLib.Domain.Messages;

namespace Orders.Application.Queries.GetLastOrder
{
    public class GetLastOrderQuery(Guid customerId) : Query<GetLastOrderQuery, OrderDTO>
    {
        public Guid CustomerId { get; private set; } = customerId;
    }
}
