using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Models
{
    public class movimientos
    {
        [ScaffoldColumn(false), Key]
        public int ID_Movimiento { get; set; }

        [StringLength(10000), Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public string stringn { get; set; }
        
        [StringLength(10000), Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        public int? importe { get; set; }

        public string fechamovimiento { get; set; }
        public DateTime dateTime { get; set; }

        public int? ProvID { get; set; }
        public bool? Pagado { get; set; }

        public virtual ICollection<Detalles_Movimientos> Detalles_Movimientos { get; set; }
    }
}