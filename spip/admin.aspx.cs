using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace spip
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string uid = (string)(Session["eno"]);
            //string uid = "Bob.";
            //SqlDataSource1.SelectParameters.Add("@uid", uid);
            //SqlDataSource1.SelectCommand = "SELECT * FROM master where createdBy=@uid";
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/goals.aspx");
        }
        protected void btnObj_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/objectives.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/strategies.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/users.aspx");
        }
    }
}