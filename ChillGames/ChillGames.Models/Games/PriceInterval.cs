namespace ChillGames.Models.Games
{
    using Common;

    /// <summary>
    /// Диапазон цены.
    /// </summary>
    [Model]
    public class PriceInterval
    {
        /// <summary>
        /// Получает или задает нижнюю границу диапазона цены.
        /// </summary>
        public int From { get; set; }
        
        /// <summary>
        /// Получает или задает верхнюю границу диапазона цены.
        /// </summary>
        public int To { get; set; }
    }
}