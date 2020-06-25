using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class udetail : System.Web.UI.Page
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
        string qry = "select * from dbo.Details order by id desc";
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

    protected void lbtnRem_Click(object sender, EventArgs e)
    {
        var rpt = ((Control)sender).NamingContainer;

        HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
        id = Convert.ToInt32(hf.Value);

        try
        {
            cn.Open();
            string qry = "update dbo.Details set Gender = '" + "" + "', DOB = '" + "" + "', Country = '" + "" + "', Mobile = '" + "" + "', Password = '" + "" + "', E_mail = '" + "" + "', About = '" + "" + "', Security_ques = '" + "" + "', Security_ans = '" + "" + "', Status = '" + "" + "' where id=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('User Removed');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('There is a problem in removing this user.');", true);
        }
    }
}