namespace ChillGames.Models.Entities.Tags
{
    using Common;

    /// <summary>
    /// Тег.
    /// </summary>
    [EntityModel]
    public class EntityTag
    {
        /// <summary>
        /// Идентификатор тега.
        /// </summary>
        public long EntityTagID { get; set; }
        
        /// <summary>
        /// Название тега.
        /// </summary>
        public string Name { get; set; }
    }
}