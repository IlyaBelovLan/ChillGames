using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChillGames.Models.Entities.Users
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Games;
    using Images;
    using Orders;

    [EntityModel]
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class EntityUser : IEntityWithId
    {
        /// <inheritdoc />
        public long Id { get; set; }
        
        /// <summary>
        /// Получает или задает имя пользователя.
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Получает или задает адрес электронной почты пользователя.
        /// </summary>
        [Required]
        public string Email { get; set; }
        
        /// <summary>
        /// Получает или задает дату регистрации пользователя.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Получает или задает список заказов пользователя.
        /// </summary>
        public ICollection<EntityOrder> Orders { get; set; } = new List<EntityOrder>();

        /// <summary>
        /// Получает или задает список желаемого пользователя.
        /// </summary>
        public ICollection<EntityGame> WishList { get; set; } = new List<EntityGame>();

        /// <summary>
        /// Получает или задает аватар пользователя.
        /// </summary>
        public EntityUserImage UserImage { get; set; }
    }
}