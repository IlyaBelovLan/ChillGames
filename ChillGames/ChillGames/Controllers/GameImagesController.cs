using Microsoft.AspNetCore.Mvc;

namespace ChillGames.WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using MediatR;
    using UseCases.Images.AddGameImages;
    using UseCases.Images.DeleteGameImages;
    using UseCases.Images.GetGameImagesById;
    using UseCases.Images.GetGamePreview;
    using UseCases.Images.UpdateGameImages;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameImagesController : ControllerBase
    {
        /// <summary>
        /// <see cref="IMediator"/>.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Инициализирует экземпляр <see cref="IMediator"/>.
        /// </summary>
        /// <param name="mediator"><see cref="IMediator"/>.</param>
        public GameImagesController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Добавляет игровые изображения.
        /// </summary>
        /// <param name="command"><see cref="AddGameImagesCommand"/>.</param>
        [HttpPost]
        public async Task<IActionResult> AddGameImages(AddGameImagesCommand command)
        {
            await _mediator.Send(command).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Получает изображения для игры.
        /// </summary>
        /// <param name="query"><see cref="GetGameImagesByIdQuery"/>.</param>
        /// <returns>Список изображений.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetGameImagesByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGameImagesById(GetGameImagesByIdQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Удаляет игровые изображения.
        /// </summary>
        /// <param name="command"><see cref="DeleteGameImagesCommand"/></param>.
        [HttpPost]
        public async Task<IActionResult> DeleteGameImages(DeleteGameImagesCommand command)
        {
            await _mediator.Send(command).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Обновляет игровые изображения.
        /// </summary>
        /// <param name="command"><see cref="UpdateGameImagesCommand"/>.</param>
        [HttpPost]
        public async Task<IActionResult> UpdateGameImages(UpdateGameImagesCommand command)
        {
            await _mediator.Send(command).ConfigureAwait(false);
            return Ok();
        }
        
        /// <summary>
        /// Получает обложку для игры.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        /// <returns>Изображение.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetGamePreviewResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGamePreview(string id)
        {
            var query = new GetGamePreviewQuery { Id = id };
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
    }
}