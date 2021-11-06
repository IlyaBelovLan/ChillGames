namespace ChillGames.Models.Entities.Orders
{
    using System;
    using System.Collections.Generic;
    using Common;

    /// <summary>
    /// Сущность заказа из базы данных.
    /// </summary>
    [EntityModel]
    public class EntityOrder
    {
        /// <summary>
        /// Получает или задает идентификатор заказа.
        /// </summary>
        public long EntityOrderID { get; set; }
        
        /// <summary>
        /// Получает или задает дату заказа.
        /// </summary>
        public DateTime OrderDate { get; set; }
        
        /// <summary>
        /// Получает или задает список купленных игр, их количество и стоимость.
        /// </summary>
        public IReadOnlyCollection<EntityOrderPosition> ShoppingList { get; set; }
        
        /// <summary>
        /// Получает или задает сумму заказа.
        /// </summary>
        public int Amount { get; set; }
    }
}