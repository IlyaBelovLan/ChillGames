namespace ChillGames.UseCases.Games.GetGamesByIds
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Запрос получения игр по идентификаторам.
    /// </summary>
    [PublicAPI]
    public class GetGamesByIdsQuery : IRequest<GetGamesByIdsResponse>
    {
        /// <summary>
        /// Получает или задает список идентификаторов игр.
        /// </summary>
        public IReadOnlyCollection<string> Ids { get; set; }
    }
}