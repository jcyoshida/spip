using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace spip
{
    public partial class myplans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string uid = (string)(Session["eno"]);
            string uid = "Bob.";
            SqlDataSource1.SelectParameters.Add("@uid", uid);
            SqlDataSource1.SelectCommand = "SELECT * FROM master where createdBy=@uid";
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/plan.aspx");
        }
    }
}