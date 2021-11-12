

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ChillGames.Data.Repositories.GamesRepositories;
using ChillGames.Data.StoreContext;
using ChillGames.Models.Games;
using ChillGames.UseCases.Common.Extensions;
using JetBrains.Annotations;
using MediatR;

namespace ChillGames.UseCases.GetGameById
{


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
            
            var entityGame = await _gamesRepository.GetById(query.Id.ToLong());
            
            var game = _mapper.Map<Game>(entityGame);

            return new GetGameByIdResponse { Game = game };
        }
    }
}