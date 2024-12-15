using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/book")]
[ApiController]
public class BookController(IGenericRepository<Book> repository) : ControllerBase
{
    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBook([FromRoute]int bookId)
    {
        var book = await repository.GetByIdAsync(bookId);

        if (book is null)
            throw new NotFoundException("Book not found");

        return Ok(book);
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteBook([FromRoute]int bookId)
    {
        var book = await repository.GetByIdAsync(bookId);

        if (book is null)
            throw new NotFoundException("Book not found");

        repository.Delete(book);
        return Ok();
    }

    [HttpPut("{bookId}")]
    public async Task<IActionResult> UpdateBook([FromRoute]int bookId, [FromBody]UpdateBookRequest updateBookRequest)
    {
        var book = await repository.GetByIdAsync(bookId);

        if (book is null)
            throw new NotFoundException("Book not found");

        book.Title = updateBookRequest.title;
        book.Description = updateBookRequest.description;

        repository.Update(book);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]AddBookRequest addBookRequest)
    {
        var author = await repository.GetByIdAsync(addBookRequest.authorId);
        if (author is null)
            throw new NotFoundException("Author not found");

        var publisher = await repository.GetByIdAsync(addBookRequest.authorId);
        if (publisher is null)
            throw new NotFoundException("Publisher not found");

        var category = await repository.GetByIdAsync(addBookRequest.authorId);
        if (category is null)
            throw new NotFoundException("Category not found");

        var book = new Book
        {
            AuthorId = addBookRequest.authorId,
            CategoryId = addBookRequest.categoryId,
            Description = addBookRequest.description,
            Title = addBookRequest.title,
            PublisherId = addBookRequest.publisherId
        };

        repository.Add(book);
        return Ok();
    }
}
