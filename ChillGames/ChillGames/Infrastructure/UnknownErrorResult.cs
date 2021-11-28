namespace ChillGames.WebApi.Infrastructure
{
    using JetBrains.Annotations;

    /// <summary>
    /// Результат с неизвестной ошибкой.
    /// </summary>
    [PublicAPI]
    public class UnknownErrorResult : AbstractRequestResult
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UnknownErrorResult"/>.
        /// </summary>
        /// <param name="value">Результат операции.</param>
        public UnknownErrorResult(object value) : base(value, (int)HttpCodes.UnknownError) {}
    }
}