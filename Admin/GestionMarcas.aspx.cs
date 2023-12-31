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
    public partial class GestionMarcas : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        string connectionString = ConfigurationManager.ConnectionStrings["TiendaZapatillas"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Marcas", gvcattab);

            }

        }

        protected void AddCat_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Images/");

            if (imgaddmarca.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(imgaddmarca.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            if (fileOK)
            {
                try
                {
                    imgaddmarca.PostedFile.SaveAs(path + "Thumbs/" + imgaddmarca.FileName);
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }


                using (ProductContext _db = new ProductContext())
                {
                    // Verificar si ya existe una categoría con el mismo nombre.
                    if (!_db.Marcas.Any(c => c.MarcaName == AddCategoria.Text))
                    {
                        // La categoría no existe, así que puedes agregarla.
                        AddMarca marca = new AddMarca();
                        bool addSuccess = marca.AddMarcas(AddCategoria.Text, txtdescmarca.Text, txtpaismarca.Text, imgaddmarca.FileName, txturlmarca.Text);

                        if (addSuccess)
                        {
                            lbladdcatstatus.Text = "La categoría se agregó exitosamente.";
                        }
                        else
                        {
                            lbladdcatstatus.Text = "No se pudo agregar la categoría a la base de datos";
                        }
                        // Luego, redirige la página.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?ProductAction=addcat");
                    }
                    else
                    {
                        // La categoría ya existe, muestra un mensaje de error.
                        lbladdcatstatus.Text = "La categoría ya existe en la base de datos y no se puede agregar nuevamente.";
                    }
                }
            }
        }     

        protected void gvcattab_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvcattab.EditIndex = e.NewEditIndex;
            DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Marcas", gvcattab);
        }

        protected void gvcattab_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvcattab.EditIndex = -1;
            DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Marcas", gvcattab);
        }

        protected void gvcattab_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Marcas SET MarcaName=@MarcaName,Description=@Description,paisorigen=@paisorigen,Imagen_marca=@Imagen_marca,paginaweb_marca=@paginaweb_marca WHERE MarcaID = @ProductID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MarcaName", (gvcattab.Rows[e.RowIndex].FindControl("txtCategoryNameedit") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Description", (gvcattab.Rows[e.RowIndex].FindControl("txteditdescription") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@paisorigen", (gvcattab.Rows[e.RowIndex].FindControl("txteditpais") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Imagen_marca", (gvcattab.Rows[e.RowIndex].FindControl("txteditimagen") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@paginaweb_marca", (gvcattab.Rows[e.RowIndex].FindControl("txtediturl") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(gvcattab.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvcattab.EditIndex = -1;
                DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Marcas", gvcattab);
                lblSuccessMessage.Text = "Marcas actualizada con éxito";
                lblErrorMessage.Text = "";  
            }
            Response.Redirect("~/Admin/GestionMarcas.aspx");
        }



        protected void gvcattab_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Marcas WHERE MarcaID = @ProductID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(gvcattab.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    DatabaseUtility.DatabaseCrud("TiendaZapatillas", "SELECT * from Marcas", gvcattab);
                    lblSuccessMessage.Text = "Marcas eliminado con exito";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
            Response.Redirect("~/Admin/GestionMarcas.aspx");
        }

        protected void gvcattab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void btndetcat_Click(object sender, ImageClickEventArgs e)
        {
            int id4 = Convert.ToInt32((sender as ImageButton).CommandArgument);
            Response.Redirect("~/Admin/detprodcat.aspx?id4=" + id4);
        }
    }
}