namespace ChillGames.UseCases.Games.AddGame
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories.GamesRepositories;
    using Data.Repositories.TagsRepository;
    using Data.UnitsOfWork;
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
        private readonly GamesUow _gamesUow;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameUseCase"/>.
        /// </summary>
        /// <param name="gamesUow"><see cref="GamesUow"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public AddGameUseCase(GamesUow gamesUow, IMapper mapper)
        {
            _mapper = mapper;
            _gamesUow = gamesUow;
        }


        /// <inheritdoc />
        public async Task<AddGameResponse> Handle(AddGameCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityGame = _mapper.Map<EntityGame>(command);

            await _gamesUow.AddGameWithTags(entityGame);

            await _gamesUow.SaveChangesAsync();

            return new AddGameResponse { Id = entityGame.Id.ToString() };
        }
    }
}