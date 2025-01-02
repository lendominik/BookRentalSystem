using MediatR;

namespace Application.Author.Commands.EditAuthorCommand;

public class EditAuthorCommand : AuthorDto, IRequest
{
    public int AuthorId { get; set; }
}
