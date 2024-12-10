namespace BookRentalSystem.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
}