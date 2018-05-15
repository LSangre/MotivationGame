using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivationGame.Models
{
    public class CreateGameModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double Stake { get; set; }
    }
}
