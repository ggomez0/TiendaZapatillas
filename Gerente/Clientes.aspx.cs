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
using System.Windows.Forms;

namespace TiendaZapatillas.Gerente
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DatabaseUtility.DatabaseCrud("defaultconnection", "SELECT a.Email, a.UserName, COALESCE(c.Name, 'CLIENTES') AS Rol FROM aspnetusers a " +
                    "LEFT JOIN aspnetuserroles b ON a.Id = b.UserId " +
                    "LEFT JOIN aspnetroles c ON b.RoleId = c.Id;", tablausers);

            }
        }

        protected void imgord_Click(object sender, ImageClickEventArgs e)
        {
            string id1 = (sender as ImageButton).CommandArgument;
            Response.Redirect("~/Gerente/Ordenes_Usuarios.aspx?id1=" + id1);

        }
    }
}