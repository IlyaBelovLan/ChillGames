namespace ChillGames.UseCases.GetGameById
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGameByIdQueryValidator"/>.
        /// </summary>
        public GetGameByIdQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");
        }
    }
}