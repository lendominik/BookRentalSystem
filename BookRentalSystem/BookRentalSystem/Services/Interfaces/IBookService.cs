﻿using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace BookRentalSystem.Services.Interfaces;

public interface IBookService
{
    Task<GetBookResponse> GetBook(int bookId);
    Task AddBook(AddBookRequest addBookRequest);
    Task UpdateBook(int bookId, UpdateBookRequest updateBookRequest);
    Task DeleteBook(int bookId);
}
