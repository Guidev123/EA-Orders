using Orders.Core.Enums;
using Orders.Core.Specs;
using SharedLib.Domain.DomainObjects;

namespace Orders.Core.Entities
{
    public class Voucher : Entity, IAggregateRoot
    {
        public Voucher(string code, decimal? percentual,
                       decimal? discountValue, int? quantity,
                       EDiscountType? discountType)
        {
            Code = code;
            Percentual = percentual;
            DiscountValue = discountValue;
            Quantity = quantity;
            DiscountType = discountType ?? EDiscountType.Value;
            IsActive = true;
            CreatedAt = DateTime.Now;
            IsUsed = false;
        }
        protected Voucher() { }

        public string Code { get; private set; } = string.Empty;
        public decimal? Percentual { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public int? Quantity { get; private set; }
        public EDiscountType DiscountType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UsedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsUsed { get; private set; }

        public bool IsValidToUse() =>
             new VoucherActiveSpecification()
                .And(new VoucherDateSpecification())
                .And(new VoucherQuantitySpecification()).IsSatisfiedBy(this);


        public void SetAsUsed()
        {
            IsActive = false;
            IsUsed = true;
            Quantity = 0;
            UsedAt = DateTime.Now;
        }

        public void DebitQuantity()
        {
            Quantity -= 1;
            if (Quantity >= 1) return;

            SetAsUsed();
        }

        public void SetExpirationDate(DateTime expirationDate) => ExpiresAt = expirationDate;
    }
}
