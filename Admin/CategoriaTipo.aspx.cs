﻿using TiendaZapatillas.Logic;
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
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);

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
            DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);
        }

        protected void gvtipotab_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvtipotab.EditIndex = -1;
            DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);
        }

        protected void gvtipotab_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
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
                    DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT TypeCategoryID, TypeCategoryName from TypeCategories", gvtipotab);
                    lblSuccessMessage.Text = "Categoria actualizado con exito";
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
                    DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT TypeCategoryID, TypeategoryName from TypeCategories", gvtipotab);
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


    }
}