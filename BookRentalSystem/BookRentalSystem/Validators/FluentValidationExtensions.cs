using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookRentalSystem.Validators;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, int> Exists<T, TEntity>(
        this IRuleBuilder<T, int> ruleBuilder,
        DbContext dbContext,
        CancellationToken cancellationToken = default) where TEntity : class
    {
        return ruleBuilder.MustAsync(async (id, _) =>
        {
            return await dbContext.Set<TEntity>().AnyAsync(entity => EF.Property<int>(entity, "Id") == id, cancellationToken);
        }).WithMessage("The specified {PropertyName} does not exist.");
    }
}
