using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;


namespace spip
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string AD = "LDAP://ldap.hosted.lac.com";
            string user = txtUsername.Text.ToString();
            string pw = txtPassword.Text.ToString();

            try
            {
                DirectoryEntry DEntry = new DirectoryEntry(AD, user, pw);
                DirectorySearcher DSearch = new DirectorySearcher(DEntry);
                DSearch.Filter = String.Format("(SAMAccountName={0})", user);
                SearchResult SResult = DSearch.FindOne();
                //lblPgStatus.Text = "LOGIN SUCCESS";
                Session["eno"] = user;
                Response.Redirect("~/plan.aspx");

            }catch (Exception ex)
            {
                lblPgStatus.Text = "LOGIN ERROR: ";
                lblPgStatus.Text += ex.Message;
            }
        }
    }
}