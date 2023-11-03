using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaZapatillas.Models;
using TiendaZapatillas.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using System.Data.SqlClient;

namespace TiendaZapatillas
{
    public partial class ShoppingCart : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                List<CartItem> myOrderList = usersShoppingCart.GetCartItems();
                String cartId = usersShoppingCart.GetCartId();
                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int j = 0; j < CartList.Rows.Count; j++)
                {
                    if (myOrderList[j].Product.stock <= 0 || (myOrderList[j].Product.stock < myOrderList[j].Quantity))
                    {

                        IOrderedDictionary rowValues = new OrderedDictionary();
                        rowValues = GetValues(CartList.Rows[j]);
                        cartUpdates[j].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                        CheckBox cbRemove = new CheckBox();
                        cbRemove = (CheckBox)CartList.Rows[j].FindControl("Remove");
                        cbRemove.Checked = true;

                        usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                        CartList.DataBind();
                        lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());

                        usersShoppingCart.GetCartItems();

                    }
                    UpdateCartItems();
                }

                if (cartTotal > 0)
                {
                    // Muestra el total
                    lblTotal.Text = String.Format("{0:c}", cartTotal);

                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "El carrito esta vacio, elige un producto";
                    UpdateBtn.Visible = false;
                    Pagarbtn.Visible = false;
                }
            }

        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }
        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }

        protected void Pagarbtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
            //if (ValidateStock())
            //{
            //    // Redirige al proceso de pago
                Response.Redirect("~/Checkout/Pagocard.aspx?total=" + lblTotal.Text);
            }
            //else
            //{
            //    ShoppingCartTitle.InnerText = "El producto no tiene tanto stock";

            //}
        

        private bool ValidateStock()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                List<CartItem> cartItems = usersShoppingCart.GetCartItems();
                bool valid = true;

                foreach (GridViewRow row in CartList.Rows)
                {
                    int productId = Convert.ToInt32(CartList.DataKeys[row.RowIndex].Value);
                    int requestedQuantity = Convert.ToInt32(((TextBox)row.FindControl("PurchaseQuantity")).Text);

                    // Obtén la cantidad en stock para el producto actual (debes implementar este método)
                    int stockQuantity = GetStockQuantity(productId);

                    if (requestedQuantity > stockQuantity)
                    {
                        // La cantidad solicitada es mayor que el stock disponible, muestra un mensaje de error
                        ShoppingCartTitle.InnerText = "El producto no tiene tanto stock";
                        valid = false;
                        // Puedes mostrar un mensaje de error o tomar alguna acción aquí
                    }
                }

                return valid;
            }
        }

        // Método para obtener la cantidad en stock desde la base de datos (debes implementarlo)
        private int GetStockQuantity(int productId)
        {
            int stockQuantity = 0; // Inicializa la cantidad en stock

            string connectionString = "TiendaZapatillas"; 
            string query = "SELECT stock FROM Products WHERE ProductID = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stockQuantity = reader.GetInt32(0); // La columna 0 contiene la cantidad en stock
                        }
                    }
                }
            }

            return stockQuantity;
        }




    }
}
