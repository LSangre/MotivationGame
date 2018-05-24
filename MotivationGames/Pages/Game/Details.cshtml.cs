using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotivationGame.DataLayer.Data;

namespace MotivationGame.Pages.Game
{
    public class DetailsModel : PageModel
    {
        private readonly MotivationGame.DataLayer.Data.ApplicationDbContext _context;

        public DetailsModel(MotivationGame.DataLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MotivationGame.DataLayer.Data.Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games.SingleOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
