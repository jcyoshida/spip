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
    public partial class editStrat : System.Web.UI.Page
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
            string selectSQL = "SELECT * FROM strategy WHERE id='" + record + "'";

            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);


            try
            {
                myConnection.Open();
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();

                string gID = reader["gID"].ToString();
                string objID = reader["objID"].ToString();
                string sNum = reader["stratNum"].ToString();
                string sDesc = reader["stratDesc"].ToString();
                string time = reader["timelines"].ToString();

                reader.Close();

                gidTxt.Text = gID;
                objTxt.Text = objID;
                sNumTxt.Text = sNum;
                sDescTxt.Text = sDesc;
                DateTime dt2 = Convert.ToDateTime(time);
                string tDate = dt2.Month + "/" + dt2.Day + "/" + dt2.Year;
                tTxt.Text = tDate;

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

            string updateSQL = "UPDATE strategy SET gID = @gID, objID = @objID, stratNum = @sNum, stratDesc = @sDesc, timelines = @timeLine WHERE id = @record";
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(updateSQL, con);
            try
            {
                con.Open();
                string gID = gidTxt.Text;
                string oID = objTxt.Text;
                string sNum = sNumTxt.Text;
                string sDesc = sDescTxt.Text;
                string timeLines = tTxt.Text;
                DateTime dt2 = Convert.ToDateTime(timeLines);
                string tDate = dt2.Year + "-" + dt2.Month + "-" + dt2.Day;
                cmd.Parameters.AddWithValue("@gID", gID);
                cmd.Parameters.AddWithValue("@objID", oID);
                cmd.Parameters.AddWithValue("@sNum", sNum);
                cmd.Parameters.AddWithValue("@sDesc", sDesc);
                cmd.Parameters.AddWithValue("@timeLine", tDate);
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
                cs.RegisterStartupScript(this.GetType(), "showalert", "alert('Strategy Updated')", true);
                con.Close();
                Response.Redirect("~/strategies.aspx");
            }
        }
    }
}
