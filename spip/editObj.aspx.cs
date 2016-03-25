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
    public partial class editObj : System.Web.UI.Page
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
            string selectSQL = "SELECT * FROM objective WHERE id='" + record + "'";

            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);


            try
            {
                myConnection.Open();
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();

                string obj = reader["objNum"].ToString();
                string objDesc = reader["objDesc"].ToString();
                string objLongDesc = reader["objDesc2"].ToString();

                reader.Close();

                lbldti.Text = "<strong>OBJECTIVE " + obj + "</strong>";
                objDescTxt.Text = objDesc;
                objLongDescTxt.Text = objLongDesc;

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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string record = Request.QueryString["r"];

            string updateSQL = "UPDATE objective SET objDesc = @objDesc, objDesc2 = @desc WHERE id = @record";
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(updateSQL, con);
            try
            {
                con.Open();
                string titleTxt = objDescTxt.Text;
                string descTxt = objLongDescTxt.Text;
                cmd.Parameters.AddWithValue("@objDesc", titleTxt);
                cmd.Parameters.AddWithValue("@desc", descTxt);
                cmd.Parameters.AddWithValue("@record", record);
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                lblInfo.Text = "error: ";
                lblInfo.Text += err.Message;
            }
            finally
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "showalert", "alert('Goal Updated')", true);
                con.Close();
                Response.Redirect("~/objectives.aspx");
            }
        }
    }
}
