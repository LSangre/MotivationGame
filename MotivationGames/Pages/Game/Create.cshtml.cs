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
using MotivationGame.DataLayer.Repositories;
using MotivationGame.Models;
using MotivationGame.Extensions;

namespace MotivationGame.Pages.Game
{
    public class CreateModel : PageModel
    {
        private readonly GameController _gameController;

        public CreateModel(GameController gameController)
        {
            _gameController = gameController;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult OnGet()
        {
            Input = new InputModel
            {
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(1)
            };
            return Page();
        }

        public class InputModel
        {
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _gameController.Post(new DataLayer.Data.Game
            {
                StartDate = Input.StartDate,
                FinishDate = Input.FinishDate,
                Name = Input.Name
            });

            return RedirectToPage("./Index");
        }
    }
}