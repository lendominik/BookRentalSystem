using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Category.Commands.EditCategoryCommand;

public class EditCategoryCommandHandler(
    IGenericRepository<Core.Entities.Category> repository)
    : IRequestHandler<EditCategoryCommand>
{
    public async Task Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);

        if (category is null)
            throw new NotFoundException("Category not found");

        if (!string.IsNullOrEmpty(request.Name))
            category.Name = request.Name;

        if (!string.IsNullOrEmpty(request.Description))
            category.Description = request.Description;

        repository.Update(category);

        if (!await repository.SaveAllAsync())
        {
            throw new BadRequestException("Problem updating the category");
        }
    }
}
