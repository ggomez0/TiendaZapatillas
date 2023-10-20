using TiendaZapatillas.Logic;
using TiendaZapatillas.Models;
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
    public partial class CategoriaTipo : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        string connectionString = ConfigurationManager.ConnectionStrings["TiendaZapatillas"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.databasecrud(connectionString, "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);

            }

        }

        protected void Addtipo_Click(object sender, EventArgs e)
        {
            using (ProductContext _db = new ProductContext())
            {
                // Verificar si ya existe una categoría con el mismo nombre.
                if (!_db.TypeCategories.Any(c => c.TypeCategoryName == lblAddTipo.Text))
                {
                    AddTypeCategory typeCategory = new AddTypeCategory();

                    bool addSucces = typeCategory.AddTypeCat(lblAddTipo.Text);

                    if (addSucces)
                    {
                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?ProductAction=addcat");
                    }
                    else
                    {
                        lbladdtipostatus.Text = "No se pudo agregar la categoria a la base de datos";
                    }
                }
            }
        }

        protected void gvtipotab_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvtipotab.EditIndex = e.NewEditIndex;
            this.databasecrud(connectionString, "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);
        }

        protected void gvtipotab_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvtipotab.EditIndex = -1;
            this.databasecrud(connectionString, "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);
        }

        protected void gvtipotab_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (ProductContext _db = new ProductContext())
                {
                    // Verificar si ya existe una categoría con el mismo nombre.
                    TextBox txttipoNameedit = gvtipotab.Rows[e.RowIndex].FindControl("txttipoNameedit") as TextBox;
                    if (!_db.TypeCategories.Any(c => c.TypeCategoryName == txttipoNameedit.Text))
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            string query = "UPDATE TypeCategories SET TypeCategoryName=@ProductName WHERE TypeCategoryID = @ProductID";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@ProductName", (gvtipotab.Rows[e.RowIndex].FindControl("txttipoNameedit") as TextBox).Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(gvtipotab.DataKeys[e.RowIndex].Value.ToString()));
                            sqlCmd.ExecuteNonQuery();
                            gvtipotab.EditIndex = -1;
                            this.databasecrud(connectionString, "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);
                            lblSuccessMessage.Text = "Categoria actualizado con exito";
                            lblErrorMessage.Text = "";
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "Categoria ya existente";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
            Response.Redirect("~/Admin/CategoriaTipo.aspx");

        }

        protected void gvtipotab_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM TypeCategories WHERE TypeCategoryID = @ProductID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(gvtipotab.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    this.databasecrud(connectionString, "SELECT TypeCategoryID, TypeategoryName from TypeCategories", gvtipotab);
                    lblSuccessMessage.Text = "Categoria eliminado con exito";
                    lblErrorMessage.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;

            }
            Response.Redirect("~/Admin/CategoriaTipo.aspx");

        }

        protected void gvtipotab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void btndettipo_Click(object sender, ImageClickEventArgs e)
        {
            int id4 = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Admin/detprodcat.aspx?id4=" + id4);
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
                tablag.Rows[0].Cells[0].Text = "No se encontraron Tipos de calzado..!";
                tablag.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            tablag.UseAccessibleHeader = true;
            tablag.HeaderRow.TableSection = TableRowSection.TableHeader;
        }


    }
}