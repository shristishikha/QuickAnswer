using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pswd"] == "1")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Password Changed Successfully.');", true);
            Session["pswd"] = "0";
        }

        if (!this.IsPostBack)
        {
            show();
        }
    }

    protected void show()
    {
        string qry = "SELECT * FROM dbo.QuesMaster as qn, dbo.Details as un where qn.User_id = un.id and qn.Status = 'Active'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            rptCustomers.DataSource = GetData("SELECT * FROM dbo.QuesMaster as qn, dbo.Details as un where qn.User_id = un.id and qn.Status = 'Active' order by qn.Q_id desc");
            rptCustomers.DataBind(); 
            Nothing.Visible = false;
            rptCustomers.Visible = true;
        }
        else
        {
            Nothing.Visible = true;
            rptCustomers.Visible = false;
        }

    }

    //Displaying questions
    private static DataTable GetData(string query)
    {
        string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string customerId = (e.Item.FindControl("hfCustomerId") as HiddenField).Value;
            Repeater rptOrders = e.Item.FindControl("rptOrders") as Repeater;
            rptOrders.DataSource = GetData(string.Format("SELECT * FROM dbo.AnsNotes as an, dbo.Details as un where an.User_id = un.id and Qid='{0}' order by an.date desc", customerId));
            rptOrders.DataBind();
        }
    }
    
}