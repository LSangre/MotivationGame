using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MotivationGame.DataLayer.Data
{
    public class Invitation
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public long GameId { get; set; }

        public bool Active { get; set; }

        [ForeignKey("GameId")]
        public ApplicationUser Sender { get; set; }
        public string SenderId { get; set; }
    }
}
