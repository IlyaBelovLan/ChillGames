namespace ChillGames.Data.Repositories
{
    using StoreContext;

    /// <summary>
    /// Абстрактный репозиторий.
    /// </summary>
    public abstract class AbstractStoreRepository
    {
        /// <summary>
        /// Контекст магазина.
        /// </summary>
        protected readonly StoreContext StoreContext;

        /// <summary>
        /// Инициализирует <see cref="AbstractStoreRepository"/>.
        /// </summary>
        /// <param name="storeContext"><see cref="Data.StoreContext.StoreContext"/>.</param>
        protected AbstractStoreRepository(StoreContext storeContext)
        {
            StoreContext = storeContext;
        }
        
        /// <summary>
        /// Сохраняет изменения в базе данных.
        /// </summary>
        public virtual void SaveChanges()
        {
            StoreContext.SaveChanges();
        }
    }
}