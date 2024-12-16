using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Publisher.Commands.CreatePublisherCommand;

public class CreatePublisherCommandHandler(IGenericRepository<Core.Entities.Publisher> repository) : IRequestHandler<CreatePublisherCommand>
{
    public async Task Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = new Core.Entities.Publisher
        {
            Name = request.Name,
            Description = request.Description
        };

        repository.Add(publisher);

        if (!await repository.SaveAllAsync())
        {
            throw new BadRequestException("Problem creating publisher");
        }
    }
}
