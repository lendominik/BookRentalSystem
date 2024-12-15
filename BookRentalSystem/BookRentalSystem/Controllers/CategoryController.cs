﻿using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/category")]
[ApiController]
public class CategoryController(IGenericRepository<Category> repository) : ControllerBase
{
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategory([FromRoute]int categoryId)
    {
        var category = await repository.GetByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException("Category not found");

        return Ok(category);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory([FromRoute]int categoryId)
    {
        var category = await repository.GetByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException("Category not found");

        repository.Delete(category);
        return Ok();
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]int categoryId, [FromBody]UpdateCategoryRequest updateCategoryRequest)
    {
        var category = await repository.GetByIdAsync(categoryId);

        if (category is null)
            throw new NotFoundException("Category not found");

        category.Name = updateCategoryRequest.name;
        category.Description = updateCategoryRequest.description;

        repository.Update(category);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddCategory([FromBody]AddCategoryRequest addCategoryRequest)
    {
        var category = new Category
        {
            Name = addCategoryRequest.name,
            Description = addCategoryRequest.description
        };

        repository.Add(category);
        return Ok();
    }
}
