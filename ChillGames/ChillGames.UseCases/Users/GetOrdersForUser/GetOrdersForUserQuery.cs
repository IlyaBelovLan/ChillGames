namespace ChillGames.UseCases.Users.GetOrdersForUser
{
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Запрос получения заказов пользователя.
    /// </summary>
    [PublicAPI]
    public class GetOrdersForUserQuery : IRequest<GetOrdersForUserResponse>
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public string Id { get; set; }
    }
}