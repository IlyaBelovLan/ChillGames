namespace ChillGames.Models.Users
{
    using System;
    using Common;

    /// <summary>
    /// Информация о пользователе.
    /// </summary>
    [Model]
    public class UserInfo
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Получает или задает имя пользователя.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Получает или задает адрес электронной почты пользователя.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Получает или задает дату регистрации пользователя.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
    }
}