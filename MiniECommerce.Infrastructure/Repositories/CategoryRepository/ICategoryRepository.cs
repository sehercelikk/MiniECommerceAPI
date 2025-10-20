using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Repositories.GenericRepository;

namespace MiniECommerce.Infrastructure.Repositories.CategoryRepository;

public interface ICategoryRepository : IGenericRepository<Category>
{
}
