using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/author")]
[ApiController]
public class AuthorController(IGenericRepository<Author> repository) : ControllerBase
{
    [HttpGet("{authorId}")]
    public async Task<IActionResult> GetAuthor([FromRoute] int authorId)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author is null)
            throw new NotFoundException("Author not found");

        return Ok(author);
    }

    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] int authorId)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author is null)
            throw new NotFoundException("Author not found");

        repository.Delete(author);
        return Ok();
    }

    [HttpPut("{authorId}")]
    public async Task<IActionResult> UpdateAuthor([FromRoute] int authorId, [FromBody] UpdateAuthorRequest updateAuthorRequest)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author is null)
            throw new NotFoundException("Author not found");

        repository.Update(author);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] AddAuthorRequest addAuthorRequest)
    {
        var author = new Author
        {
            FistName = addAuthorRequest.firstName,
            LastName = addAuthorRequest.lastName,
            Description = addAuthorRequest.description,
            Nationality = addAuthorRequest.nationality,
            DateOfBirth = addAuthorRequest.dateOfBirth,
            DateOfDeath = addAuthorRequest.dateOfDeath
        };

        repository.Add(author);
        return Ok();
    }
}
