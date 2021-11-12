namespace ChillGames.Data.Repositories.GamesRepositories
{
    using Models.Entities.Games;

    /// <summary>
    /// Интерфейс репозитория для доступа к играм.
    /// </summary>
    public interface IGamesRepository : IRepository<EntityGame>
    {
    }
}