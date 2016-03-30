using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace spip
{
    public partial class _default : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string AD = "LDAP://ldap.hosted.lac.com";
            string user = txtUsername.Text.ToString();
            string pw = txtPassword.Text.ToString();

            string SQL = "SELECT COUNT(*) FROM user WHERE empNo = @empNo";
            MySqlConnection myConnection = new MySqlConnection(connectionString);
            MySqlCommand myCommand = new MySqlCommand(SQL, myConnection);
            myCommand.Parameters.AddWithValue("@empNo", user);
            string aChk = "SELECT admin FROM user WHERE empNo = @empNo";
            MySqlCommand cmd = new MySqlCommand(aChk, myConnection);
            cmd.Parameters.AddWithValue("@empNo", user);

            try
            {
                myConnection.Open();
                Int32 userExist = Convert.ToInt32(myCommand.ExecuteScalar());
                if(userExist > 0)
                {
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    string adm = reader["admin"].ToString();
                    reader.Close();

                    DirectoryEntry DEntry = new DirectoryEntry(AD, user, pw);
                    DirectorySearcher DSearch = new DirectorySearcher(DEntry);
                    DSearch.Filter = String.Format("(SAMAccountName={0})", user);
                    SearchResult SResult = DSearch.FindOne();
                    Session["eno"] = user;
                    
                    if (adm=="Y")
                    {
                        Session["adm"] = 1;
                    }
                    else
                    {
                        Session["adm"] = 0;
                    }
                    Response.Redirect("~/myplans.aspx");
                } else
                {
                    lblPgStatus.Text = "You do not have access to this system.";
                }


            }
            catch (Exception ex)
            {
                lblPgStatus.Text = "LOGIN ERROR: ";
                lblPgStatus.Text += ex.Message;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}