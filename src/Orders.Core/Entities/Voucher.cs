using EA.CommonLib.DomainObjects;
using Orders.Core.Enums;

namespace Orders.Core.Entities
{
    public class Voucher : Entity, IAggregateRoot
    {
        public Voucher(string code, decimal? percentual,
                       decimal? discountValue, int? quantity,
                       EDiscountType discountType, DateTime createdAt,
                       DateTime usedAt, DateTime expiresAt,
                       bool isActive, bool isUsed)
        {
            Code = code;
            Percentual = percentual;
            DiscountValue = discountValue;
            Quantity = quantity;
            DiscountType = discountType;
            CreatedAt = createdAt;
            UsedAt = usedAt;
            ExpiresAt = expiresAt;
            IsActive = isActive;
            IsUsed = isUsed;
        }

        public string Code { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public int? Quantity { get; private set; }
        public EDiscountType DiscountType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UsedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsUsed { get; private set; }
    }
}
