using Microsoft.EntityFrameworkCore;
using Orders.Core.Entities;
using Orders.Core.Repositories;

namespace Orders.Infrastructure.Persistence.Repositories
{
    public class VoucherRepository(OrderDbContext context) : IVoucherRepository
    {
        private readonly OrderDbContext _context = context;
        public IUnitOfWork UnitOfWork => _context;

        public async Task<Voucher?> GetVoucherByCodeAsync(string code) => 
            await _context.Vouchers.AsNoTracking().FirstOrDefaultAsync(x => x.Code == code);

        public void Update(Voucher voucher) => _context.Vouchers.Update(voucher);
    }
}
