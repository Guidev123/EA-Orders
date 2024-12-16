using Orders.Application.DTOs;
using Orders.Core.Entities;

namespace Orders.Application.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItem MapFromEntity(OrderItemDTO item) =>
            new(item.OrderId, item.ProductId, item.Name, item.Quantity, item.Price, item.Image);
    }
}
