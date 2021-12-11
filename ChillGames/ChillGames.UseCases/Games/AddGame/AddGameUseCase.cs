namespace ChillGames.UseCases.Games.AddGame
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameUseCase : IRequestHandler<AddGameCommand, AddGameResponse>
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public AddGameUseCase(IMapper mapper, StoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        /// <inheritdoc />
        public async Task<AddGameResponse> Handle(AddGameCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityGame = _mapper.Map<EntityGame>(command);
            
            var existingTags = await _dbContext.Tags.ToListAsync(cancellationToken).ConfigureAwait(false);

            entityGame.ReplaceRepeatedTags(existingTags);

            await _dbContext.CreateAsync(entityGame, cancellationToken).ConfigureAwait(false);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return new AddGameResponse { Id = entityGame.Id.ToString() };
        }
    }
}