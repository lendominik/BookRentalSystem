using AutoMapper;
using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Book.Commands.CreateBookCommand;

public class CreateBookCommandHandler(
    IGenericRepository<Core.Entities.Book> repository,
    IGenericRepository<Core.Entities.Author> authorRepository,
    IGenericRepository<Core.Entities.Publisher> publisherRepository,
    IGenericRepository<Core.Entities.Category> categoryRepository,
    IMapper mapper)
    : IRequestHandler<CreateBookCommand>
{
    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var authorExsists = authorRepository.Exists(request.AuthorId);
        var publisherExsists = publisherRepository.Exists(request.PublisherId);
        var categoryExsists = categoryRepository.Exists(request.CategoryId);

        if (!authorExsists || !publisherExsists || !categoryExsists)
            throw new NotFoundException("Author, Publisher or Category not found");

        var book = mapper.Map<Core.Entities.Book>(request);

        repository.Add(book);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating book");
    }
}