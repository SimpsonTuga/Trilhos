using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class GuideTrail
    {
        public Trail Trail { get; set; }
        public int TrailId { get; set; }
        public Guide Guide { set; get; }
        public int GuideId { set; get; }

    }
}
