namespace Orders.Application.DTOs
{
    public record VoucherDTO(string code, decimal? percentual, decimal? discountValue, int discountType);
}
