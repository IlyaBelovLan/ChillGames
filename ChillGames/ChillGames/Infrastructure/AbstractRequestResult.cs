namespace ChillGames.WebApi.Infrastructure
{
    /// <summary>
    /// Базовый класс результата Http-запроса.
    /// </summary>
    public class AbstractRequestResult
    {
        /// <summary>
        /// Результат выполнения.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Код результата.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="AbstractRequestResult"/>.
        /// </summary>
        /// <param name="value">Результат выполнения.</param>
        /// <param name="statusCode">Код результата.</param>
        public AbstractRequestResult(object value, int statusCode)
        {
            Value = value;
            StatusCode = statusCode;
        }
    }
}