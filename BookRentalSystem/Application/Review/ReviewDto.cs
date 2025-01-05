using System.ComponentModel.DataAnnotations;

namespace Application.Review;

public class ReviewDto
{
    public int Id { get; set; }
    [Required]
    public string Content { get; set; } = default!;
    public string ReviewerName { get; set; } = "Anonymous";
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int BookId { get; set; }
}
