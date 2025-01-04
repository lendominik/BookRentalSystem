using Application.Publisher.Commands.CreatePublisherCommand;
using Application.Publisher.Commands.DeletePublisherCommand;
using Application.Publisher.Commands.EditPublisherCommand;
using Application.Publisher.Queries.GetAllPublishersQuery;
using Application.Publisher.Queries.GetPublisherByIdQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class PublisherController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    [HttpGet]
    [Route("Publisher")]
    public async Task<IActionResult> Index()
    {
        var publishers = await mediator.Send(new GetAllPublishersQuery());
        return View(publishers);
    }

    [HttpGet]
    [Route("Publisher/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("Publisher/Create")]
    public async Task<IActionResult> Create(CreatePublisherCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Publisher/{publisherId}/Details")]
    public async Task<IActionResult> Details(int publisherId)
    {
        var publisherDto = await mediator.Send(new GetPublisherByIdQuery(publisherId));
        return View(publisherDto);
    }

    [Route("Publisher/{publisherId}/Edit")]
    public async Task<IActionResult> Edit(int publisherId)
    {
        var publisherDto = await mediator.Send(new GetPublisherByIdQuery(publisherId));
        var model = mapper.Map<EditPublisherCommand>(publisherDto);
        return View(model);
    }

    [HttpPost]
    [Route("Publisher/{publisherId}/Edit")]
    public async Task<IActionResult> Edit(int publisherId, EditPublisherCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Publisher/{publisherId}/Delete")]
    public async Task<IActionResult> Delete(int publisherId)
    {
        await mediator.Send(new DeletePublisherCommand(publisherId));
        return RedirectToAction(nameof(Index));
    }
}
