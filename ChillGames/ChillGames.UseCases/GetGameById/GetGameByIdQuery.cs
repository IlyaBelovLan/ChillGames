namespace ChillGames.UseCases.GetGameById
{
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Запрос на получение игры по идентификатору.
    /// </summary>
    [PublicAPI]
    public class GetGameByIdQuery : IRequest<GetGameByIdResponse>
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string Id { get; set; }
    }
}