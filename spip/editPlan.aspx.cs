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
    public partial class editPlan : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["strategic_planConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                fillLeads();
                fillDisabled();
                
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
        private void fillDisabled()
        {
            string record = Request.QueryString["r"];

            MySqlConnection myConnection = new MySqlConnection(connectionString);
            string selectSQL = "SELECT * FROM master WHERE id='" + record + "'";

            MySqlCommand myCommand = new MySqlCommand(selectSQL, myConnection);


            try
            {
                myConnection.Open();
                MySqlDataReader reader;
                //MySqlDataReader reader2;
                reader = myCommand.ExecuteReader();
                reader.Read();

                string goal = reader["gID"].ToString();
                string obj = reader["objID"].ToString();
                string strat = reader["stratID"].ToString();
                string lead = reader["leadID"].ToString();
                string desc = reader["bDescTxt"].ToString();
                string aPlan = reader["apTxt"].ToString();
                string impDate = Convert.ToDateTime(reader["impDate"]).ToString("MM/dd/yyyy");
                string antDate = Convert.ToDateTime(reader["acDate"]).ToString("MM/dd/yyyy");
                string apStatus = reader["apStatus"].ToString();
                string pManager = reader["pmID"].ToString();
                string progress = reader["progressTxt"].ToString();
                string challengesRcvd = reader["challengesTxt"].ToString();
                string methodRcvd = reader["methodTxt"].ToString();
                
                reader.Close();

                lbldti.Text = "<strong>GOAL " + goal + ":</strong>";
                lbldti2.Text = "<strong>OBJECTIVE " + obj + ":</strong>";
                lbldti3.Text = "<strong>STRATEGY " + strat + ":</strong>";
                brief_desc.Text = desc;
                actionPlan.Text = aPlan;
                imp_date.Text = impDate;
                ant_date.Text = antDate;
                ap_status.SelectedValue = apStatus;
                lstLeads.SelectedValue = pManager;
                op.Text = progress;
                challenges.Text = challengesRcvd;
                method.Text = methodRcvd;

                // Goal information
                string gSQL = "SELECT * FROM goal where id='" + goal + "'";
                MySqlCommand cmdGoal = new MySqlCommand(gSQL, myConnection);
                reader = cmdGoal.ExecuteReader();
                reader.Read();
                disabledTextInput.Text = reader["title"].ToString();
                reader.Close();
                // Objective information   
                string oSQL = "SELECT * FROM objective WHERE objNum='" + obj + "' AND gid='"+goal+"'";
                MySqlCommand cmdObj = new MySqlCommand(oSQL, myConnection);
                reader = cmdObj.ExecuteReader();
                reader.Read();
                disabledTextInput2.Text = reader["objDesc"].ToString();
                reader.Close();
                // Strategy information
                string sSQL = "SELECT * FROM strategy WHERE stratNum='" + strat + "' AND objID='" + obj + "'";
                MySqlCommand cmdStrat = new MySqlCommand(sSQL, myConnection);
                reader = cmdStrat.ExecuteReader();
                reader.Read();
                disabledTextInput3.Text = reader["stratDesc"].ToString();
                DateTime date = Convert.ToDateTime(reader["timelines"]);
                disabledTextInput4.Text = date.ToShortDateString().ToString();
                reader.Close();

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
            string record = Request.QueryString["r"];

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlDataReader reader;
            string selectSQL = "SELECT * FROM master WHERE id='" + record + "'";

            MySqlCommand myCommand = new MySqlCommand(selectSQL, con);

            //con.Open();



            string updateSQL = "UPDATE master SET "
                            + "gID = @goal, objID = @obj, stratID = @strat, leadID = @leads, pmID = @pID, bDescTxt = @desc, apTxt = @ap, impDate = @impDate, "
                            + "acDate = @acDate, apStatus = @apStatus, progressTxt = @overallProgress, challengesTxt = @chall, methodTxt = @meth "
                            + "WHERE id =  @record";

            
            MySqlCommand cmd = new MySqlCommand(updateSQL, con);

            string logIT = "INSERT INTO logs (modifiedBy, modifiedDate, rID) VALUES (@mBy, @mDate, @record)";
            MySqlCommand cmd2 = new MySqlCommand(logIT, con);

            try
            {

                con.Open();
                reader = myCommand.ExecuteReader();
                reader.Read();
                string goal = reader["gID"].ToString();
                string obj = reader["objID"].ToString();
                string strat = reader["stratID"].ToString();
                reader.Close();



                string leads = lstLeads.SelectedValue;
                string desc = brief_desc.Text;
                string ap = actionPlan.Text;
                string ad = ant_date.Text;
                DateTime dt = Convert.ToDateTime(ad);
                string aDate = dt.Year + "-" + dt.Month + "-" + dt.Day;
                string iDate = imp_date.Text;
                DateTime dt2 = Convert.ToDateTime(iDate);
                string impDate = dt2.Year + "-" + dt2.Month + "-" + dt2.Day;
                string apStatus = ap_status.SelectedValue;
                string overallProgress = op.Text;
                string chall = challenges.Text;
                string meth = method.Text;
                string cBy = (string)(Session["eno"]);
                string pID = cBy;
                DateTime cDate = DateTime.Now;
                cDate.ToString();
                cmd.Parameters.AddWithValue("@goal", goal);
                cmd.Parameters.AddWithValue("@obj", obj);
                cmd.Parameters.AddWithValue("@strat", strat);
                cmd.Parameters.AddWithValue("@leads", leads);
                cmd.Parameters.AddWithValue("@pmID", pID);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@ap", ap);
                cmd.Parameters.AddWithValue("@acDate", aDate);
                cmd.Parameters.AddWithValue("@impDate", impDate);
                cmd.Parameters.AddWithValue("@apStatus", apStatus);
                cmd.Parameters.AddWithValue("@overallProgress", overallProgress);
                cmd.Parameters.AddWithValue("@chall", chall);
                cmd.Parameters.AddWithValue("@meth", meth);
                cmd.Parameters.AddWithValue("@record", record);
                cmd.ExecuteNonQuery();
                cmd2.Parameters.AddWithValue("@mBy", cBy);
                cmd2.Parameters.AddWithValue("@mDate", cDate);
                cmd2.Parameters.AddWithValue("@record", record);
                cmd2.ExecuteNonQuery();


            }
            catch (Exception err)
            {
                lblInfo.Text = "error: ";
                lblInfo.Text += err.Message;
            }
            finally
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "showalert", "alert('Plan Updated')", true);
                con.Close();
                Response.Redirect("~/myplans.aspx");
            }

        }
    }
}