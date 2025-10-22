using AutoMapper;
using FluentValidation;
using MiniECommerce.Dtos.CategoryDtos;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Repositories.CategoryRepository;

namespace MiniECommerce.Application.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryDto> _createValidator;
    private readonly IValidator<UpdateCategoryDto> _updateValidator;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CreateCategoryDto> createValidator, IValidator<UpdateCategoryDto> updateValidator)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task AddAsync(CreateCategoryDto entity)
    {
        var valid = await _createValidator.ValidateAsync(entity);
        if (!valid.IsValid)
        {
            // Tüm hataları bir exception ile fırlatabiliriz
            throw new ValidationException(valid.Errors);
        }
        await _categoryRepository.AddAsync(_mapper.Map<Category>(entity));
    }


    public async Task DeleteAsync(int id)
    {
        var findEntity = await _categoryRepository.GetAsync(a => a.Id == id);
        if (findEntity != null)
        {
            await _categoryRepository.DeleteAsync(findEntity);
        }
        else
        {
            throw new Exception("Kayıt Bulunamadı");
        }
    }

    public async Task<List<ResponseCategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<List<ResponseCategoryDto>>(categories);
    }

    public async Task<ResponseCategoryDto> GetAsync(int id)
    {
        var findId = await _categoryRepository.GetAsync(a => a.Id == id);
        var mapEntity = _mapper.Map<ResponseCategoryDto>(findId);
        return mapEntity;
    }

    public async Task UpdateAsync(UpdateCategoryDto entity)
    {
        var valid = await _updateValidator.ValidateAsync(entity);
        var findEntity = await _categoryRepository.GetAsync(a => a.Id == entity.Id);
        if (!valid.IsValid)
        {
            throw new ValidationException(valid.Errors);
        }
        if(findEntity ==null)
        {
            throw new KeyNotFoundException($"Id {entity.Id} numaralı ürün bulunamadı.");
        }
        await _categoryRepository.UpdateAsync(_mapper.Map<Category>(entity));
    }
}
