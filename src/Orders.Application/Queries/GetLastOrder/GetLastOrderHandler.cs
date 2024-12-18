using MediatR;
using Orders.Application.DTOs;
using SharedLib.Domain.Messages;
using SharedLib.Domain.Responses;

namespace Orders.Application.Queries.GetLastOrder
{
    public class GetLastOrderHandler
               : CommandHandler,
                 IRequestHandler<GetLastOrderQuery, Response<OrderDTO>>
    {
        public async Task<Response<OrderDTO>> Handle(GetLastOrderQuery request, CancellationToken cancellationToken)
        {
            return new(null);
        }
    }
}
