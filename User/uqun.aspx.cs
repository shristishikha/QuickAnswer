using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class User_uqun : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["search"] = "0";
        
        delete();
        
        if (!IsPostBack)
        {

            Session["ansPage"] = "1";

            show();
            
        }

    }

    protected void show()
    {
        string qry = "SELECT * FROM dbo.QuesMaster as qn, dbo.Details as un where qn.User_id = un.id and Question like '" + Session["searchtxt"] + "%' order by qn.Date desc";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            rptCustomers.DataSource = GetData("SELECT * FROM dbo.QuesMaster as qn, dbo.Details as un where qn.User_id = un.id and qn.User_id ='" + Session["id"].ToString() + "' order by qn.Date desc");
            rptCustomers.DataBind();
            Nothing.Visible = false;
            rptCustomers.Visible = true;
        }
        else
        {
            rptCustomers.DataSource = GetData("SELECT * FROM dbo.QuesMaster as qn, dbo.Details as un where qn.User_id = un.id and qn.User_id ='" + Session["id"].ToString() + "' order by qn.Date desc");
            rptCustomers.DataBind();
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

    protected void delete()
    {
        cn.Open();
        id = Convert.ToInt32(Request.QueryString["UID"]);
        string qry, qry1;
        qry= "Delete from dbo.QuesMaster where Q_id = " + id;
        qry1 = "Delete from dbo.AnsNotes where Q_id = " + id;
        
        SqlCommand cmd = new SqlCommand(qry, cn);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand(qry1, cn);
        cmd.ExecuteNonQuery();
        
        cn.Close();

    }
}