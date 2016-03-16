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
    public partial class ap : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string goal = Request.QueryString["g"];
            string obj = Request.QueryString["o"];
            string strat = Request.QueryString["s"];
            lbldti.Text = "<strong>GOAL " + goal + ":</strong>";
            lbldti2.Text = "<strong>OBJECTIVE " + obj + ":</strong>";
            lbldti3.Text = "<strong>STRATEGY " + strat + ":</strong>";

            MySqlConnection myConnection = new MySqlConnection(connectionString);
            string selectSQL = "SELECT * FROM goal WHERE id='" + goal + "'";
            string selectSQL2 = "SELECT * FROM objective WHERE id='" + obj + "'";
            string selectSQL3 = "SELECT * FROM strategy WHERE id='" + strat + "'";
            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);
            MySqlCommand cmd2 = new MySqlCommand(selectSQL2, myConnection);
            MySqlCommand cmd3 = new MySqlCommand(selectSQL3, myConnection);
            //string selectSQL4 = "SELECT * FROM strategy WHERE objID='" + obj + "'";
            //MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQL3, myConnection);
            //DataSet ds = new DataSet();

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

                reader = cmd3.ExecuteReader();
                reader.Read();
                disabledTextInput3.Text = reader["stratDesc"].ToString();
                
                DateTime date = Convert.ToDateTime(reader["timelines"]);
                disabledTextInput4.Text = date.ToShortDateString().ToString();
                reader.Close();



                //adapter.Fill(ds, "Strategies");
                //mygv.DataSource = ds;
                //mygv.DataBind();

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

            if (!this.IsPostBack)
            {
                fillLeads();
            }
        }
        protected void mygv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string goal = Request.QueryString["g"];
            string obj = Request.QueryString["o"];
            string strat = Request.QueryString["s"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

                int g = (int)DataBinder.Eval(e.Row.DataItem, "id");
                e.Row.Attributes["data-href"] = "ap.aspx?g=" + goal + "&o=" + obj + "&s=" +g;
            }
        }
        private void fillLeads()
        {
            lstLeads.Items.Clear();

            string sql = "select * from user where lead='Y' AND admin='N'";
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["lastName"] + ", " + reader["firstName"];
                    newItem.Value = reader["id"].ToString();
                    lstLeads.Items.Add(newItem);
                }
                reader.Close();
            }catch (Exception err)
            {
                lblInfo.Text = "error filling the list.";
                lblInfo.Text += err.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string goal = Request.QueryString["g"];
            string obj = Request.QueryString["o"];
            string strat = Request.QueryString["s"];
            string leads = lstLeads.SelectedValue;
            string desc = brief_desc.Text;
            string ap = actionPlan.Text;
            string ad = ant_date.Text;
            string impDate = imp_date.Text;
            string apStatus = ap_status.SelectedValue;
            string overallProgress = op.Text;
            string chall = challenges.Text;
            string meth = method.Text;
            string cBy = (string)(Session["eno"]);
            DateTime cDate = DateTime.Now;
            cDate.ToString();


            string insertSQL = "INSERT INTO master "
                + "(gID,objID,stratID,leadID,pmID,bDescTxt,apTxt,impDate,acDate,apStatus,progressTxt,challengesTxt,methodTxt,createdBy,createdDate) "
                + "VALUES "
                + "(@goal,@obj,@strat,@leads,@desc,@ap,@ad,@impDate,@apStatus,@overallProgress,@chall,@meth,@cBy,@cDate)";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(insertSQL, con);

            cmd.Parameters.AddWithValue("@goal", goal);
            cmd.Parameters.AddWithValue("@obj", obj);
            cmd.Parameters.AddWithValue("@strat", strat);
            cmd.Parameters.AddWithValue("@leads", leads);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@ap", ap);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@impDate", impDate);
            cmd.Parameters.AddWithValue("@apStatus", apStatus);
            cmd.Parameters.AddWithValue("@overallProgress", overallProgress);
            cmd.Parameters.AddWithValue("@chall", chall);
            cmd.Parameters.AddWithValue("@meth", meth);
            cmd.Parameters.AddWithValue("@cBy", cBy);
            cmd.Parameters.AddWithValue("@cDate", cDate);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //reader = cmd.ExecuteReader();

            }
            catch (Exception err)
            {
                lblInfo.Text = "error filling the list.";
                lblInfo.Text += err.Message;
            }
            finally
            {
                con.Close();
            }
            //lblInfo.Visible = true;
            //lblInfo.Text = leads + desc + ap + ad + impDate + apStatus + overallProgress + chall + meth;
        }
    }
}