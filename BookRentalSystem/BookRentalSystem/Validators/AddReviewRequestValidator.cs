using BookRentalSystem.Entities;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Persistence;
using FluentValidation;

namespace BookRentalSystem.Validators;

public class AddReviewRequestValidator : AbstractValidator<AddReviewRequest>
{
    private readonly AppDbContext _dbContext;
    public AddReviewRequestValidator(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(request => request.bookId)
            .Exists<AddReviewRequest, Category>(dbContext)
            .WithMessage("The specified category does not exist.");
    }
}
