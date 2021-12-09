namespace ChillGames.UseCases.Users.GetUserInfo
{
    using JetBrains.Annotations;
    using Models.Users;

    /// <summary>
    /// Ответ для <see cref="GetUserInfoQuery"/>.
    /// </summary>
    [PublicAPI]
    public class GetUserInfoResponse
    {
        /// <summary>
        /// Получает или задает информацию о пользователе.
        /// </summary>
        public UserInfo UserInfo { get; set; }
    }
}