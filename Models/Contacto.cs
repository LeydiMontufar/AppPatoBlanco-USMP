using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPatoBlanco_USMP.Models
{


    [Table("t_contacto")]
    public class Contacto
    {
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
         public int Id {get; set; }

          [Column("nom")]
        public string Nombre {get; set; }
        [Column("email")]
        public string Email {get; set; }
        [Column("consult")]
        public string Consult {get; set; }
    }
}