using MediatR;

namespace Application.Book.Queries.GetAllBooksQuery;

public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
{

}
