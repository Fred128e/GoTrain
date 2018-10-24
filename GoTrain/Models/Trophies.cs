using System;
using System.Collections.Generic;

namespace GoTrain.Models
{
    public partial class Trophies
    {
        public string TrophyName { get; set; }
        public string Description { get; set; }
        public int Counter { get; set; }
        public int Id { get; set; }
        public int Goal { get; set; }
        public int? TraningspartnerForeignKey { get; set; }

        public Trainingspartners TraningspartnerForeignKeyNavigation { get; set; }
    }
}
