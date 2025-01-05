using Application.Review.Commands.CreateReviewCommand;
using Application.Review.Commands.DeleteReviewCommand;
using Application.Review.Queries.GetAllReviewsQuery;
using Application.Review.Queries.GetReviewByIdQuery;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReviewRentalSystem.Controllers;

public class ReviewController(
    IMediator mediator)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var reviews = await mediator.Send(new GetAllReviewsQuery());
        return View(reviews);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewCommand command)
    {
        await mediator.Send(command);
        this.SetNotification("success", "Review created successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Route("Review/Details/{reviewId}")]
    public async Task<IActionResult> Details(int reviewId)
    {
        var reviewDto = await mediator.Send(new GetReviewByIdQuery(reviewId));
        this.SetNotification("info", "Review updated successfully.");
        return View(reviewDto);
    }

    [Route("Review/Delete/{reviewId}")]
    public async Task<IActionResult> Delete(int reviewId)
    {
        await mediator.Send(new DeleteReviewCommand(reviewId));
        this.SetNotification("error", "Review deleted successfully.");
        return RedirectToAction(nameof(Index));
    }
}
