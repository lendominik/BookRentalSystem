using MediatR;

namespace BookRentalSystem.Publisher;

public class PublisherDto : IRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
