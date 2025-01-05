using MediatR;

namespace Application.Author.Queries.GetAuthorByIdQuery;

public record GetAuthorByIdQuery(int AuthorId) : IRequest<AuthorDto>;