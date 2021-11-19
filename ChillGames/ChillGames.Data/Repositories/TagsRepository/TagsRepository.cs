namespace ChillGames.Data.Repositories.TagsRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models.Entities.Tags;
    using StoreContext;

    /// <summary>
    /// Репозиторий работы с тегами.
    /// </summary>
    public class TagsRepository : AbstractStoreRepository, ITagsRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="TagsRepository"/>.
        /// </summary>
        /// <param name="storeDbContext"></param>
        public TagsRepository(StoreDbContext storeDbContext) : base(storeDbContext) {}

        /// <inheritdoc />
        public async Task<EntityTag> GetByIdAsync(long id)
        {
            return await StoreDbContext.Tags.FindAsync(id).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<ICollection<EntityTag>> GetByIdsAsync(IEnumerable<long> ids)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<ICollection<EntityTag>> GetAllAsync()
        {
            var tags = await StoreDbContext.Tags.ToListAsync();
            return tags;
        }

        /// <inheritdoc />
        public Task<long> AddAsync(EntityTag entity)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public Task UpdateAsync(EntityTag entity)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public Task DeleteByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}