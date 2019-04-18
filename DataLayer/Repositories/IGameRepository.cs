using MotivationGame.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MotivationGame.DataLayer.Repositories
{
    public interface IGameRepository
    {
        Game Create(Game game);
        List<Game> List(string userId);
        List<Game> List();
        void AddGoals(string userId, long gameId, List<Goal> goalList);
        Game Get(long id);
        void Update(Game game);
        bool IsExist(long id);
    }
}
