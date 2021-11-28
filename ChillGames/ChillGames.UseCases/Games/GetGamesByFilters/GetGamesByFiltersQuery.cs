namespace ChillGames.UseCases.Games.GetGamesByFilters
{
    using Common;
    using JetBrains.Annotations;
    using MediatR;
    using Models.Games;

    /// <summary>
    /// Запрос получения игр по фильтрам.
    /// </summary>
    [PublicAPI]
    public class GetGamesByFiltersQuery : GamesSearchParams, IRequest<GetGamesByFiltersResponse>, IRequestWithPagination
    {
        
    }
}