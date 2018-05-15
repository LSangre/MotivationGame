﻿using MotivationGame.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotivationGame.DataLayer.Repositories
{
    public interface IGameRepository
    {
        void CreateGame(Game game);
        List<Game> List(string userId);
        void AddGameGoals(string userId, long gameId, List<Goal> goalList);
    }
}
