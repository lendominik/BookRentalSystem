using AutoMapper;
using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Book.Commands.CreateBookCommand;

public class CreateBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateBookCommand>
{
    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var authorExsists = unitOfWork.Repository<Core.Entities.Author>().Exists(request.AuthorId);
        var publisherExsists = unitOfWork.Repository<Core.Entities.Publisher>().Exists(request.PublisherId);
        var categoryExsists = unitOfWork.Repository<Core.Entities.Category>().Exists(request.CategoryId);

        if (!authorExsists || !publisherExsists || !categoryExsists)
            throw new NotFoundException("Author, Publisher or Category not found");

        var book = mapper.Map<Core.Entities.Book>(request);

        unitOfWork.Repository<Core.Entities.Book>().Add(book);

        if (!await unitOfWork.Repository<Core.Entities.Author>().SaveAllAsync())
            throw new BadRequestException("Problem creating book");
    }
}