namespace ChillGames.UseCases.Games.GetGamesByIds
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamesByIdsQueryValidator : AbstractValidator<GetGamesByIdsQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGamesByIdsQueryValidator"/>.
        /// </summary>
        public GetGamesByIdsQueryValidator()
        {
            RuleFor(q => q.Ids)
                .NotEmpty()
                .WithMessage("Не заданы идентификаторы игр!");
        }
    }
}