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
    }
}
