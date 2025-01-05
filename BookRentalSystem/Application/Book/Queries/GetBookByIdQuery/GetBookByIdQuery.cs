using MediatR;

namespace Application.Book.Queries.GetBookByIdQuery;

public record GetBookByIdQuery(int BookId) : IRequest<BookDto>;
