using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Configuration;


namespace spip
{
    public partial class planb : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string goal = Request.QueryString["choice"];
            lbldti.Text = "<strong>GOAL " + goal + ":</strong>";

            MySqlConnection myConnection = new MySqlConnection(connectionString);
            string selectSQL = "SELECT title FROM goal WHERE id='" + goal + "'";
            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);
            string selectSQLtwo = "SELECT id,objNum,objDesc FROM objective WHERE gid='" + goal + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLtwo, myConnection);
            DataSet ds = new DataSet();

            try
            {
                myConnection.Open();
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();
                disabledTextInput.Text = reader["title"].ToString();
                reader.Close();

                adapter.Fill(ds, "Objectives");
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
            string goal = Request.QueryString["choice"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

                int g = (int)DataBinder.Eval(e.Row.DataItem, "id");
                e.Row.Attributes["data-href"] = "planc.aspx?g=" + goal + "&o=" + g;
            }
        }
    }
}