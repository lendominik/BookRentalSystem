using MediatR;

namespace BookRentalSystem.Publisher;

public class PublisherDto : IRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual List<Core.Entities.Book> Books { get; set; } = [];
}
