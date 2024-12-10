namespace BookRentalSystem.Entities;

public class Author
{
    public int Id { get; set; }
    public string FistName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public List<Book> Books { get; set; } = [];
}