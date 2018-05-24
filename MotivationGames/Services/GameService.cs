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

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void AcceptInvitation(string userId, string invitationCode, List<Goal> goalList)
        {
            throw new NotImplementedException();
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

            var messageTemplate = @"Привет! Вас пригласили в игру {gameName}. Нажмите на ссылку {link}, чтобы присоединиться к игре.";
            foreach(var email in playersEmails)
            {
                var invitation = new Invitation
                {
                    Code = Guid.NewGuid().ToString(),
                    GameId = gameId,
                    Email = email,
                    Active = true
                };
            }
        }
    }
}
