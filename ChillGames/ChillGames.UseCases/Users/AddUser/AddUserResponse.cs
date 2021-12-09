namespace ChillGames.UseCases.Users.AddUser
{
    using JetBrains.Annotations;

    /// <summary>
    /// Ответ для <see cref="AddUserCommand"/>.
    /// </summary>
    [PublicAPI]
    public class AddUserResponse
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public string Id { get; set; }
    }
}