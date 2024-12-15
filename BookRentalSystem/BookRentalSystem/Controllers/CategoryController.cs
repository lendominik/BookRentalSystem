using Core.Interfaces;
using Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/category")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategory([FromRoute]int categoryId)
    {
        var category = await categoryService.GetCategory(categoryId);
        return Ok(category);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory([FromRoute]int categoryId)
    {
        await categoryService.DeleteCategory(categoryId);
        return Ok();
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]int categoryId, [FromBody]UpdateCategoryRequest updateCategoryRequest)
    {
        await categoryService.UpdateCategory(categoryId, updateCategoryRequest);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody]AddCategoryRequest addCategoryRequest)
    {
        await categoryService.AddCategory(addCategoryRequest);
        return Ok();
    }
}
