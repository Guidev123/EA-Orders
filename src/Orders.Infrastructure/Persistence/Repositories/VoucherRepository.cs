using Orders.Core.Repositories;

namespace Orders.Infrastructure.Persistence.Repositories
{
    public class VoucherRepository(OrderDbContext context) : IVoucherRepository
    {
        private readonly OrderDbContext _context = context;
        public IUnitOfWork UnitOfWork => _context;
    }
}
