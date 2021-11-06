namespace ChillGames.Models.Orders
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Games;

    /// <summary>
    /// Покупка игры.
    /// </summary>
    [Model]
    public class Order
    {
        /// <summary>
        /// Получает или задает идентификатор заказа.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Получает или задает дату заказа.
        /// </summary>
        public DateTime OrderDate { get; set; }
        
        /// <summary>
        /// Получает или задает список купленных игр и их количество.
        /// </summary>
        public IReadOnlyCollection<KeyValue<Game, int>> ShoppingList { get; set; }
        
        /// <summary>
        /// Получает или задает сумму заказа.
        /// </summary>
        public int Amount { get; set; }
    }
}