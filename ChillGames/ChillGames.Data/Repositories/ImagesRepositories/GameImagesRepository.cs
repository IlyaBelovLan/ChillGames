namespace ChillGames.Data.Repositories.ImagesRepositories
{
    using AutoMapper;
    using Models.Entities.Images;
    using StoreContext;

    /// <summary>
    /// Репозиторий для работы с игровыми изображениями.
    /// </summary>
    public class GameImagesRepository : AbstractStoreRepository<EntityGameImage>, IGameImagesRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameImagesRepository"/>.
        /// </summary>
        /// <param name="storeDbContext"><see cref="StoreDbContext"/>.</param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public GameImagesRepository(StoreDbContext storeDbContext, IMapper mapper) : base(storeDbContext, mapper)
        {
        }
    }
}