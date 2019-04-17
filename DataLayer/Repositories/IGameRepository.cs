using MotivationGame.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotivationGame.DataLayer.Repositories
{
    public interface IGameRepository
    {
        Game Create(Game game);
        List<Game> List(string userId);
        void AddGoals(string userId, long gameId, List<Goal> goalList);
        Game Get(long id);
    }
}
