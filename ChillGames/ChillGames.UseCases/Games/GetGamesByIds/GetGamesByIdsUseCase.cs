namespace ChillGames.UseCases.Games.GetGamesByIds
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Extensions;
    using Data.Repositories.GamesRepositories;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamesByIdsUseCase : IRequestHandler<GetGamesByIdsQuery, GetGamesByIdsResponse>
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
        /// Инициализирует экземпляр <see cref="GetGamesByIdsUseCase"/>.
        /// </summary>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetGamesByIdsUseCase(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetGamesByIdsResponse> Handle(GetGamesByIdsQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGames = await _gamesRepository.GetByIdsAsync(query.Ids.ToLongs()).ConfigureAwait(false);

            var games = _mapper.Map<List<Game>>(entityGames);

            return new GetGamesByIdsResponse { Games = games };
        }
    }
}