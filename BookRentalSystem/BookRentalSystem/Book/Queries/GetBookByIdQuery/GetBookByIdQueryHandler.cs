using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Book.Queries.GetBookByIdQuery;

public class GetBookByIdQueryHandler(IGenericRepository<Core.Entities.Book> repository) : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.BookId);

        if (book is null) 
            throw new NotFoundException("Book not found");

        return new BookDto
        {
            Author = book.Author,
            AuthorId = book.AuthorId,
            Category = book.Category,
            CategoryId = book.CategoryId,
            Description = book.Description,
            Publisher = book.Publisher,
            PublisherId = book.PublisherId,
            Reviews = book.Reviews,
            Title = book.Title
        };
    }
}
