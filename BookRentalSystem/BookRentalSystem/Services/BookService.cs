using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Services.Interfaces;

namespace BookRentalSystem.Services;

[Service(ServiceLifetime.Scoped)]
public class BookService : IBookService
{
    public void AddBook(AddBookRequest addBookRequest)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(DeleteBookRequest deleteBookRequest)
    {
        throw new NotImplementedException();
    }

    public GetBookResponse GetBook(int bookId)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(UpdateBookRequest updateBookRequest)
    {
        throw new NotImplementedException();
    }
}
