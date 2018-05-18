using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotivationGame.DataLayer.Data;
using MotivationGame.DataLayer.Repositories;
using MotivationGames.Extensions;

namespace MotivationGames.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly MotivationGame.DataLayer.Data.ApplicationDbContext _context;
        private readonly IGameRepository _gameRepository;

        public IndexModel(MotivationGame.DataLayer.Data.ApplicationDbContext context,
            IGameRepository gameRepository)
        {
            _context = context;
            _gameRepository = gameRepository;
        }

        public IList<MotivationGame.DataLayer.Data.Game> Model { get;set; }

        public async Task OnGetAsync()
        {
            Model = _gameRepository.List(User.GetUserId());
        }
    }
}
