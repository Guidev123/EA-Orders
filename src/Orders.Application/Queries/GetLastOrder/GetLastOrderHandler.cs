using EA.CommonLib.Messages;
using EA.CommonLib.Responses;
using MediatR;
using Orders.Application.DTOs;

namespace Orders.Application.Queries.GetLastOrder
{
    public class GetLastOrderHandler
               : CommandHandler,
                 IRequestHandler<GetLastOrderQuery, Response<OrderDTO>>
    {
        public async Task<Response<OrderDTO>> Handle(GetLastOrderQuery request, CancellationToken cancellationToken)
        {

        }
    }
}
