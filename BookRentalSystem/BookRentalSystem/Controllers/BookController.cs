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

        if (book is null) return NotFound();

        return Ok(book);
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteBook([FromRoute]int bookId)
    {
        var book = await repository.GetByIdAsync(bookId);

        if (book is null) return NotFound("Book not found");

        repository.Delete(book);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the book");
    }

    [HttpPut("{bookId}")]
    public async Task<IActionResult> UpdateBook([FromRoute]int bookId, [FromBody]UpdateBookRequest updateBookRequest)
    {
        var book = await repository.GetByIdAsync(bookId);

        if (book is null) return NotFound("Book not found");

        book.Title = updateBookRequest.title;
        book.Description = updateBookRequest.description;

        repository.Update(book);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the book");
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]AddBookRequest addBookRequest)
    {
        var authorExsists = repository.Exists(addBookRequest.authorId);
        var publisherExsists = repository.Exists(addBookRequest.authorId);
        var categoryExsists = repository.Exists(addBookRequest.authorId);

        if (!authorExsists || !publisherExsists || !categoryExsists)
            return NotFound("Author, Publisher or Category not found");

        var book = new Book
        {
            AuthorId = addBookRequest.authorId,
            CategoryId = addBookRequest.categoryId,
            Description = addBookRequest.description,
            Title = addBookRequest.title,
            PublisherId = addBookRequest.publisherId
        };

        repository.Add(book);

        if (await repository.SaveAllAsync())
        {
            return CreatedAtAction(nameof(GetBook), new { bookId = book.Id }, book);
        }

        return BadRequest("Problem creating book");
    }
}
