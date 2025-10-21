using MiniECommerce.Domain.Concrete;
using MiniECommerce.Dtos.ProductDtos;
using MiniECommerce.Infrastructure.Repositories.GenericRepository;

namespace MiniECommerce.Infrastructure.Repositories.ProductRepository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<ResponseProductDto>> GetProductWithCategory(int id);
}
