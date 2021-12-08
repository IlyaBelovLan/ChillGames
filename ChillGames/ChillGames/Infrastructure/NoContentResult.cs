namespace ChillGames.WebApi.Infrastructure
{
    using JetBrains.Annotations;

    /// <summary>
    /// Результат отстутствия искомых данных. 
    /// </summary>
    [PublicAPI]
    public class NoContentResult : AbstractRequestResult
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="NoContentResult"/>.
        /// </summary>
        /// <param name="value">Результат операции.</param>
        public NoContentResult(object value) :base(value, (int)HttpCodes.NoContent){}
    }
}