using Application.Category.Commands.CreateCategoryCommand;
using Application.Category.Commands.DeleteCategoryCommand;
using Application.Category.Commands.EditCategoryCommand;
using Application.Category.Queries.GetAllCategoriesQuery;
using Application.Category.Queries.GetCategoryByIdQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class CategoryController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    [HttpGet]
    [Route("Category")]
    public async Task<IActionResult> Index()
    {
        var carWorkshops = await mediator.Send(new GetAllCategoriesQuery());
        return View(carWorkshops);
    }

    [HttpGet]
    [Route("Category/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("Category/Create")]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Category/{categoryId}/Details")]
    public async Task<IActionResult> Details(int categoryId)
    {
        var categoryDto = await mediator.Send(new GetCategoryByIdQuery(categoryId));
        return View(categoryDto);
    }

    [Route("Category/{categoryId}/Edit")]
    public async Task<IActionResult> Edit(int categoryId)
    {
        var categoryDto = await mediator.Send(new GetCategoryByIdQuery(categoryId));
        var model = mapper.Map<EditCategoryCommand>(categoryDto);
        return View(model);
    }

    [HttpPost]
    [Route("Category/{categoryId}/Edit")]
    public async Task<IActionResult> Edit(int categoryId, EditCategoryCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Category/{categoryId}/Delete")]
    public async Task<IActionResult> Delete(int categoryId)
    {
        await mediator.Send(new DeleteCategoryCommand(categoryId));
        return RedirectToAction(nameof(Index));
    }
}
