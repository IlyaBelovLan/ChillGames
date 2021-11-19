namespace ChillGames.Data.UnitsOfWork
{
    using System.Threading.Tasks;

    /// <summary>
    /// Единица работы.
    /// </summary>
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}