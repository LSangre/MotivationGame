using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                throw new NullReferenceException($"Пользователь с айди {userId} не найден");
            }

            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game == null)
            {
                throw new NullReferenceException($"Пользователь с айди {userId} не найден");
            }

            game.Goals.AddRange(goalList);
            
            if(!game.Players.Contains(user))
            {
                game.Players.Add(user);
            }

            _context.SaveChanges();
        }

        public Game Create(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public Game Get(long id)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            return game;
        }

        public bool IsExist(long id)
        {
            return _context.Games.Any(x => x.Id == id);
        }

        public List<Game> List(string userId)
        {
            var list = _context.Games.Where(g => g.CreatorId == userId).ToList();
            return list;
        }

        public List<Game> List()
        {
            return _context.Games.ToList();
        }

        public void Update(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }
    }
}
