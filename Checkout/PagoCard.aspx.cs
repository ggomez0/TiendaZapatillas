using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaZapatillas.Logic;
using TiendaZapatillas.Models;

namespace TiendaZapatillas.Checkout
{

    public partial class PagoCard : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        string connectionString = ConfigurationManager.ConnectionStrings["TiendaZapatillas"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotalca.Text = Request.QueryString["total"];
            using (TiendaZapatillas.Logic.ShoppingCartActions usersShoppingCart = new TiendaZapatillas.Logic.ShoppingCartActions())
            {
                List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                // Add OrderDetail information to the DB for each product purchased.

                OrderItemList.DataSource = myOrderList;
                OrderItemList.DataBind();
            }
        }

        protected void cardbtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddCards cards = new AddCards();
                AddOrder order = new AddOrder();
                bool addSuccess1 = order.AddOrders(DateTime.Now, firstName.Text, lastName.Text, address.Text, phone.Text, email.Text, User.Identity.Name);
                bool addSuccess = cards.AddCard(ccnumber.Text, Convert.ToInt32(cccvv.Text), ccexpiration.Text, ccname.Text);
                int max = _db.Orders.Max(p => p.OrderId);
                this.sendemail(email.Text);
                this.sendemail1();


                using (TiendaZapatillas.Logic.ShoppingCartActions usersShoppingCart = new TiendaZapatillas.Logic.ShoppingCartActions())
                {
                    List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                    // Add OrderDetail information to the DB for each product purchased.
                    for (int i = 0; i < myOrderList.Count; i++)
                    {
                        AddOrderDetails orderDetails = new AddOrderDetails();
                        orderDetails.AddOrdersDetails(max, myOrderList[i].ProductId, myOrderList[i].Product.ProductName, myOrderList[i].Quantity, Convert.ToDouble(myOrderList[i].Product.UnitPrice));
                        updateprod(myOrderList[i].Quantity, myOrderList[i].ProductId);


                    }
                    Response.Redirect("~/Checkout/CheckoutComplete.aspx?id=" + max);

                }
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "declare @id int = (select max(OrderId) from Orders); declare @totalprod int = (select sum(totalprod) from OrderDetails where OrderId=@id); update Orders set Total=@totalprod where OrderId=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();

                }
                if (addSuccess & addSuccess1)
                {

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());



                }
                else
                {
                    lblcard.Text = "El pago ha sido cancelado!";
                }
            }
            catch
            {
                lblcard.Text = "El numero de tarjeta no es valido";
            }
        }

        private void sendemail(string txt1)
        {
            int max = _db.Orders.Max(p => p.OrderId);
            Order order = _db.Orders.SingleOrDefault(o => o.OrderId == max); // Supongamos que tienes una entidad "Order" que contiene los detalles de la orden.
            List<OrderDetail> orderItems = _db.OrderDetails.Where(oi => oi.OrderId == max).ToList(); // Supongamos que tienes una entidad "OrderItem" que contiene los productos de la orden.

            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress("gaspargomez2000@outlook.com", "AltasLlantas");
            mensaje.To.Add(txt1);
            mensaje.Subject = string.Format("Gracias por la compra - Orden #{0}", max);
            mensaje.IsBodyHtml = true; // Habilitamos el formato HTML

            // Cuerpo del correo
            string body = @"
        <html>
        <head>
        <style>
            table {
                border-collapse: collapse;
                width: 100%;
            }

            th, td {
                border: 1px solid #dddddd;
                text-align: left;
                padding: 8px;
            }

            tr:nth-child(even) {
                background-color: #f2f2f2;
            }
        </style>
        </head>
        <body>
        <h1 style='color: #007ACC;'>¡Gracias por tu compra en Altas Llantas!</h1>
        <p>Hola, has realizado la compra en Altas Llantas con éxito. A continuación, encontrarás los detalles de tu compra:</p>

        <table>
            <tr>
                <th>Producto</th>
                <th>Cantidad</th>
                <th>Precio Unitario</th>
                <th>Total</th>
            </tr>";

            foreach (var item in orderItems)
            {

                body += $@"
            <tr>
                <td>{item.ProductName}</td>
                <td>{item.Quantity}</td>
                <td>${item.UnitPrice:0.00}</td>
                <td>${item.totalprod:0.00}</td>
            </tr>";
            }

            body += $@"
        </table>
        <p>Total de la compra: ${order.Total:0.00}</p>
        <p>Para ver todas tus órdenes y detalles, ingresa a <a href='https://localhost:44351/Account/ordersusers'>tu cuenta</a>.</p>
        </body>
        </html>
    ";


            mensaje.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential();
            credenciales.UserName = "gaspargomez2000@outlook.com";
            credenciales.Password = "fpibqmlctvjdfpiu";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = credenciales;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(mensaje);
        }


        private void sendemail1()
        {
            int max = _db.Orders.Max(p => p.OrderId);
            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress("gaspargomez2000@outlook.com", "AltasLlantas");
            mensaje.To.Add("gaspargomez2000@outlook.com");
            mensaje.Subject = string.Format("Venta Realizada - Orden #{0}", max);

            mensaje.IsBodyHtml = false;
            mensaje.Body = ("Hola, has realizado una venta en GamerSalta con exito. Ingresar a tu cuenta para poder visualizar los detalles de la orden");

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential();

            credenciales.UserName = "gaspargomez2000@outlook.com";
            credenciales.Password = "fpibqmlctvjdfpiu";

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = credenciales;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(mensaje);
        }

        private void updateprod(int qty, int id)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Products SET stock = stock - @txtqty, vendido = vendido + @txtqty  WHERE [ProductID] = @id";
                cmd.Parameters.AddWithValue("@txtQty", qty);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = sqlCon;
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}


