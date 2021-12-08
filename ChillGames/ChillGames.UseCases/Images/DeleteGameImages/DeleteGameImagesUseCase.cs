namespace ChillGames.UseCases.Images.DeleteGameImages
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Exceptions;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class DeleteGameImagesUseCase : IRequestHandler<DeleteGameImagesCommand>
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="DeleteGameImagesUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public DeleteGameImagesUseCase(StoreDbContext dbContext) => _dbContext = dbContext;


        /// <inheritdoc />
        public async Task<Unit> Handle(DeleteGameImagesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityGameImages = await _dbContext.GamesImages
                .Where(w => w.EntityGameId == command.GameId.ToLong())
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            if (entityGameImages == null)
                throw new UseCaseException("Изображения не найдены!");

            foreach (var entityGameImage in entityGameImages)
            {
                if (!command.ImageIds.Contains(entityGameImage.Id.ToString()))
                {
                    throw new UseCaseException("Не найдено игровое изображение!");
                }

                _dbContext.GamesImages.Remove(entityGameImage);
            }

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            
            return Unit.Value;
        }
    }
}