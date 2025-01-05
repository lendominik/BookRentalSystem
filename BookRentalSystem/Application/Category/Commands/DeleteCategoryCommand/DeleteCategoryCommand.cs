using MediatR;

namespace Application.Category.Commands.DeleteCategoryCommand;

public record DeleteCategoryCommand(int CategoryId) : IRequest;