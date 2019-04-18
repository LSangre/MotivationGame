using MotivationGame.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotivationGame.DataLayer.Repositories
{
    public interface IInvitationRepository
    {
        void AddInvitationList(List<Invitation> invitationList);
        void AcceptInvitation(string code, List<Goal> goalList);
        Invitation Get(long id);
        Invitation Get(string code);
        Invitation Get(string senderId, string receiverId, long gameId);
        Invitation Create(Invitation invitation);
        void SetInactive(long id);
    }
}
