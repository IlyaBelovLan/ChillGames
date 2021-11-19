namespace ChillGames.Data.UnitsOfWork
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.Entities;
    using Models.Entities.Games;
    using Models.Entities.Tags;
    using Repositories.GamesRepositories;
    using Repositories.TagsRepository;

    /// <summary>
    /// Единица работы с играми.
    /// </summary>
    public class GamesUow : IUnitOfWork
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GamesUow"/>.
        /// </summary>
        /// <param name="gamesRepository"><see cref="IGamesRepository"/>.</param>
        /// <param name="tagsRepository"><see cref="ITagsRepository"/>.</param>
        public GamesUow(IGamesRepository gamesRepository, ITagsRepository tagsRepository)
        {
            GamesRepository = gamesRepository;
            TagsRepository = tagsRepository;
        }
        
        /// <summary>
        /// Получает репозиторий игр.
        /// </summary>
        public IGamesRepository GamesRepository { get; }

        /// <summary>
        /// Получает репозиторий тегов.
        /// </summary>
        public ITagsRepository TagsRepository { get; }

        /// <summary>
        /// Добавляет игру с учетом уникальности связанных сущностей.
        /// </summary>
        /// <param name="game"><see cref="EntityGame"/>.</param>
        public async Task AddGameWithTags(EntityGame game)
        {
            var existingTags = await TagsRepository.GetAllAsync().ConfigureAwait(false);

            ReplaceRepeatedTags(game, existingTags);

            await GamesRepository.AddAsync(game);
        }

        /// <summary>
        /// Заменяет теги в <see cref="EntityGame"/> аналогичными тегами из <see cref="ICollection{EntityTag}"/>
        /// </summary>
        /// <param name="entityGame">Игра.</param>
        /// <param name="actualTags">Список тегов.</param>
        private static void ReplaceRepeatedTags(EntityGame entityGame, ICollection<EntityTag> actualTags)
        {
            var gameTags = entityGame.Tags.ToList();
            var entityTagComparer = new EntityTagComparer(); 

            var intersectTags = actualTags.Intersect(gameTags, entityTagComparer).ToList();

            var exceptTags = gameTags.Except(intersectTags, entityTagComparer).ToList();

            var unionTags = intersectTags.Union(exceptTags).ToList();

            entityGame.Tags = unionTags;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await GamesRepository.SaveChangesAsync();
        }
    }
 }