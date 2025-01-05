using MediatR;

namespace Application.Publisher.Commands.EditPublisherCommand;

public class EditPublisherCommand : IRequest
{
    public int PublisherId { get; set; }
    public string? Description { get; set; }
}
