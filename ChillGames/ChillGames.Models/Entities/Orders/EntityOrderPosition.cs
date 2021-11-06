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
        /// Получает или задает идентфикатор позиции заказа.
        /// </summary>
        public long EntityOrderPositionID { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string EntityGameID { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор заказа.
        /// </summary>
        public string EntityOrderID { get; set; }
        
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
        public EntityOrder EntityOrder { get; set; }
        
        /// <summary>
        /// Получает или задает игру.
        /// </summary>
        public EntityGame EntityGame { get; set; }
    }
}