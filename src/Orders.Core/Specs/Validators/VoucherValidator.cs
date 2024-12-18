using Orders.Core.Entities;
using SharedLib.Domain.Specifications.Validations;

namespace Orders.Core.Specs.Validators
{
    public class VoucherValidator : SpecValidator<Voucher>
    {
        public VoucherValidator()
        {
            var dateSpec = new VoucherDateSpecification();
            var qtdeSpec = new VoucherQuantitySpecification();
            var activeSpec = new VoucherActiveSpecification();

            Add("dateSpec", new(dateSpec, "Voucher is expired."));
            Add("quantitySpec", new(qtdeSpec, "This voucher has already been used."));
            Add("activeSpec", new(activeSpec, "This voucher is not active."));
        }
    }
}
