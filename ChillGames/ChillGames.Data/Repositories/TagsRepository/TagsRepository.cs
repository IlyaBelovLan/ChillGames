namespace ChillGames.Data.Repositories.TagsRepository
{
    using AutoMapper;
    using Models.Entities.Tags;
    using StoreContext;

    /// <summary>
    /// Репозиторий работы с тегами.
    /// </summary>
    public class TagsRepository : AbstractStoreRepository<EntityTag>, ITagsRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="TagsRepository"/>.
        /// </summary>
        /// <param name="storeDbContext"></param>
        /// <param name="mapper"><see cref="IMapper"/>.</param>
        public TagsRepository(StoreDbContext storeDbContext, IMapper mapper) : base(storeDbContext, mapper) {}
    }
}