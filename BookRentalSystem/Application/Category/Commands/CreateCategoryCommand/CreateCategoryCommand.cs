using MediatR;

namespace Application.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommand : IRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
