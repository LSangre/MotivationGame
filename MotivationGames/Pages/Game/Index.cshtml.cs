using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotivationGame.Controllers;
using MotivationGame.DataLayer.Data;
using MotivationGame.DataLayer.Repositories;
using MotivationGame.Extensions;

namespace MotivationGame.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly GameController _gameController;

        public IndexModel(GameController gameController)
        {
            _gameController = gameController;
        }

        [BindProperty]
        public IList<MotivationGame.DataLayer.Data.Game> Model { get; set; }

        public async Task OnGetAsync()
        {
            var games = await _gameController.Get();
            Model = games.ToList();
        }
    }
}
