namespace ChillGames.UseCases.Users.Common
{
    using Data.StoreContext;
    using FluentValidation;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Games;
    using Models.Orders;

    /// <inheritdoc />
    [UsedImplicitly]
    public class OrderPositionInfoValidator : AbstractValidator<OrderPositionInfo>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="OrderPositionInfoValidator"/>.
        /// </summary>
        public OrderPositionInfoValidator(StoreDbContext dbContext)
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(o => o)
                .CustomAsync(async (orderPosition, context, cancellationToken) =>
                {
                    var game = await dbContext.GetDbSet<EntityGame>()
                        .FirstOrDefaultAsync(f => f.Id == orderPosition.GameId.ToLong()).ConfigureAwait(false);

                    if (game == null)
                    {
                        context.AddFailure("Игра не найдена!");
                        return;
                    }

                    if (!(orderPosition.Count > 0 && orderPosition.Count <= game.Count))
                    {
                        context.AddFailure("Недопустимое количество копий игры!");
                    }
                });
        }
    }
}