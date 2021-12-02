using System.Threading.Tasks;

namespace ChillGames.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models.Entities;
    using StoreContext;

    /// <summary>
    /// Абстрактный репозиторий.
    /// </summary>
    public abstract class AbstractStoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityWithId, new()
    {
        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Контекст магазина.
        /// </summary>
        protected readonly StoreDbContext StoreDbContext;

        /// <summary>
        /// Инициализирует <see cref="AbstractStoreRepository{TEntity}"/>.
        /// </summary>
        /// <param name="storeDbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        protected AbstractStoreRepository(StoreDbContext storeDbContext, IMapper mapper)
        {
            StoreDbContext = storeDbContext;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Получает или задает набор данных для типа <see cref="TEntity"/>.
        /// </summary>
        protected DbSet<TEntity> EntityDbSet => StoreDbContext.Set<TEntity>();

        /// <inheritdoc />
        public virtual async Task<TEntity> GetByIdAsync(long id) => await EntityDbSet.FirstAsync(f => f.Id == id);

        /// <inheritdoc />
        public virtual async Task<ICollection<TEntity>> GetByIdsAsync(IEnumerable<long> ids) => await EntityDbSet.Where(w => ids.Contains(w.Id)).ToListAsync();

        /// <inheritdoc />
        public virtual async Task<ICollection<TEntity>> GetAllAsync() => await EntityDbSet.ToListAsync();


        /// <inheritdoc />
        public virtual async Task<long> AddAsync(TEntity entity)
        {
            await EntityDbSet.AddAsync(entity).ConfigureAwait(false);
            return entity.Id;
        }

        /// <inheritdoc />
        public virtual async Task UpdateAsync(TEntity entity)
        {
            var existingEntity = await EntityDbSet.FirstAsync(f => f.Id == entity.Id).ConfigureAwait(false);

            if (existingEntity == null)
            {
                await EntityDbSet.AddAsync(entity).ConfigureAwait(false);
            }
            else
            {
                _mapper.Map(entity, existingEntity);
                EntityDbSet.Update(existingEntity);
            }
        }

        /// <inheritdoc />
        public virtual async Task DeleteByIdAsync(long id)
        {
            await Task.Run(() =>
            {
                var entity = AttachEntityWithId(id);
                Delete(entity);
            });
        }

        /// <summary>
        /// Сохраняет изменения в базе данных.
        /// </summary>
        public virtual async Task<int> SaveChangesAsync()
        {
            return await StoreDbContext.SaveChanges();
        }

        /// <summary>
        /// Удаляет сущность из базы данных.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        protected void Delete(TEntity entity) => StoreDbContext.Entry(entity).State = EntityState.Deleted;

        /// <summary>
        /// Начинает отслеживание сущности <see cref="TEntity"/> с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        /// <returns>Экземпляр <see cref="TEntity"/>.</returns>
        protected TEntity AttachEntityWithId(long id)
        {
            var entity = new TEntity { Id = id };
            StoreDbContext.Attach(entity);
            return entity;
        }
    }
}