namespace ChillGames.UseCases.Users.AddOrderToUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Games;
    using Models.Entities.Orders;
    using Models.Entities.Users;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddOrderToUserUseCase : IRequestHandler<AddOrderToUserCommand, AddOrderToUserResponse>
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
        /// Инициализирует экземпляр <see cref="AddOrderToUserUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public AddOrderToUserUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<AddOrderToUserResponse> Handle(AddOrderToUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var games = await _dbContext.GetDbSet<EntityGame>()
                .Where(w => command.OrderPositionInfos.Select(s => s.GameId.ToLong()).Contains(w.Id))
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            for(int i = 0; i < games.Count; i++)
            {
                command.OrderPositionInfos[i].EntityGame = games[i];
            }

            var orderPositions = _mapper.Map<List<EntityOrderPosition>>(command.OrderPositionInfos);

            var order = _mapper.Map<EntityOrder>(orderPositions);
            order.EntityUserId = command.UserId.ToLong();
            
            var user = await _dbContext.GetDbSet<EntityUser>()
                .FirstOrDefaultAsync(f => f.Id == command.UserId.ToLong(), cancellationToken).ConfigureAwait(false);

            user.Orders.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return new AddOrderToUserResponse { Id = order.Id.ToString() };
        }
    }
}