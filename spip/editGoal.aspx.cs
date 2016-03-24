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
    public partial class editGoal : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                fillFields();

            }
        }
        private void fillFields()
        {
            string record = Request.QueryString["r"];

            MySqlConnection myConnection = new MySqlConnection(connectionString);
            string selectSQL = "SELECT * FROM goal WHERE id='" + record + "'";

            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);


            try
            {
                myConnection.Open();
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();

                string goal = reader["id"].ToString();
                string goalDesc = reader["title"].ToString();
                string goalLongDesc = reader["desc"].ToString();

                reader.Close();

                lbldti.Text = "<strong>GOAL " + goal + "</strong>";
                //lbldti2.Text = "<strong>OBJECTIVE " + obj + ":</strong>";
                //lbldti3.Text = "<strong>STRATEGY " + strat + ":</strong>";



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
    }
}
