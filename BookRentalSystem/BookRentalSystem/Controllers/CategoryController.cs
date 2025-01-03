using Application.Category.Commands.CreateCategoryCommand;
using Application.Category.Queries.GetCategoryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class CategoryController(
    IMediator mediator)
    : Controller
{
    [HttpPost]
    [Route("api/categories")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [Route("api/categories/{categoryId}/Details")]
    public async Task<IActionResult> Details(int categoryId)
    {
        var categoryDto = await mediator.Send(new GetCategoryByIdQuery(categoryId));
        return View(categoryDto);
    }
}
