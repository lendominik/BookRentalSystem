using MediatR;

namespace Application.Author.Commands.DeleteAuthorCommand;

public class DeleteAuthorCommand : IRequest
{
    public int AuthorId { get; set; }

    public DeleteAuthorCommand(int authorId)
    {
        AuthorId = authorId;
    }
}
