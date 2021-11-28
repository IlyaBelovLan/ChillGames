namespace ChillGames.UseCases.Games.GetAllGames
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Models.Games;

    /// <summary>
    /// Ответ для <see cref="GetAllGamesQuery"/>.
    /// </summary>
    [PublicAPI]
    public class GetAllGamesResponse
    {
        /// <summary>
        /// Получает или задает список игр.
        /// </summary>
        public IReadOnlyCollection<Game> Games { get; set; }
    }
}