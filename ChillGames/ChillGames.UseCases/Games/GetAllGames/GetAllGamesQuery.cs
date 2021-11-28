namespace ChillGames.UseCases.Games.GetAllGames
{
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Запрос получения всех игр.
    /// </summary>
    [PublicAPI]
    public class GetAllGamesQuery : IRequest<GetAllGamesResponse>
    {
    }
}