using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["pswd"] = "";

        if (Session["Session"] != null)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Session timeout. Re-login...');", true);
            Session["Session"] = null;
        }

    }

    //signup
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }

    //Logging in
    protected void Button2_Click(object sender, EventArgs e)
    {

        cn.Open();
        string qry = "Select * from dbo.Details where Mobile = '" + txtUname.Text.Trim() + "' and Password = '" + txtPass.Text.Trim() + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string qry1 = "update dbo.Details set Status = '" + "Active" + "' where Mobile = '" + txtUname.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(qry1, cn);
            cmd.ExecuteNonQuery();

            Session["id"] = dt.Rows[0]["id"];
            Session["lname"] = dt.Rows[0]["L_Name"].ToString();
            Session["fname"] = dt.Rows[0]["F_Name"].ToString();
            Session["name"] = Session["fname"] + " " + Session["lname"];
            Session["mob"] = txtUname.Text.Trim();

            Response.Redirect("Pro.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Incorrect Username or password');", true);
            txtPass.Text = "";
        }
        cn.Close();

    }

    //searching question
    protected void search_Click(object sender, EventArgs e)
    {
        try
        {
            Session["searchtxt"] = txtsearch.Text.Trim();
            Response.Redirect("USearch.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error');", true);
        }
        
    }
    protected void lbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }

}