using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Category.Queries.GetCategoryByIdQuery;

public class GetCategoryByIdQueryHandler(IGenericRepository<Core.Entities.Category> repository) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.CategoryId);

        if (category is null)
            throw new NotFoundException("Category not found");

        return new CategoryDto
        {
            Books = category.Books,
            Description = category.Description,
            Name = category.Name
        };
    }
}
