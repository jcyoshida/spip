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
    public partial class newUser : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string empNum = empNoTxt.Text;
            string lName = lNameTxt.Text;
            string fName = fNameTxt.Text;
            string title = titleTxt.Text;
            string lead = leadRdo.Text;
            string mgr = mgrRdo.Text;
            string admin = adminRDO.Text;
            string insertSQL = "INSERT INTO user (lastName,firstName,empNo,title,lead,mgr,admin) VALUES (@lName,@fName,@eNum,@title,@lead,@mgr,@admin)";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(insertSQL, con);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@eNum", empNum);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@lead", lead);
            cmd.Parameters.AddWithValue("@mgr", mgr);
            cmd.Parameters.AddWithValue("@admin", admin);

            try
            {
                con.Open();
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
                cs.RegisterStartupScript(this.GetType(), "showalert", "alert('User Saved')", true);
                con.Close();
                Response.Redirect("~/users.aspx");
            }
        }
    }
}