using AutoMapper;
using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler(
    IGenericRepository<Core.Entities.Category> repository,
    IMapper mapper)
    : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Core.Entities.Category>(request);

        repository.Add(category);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating category");
    }
}
