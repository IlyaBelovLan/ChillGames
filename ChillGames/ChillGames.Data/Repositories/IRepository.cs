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
        Task<TEntity> GetById(long id);

        /// <summary>
        /// Возвращает сущности с заданными идентификаторами.
        /// </summary>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Список экземпляров <see cref="TEntity"/>.</returns>
        Task<ICollection<TEntity>> GetByIds(IReadOnlyCollection<long> ids);

        /// <summary>
        /// Добавляет сущность.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        Task<long> Add(TEntity entity);

        /// <summary>
        /// Обновляет сущность.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        Task Update(TEntity entity);

        /// <summary>
        /// Удаляет сущность с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        Task DeleteById(long id);

        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        Task<int> SaveChanges();
    }
}
