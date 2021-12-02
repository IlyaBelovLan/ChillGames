namespace ChillGames.Data.Repositories.GamesRepositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Games;
    using StoreContext;
    using System.Threading.Tasks;
    using AutoMapper;
    using Models.Games;

    /// <summary>
    /// Репозиторий для доступа к играм.
    /// </summary>
    public class GamesRepository : AbstractStoreRepository<EntityGame>, IGamesRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GamesRepository"/>.
        /// </summary>
        /// <param name="storeDbContext"><see cref="GamesRepository"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GamesRepository(StoreDbContext storeDbContext, IMapper mapper) : base(storeDbContext, mapper) {}


        /// <inheritdoc />
        public override async Task<EntityGame> GetByIdAsync(long id)
        {
            return await StoreDbContext
                .Games
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .Where(w => w.Id == id)
                .FirstAsync();
        }

        /// <inheritdoc />
        public override async Task<ICollection<EntityGame>> GetAllAsync()
        {
            var games = await EntityDbSet
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .ToListAsync();

            return games;
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