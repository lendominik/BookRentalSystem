using Core.Models.Requests;
using Core.Models.Responses;

namespace Core.Interfaces;

public interface IBookService
{
    Task<GetBookResponse> GetBook(int bookId);
    Task AddBook(AddBookRequest addBookRequest);
    Task UpdateBook(int bookId, UpdateBookRequest updateBookRequest);
    Task DeleteBook(int bookId);
}
