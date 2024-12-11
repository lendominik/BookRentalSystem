namespace BookRentalSystem.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public List<Book> Books { get; set; } = [];
}