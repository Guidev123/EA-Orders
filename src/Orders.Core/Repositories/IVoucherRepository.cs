using Orders.Core.Entities;

namespace Orders.Core.Repositories
{
    public interface IVoucherRepository
    {
        Task<Voucher?> GetVoucherByCodeAsync(string code);   
        IUnitOfWork UnitOfWork { get; }
    }
}
