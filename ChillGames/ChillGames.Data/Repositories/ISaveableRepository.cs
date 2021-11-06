using System;
using System.Collections.Generic;
using System.Text;

namespace ChillGames.Data.Repositories
{
    /// <summary>
    /// Интерфейс репозитория, который должен сохранять изменения.
    /// </summary>
    public interface ISaveableRepository
    {
        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        void SaveChanges();
    }
}
