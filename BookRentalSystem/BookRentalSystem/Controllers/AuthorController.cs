﻿using Application.Author.Commands.CreateAuthorCommand;
using Application.Author.Commands.DeleteAuthorCommand;
using Application.Author.Commands.EditAuthorCommand;
using Application.Author.Queries.GetAllAuthorsQuery;
using Application.Author.Queries.GetAuthorByIdQuery;
using AutoMapper;
using BookRentalSystem.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class AuthorController(
    IMediator mediator,
    IMapper mapper)
    : Controller
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var authors = await mediator.Send(new GetAllAuthorsQuery());
        return View(authors);
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateAuthorCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await mediator.Send(command);
        this.SetNotification("success", "Author created successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [Route("Author/Details/{authorId}")]
    public async Task<IActionResult> Details(int authorId)
    {
        var authorDto = await mediator.Send(new GetAuthorByIdQuery(authorId));
        return View(authorDto);
    }

    [Authorize]
    [Route("Author/Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var authorDto = await mediator.Send(new GetAuthorByIdQuery(id));
        var model = mapper.Map<EditAuthorCommand>(authorDto);
        return View(model);
    }

    [Authorize]
    [HttpPost]
    [Route("Author/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, EditAuthorCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await mediator.Send(command);
        this.SetNotification("info", "Author updated successfully.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [Route("Author/Delete/{authorId}")]
    public async Task<IActionResult> Delete(int authorId)
    {
        await mediator.Send(new DeleteAuthorCommand(authorId));
        this.SetNotification("error", "Author deleted successfully.");
        return RedirectToAction(nameof(Index));
    }
}
