using AutoMapper;
using Application.Exceptions;
using Core.Contracts;
using MediatR;
using Application.ApplicationUser;

namespace Application.Publisher.Commands.CreatePublisherCommand;

public class CreatePublisherCommandHandler(
    IGenericRepository<Core.Entities.Publisher> repository,
    IMapper mapper,
    IUserContext userContext)
    : IRequestHandler<CreatePublisherCommand>
{
    public async Task Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = mapper.Map<Core.Entities.Publisher>(request);

        publisher.CreatedById = userContext.GetCurrentUser().Id;

        repository.Add(publisher);

        if (!await repository.SaveAllAsync())
        {
            throw new BadRequestException("Problem creating publisher");
        }
    }
}
