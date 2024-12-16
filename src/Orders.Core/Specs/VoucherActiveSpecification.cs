using EA.CommonLib.Specs;
using Orders.Core.Entities;
using System.Linq.Expressions;

namespace Orders.Core.Specs
{
    public class VoucherActiveSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() =>
            voucher => voucher.IsActive && !voucher.IsUsed;
    }
}
