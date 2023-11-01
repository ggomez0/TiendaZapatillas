using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaZapatillas.Gerente
{
    public partial class MenuGerente : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TiendaZapatillas"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Ingresos del mes actual
                    string resultMesActual = "SELECT SUM(od.totalprod) FROM OrderDetails od INNER JOIN Orders o ON o.OrderId = od.OrderID WHERE DATEPART(MONTH, o.OrderDate) = DATEPART(MONTH, GETDATE())";
                    SqlCommand showresultMesActual = new SqlCommand(resultMesActual, conn);
                    decimal ingresosMesActual = Convert.ToDecimal(showresultMesActual.ExecuteScalar());
                    lblingmes.Text += ingresosMesActual.ToString("$0,0.000");

                    // Ingresos del año actual
                    string resultAnioActual = "SELECT SUM(od.totalprod) FROM OrderDetails od INNER JOIN Orders o ON o.OrderId = od.OrderID WHERE DATEPART(YEAR, o.OrderDate) = DATEPART(YEAR, GETDATE())";
                    SqlCommand showresultAnioActual = new SqlCommand(resultAnioActual, conn);
                    decimal ingresosAnioActual = Convert.ToDecimal(showresultAnioActual.ExecuteScalar());
                    lblinganual.Text += ingresosAnioActual.ToString("$0,0.000");

                    // Órdenes del mes actual
                    string resultOrdenesMesActual = "SELECT COUNT(OrderId) FROM Orders WHERE DATEPART(MONTH, OrderDate) = DATEPART(MONTH, GETDATE())";
                    SqlCommand showresultOrdenesMesActual = new SqlCommand(resultOrdenesMesActual, conn);
                    int ordenesMesActual = Convert.ToInt32(showresultOrdenesMesActual.ExecuteScalar());
                    lblordmes.Text += ordenesMesActual.ToString();

                    // Órdenes del año actual
                    string resultOrdenesAnioActual = "SELECT COUNT(OrderId) FROM Orders WHERE DATEPART(YEAR, OrderDate) = DATEPART(YEAR, GETDATE())";
                    SqlCommand showresultOrdenesAnioActual = new SqlCommand(resultOrdenesAnioActual, conn);
                    int ordenesAnioActual = Convert.ToInt32(showresultOrdenesAnioActual.ExecuteScalar());
                    lblordanio.Text += ordenesAnioActual.ToString();


                    conn.Close();
                }
            }

        }

        protected string datosPieChartSQL()
        {

            SqlConnection redSQL = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT top 5 ProductName, vendido from Products order by vendido desc";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = redSQL;
            redSQL.Open();

            DataTable gdatos = new DataTable();
            gdatos.Load(cmd.ExecuteReader());
            redSQL.Close();

            string xdata;
            xdata = "[['ProductName','vendido'],";
            foreach (DataRow dr in gdatos.Rows)
            {
                xdata = xdata + "[";
                xdata = xdata + "'" + dr[0] + "'" + "," + dr[1].ToString();
                xdata = xdata + "],";
            }

            xdata = xdata + "]";
            return xdata;
        }

        protected string datosColumnChartSQL()
        {

            SqlConnection redSQL = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CONCAT(YEAR(o.OrderDate), '-', MONTH(o.OrderDate)) AS Fecha," +
                " sum(od.totalprod) as Ingresos FROM Orders o inner join OrderDetails od on od.OrderId=o.OrderId" +
                " GROUP BY YEAR(OrderDate), MONTH(OrderDate) order by YEAR(OrderDate), MONTH(OrderDate) asc";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = redSQL;
            redSQL.Open();

            DataTable gdatos = new DataTable();
            gdatos.Load(cmd.ExecuteReader());
            redSQL.Close();

            string xdata;
            xdata = "[['Fecha','Ingresos'],";
            foreach (DataRow dr in gdatos.Rows)
            {
                xdata = xdata + "[";
                xdata = xdata + "'" + dr[0] + "'" + "," + dr[1].ToString();
                xdata = xdata + "],";
            }

            xdata = xdata + "]";
            return xdata;
        }
        protected string datosBarChartSQL()
        {

            SqlConnection redSQL = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select a.userName as Cliente, sum(totalprod) as Compras from Aspnetusers a inner join Orders o on a.UserName=o.Username inner join OrderDetails od on od.OrderId=o.OrderId group by a.UserName";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = redSQL;
            redSQL.Open();

            DataTable gdatos = new DataTable();
            gdatos.Load(cmd.ExecuteReader());
            redSQL.Close();

            string xdata;
            xdata = "[['Cliente','Compras'],";
            foreach (DataRow dr in gdatos.Rows)
            {
                xdata = xdata + "[";
                xdata = xdata + "'" + dr[0] + "'" + "," + dr[1].ToString();
                xdata = xdata + "],";
            }

            xdata = xdata + "]";
            return xdata;
        }
    }
}