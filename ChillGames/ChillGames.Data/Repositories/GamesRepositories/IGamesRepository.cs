namespace ChillGames.Data.Repositories.GamesRepositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Entities.Games;
    using Models.Games;

    /// <summary>
    /// Интерфейс репозитория для доступа к играм.
    /// </summary>
    public interface IGamesRepository : IRepository<EntityGame>
    {
        /// <summary>
        /// Возвращает список игр, удовлетворяющих фильтрам.
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyCollection<EntityGame>> GetGamesByFiltersAsync(GamesSearchParams filters);
    }
}