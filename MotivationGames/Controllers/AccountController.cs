using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotivationGame.DataLayer.Data;
using MotivationGame.Pages.Account;
using MotivationGame.Services;
using System.Threading.Tasks;

namespace MotivationGames.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<LoginModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = new User { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return StatusCode(500);
            
            _logger.LogInformation("User created a new account with password.");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = System.Web.HttpUtility.UrlEncode(code);
            var callbackUrl = $"http://localhost:60474/Account/ConfirmEmail?code={code}&userId={user.Id}";
            await _emailSender.SendEmailConfirmationAsync(email, callbackUrl);

            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();

        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return new RedirectToPageResult("/Index");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                return BadRequest($"Error confirming email for user with ID '{userId}':");
            }

            return Ok();
        }

    }
}