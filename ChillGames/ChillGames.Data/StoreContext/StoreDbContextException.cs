namespace ChillGames.Data.StoreContext
{
    using System;
    
    /// <summary>
    /// Исключение контекста базы данных.
    /// </summary>
    public class StoreDbContextException : Exception
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="StoreDbContextException"/>.
        /// </summary>
        public StoreDbContextException()
        {
        }

        /// <summary>
        /// Инициализирует экземпляр <see cref="StoreDbContextException"/>.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        public StoreDbContextException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует экземпляр <see cref="StoreDbContextException"/>.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        /// <param name="innerException">Вложенное исключение.</param>
        public StoreDbContextException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}