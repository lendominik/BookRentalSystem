using MediatR;

namespace Application.Category.Queries.GetCategoryByIdQuery;

public record GetCategoryByIdQuery(int CategoryId) : IRequest<CategoryDto>;