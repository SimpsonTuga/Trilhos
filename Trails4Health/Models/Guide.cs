using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Trails4Health.Models
{
    public class Guide
    {
        
        public int IdGuide { get; set; }
        [Required(ErrorMessage = "Porfavor Introduza o nome")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Porfavor Introduza o numero de Telemovel")]
        //[MaxLength="9"]
        //[MinLength=9]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Porfavor Introduza o Email")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Porfavor introduza um email valido")]
        public string Email { get; set; }
    }
}
