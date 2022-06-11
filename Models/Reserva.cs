using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPatoBlanco_USMP.Models
{
    [Table("t_reserva")]
    public class Reserva
    {      
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Column("id")]

       public int id { get; set; }

       
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public String Fecha{ get; set;}
        public String Horario{ get; set;}
        public int Cantidad { get; set; }

    }
}