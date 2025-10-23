using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Services.ProductServices;
using MiniECommerce.Dtos.ProductDtos;
using System.Threading.Tasks;

namespace MiniECommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllProduct(int id)
    {
        var products = await _productService.GetAllWithCategory(id);
        if (products == null || !products.Any())
            return NotFound(new { Message = "Bu kategoriye ait ürün bulunamadı." });
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductDto model)
    {
        await _productService.AddAsync(model);
        return Ok(model);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
    {
        await _productService.UpdateAsync(model);
        return Ok(model);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteAsync(id);
        return Ok();
    }
}
