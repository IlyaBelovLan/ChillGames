namespace ChillGames.Models.Entities
{
    /// <summary>
    /// Интерфейс сущности с идентификатором.
    /// </summary>
    public interface IEntityWithId
    {
        /// <summary>
        /// Получает или задает идентификатор сущности.
        /// </summary>
        public long Id { get; set; }
    }
}