namespace ChillGames.UseCases.Images.GetGamePreview
{
    /// <summary>
    /// Ответ для <see cref="GetGamePreviewQuery"/>.
    /// </summary>
    public class GetGamePreviewResponse
    {
        /// <summary>
        /// Получает или задает код изображения.
        /// </summary>
        public string ImageCode { get; set; }
    }
}