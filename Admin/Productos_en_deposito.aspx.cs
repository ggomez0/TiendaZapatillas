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
using TiendaZapatillas.Models;

namespace TiendaZapatillas.Admin
{
    public partial class Productos_en_deposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nID = Request.QueryString["id"];
                DatabaseUtility.mostrarorder("TiendaZapatillas", "select IngID, ProductName as Nombre, cantingreso as Cantidad from prodendeps p inner join " +
                "Products pr on p.Product_ProductID=pr.ProductID where p.Depositos_DepID = @idorder", gvprodendep,nID, "@idorder");
            }
        }

        public IQueryable<depositos> GetDeposito([QueryString("id")] int? pedidoid)
        {
            var _db = new TiendaZapatillas.Models.ProductContext();
            IQueryable<depositos> query = _db.depositos;
            if (pedidoid.HasValue && pedidoid > 0)
            {
                query = query.Where(p => p.DepID== pedidoid);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
    
}