namespace ChillGames.UseCases.Common.Extensions
{
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
        public static long ToLong(this string str)
        {
            return long.Parse(str);
        } 
    }
}