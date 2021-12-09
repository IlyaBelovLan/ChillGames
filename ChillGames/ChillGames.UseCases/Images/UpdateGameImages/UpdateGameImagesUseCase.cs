namespace ChillGames.UseCases.Images.UpdateGameImages
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using UseCases.Common.Exceptions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameImagesUseCase : IRequestHandler<UpdateGameImagesCommand>
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        public UpdateGameImagesUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateGameImagesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var imageIds = command.Images.Select(s => s.Id.ToLong()).ToList();
            
            foreach (var imageId in imageIds)
            {
                var image = await _dbContext.GamesImages
                    .FirstOrDefaultAsync(f => f.Id == imageId && f.EntityGameId == command.GameId.ToLong(), cancellationToken)
                    .ConfigureAwait(false);

                if (image == null)
                    throw new UseCaseException("Изображение не найдено!");
            }

            var entityGameImages = await _dbContext.GamesImages
                .Where(w => w.EntityGameId == command.GameId.ToLong())
                .Where(w => imageIds.Contains(w.Id))
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            _mapper.Map(command.Images, entityGameImages);

            foreach (var entityGameImage in entityGameImages)
            {
                await _dbContext.UpdateAsync(entityGameImage, cancellationToken).ConfigureAwait(false);
            }

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            
            return Unit.Value;
        }
    }
}