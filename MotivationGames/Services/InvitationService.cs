using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotivationGame.DataLayer.Data;
using MotivationGame.DataLayer.Enums;
using MotivationGame.DataLayer.Repositories;
using MotivationGame.Services;

namespace MotivationGames.Services
{
    public class InvitationService: IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly UserManager<User> _userManager;
        private readonly IGameRepository _gameRepository;
        private readonly IEmailSender _emailSender;

        public InvitationService(IInvitationRepository invitationRepository, UserManager<User> userManager, IGameRepository gameRepository, IEmailSender emailSender)
        {
            _invitationRepository = invitationRepository;
            _userManager = userManager;
            _gameRepository = gameRepository;
            _emailSender = emailSender;
        }

        public async Task<Invitation> AddInvitation(string senderId, string receiverEmail, long gameId)
        {
            if (!_gameRepository.IsExist(gameId))
            {
                throw new ArgumentException($"Не существует игры с id = {gameId}");
            }

            var invitation = _invitationRepository.Get(senderId, receiverEmail, gameId);
            if (invitation == null)
            {
                var recipient = await _userManager.FindByEmailAsync(receiverEmail);
                invitation = new Invitation
                {
                    SenderId = senderId,
                    Email = receiverEmail,
                    GameId = gameId,
                    Recipient = recipient,
                    Code = Guid.NewGuid().ToString(),
                    Status = InvitationStatus.Sended
                };

                _invitationRepository.Create(invitation);
            }

            await _emailSender.SendEmailAsync(receiverEmail, "Приглашение на игру",
                $"Вас приглашают на <a href='{HtmlEncoder.Default.Encode($"http://localhoset:64535/{invitation.Code}")}'>игру</a>.");

            return invitation;
        }
    }
}
