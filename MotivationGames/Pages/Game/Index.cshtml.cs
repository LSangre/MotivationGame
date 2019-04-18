using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivationGame.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IList<DataLayer.Data.Game> Model { get; set; }

        public async Task OnGetAsync()
        {
            var games = await _gameController.GetMine();
            Model = games.ToList();
        }
    }
}
