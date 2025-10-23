using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Services.CategoryServices;
using MiniECommerce.Application.Services.ProductServices;
using MiniECommerce.Application.Services.UserServices;
using MiniECommerce.Infrastructure.Repositories.CategoryRepository;
using MiniECommerce.Infrastructure.Repositories.ProductRepository;
using MiniECommerce.Infrastructure.Repositories.UserRepository;

namespace MiniECommerce.Application.AddDependenciesScoped;

public static class CustomExtension
{
    public static void AddDependenciesScoped(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
