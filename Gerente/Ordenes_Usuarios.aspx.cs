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
    public partial class Ordenes_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nID = Request.QueryString["id1"];
                lblord.Text += nID;
                DatabaseUtility.mostrarorder("TiendaZapatillas", "select * from Orders where Username = @idorder", gvordenesusuario, nID,"@idorder");
            }
        }

        protected void imgbtn1_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Gerente/Detalles_Ordenes_Usuarios.aspx?id=" + id);
        }

    }
}