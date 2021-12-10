namespace ChillGames.UseCases.Users.GetUserInfo
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.Common.Extensions;
    using Models.Entities.Users;
    using Models.Users;
    using UseCases.Common.Exceptions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetUserInfoUseCase : IRequestHandler<GetUserInfoQuery, GetUserInfoResponse>
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
        /// Инициализирует экземпляр <see cref="GetUserInfoUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GetUserInfoUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<GetUserInfoResponse> Handle(GetUserInfoQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var entityUser = await _dbContext.GetDbSet<EntityUser>()
                .FirstOrDefaultAsync(f => f.Id == query.Id.ToLong(), cancellationToken).ConfigureAwait(false);

            if (entityUser == null)
                throw new UseCaseException("Пользователь не найден!");

            var userInfo = _mapper.Map<UserInfo>(entityUser);

            return new GetUserInfoResponse { UserInfo = userInfo };
        }
    }
}