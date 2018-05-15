using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotivationGame.DataLayer.Data;

namespace MotivationGames.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly MotivationGame.DataLayer.Data.ApplicationDbContext _context;

        public IndexModel(MotivationGame.DataLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }

        public async Task OnGetAsync()
        {
            Game = await _context.Game.ToListAsync();
        }
    }
}
