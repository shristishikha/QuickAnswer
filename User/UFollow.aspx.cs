using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_UFollow : System.Web.UI.Page
{
   SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
   
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["search"] = "1";
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
            Nothing.Visible = false;
            rptCustomers.Visible = true;
            rptCustomers.DataSource = GetData("select qn.*, un.id, un.F_Name, un.L_Name, un.Country, un.Profile_pic, fa.Q_id, fa.U_id from dbo.Favorite as fa left join dbo.QuesMaster as qn on fa.Q_id = qn.Q_id, dbo.Details as un where fa.U_id = '"+Session["id"]+"' and qn.User_id = un.id order by qn.Date desc");
            rptCustomers.DataBind();
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

    protected void lbtnUFollow_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();

            var rpt = ((Control)sender).NamingContainer;
            HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
            id = Convert.ToInt32(hf.Value);

            string qry = "Delete from dbo.Favorite where Q_id = '" + id + "' and U_id = '" + Session["id"] + "'";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry for the interruption');", true);
        }
    }
}