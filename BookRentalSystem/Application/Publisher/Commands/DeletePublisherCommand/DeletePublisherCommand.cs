using MediatR;

namespace Application.Publisher.Commands.DeletePublisherCommand;

public record DeletePublisherCommand(int PublisherId) : IRequest;