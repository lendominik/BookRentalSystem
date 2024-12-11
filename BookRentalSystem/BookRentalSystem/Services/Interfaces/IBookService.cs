using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace BookRentalSystem.Services.Interfaces;

public interface IBookService
{
    Task<GetBookResponse> GetBook(int bookId);
    Task AddBook(AddBookRequest addBookRequest);
    Task UpdateBook(UpdateBookRequest updateBookRequest);
    Task DeleteBook(DeleteBookRequest deleteBookRequest);
}
