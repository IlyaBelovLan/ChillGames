namespace ChillGames.UseCases.Games.GetGamesByIds
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Models.Games;

    /// <summary>
    /// Ответ для <see cref="GetGamesByIdsQuery"/>.
    /// </summary>
    [PublicAPI]
    public class GetGamesByIdsResponse
    {
        /// <summary>
        /// Получает или задает список игр.
        /// </summary>
        public IReadOnlyCollection<Game> Games { get; set; }
    }
}