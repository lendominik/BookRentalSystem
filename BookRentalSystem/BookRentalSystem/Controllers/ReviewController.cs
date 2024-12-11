using BookRentalSystem.Models.Requests;
using BookRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/review")]
[ApiController]
public class ReviewController(IReviewService reviewService) : ControllerBase
{
    [HttpGet("{reviewId}")]
    public async Task<IActionResult> GetReview([FromRoute]int reviewId)
    {
        var review = await reviewService.GetReview(reviewId);
        return Ok(review);
    }

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteReview([FromRoute]int reviewId)
    {
        await reviewService.DeleteReview(reviewId);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddReview([FromBody]AddReviewRequest addReviewRequest)
    {
        await reviewService.AddReview(addReviewRequest);
        return Ok();
    }
}
