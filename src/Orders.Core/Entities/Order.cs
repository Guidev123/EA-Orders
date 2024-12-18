﻿using Orders.Core.Enums;
using Orders.Core.ValueObjects;
using SharedLib.Domain.DomainObjects;

namespace Orders.Core.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public Order(Guid customerId, decimal totalPrice,
                     List<OrderItem> orderItems,
                     bool voucherIsUsed = false, decimal discount = 0)
        {
            Code = Guid.NewGuid().ToString()[..8];
            CustomerId = customerId;
            TotalPrice = totalPrice;
            _items = orderItems;
            Discount = discount;
            VoucherIsUsed = voucherIsUsed;
            CreatedAt = DateTime.Now;
            OrderStatus = EOrderStatus.WaitingPyment;
        }

        public string Code { get; private set; } = string.Empty;
        public Guid CustomerId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherIsUsed { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public EOrderStatus OrderStatus { get; private set; }
        public Address? Address { get; private set; }
        private readonly List<OrderItem> _items = [];
        public IReadOnlyCollection<OrderItem> OrderItems => _items;

        public void ApplyVoucher(Voucher voucher)
        {
            VoucherIsUsed = true;
            Voucher = voucher;
            VoucherId = voucher.Id;
        }

        public void ApplyAddress(Address address) => Address = address;

        public void CalculateOrderPrice()
        {
            TotalPrice = OrderItems.Sum(p => p.GetPrice());
            CalculateOrderPriceDiscount();
        }

        public void CalculateOrderPriceDiscount()
        {
            if (!VoucherIsUsed) return;

            decimal discount = 0;
            var value = TotalPrice;

            if(Voucher.DiscountType == EDiscountType.Percentual)
            {
                if (Voucher.Percentual.HasValue)
                {
                    discount = (value * Voucher.Percentual.Value) / 100;
                    value -= discount;
                }
            }
            else
            {
                if (Voucher.Percentual.HasValue)
                {
                    discount = Voucher.DiscountValue!.Value;
                    value -= discount;
                }
            }

            TotalPrice = value < 0 ? 0 : value;
            Discount = discount;    
        }

        public void AuthorizeOrder() => OrderStatus = EOrderStatus.Authorized;
        public void CancelOrder() => OrderStatus = EOrderStatus.Canceled;
        public void PayOrder() => OrderStatus = EOrderStatus.Paid;
        public void DeliveryOrder() => OrderStatus = EOrderStatus.Delivered;

        //EF Rel
        protected Order() { }
        public Voucher Voucher { get; set; } = null!;
    }
}
