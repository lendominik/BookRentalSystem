using AutoMapper;
using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Book.Commands.CreateBookCommand;

public class CreateBookCommandHandler(IGenericRepository<Core.Entities.Book> repository, IMapper mapper) : IRequestHandler<CreateBookCommand>
{
    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var authorExsists = repository.Exists(request.AuthorId);
        var publisherExsists = repository.Exists(request.PublisherId);
        var categoryExsists = repository.Exists(request.CategoryId);

        if (!authorExsists || !publisherExsists || !categoryExsists)
            throw new NotFoundException("Author, Publisher or Category not found");

        var book = mapper.Map<Core.Entities.Book>(request);

        repository.Add(book);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating book");
    }
}