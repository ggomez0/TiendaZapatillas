using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Models
{    public class Respuesta<T>
    {
        public bool estado { get; set; }
        public string valor { get; set; }
        public T objeto { get; set; }
    }
}
