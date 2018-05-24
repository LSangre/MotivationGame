using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: api/Game
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            var gameList = _gameRepository.List(User.GetUserId());
            return gameList;
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public Game Get(int id)
        {
            var game = _gameRepository.Get(id);
            return game;
        }
        
        // POST: api/Game
        [HttpPost]
        public void Post([FromBody]Game game)
        {
            game.CreatorId = User.GetUserId();
            _gameRepository.Create(game);
        }
        
        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public void AddGoals(List<Goal> goalList, long gameId)
        {
            _gameRepository.AddGoals(User.GetUserId(), gameId, goalList);
        }
    }
}
