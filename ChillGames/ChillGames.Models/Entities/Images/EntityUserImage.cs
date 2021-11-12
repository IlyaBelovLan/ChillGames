﻿using ChillGames.Models.Entities.Users;

namespace ChillGames.Models.Entities.Images
{
    /// <summary>
    /// Аватар пользователя.
    /// </summary>
    public class EntityUserImage : IImage
    {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <inheritdoc />
        public string ImageCode { get; set; }

        /// <summary>
        /// Получает или задает идентификатор пользователя.
        /// </summary>
        public long EntityUserId { get; set; }

        ///Получает или задает владельца аватара.
        public EntityUser User { get; set; }
    }
}
