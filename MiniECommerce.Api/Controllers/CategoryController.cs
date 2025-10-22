using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Dtos.CategoryDtos;
using MiniECommerce.Application.Services.CategoryServices;
using System.Threading.Tasks;

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

    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var categories= await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CreateCategoryDto model)
    {
        await _categoryService.AddAsync(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        await _categoryService.UpdateAsync(model);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok();
    }
}
