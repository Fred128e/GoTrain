using System;
using System.Collections.Generic;

namespace GoTrain.Models
{
    public partial class TraningsPartnerSession
    {
        public int TraningsPartnerId { get; set; }
        public int TraningsSessionId { get; set; }

        public Trainingspartners TraningsPartner { get; set; }
        public TrainingsSessions TraningsSession { get; set; }
    }
}
