using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Postgrest;

public class DatabaseUtility
{
    public static void DatabaseCrud(string connectionName, string query, GridView table)
    {
        DataTable dtbl = new DataTable();
        string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            sqlDa.Fill(dtbl);
        }
        if (dtbl.Rows.Count > 0)
        {
            table.DataSource = dtbl;
            table.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            table.DataSource = dtbl;
            table.DataBind();
            table.Rows[0].Cells.Clear();
            table.Rows[0].Cells.Add(new TableCell());
            table.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            table.Rows[0].Cells[0].Text = "No se encontraron registros";
            table.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }
        table.UseAccessibleHeader = true;
        table.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public static void mostrarorder(string connectionName, string query, GridView table, string input, string output)
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ToString());
        SqlCommand cmd = new SqlCommand();
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDA;
        cnn.Open();
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue(output, input);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;
        sqlDA = new SqlDataAdapter(cmd);
        sqlDA.Fill(dataTable);
        table.DataSource = dataTable;
        table.DataBind();
        cnn.Close();
        table.UseAccessibleHeader = true;
        table.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
