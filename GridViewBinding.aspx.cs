using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace binding_prueba
{
    public partial class GridViewBinding : System.Web.UI.Page
    {

        // DATABIND en GRIDVIEW usando DATAREADER
        private string connectionString = WebConfigurationManager.ConnectionStrings["Northwnd"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectSQL = "SELECT * FROM Products; SELECT* FROM Categories";
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(selectSQL, con);
                // Open the connection.
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ProductsGrid.DataSource = rdr;
                    ProductsGrid.DataBind();

                    while (rdr.NextResult())
                    {
                        CategoriesGrid.DataSource = rdr;
                        CategoriesGrid.DataBind();

                    }

                }

            }
        }
    }
}