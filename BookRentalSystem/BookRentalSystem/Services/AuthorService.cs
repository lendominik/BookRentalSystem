using AuthorRentalSystem.Services.Interfaces;
using BookRentalSystem.Entities;
using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Persistence;

namespace AuthorRentalSystem.Services;

[Service(ServiceLifetime.Scoped)]
public class AuthorService(AppDbContext dbContext) : IAuthorService
{
    public async Task AddAuthor(AddAuthorRequest addAuthorRequest)
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

        await dbContext.Authors.AddAsync(author);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAuthor(int authorId)
    {
        var author = await dbContext.Authors.FindAsync(authorId);

        if (author is null)
        {
            throw new NotFoundException("Author not found");
        }

        dbContext.Authors.Remove(author);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GetAuthorResponse> GetAuthor(int authorId)
    {
        var author = await dbContext.Authors.FindAsync(authorId);

        if (author is null)
        {
            throw new NotFoundException("Author not found");
        }

        return new GetAuthorResponse(
            author.FistName,
            author.LastName,
            author.Description,
            author.Nationality,
            author.DateOfBirth,
            author.DateOfDeath);
    }

    public async Task UpdateAuthor(int authorId, UpdateAuthorRequest updateAuthorRequest)
    {
        var author = await dbContext.Authors.FindAsync(authorId);

        if (author is null)
        {
            throw new NotFoundException("Author not found");
        }

        author.Description = updateAuthorRequest.description;

        await dbContext.SaveChangesAsync();
    }
}
