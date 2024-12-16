using EA.CommonLib.Mediator;
using EA.CommonLib.Messages;
using Microsoft.EntityFrameworkCore;
using Orders.Core.Entities;
using Orders.Core.Repositories;
using Orders.Infrastructure.Persistence.Extensions;

namespace Orders.Infrastructure.Persistence
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options, IMediatorHandler mediatorHandler)
               : DbContext(options), IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler = mediatorHandler;

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(160)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);

            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                rel.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }

        public async Task<bool> CommitAsync()
        {
            var success = await SaveChangesAsync() > 0;

            if (success) await _mediatorHandler.PublishEvents(this);

            return success;
        }
    }
}
