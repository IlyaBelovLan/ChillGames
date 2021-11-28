namespace ChillGames.UseCases.Games.GetGamesByFilters
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories.GamesRepositories;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamesByFiltersUseCase : IRequestHandler<GetGamesByFiltersQuery, GetGamesByFiltersResponse>
    {
        /// <summary>
        /// <see cref="IGamesRepository"/>.
        /// </summary>
        private readonly IGamesRepository _gamesRepository;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGamesByFiltersUseCase"/>.
        /// </summary>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetGamesByFiltersUseCase(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetGamesByFiltersResponse> Handle(GetGamesByFiltersQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGames = await _gamesRepository.GetGamesByFiltersAsync(query).ConfigureAwait(false);

            var games = _mapper.Map<List<Game>>(entityGames);

            return new GetGamesByFiltersResponse { Games = games };
        }
    }
}