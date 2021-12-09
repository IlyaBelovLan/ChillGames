namespace ChillGames.UseCases.Users.AddUser
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.StoreContext;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Entities.Users;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddUserUseCase : IRequestHandler<AddUserCommand, AddUserResponse>
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
        /// Инициализирует экземпляр <see cref="AddUserUseCase"/>.
        /// </summary>
        /// <param name="dbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public AddUserUseCase(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<AddUserResponse> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var entityUser = _mapper.Map<EntityUser>(command);

            await _dbContext.CreateAsync(entityUser, cancellationToken).ConfigureAwait(false);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return new AddUserResponse { Id = entityUser.Id.ToString() };
        }
    }
}