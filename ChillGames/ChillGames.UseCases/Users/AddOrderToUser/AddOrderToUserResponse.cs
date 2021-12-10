namespace ChillGames.UseCases.Users.AddOrderToUser
{
    using JetBrains.Annotations;

    /// <summary>
    /// Ответ для <see cref="AddOrderToUserCommand"/>.
    /// </summary>
    [PublicAPI]
    public class AddOrderToUserResponse
    {
        /// <summary>
        /// Получает или задает идентификатор заказа.
        /// </summary>
        public string Id { get; set; }
    }
}