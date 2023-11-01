using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaZapatillas.Gerente
{
    public partial class Detalles_Transacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nID = Request.QueryString["id2"];
                lblord.Text += nID;
                DatabaseUtility.mostrarorder("TiendaZapatillas", "select OrderDetailId as 'ID', Username as 'Usuario'," +
                    "ProductName as 'Producto', Quantity as 'Cantidad'," +
                " UnitPrice as 'Precio Unit.', totalprod as 'Total' from OrderDetails od inner join Orders o " +
                "on od.OrderId=o.OrderId where od.OrderId = @idorder", Grid_Det_Transaccion, nID, "@idorder");
            }
        }
        protected void imgordenes_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Gerente/Detalles_Ordenes_Usuarios.aspx?id=" + id);

        }
    }
}
