using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper _mapper;

        public EditModel(GameController gameController, IMapper mapper)
        {
            _gameController = gameController;
            _mapper = mapper;
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

            Input = _mapper.Map<InputModel>(result);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var game = new DataLayer.Data.Game
            {
                Id = Input.Id,
                Name = Input.Name,
                StartDate = Input.StartDate,
                FinishDate = Input.FinishDate,
                Rules = Input.Rules
            };
            await _gameController.Put(game.Id, game);
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

            [Display(Name = "Правила")]
            [MaxLength(5000)]
            public string Rules { get; set; }

        }
    }
}
