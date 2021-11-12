namespace ChillGames.UseCases.Common.Exceptions
{
    using System;

    /// <summary>
    /// Исключение обработки запроса.
    /// </summary>
    public class UseCaseException : Exception
    {
        /// <summary>
        /// Инициализирует пустой экземпляр <see cref="UseCaseException"/>.
        /// </summary>
        public UseCaseException(){}

        /// <summary>
        /// Инициализирует экземпляр <see cref="UseCaseException"/> с сообщением.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        public UseCaseException(string message) : base(message){}
        
        /// <summary>
        /// Инициализирует экземпляр <see cref="UseCaseException"/> с сообщением и исключением.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="innerException">Внутренне исключение.</param>
        public UseCaseException(string message, Exception innerException) : base(message, innerException){}
    }
}