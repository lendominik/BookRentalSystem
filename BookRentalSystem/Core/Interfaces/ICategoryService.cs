using Core.Models.Requests;
using Core.Models.Responses;

namespace Core.Interfaces;

public interface ICategoryService
{
    Task<GetCategoryResponse> GetCategory(int categoryId);
    Task AddCategory(AddCategoryRequest addCategoryRequest);
    Task UpdateCategory(int categoryId, UpdateCategoryRequest updateCategoryRequest);
    Task DeleteCategory(int categoryId);
}
