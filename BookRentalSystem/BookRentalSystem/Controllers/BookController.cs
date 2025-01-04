using Application.Book.Commands.CreateBookCommand;
using Application.Book.Commands.DeleteBookCommand;
using Application.Book.Commands.EditBookCommand;
using Application.Book.Queries.GetAllBooksQuery;
using Application.Book.Queries.GetBookByIdQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class BookController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    [HttpGet]
    [Route("Book")]
    public async Task<IActionResult> Index()
    {
        var carWorkshops = await mediator.Send(new GetAllBooksQuery());
        return View(carWorkshops);
    }

    [HttpGet]
    [Route("Book/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("Book/Create")]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Book/{bookId}/Details")]
    public async Task<IActionResult> Details(int bookId)
    {
        var bookDto = await mediator.Send(new GetBookByIdQuery(bookId));
        return View(bookDto);
    }

    [Route("Book/{bookId}/Edit")]
    public async Task<IActionResult> Edit(int bookId)
    {
        var bookDto = await mediator.Send(new GetBookByIdQuery(bookId));
        var model = mapper.Map<EditBookCommand>(bookDto);
        return View(model);
    }

    [HttpPost]
    [Route("Book/{bookId}/Edit")]
    public async Task<IActionResult> Edit(int bookId, EditBookCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Book/{bookId}/Delete")]
    public async Task<IActionResult> Delete(int bookId)
    {
        await mediator.Send(new DeleteBookCommand(bookId));
        return RedirectToAction(nameof(Index));
    }
}
