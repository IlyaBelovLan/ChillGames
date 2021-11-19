namespace ChillGames.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Интерфейс репозитория для доступа к сущностям типа <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Возвращает сущность по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Экземпляр <see cref="TEntity"/>.</returns>
        Task<TEntity> GetByIdAsync(long id);

        /// <summary>
        /// Возвращает сущности с заданными идентификаторами.
        /// </summary>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Список экземпляров <see cref="TEntity"/>.</returns>
        Task<ICollection<TEntity>> GetByIdsAsync(IEnumerable<long> ids);

        /// <summary>
        /// Возвращает все сущности.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Добавляет сущность.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        Task<long> AddAsync(TEntity entity);

        /// <summary>
        /// Обновляет сущность.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Удаляет сущность с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        Task DeleteByIdAsync(long id);

        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
