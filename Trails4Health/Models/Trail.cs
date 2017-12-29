using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int TrailsId { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public bool State { get; set; }
        public int DifficultyId { set; get; }
        public Difficulty Difficulty { get; set; }

        public List<GuideTrail> GuideTrail { set; get; }
    }
}
