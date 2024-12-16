using EA.CommonLib.Specs;
using Orders.Core.Entities;
using System.Linq.Expressions;

namespace Orders.Core.Specs
{
    public class VoucherDateSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression() =>
            voucher => voucher.ExpiresAt >= DateTime.Now;
    }
}
