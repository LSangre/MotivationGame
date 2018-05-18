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
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new NullReferenceException(string.Format("Пользователь с айди {0} не найден", userId));
            }

            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game == null)
            {
                throw new NullReferenceException(string.Format("Пользователь с айди {0} не найден", userId));
            }

            game.Goals.AddRange(goalList);
            
            if(!game.Players.Contains(user))
            {
                game.Players.Add(user);
            }

            _context.SaveChanges();
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
