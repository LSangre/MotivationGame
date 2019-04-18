using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivationGame.DataLayer.Data;
using MotivationGames.Controllers;

namespace MotivationGame.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly AccountController _accountController;

        public ConfirmEmailModel(AccountController accountController)
        {
            _accountController = accountController;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }
            await _accountController.ConfirmEmail(userId, code);
            return Page();
        }
    }
}
