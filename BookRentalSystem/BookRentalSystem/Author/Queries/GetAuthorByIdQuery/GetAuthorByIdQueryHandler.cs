using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Author.Queries.GetAuthorByIdQuery;

public class GetAuthorByIdQueryHandler(IGenericRepository<Core.Entities.Author> repository) : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await repository.GetByIdAsync(request.AuthorId);

        if (author is null) 
            throw new NotFoundException("Author not found");

        return new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Description = author.Description,
            DateOfBirth = author.DateOfBirth,
            DateOfDeath = author.DateOfDeath,
            Nationality = author.Nationality
        };
    }
}
