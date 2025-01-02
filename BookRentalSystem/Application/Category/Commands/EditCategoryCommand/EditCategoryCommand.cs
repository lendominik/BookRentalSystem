using MediatR;

namespace Application.Category.Commands.EditCategoryCommand;

public class EditCategoryCommand : IRequest
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
