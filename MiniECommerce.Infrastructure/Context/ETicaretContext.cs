using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Funciton;

namespace MiniECommerce.Infrastructure.Context;

public class ETicaretContext : DbContext
{
    public ETicaretContext(DbContextOptions<ETicaretContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ETicaretInfo();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }
}
