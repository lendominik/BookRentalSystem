using AutoMapper;
using Application.Exceptions;
using Core.Contracts;
using MediatR;
using Application.ApplicationUser;

namespace Application.Book.Commands.CreateBookCommand;

public class CreateBookCommandHandler(
    IGenericRepository<Core.Entities.Book> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IUserContext userContext)
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

        book.CreatedById = userContext.GetCurrentUser().Id;

        repository.Add(book);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating book");
    }
}