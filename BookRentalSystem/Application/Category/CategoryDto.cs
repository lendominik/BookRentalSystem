using System.ComponentModel.DataAnnotations;

namespace Application.Category;

public class CategoryDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
