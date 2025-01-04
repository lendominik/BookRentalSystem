using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Book.Commands.CreateBookCommand;

public class CreateBookCommand : IRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }

    public List<SelectListItem> Categories { get; set; } = [];
    public List<SelectListItem> Publishers { get; set; } = [];
    public List<SelectListItem> Authors { get; set; } = [];
}
