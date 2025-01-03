using MediatR;

namespace Application.Author.Queries.GetAllAuthorsQuery;

public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
{
}
