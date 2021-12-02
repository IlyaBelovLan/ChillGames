namespace ChillGames.UseCases.Images.AddGameImages
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Images;

    /// <summary>
    /// Команда добавления изображений для игры.
    /// </summary>
    [PublicAPI]
    public class AddGameImagesCommand : IRequest<Unit>
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string GameId { get; set; }
        
        /// <summary>
        /// Получает или задает список изображений.
        /// </summary>
        public IReadOnlyCollection<GameImageInfo> Images { get; set; }
    }
}