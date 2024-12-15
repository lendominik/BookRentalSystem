﻿using BookRentalSystem.Author.Commands.CreateAuthorCommand;
using BookRentalSystem.Author.Commands.DeleteAuthorCommand;
using BookRentalSystem.Author.Commands.EditAuthorCommand;
using BookRentalSystem.Author.Queries.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/author")]
[ApiController]
public class AuthorController(IMediator mediator) : ControllerBase
{
    [HttpGet("{authorId}")]
    public async Task<IActionResult> GetAuthor([FromRoute] int authorId)
    {
        var author = await mediator.Send(new GetAuthorByIdQuery(authorId));
        return Ok(author);
    }

    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] int authorId)
    {
        await mediator.Send(new DeleteAuthorCommand(authorId));
        return Ok();
    }

    [HttpPut("{authorId}")]
    public async Task<IActionResult> UpdateAuthor([FromRoute] int authorId, [FromBody] EditAuthorCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}
