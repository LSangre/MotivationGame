using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotivationGame.DataLayer.Data;
using MotivationGame.DataLayer.Repositories;
using MotivationGame.Extensions;

namespace MotivationGame.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GameController(IGameRepository gameRepository, IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private string getUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            var gameList = _gameRepository.List();
            return gameList;
        }

        [HttpGet("GetMy")]
        [Authorize]
        public async Task<IEnumerable<Game>> GetMine()
        {
            var gameList = _gameRepository.List(getUserId());
            return gameList;
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Game> Get(long id)
        {
            var game = _gameRepository.Get(id);
            return game;
        }
        
        // POST: api/Game
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]Game game)
        {
            game.CreatorId = getUserId();
            _gameRepository.Create(game);
            return Ok(game);
        }
        
        // PUT: api/Game/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(long id, [FromBody]Game game)
        {
            var gameToUpdate = _gameRepository.Get(id);
            if (gameToUpdate == null)
            {
                return NotFound("Игра с таким номером не найдена");
            }

            if (gameToUpdate.CreatorId != getUserId())
            {
                return Forbid("Вы не можете редактировать эту игру");
            }

            gameToUpdate.Name = game.Name;
            gameToUpdate.FinishDate = game.FinishDate;
            gameToUpdate.StartDate = game.StartDate;
            gameToUpdate.Rules = game.Rules;
            _gameRepository.Update(gameToUpdate);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
