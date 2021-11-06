namespace ChillGames.Models.Entities.Users
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Games;
    using Orders;

    [EntityModel]
    public class EntityUser
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public long EntityUserID { get; set; }
        
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
        public IReadOnlyCollection<EntityOrder> Orders { get; set; }
        
        /// <summary>
        /// Получает или задает список желаемого пользователя.
        /// </summary>
        public IReadOnlyCollection<EntityGame> WishList { get; set; }
    }
}