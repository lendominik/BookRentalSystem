﻿using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Book.Commands.EditBookCommand;

public class EditBookCommandHandler(
    IGenericRepository<Core.Entities.Book> repository)
    : IRequestHandler<EditBookCommand>
{
    public async Task Handle(EditBookCommand request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id);

        if (book is null)
            throw new NotFoundException("Book not found");

        if (!string.IsNullOrEmpty(request.Title))
            book.Title = request.Title;

        book.Description = request.Description;

        repository.Update(book);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem updating the book"); 
    }
}