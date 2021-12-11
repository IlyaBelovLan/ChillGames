namespace ChillGames.UseCases.Users.GetOrdersForUser
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Models.Orders;

    /// <summary>
    /// Ответ для <see cref="GetOrdersForUserResponse"/>
    /// </summary>
    [PublicAPI]
    public class GetOrdersForUserResponse
    {
        /// <summary>
        /// Получает или задает заказы пользователя.
        /// </summary>
        public IReadOnlyCollection<Order> Orders { get; set; }

    }
}