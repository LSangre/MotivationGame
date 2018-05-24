using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotivationGame.Services;

namespace MotivationGames.Controllers
{
    [Produces("application/json")]
    [Route("api/Invitation")]
    public class InvitationController : Controller
    {
        private readonly IGameService _gameService;

        public InvitationController(IGameService gameService)
        {
            _gameService = gameService;
        }
        
    }
}