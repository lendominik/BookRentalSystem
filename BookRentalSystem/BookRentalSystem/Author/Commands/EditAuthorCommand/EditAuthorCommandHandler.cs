﻿using BookRentalSystem.Exceptions;
using Infrastructure.Services;
using MediatR;

namespace BookRentalSystem.Author.Commands.EditAuthorCommand;

public class EditAuthorCommandHandler(GenericRepository<Core.Entities.Author> repository) : IRequestHandler<EditAuthorCommand>
{
    public async Task Handle(EditAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await repository.GetByIdAsync(request.AuthorId);

        if (author is null)
            throw new NotFoundException("Author not found");

        repository.Update(author);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem updating the author");
    }
}
