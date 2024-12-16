using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler(IGenericRepository<Core.Entities.Category> repository) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Core.Entities.Category
        {
            Name = request.Name,
            Description = request.Description
        };

        repository.Add(category);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating category");
    }
}
