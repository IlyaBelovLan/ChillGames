namespace ChillGames.UseCases.Games.DeleteGameById
{
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Команда удаления игры.
    /// </summary>
    [PublicAPI]
    public class DeleteGameByIdCommand : IRequest
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string Id { get; set; }
    }
}