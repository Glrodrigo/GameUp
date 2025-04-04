using GamesUpApp.Domain;
using GamesUpApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesUpApp.Controllers
{
    [Route("games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gamesService;

        public GameController(IGameService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpPost("create", Name = "createGame")]
        public async Task<IActionResult> CreateAsync([FromBody] GameDomain game)
        {
            try
            {
                var gameBase = new GameBase(game.UserId, game.Name, game.Description, game.Platform, game.TotalHours, game.Finished) { };
                var result = await _gamesService.CreateAsync(gameBase);

                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(this.BadRequest(ex.Message));
            }
        }

        [HttpGet("all", Name = "getGames")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _gamesService.GetAsync();

                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(this.BadRequest(ex.Message));
            }
        }

        [HttpGet("find/id", Name = "findByIdGame")]
        public async Task<IActionResult> FindByIdAsync(Guid id)
        {
            try
            {
                var result = await _gamesService.FindByIdAsync(id);

                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(this.BadRequest(ex.Message));
            }
        }

        [HttpPut("change", Name = "changeGame")]
        public async Task<IActionResult> ChangeAsync([FromBody] GameParams game)
        {
            try
            {
                var result = await _gamesService.ChangeAsync(game);
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(this.BadRequest(ex.Message));
            }
        }
    }
}
