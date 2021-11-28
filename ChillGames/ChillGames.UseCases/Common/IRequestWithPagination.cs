namespace ChillGames.UseCases.Common
{
    /// <summary>
    /// Задает запрос с полями для пагинации.
    /// </summary>
    public interface IRequestWithPagination
    {
        /// <summary>
        /// Получает или задает количество элементов на странице.
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// Получает или задает номер страницы.
        /// </summary>
        public int PageNumber { get; set; }
    }
}