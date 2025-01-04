using Application.Review.Commands.CreateReviewCommand;
using Application.Review.Commands.DeleteReviewCommand;
using Application.Review.Queries.GetAllReviewsQuery;
using Application.Review.Queries.GetReviewByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReviewRentalSystem.Controllers;

public class ReviewController(
    IMediator mediator)
    : Controller
{
    [HttpGet]
    [Route("Review")]
    public async Task<IActionResult> Index()
    {
        var reviews = await mediator.Send(new GetAllReviewsQuery());
        return View(reviews);
    }

    [HttpGet]
    [Route("Review/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("Review/Create")]
    public async Task<IActionResult> Create(CreateReviewCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Review/{reviewId}/Details")]
    public async Task<IActionResult> Details(int reviewId)
    {
        var reviewDto = await mediator.Send(new GetReviewByIdQuery(reviewId));
        return View(reviewDto);
    }

    [Route("Review/{reviewId}/Delete")]
    public async Task<IActionResult> Delete(int reviewId)
    {
        await mediator.Send(new DeleteReviewCommand(reviewId));
        return RedirectToAction(nameof(Index));
    }
}
