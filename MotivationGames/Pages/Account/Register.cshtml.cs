using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MotivationGame.DataLayer.Data;
using MotivationGame.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MotivationGames.Controllers;

namespace MotivationGame.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private AccountController _accountController;

        public RegisterModel(
            AccountController accountController)
        {
            _accountController = accountController;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                await _accountController.Register(Input.Email, Input.Password);
                return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
