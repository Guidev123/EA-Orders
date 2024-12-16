using Microsoft.EntityFrameworkCore;
using Orders.Core.Entities;
using Orders.Core.Repositories;

namespace Orders.Infrastructure.Persistence.Repositories
{
    public class OrderRepository(OrderDbContext context) : IOrderRepository
    {
        private readonly OrderDbContext _context = context;
        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(Order order) => await _context.AddAsync(order);
        public void UpdateAsync(Order order) => _context.Update(order);

        public async Task<List<Order>?> GetAllAsync(int pageNumber, int pageSize, Guid customerId) =>
            await _context.Orders.Include(x => x.OrderItems).AsNoTracking()
            .Where(x => x.CustomerId == customerId).OrderBy(x => x.CreatedAt)
            .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        public async Task<Order?> GetByIdAsync(Guid id) =>
            await _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);

        public async Task<OrderItem?> GetItemByIdAsync(Guid id) =>
            await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);

        public async Task<OrderItem?> GetItemByOrder(Guid orderId, Guid productId) =>
            await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId);
    }
}
