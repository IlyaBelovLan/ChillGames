namespace ChillGames.Models.Games
{
    using System;
    using Common;

    /// <summary>
    /// Интервал дат.
    /// </summary>
    [Model]
    public class DateInterval
    {
        /// <summary>
        /// Получает или задает нижнюю границу интервала.
        /// </summary>
        public DateTime From { get; set; }
        
        /// <summary>
        /// Получает или задает верхнюю границу интервала.
        /// </summary>
        public DateTime To { get; set; }
    }
}