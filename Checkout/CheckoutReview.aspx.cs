using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaZapatillas.Models;

namespace TiendaZapatillas.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            // Get the shopping cart items and process them.
            using (TiendaZapatillas.Logic.ShoppingCartActions usersShoppingCart = new TiendaZapatillas.Logic.ShoppingCartActions())
            {
                List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                // Add OrderDetail information to the DB for each product purchased.


                // Display OrderDetails.
                OrderItemList.DataSource = myOrderList;
                OrderItemList.DataBind();
            }
        }
    }
}
 