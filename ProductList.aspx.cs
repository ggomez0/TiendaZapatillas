using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaZapatillas.Models;
using System.Web.ModelBinding;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TiendaZapatillas
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Nike"]))
            {
                // Recupera el valor del parámetro "category".
                string category = Request.QueryString["Nike"];

                // Asigna el valor al DropDownList correspondiente.
                DropDownList1.SelectedValue = category;

                // Llama a la función de búsqueda o método necesario para aplicar el filtro.
                // En este caso, podrías llamar a tu función btnSearch_Click o similar.
                btnSearch_Click(sender, e);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Adidas"]))
            {
                // Recupera el valor del parámetro "category".
                string category = Request.QueryString["Adidas"];

                // Asigna el valor al DropDownList correspondiente.
                DropDownList1.SelectedValue = category;

                // Llama a la función de búsqueda o método necesario para aplicar el filtro.
                // En este caso, podrías llamar a tu función btnSearch_Click o similar.
                btnSearch_Click(sender, e);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["NewBalance"]))
            {
                // Recupera el valor del parámetro "category".
                string category = Request.QueryString["NewBalance"];

                // Asigna el valor al DropDownList correspondiente.
                DropDownList1.SelectedValue = category;

                // Llama a la función de búsqueda o método necesario para aplicar el filtro.
                // En este caso, podrías llamar a tu función btnSearch_Click o similar.
                btnSearch_Click(sender, e);
            }

        }

   


        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
        }
    }
}