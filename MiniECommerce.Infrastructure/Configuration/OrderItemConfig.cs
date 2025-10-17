using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Infrastructure.Configuration;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(a=>a.Id).HasName("PK_ORDR_ITM_ID");
        builder.Property(a => a.Quantity).IsRequired();
        builder.Property(a => a.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(a => a.OrderId).IsRequired();
        builder.Property(a => a.ProductId).IsRequired();
    }
}
