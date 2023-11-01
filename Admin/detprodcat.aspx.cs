using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaZapatillas.Admin
{
    public partial class detprodcat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nID = Request.QueryString["id4"];
                lblcatprod.Text += nID;
                DatabaseUtility.mostrarorder("TiendaZapatillas", "select ProductID as #,ProductName as Producto, " +
                    "Description as Descripcion, Unitprice as Precio from Products where MarcaID = @catid",gvdetprodcat,nID,"@catid");
            }
        }

    }
}
        