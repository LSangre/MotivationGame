using MotivationGame.DataLayer.Enums;
using System;
using System.Collections.Generic;

namespace MotivationGame.DataLayer.Data
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ApplicationUser Creator { get; set; }
        public ICollection<ApplicationUser> Players { get; set; }
        public GameType GameType { get; set; }
        public virtual List<Goal> Goals {get; set;}
    }
}
