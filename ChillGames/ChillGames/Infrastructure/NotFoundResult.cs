namespace ChillGames.WebApi.Infrastructure
{
    using JetBrains.Annotations;

    /// <summary>
    /// Результат отстутствия искомых данных. 
    /// </summary>
    [PublicAPI]
    public class NotFoundResult : AbstractRequestResult
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="NotFoundResult"/>.
        /// </summary>
        /// <param name="value">Результат операции.</param>
        public NotFoundResult(object value) :base(value, (int)HttpCodes.NotFound){}
    }
}