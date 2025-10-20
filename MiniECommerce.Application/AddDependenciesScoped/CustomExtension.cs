using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Services.CategoryServices;
using MiniECommerce.Infrastructure.Repositories.CategoryRepository;

namespace MiniECommerce.Application.AddDependenciesScoped;

public static class CustomExtension
{
    public static void AddDependenciesScoped(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}
