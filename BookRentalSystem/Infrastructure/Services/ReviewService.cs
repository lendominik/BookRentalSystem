using Core.Entities;
using BookRentalSystem.Exceptions;
using Core.Interfaces;
using Core.Models.Requests;
using Core.Models.Responses;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

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
        var review = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);

        if (review is null)
        {
            throw new NotFoundException("Review not found");
        }

        dbContext.Reviews.Remove(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GetReviewResponse> GetReview(int reviewId)
    {
        var review = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);

        if (review is null)
        {
            throw new NotFoundException("Review not found");
        }

        return new GetReviewResponse(review.Content, review.ReviewerName, review.CreatedDate);
    }
}
