using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Publisher;

public class PublisherDto : IRequest
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
