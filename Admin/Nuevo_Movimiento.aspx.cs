using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using TiendaZapatillas.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace TiendaZapatillas.Admin
{
    public partial class Nuevo_Movimiento : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        string connectionString = ConfigurationManager.ConnectionStrings["TiendaZapatillas"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT ProductID as ID,ProductName as Producto,Description as " +
                   "Descripcion,UnitPrice as Precio,MarcaID,Stock FROM Products", gvproductoslista);



                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string result = "select max(ID_Movimiento) from movimientos";
                    SqlCommand showresult = new SqlCommand(result, conn);

                    conn.Open();
                    string nummov = showresult.ExecuteScalar().ToString();
                    txtidmov.Text = nummov;
                    conn.Close();
                }

                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Detalles_Movimientos cd inner join products p on p.ProductID=cd.Product_ProductID" +
                    " where movimientos_ID_Movimiento=" + Convert.ToInt32(txtidmov.Text), gvprodmov);
            }
        }

        public IQueryable GetDepositos()
        {
            var _db = new TiendaZapatillas.Models.ProductContext();
            IQueryable query = _db.depositos;
            return query;
        }

        protected void gvproductoslista_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "insert into Detalles_Movimientos(cantidad,Product_ProductID,movimientos_ID_Movimientos) values (@cantped,@product,@idpedido);";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@cantped", Convert.ToInt32((gvproductoslista.Rows[e.RowIndex].FindControl("txtcantpedido") as TextBox).Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@idpedido", Convert.ToInt32((txtidmov.Text).ToString()));
                    sqlCmd.Parameters.AddWithValue("@product", Convert.ToInt32(gvproductoslista.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();
                    gvproductoslista.EditIndex = -1;
                    lblSuccessMessage.Text = "Agregado con exito";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void btnguardarmov_Click(object sender, EventArgs e)
        {
            if (rblistlist.Items[0].Selected)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "update movimientos set Nombre='Ingreso', descripcion=@Observaciones, stringn=@Depositos where ID_Movimiento=@ID_Movimiento";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Observaciones", txtobsmov.Text);
                    sqlCmd.Parameters.AddWithValue("@ID_Movimiento", Convert.ToInt32((txtidmov.Text).ToString()));
                    sqlCmd.Parameters.AddWithValue("@Depositos", ddlistdep.SelectedValue);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }


                foreach (GridViewRow row in gvprodmov.Rows)
                {
                    using (SqlConnection sqlCon1 = new SqlConnection(connectionString))
                    {
                        sqlCon1.Open();
                        string query1 = "UPDATE Products SET stock = stock + @stock WHERE ProductID in (select ProductID from Products where ProductName = @Productos) ";
                        SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                        sqlCmd1.Parameters.AddWithValue("@stock", Convert.ToInt32((gvprodmov.Rows[row.RowIndex].FindControl("lblcantmov") as Label).Text.Trim()));
                        sqlCmd1.Parameters.AddWithValue("@Productos", (gvprodmov.Rows[row.RowIndex].FindControl("lblprodmov") as Label).Text.Trim());
                        sqlCmd1.ExecuteNonQuery();
                        sqlCon1.Close();
                    }

                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "IF EXISTS(SELECT* FROM prodendeps WHERE Depositos_DepID = @Depositos and (prodendeps.Product_ProductID in " +
                            "(select ProductID from Products where ProductName = @Productos))) BEGIN UPDATE prodendeps " +
                            "SET cantingreso = cantingreso + @cantingreso WHERE Depositos_DepID = @Depositos and " +
                            "(prodendeps.Product_ProductID in (select ProductID from Products where ProductName = @Productos)); END ELSE BEGIN insert into " +
                            "prodendeps(cantingreso, Depositos_DepID, Product_ProductID) values(@cantingreso, @Depositos, " +
                            "(select ProductID from Products where ProductName = @Productos)); END";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@cantingreso", Convert.ToInt32((gvprodmov.Rows[row.RowIndex].FindControl("lblcantmov") as Label).Text.Trim()));
                        sqlCmd.Parameters.AddWithValue("@Productos", (gvprodmov.Rows[row.RowIndex].FindControl("lblprodmov") as Label).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Depositos", ddlistdep.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }

            }

            if (rblistlist.Items[1].Selected)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "update movimientos set Nombre='Egreso', descripcion=@Observaciones, stringn=@Depositos where ID_Movimiento=@ID_Movimiento";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Observaciones", txtobsmov.Text);
                    sqlCmd.Parameters.AddWithValue("@ID_Movimiento", Convert.ToInt32((txtidmov.Text).ToString()));
                    sqlCmd.Parameters.AddWithValue("@Depositos", ddlistdep.SelectedValue);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                foreach (GridViewRow row in gvprodmov.Rows)
                {
                    using (SqlConnection sqlCon1 = new SqlConnection(connectionString))
                    {
                        sqlCon1.Open();
                        string query1 = "UPDATE Products SET stock = stock - @stock WHERE ProductID in (select ProductID from Products where ProductName = @Productos) ";
                        SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                        sqlCmd1.Parameters.AddWithValue("@stock", Convert.ToInt32((gvprodmov.Rows[row.RowIndex].FindControl("lblcantmov") as Label).Text.Trim()));
                        sqlCmd1.Parameters.AddWithValue("@Productos", (gvprodmov.Rows[row.RowIndex].FindControl("lblprodmov") as Label).Text.Trim());

                        sqlCmd1.ExecuteNonQuery();
                    }
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "IF EXISTS(SELECT* FROM prodendeps WHERE Depositos_DepID = @Depositos and (prodendeps.Product_ProductID in " +
                            "(select ProductID from Products where ProductName = @Productos))) BEGIN UPDATE prodendeps " +
                            "SET cantingreso = cantingreso - @cantingreso WHERE Depositos_DepID = @Depositos and " +
                            "(prodendeps.Product_ProductID in (select ProductID from Products where ProductName = @Productos)); END ELSE BEGIN insert into " +
                            "prodendeps(cantingreso, Depositos_DepID, Product_ProductID) values(@cantingreso, @Depositos, " +
                            "(select ProductID from Products where ProductName = @Productos)); END";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@cantingreso", Convert.ToInt32((gvprodmov.Rows[row.RowIndex].FindControl("lblcantmov") as Label).Text.Trim()));
                        sqlCmd.Parameters.AddWithValue("@Productos", (gvprodmov.Rows[row.RowIndex].FindControl("lblprodmov") as Label).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Depositos", ddlistdep.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }

            }
            Response.Redirect("~/Admin/IngEgrAdmin.aspx");

        }

        protected void gvprodmov_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "delete from Detalles_Movimientos where ID_Det_Movimientoss=@id;";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvprodmov.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();
                    gvproductoslista.EditIndex = -1;
                    lblSuccessMessage.Text = "Agregado con exito";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
            Response.Redirect(Request.RawUrl);

        }
    }
}









