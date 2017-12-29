using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Difficulty
    {
        public int DifficultyID { get; set; }
        public string Name { get; set; }

        public List<Trail> Trail { get; set; }
    }
}
