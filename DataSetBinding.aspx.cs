using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace binding_prueba
{
    public partial class DataSetBinding : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                FillAuthorListDataSet();
            }
        }

        private void FillAuthorListDataSet()
        {
            lstAuthor.Items.Clear();
            // Definimos el Select
            // Necesitamos tres campos de informacion:  unique id
            // y first and last name.
            string selectSQL = "SELECT au_lname, au_fname, au_id FROM Authors";
            // Define the ADO.NET objects.
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);

            // A continuacion definimos el Adapter, que representara al comando SELECT y a la conexion a la base de datos,
            // y a el DataSet

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsPubs = new DataSet();
            // Abrimos la base de datos y rellenamos el DataSet.
            try
            {
                // Toda la informacion para transferir y rellenar el DataSet se hace con una instruccion: adapter.Fill(dsPubs, "Authors");
                // que crea una DataTable (llamada Authors)
                // dentro del DataSet.
                con.Open();
                adapter.Fill(dsPubs, "Authors");
            }
            catch (Exception err)
            {
                lblResults.Text = "Error reading list of names. ";
                lblResults.Text += err.Message;
            }
            finally
            {
                con.Close();
            }

            /*  foreach (DataRow row in dsPubs.Tables["Authors"].Rows)
              {
                  ListItem newItem = new ListItem();
                  newItem.Text = row["au_lname"] + ", " +
                  row["au_fname"];
                  newItem.Value = row["au_id"].ToString();
                  lstAuthor.Items.Add(newItem);*/

            lstAuthor.DataSource = dsPubs.Tables["Authors"];
            lstAuthor.DataTextField = "au_lname";
            lstAuthor.DataValueField = "au_id";

            this.DataBind();
        }

        protected void lstAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {


            string selectSQL;
            selectSQL = "SELECT * FROM Authors ";
            selectSQL += "WHERE au_id='" + lstAuthor.SelectedItem.Value + "'";
            // Define the ADO.NET objects.
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;
            // Try to open database and read information.
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                // Build a string with the record information,
                // and display that in a label.
                StringBuilder sb = new StringBuilder();
                sb.Append("<b>");
                sb.Append(reader["au_lname"]);
                sb.Append(", ");
                sb.Append(reader["au_fname"]);
                sb.Append("</b><br />");
                sb.Append("Phone: ");
                sb.Append(reader["phone"]);
                sb.Append("<br />");
                sb.Append("Address: ");
                sb.Append(reader["address"]);
                sb.Append("<br />");
                sb.Append("City: ");
                sb.Append(reader["city"]);
                sb.Append("<br />");
                sb.Append("State: ");
                sb.Append(reader["state"]);
                sb.Append("<br />");
                lblResults.Text = sb.ToString();
                reader.Close();
            }
            catch (Exception err)
            {
                lblResults.Text = "Error getting author. ";
                lblResults.Text += err.Message;
            }
            finally
            {
                con.Close();
            }



        }
    }
}