using MediatR;

namespace BookRentalSystem.Author.Queries.GetAuthorById;

public class GetAuthorByIdQuery : IRequest<AuthorDto>
{
    public int AuthorId { get; set; }

    public GetAuthorByIdQuery(int authorId)
    {
        AuthorId = authorId;
    }
}
