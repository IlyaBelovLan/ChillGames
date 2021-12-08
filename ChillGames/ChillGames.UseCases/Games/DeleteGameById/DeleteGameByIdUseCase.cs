namespace ChillGames.UseCases.Games.DeleteGameById
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Common.Extensions;
    using Models.Entities.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class DeleteGameByIdUseCase : IRequestHandler<DeleteGameByIdCommand>
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="DeleteGameByIdUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public DeleteGameByIdUseCase(StoreDbContext dbContext) => _dbContext = dbContext;

        /// <inheritdoc />
        public async Task<Unit> Handle(DeleteGameByIdCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            await _dbContext.DeleteAsync<EntityGame>(command.Id.ToLong(), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}