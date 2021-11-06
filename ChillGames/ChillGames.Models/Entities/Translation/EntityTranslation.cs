namespace ChillGames.Models.Entities.Translation
{
    using Common;

    /// <summary>
    /// Язык и тип перевода игры.
    /// </summary>
    [EntityModel]
    public class EntityTranslation
    {
        /// <summary>
        /// Получает или задает идентификатор перевода.
        /// </summary>
        public long EntityTranslationID { get; set; }

        /// <summary>
        /// Язык перевода.
        /// </summary>
        public string Language { get; set; }
        
        /// <summary>
        /// Тип перевода.
        /// </summary>
        public TranslationType TranslationType { get; set; }
    }
}