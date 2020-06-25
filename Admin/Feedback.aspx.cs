using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Feedback : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }
    }

    protected void show()
    {
        string qry = "select fd.*, un.id, un.F_name, un.L_name,un.Profile_pic from dbo.Details as un, dbo.Feedback fd where fd.U_id = un.id order by F_id desc";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            rptFeedback.DataSource = dt;
            rptFeedback.DataBind();
            Nothing.Visible = false;
            rptFeedback.Visible = true;
        }
        else
        {
            Nothing.Visible = true;
            rptFeedback.Visible = false;
        }
    }
    protected void lbtnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();

            var rpt = ((Control)sender).NamingContainer;
            HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
            id = Convert.ToInt32(hf.Value);

            string qry = "delete from dbo.Feedback where F_id=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            cn.Close(); 
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Removed');", true);
            show();
            
            
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry...This feedback cannot be removed');", true);
            cn.Close();
            show();
        }
    }
}