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
    public class DetailsModel : PageModel
    {
        private readonly MotivationGame.DataLayer.Data.ApplicationDbContext _context;

        public DetailsModel(MotivationGame.DataLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.SingleOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
