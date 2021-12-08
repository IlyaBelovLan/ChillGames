namespace ChillGames.UseCases.Games.GetAllGames
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetAllGamesUseCase : IRequestHandler<GetAllGamesQuery, GetAllGamesResponse>
    {
        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetAllGamesUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public GetAllGamesUseCase(IMapper mapper, StoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<GetAllGamesResponse> Handle(GetAllGamesQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGames = await _dbContext.Games
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            var games = _mapper.Map<List<Game>>(entityGames);

            return new GetAllGamesResponse { Games = games };
        }
    }
}