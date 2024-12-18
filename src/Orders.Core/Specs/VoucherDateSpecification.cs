using Orders.Core.Entities;
using SharedLib.Domain.Specifications;
using System.Linq.Expressions;

namespace Orders.Core.Specs
{
    public class VoucherDateSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() =>
            voucher => voucher.ExpiresAt >= DateTime.Now;
    }
}
