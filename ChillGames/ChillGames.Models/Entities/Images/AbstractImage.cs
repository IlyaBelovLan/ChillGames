namespace ChillGames.Models.Entities.Images
{
    /// <summary>
    /// Интерфейс изображения.
    /// </summary>
    public interface IImage : IEntityWithId
    {
        /// <summary>
        /// Получает или задает изображение, закодированное в строку.
        /// </summary>
        public string ImageCode { get; set; }
    }
}
