using Microsoft.AspNetCore.Identity;
using MotivationGame.DataLayer.Data;
using MotivationGame.DataLayer.Repositories;
using MotivationGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivationGames.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IInvitationRepository _invitationRepository;
        private readonly IEmailSender _emailSender;
        private readonly IUserStore<User> _userStore;

        private const string domain = "domain";

        public GameService(IGameRepository gameRepository,
                            IInvitationRepository invitationRepository,
                            IEmailSender emailSender,
                            IUserStore<User> userStore)
        {
            _gameRepository = gameRepository;
            _invitationRepository = invitationRepository;
            _emailSender = emailSender;
        }

        public void AcceptInvitation(string userId, string invitationCode, List<Goal> goalList)
        {
        }

        public void AddPlayersToGame(string userId, long gameId, List<string> playersEmails)
        {
            var game = _gameRepository.Get(gameId);
            
            if (game.CreatorId != userId || 
                game.Players.Select(p => p.Id).Contains(userId))
            {
                throw new Exception("Пользователь не имеет права добавлять игроков в эту игру");
            }

            var invitationList = new List<Invitation>();

            var messageTemplate = string.Format("Привет! Вас пригласили в игру {0}. Нажмите на ссылку %link%, чтобы присоединиться к игре.", game.Name);
            var subject = "Вас пригласили в игру!";
            foreach(var email in playersEmails)
            {
       
                var invitation = new Invitation
                {
                    Code = Guid.NewGuid().ToString(),
                    GameId = gameId,
                    Email = email,
               //     Active = true
                };
            //    _invitationRepository.CreateInvitation(invitation);
                var link = string.Format("{0}{1}{2}", domain, "/Invitation/Accept?code=", invitation.Code);
                var invitationMessage = messageTemplate.Replace("%link%}", link);
                _emailSender.SendEmailAsync(email, subject, invitationMessage);
            }
        }
    }
}
