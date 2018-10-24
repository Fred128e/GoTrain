using System;
using System.Collections.Generic;

namespace GoTrain.Models
{
    public partial class Trainingspartners
    {
        public Trainingspartners()
        {
            TraningsPartnerSession = new HashSet<TraningsPartnerSession>();
            Trophies = new HashSet<Trophies>();
        }

        public string Name { get; set; }
        public int Location { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public ICollection<TraningsPartnerSession> TraningsPartnerSession { get; set; }
        public ICollection<Trophies> Trophies { get; set; }
    }
}
