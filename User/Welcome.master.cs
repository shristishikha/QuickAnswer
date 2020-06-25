using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Welcome : System.Web.UI.MasterPage
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    static int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //Checking Session
            if (Session["name"] == null || Session["lname"] == null || Session["mob"] == null || Session["id"] == null)
            {
                cn.Open();
                string qry = "update dbo.Details set Status = '" + "Inactive" + "' where id = " + id;
                SqlCommand cmd = new SqlCommand(qry, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                
                Session["Session"] = 1;
               
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "message", "alert('Session timeout. Re-login...');", true);
                
                Response.Redirect("Main.aspx");
            }
            else
            {
                lblname.Text = Session["name"].ToString();
                id = Convert.ToInt32(Session["id"].ToString());
            }

            getPic();
            prodata();
            qtype();

            //show/hide question box
            if (Session["ansPage"] == "1")
            {
                QuesBox.Visible = false;
                space.Visible = false;
            }
            else
            {
                QuesBox.Visible = true;
                space.Visible = true;
            }

            //Sidebar
            if (Session["Profile"] == "1")
            {
                SBar.Visible = false;
                main.Attributes["class"] = "pqun";
            }
            else
            {
                SBar.Visible = true;
                main.Attributes["class"] = "qun";
            }

            //searchbox
            if (Session["search"] == "1")
            {
                search.Visible = false;
            }
            else
            {
                search.Visible = true;
            }
        }

    }

    //Getting Profile Pic
    void getPic()
    {
        string qry = "select * from dbo.Details where Mobile = '" + Session["mob"].ToString() + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows[0]["Profile_pic"].ToString() == "")
        {
            Image1.ImageUrl = "User_pics/unknownbig.png";
        }
        else
        {
            Image1.ImageUrl = "User_pics/" + dt.Rows[0]["Profile_pic"].ToString();
        }

    }

    //User Stats 
    protected void prodata()
    {
        
        String qry1 = "select count(Q_id) as tques from dbo.QuesMaster where User_id = '" + Session["id"]+"'";
        SqlDataAdapter da1 = new SqlDataAdapter(qry1, cn);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        lblMyQun.Text = dt1.Rows[0]["tques"].ToString();

        String qry2 = "select count(distinct(Qid)) as tans from dbo.AnsNotes where User_id='" + Session["id"] + "'";
        SqlDataAdapter da2 = new SqlDataAdapter(qry2, cn);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        lblMyAns.Text = dt2.Rows[0]["tans"].ToString();

        String qry3 = "select count(F_id) as tflw from dbo.Favorite where U_id = '" + Session["id"] + "'";
        SqlDataAdapter da3 = new SqlDataAdapter(qry3, cn);
        DataTable dt3 = new DataTable();
        da3.Fill(dt3);
        lblQunFlw.Text = dt3.Rows[0]["tflw"].ToString();

    }

    //Question Categories
    private void qtype()
    {

        string qry = "select Q_id, Ques_type from dbo.QuesTypeMaster";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Ques_type";
            DropDownList1.DataValueField = "Q_id";
            DropDownList1.DataBind();
        }

    }

    //Submitting Question
    protected void Btnsmt_Click(object sender, EventArgs e)
    {

        try
        {
            cn.Open();
            string qry1 = "Select id from dbo.Details where Mobile = '" + Session["mob"].ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry1, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string qry = "insert into dbo.QuesMaster(Question, Question_type, Ques_by, User_id, Date, Status) values ('" + txtQbox.Text.Trim() + "','" + DropDownList1.SelectedItem.ToString() + "','" + Session["name"].ToString() + "', '" + Session["id"] + "','" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "','" + "Inactive" + "')";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            txtQbox.Text = "";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Question Submitted Successfully');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Submission Failed');", true);
        }

    }

    //Logout
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        cn.Open();
        string qry = "update dbo.Details set Status = '" + "Inactive" + "' where id = '" + Session["id"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(qry, cn);
        cmd.ExecuteNonQuery();
        cn.Close();

        Session["id"] = "";
        Session["lname"] = "";
        Session["fname"] = "";
        Session["name"] = "";
        Session["mob"] = "";
            
        Response.Redirect("Main.aspx");
    }

    protected void search_Click(object sender, EventArgs e)
    {
        try
        {
            Session["searchtxt"] = txtsearch.Text.Trim();
            Response.Redirect("WSearch.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error');", true);
        }

    }
}