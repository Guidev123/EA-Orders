using EA.CommonLib.Messages;
using EA.CommonLib.Responses;
using MediatR;
using Orders.Application.Commands.CreateOrder;
using Orders.Application.Events;
using Orders.Application.Mappers;
using Orders.Core.Entities;
using Orders.Core.Repositories;
using Orders.Core.Specs;
using Orders.Core.Specs.Validators;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderHandler(IOrderRepository orderRepository, IVoucherRepository voucherRepository) 
                                  : CommandHandler, IRequestHandler<CreateOrderCommand,
                                    Response<CreateOrderCommand>>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IVoucherRepository _voucherRepository = voucherRepository;
        public async Task<Response<CreateOrderCommand>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return new(null, 400, "Error", GetAllErrors(command.ValidationResult!));

            var order = command.MapToEntity();

            if (!await ApplyVoucherAsync(command, order))
                return new(null, 400, "Error", GetAllErrors(command.ValidationResult!));

            if (!ValidateOrder(order))
            {
                AddError(command.ValidationResult!, "The order price is not correct");
                return new(null, 400, "Error", GetAllErrors(command.ValidationResult!));
            }

            // TODO
            if (!ProcessPayment(order))
                return new(null, 400, "Error", GetAllErrors(command.ValidationResult!));

            order.AuthorizeOrder();

            order.AddEvent(new OrderPlacedEvent(order.Id, order.CustomerId));

            await _orderRepository.CreateAsync(order);
            await _orderRepository.UnitOfWork.CommitAsync();

            return new(null, 201, "Success");
        }

        #region Validators Methods
        private async Task<bool> ApplyVoucherAsync(CreateOrderCommand command, Order order)
        {
            if (!command.VoucherIsUsed) return true;

            var voucher = await _voucherRepository.GetVoucherByCodeAsync(command.VoucherCode);
            if(voucher is null)
            {
                AddError(command.ValidationResult!, "Voucher not found");
                return false;
            }

            var voucherValidation = new VoucherValidator().Validate(voucher);
            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ToList().ForEach(m =>  AddError(command.ValidationResult!, m.ErrorMessage));
                return false;
            }

            order.ApplyVoucher(voucher);
            voucher.DebitQuantity();

            _voucherRepository.Update(voucher);

            return true;
        }

        private bool ValidateOrder(Order order)
        {
            var orderOriginalPrice = order.TotalPrice;
            var orderDiscount = order.Discount;

            order.CalculateOrderPrice();

            if(order.TotalPrice != orderOriginalPrice) return false;
            if(order.Discount != orderDiscount) return false;

            return true;
        }

        private bool ProcessPayment(Order order) => true;
        #endregion
    }
}
