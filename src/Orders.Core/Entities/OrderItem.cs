﻿using EA.CommonLib.DomainObjects;

namespace Orders.Core.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Guid orderId, Guid productId,
                         string productName, int quantity,
                         decimal unitValue, string? productImage = null)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitValue = unitValue;
            ProductImage = productImage;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }
        public string? ProductImage { get; private set; }

        //EF Rel
        public Order Order { get; set; } = null!;
        internal decimal GetPrice() => Quantity * UnitValue;    
    }
}