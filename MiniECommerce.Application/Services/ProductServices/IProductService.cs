using MiniECommerce.Application.Services.GenericService;
using MiniECommerce.Dtos.ProductDtos;

namespace MiniECommerce.Application.Services.ProductServices;

public interface IProductService : IGenericService<ResponseProductDto,UpdateProductDto,CreateProductDto>
{
    Task<List<ResponseProductDto>> GetAllWithCategory(int id);
}
