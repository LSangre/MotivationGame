using MotivationGame.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivationGame.DataLayer.Data
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        public string CreatorId { get; set; }

        public ICollection<User> Players { get; set; }
        public GameType GameType { get; set; }
        public virtual List<Goal> Goals {get; set;}

        public string Rules { get; set; }
    }
}
