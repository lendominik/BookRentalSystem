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
    public async Task<IActionResult> Index()
    {
        var books = await mediator.Send(new GetAllBooksQuery());
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Book/Details/{bookId}")]
    public async Task<IActionResult> Details(int bookId)
    {
        var bookDto = await mediator.Send(new GetBookByIdQuery(bookId));
        return View(bookDto);
    }

    [Route("Book/Edit/{bookId}")]
    public async Task<IActionResult> Edit(int bookId)
    {
        var bookDto = await mediator.Send(new GetBookByIdQuery(bookId));
        var model = mapper.Map<EditBookCommand>(bookDto);
        return View(model);
    }

    [HttpPost]
    [Route("Book/Edit/{bookId}")]
    public async Task<IActionResult> Edit(int bookId, EditBookCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Book/Delete/{bookId}")]
    public async Task<IActionResult> Delete(int bookId)
    {
        await mediator.Send(new DeleteBookCommand(bookId));
        return RedirectToAction(nameof(Index));
    }
}
