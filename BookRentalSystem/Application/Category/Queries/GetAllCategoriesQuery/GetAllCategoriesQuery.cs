using MediatR;

namespace Application.Category.Queries.GetAllCategoriesQuery;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}
