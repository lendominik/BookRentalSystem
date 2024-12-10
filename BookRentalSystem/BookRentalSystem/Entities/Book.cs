namespace BookRentalSystem.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;
}