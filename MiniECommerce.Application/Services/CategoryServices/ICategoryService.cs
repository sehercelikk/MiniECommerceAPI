using MiniECommerce.Application.Dtos.CategoryDtos;
using MiniECommerce.Application.Services.GenericService;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Application.Services.CategoryServices;

public interface ICategoryService : IGenericService<ResponseCategoryDto,UpdateCategoryDto,CreateCategoryDto>
{
}
