using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Dificulty
    {
        public int IdDificulty { get; set; }
        //Nome da dificultade
        [StringLength(maximumLength: 18, MinimumLength = 3)]
        public string Name { get;set }
        //Relação com o trilho
        public ICollection<Trails> Trails { set;get }

    }
}
