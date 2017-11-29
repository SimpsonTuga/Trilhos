using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Trails4Health.Models
{
    public class Guide
    {
        
        public int GuideID { get; set; }
        //nome
        [Required(ErrorMessage = "Porfavor Introduza o nome")]
        public string Name { get; set; }
        //Telefone
        [Required(ErrorMessage = "Porfavor Introduza o numero de Telemovel")]
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        public string Phone { get; set; }
        //Email
        [Required(ErrorMessage = "Porfavor Introduza o Email")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Porfavor introduza um email valido")]
        public string Email { get; set; }
        //Numero de Indentificação fiscal
        [StringLength(maximumLength:9, MinimumLength = 9)]
        public string NIF { get; set; }
        [StringLength(maximumLength: 9, MinimumLength = 9)]
        //Nº do BI
        public string BI { get; set; }

    }
}
