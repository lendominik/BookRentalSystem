using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/review")]
[ApiController]
public class ReviewController(IGenericRepository<Review> repository) : ControllerBase
{
    [HttpGet("{reviewId}")]
    public async Task<IActionResult> GetReview([FromRoute]int reviewId)
    {
        var review = await repository.GetByIdAsync(reviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        return Ok(review);
    }

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteReview([FromRoute]int reviewId)
    {
        var review = await repository.GetByIdAsync(reviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        repository.Delete(review);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddReview([FromBody]AddReviewRequest addReviewRequest)
    {
        var book = await repository.GetByIdAsync(addReviewRequest.bookId);
        if (book is null)
            throw new NotFoundException("Book not found");

        var review = new Review
        {
            ReviewerName = addReviewRequest.reviewerName,
            Content = addReviewRequest.content,
            BookId = addReviewRequest.bookId
        };

        repository.Add(review);
        return Ok();
    }
}
