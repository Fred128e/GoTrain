using System;
using System.Collections.Generic;

namespace GoTrain.Models
{
    public partial class TrainingsSessions
    {
        public TrainingsSessions()
        {
            TraningsPartnerSession = new HashSet<TraningsPartnerSession>();
        }

        public int Id { get; set; }
        public string TrainingsDescription { get; set; }

        public ICollection<TraningsPartnerSession> TraningsPartnerSession { get; set; }
    }
}
