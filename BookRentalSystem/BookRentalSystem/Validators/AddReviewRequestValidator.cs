using BookRentalSystem.Entities;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookRentalSystem.Validators;

public class AddReviewRequestValidator : AbstractValidator<AddReviewRequest>
{
    private readonly AppDbContext _dbContext;
    public AddReviewRequestValidator(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(review => review.bookId)
            .MustAsync(BookExists).WithMessage("The specified book does not exist.");
    }

    private async Task<bool> BookExists(int bookId, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Book>().AnyAsync(book => book.Id == bookId, cancellationToken);
    }
}
