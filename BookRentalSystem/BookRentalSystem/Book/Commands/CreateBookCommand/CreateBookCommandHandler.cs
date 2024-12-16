using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Book.Commands.CreateBookCommand;

public class CreateBookCommandHandler(IGenericRepository<Core.Entities.Book> repository) : IRequestHandler<CreateBookCommand>
{
    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var authorExsists = repository.Exists(request.AuthorId);
        var publisherExsists = repository.Exists(request.PublisherId);
        var categoryExsists = repository.Exists(request.CategoryId);

        if (!authorExsists || !publisherExsists || !categoryExsists)
            throw new NotFoundException("Author, Publisher or Category not found");

        var book = new Core.Entities.Book
        {
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
            Description = request.Description,
            Title = request.Title,
            PublisherId = request.PublisherId
        };

        repository.Add(book);

        if (!await repository.SaveAllAsync())
        {
            throw new BadRequestException("Problem creating book");
        }
    }
}