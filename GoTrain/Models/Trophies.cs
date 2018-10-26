using System;
using System.Collections.Generic;

namespace GoTrain.Models
{
    public partial class Trophies
    {
        
        public int Id { get; set; }
        public int Counter { get; set; }
        public string UserForeignKey { get; set; }
        public int Trophylistkey { get; set; }

        public AspNetUsers UserForeignKeyNavigation { get; set; }

        public TrophyList trophyList { get; set; }
    }
}
