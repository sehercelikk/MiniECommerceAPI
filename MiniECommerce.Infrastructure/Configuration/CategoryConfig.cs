using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Infrastructure.Configuration;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(a=>a.Id).HasName("PK_CTGRY_ID");

        builder.Property(a => a.Name).IsRequired().HasMaxLength(60);
        builder.Property(a => a.Description).HasMaxLength(500);

        builder.HasMany(a => a.Products)
            .WithOne(b => b.Category)
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
