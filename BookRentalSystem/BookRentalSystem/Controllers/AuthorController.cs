using AuthorRentalSystem.Services.Interfaces;
using BookRentalSystem.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AuthorRentalSystem.Controllers;

[Route("api/v1/author")]
[ApiController]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpGet("{authorId}")]
    public async Task<IActionResult> GetAuthor([FromRoute] int authorId)
    {
        var author = await authorService.GetAuthor(authorId);
        return Ok(author);
    }

    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] int authorId)
    {
        await authorService.DeleteAuthor(authorId);
        return Ok();
    }

    [HttpPut("{authorId}")]
    public async Task<IActionResult> UpdateAuthor([FromRoute] int authorId, [FromBody] UpdateAuthorRequest updateAuthorRequest)
    {
        await authorService.UpdateAuthor(authorId, updateAuthorRequest);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest AddAuthorRequest)
    {
        await authorService.AddAuthor(AddAuthorRequest);
        return Ok();
    }
}
