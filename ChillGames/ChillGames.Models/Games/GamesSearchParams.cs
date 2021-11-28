namespace ChillGames.Models.Games
{
    using Common;

    /// <summary>
    /// Параметры поиска игр.
    /// </summary>
    [Model]
    public class GamesSearchParams
    {
        /// <summary>
        /// Получает или задает фильтры поиска игр.
        /// </summary>
        public GamesSearchFilters GamesSearchFilters { get; set; }
        
        /// <summary>
        /// Получает или задает количество игр на странице.
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// Получает или задает номер страницы.
        /// </summary>
        public int PageNumber { get; set; }
        
        /// <summary>
        /// Получает или задает поле сортировки.
        /// </summary>
        public OrderedField SortBy { get; set; }
    }
}