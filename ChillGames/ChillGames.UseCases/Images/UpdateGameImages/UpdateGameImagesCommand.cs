namespace ChillGames.UseCases.Images.UpdateGameImages
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Images;

    /// <summary>
    /// Команда обновления игровых изображений.
    /// </summary>
    [PublicAPI]
    public class UpdateGameImagesCommand : IRequest
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string GameId { get; set; }
        
        /// <summary>
        /// Получает или задает изображения для обновления.
        /// </summary>
        public IReadOnlyCollection<GameImage> Images { get; set; }
    }
}