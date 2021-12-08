namespace ChillGames.UseCases.Images.DeleteGameImages
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Команда удаления игровых изображений.
    /// </summary>
    [PublicAPI]
    public class DeleteGameImagesCommand : IRequest
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string GameId { get; set; }
        
        /// <summary>
        /// Получает или задает идентификаторы изображений.
        /// </summary>
        public IReadOnlyCollection<string> ImageIds { get; set; }
    }
}