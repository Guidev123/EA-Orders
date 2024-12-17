using EA.CommonLib.Messages;
using Orders.Application.DTOs;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : Command<CreateOrderCommand>
    {
        public CreateOrderCommand(Guid customerId, decimal totalPrice,
                                  List<OrderItemDTO> orderItems, string voucherCode,
                                  bool voucherIsUsed, decimal discount, AddressDTO address)
        {
            AggregateId = Guid.NewGuid();
            CustomerId = customerId;
            TotalPrice = totalPrice;
            OrderItems = orderItems;
            VoucherCode = voucherCode;
            VoucherIsUsed = voucherIsUsed;
            Discount = discount;
            Address = address;
        }

        public Guid CustomerId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public List<OrderItemDTO> OrderItems { get; private set; }
        public string VoucherCode { get; private set; }
        public bool VoucherIsUsed { get; private set; }
        public decimal Discount { get; private set; }
        public AddressDTO Address { get; private set; }

        public void SetCustomerId(Guid customerId) => CustomerId = customerId;
        public override bool IsValid()
        {
            ValidationResult = new CreateOrderValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
