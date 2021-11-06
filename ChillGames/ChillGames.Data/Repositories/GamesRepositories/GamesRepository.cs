namespace ChillGames.Data.Repositories.GamesRepositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Entities.Games;
    using StoreContext;

    /// <summary>
    /// Репозиторий для доступа к играм.
    /// </summary>
    public class GamesRepository : AbstractStoreRepository, IGamesRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GamesRepository"/>.
        /// </summary>
        /// <param name="storeContext"><see cref="GamesRepository"/>.</param>
        public GamesRepository(StoreContext storeContext) : base(storeContext) {}

        public EntityGame GetGameById(long id)
        {
            return StoreContext.Games.Find(id);
        }

        /// <inheritdoc />
        public IReadOnlyCollection<EntityGame> GetGamesByIds(IReadOnlyCollection<long> ids)
        {
            return StoreContext.Games.Where(s => ids.Contains(s.EntityGameID)).ToList();
        }

        /// <inheritdoc />
        public void AddGame(EntityGame game)
        {
            StoreContext.Games.Add(game);
        }

        /// <inheritdoc />
        public void UpdateGame(EntityGame game)
        {
            StoreContext.Update(game);
        }

        /// <inheritdoc />
        public void DeleteGameById(long id)
        {
            var game = GetGameById(id);
            StoreContext.Games.Remove(game);
        }
    }
}