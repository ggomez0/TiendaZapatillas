using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Models
{
    public class Detalles_Movimientos
    {
        [ScaffoldColumn(true), Key]
        public int ID_Det_Movimientoss { get; set; }

        public int cantidad { get; set; }
        public int? precio { get; set; }
        public int? factid { get; set; }

        public virtual Product Product { get; set; }

        public virtual movimientos movimientos { get; set; }
    }
}