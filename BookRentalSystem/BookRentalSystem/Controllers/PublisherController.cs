﻿using Application.Publisher.Commands.CreatePublisherCommand;
using Application.Publisher.Commands.DeletePublisherCommand;
using Application.Publisher.Commands.EditPublisherCommand;
using Application.Publisher.Queries.GetAllPublishersQuery;
using Application.Publisher.Queries.GetPublisherByIdQuery;
using AutoMapper;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class PublisherController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var publishers = await mediator.Send(new GetAllPublishersQuery());
        return View(publishers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePublisherCommand command)
    {
        await mediator.Send(command);
        this.SetNotification("success", "Publisher created successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Route("Publisher/Details/{publisherId}")]
    public async Task<IActionResult> Details(int publisherId)
    {
        var publisherDto = await mediator.Send(new GetPublisherByIdQuery(publisherId));
        return View(publisherDto);
    }

    [Route("Publisher/Edit/{publisherId}")]
    public async Task<IActionResult> Edit(int publisherId)
    {
        var publisherDto = await mediator.Send(new GetPublisherByIdQuery(publisherId));
        var model = mapper.Map<EditPublisherCommand>(publisherDto);
        return View(model);
    }

    [HttpPost]
    [Route("Publisher/Edit/{publisherId}")]
    public async Task<IActionResult> Edit(int publisherId, EditPublisherCommand command)
    {
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Publisher/Delete/{publisherId}")]
    public async Task<IActionResult> Delete(int publisherId)
    {
        await mediator.Send(new DeletePublisherCommand(publisherId));
        return RedirectToAction(nameof(Index));
    }
}
