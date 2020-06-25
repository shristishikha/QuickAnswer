using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class User_Answer : System.Web.UI.Page
{
    
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    int id;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["search"] = "0";
        Session["ansPage"] = "1";
        id = Convert.ToInt32(Request.QueryString["ID"]);
        qun();

    }
    
    //Displaying question
    void qun()
    {

        String qry = "select * from dbo.QuesMaster where Q_id = " + id;
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        
        lblqun.Text = dt.Rows[0]["Question"].ToString();
        lblqunby.Text = dt.Rows[0]["Ques_by"].ToString();
        lblqdate.Text = dt.Rows[0]["Date"].ToString();
    
    }
    
    //Submitting Answer
    protected void add_Ans_Click(object sender, EventArgs e)
    {

        try
        {
            cn.Open();
            String qry = "insert into dbo.AnsNotes (Qid, Answer, AnsBy, User_id, Date) values ('" + id + "','" + txtans.Text.Trim() + "','" + Session["name"].ToString() + " " + Session["lname"].ToString() + "', '" + Session["id"] + "', '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Submitted Successfully');", true);
            cn.Close();
            Response.Redirect("Pro.aspx");
            txtans.Text = "";
            Session["ansPage"] = "0";
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Submission Failed');", true);            
        }

    }

}