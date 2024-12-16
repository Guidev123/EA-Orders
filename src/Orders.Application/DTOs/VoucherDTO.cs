namespace Orders.Application.DTOs
{
    public record VoucherDTO(string Code, decimal? Percentual,
                             decimal? DiscountValue, int DiscountType);
}
