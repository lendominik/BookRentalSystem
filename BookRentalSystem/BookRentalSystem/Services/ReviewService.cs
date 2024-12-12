using BookRentalSystem.Entities;
using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Persistence;
using BookRentalSystem.Services.Interfaces;
using BookRentalSystem.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookRentalSystem.Services;

[Service(ServiceLifetime.Scoped)]
public class ReviewService(AppDbContext dbContext, AddReviewRequestValidator validator) : IReviewService
{
    public async Task AddReview(AddReviewRequest addReviewRequest)
    {
        var validationResult = await validator.ValidateAsync(addReviewRequest);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

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
