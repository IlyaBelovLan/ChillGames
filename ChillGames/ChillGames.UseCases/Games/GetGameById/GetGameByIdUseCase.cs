namespace ChillGames.UseCases.Games.GetGameById
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Exceptions;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameByIdUseCase : IRequestHandler<GetGameByIdQuery, GetGameByIdResponse>
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
        /// Инициализирует экземпляр <see cref="GetGameByIdUseCase"/>.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        public GetGameByIdUseCase(IMapper mapper, StoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        /// <inheritdoc />
        public async Task<GetGameByIdResponse> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityGame = await _dbContext.Games
                .Where(w => w.Id == query.Id.ToLong())
                .Include(i => i.Tags)
                .Include(i => i.Translations)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            if (entityGame == null)
                throw new UseCaseException("Игра не найдена!");
            
            var game = _mapper.Map<Game>(entityGame);

            return new GetGameByIdResponse { Game = game };
        }
    }
}