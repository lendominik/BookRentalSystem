using System.ComponentModel.DataAnnotations;

namespace Application.Author;

public class AuthorDto
{
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = default!;
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = default!;
    public string? Description { get; set; }
    public string? Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}
