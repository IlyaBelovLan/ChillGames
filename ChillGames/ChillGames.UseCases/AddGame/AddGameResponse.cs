namespace ChillGames.UseCases.AddGame
{
    /// <summary>
    /// Ответ для <see cref="AddGameCommand"/>.
    /// </summary>
    public class AddGameResponse
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public string Id { get; set; }
    }
}