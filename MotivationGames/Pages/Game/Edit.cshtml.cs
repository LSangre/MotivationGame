using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotivationGame.Controllers;
using MotivationGame.DataLayer.Data;

namespace MotivationGame.Pages.Game
{
    public class EditModel : PageModel
    {
        private readonly GameController _gameController;

        public EditModel(GameController gameController)
        {
            _gameController = gameController;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _gameController.Get(id.Value);

            if (result == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                FinishDate = result.FinishDate,
                Name = result.Name,
                StartDate = result.StartDate
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Game).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GameExists(Game.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        public class InputModel
        {
            public long Id { get; set; }

            [Required(ErrorMessage = "Заполните название игры")]
            [Display(Name = "Название игры")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Заполните дату и время начала игры")]
            [Display(Name = "Начало игры")]
            public DateTime StartDate { get; set; }

            [Required(ErrorMessage = "Заполните дату и время окончания игры")]
            [Display(Name = "Конец игры")]
            public DateTime FinishDate { get; set; }
        }
    }
}
