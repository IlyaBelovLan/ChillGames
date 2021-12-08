namespace ChillGames.UseCases.Games.GetGamesByFilters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Exceptions;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamesByFiltersUseCase : IRequestHandler<GetGamesByFiltersQuery, GetGamesByFiltersResponse>
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGamesByFiltersUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetGamesByFiltersUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetGamesByFiltersResponse> Handle(GetGamesByFiltersQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var filters = query.GamesSearchFilters;
            
            var entityGames = await _dbContext.Games
                .Include(i => i.Translations)
                .Include(i => i.Tags)
                .Where(w => filters.Genres.IsNullOrEmpty() || filters.Genres.Contains(w.Genre))
                .Where(w => filters.ReleaseDateInterval == null || filters.ReleaseDateInterval.From <= w.ReleaseDate && w.ReleaseDate <= filters.ReleaseDateInterval.To)
                .Where(w => filters.PriceInterval == null || filters.PriceInterval.From <= w.Price && w.Price <= filters.PriceInterval.To)
                .OrderByDescending(query.SortBy.ToSortExpression())
                .Skip(query.PageNumber * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            entityGames = entityGames
                .Where(w => filters.Launchers.IsNullOrEmpty() || filters.Launchers.Intersect(w.Launchers).Any())
                .ToList();

            if (entityGames == null)
                throw new UseCaseException("Не удалось найти игры!");
            
            var games = _mapper.Map<List<Game>>(entityGames);

            return new GetGamesByFiltersResponse { Games = games };
        }
    }
}