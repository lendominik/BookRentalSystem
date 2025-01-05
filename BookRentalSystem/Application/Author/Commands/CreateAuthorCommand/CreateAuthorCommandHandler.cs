using AutoMapper;
using Application.Exceptions;
using Core.Contracts;
using MediatR;
using Application.ApplicationUser;

namespace Application.Author.Commands.CreateAuthorCommand;

public class CreateAuthorCommandHandler(
    IGenericRepository<Core.Entities.Author> repository,
    IMapper mapper,
    IUserContext userContext)
    : IRequestHandler<CreateAuthorCommand>
{
    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = mapper.Map<Core.Entities.Author>(request);

        author.CreatedById = userContext.GetCurrentUser().Id;

        repository.Add(author);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating author");
    }
}
