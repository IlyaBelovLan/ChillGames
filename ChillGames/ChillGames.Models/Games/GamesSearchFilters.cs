namespace ChillGames.Models.Games
{
    using System.Collections.Generic;
    using Common;

    /// <summary>
    /// Фильтры поиска игр.
    /// </summary>
    [Model]
    public class GamesSearchFilters
    {
        /// <summary>
        /// Получает или задает жанры игры.
        /// </summary>
        public IReadOnlyCollection<string> Genres { get; set; }
        
        /// <summary>
        /// Получает или задает период выхода игры.
        /// </summary>
        public DateInterval ReleaseDateInterval { get; set; }
        
        /// <summary>
        /// Получает или задает лаунчеры игры.
        /// </summary>
        public IReadOnlyCollection<Launcher> Launchers { get; set; }
        
        /// <summary>
        /// Получает или задает диапазон цены игры.
        /// </summary>
        public PriceInterval PriceInterval { get; set; }
    }
}