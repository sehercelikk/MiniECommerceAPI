using AutoMapper;
using FluentValidation;
using MiniECommerce.Application.Dtos.CategoryDtos;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Repositories.CategoryRepository;

namespace MiniECommerce.Application.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryDto> _createValidator;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CreateCategoryDto> createValidator)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _createValidator = createValidator;
    }

    public async Task AddAsync(CreateCategoryDto entity)
    {
        var valid=await _createValidator.ValidateAsync(entity);
        if (!valid.IsValid)
        {
            // Tüm hataları bir exception ile fırlatabiliriz
            throw new ValidationException(valid.Errors);
        }
        await _categoryRepository.AddAsync(_mapper.Map<Category>(entity));
    }


    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResponseCategoryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseCategoryDto> GetAsync(ResponseCategoryDto entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateCategoryDto entity)
    {
        throw new NotImplementedException();
    }
}
