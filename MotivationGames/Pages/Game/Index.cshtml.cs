using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotivationGame.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly MotivationGame.Data.ApplicationDbContext _context;

        public IndexModel(MotivationGame.Data.ApplicationDbContext context)
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
