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
                this.databasecrud("TiendaZapatillas", "SELECT * from Orders order by OrderDate desc", tablatrans);

            }
        }
        private void databasecrud(string conexion, string comando, GridView tabla)
        {
            string constr = ConfigurationManager.ConnectionStrings[conexion].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(comando, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                }
            }
            //Required for jQuery DataTables to work.
            tabla.UseAccessibleHeader = true;
            tabla.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void imgordenes_Click(object sender, ImageClickEventArgs e)
        {
            int id2 = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Gerente/Detalles_Transacciones.aspx?id2=" + id2);

        }
    }
}