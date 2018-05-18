using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotivationGame.DataLayer.Data;

namespace MotivationGame.DataLayer.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddGoals(string userId, long gameId, List<Goal> goalList)
        {
            throw new NotImplementedException();
        }

        public void Create(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public List<Game> List(string userId)
        {
            var list = _context.Games.Where(g => g.CreatorId == userId).ToList();
            return list;
        }
    }
}
