using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotivationGame.DataLayer.Data;
using MotivationGame.DataLayer.Repositories;
using MotivationGame.Models;

namespace MotivationGames.Pages.Game
{
    public class CreateModel : PageModel
    {
        private readonly MotivationGame.DataLayer.Data.ApplicationDbContext _context;
        private readonly IGameRepository _gameRepository;

        public CreateModel(MotivationGame.DataLayer.Data.ApplicationDbContext context,
            IGameRepository gameRepository)
        {
            _context = context;
            _gameRepository = gameRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateGameModel Game { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            _context.Game.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}