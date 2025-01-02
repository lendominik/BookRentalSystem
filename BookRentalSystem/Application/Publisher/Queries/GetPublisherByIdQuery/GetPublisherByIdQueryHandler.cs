using AutoMapper;
using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Publisher.Queries.GetPublisherByIdQuery;

public class GetPublisherByIdQueryHandler(
    IGenericRepository<Core.Entities.Publisher> repository,
    IMapper mapper)
    : IRequestHandler<GetPublisherByIdQuery, PublisherDto>
{
    public async Task<PublisherDto> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
    {
        var publisher = await repository.GetByIdAsync(request.PublisherId);

        if (publisher is null)
            throw new NotFoundException("Publisher not found");

        return mapper.Map<PublisherDto>(publisher);
    }
}
