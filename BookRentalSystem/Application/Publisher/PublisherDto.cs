using MediatR;

namespace Application.Publisher;

public class PublisherDto : IRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
