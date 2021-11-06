namespace ChillGames.Models.Users
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Games;
    using Orders;

    /// <summary>
    /// Модель пользователя.
    /// </summary>
    [Model]
    public class User
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
        
        /// <summary>
        /// Получает или задает список заказов пользователя.
        /// </summary>
        public IReadOnlyCollection<Order> Orders { get; set; }
        
        /// <summary>
        /// Получает или задает список желаемого пользователя.
        /// </summary>
        public IReadOnlyCollection<Game> WishList { get; set; }
    }
}