using BookRentalSystem.Entities;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookRentalSystem.Validators;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    private readonly AppDbContext _dbContext;
    public AddBookRequestValidator(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(book => book.authorId)
            .MustAsync(AuthorExsists).WithMessage("The specified author does not exist.");

        RuleFor(book => book.publisherId)
            .MustAsync(PublisherExsists).WithMessage("The specified publisher does not exist.");

        RuleFor(book => book.categoryId)
            .MustAsync(CategoryExsists).WithMessage("The specified category does not exist.");
    }

    private async Task<bool> AuthorExsists(int authorId, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Author>().AnyAsync(author => author.Id == authorId, cancellationToken);
    }
    private async Task<bool> PublisherExsists(int publisherId, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Publisher>().AnyAsync(publisher => publisher.Id == publisherId, cancellationToken);
    }
    private async Task<bool> CategoryExsists(int categoryId, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Category>().AnyAsync(category => category.Id == categoryId, cancellationToken);
    }
}
