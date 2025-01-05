using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Author.Commands.EditAuthorCommand;

public class EditAuthorCommandHandler(
    IGenericRepository<Core.Entities.Author> repository)
    : IRequestHandler<EditAuthorCommand>
{
    public async Task Handle(EditAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await repository.GetByIdAsync(request.Id);

        if (author is null)
            throw new NotFoundException("Author not found");

        author.Description = request.Description;
        author.DateOfDeath = request.DateOfDeath;
        author.DateOfBirth = request.DateOfBirth;
        author.FirstName = request.FirstName;
        author.LastName = request.LastName;
        author.Nationality = request.Nationality;

        repository.Update(author);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem updating the author");
    }
}
