namespace ChillGames.UseCases.Games.GetGamesByFilters
{
    using Common;
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamesByFiltersQueryValidator : AbstractValidator<GetGamesByFiltersQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGamesByFiltersQueryValidator"/>.
        /// </summary>
        public GetGamesByFiltersQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(q => q.GamesSearchFilters)
                .NotNull()
                .WithMessage("Не заданы фильтры поиска!");
            
            Include(new RequestWithPaginationValidator());
        }
    }
}