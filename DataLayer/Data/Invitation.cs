using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MotivationGame.DataLayer.Enums;

namespace MotivationGame.DataLayer.Data
{
    public class Invitation
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }

        [ForeignKey("RecipientId")]
        public virtual User Recipient { get; set; }
        public string RecipientId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public long GameId { get; set; }

        public InvitationStatus Status { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }
        public string SenderId { get; set; }
    }
}
