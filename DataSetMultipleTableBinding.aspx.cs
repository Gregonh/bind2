using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace binding_prueba
{
    public partial class DataSetMultipleTableBinding : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Northwnd"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                /*consulta para hacer el procedimiento
                 * 
                 * CREATE PROCEDURE [dbo].spCategoriesProducts
                    AS
                    SELECT * from Categories
                    SELECT * from Products
                    RETURN 0
                 * 
                 * */
                SqlDataAdapter adapter = new SqlDataAdapter("spCategoriesProducts", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                // La primera tabla se rellena con el primer SELECT


                //GridView1.DataSource = ds.Tables[0]
                //GridView1.DataSource = ds.Tables["Table"]
                ds.Tables[0].TableName = "Categories";

                GridView1.DataSource = ds.Tables["Categories"];


                GridView1.DataBind();

                // GridView2.DataSource = ds.Tables[1]
                //GridView1.DataSource = ds.Tables["Table1"]
                ds.Tables[1].TableName = "Products";

                GridView2.DataSource = ds.Tables["Products"];


                GridView2.DataBind();

            }
        }
    }
}