using BookRentalSystem.Book.Commands.CreateBookCommand;
using BookRentalSystem.Book.Commands.DeleteBookCommand;
using BookRentalSystem.Book.Commands.EditBookCommand;
using BookRentalSystem.Book.Queries.GetBookByIdQuery;
using BookRentalSystem.Models.Requests;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/book")]
[ApiController]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBook([FromRoute]int bookId)
    {
        var book = await mediator.Send(new GetBookByIdQuery(bookId));
        return Ok(book);
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteBook([FromRoute]int bookId)
    {
        await mediator.Send(new DeleteBookCommand(bookId));
        return Ok();
    }

    [HttpPut("{bookId}")]
    public async Task<IActionResult> UpdateBook([FromRoute]int bookId, [FromBody]EditBookCommand command)
    {
        command.BookId = bookId;
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]CreateBookCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}
