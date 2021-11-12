namespace ChillGames.UseCases.AddGame
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories.GamesRepositories;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Entities.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameUseCase : IRequestHandler<AddGameCommand, AddGameResponse>
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
        /// Инициализирует экземпляр <see cref="AddGameUseCase"/>.
        /// </summary>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public AddGameUseCase(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }


        /// <inheritdoc />
        public async Task<AddGameResponse> Handle(AddGameCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var game = _mapper.Map<EntityGame>(command);

            await _gamesRepository.Add(game);

            return new AddGameResponse { Id = game.Id.ToString() };
        }
    }
}