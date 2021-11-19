namespace ChillGames.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tags;

    /// <summary>
    /// Сравнивает объекты <see cref="EntityTag"/>.
    /// </summary>
    public class EntityTagComparer : IEqualityComparer<EntityTag>
    {
        public bool Equals(EntityTag leftTag, EntityTag rightTag)
        {
            if (leftTag == null)
                throw new ArgumentNullException(nameof(leftTag));
            
            if (rightTag == null)
                throw new ArgumentNullException(nameof(rightTag));
            
            return leftTag.Name == rightTag.Name;
        }

        public int GetHashCode(EntityTag tag)
        {
            return tag.Name.Sum(s => s);
        }
    }
}