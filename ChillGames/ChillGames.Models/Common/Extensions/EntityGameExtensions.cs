namespace ChillGames.Models.Common.Extensions
{
    using System.Linq;
    using Entities.Games;

    /// <summary>
    /// Методы расширения для <see cref="EntityGame"/>.
    /// </summary>
    public static class EntityGameExtensions
    {
        /// <summary>
        /// Копирует значения <see cref="source"/> в <see cref="destination"/>. 
        /// </summary>
        /// <param name="destination">Экземпляр <see cref="TEntity"/>, которому присваивается значение.</param>
        /// <param name="source">Источник значений.</param>
        /// <typeparam name="TEntity">Тип объекта, с которым идет работа.</typeparam>
        public static void AssignFrom<TEntity>(this TEntity destination, TEntity source)
        {
            destination
                .GetType().GetProperties().ToList()
                .ForEach(p => p
                    .SetValue(destination, p.GetValue(source)));
        }
    }
}