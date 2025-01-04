using MediatR;

namespace Application.Publisher.Queries.GetAllPublishersQuery;

public class GetAllPublishersQuery : IRequest<IEnumerable<PublisherDto>>
{
}
