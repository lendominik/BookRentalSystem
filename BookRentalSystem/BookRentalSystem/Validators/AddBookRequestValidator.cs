﻿using Core.Entities;
using Core.Models.Requests;
using Infrastructure.Persistence;
using FluentValidation;

namespace BookRentalSystem.Validators;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    private readonly AppDbContext _dbContext;
    public AddBookRequestValidator(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(request => request.authorId)
            .Exists<AddBookRequest, Author>(dbContext)
            .WithMessage("The specified author does not exist.");

        RuleFor(request => request.publisherId)
            .Exists<AddBookRequest, Publisher>(dbContext)
            .WithMessage("The specified publisher does not exist.");

        RuleFor(request => request.categoryId)
            .Exists<AddBookRequest, Category>(dbContext)
            .WithMessage("The specified category does not exist.");
    }
}
