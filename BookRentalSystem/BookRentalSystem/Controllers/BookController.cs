using BookRentalSystem.Models.Requests;
using BookRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/book")]
[ApiController]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBook([FromRoute]int bookId)
    {
        var book = await bookService.GetBook(bookId);
        return Ok(book);
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteBook([FromRoute]int bookId)
    {
        await bookService.DeleteBook(bookId);
        return Ok();
    }

    [HttpPut("{bookId}")]
    public async Task<IActionResult> UpdateBook([FromRoute]int bookId, [FromBody]UpdateBookRequest updateBookRequest)
    {
        await bookService.UpdateBook(bookId, updateBookRequest);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]AddBookRequest AddBookRequest)
    {
        await bookService.AddBook(AddBookRequest);
        return Ok();
    }
}
