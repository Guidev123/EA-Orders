using EA.CommonLib.Messages;
using Orders.Application.DTOs;

namespace Orders.Application.Queries.GetLastOrder
{
    public class GetLastOrderQuery(Guid customerId) : Query<GetLastOrderQuery, OrderDTO>
    {
        public Guid CustomerId { get; private set; } = customerId;
    }
}
