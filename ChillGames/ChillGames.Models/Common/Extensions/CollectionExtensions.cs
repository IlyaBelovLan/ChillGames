namespace ChillGames.Models.Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Методы расширений для коллекций.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Проверяет коллекцию на наличие элементов.
        /// </summary>
        /// <param name="collection">Коллекция.</param>
        /// <typeparam name="T">Тип элементов коллекции.</typeparam>
        /// <returns>Истину, если коллекция пуста и ложь, если не пуста.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || !collection.Any();
    }
}