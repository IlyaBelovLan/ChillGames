namespace ChillGames.WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models.Games;
    using UseCases.Games.AddGame;
    using UseCases.Games.DeleteGameById;
    using UseCases.Games.GetGameById;
    using UseCases.Games.GetGamesByIds;

    /// <summary>
    /// Контролер для работы с книгами.
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GamesController : ControllerBase
    {
        /// <summary>
        /// <see cref="IMediator"/>.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GamesController"/>.
        /// </summary>
        /// <param name="mediator"><see cref="IMediator"/>.</param>
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Получает игру по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        /// <returns>Экземпляр <see cref="Game"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetGameByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGameById(string id)
        {
            var query = new GetGameByIdQuery { Id = id };
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Добавляет игру.
        /// </summary>
        /// <param name="command">Команда добавления игры.</param>
        /// <returns>Идентификатор игры.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AddGameResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddGame(AddGameCommand command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Удаляет игру.
        /// </summary>
        /// <param name="command">Команда удаления игры.</param>
        /// <returns>Ничего не возвращает.</returns>
        [HttpPost]
        public async Task<IActionResult> DeleteGameById(DeleteGameByIdCommand command)
        {
            await _mediator.Send(command).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Возвращает игры с заданными идентификаторами.
        /// </summary>
        /// <param name="query">Запрос получения игр.</param>
        /// <returns>Список игр.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetGamesByIdsQuery), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGamesByIds(GetGamesByIdsQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
    }
}