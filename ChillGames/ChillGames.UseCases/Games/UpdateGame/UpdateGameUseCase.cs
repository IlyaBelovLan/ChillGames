namespace ChillGames.UseCases.Games.UpdateGame
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Exceptions;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameUseCase : IRequestHandler<UpdateGameCommand, Unit>
    {
        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UpdateGameUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public UpdateGameUseCase(IMapper mapper, StoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityGame = await _dbContext.Games.FirstOrDefaultAsync(f => f.Id == command.Id.ToLong(), cancellationToken).ConfigureAwait(false);

            if (entityGame == null)
                throw new UseCaseException("Игра не найдена!");
            
            _mapper.Map(command, entityGame);

            await _dbContext.UpdateAsync(entityGame, cancellationToken).ConfigureAwait(false);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}