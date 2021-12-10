namespace ChillGames.Models.Orders
{
    using System.Text.Json.Serialization;
    using Entities.Games;

    /// <summary>
    /// Информация о позиции заказа.
    /// </summary>
    public class OrderPositionInfo
    {
        /// <summary>
        /// Получает или задает количество копий игры.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string GameId { get; set; }
        
        /// <summary>
        /// Получает или задает игру из заказа.
        /// </summary>
        [JsonIgnore]
        public EntityGame EntityGame { get; set; }
    }
}