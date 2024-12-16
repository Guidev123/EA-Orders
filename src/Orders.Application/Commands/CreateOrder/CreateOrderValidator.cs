using FluentValidation;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(order => order.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(order => order.TotalPrice)
                .GreaterThan(0).WithMessage("Total price must be greater than zero.");

            RuleFor(order => order.OrderItems)
                .NotNull().WithMessage("Order items are required.")
                .NotEmpty().WithMessage("Order must have at least one item.")
                .ForEach(item =>
                {
                    item.ChildRules(orderItem =>
                    {
                        orderItem.RuleFor(i => i.ProductId)
                            .NotEmpty().WithMessage("Product ID is required.");
                        orderItem.RuleFor(i => i.Quantity)
                            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
                        orderItem.RuleFor(i => i.Price)
                            .GreaterThan(0).WithMessage("Price must be greater than zero.");
                    });
                });

            RuleFor(order => order.VoucherCode)
                .MaximumLength(50).WithMessage("Voucher code must not exceed 50 characters.");

            RuleFor(order => order.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be a non-negative value.")
                .LessThanOrEqualTo(order => order.TotalPrice).WithMessage("Discount cannot exceed the total price.");

            RuleFor(order => order.Address)
                .NotNull().WithMessage("Address is required.")
                .ChildRules(address =>
                {
                    address.RuleFor(a => a.Street)
                        .NotEmpty().WithMessage("Street is required.");
                    address.RuleFor(a => a.Number)
                        .NotEmpty().WithMessage("Number is required.");
                    address.RuleFor(a => a.Neighborhood)
                        .NotEmpty().WithMessage("Neighborhood is required.");
                    address.RuleFor(a => a.ZipCode)
                        .NotEmpty().WithMessage("Zip code is required.")
                        .Matches("^\\d{5}-\\d{3}$").WithMessage("Zip code must follow the format 00000-000.");
                    address.RuleFor(a => a.City)
                        .NotEmpty().WithMessage("City is required.");
                    address.RuleFor(a => a.State)
                        .NotEmpty().WithMessage("State is required.")
                        .Length(2).WithMessage("State must be a 2-letter abbreviation.");
                });
        }
    }
}
