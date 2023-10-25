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
        string connectionString = ConfigurationManager.ConnectionStrings["TiendaZapatillas"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.databasecrud(connectionString, "SELECT * FROM Products p INNER JOIN GeneroCategories g ON" +
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


        void databasecrud(string conexion, string sqlcomando, GridView tablag)
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conexion))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlcomando, sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                tablag.DataSource = dtbl;
                tablag.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                tablag.DataSource = dtbl;
                tablag.DataBind();
                tablag.Rows[0].Cells.Clear();
                tablag.Rows[0].Cells.Add(new TableCell());
                tablag.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                tablag.Rows[0].Cells[0].Text = "No se encontraron productos..!";
                tablag.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            tablag.UseAccessibleHeader = true;
            tablag.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}