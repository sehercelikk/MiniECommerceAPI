using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Dtos.CategoryDtos;
using MiniECommerce.Application.Services.CategoryServices;

namespace MiniECommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CreateCategoryDto model)
    {
        await _categoryService.AddAsync(model);
        return Ok();
    }
}
