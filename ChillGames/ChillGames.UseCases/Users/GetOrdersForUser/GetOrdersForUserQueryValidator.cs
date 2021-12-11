namespace ChillGames.UseCases.Users.GetOrdersForUser
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetOrdersForUserQueryValidator : AbstractValidator<GetOrdersForUserQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrdersForUserQueryValidator"/>.
        /// </summary>
        public GetOrdersForUserQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор пользователя!");
        }
    }
}