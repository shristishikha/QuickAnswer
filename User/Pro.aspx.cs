using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pro : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    
    string customerId;
    int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["search"] = "0";
        Session["Profile"] = "0";
        Session["ansPage"] = "0";
        if (!this.IsPostBack)
        {
            display();
        }
        
        
    }

    protected void display()
    {

        string qry = "SELECT * FROM dbo.QuesMaster as qn, dbo.Details as un where qn.User_id = un.id and Question like '" + Session["searchtxt"] + "%' order by qn.Date desc";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            rptCustomers.DataSource = GetData("SELECT qn.*, un.id, un.F_Name, un.L_Name, un.Country, un.Profile_pic, fa.Q_id, fa.U_id, isnull(fa.F_Status, 'Like') as FStatus FROM dbo.Details as un, dbo.QuesMaster as qn left join dbo.Favorite as fa on fa.Q_id = qn.Q_id where qn.User_id = un.id and qn.Status = 'Active' order by qn.Q_id desc");
            rptCustomers.DataBind(); Nothing.Visible = false;
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
            customerId = (e.Item.FindControl("hfCustomerId") as HiddenField).Value;
            Repeater rptOrders = e.Item.FindControl("rptOrders") as Repeater;
            rptOrders.DataSource = GetData(string.Format("SELECT * FROM dbo.AnsNotes as an, dbo.Details as un where an.User_id = un.id and Qid='{0}' order by an.date desc", customerId));
            rptOrders.DataBind();
        }
    }

    protected void imgbtnLike_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            cn.Open();

            var rpt = ((Control)sender).NamingContainer;
            HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
            id = Convert.ToInt32(hf.Value);

            string qry = "Select * from dbo.Favorite where Q_id = '" + id + "' and U_id = '" + Session["id"] + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string qry1 = "Delete from dbo.Favorite where Q_id = '" + id + "' and U_id = '" + Session["id"] + "'";
                SqlCommand cmd = new SqlCommand(qry1, cn);
                cmd.ExecuteNonQuery();
                Response.Redirect("Pro.aspx");
            }
            else
            {
                string qry2 = "insert into dbo.Favorite (Q_id, U_id, F_Status) values ('" + id + "', '" + Session["id"] + "', '" + "Unlike" + "')";
                SqlCommand cmd = new SqlCommand(qry2, cn);
                cmd.ExecuteNonQuery();
                Response.Redirect("Pro.aspx");
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry for the interruption');", true);
        }
    }
}
