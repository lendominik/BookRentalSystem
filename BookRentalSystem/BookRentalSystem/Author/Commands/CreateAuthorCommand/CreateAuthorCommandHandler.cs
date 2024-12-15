using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Author.Commands.CreateAuthorCommand;

public class CreateAuthorCommandHandler(IGenericRepository<Core.Entities.Author> repository) : IRequestHandler<CreateAuthorCommand>
{
    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Core.Entities.Author
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Description = request.Description,
            Nationality = request.Nationality,
            DateOfBirth = request.DateOfBirth,
            DateOfDeath = request.DateOfDeath
        };

        repository.Add(author);

        _ = await repository.SaveAllAsync();
    }
}
