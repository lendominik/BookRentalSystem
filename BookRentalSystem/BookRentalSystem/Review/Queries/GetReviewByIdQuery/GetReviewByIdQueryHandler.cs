using BookRentalSystem.Exceptions;
using Core.Interfaces;
using MediatR;

namespace BookRentalSystem.Review.Queries.GetReviewByIdQuery;

public class GetReviewByIdQueryHandler(IGenericRepository<Core.Entities.Review> repository) : IRequestHandler<GetReviewByIdQuery, ReviewDto>
{
    public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await repository.GetByIdAsync(request.ReviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        return new ReviewDto
        {
            BookId = review.BookId,
            Content = review.Content,
            CreatedDate = review.CreatedDate,
            ReviewerName = review.ReviewerName
        };
    }
}
