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
    public partial class planc : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string goal = Request.QueryString["g"];
            string obj = Request.QueryString["o"];
            lbldti.Text = "<strong>GOAL " + goal + ":</strong>";
            lbldti2.Text = "<strong>OBJECTIVE " + obj + ":</strong>";

            MySqlConnection myConnection = new MySqlConnection(connectionString);
            string selectSQL = "SELECT title FROM goal WHERE id='" + goal + "'";
            string selectSQL2 = "SELECT objDesc FROM objective WHERE id='" + obj + "'";
            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);
            MySqlCommand cmd2 = new MySqlCommand(selectSQL2, myConnection);
            string selectSQL3 = "SELECT * FROM strategy WHERE objID='" + obj + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQL3, myConnection);
            DataSet ds = new DataSet();

            try
            {
                myConnection.Open();
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();
                disabledTextInput.Text = reader["title"].ToString();
                reader.Close();
                reader = cmd2.ExecuteReader();
                reader.Read();
                disabledTextInput2.Text = reader["objDesc"].ToString();
                reader.Close();

                adapter.Fill(ds, "Strategies");
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
            string goal = Request.QueryString["g"];
            string obj = Request.QueryString["o"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

                int g = (int)DataBinder.Eval(e.Row.DataItem, "id");
                e.Row.Attributes["data-href"] = "ap.aspx?g=" + goal + "&o=" + obj + "&s=" +g;
            }
        }
    }
}