namespace Orders.Application.DTOs
{
    public record OrderDTO(Guid Id, int Code, int Status,
                           DateTime Date, decimal TotalPrice,
                           decimal Discount, string VoucherCode,
                           bool VoucherIsUsed, List<OrderItemDTO> OrderItems,
                           AddressDTO Address); 
}
