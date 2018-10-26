using System;
using System.Collections.Generic;

namespace GoTrain.Models
{
    public partial class TraningsPartnerSession
    {
        public string UserId { get; set; }
        public int TraningsSessionId { get; set; }

        public AspNetUsers TraningsPartner { get; set; }
        public TrainingsSessions TraningsSession { get; set; }
    }
}
