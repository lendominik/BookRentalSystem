using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Publisher.Commands.EditPublisherCommand;

public class EditPublisherCommandHandler(
    IGenericRepository<Core.Entities.Publisher> repository)
    : IRequestHandler<EditPublisherCommand>
{
    public async Task Handle(EditPublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = await repository.GetByIdAsync(request.Id);

        if (publisher is null)
            throw new NotFoundException("Publisher not found");

        if (!string.IsNullOrEmpty(request.Description))
            publisher.Description = request.Description;

        repository.Update(publisher);

        if (!await repository.SaveAllAsync())
        {
            throw new BadRequestException("Problem updating the publisher");
        }
    }
}
