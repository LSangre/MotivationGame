using MotivationGame.DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotivationGame.DataLayer.Data
{
    public class Goal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public GoalType GoalType { get; set; }
        public double Strake { get; set; }
        public string UserId { get; set; }
    
        [ForeignKey("UserId")]
        public virtual ApplicationUser User {get;set;}
    }
}
