﻿using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace AuthorRentalSystem.Services.Interfaces;

public interface IAuthorService
{
    Task<GetAuthorResponse> GetAuthor(int authorId);
    Task AddAuthor(AddAuthorRequest addAuthorRequest);
    Task UpdateAuthor(int authorId, UpdateAuthorRequest updateAuthorRequest);
    Task DeleteAuthor(int authorId);
}