namespace ChillGames.Models.Entities.Tags
{
    using System.Text.Json.Serialization;
    using Common;
    using Games;

    /// <summary>
    /// Сущность тегирования игры.
    /// Тегирование - добавление к игре тега.
    /// </summary>
    [EntityModel]
    public class EntityTagging
    {
        /// <summary>
        /// Получает или задает идентификатор теггирования.
        /// </summary>
        public long EntityTaggingID { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор игры.
        /// </summary>
        public long EntityGameID { get; set; }
        
        /// <summary>
        /// Получает или задает идентификатор тега.
        /// </summary>
        public long EntityTagID { get; set; }
        
        /// <summary>
        /// Получает или задает игру.
        /// </summary>
        [JsonIgnore]
        public EntityGame EntityGame { get; set; }
        
        /// <summary>
        /// Получает или задает тег.
        /// </summary>
        [JsonIgnore]
        public EntityTag EntityTag { get; set; }
    }
}