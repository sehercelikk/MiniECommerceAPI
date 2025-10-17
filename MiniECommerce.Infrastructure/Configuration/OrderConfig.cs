using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Infrastructure.Configuration;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(a=>a.Id).HasName("PK_Order_ID");

        builder.Property(a=>a.TotalPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(a=>a.UserId)
            .IsRequired();

        builder.HasMany(a=>a.OrderItems)
            .WithOne(b=>b.Order)
            .HasForeignKey(a=>a.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
