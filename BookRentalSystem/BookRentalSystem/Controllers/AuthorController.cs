using Application.Author.Commands.CreateAuthorCommand;
using Application.Author.Commands.DeleteAuthorCommand;
using Application.Author.Commands.EditAuthorCommand;
using Application.Author.Queries.GetAllAuthorsQuery;
using Application.Author.Queries.GetAuthorByIdQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class AuthorController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    [HttpGet]
    [Route("Author")]
    public async Task<IActionResult> Index()
    {
        var authors = await mediator.Send(new GetAllAuthorsQuery());
        return View(authors);
    }

    [HttpGet]
    [Route("Author/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("Author/Create")]
    public async Task<IActionResult> Create(CreateAuthorCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Author/{authorId}/Details")]
    public async Task<IActionResult> Details(int authorId)
    {
        var authorDto = await mediator.Send(new GetAuthorByIdQuery(authorId));
        return View(authorDto);
    }

    [Route("Author/{authorId}/Edit")]
    public async Task<IActionResult> Edit(int authorId)
    {
        var authorDto = await mediator.Send(new GetAuthorByIdQuery(authorId));
        var model = mapper.Map<EditAuthorCommand>(authorDto);
        return View(model);
    }

    [HttpPost]
    [Route("Author/{authorId}/Edit")]
    public async Task<IActionResult> Edit(int authorId, EditAuthorCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Author/{authorId}/Delete")]
    public async Task<IActionResult> Delete(int authorId)
    {
        await mediator.Send(new DeleteAuthorCommand(authorId));
        return RedirectToAction(nameof(Index));
    }
}
