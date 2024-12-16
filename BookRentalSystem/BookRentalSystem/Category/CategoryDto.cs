namespace BookRentalSystem.Category;

public class CategoryDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual List<Core.Entities.Book> Books { get; set; } = [];
}
