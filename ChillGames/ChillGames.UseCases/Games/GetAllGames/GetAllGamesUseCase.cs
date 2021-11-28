namespace ChillGames.UseCases.Games.GetAllGames
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
    public class GetAllGamesUseCase : IRequestHandler<GetAllGamesQuery, GetAllGamesResponse>
    {
        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// <see cref="IGamesRepository"/>.
        /// </summary>
        private readonly IGamesRepository _gamesRepository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetAllGamesUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        public GetAllGamesUseCase(IMapper mapper, IGamesRepository gamesRepository)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
        }

        /// <inheritdoc />
        public async Task<GetAllGamesResponse> Handle(GetAllGamesQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGames = await _gamesRepository.GetAllAsync().ConfigureAwait(false);

            var games = _mapper.Map<List<Game>>(entityGames);

            return new GetAllGamesResponse { Games = games };
        }
    }
}