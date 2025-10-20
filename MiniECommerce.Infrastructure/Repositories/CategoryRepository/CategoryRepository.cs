using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.Repositories.GenericRepository;

namespace MiniECommerce.Infrastructure.Repositories.CategoryRepository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ETicaretContext context) : base(context)
    {
    }
}
