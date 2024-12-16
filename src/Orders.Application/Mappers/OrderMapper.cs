using Orders.Application.Commands.CreateOrder;
using Orders.Core.Entities;
using Orders.Core.ValueObjects;

namespace Orders.Application.Mappers
{
    public static class OrderMapper
    {
        public static Order MapToEntity(this CreateOrderCommand command)
        {
            var address = new Address
            {
                City = command.Address.City,
                AdditionalInfo = command.Address.AdditionalInfo,
                State = command.Address.State,
                Street = command.Address.Street,
                ZipCode = command.Address.ZipCode,
                Neighborhood = command.Address.Neighborhood,
                Number = command.Address.Number,
            };

            var order = new Order(command.CustomerId, command.TotalPrice,
                command.OrderItems.Select(OrderItemMapper.MapFromEntity).ToList(),
                command.VoucherIsUsed, command.Discount);

            order.ApplyAddress(address);

            return order;
        }
    }
}
