using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Application.Book;

public class BookDto
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }

    [Display(Name = "Select Category")]
    public int CategoryId { get; set; }
    [Display(Name = "Select Author")]
    public int AuthorId { get; set; }
    [Display(Name = "Select Publisher")]
    public int PublisherId { get; set; }

    public List<SelectListItem> Categories { get; set; } = [];
    public List<SelectListItem> Publishers { get; set; } = [];
    public List<SelectListItem> Authors { get; set; } = [];
}
