﻿namespace ChillGames.Models.Entities.Games
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using Tags;
    using Translation;

    /// <summary>
    /// Сущность игры из базы данных.
    /// </summary>
    [EntityModel]
    public class EntityGame
    {
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public long EntityGameID { get; set; }
        
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
        public IReadOnlyCollection<Platform> Platforms { get; set; }
        
        /// <summary>
        /// Получает или задает лаунчеры, для которых доступна игра.
        /// </summary>
        public IReadOnlyCollection<Launcher> Launchers { get; set; }

        /// <summary>
        /// Получает или задает жанр игры.
        /// </summary>
        public string Genre { get; set; }
        
        /// <summary>
        /// Получает или задает издателя игры.
        /// </summary>
        public string Publisher { get; set; }
        
        /// <summary>
        /// Получает или задает список доступных языков и тип перевода на каждый их них.
        /// </summary>
        public IReadOnlyCollection<EntityGameTranslation> Translations { get; set; }
        
        /// <summary>
        /// Получает или задает дату выхода игры.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        
        /// <summary>
        /// Получает или задает теги игры.
        /// </summary>
        public IReadOnlyCollection<EntityTagging> Tags { get; set; }

        /// <summary>
        /// Получает или задает количество оставшихся ключей.
        /// </summary>
        public int Count { get; set; }
    }
}