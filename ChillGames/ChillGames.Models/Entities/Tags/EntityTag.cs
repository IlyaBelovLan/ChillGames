using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChillGames.Models.Entities.Games;
using Microsoft.EntityFrameworkCore;

namespace ChillGames.Models.Entities.Tags
{
    using Common;

    /// <summary>
    /// Тег.
    /// </summary>
    [EntityModel]
    [Table("Tags")]
    [Index(nameof(Name), IsUnique = true)]
    public class EntityTag : IEntityWithId
    {
        /// <inheritdoc />
        public long Id { get; set; }
        
        /// <summary>
        /// Название тега.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает список игр.
        /// </summary>
        public ICollection<EntityGame> Games { get; set; } = new List<EntityGame>();
    }
}