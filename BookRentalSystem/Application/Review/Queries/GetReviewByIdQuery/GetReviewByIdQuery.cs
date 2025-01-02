using MediatR;

namespace Application.Review.Queries.GetReviewByIdQuery;

public class GetReviewByIdQuery : IRequest<ReviewDto>
{
    public int ReviewId { get; set; }

    public GetReviewByIdQuery(int reviewId)
    {
        ReviewId = reviewId;
    }
}