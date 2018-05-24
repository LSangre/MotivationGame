using MotivationGame.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivationGame.Services
{
    public interface IGameService
    {
        void AddPlayersToGame(string userId, long gameId, List<string> playersEmails);
        void AcceptInvitation(string userId, string invitationCode, List<Goal> goalList);
    }
}
