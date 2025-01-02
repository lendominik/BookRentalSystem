using MediatR;

namespace Application.Publisher.Commands.DeletePublisherCommand;

public class DeletePublisherCommand : IRequest
{
    public int PublisherId { get; set; }

    public DeletePublisherCommand(int publisherId)
    {
        PublisherId = publisherId;
    }
}
