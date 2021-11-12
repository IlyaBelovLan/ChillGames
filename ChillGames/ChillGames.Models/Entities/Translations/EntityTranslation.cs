namespace ChillGames.Models.Entities.Translations
{
    using System.Collections.Generic;
    using Common;
    using Games;

    /// <summary>
    /// Язык и тип перевода игры.
    /// </summary>
    [EntityModel]
    public class EntityTranslation : IEntityWithId
    {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <summary>
        /// Язык перевода.
        /// </summary>
        public string Language { get; set; }
        
        /// <summary>
        /// Тип перевода.
        /// </summary>
        public TranslationType TranslationType { get; set; }

        /// <summary>
        /// Получает или задает список доступных языков и тип перевода на каждый их них.
        /// </summary>
        public ICollection<EntityGame> Games { get; set; } = new List<EntityGame>();
    }
}