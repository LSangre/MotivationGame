using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotivationGame.DataLayer.Data;

namespace MotivationGame.DataLayer.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly ApplicationDbContext _context;

        public InvitationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AcceptInvitation(string code, List<Goal> goalList)
        {
            throw new NotImplementedException();
        }

        public void AddInvitationList(List<Invitation> invitationList)
        {
            _context.AddRange(invitationList);
            _context.SaveChanges();
        }

        public Invitation Get(long id)
        {
            return _context.Invitations.FirstOrDefault(x => x.Id == id);
        }
    }
}
