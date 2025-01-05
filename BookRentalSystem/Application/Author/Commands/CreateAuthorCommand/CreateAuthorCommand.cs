using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Author.Commands.CreateAuthorCommand;

public class CreateAuthorCommand : IRequest
{
    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set; } = default!;
    public string? Description { get; set; }
    public string? Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}