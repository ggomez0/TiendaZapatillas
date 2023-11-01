using TiendaZapatillas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaZapatillas.Admin
{
    public partial class DetMovimiento : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string nID = Request.QueryString["id"];
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Detalles_Movimientos cd " +
                    "inner join products p on p.ProductID=cd.Product_ProductID" +
                    " where movimientos_ID_Movimento=" + nID, gv_detmov);


            }

        }
        public IQueryable<movimientos> GetMovimiento([QueryString("id")] int? ID_Movimiento)
        {
            var _db = new TiendaZapatillas.Models.ProductContext();
            IQueryable<movimientos> query = _db.movimientos;
            if (ID_Movimiento.HasValue && ID_Movimiento > 0)
            {
                query = query.Where(p => p.ID_Movimiento == ID_Movimiento);
            }
            else
            {
                query = null;
            }
            return query;
        }       
    }
}