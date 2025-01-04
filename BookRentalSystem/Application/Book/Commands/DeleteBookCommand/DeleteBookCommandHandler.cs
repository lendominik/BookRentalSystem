using Application.Exceptions;
using Core.Contracts;
using MediatR;

namespace Application.Book.Commands.DeleteBookCommand;

public class DeleteBookCommandHandler(
    IGenericRepository<Core.Entities.Book> repository)
    : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.BookId);

        if (book is null)
            throw new NotFoundException("Book not found");

        repository.Delete(book);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem deleting the book");
    }
}
