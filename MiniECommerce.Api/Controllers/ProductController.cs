using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Services.ProductServices;
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
}
