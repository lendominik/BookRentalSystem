using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace BookRentalSystem.Services.Interfaces;

public interface IBookService
{
    GetBookResponse GetBook(int bookId);
    void AddBook(AddBookRequest addBookRequest);
    void UpdateBook(UpdateBookRequest updateBookRequest);
    void DeleteBook(DeleteBookRequest deleteBookRequest);
}
