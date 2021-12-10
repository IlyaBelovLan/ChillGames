namespace ChillGames.UseCases.Users.AddOrderToUser
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Orders;

    /// <summary>
    /// Команда добавления заказа для пользователя.
    /// </summary>
    [PublicAPI]
    public class AddOrderToUserCommand : IRequest<AddOrderToUserResponse>
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Получает или задает список позиций заказа.
        /// </summary>
        public IList<OrderPositionInfo> OrderPositionInfos { get; set; }
    }
}