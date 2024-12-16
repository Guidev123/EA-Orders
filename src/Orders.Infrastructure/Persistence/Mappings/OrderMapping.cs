using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Core.Entities;

namespace Orders.Infrastructure.Persistence.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.Address, e =>
            {
                e.Property(x => x.Street).HasColumnName("Street");
                e.Property(x => x.City).HasColumnName("City");
                e.Property(x => x.AdditionalInfo).HasColumnName("AdditionalInfo");
                e.Property(x => x.ZipCode).HasColumnName("ZipCode");
                e.Property(x => x.State).HasColumnName("State");
                e.Property(x => x.Number).HasColumnName("Number");
                e.Property(x => x.Neighborhood).HasColumnName("Neighborhood");
            });

            // 1 : N
            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        }
    }
}
