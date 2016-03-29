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
    public partial class newStrat : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string gID = goalTxt.Text;
            string oID = objTxt.Text;
            string sNum = stratTxt.Text;
            string sDesc = descTxt.Text;
            string tLine = timeTxt.Text;
            DateTime dt2 = Convert.ToDateTime(tLine);
            string tDate = dt2.Year + "/" + dt2.Month + "/" + dt2.Day;
            string insertSQL = "INSERT INTO strategy (gID,objID,stratNum,stratDesc,timelines) VALUES (@gid,@oid,@snum,@sdesc,@tline)";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(insertSQL, con);
            cmd.Parameters.AddWithValue("@gid", gID);
            cmd.Parameters.AddWithValue("@oid", oID);
            cmd.Parameters.AddWithValue("@snum", sNum);
            cmd.Parameters.AddWithValue("@sdesc", sDesc);
            cmd.Parameters.AddWithValue("@tline", tDate);

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
                cs.RegisterStartupScript(this.GetType(), "showalert", "alert('Strategy Saved')", true);
                con.Close();
                Response.Redirect("~/strategies.aspx");
            }
        }
    }
}