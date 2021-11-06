namespace ChillGames.Models.Entities.Translation
{
    using System.Text.Json.Serialization;
    using Common;
    using Games;

    /// <summary>
    /// Перевод игры.
    /// </summary>
    [EntityModel]
    public class EntityGameTranslation
    {
        /// <summary>
        /// Получает или задает идентификатор одного перевода для одной игры. 
        /// </summary>
        public long EntityGameTranslationID { get; set; }
        
        /// <summary>
        /// Получает или задает идентфикикатор игры.
        /// </summary>
        public long EntityGameID { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор перевода игры.
        /// </summary>
        public long EntityTranslationID { get; set; }
        
        /// <summary>
        /// Получает или задает игру.
        /// </summary>
        [JsonIgnore]
        public EntityGame EntityGame { get; set; }
        
        /// <summary>
        /// Получает или задает перевод игры.
        /// </summary>
        [JsonIgnore]
        public EntityTranslation EntityTranslation { get; set; }
    }
}