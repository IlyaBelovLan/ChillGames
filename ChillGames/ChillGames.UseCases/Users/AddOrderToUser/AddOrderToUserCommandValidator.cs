namespace ChillGames.UseCases.Users.AddOrderToUser
{
    using Common;
    using Data.StoreContext;
    using FluentValidation;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Users;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddOrderToUserCommandValidator : AbstractValidator<AddOrderToUserCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddOrderToUserCommandValidator"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public AddOrderToUserCommandValidator(StoreDbContext dbContext)
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("Не задан идентификатор пользователя!")
                .CustomAsync(async (id, context, cancellationToken) =>
                {
                    var user = await dbContext.GetDbSet<EntityUser>()
                        .FirstOrDefaultAsync(f => f.Id == id.ToLong())
                        .ConfigureAwait(false);

                    if (user == null)
                        context.AddFailure("Пользователь не найден!");
                });

            RuleForEach(c => c.OrderPositionInfos)
                .SetValidator(new OrderPositionInfoValidator(dbContext));
        }
    }
}