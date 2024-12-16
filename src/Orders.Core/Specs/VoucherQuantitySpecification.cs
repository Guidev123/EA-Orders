using EA.CommonLib.Specs;
using Orders.Core.Entities;
using System.Linq.Expressions;

namespace Orders.Core.Specs
{
    public class VoucherQuantitySpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() =>
            voucher => voucher.Quantity > 0;
    }
}
