using Application.Author.Queries.GetAllAuthorsQuery;
using Application.Book.Commands.CreateBookCommand;
using Application.Book.Commands.DeleteBookCommand;
using Application.Book.Commands.EditBookCommand;
using Application.Book.Queries.GetAllBooksQuery;
using Application.Book.Queries.GetBookByIdQuery;
using Application.Category.Queries.GetAllCategoriesQuery;
using Application.Publisher.Queries.GetAllPublishersQuery;
using AutoMapper;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public async Task<IActionResult> Create()
    {
        var command = new CreateBookCommand
        {
            Categories = (await mediator.Send(new GetAllCategoriesQuery()))
            .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            .ToList(),
            Authors = (await mediator.Send(new GetAllAuthorsQuery()))
            .Select(x => new SelectListItem { Text = $"{x.FirstName} {x.LastName}", Value = x.Id.ToString() })
            .ToList(),
            Publishers = (await mediator.Send(new GetAllPublishersQuery()))
            .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            .ToList()
        };

        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        await mediator.Send(command);
        this.SetNotification("success", "Book created successfully.");
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
