using Microsoft.AspNetCore.Mvc;

namespace ChillGames.WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using MediatR;
    using UseCases.Users.AddUser;
    using UseCases.Users.GetUserInfo;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// <see cref="IMediator"/>.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UserController"/>.
        /// </summary>
        /// <param name="mediator"><see cref="IMediator"/>.</param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавляет пользователя.
        /// </summary>
        /// <param name="command"><see cref="AddUserCommand"/>.</param>
        /// <returns>Идентификатор пользователя.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AddUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Получает информацию о пользователе.
        /// </summary>
        /// <param name="query"><see cref="GetUserInfoQuery"/>.</param>
        /// <returns>Информация о пользователе.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetUserInfoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserInfo(GetUserInfoQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
    }
}