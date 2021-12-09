namespace ChillGames.Data.StoreContext
{
    using Microsoft.EntityFrameworkCore;
    using Models.Entities;
    using Models.Entities.Games;
    using Models.Entities.Orders;
    using Models.Entities.Tags;
    using Models.Entities.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Models.Common;
    using Models.Entities.Images;
    using Models.Entities.Translations;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    
    /// <summary>
    /// Контекст базы данных магазина.
    /// </summary>
    public class StoreDbContext : DbContext, IStoreDbContext
    {
        /// <summary>
        /// <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;
        
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

        /// <inheritdoc />
        public StoreDbContext(DbContextOptions<StoreDbContext> options, IMapper mapper) : base(options)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Получает или задает набор данных для типа <see cref="TEntity"/>.
        /// </summary>
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class => Set<TEntity>();

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                        j.HasKey(h => new { h.EntityGameId, h.EntityOrderId });
                        j.ToTable("OrderPositions");
                    }
                );

            modelBuilder
                .Entity<EntityUser>()
                .HasMany(h => h.WishListGames)
                .WithMany(w => w.InterestedUsers)
                .UsingEntity(u => u.ToTable("GamesByWishLists"));

            modelBuilder
                .Entity<EntityUser>()
                .HasMany(h => h.Orders)
                .WithOne(w => w.PaidUser);

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

        /// <summary>
        /// Добавляет сущность.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        public async Task<long> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntityWithId
        {
            await GetDbSet<TEntity>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }
        
        /// <summary>
        /// Добавляет сущности из списка.
        /// </summary>
        /// <param name="entityList">Экземпляр <see cref="IReadOnlyCollection{TEntity}"/>.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        public async Task CreateRangeAsync<TEntity>(IReadOnlyCollection<TEntity> entityList, CancellationToken cancellationToken = default) 
            where TEntity : class, IEntityWithId =>
            await GetDbSet<TEntity>().AddRangeAsync(entityList, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Обновляет сущность.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        public async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)  where TEntity : class, IEntityWithId
        {
            var dbSet = GetDbSet<TEntity>();
            
            var existingEntity = await dbSet.FirstAsync(f => f.Id == entity.Id, cancellationToken).ConfigureAwait(false);

            if (existingEntity == null)
            {
                await dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _mapper.Map(entity, existingEntity);
                dbSet.Update(existingEntity);
            }
        }

        /// <summary>
        /// Удаляет сущность с указанным идентификатором. 
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        public async Task DeleteAsync<TEntity>(long id, CancellationToken cancellationToken = default)
            where TEntity : IEntityWithId, new()
        {
            await Task.Run(() =>
            {
                var entity = AttachEntityWithId<TEntity>(id); 
                Delete(entity);
            },
                cancellationToken);
        }
        
        /// <summary>
        /// Удаляет сущность из базы данных.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        private void Delete<TEntity>(TEntity entity) => Entry(entity).State = EntityState.Deleted;
        
        /// <summary>
        /// Начинает отслеживание сущности <see cref="TEntity"/> с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        /// <returns>Экземпляр <see cref="TEntity"/>.</returns>
        private TEntity AttachEntityWithId<TEntity>(long id) 
            where TEntity : IEntityWithId, new()
        {
            var entity = new TEntity { Id = id };
            Attach(entity);
            return entity;
        }
    }
}
