namespace BookRentalSystem.Review;

public class ReviewDto
{
    public string Content { get; set; } = null!;
    public string ReviewerName { get; set; } = "Anonymous";
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int BookId { get; set; }
}
