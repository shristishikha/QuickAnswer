using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class qreq : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            show();
        }

    }

    protected void show()
    {
        string qry = "SELECT qn.*, un.id, un.F_Name, un.L_Name, un.Country, un.Profile_pic FROM dbo.Details as un, dbo.QuesMaster as qn where qn.User_id = un.id and qn.Status = 'inactive' order by qn.Date desc";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            rptQues.DataSource = dt;
            rptQues.DataBind();
            Nothing.Visible = false;
            rptQues.Visible = true;
        }
        else
        {
            Nothing.Visible = true;
            rptQues.Visible = false;
        }
    }

    protected void lbtnApp_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();

            var rpt = ((Control)sender).NamingContainer;
            HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
            id = Convert.ToInt32(hf.Value);

            string qry = "update dbo.QuesMaster set status ='" + "Active" + "' where Q_id=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Approved');", true);

            cn.Close();
            show();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry...This question cannot be approved');", true);
            cn.Close();
            show();
        }

    }
    protected void lbtnRej_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();

            var rpt = ((Control)sender).NamingContainer;
            HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
            id = Convert.ToInt32(hf.Value);

            string qry = "delete from dbo.QuesMaster where Q_id=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();

            string qry1 = "Update dbo.loginmaster set Q_Rejected = Q_Rejected + 1 ";
            SqlCommand cmd1 = new SqlCommand(qry1, cn);
            cmd1.ExecuteNonQuery();
            
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Rejected');", true);

            cn.Close();
            show();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry...This question cannot be rejected');", true);
            cn.Close();
            show();
        }
    }
}