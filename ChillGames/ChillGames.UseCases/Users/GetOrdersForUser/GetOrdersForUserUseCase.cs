namespace ChillGames.UseCases.Users.GetOrdersForUser
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
    using Models.Entities.Orders;
    using Models.Orders;
    using UseCases.Common.Exceptions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetOrdersForUserUseCase : IRequestHandler<GetOrdersForUserQuery, GetOrdersForUserResponse>
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
        /// Инициализирует экземпляр <see cref="GetOrdersForUserUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetOrdersForUserUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        /// <inheritdoc />
        public async Task<GetOrdersForUserResponse> Handle(GetOrdersForUserQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityOrders = await _dbContext.GetDbSet<EntityOrder>()
                .Include(i => i.OrderPositions)
                .Where(w => w.EntityUserId == query.Id.ToLong())
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            if (entityOrders.IsNullOrEmpty())
                throw new UseCaseException("Заказы пользователя не найдены!");
            
            entityOrders.Sort((left, right) =>
            {
                if (left.OrderDate == right.OrderDate)
                    return 0;
                
                if (left.OrderDate > right.OrderDate)
                    return -1;

                return 1;

            });

            var orders = _mapper.Map<List<Order>>(entityOrders);

            return new GetOrdersForUserResponse { Orders = orders};
        }
    }
}