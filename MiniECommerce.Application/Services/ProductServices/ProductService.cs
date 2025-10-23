using AutoMapper;
using FluentValidation;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Dtos.ProductDtos;
using MiniECommerce.Infrastructure.Repositories.CategoryRepository;
using MiniECommerce.Infrastructure.Repositories.ProductRepository;

namespace MiniECommerce.Application.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductDto> _createValid;
    private readonly IValidator<UpdateProductDto> _updateValid;
    public ProductService(IProductRepository productRepository, IMapper mapper, IValidator<CreateProductDto> createValid, IValidator<UpdateProductDto> updateValid, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _createValid = createValid;
        _updateValid = updateValid;
        _categoryRepository = categoryRepository;
    }

    public async Task AddAsync(CreateProductDto entity)
    {
        var valid = await _createValid.ValidateAsync(entity);
        var findCategory = await _categoryRepository.GetAsync(a => a.Id == entity.CategoryId);
        if(findCategory ==null)
        {
            throw new Exception("Kategori Bulunamadı");
        }
        if (!valid.IsValid) 
        {
            throw new ValidationException(valid.Errors);
        }
        await _productRepository.AddAsync(_mapper.Map<Product>(entity));
    }

    public async Task DeleteAsync(int id)
    {
        var findEntity = await _productRepository.GetAsync(a => a.Id == id);
        if (findEntity is not null)
        {
            await _productRepository.DeleteAsync(findEntity);
        }
        else
        {
            throw new Exception("Kayıt Bulunamadı");
        }
    }

    public Task<List<ResponseProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    public async Task<List<ResponseProductDto>> GetAllWithCategory(int id)
    {
        var findCategory = await _productRepository.GetAsync(a => a.CategoryId == id);
        if (findCategory != null)
        {
            var product = await _productRepository.GetProductWithCategory(id);
            return _mapper.Map<List<ResponseProductDto>>(product);
        }
        return null;
    }

    public async Task<ResponseProductDto> GetAsync(int id)
    {
        var findEntity = await _productRepository.GetAsync(a => a.Id == id);
        var mapEntity = _mapper.Map<ResponseProductDto>(findEntity);
        return mapEntity;
    }

    public async Task UpdateAsync(UpdateProductDto entity)
    {
        var findEntity = await _productRepository.GetAsync(a => a.Id == entity.Id);
        var findCategory = await _categoryRepository.GetAsync(a => a.Id == entity.CategoryId);
        var valid = await _updateValid.ValidateAsync(entity);
        if(findCategory==null)
        {
            throw new Exception("Kategori Bulunamadı");
        }
        if (!valid.IsValid)
        {
            throw new ValidationException(valid.Errors);
        }
        if (findEntity == null)
        {
            throw new KeyNotFoundException($"Id {entity.Id} numaralı ürün bulunamadı.");
        }
        await _productRepository.UpdateAsync(_mapper.Map<Product>(entity));
    }
}
