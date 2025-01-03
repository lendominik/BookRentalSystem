using Application.Category.Commands.CreateCategoryCommand;
using Application.Category.Commands.DeleteCategoryCommand;
using Application.Category.Commands.EditCategoryCommand;
using Application.Category.Queries.GetAllCategoriesQuery;
using Application.Category.Queries.GetCategoryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class CategoryController(
    IMediator mediator)
    : Controller
{
    [HttpGet]
    [Route("Category")]
    public async Task<IActionResult> Index()
    {
        var carWorkshops = await mediator.Send(new GetAllCategoriesQuery());
        return View(carWorkshops);
    }

    [HttpPost]
    [Route("Category")]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [Route("Category/{categoryId}/Details")]
    public async Task<IActionResult> Details(int categoryId)
    {
        var categoryDto = await mediator.Send(new GetCategoryByIdQuery(categoryId));
        return View(categoryDto);
    }

    [Route("Category/{categoryId}/Edit")]
    public async Task<IActionResult> Edit(int categoryId, EditCategoryCommand command)
    {
        command.CategoryId = categoryId;
        await mediator.Send(command);
        return Ok();
    }

    [Route("Category/{categoryId}/Delete")]
    public async Task<IActionResult> Delete(int categoryId)
    {
        await mediator.Send(new DeleteCategoryCommand(categoryId));
        return Ok();
    }
}
