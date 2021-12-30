namespace ChillGames.UseCases.Images.GetGamePreview
{
    using MediatR;
    
    /// <summary>
    /// Запрос получения превью игры.
    /// </summary>
    public class GetGamePreviewQuery : IRequest<GetGamePreviewResponse>
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string Id { get; set; }
    }
}