using Core.Models.Requests;
using Core.Models.Responses;

namespace Core.Interfaces;

public interface IAuthorService
{
    Task<GetAuthorResponse> GetAuthor(int authorId);
    Task AddAuthor(AddAuthorRequest addAuthorRequest);
    Task UpdateAuthor(int authorId, UpdateAuthorRequest updateAuthorRequest);
    Task DeleteAuthor(int authorId);
}
