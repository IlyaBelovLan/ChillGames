namespace ChillGames.UseCases.Games.UpdateGame
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories.GamesRepositories;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Common.Extensions;
    using Models.Entities.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameUseCase : IRequestHandler<UpdateGameCommand, Unit>
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
        /// Инициализирует экземпляр <see cref="UpdateGameUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        public UpdateGameUseCase(IMapper mapper, IGamesRepository gamesRepository)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityGame = await _gamesRepository.GetByIdAsync(command.Id.ToLong()).ConfigureAwait(false);

            _mapper.Map(command, entityGame);

            await _gamesRepository.UpdateAsync(entityGame).ConfigureAwait(false);

            await _gamesRepository.SaveChangesAsync().ConfigureAwait(false);

            return Unit.Value;
        }
    }
}