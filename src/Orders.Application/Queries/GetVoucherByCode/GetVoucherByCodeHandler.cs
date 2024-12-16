using EA.CommonLib.Responses;
using MediatR;
using Orders.Application.DTOs;
using Orders.Application.Mappers;
using Orders.Core.Repositories;

namespace Orders.Application.Queries.GetVoucherByCode
{
    public class GetVoucherByCodeHandler(IVoucherRepository voucherRepository)
                                       : IRequestHandler<GetVoucherByCodeQuery, Response<VoucherDTO>>
    {
        private readonly IVoucherRepository _voucherRepository = voucherRepository;
        public async Task<Response<VoucherDTO>> Handle(GetVoucherByCodeQuery request, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepository.GetVoucherByCodeAsync(request.Code);
            if (voucher is null) return new(null, 404);

            if (!voucher.IsValidToUse()) return new(null, 404);

            return new(voucher.MapFromEntity(), 200);
        }
    }
}
