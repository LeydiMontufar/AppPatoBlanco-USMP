using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPatoBlanco_USMP.Models
{
        [Table("t_product")]
   
    public class Producto
    {
        
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
         public int Id {get; set; }

        [Column("nomPro")]
        public string Nombre {get; set; }
        [Column("desc")]
        public string Descripcion {get; set; }
        [Column("precio")]
        public Decimal Precio {get; set; }
        [Column("porDesc")]
        public Decimal PorcentajeDesc {get; set; }
        [Column("imagen")]
        public string Imagen {get; set; }
        [Column("status")]
        public string Status {get; set; }
    }

    
}