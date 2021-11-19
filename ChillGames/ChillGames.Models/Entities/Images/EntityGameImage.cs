using System.ComponentModel.DataAnnotations.Schema;
using ChillGames.Models.Common;
using ChillGames.Models.Entities.Games;

namespace ChillGames.Models.Entities.Images
{
    /// <summary>
    /// Изображение, связанное с игрой.
    /// </summary>
    [EntityModel]
    [Table("GamesImages")]
    public class EntityGameImage : IImage
    {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <inheritdoc />
        public string ImageCode { get; set; }

        /// <summary>
        /// Получает или задет флаг изображения-обложки.
        /// </summary>
        public bool IsPreview { get; set; }

        /// <summary>
        /// Получает или задает порядок изображения в списке скриншотов.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public long EntityGameId { get; set; }

        /// <summary>
        /// Получает или задает игру.
        /// </summary>
        public EntityGame Game { get; set; }
    }
}
