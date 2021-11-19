namespace ChillGames.UseCases.Games.GetGameById
{
    using System;
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
    public class GetGameByIdUseCase : IRequestHandler<GetGameByIdQuery, GetGameByIdResponse>
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
        /// Инициализирует экземпляр <see cref="GetGameByIdUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        public GetGameByIdUseCase(IMapper mapper, IGamesRepository gamesRepository)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
        }


        /// <inheritdoc />
        public async Task<GetGameByIdResponse> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            
            var entityGame = await _gamesRepository.GetByIdAsync(query.Id.ToLong());
            
            var game = _mapper.Map<Game>(entityGame);

            return new GetGameByIdResponse { Game = game };
        }
    }
}