namespace ChillGames.Models.Orders
{
    using Common;

    /// <summary>
    /// Позиция заказа.
    /// </summary>
    [Model]
    public class OrderPosition : OrderPositionInfo
    {
        /// <summary>
        /// Получает или задает идентификатор заказа.
        /// </summary>
        public string OrderId { get; set; }
    }
}