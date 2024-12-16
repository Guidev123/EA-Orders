using EA.CommonLib.Controllers;
using EA.CommonLib.Mediator;
using EA.CommonLib.Responses;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.DTOs;
using Orders.Application.Queries.GetVoucherByCode;
using System.Net;

namespace Orders.API.Controllers
{
    [Route("api/v1/vouchers")]
    public class VouchersController(IMediatorHandler mediator) : MainController
    {
        private readonly IMediatorHandler _mediator = mediator;

        [HttpGet("{code}")]
        [ProducesResponseType(typeof(Response<VoucherDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IResult> GetByCodeAsync(string code) =>
            CustomResponse(await _mediator.SendQuery<GetVoucherByCodeQuery, VoucherDTO>(new(code)));
    }
}
