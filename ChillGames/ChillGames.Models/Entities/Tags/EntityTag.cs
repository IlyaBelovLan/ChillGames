using System.Collections;
using System.Collections.Generic;
using ChillGames.Models.Entities.Games;

namespace ChillGames.Models.Entities.Tags
{
    using Common;

    /// <summary>
    /// Тег.
    /// </summary>
    [EntityModel]
    public class EntityTag : IEntityWithId
    {
        /// <inheritdoc />
        public long Id { get; set; }
        
        /// <summary>
        /// Название тега.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает список игр.
        /// </summary>
        public ICollection<EntityGame> Games { get; set; } = new List<EntityGame>();
    }
}