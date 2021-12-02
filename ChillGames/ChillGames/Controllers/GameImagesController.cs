using Microsoft.AspNetCore.Mvc;

namespace ChillGames.WebApi.Controllers
{
    using System.Threading.Tasks;
    using MediatR;
    using UseCases.Images.AddGameImages;

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
    }
}