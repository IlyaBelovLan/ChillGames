namespace ChillGames.UseCases.Images.GetGameImagesById
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories.GamesRepositories;
    using Data.Repositories.ImagesRepositories;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Common.Extensions;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameImagesByIdUseCase : IRequestHandler<GetGameImagesByIdQuery, GetGameImagesByIdResponse>
    {
        /// <summary>
        /// <see cref="IGameImagesRepository"/>.
        /// </summary>
        private readonly IGamesRepository _gamesRepository;

        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGameImagesByIdUseCase"/>.
        /// </summary>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetGameImagesByIdUseCase(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetGameImagesByIdResponse> Handle(GetGameImagesByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGame = await _gamesRepository.GetByIdAsync(query.Id.ToLong()).ConfigureAwait(false);

            var entityGameImages = entityGame.GameImages;

            var gameImages = _mapper.Map<List<GameImage>>(entityGameImages);

            return new GetGameImagesByIdResponse { Images = gameImages };
        }
    }
}