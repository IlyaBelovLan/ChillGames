using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChillGames.Models.Common;
using ChillGames.Models.Entities.Images;
using ChillGames.Models.Entities.Translations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ChillGames.Data.StoreContext
{
    using Microsoft.EntityFrameworkCore;
    using Models.Entities.Games;
    using Models.Entities.Orders;
    using Models.Entities.Tags;
    using Models.Entities.Users;

    /// <summary>
    /// Контекст базы данных магазина.
    /// </summary>
    public class StoreDbContext : DbContext, IStoreDbContext
    {
        /// <inheritdoc />
        public DbSet<EntityGame> Games { get; set; }

        /// <inheritdoc />
        public DbSet<EntityTag> Tags { get; set; }

        /// <inheritdoc />
        public DbSet<EntityTranslation> Translations { get; set; }

        /// <inheritdoc />
        public DbSet<EntityUser> Users { get; set; }

        /// <inheritdoc />
        public DbSet<EntityOrder> Orders { get; set; }

        /// <inheritdoc />
        public DbSet<EntityGameImage> GamesImages { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        /// <inheritdoc />
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        { }


        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityGame>().ToTable("Games");
            modelBuilder.Entity<EntityTag>().ToTable("Tags");
            modelBuilder.Entity<EntityTranslation>().ToTable("Translations");
            modelBuilder.Entity<EntityUser>().ToTable("Users");
            modelBuilder.Entity<EntityOrder>().ToTable("Orders");
            modelBuilder.Entity<EntityGameImage>().ToTable("GamesImages");
            modelBuilder.Entity<EntityUserImage>().ToTable("UserImages");

            modelBuilder
                .Entity<EntityGame>()
                .HasMany(h => h.Tags)
                .WithMany(w => w.Games)
                .UsingEntity(u => u.ToTable("Tagging"));

            modelBuilder
                .Entity<EntityGame>()
                .HasMany(h => h.Translations)
                .WithMany(w => w.Games)
                .UsingEntity(u => u.ToTable("GamesTranslations"));

            modelBuilder
                .Entity<EntityOrder>()
                .HasMany(h => h.Games)
                .WithMany(w => w.Orders)
                .UsingEntity<EntityOrderPosition>(
                    j => j
                        .HasOne(pt => pt.Game)
                        .WithMany(p => p.OrderPositions)
                        .HasForeignKey(pt => pt.EntityGameId),
                    j => j
                        .HasOne(pt => pt.Order)
                        .WithMany(p => p.OrderPositions)
                        .HasForeignKey(pt => pt.EntityOrderId),
                    j =>
                    {
                        j.HasKey(h => new {h.EntityGameId, h.EntityOrderId});
                        j.ToTable("OrderPositions");
                    }
                );

            modelBuilder
                .Entity<EntityGame>()
                .Property(p => p.Launchers)
                .HasConversion(
                    launchers => string.Join(';', launchers),
                    stringLaunchers => stringLaunchers.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Launcher>).ToList(),
                    new ValueComparer<ICollection<Launcher>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (hash, el) => HashCode.Combine(hash, el.GetHashCode())),
                        c => c.ToList() as ICollection<Launcher>));

            modelBuilder
                .Entity<EntityGame>()
                .Property(p => p.Platforms)
                .HasConversion(platforms => string.Join(';', platforms),
                    stringPlatforms => stringPlatforms.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Platform>).ToList(),
                    new ValueComparer<ICollection<Platform>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (hash, el) => HashCode.Combine(hash, el.GetHashCode())),
                        c => c.ToArray() as ICollection<Platform>));
        }
    }
}
