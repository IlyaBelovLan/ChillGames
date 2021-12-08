namespace ChillGames.UseCases.Images.GetGameImagesById
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameImagesByIdUseCase : IRequestHandler<GetGameImagesByIdQuery, GetGameImagesByIdResponse>
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
        /// Инициализирует экземпляр <see cref="GetGameImagesByIdUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetGameImagesByIdUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetGameImagesByIdResponse> Handle(GetGameImagesByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGame = await _dbContext.Games
                .Include(i => i.GameImages)
                .FirstOrDefaultAsync(f => f.Id == query.Id.ToLong(), cancellationToken).ConfigureAwait(false);

            var entityGameImages = entityGame.GameImages;

            var gameImages = _mapper.Map<List<GameImage>>(entityGameImages);

            return new GetGameImagesByIdResponse { Images = gameImages };
        }
    }
}