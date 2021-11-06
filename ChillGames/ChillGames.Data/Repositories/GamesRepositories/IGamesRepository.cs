namespace ChillGames.Data.Repositories.GamesRepositories
{
    using System.Collections.Generic;
    using Models.Entities.Games;

    /// <summary>
    /// Интерфейс репозитория для доступа к играм.
    /// </summary>
    public interface IGamesRepository : ISaveableRepository
    {
        /// <summary>
        /// Возвращает игру с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        /// <returns><see cref="EntityGame"/>.</returns>
        EntityGame GetGameById(long id);
        
        /// <summary>
        /// Возвращает игры с заданными идентификаторами.
        /// </summary>
        /// <param name="ids">Идентификаторы игр.</param>
        /// <returns>Список <see cref="EntityGame"/>.</returns>
        IReadOnlyCollection<EntityGame> GetGamesByIds(IReadOnlyCollection<long> ids);

        /// <summary>
        /// Добавляет игру.
        /// </summary>
        /// <param name="game"><see cref="EntityGame"/>.</param>
        void AddGame(EntityGame game);

        /// <summary>
        /// Обновляет игру.
        /// </summary>
        /// <param name="game"><see cref="EntityGame"/>.</param>
        void UpdateGame(EntityGame game);

        /// <summary>
        /// Удаляет игру с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        void DeleteGameById(long id);
    }
}