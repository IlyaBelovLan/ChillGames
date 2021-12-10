using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChillGames.Models.Entities.Games;

namespace ChillGames.Models.Entities.Orders
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Users;

    /// <summary>
    /// Сущность заказа из базы данных.
    /// </summary>
    [EntityModel]
    [Table("Orders")]
    public class EntityOrder : IEntityWithId
    {
        /// <inheritdoc />
        public long Id { get; set; }
        
        /// <summary>
        /// Получает или задает дату заказа.
        /// </summary>
        [Required]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Получает или задает список позиций заказа.
        /// </summary>
        public ICollection<EntityOrderPosition> OrderPositions { get; set; } = new List<EntityOrderPosition>();

        /// <summary>
        /// Получает или задает список игр в заказе.
        /// </summary>
        public ICollection<EntityGame> Games { get; set; } = new List<EntityGame>();
        
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public long EntityUserId { get; set; }
        
        /// <summary>
        /// Получает или задает пользователя, сделавшего заказ.
        /// </summary>
        public EntityUser EntityUser { get; set; }

        /// <summary>
        /// Получает или задает сумму заказа.
        /// </summary>
        [Required]
        public int Amount { get; set; }
    }
}