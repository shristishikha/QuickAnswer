using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class User_Forgot : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["pswd"].ToString() == "2")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Operation Failed');", true);
            Session["pswd"] = "0";
        }

    }
    
    //checking username
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["mob"] = txtid.Text.Trim();

        string qry = "select * from dbo.Details where Mobile = '" + Session["mob"].ToString() + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtid.Visible = false;
            lblID.Visible = true;

            lblsqun.Visible = true;
            lblSQues.Visible = true;

            Label2.Visible = true;
            txtans.Visible = true;

            btnReset.Visible = true;
            btnSubmit.Visible = false;

            lblID.Text = Session["mob"].ToString();
            lblSQues.Text = dt.Rows[0]["Security_ques"].ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Username');", true);
        }

    }

    //checking security answer
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblSAns.Text = txtans.Text.Trim();
        string qry = "select * from dbo.Details where Mobile = '" + Session["mob"].ToString() + "' and Security_ans = '"+ txtans.Text.Trim() +"'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtans.Visible = false;
            lblSAns.Visible = true;
            btnReset.Visible = false;

            pbox.Visible = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Incorrect Answer');", true);
        }
    }

    //changing password
    protected void btnPswd_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();

            Session["pswd"] = "1";

            string qry = "Update dbo.Details set Password = '" + txtNPswd.Text.Trim() + "' where Mobile = '" + Session["mob"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        catch (Exception ex)
        {
            cn.Close();

            Session["pswd"] = "2";

            Response.Redirect("forgot.aspx");
        }

        Response.Redirect("Main.aspx");
    }
}