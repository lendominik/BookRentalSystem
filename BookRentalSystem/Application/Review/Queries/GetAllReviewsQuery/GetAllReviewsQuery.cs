using MediatR;

namespace Application.Review.Queries.GetAllReviewsQuery;

public class GetAllReviewsQuery : IRequest<IEnumerable<ReviewDto>>
{
}
