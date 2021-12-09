namespace ChillGames.Models.Images
{
    using Common;

    /// <summary>
    /// Игровое изображение.
    /// </summary>
    [Model]
    public class GameImage : GameImageInfo
    {
        /// <summary>
        /// Получает или задает идентификатор изображения.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string GameId { get; set; }
    }
}