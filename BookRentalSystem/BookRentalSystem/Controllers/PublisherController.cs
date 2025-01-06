using Application.Publisher.Commands.CreatePublisherCommand;
using Application.Publisher.Commands.DeletePublisherCommand;
using Application.Publisher.Commands.EditPublisherCommand;
using Application.Publisher.Queries.GetAllPublishersQuery;
using Application.Publisher.Queries.GetPublisherByIdQuery;
using AutoMapper;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class PublisherController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var publishers = await mediator.Send(new GetAllPublishersQuery());
        return View(publishers);
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreatePublisherCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await mediator.Send(command);
        this.SetNotification("success", "Publisher created successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [Route("Publisher/Details/{publisherId}")]
    public async Task<IActionResult> Details(int publisherId)
    {
        var publisherDto = await mediator.Send(new GetPublisherByIdQuery(publisherId));
        return View(publisherDto);
    }

    [Authorize]
    [Route("Publisher/Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var publisherDto = await mediator.Send(new GetPublisherByIdQuery(id));
        var model = mapper.Map<EditPublisherCommand>(publisherDto);
        return View(model);
    }

    [Authorize]
    [HttpPost]
    [Route("Publisher/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, EditPublisherCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await mediator.Send(command);
        this.SetNotification("info", "Publisher updated successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [Route("Publisher/Delete/{publisherId}")]
    public async Task<IActionResult> Delete(int publisherId)
    {
        await mediator.Send(new DeletePublisherCommand(publisherId));
        this.SetNotification("error", "Publisher deleted successfully.");
        return RedirectToAction(nameof(Index));
    }
}
