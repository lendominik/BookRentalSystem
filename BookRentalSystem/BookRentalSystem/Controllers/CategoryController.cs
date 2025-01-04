using Application.Category.Commands.CreateCategoryCommand;
using Application.Category.Commands.DeleteCategoryCommand;
using Application.Category.Commands.EditCategoryCommand;
using Application.Category.Queries.GetAllCategoriesQuery;
using Application.Category.Queries.GetCategoryByIdQuery;
using AutoMapper;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class CategoryController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await mediator.Send(new GetAllCategoriesQuery());
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        await mediator.Send(command);
        this.SetNotification("success", "Category created successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Route("Category/Details/{categoryId}")]
    public async Task<IActionResult> Details(int categoryId)
    {
        var categoryDto = await mediator.Send(new GetCategoryByIdQuery(categoryId));
        return View(categoryDto);
    }

    [Route("Category/Edit/{categoryId}")]
    public async Task<IActionResult> Edit(int categoryId)
    {
        var categoryDto = await mediator.Send(new GetCategoryByIdQuery(categoryId));
        var model = mapper.Map<EditCategoryCommand>(categoryDto);
        return View(model);
    }

    [HttpPost]
    [Route("Category/Edit/{categoryId}")]
    public async Task<IActionResult> Edit(int categoryId, EditCategoryCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Category/Delete/{categoryId}")]
    public async Task<IActionResult> Delete(int categoryId)
    {
        await mediator.Send(new DeleteCategoryCommand(categoryId));
        return RedirectToAction(nameof(Index));
    }
}
