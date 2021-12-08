namespace ChillGames.UseCases.Images.GetGameImagesById
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Models.Images;

    /// <summary>
    /// Ответ для <see cref="GetGameImagesByIdQuery"/>.
    /// </summary>
    [PublicAPI]
    public class GetGameImagesByIdResponse
    {
        /// <summary>
        /// Получает или задает список игровых изображений.
        /// </summary>
        public IReadOnlyCollection<GameImage> Images { get; set; }
    }
}