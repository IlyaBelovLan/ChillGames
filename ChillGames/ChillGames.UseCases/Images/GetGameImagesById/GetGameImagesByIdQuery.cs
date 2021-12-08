namespace ChillGames.UseCases.Images.GetGameImagesById
{
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Запрос получения игровых изображений.
    /// </summary>
    [PublicAPI]
    public class GetGameImagesByIdQuery : IRequest<GetGameImagesByIdResponse>
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string Id { get; set; }
    }
}