using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands.CreateOrder;
using Orders.Application.Services.Interfaces;
using SharedLib.Domain.Mediator;
using System.Security.Claims;

namespace Orders.API.Controllers
{
    [Route("api/v1/orders")]
    public class OrdersController(IMediatorHandler mediator, IUserUseCase user) : MainController
    {
        private readonly IMediatorHandler _mediator = mediator;
        private readonly IUserUseCase _user = user;

        [HttpPost]
        public async Task<IResult> CreateAsync(CreateOrderCommand command, ClaimsPrincipal user)
        {
            var customerId = _user.GetUserId(user);
            command.SetCustomerId(customerId);

            return CustomResponse(await _mediator.SendCommand(command));
        }
    }
}
