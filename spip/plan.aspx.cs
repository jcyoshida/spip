using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Text;

namespace spip
{
    public partial class plan : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            MySqlConnection myConnection = new MySqlConnection(connectionString);
            MySqlCommand myCommand = new MySqlCommand("SELECT id, title FROM goal",myConnection);
            string selectSQL = "SELECT id,title FROM goal";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQL, myConnection);
            DataSet ds = new DataSet();

            try
            {
                myConnection.Open();

                adapter.Fill(ds, "Goals");
                mygv.DataSource = ds;
                mygv.DataBind();
                
                //lblInfo.Text = "Server Ver." + myConnection.ServerVersion;

            }
            catch (Exception err)
            {
                lblInfo.Text = "error reading the db.";
                lblInfo.Text += err.Message;
            }
            finally
            {
                myConnection.Close();
            }

           
        }
        protected void mygv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                
                int g = (int)DataBinder.Eval(e.Row.DataItem, "id");
                e.Row.Attributes["data-href"] = "planb.aspx?choice="+g;
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Testing');", true);
            }
        }
    }
}