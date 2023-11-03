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
    public partial class TransaccionesAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT o.OrderID as ID, o.OrderDate as Date, o.UserName as usuarion," +
                    " SUM(od.totalprod) as Total FROM Orders o INNER JOIN OrderDetails od ON od.OrderId = o.OrderId " +
                    "GROUP BY o.OrderID, o.OrderDate, o.UserName order by o.OrderID desc", tablatrans);
            }
        }
       
        protected void imgordenes_Click(object sender, ImageClickEventArgs e)
        {
            int id2 = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Gerente/Detalles_Transacciones.aspx?id2=" + id2);

        }
    }
}