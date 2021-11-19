using System.Threading.Tasks;

namespace ChillGames.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Models.Entities;
    using StoreContext;

    /// <summary>
    /// Абстрактный репозиторий.
    /// </summary>
    public abstract class AbstractStoreRepository
    {
        /// <summary>
        /// Контекст магазина.
        /// </summary>
        protected readonly StoreDbContext StoreDbContext;

        /// <summary>
        /// Инициализирует <see cref="AbstractStoreRepository"/>.
        /// </summary>
        /// <param name="storeDbContext"><see cref="StoreDbContext"/>.</param>
        protected AbstractStoreRepository(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
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
        protected void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            StoreDbContext.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Начинает отслеживание сущности <see cref="TEntity"/> с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        /// <returns>Экземпляр <see cref="TEntity"/>.</returns>
        protected TEntity AttachEntityWithId<TEntity>(long id) 
            where TEntity : IEntityWithId, new()
        {
            var entity = new TEntity { Id = id };
            StoreDbContext.Attach(entity);
            return entity;
        }
    }
}