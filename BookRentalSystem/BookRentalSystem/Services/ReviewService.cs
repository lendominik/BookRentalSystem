using BookRentalSystem.Entities;
using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Persistence;
using BookRentalSystem.Services.Interfaces;

namespace BookRentalSystem.Services;

public class ReviewService(AppDbContext dbContext) : IReviewService
{
    public async Task AddReview(AddReviewRequest addReviewRequest)
    {
        var review = new Review
        {
            ReviewerName = addReviewRequest.reviewerName,
            Content = addReviewRequest.content,
            BookId = addReviewRequest.bookId
        };

        await dbContext.Reviews.AddAsync(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteReview(int reviewId)
    {
        var review = await dbContext.Reviews.FindAsync(reviewId);

        if (review is null)
        {
            throw new NotFoundException("Review not found");
        }

        dbContext.Reviews.Remove(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GetReviewResponse> GetReview(int reviewId)
    {
        var review = await dbContext.Reviews.FindAsync(reviewId);

        if (review is null)
        {
            throw new NotFoundException("Review not found");
        }

        return new GetReviewResponse(review.Content, review.ReviewerName, review.CreatedDate);
    }
}
