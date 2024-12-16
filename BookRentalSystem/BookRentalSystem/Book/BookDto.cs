using Core.Entities;

namespace BookRentalSystem.Book;

public class BookDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public virtual Core.Entities.Category Category { get; set; } = null!;

    public int AuthorId { get; set; }
    public virtual Core.Entities.Author Author { get; set; } = null!;

    public int PublisherId { get; set; }
    public virtual Core.Entities.Publisher Publisher { get; set; } = null!;

    public virtual List<Core.Entities.Review> Reviews { get; set; } = [];
}
