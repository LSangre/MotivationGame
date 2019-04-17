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
        public async Task<IEnumerable<Game>> Get()
        {
            var gameList = _gameRepository.List(User.GetUserId());
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
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
