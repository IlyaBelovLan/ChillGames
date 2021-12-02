namespace ChillGames.Models.Images
{
    using JetBrains.Annotations;

    /// <summary>
    /// Изображение.
    /// </summary>
    [PublicAPI]
    public class GameImageInfo
    {
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