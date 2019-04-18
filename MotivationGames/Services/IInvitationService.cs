using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotivationGame.DataLayer.Data;

namespace MotivationGames.Services
{
    public interface IInvitationService
    {
        Task<Invitation> AddInvitation(string senderId, string recieverEmail, long gameId);
    }
}
