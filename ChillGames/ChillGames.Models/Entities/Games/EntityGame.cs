using ChillGames.Models.Entities.Images;
using ChillGames.Models.Entities.Orders;
using ChillGames.Models.Entities.Translations;

namespace ChillGames.Models.Entities.Games
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Tags;

    /// <summary>
    /// Сущность игры из базы данных.
    /// </summary>
    [EntityModel]
    public class EntityGame : IEntityWithId
    {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <summary>
        /// Получает или задает название игры.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получает или задает описание игры.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Получает или задает цену игры.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Получает или задает скидку на игру.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Получает или задает платформы, на которых доступна игра.
        /// </summary>
        public ICollection<Platform> Platforms { get; set; } = new List<Platform>();

        /// <summary>
        /// Получает или задает лаунчеры, для которых доступна игра.
        /// </summary>
        public ICollection<Launcher> Launchers { get; set; } = new List<Launcher>();

        /// <summary>
        /// Получает или задает жанр игры.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Получает или задает издателя игры.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Получает или задает дату выхода игры.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Получает или задает количество оставшихся ключей.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Получает или задает теги игры.
        /// </summary>
        public ICollection<EntityTag> Tags { get; set; } = new List<EntityTag>();

        /// <summary>
        /// Получает или задает список позиций заказа.
        /// </summary>
        public ICollection<EntityOrderPosition> OrderPositions { get; set; } = new List<EntityOrderPosition>();

        /// <summary>
        /// Получает или задает список игр в заказе.
        /// </summary>
        public ICollection<EntityOrder> Orders { get; set; } = new List<EntityOrder>();

        /// <summary>
        /// Получает или задает список доступных языков и тип перевода на каждый их них.
        /// </summary>
        public ICollection<EntityTranslation> Translations { get; set; } = new List<EntityTranslation>();

        /// <summary>
        /// Получает или задет список изображений игры.
        /// </summary>
        public ICollection<EntityGameImage> GameImages { get; set; } = new List<EntityGameImage>();
    }
}