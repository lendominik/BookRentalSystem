using MediatR;

namespace Application.Book.Commands.EditBookCommand;

public class EditBookCommand : IRequest
{
    public int BookId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set;}
}
