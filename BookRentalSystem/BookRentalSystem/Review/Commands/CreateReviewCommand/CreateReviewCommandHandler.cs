using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Review.Commands.CreateReviewCommand;

public class CreateReviewCommandHandler(IGenericRepository<Core.Entities.Review> repository) : IRequestHandler<CreateReviewCommand>
{
    public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var bookExists = repository.Exists(request.BookId);

        if (!bookExists) 
            throw new NotFoundException("Book not found");

        var review = new Core.Entities.Review
        {
            ReviewerName = request.ReviewerName,
            Content = request.Content,
            BookId = request.BookId
        };

        repository.Add(review);

        if (!await repository.SaveAllAsync())
            throw new BadRequestException("Problem creating review");
    }
}
