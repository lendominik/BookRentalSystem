using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace BookRentalSystem.Interfaces;

public interface ICategoryService
{
    Task<GetCategoryResponse> GetCategory(int categoryId);
    Task AddCategory(AddCategoryRequest addCategoryRequest);
    Task UpdateCategory(int categoryId, UpdateCategoryRequest updateCategoryRequest);
    Task DeleteCategory(int categoryId);
}
