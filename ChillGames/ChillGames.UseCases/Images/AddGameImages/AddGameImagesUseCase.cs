namespace ChillGames.UseCases.Images.AddGameImages
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Entities.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameImagesUseCase : IRequestHandler<AddGameImagesCommand>
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
        /// Инициализирует экземпляр <see cref="AddGameImagesUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public AddGameImagesUseCase(IMapper mapper, StoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(AddGameImagesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityGameImages = _mapper.Map<List<EntityGameImage>>(command);

            await _dbContext.CreateRangeAsync(entityGameImages, cancellationToken).ConfigureAwait(false);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            
            return Unit.Value;
        }
    }
}