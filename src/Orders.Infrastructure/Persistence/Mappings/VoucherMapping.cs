using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Core.Entities;

namespace Orders.Infrastructure.Persistence.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Vouchers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(x => x.DiscountValue).IsRequired(false);
            builder.Property(x => x.Percentual).IsRequired(false);
        }
    }
}
