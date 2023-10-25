using TiendaZapatillas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaZapatillas.Logic
{
    public class addmovimiento
    {
        public bool addmovimientos(string nombre, string descripcion, int importe, int IDMovimiento, string prov, string noom, string calendar)
        {
            var mylstcpra = new movimientos();
            mylstcpra.Nombre = nombre;
            mylstcpra.descripcion = descripcion;
            mylstcpra.importe =importe;
            mylstcpra.dateTime = DateTime.Now;
            mylstcpra.ProvID = Convert.ToInt32(prov);
            mylstcpra.ID_Movimiento = IDMovimiento;
            mylstcpra.stringn = noom;
            mylstcpra.fechamovimiento = calendar;

            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.movimientos.Add(mylstcpra);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}