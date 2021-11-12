using System.Threading.Tasks;
using ChillGames.Models.Entities.Games;
using ChillGames.Models.Entities.Images;
using ChillGames.Models.Entities.Orders;
using ChillGames.Models.Entities.Tags;
using ChillGames.Models.Entities.Translations;
using ChillGames.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace ChillGames.Data.StoreContext
{
    public interface IStoreDbContext
    {
        /// <summary>
        /// Получает или задает таблицу игр.
        /// </summary>
        public DbSet<EntityGame> Games { get; set; }

        /// <summary>
        /// Получает или задает таблицу тегов для игр.
        /// </summary>
        public DbSet<EntityTag> Tags { get; set; }

        /// <summary>
        /// Получает или задает таблицу возможных переводов.
        /// </summary>
        public DbSet<EntityTranslation> Translations { get; set; }

        /// <summary>
        /// Получает или задает таблицу пользователей.
        /// </summary>
        public DbSet<EntityUser> Users { get; set; }

        /// <summary>
        /// Получает или задеет таблицу заказов.
        /// </summary>
        public DbSet<EntityOrder> Orders { get; set; }

        /// <summary>
        /// Получает или задает  таблицу изображений для игр.
        /// </summary>
        public DbSet<EntityGameImage> GamesImages { get; set; }

        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        public Task<int> SaveChanges();
    }
}
