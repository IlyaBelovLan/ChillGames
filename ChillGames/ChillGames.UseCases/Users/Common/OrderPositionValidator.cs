namespace ChillGames.UseCases.Users.Common
{
    using Data.StoreContext;
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Orders;

    /// <inheritdoc />
    [UsedImplicitly]
    public class OrderPositionValidator : AbstractValidator<OrderPosition>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="OrderPositionValidator"/>.
        /// </summary>
        public OrderPositionValidator(StoreDbContext dbContext)
        {
            CascadeMode = CascadeMode.Stop;
            
            Include(new OrderPositionInfoValidator(dbContext));

            RuleFor(o => o.OrderId)
                .NotEmpty()
                .WithMessage("Не задан идентификатор заказа!");
        }
    }
}