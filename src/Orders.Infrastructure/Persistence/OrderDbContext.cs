using EA.CommonLib.Mediator;
using EA.CommonLib.Messages;
using Microsoft.EntityFrameworkCore;
using Orders.Core.Repositories;
using Orders.Infrastructure.Persistence.Extensions;

namespace Orders.Infrastructure.Persistence
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options, IMediatorHandler mediatorHandler)
               : DbContext(options), IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler = mediatorHandler;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(160)");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) property.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
        }
        public async Task<bool> CommitAsync()
        {
            var success = await SaveChangesAsync() > 0;

            if (success) await _mediatorHandler.PublishEvents(this);

            return success;
        }
    }
}
