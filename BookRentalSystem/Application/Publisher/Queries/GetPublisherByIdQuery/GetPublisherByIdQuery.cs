using MediatR;

namespace Application.Publisher.Queries.GetPublisherByIdQuery;

public record GetPublisherByIdQuery(int PublisherId) : IRequest<PublisherDto>;
