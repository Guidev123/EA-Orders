using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Core.Entities;

namespace Orders.Infrastructure.Persistence.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName).IsRequired();

            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems);
        }
    }
}
