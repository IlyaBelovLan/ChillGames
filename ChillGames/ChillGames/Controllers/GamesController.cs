namespace ChillGames.WebApi.Controllers
{
    using System;
    using Data.Repositories.GamesRepositories;
    using Microsoft.AspNetCore.Mvc;
    using Models.Common;
    using Models.Entities.Games;
    using Swashbuckle.AspNetCore.Annotations;

    /// <summary>
    /// Контролер для работы с книгами.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        /// <summary>
        /// Получает книгу.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation]
        public IActionResult GetGame()
        {

            var game = new EntityGame
            {
                Title = "Skyrim",
                Description = "Beautiful RPG",
                Price = 1000,
                Discount = 0,
                Platforms = new[] { Platform.Windows },
                Launchers = new[] { Launcher.Steam },
                Genre = "RPG",
                Publisher = "Bethesda",
                ReleaseDate = new DateTime(2011, 11, 11),
                Count = 123
            };

            _gamesRepository.AddGame(game);

            _gamesRepository.SaveChanges();

            var game1 = _gamesRepository.GetGameById(1);
            return Ok(game1);
        }
    }
}