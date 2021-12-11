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
        public string Id { get; set; }
        
        /// <summary>
        /// Получает или задает дату заказа.
        /// </summary>
        public DateTime OrderDate { get; set; }
        
        /// <summary>
        /// Получает или задает список позиций заказа.
        /// </summary>
        public IReadOnlyCollection<OrderPosition> OrderPositions { get; set; }
        
        /// <summary>
        /// Получает или задает сумму заказа.
        /// </summary>
        public int Amount { get; set; }
    }
}