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

        if (review is null) return NotFound("Review not found");

        return Ok(review);
    }

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteReview([FromRoute]int reviewId)
    {
        var review = await repository.GetByIdAsync(reviewId);

        if (review is null) return NotFound("Review not found");

        repository.Delete(review);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the review");
    }

    [HttpPost]
    public async Task<IActionResult> AddReview([FromBody]AddReviewRequest addReviewRequest)
    {
        var bookExists = repository.Exists(addReviewRequest.bookId);
        if (!bookExists) return NotFound("Book not found");

        var review = new Review
        {
            ReviewerName = addReviewRequest.reviewerName,
            Content = addReviewRequest.content,
            BookId = addReviewRequest.bookId
        };

        repository.Add(review);

        if (await repository.SaveAllAsync())
        {
            return CreatedAtAction(nameof(GetReview), new { reviewId = review.Id }, review);
        }

        return BadRequest("Problem creating review");
    }
}
