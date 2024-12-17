using EA.CommonLib.Controllers;
using EA.CommonLib.Mediator;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands.CreateOrder;
using Orders.Application.Services.Interfaces;

namespace Orders.API.Controllers
{
    [Route("api/v1/orders")]
    public class OrdersController(IMediatorHandler mediator, IUserService user) : MainController
    {
        private readonly IMediatorHandler _mediator = mediator;
        private readonly IUserService _user = user;

        [HttpPost]
        public async Task<IResult> CreateAsync(CreateOrderCommand command)
        {
            var customerId = _user.GetUserId();
            command.SetCustomerId(customerId);

            return CustomResponse(await _mediator.SendCommand(command));
        }
    }
}
