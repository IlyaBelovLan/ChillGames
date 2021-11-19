namespace ChillGames.UseCases.Games.DeleteGameById
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Extensions;
    using Data.Repositories.GamesRepositories;
    using JetBrains.Annotations;
    using MediatR;

    /// <inheritdoc />
    [UsedImplicitly]
    public class DeleteGameByIdUseCase : IRequestHandler<DeleteGameByIdCommand, Unit>
    {
        /// <summary>
        /// <see cref="IGamesRepository"/>.
        /// </summary>
        private readonly IGamesRepository _gamesRepository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="DeleteGameByIdUseCase"/>.
        /// </summary>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        public DeleteGameByIdUseCase(IGamesRepository gamesRepository) => _gamesRepository = gamesRepository;

        /// <inheritdoc />
        public async Task<Unit> Handle(DeleteGameByIdCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            await _gamesRepository.DeleteByIdAsync(command.Id.ToLong());

            await _gamesRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}