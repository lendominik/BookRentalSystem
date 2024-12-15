using Core.Models.Requests;
using Core.Models.Responses;

namespace Core.Interfaces;

public interface IReviewService
{
    Task<GetReviewResponse> GetReview(int reviewId);
    Task AddReview(AddReviewRequest addReviewRequest);
    Task DeleteReview(int reviewId);
}
