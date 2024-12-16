using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Publisher.Queries.GetPublisherByIdQuery;

public class GetPublisherByIdQueryHandler(IGenericRepository<Core.Entities.Publisher> repository) : IRequestHandler<GetPublisherByIdQuery, PublisherDto>
{
    public async Task<PublisherDto> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
    {
        var publisher = await repository.GetByIdAsync(request.PublisherId);

        if (publisher is null) 
            throw new NotFoundException("Publisher not found");

        return new PublisherDto
        {
            Description = publisher.Description,
            Name = publisher.Name
        };
    }
}
