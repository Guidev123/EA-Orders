using Orders.Application.DTOs;
using Orders.Core.Entities;

namespace Orders.Application.Mappers
{
    public static class VoucherMapper
    {
        public static VoucherDTO MapFromEntity(this Voucher voucher) =>
            new(voucher.Code, voucher.Percentual, voucher.DiscountValue, (int)voucher.DiscountType);
    }
}
