using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace BookRentalSystem.Interfaces;

public interface IReviewService
{
    Task<GetReviewResponse> GetReview(int reviewId);
    Task AddReview(AddReviewRequest addReviewRequest);
    Task DeleteReview(int reviewId);
}
