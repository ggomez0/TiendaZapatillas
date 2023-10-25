using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaZapatillas.Models;

namespace TiendaZapatillas.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ordencompra.Text = Request.QueryString["id"];
            if (!IsPostBack)
            {             
               
                    // Clear shopping cart.
                    using (TiendaZapatillas.Logic.ShoppingCartActions usersShoppingCart =
                        new TiendaZapatillas.Logic.ShoppingCartActions())
                    {
                        usersShoppingCart.EmptyCart();
                    }                
                }
        }
        
        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}