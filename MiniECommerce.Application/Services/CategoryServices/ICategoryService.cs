using MiniECommerce.Dtos.CategoryDtos;
using MiniECommerce.Application.Services.GenericService;

namespace MiniECommerce.Application.Services.CategoryServices;

public interface ICategoryService : IGenericService<ResponseCategoryDto,UpdateCategoryDto,CreateCategoryDto>
{
}
