namespace ChillGames.Models.Entities.Orders
{
    using Common;
    using Games;

    /// <summary>
    /// Позиция заказа.
    /// </summary>
    [EntityModel]
    public class EntityOrderPosition
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public long EntityGameId { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор заказа.
        /// </summary>
        public long EntityOrderId { get; set; }
        
        /// <summary>
        /// Получает или задает количество копий игры.
        /// </summary>
        public int Count { get; set; }
        
        /// <summary>
        /// Получает или задает цену за игру.
        /// </summary>
        public int Price { get; set; }
        
        /// <summary>
        /// Получает или задает заказ.
        /// </summary>
        public EntityOrder Order { get; set; }
        
        /// <summary>
        /// Получает или задает игру.
        /// </summary>
        public EntityGame Game { get; set; }
    }
}