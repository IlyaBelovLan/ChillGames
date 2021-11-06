namespace ChillGames.Models.Common
{
    /// <summary>
    /// Пара ключ-значение.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип значения.</typeparam>
    public class KeyValue<TKey, TValue>
    {
        /// <summary>
        /// Ключ.
        /// </summary>
        public TKey Key { get; set; }
        
        /// <summary>
        /// Значение.
        /// </summary>
        public TValue Value { get; set; }
    }
}