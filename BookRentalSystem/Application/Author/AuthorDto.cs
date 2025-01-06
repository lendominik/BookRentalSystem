using System.ComponentModel.DataAnnotations;

namespace Application.Author;

public class AuthorDto
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = default!;
    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = default!;
    public string? Description { get; set; }
    public string? Nationality { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfDeath { get; set; }
}
