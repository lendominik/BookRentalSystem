using AutoMapper;
using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Author.Queries.GetAuthorByIdQuery;

public class GetAuthorByIdQueryHandler(
    IGenericRepository<Core.Entities.Author> repository,
    IMapper mapper)
    : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await repository.GetByIdAsync(request.AuthorId);

        if (author is null) 
            throw new NotFoundException("Author not found");

        return mapper.Map<AuthorDto>(author);
    }
}
