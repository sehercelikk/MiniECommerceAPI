using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Infrastructure.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id).HasName("Pk_User_Id");
        builder.Property(a => a.UserName).IsRequired().HasMaxLength(50);
        builder.Property(a => a.Role).IsRequired();
        builder.Property(a => a.Email).IsRequired();
        builder.Property(a => a.PasswordHash).IsRequired();

        builder.HasMany(a => a.Orders)
            .WithOne(b => b.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
