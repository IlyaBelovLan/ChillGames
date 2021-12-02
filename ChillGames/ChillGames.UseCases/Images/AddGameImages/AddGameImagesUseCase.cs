namespace ChillGames.UseCases.Images.AddGameImages
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories.ImagesRepositories;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Entities.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameImagesUseCase : IRequestHandler<AddGameImagesCommand, Unit>
    {
        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// <see cref="IGameImagesRepository"/>.
        /// </summary>
        private readonly IGameImagesRepository _gameImagesRepository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameImagesUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="gameImagesRepository"><see cref="IGameImagesRepository"/>.</param>
        public AddGameImagesUseCase(IMapper mapper, IGameImagesRepository gameImagesRepository)
        {
            _mapper = mapper;
            _gameImagesRepository = gameImagesRepository;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(AddGameImagesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var images = _mapper.Map<List<EntityGameImage>>(command);

            foreach (var image in images)
            {
                await _gameImagesRepository.AddAsync(image).ConfigureAwait(false);
            }

            await _gameImagesRepository.SaveChangesAsync().ConfigureAwait(false);
            
            return Unit.Value;
        }
    }
}