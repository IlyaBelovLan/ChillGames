namespace ChillGames.UseCases.Games.GetGamesByFilters
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Models.Games;

    /// <summary>
    /// Ответ для <see cref="GetGamesByFiltersQuery"/>.
    /// </summary>
    [PublicAPI]
    public class GetGamesByFiltersResponse
    {
        /// <summary>
        /// Получает или задает список игр.
        /// </summary>
        public IReadOnlyCollection<Game> Games { get; set; }
    }
}