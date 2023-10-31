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

namespace TiendaZapatillas.Admin
{
    public partial class EstadisticasAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.SearchCustomers("TiendaZapatillas", "SELECT ProductName, stock, vendido from Products", gvstat);

            }


        }

        private void SearchCustomers(string conexion, string comando, GridView tabla)
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

    }
}