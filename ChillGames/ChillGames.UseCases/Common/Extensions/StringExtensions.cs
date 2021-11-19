namespace ChillGames.UseCases.Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Расширения для <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Приводит строку к длинному числу.
        /// </summary>
        /// <param name="str">Строка.</param>
        /// <returns>Длинное целое число.</returns>
        public static long ToLong(this string str) => long.Parse(str);

        /// <summary>
        /// Преобразует список строк в список длинных целых.
        /// </summary>
        /// <param name="strings">Список строк.</param>
        /// <returns>Список длинных целых.</returns>
        public static IEnumerable<long> ToLongs(this IEnumerable<string> strings) => strings.Select(s => s.ToLong());
    }
}