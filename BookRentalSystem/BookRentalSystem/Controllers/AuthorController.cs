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

        if (author is null) return NotFound();

        return Ok(author);
    }

    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] int authorId)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author is null) return NotFound("Author not found");

        repository.Delete(author);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the author");
    }

    [HttpPut("{authorId}")]
    public async Task<IActionResult> UpdateAuthor([FromRoute] int authorId, [FromBody] UpdateAuthorRequest updateAuthorRequest)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author is null) return NotFound("Author not found");

        repository.Update(author);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the author");
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest addAuthorRequest)
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

        if (await repository.SaveAllAsync())
        {
            return CreatedAtAction(nameof(GetAuthor), new { author = author.Id }, author);
        }

        return BadRequest("Problem creating book");
    }
}
