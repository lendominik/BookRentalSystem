using MediatR;

namespace Application.Author.Commands.DeleteAuthorCommand;

public record DeleteAuthorCommand(int AuthorId) : IRequest;