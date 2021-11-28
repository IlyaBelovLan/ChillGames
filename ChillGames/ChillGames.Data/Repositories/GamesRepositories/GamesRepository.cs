namespace ChillGames.Data.Repositories.GamesRepositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Games;
    using StoreContext;
    using System.Threading.Tasks;
    using Models.Games;

    /// <summary>
    /// Репозиторий для доступа к играм.
    /// </summary>
    public class GamesRepository : AbstractStoreRepository, IGamesRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GamesRepository"/>.
        /// </summary>
        /// <param name="storeDbContext"><see cref="GamesRepository"/>.</param>
        public GamesRepository(StoreDbContext storeDbContext) : base(storeDbContext) {}


        /// <inheritdoc />
        public async Task<EntityGame> GetByIdAsync(long id)
        {
            return await StoreDbContext
                .Games
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .Where(w => w.Id == id)
                .FirstAsync();
        }
        
        /// <inheritdoc />
        public async Task<ICollection<EntityGame>> GetByIdsAsync(IEnumerable<long> ids)
        {
            return await StoreDbContext.Games.Where(w => ids.Contains(w.Id)).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<ICollection<EntityGame>> GetAllAsync()
        {
            var games = await StoreDbContext
                .Games
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .ToListAsync();

            return games;
        }

        /// <inheritdoc />
        public async Task<long> AddAsync(EntityGame entity)
        {
            await StoreDbContext.AddAsync(entity);

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(EntityGame entity)
        {
            var game = await StoreDbContext.Games.FirstAsync(f => f.Id == entity.Id).ConfigureAwait(false);

            if (game == null)
            {
                await StoreDbContext.Games.AddAsync(entity).ConfigureAwait(false);
            }
            else
            {
                game.AssignFrom(entity);
                StoreDbContext.Games.Update(game);
            }
        }

        /// <inheritdoc />
        public async Task DeleteByIdAsync(long id)
        {
            await Task.Run(() =>
            {
                var game = AttachEntityWithId<EntityGame>(id);
            
                Delete(game);
            });
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<EntityGame>> GetGamesByFiltersAsync(GamesSearchParams searchParams)
        {
            var filters = searchParams.GamesSearchFilters;
            
            var games =  await StoreDbContext
                .Games
                .Include(i => i.Translations)
                .Include(i => i.Tags)
                .Where(w => !filters.Genres.IsNullOrEmpty() ? filters.Genres.Contains(w.Genre) : true)
                .Where(w => filters.ReleaseDateInterval != null ? filters.ReleaseDateInterval.From <= w.ReleaseDate && w.ReleaseDate <= filters.ReleaseDateInterval.To : true)
                .Where(w => filters.PriceInterval != null ? filters.PriceInterval.From <= w.Price && w.Price <= filters.PriceInterval.To : true)
                .OrderByDescending(searchParams.SortBy.ToSortExpression())
                .Skip(searchParams.PageNumber * searchParams.PageSize)
                .Take(searchParams.PageSize)
                .ToListAsync().ConfigureAwait(false);

            return games
                .Where(w => !filters.Launchers.IsNullOrEmpty() ? filters.Launchers.Intersect(w.Launchers).Any() : true)
                .ToList();
        }
    }
}