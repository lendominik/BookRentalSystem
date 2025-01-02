using MediatR;

namespace Application.Book.Commands.CreateBookCommand;

public class CreateBookCommand : BookDto, IRequest
{
}
