using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoTrain.Models
{
    public class TrophyList
    {
        public string TrophyName { get; set; }
        public int TrophylistId { get; set; }
        public string Description { get; set; }
        public int Goal { get; set; }
       

        public ICollection<Trophies> trophies { get; set; }
    }
}
