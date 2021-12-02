namespace ChillGames.Models.Images
{
    using Common;

    /// <summary>
    /// Игровое изображение.
    /// </summary>
    [Model]
    public class GameImage
    {
        /// <summary>
        /// Получает или задает идентификатор изображения.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// Получает или задает кодовую строку изображения.
        /// </summary>
        public string ImageCode { get; set; }

        /// <summary>
        /// Получает или задет флаг изображения-обложки.
        /// </summary>
        public bool IsPreview { get; set; }

        /// <summary>
        /// Получает или задает порядок изображения в списке скриншотов.
        /// </summary>
        public int Order { get; set; }
    }
}