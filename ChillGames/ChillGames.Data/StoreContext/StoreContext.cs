namespace ChillGames.Data.StoreContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using Models.Common;
    using Models.Entities.Games;
    using Models.Entities.Orders;
    using Models.Entities.Tags;
    using Models.Entities.Translation;
    using Models.Entities.Users;

    /// <summary>
    /// Контекст базы данных магазина.
    /// </summary>
    public class StoreContext : DbContext
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="StoreContext"/>.
        /// </summary>
        /// <param name="options">Параметры контекста.</param>
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }
        
        /// <summary>
        /// Получает или задает таблицу игр.
        /// </summary>
        public DbSet<EntityGame> Games { get; set; }
        
        /// <summary>
        /// Получает или задает таблицу возможных переводов.
        /// </summary>
        public DbSet<EntityTranslation> Translations { get; set; }

        /// <summary>
        /// Получает или задает таблицу актуальных переводов игр.
        /// </summary>
        public DbSet<EntityGameTranslation> GameTranslations { get; set; }
        
        /// <summary>
        /// Получает или задает таблицу тегов для игр.
        /// </summary>
        public DbSet<EntityTag> Tags { get; set; }
        
        /// <summary>
        /// Получает или задает таблицу тегов, присвоенных играм.
        /// </summary>
        public DbSet<EntityTagging> Tagging { get; set; }
        
        /// <summary>
        /// Получает или задает таблицу пользователей.
        /// </summary>
        public DbSet<EntityUser> Users { get; set; }
        
        /// <summary>
        /// Получает или задеет таблицу заказов.
        /// </summary>
        public DbSet<EntityOrder> Orders { get; set; }
        
        /// <summary>
        /// Получает или задает таблицу позициий заказов.
        /// </summary>
        public DbSet<EntityOrderPosition> OrderPositions { get; set; }

        /// <summary>
        /// Настраивает модель базы данных при ее создании.
        /// </summary>
        /// <param name="modelBuilder"><see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var launcherListConverter = new ValueConverter<IReadOnlyCollection<Launcher>, string>(
                launchers => string.Join(';', launchers),
                stringLaunchers => 
                    stringLaunchers.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Launcher>).ToList());
            
            var platformListConverter = new ValueConverter<IReadOnlyCollection<Platform>, string>(
                platforms => string.Join(';', platforms),
                stringPlatforms => 
                    stringPlatforms.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Platform>).ToList());

            modelBuilder.Entity<EntityGame>().ToTable("Games");
            modelBuilder.Entity<EntityTranslation>().ToTable("Translations");
            modelBuilder.Entity<EntityGameTranslation>().ToTable("GameTranslations");
            modelBuilder.Entity<EntityTag>().ToTable("Tags");
            modelBuilder.Entity<EntityTagging>().ToTable("Tagging");
            
            modelBuilder.Entity<EntityUser>().ToTable("Users");
            
            modelBuilder.Entity<EntityOrder>().ToTable("Orders");
            modelBuilder.Entity<EntityOrderPosition>().ToTable("OrderPositions");

            modelBuilder.Entity<EntityGame>()
                .Property(g => g.Launchers)
                .HasConversion(launcherListConverter);

            modelBuilder.Entity<EntityGame>()
                .Property(g => g.Platforms)
                .HasConversion(platformListConverter);
        }
    }
}
