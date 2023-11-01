using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TiendaZapatillas.Models;
using TiendaZapatillas.Logic;
using System.Web.Services;
using System.Web.Script.Services;

namespace TiendaZapatillas.Admin
{
    public partial class IngEgrAdmin : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "select * from movimientos c inner join depositos d on c.stringn=d.DepID " +
                    "where not Nombre='NULL' order by ID_Movimiento desc", gvhistorial);
            }
        }

        protected void btnmov_Click(object sender, EventArgs e)
        {
            addmovimiento addmov = new addmovimiento();
            bool addSuccess = addmov.addmovimientos(null, null, 0, 0, null, null,null);


            if (addSuccess)
            {
                Response.Redirect("~/Admin/Nuevo_Movimiento.aspx");
            }
            
        }

        protected void btn_det_mov_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Admin/DetMovimiento.aspx?id=" + id);

        }
    }
}