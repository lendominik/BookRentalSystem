using MediatR;

namespace Application.Author.Commands.EditAuthorCommand;

public class EditAuthorCommand : IRequest
{
    public int AuthorId { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}
