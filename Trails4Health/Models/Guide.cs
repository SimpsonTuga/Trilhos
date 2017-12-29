using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Trails4Health.Models
{
    public class Guide
    {
        
        public int GuideId { get; set; }

        [Required(ErrorMessage = "Porfavor Introduza o nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Porfavor Introduza o numero de Telemovel")]
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Porfavor Introduza o Email")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Porfavor introduza um email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Porfavor Introduza o Nif")]
        public string NIF { get; set; }
        public List<GuideTrail> GuideTrail { set; get; }
    }
}
