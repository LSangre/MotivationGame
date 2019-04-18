using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotivationGame.DataLayer.Data;
using MotivationGame.Extensions;
using MotivationGames.Services;
using System;
using System.Threading.Tasks;

namespace MotivationGames.Controllers
{
    [Produces("application/json")]
    [Route("api/Invitation")]
    public class InvitationController : Controller
    {
        private readonly IInvitationService _invitationService;

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(long gameId, string email)
        {
            try
            {
                var result = await _invitationService.AddInvitation(User.GetUserId(), string.Empty, 0);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}