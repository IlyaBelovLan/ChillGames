namespace ChillGames.UseCases.Games.GetGamesByIds
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
    public class GetGamesByIdsUseCase : IRequestHandler<GetGamesByIdsQuery, GetGamesByIdsResponse>
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
        /// Инициализирует экземпляр <see cref="GetGamesByIdsUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetGamesByIdsUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetGamesByIdsResponse> Handle(GetGamesByIdsQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGames = await _dbContext.Games
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .Where(w => query.Ids.ToLong().Contains(w.Id))
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            if (entityGames.IsNullOrEmpty())
                throw new UseCaseException("Игры не найдены!");
            
            var games = _mapper.Map<List<Game>>(entityGames);

            return new GetGamesByIdsResponse { Games = games };
        }
    }
}