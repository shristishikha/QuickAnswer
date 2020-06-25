using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class qadetail : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    string newsImage = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Profile"] = "1";
        getPic();
    }

    //Getting User Information
    void getPic()
    {
        string qry = "select * from dbo.loginmaster where user_id = '" + Session["adid"] + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        lblName.Text = Session["name"].ToString();

        lblFName.Text = Session["name"].ToString();
        txtFName.Text = Session["name"].ToString();

        lblUid.Text = dt.Rows[0]["user_id"].ToString();
        txtUid.Text = dt.Rows[0]["user_id"].ToString();

        lblSQun.Text = dt.Rows[0]["Security_qun"].ToString();


        imgUser.ImageUrl = "Admin_pics/" + dt.Rows[0]["Profile_pic"].ToString();
    }

    //Uploading Profile Pic
    public void Uploadimage()
    {
        string filename = "";

        if (fupUser.HasFile)
        {
            filename = SaveFile(fupUser.PostedFile);
        }
        else
        {
            filename = "n/a";
        }

        if (filename != "n/a")
        {
            newsImage = filename;
        }
    }

    //Saving Profile Pic
    public string SaveFile(HttpPostedFile file)
    {
        string fileName = "";
        String savePath = Server.MapPath("User_pics/");

        fileName = fupUser.FileName;
        byte[] fileSize = fupUser.FileBytes;

        string fileType = fupUser.PostedFile.ContentType;
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

            savePath += fileName;
            fupUser.SaveAs(savePath);
        }

        catch (Exception e)
        {
            string errmsg = e.Message;
        }

        return fileName;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Uploadimage();

        if (newsImage == "")
        {
            string qry1 = "select * from dbo.loginmaster where user_id = '" + Session["adid"] +"'";
            SqlDataAdapter da = new SqlDataAdapter(qry1, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            newsImage = dt.Rows[0]["Profile_pic"].ToString();
        }

        try
        {
            cn.Open();

            string qry = "update dbo.loginmaster set name = '"+ txtFName.Text.Trim() +"', user_id = '"+ txtUid.Text.Trim() +"', Profile_pic = '"+ newsImage +"' where user_id = '" + Session["adid"] +"'";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Profile Updated Successfully...');", true);

            saveClicked();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Unable to update profile...try again later...');", true);
        }
    }

    protected void btnPReset_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "select * from dbo.loginmaster where user_id = '" + Session["adid"] + "' and password = '" + txtPPass.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                cn.Open();

                string qry1 = "update dbo.loginmaster set Password = '" + txtNPass.Text.Trim() + "' where user_id = '" + Session["adid"]+"'";
                SqlCommand cmd = new SqlCommand(qry1, cn);
                cmd.ExecuteNonQuery();

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Password Changed Successfully...');", true);

                Info.Visible = true;
                Password.Visible = false;

                btnEdit.Visible = true;

                txtPPass.Enabled = false;
                txtNPass.Enabled = false;
                txtCPass.Enabled = false;


                cn.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Incorrect Password...');", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Unable to change password...try again later...');", true);
            cn.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "select * from dbo.loginmaster where user_id = '" + Session["adid"] + "' and Security_ans = '" + txtSAns.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                NSQues.Visible = true;
                OSQues.Visible = false;
                txtNSQues.Enabled = true;
                txtNSAns.Enabled = true;
                txtSAns.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Incorrect Answer...');", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Unable to change security question...try again later...');", true);
        }
    }

    protected void btnSReset_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
            string qry = "update dbo.loginmaster set Security_qun = '" + txtNSQues.Text.Trim() + "', Security_ans = '" + txtNSAns.Text.Trim() + "' where user_id = '" + Session["adid"] + "'";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Security Question Changed Successfully...');", true);

            Info.Visible = true;
            Security.Visible = false;

            btnEdit.Visible = true;

            txtNSQues.Enabled = false;
            txtNSAns.Enabled = false;

            cn.Close();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Unable to change security question...try again later...');", true);
            cn.Close();
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        UserImg.Visible = true;

        Privacy.Visible = false;
        Save.Visible = true;

        lblFName.Visible = false;

        txtFName.Visible = true;
        txtFName.Enabled = true;

        lblUid.Visible = false;
        
        txtUid.Visible = true;
        txtUid.Enabled = true;


        btnEdit.Visible = false;
    }

    protected void lbtnPassword_Click(object sender, EventArgs e)
    {
        Password.Visible = true;
        Info.Visible = false;

        btnEdit.Visible = false;

        txtPPass.Enabled = true;
        txtNPass.Enabled = true;
        txtCPass.Enabled = true;
    }

    protected void lbtnSecurity_Click(object sender, EventArgs e)
    {
        Security.Visible = true;
        NSQues.Visible = false;
        OSQues.Visible = true;
        Info.Visible = false;

        btnEdit.Visible = false;

        txtSAns.Enabled = true;

    }

    protected void saveClicked()
    {
        UserImg.Visible = false;

        Privacy.Visible = true;
        Save.Visible = false;

        txtFName.Visible = false;
        txtFName.Enabled = false;

        txtUid.Visible = false;
        txtUid.Enabled = false;

        lblFName.Visible = true;
        lblUid.Visible = true;
        
        btnEdit.Visible = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        saveClicked();
    }

    protected void btnPCancel_Click(object sender, EventArgs e)
    {
        Info.Visible = true;
        Password.Visible = false;

        btnEdit.Visible = true;

        txtPPass.Enabled = false;
        txtNPass.Enabled = false;
        txtCPass.Enabled = false;
    }

    protected void btnSOCancel_Click(object sender, EventArgs e)
    {
        Info.Visible = true;
        Security.Visible = false;
        btnEdit.Visible = true;
    }
    
    protected void btnSNCancel_Click(object sender, EventArgs e)
    {
        Info.Visible = true;
        Security.Visible = false;
        btnEdit.Visible = true;
    }
    
}