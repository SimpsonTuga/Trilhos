using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Trails4Health.Models
{
    public class Trails
    {
        public int TrailID { set; get; }
        public string Name { set; get; }
        public string Length { get; set; }
        public int DificultyID { get; set; }//Fk da tabela Difilculty
        public Dificulty Dificulty { get; set; }
        public bool Ativo { get; set; }


    }
}
