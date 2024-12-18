using Orders.Core.Entities;
using SharedLib.Domain.Specifications;
using System.Linq.Expressions;

namespace Orders.Core.Specs
{
    public class VoucherActiveSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() =>
            voucher => voucher.IsActive && !voucher.IsUsed;
    }
}
