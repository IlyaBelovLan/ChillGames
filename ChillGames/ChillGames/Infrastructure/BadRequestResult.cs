namespace ChillGames.WebApi.Infrastructure
{
    using System.Net;
    using JetBrains.Annotations;

    /// <summary>
    /// Результат плохого запроса.
    /// </summary>
    [PublicAPI]
    public class BadRequestResult : AbstractRequestResult
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="BadRequestResult"/>.
        /// </summary>
        /// <param name="value">Результат операции.</param>
        public BadRequestResult(object value) : base(value, (int)HttpStatusCode.BadRequest) { }
    }
}