using BookRentalSystem.Entities;
using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Persistence;
using BookRentalSystem.Services.Interfaces;

namespace BookRentalSystem.Services;

[Service(ServiceLifetime.Scoped)]
public class CategoryService(AppDbContext dbContext) : ICategoryService
{
    public async Task AddCategory(AddCategoryRequest addCategoryRequest)
    {
        var category = new Category
        {
            Name = addCategoryRequest.name,
            Description = addCategoryRequest.description
        };

        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
        var category = await dbContext.Categories.FindAsync(categoryId);

        if (category is null)
        {
            throw new NotFoundException("Category not found");
        }

        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GetCategoryResponse> GetCategory(int categoryId)
    {
        var category = await dbContext.Categories.FindAsync(categoryId);

        if (category is null)
        {
            throw new NotFoundException("Category not found");
        }

        return new GetCategoryResponse(category.Name, category.Description);
    }

    public async Task UpdateCategory(int categoryId, UpdateCategoryRequest updateCategoryRequest)
    {
        var category = await dbContext.Categories.FindAsync(categoryId);

        if (category is null)
        {
            throw new NotFoundException("Category not found");
        }

        category.Name = updateCategoryRequest.name;
        category.Description = updateCategoryRequest.description;

        await dbContext.SaveChangesAsync();
    }
}