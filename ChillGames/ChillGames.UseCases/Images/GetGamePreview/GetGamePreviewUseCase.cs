namespace ChillGames.UseCases.Images.GetGamePreview
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamePreviewUseCase : IRequestHandler<GetGamePreviewQuery, GetGamePreviewResponse>
    {
        /// <summary>
        /// <see cref="StoreDbContext"/>.
        /// </summary>
        private readonly StoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGamePreviewUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public GetGamePreviewUseCase(StoreDbContext dbContext) => _dbContext = dbContext;

        /// <inheritdoc />
        public async Task<GetGamePreviewResponse> Handle(GetGamePreviewQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var gameImage = await _dbContext.GamesImages
                .FirstOrDefaultAsync(w => w.IsPreview && w.EntityGameId == query.Id.ToLong(), cancellationToken).ConfigureAwait(false);

            return new GetGamePreviewResponse { ImageCode = gameImage.ImageCode };
        }
    }
}