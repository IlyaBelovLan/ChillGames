namespace ChillGames.UseCases.Users.GetUserInfo
{
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Запрос получения информации о пользователе.
    /// </summary>
    [PublicAPI]
    public class GetUserInfoQuery : IRequest<GetUserInfoResponse>
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public string Id { get; set; }
    }
}