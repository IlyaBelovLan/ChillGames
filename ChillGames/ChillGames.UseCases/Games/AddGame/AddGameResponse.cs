namespace ChillGames.UseCases.Games.AddGame
{
    using JetBrains.Annotations;

    /// <summary>
    /// Ответ для <see cref="AddGameCommand"/>.
    /// </summary>
    [PublicAPI]
    public class AddGameResponse
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string Id { get; set; }
    }
}