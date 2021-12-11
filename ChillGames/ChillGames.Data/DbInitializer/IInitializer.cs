namespace ChillGames.Data.DbInitializer
{
    using System.Threading.Tasks;

    /// <summary>
    /// Интерфейс инициализатора. 
    /// </summary>
    public interface IInitializer
    {
        /// <summary>
        /// Производит инициализацию.
        /// </summary>
        void Initialize();
    }
}