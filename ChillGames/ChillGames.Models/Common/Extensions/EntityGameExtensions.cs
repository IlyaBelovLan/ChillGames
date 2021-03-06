namespace ChillGames.Models.Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Entities.Games;
    using Entities.Tags;

    /// <summary>
    /// Методы расширений для <see cref="EntityGame"/>.
    /// </summary>
    public static class EntityGameExtensions
    {
        /// <summary>
        /// Заменяет теги в <see cref="EntityGame"/> аналогичными тегами из <see cref="ICollection{EntityTag}"/>
        /// </summary>
        /// <param name="entityGame">Игра.</param>
        /// <param name="actualTags">Список тегов.</param>
        public static void ReplaceRepeatedTags(this EntityGame entityGame, ICollection<EntityTag> actualTags)
        {
            var gameTags = entityGame.Tags.ToList();
            var entityTagComparer = new EntityTagComparer(); 

            var intersectTags = actualTags.Intersect(gameTags, entityTagComparer).ToList();

            var exceptTags = gameTags.Except(intersectTags, entityTagComparer).ToList();

            var unionTags = intersectTags.Union(exceptTags).ToList();

            entityGame.Tags = unionTags;
        }
    }
}