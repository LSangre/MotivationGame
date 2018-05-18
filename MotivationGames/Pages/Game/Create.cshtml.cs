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
using AutoMapper;
using MotivationGames.Extensions;

namespace MotivationGames.Pages.Game
{
    public class CreateModel : PageModel
    {
        private readonly MotivationGame.DataLayer.Data.ApplicationDbContext _context;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public CreateModel(MotivationGame.DataLayer.Data.ApplicationDbContext context,
            IGameRepository gameRepository,
            IMapper mapper)
        {
            _context = context;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateGameModel Model { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var game = _mapper.Map<MotivationGame.DataLayer.Data.Game>(Model);
            game.CreatorId = User.GetUserId();

            _gameRepository.Create(game);

            return RedirectToPage("./Index");
        }
    }
}