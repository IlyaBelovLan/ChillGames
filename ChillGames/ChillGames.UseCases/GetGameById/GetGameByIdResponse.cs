namespace ChillGames.UseCases.GetGameById
{
    using JetBrains.Annotations;
    using Models.Games;

    /// <summary>
    /// Ответ для <see cref="GetGameByIdQuery"/>.
    /// </summary>
    [PublicAPI]
    public class GetGameByIdResponse
    {
        /// <summary>
        /// Получает или задает игру.
        /// </summary>
        public Game Game { get; set; }
    }
}