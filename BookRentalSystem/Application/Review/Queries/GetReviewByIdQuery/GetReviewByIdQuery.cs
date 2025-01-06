using MediatR;

namespace Application.Review.Queries.GetReviewByIdQuery;

public record GetReviewByIdQuery(int ReviewId) : IRequest<ReviewDto>;