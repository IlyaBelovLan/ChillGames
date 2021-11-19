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

        /// <summary>
        /// Инициализирует пустой экземпляр <see cref="KeyValue{TKey,TValue}"/>.
        /// </summary>
        public KeyValue(){}
        
        /// <summary>
        /// Инициализирует экземпляр <see cref="KeyValue{TKey,TValue}"/>.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="value">Значение.</param>
        public KeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}