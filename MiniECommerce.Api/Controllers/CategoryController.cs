using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Dtos.CategoryDtos;
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

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        var findEntity = await _categoryService.GetAsync(model.Id);
        if (findEntity.Id == model.Id)
        {
            await _categoryService.UpdateAsync(model);
            return Ok();

        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok();
    }
}
