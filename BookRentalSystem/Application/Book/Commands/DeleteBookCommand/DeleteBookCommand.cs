using MediatR;

namespace Application.Book.Commands.DeleteBookCommand;

public record DeleteBookCommand(int BookId) : IRequest;