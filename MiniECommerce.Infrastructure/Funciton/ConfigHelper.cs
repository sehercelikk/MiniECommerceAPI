using Microsoft.EntityFrameworkCore;
using MiniECommerce.Infrastructure.Configuration;

namespace MiniECommerce.Infrastructure.Funciton;

public static class ConfigHelper
{
    public static void ETicaretInfo(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfig());
        builder.ApplyConfiguration(new ProductConfig());
        builder.ApplyConfiguration(new OrderConfig());
        builder.ApplyConfiguration(new OrderItemConfig());
        builder.ApplyConfiguration(new UserConfig());
    }
}
