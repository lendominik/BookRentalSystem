using Application.Author.Commands.CreateAuthorCommand;
using Application.Author.Commands.DeleteAuthorCommand;
using Application.Author.Commands.EditAuthorCommand;
using Application.Author.Queries.GetAllAuthorsQuery;
using Application.Author.Queries.GetAuthorByIdQuery;
using AutoMapper;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class AuthorController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var authors = await mediator.Send(new GetAllAuthorsQuery());
        return View(authors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorCommand command)
    {
        await mediator.Send(command);
        this.SetNotification("success", "Author created successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Route("Author/Details/{authorId}")]
    public async Task<IActionResult> Details(int authorId)
    {
        var authorDto = await mediator.Send(new GetAuthorByIdQuery(authorId));
        return View(authorDto);
    }

    [Route("Author/Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var authorDto = await mediator.Send(new GetAuthorByIdQuery(id));
        var model = mapper.Map<EditAuthorCommand>(authorDto);
        return View(model);
    }

    [HttpPost]
    [Route("Author/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, EditAuthorCommand command)
    {
        await mediator.Send(command);
        this.SetNotification("info", "Author updated successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Route("Author/Delete/{authorId}")]
    public async Task<IActionResult> Delete(int authorId)
    {
        await mediator.Send(new DeleteAuthorCommand(authorId));
        this.SetNotification("error", "Author deleted successfully.");
        return RedirectToAction(nameof(Index));
    }
}
