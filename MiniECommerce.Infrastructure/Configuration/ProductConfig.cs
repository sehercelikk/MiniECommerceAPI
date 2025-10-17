using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Infrastructure.Configuration;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(a=>a.Id).HasName("Pk_Product_Id");
        builder.Property(a=>a.Name).IsRequired().HasMaxLength(100);
        builder.Property(a=>a.Description).HasMaxLength(500);
        builder.Property(a=>a.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(a=>a.Stock).IsRequired();
        builder.Property(a => a.CategoryId).IsRequired();
    }
}
