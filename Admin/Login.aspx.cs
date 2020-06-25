using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string newsImage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        log();
    }

    private void log()
    {
        string qry = "select * from loginmaster";
        SqlDataAdapter da = new SqlDataAdapter(qry,cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0) 
        {
            txtname.Visible  = false;
            lblname.Visible  = false;           
            Btnsignup.Visible= false;
            lblsqun.Visible  = false;
            txtsqun.Visible  = false;
            lblsans.Visible  = false;
            txtsans.Visible  = false;
            imgadm.Visible   = false;
            upadm.Visible    = false;
            txtuname.Visible = true;
            txtpwd.Visible   = true;
            Btnlogin.Visible = true;
        }
        else
        {
            imgadm.Visible   = true;
            upadm.Visible    = true;
            txtname.Visible  = true;
            lblname.Visible  = true;
            txtuname.Visible = true;
            txtpwd.Visible   = true;
            lblsqun.Visible  = true;
            txtsqun.Visible  = true;
            lblsans.Visible  = true;
            txtsans.Visible  = true;            
            Btnsignup.Visible= true;
            Btnlogin.Visible = false;
        }
    }
    protected void Btnsignup_Click(object sender, EventArgs e)
    {
        try
        {
            Uploadimage();
            cn.Open();
            string qry = "insert into dbo.loginmaster( Profile_pic,name, user_id, Password, Security_Qun, Security_Ans, Q_Rejected) values ('" + newsImage + "','" + txtname.Text.Trim() + "','" + txtuname.Text.Trim() + "','" + txtpwd.Text.Trim() + "','" + txtsqun.Text.Trim() + "','" + txtsans.Text.Trim() + "', "+ 0 +")";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            Btnsignup.Visible = false;
            Btnlogin.Visible = true;
            txtname.Visible = false;
            log();
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error');", true);
        }
    }
    protected void Btnlogin_Click(object sender, EventArgs e)
    {        
        string qry = "select user_id,Password from loginmaster where user_id='" + txtuname.Text.Trim() + "' and Password='"+txtpwd.Text.Trim()+"' ";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            
            string adid = dt.Rows[0]["user_id"].ToString();
            Session["adid"] = adid.ToString();
            Response.Redirect("dashboard.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid UserId or Password');", true);
        }
        
    }

    public void Uploadimage()
    {
        string filename = "";

        if (upadm.HasFile)
        {
            filename = SaveFile(upadm.PostedFile);
        }
        else
        {

            filename = "n/a";
        }

        if (filename != "n/a")
        {
            newsImage = filename;
        }
        else
        {
            newsImage = "unknownbig.png";
        }
    }
    public string SaveFile(HttpPostedFile file)
    {
        string fileName = "";

        String savePath = Server.MapPath("Admin_pics/");



        fileName = upadm.FileName;
        byte[] fileSize = upadm.FileBytes;
        string fileType = upadm.PostedFile.ContentType;


        string pathToCheck = savePath + fileName;


        string tempfileName = "";

        try
        {
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {

                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

            }
            else
            {

            }


            savePath += fileName;

            upadm.SaveAs(savePath);
        }
        catch (Exception e)
        {
            string errmsg = e.Message;
        }
        return fileName;
        
    }
    
}