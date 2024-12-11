﻿using BookRentalSystem.Entities;
using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Persistence;
using BookRentalSystem.Services.Interfaces;

namespace BookRentalSystem.Services;

[Service(ServiceLifetime.Scoped)]
public class BookService(AppDbContext dbContext) : IBookService
{
    public async Task AddBook(AddBookRequest addBookRequest)
    {
        var book = new Book
        {
            AuthorId = addBookRequest.authorId,
            CategoryId = addBookRequest.categoryId,
            Description = addBookRequest.description,
            Title = addBookRequest.title,
            PublisherId = addBookRequest.publisherId
        };

        await dbContext.Books.AddAsync(book);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteBook(int bookId)
    {
        var book = await dbContext.Books.FindAsync(bookId);

        if (book is null)
        {
            throw new NotFoundException("Book not found");
        }

        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GetBookResponse> GetBook(int bookId)
    {
        var book = await dbContext.Books.FindAsync(bookId);

        if (book is null)
        {
            throw new NotFoundException("Book not found");
        }

        return new GetBookResponse(book.Title, book.Description);
    }

    public async Task UpdateBook(int bookId, UpdateBookRequest updateBookRequest)
    {
        var book = await dbContext.Books.FindAsync(bookId);

        if (book is null)
        {
            throw new NotFoundException("Book not found");
        }

        book.Title = updateBookRequest.title;
        book.Description = updateBookRequest.description;

        await dbContext.SaveChangesAsync();
    }
}
