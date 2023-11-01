using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaZapatillas.Models;
using TiendaZapatillas.Logic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;

namespace TiendaZapatillas.Gerente
{
    public partial class ProductosGerente : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * FROM Products p INNER JOIN GeneroCategories g ON" +
                    " p.GenCategoryID = g.GenCategoryID INNER JOIN TypeCategories t ON p.TypeCategoryID = t.TypeCategoryID" +
                    " inner join Marcas ca on ca.MarcaID=p.MarcaID", gridproductos);
            }
        }

        public IQueryable GetMarcas()
        {
            var _db = new TiendaZapatillas.Models.ProductContext();
            IQueryable query = _db.Marcas;
            return query;
        }

    }
}