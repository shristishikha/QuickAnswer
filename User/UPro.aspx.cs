using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_UPro : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string newsImage = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["search"] = "1";
        Session["ansPage"] = "1";
        Session["Profile"] = "1";
        getPic();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "select * from dbo.Details where id = '" + Session["id"] + "' and Security_ans = '" + txtSAns.Text.Trim() + "'";
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
            string qry = "update dbo.Details set Security_ques = '" + txtNSQues.Text.Trim() + "', Security_ans = '" + txtNSAns.Text.Trim() + "' where id = '" + Session["id"] + "'";
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Security Question Changed Successfully...');", true);

            Info.Visible = true;
            Security.Visible = false;
            
            btnEdit.Visible = true;

            txtNSQues.Enabled = false;
            txtNSAns.Enabled = false;

            btnQuesAsked.Visible = true;
            btnAnswered.Visible = true;
            btnFollowed.Visible = true;

            cn.Close();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Unable to change security question...try again later...');", true);
            cn.Close();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string gen;

        if (rdbtnMale.Checked == true)
            gen = "Male";
        else
            gen = "Female";

        Uploadimage();

        if (newsImage == "")
        {
            string qry1 = "select * from dbo.Details where id = '" + Session["id"]+"'";
            SqlDataAdapter da = new SqlDataAdapter(qry1, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            newsImage = dt.Rows[0]["Profile_pic"].ToString();
        }

        try
        {
            cn.Open();

            string qry = "update dbo.Details set F_Name = '" + txtFName.Text.Trim() + "', L_Name = '" + txtLName.Text.Trim() + "', Gender = '" + gen + "', DOB = '" + txtDob.Text.ToString() + "', Country = '" + txtFrom.Text.Trim() + "', Mobile = '" + txtMobile.Text.Trim() + "', E_mail = '" + txtEmail.Text.Trim() + "', About = '" + txtAbout.Text.Trim() + "', Profile_pic = '" + newsImage + "' where id = '" + Session["id"] + "' ";
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
            string qry = "select * from dbo.Details where id = '" + Session["id"] + "' and password = '"+ txtPPass.Text.Trim() +"'";
            SqlDataAdapter da = new SqlDataAdapter(qry, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                cn.Open();

                string qry1 = "update dbo.Details set Password = '" + txtNPass.Text.Trim() + "' where id = '" + Session["id"] + "'";
                SqlCommand cmd = new SqlCommand(qry1, cn);
                cmd.ExecuteNonQuery();

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Password Changed Successfully...');", true);

                Info.Visible = true;
                Password.Visible = false;

                btnEdit.Visible = true;

                txtPPass.Enabled = false;
                txtNPass.Enabled = false;
                txtCPass.Enabled = false;

                btnQuesAsked.Visible = true;
                btnAnswered.Visible = true;
                btnFollowed.Visible = true;

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

    //Getting User Information
    void getPic()
    {
        string qry = "select * from dbo.Details where id = '" + Session["id"] + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        lblName.Text = Session["name"].ToString();
        lblDofB.Text = "born on " + dt.Rows[0]["DOB"].ToString();
        lblPlace.Text = " . from " + dt.Rows[0]["Country"].ToString();

        lblFName.Text = Session["Fname"].ToString();
        txtFName.Text = Session["Fname"].ToString();

        lblLName.Text = Session["Lname"].ToString();
        txtLName.Text = Session["Lname"].ToString();
        
        lblGender.Text = dt.Rows[0]["Gender"].ToString();
        if (lblGender.Text == "Male")
            rdbtnMale.Checked = true;
        else
            rdbtnFemale.Checked = true;

        lblDOB.Text = dt.Rows[0]["DOB"].ToString();
        txtDob.Text = dt.Rows[0]["DOB"].ToString();
        
        lblFrom.Text = dt.Rows[0]["Country"].ToString();
        txtFrom.Text = dt.Rows[0]["Country"].ToString();
        
        lblAbout.Text = dt.Rows[0]["About"].ToString();
        txtAbout.Text = dt.Rows[0]["About"].ToString();
        
        lblMobile.Text = Session["mob"].ToString();
        txtMobile.Text = Session["mob"].ToString();
        
        lblEmail.Text = dt.Rows[0]["E_mail"].ToString();
        txtEmail.Text = dt.Rows[0]["E_mail"].ToString();

        lblSQun.Text = dt.Rows[0]["Security_ques"].ToString();

        if (dt.Rows[0]["Profile_pic"].ToString() == "")
        {
            imgUser.ImageUrl = "User_pics/unknownbig.png";
        }
        else
        {
            imgUser.ImageUrl = "User_pics/" + dt.Rows[0]["Profile_pic"].ToString();
        }

        qunAsked();
        qunAnswered();
        qunFollowed();
    }

    //Question Asked
    public void qunAsked()
    {
        string qry = "select * from dbo.QuesMaster where User_id = '" + Session["id"] + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        btnQuesAsked.Text = dt.Rows.Count.ToString() + "\n Asked";
    }

    //Question Answered
    public void qunAnswered()
    {
        string qry = "select * from dbo.AnsNotes where User_id = '" + Session["id"] + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        btnAnswered.Text = dt.Rows.Count.ToString() + " Answered";
    }

    //Question Followed
    public void qunFollowed()
    {
        string qry = "select * from dbo.Favorite where U_id = '" + Session["id"] + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        btnFollowed.Text = dt.Rows.Count.ToString() + " Followed";
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

    //Controls Visiblity Functions
    protected void lbtnPassword_Click(object sender, EventArgs e)
    {
        Password.Visible = true;
        Info.Visible = false;
        
        btnEdit.Visible = false;

        txtPPass.Enabled = true;
        txtNPass.Enabled = true;
        txtCPass.Enabled = true;

        btnQuesAsked.Visible = false;
        btnAnswered.Visible = false;
        btnFollowed.Visible = false;
    }

    protected void lbtnSecurity_Click(object sender, EventArgs e)
    {
        Security.Visible = true;
        NSQues.Visible = false;
        OSQues.Visible = true;
        Info.Visible = false;

        btnEdit.Visible = false;

        txtSAns.Enabled = true;

        btnQuesAsked.Visible = false;
        btnAnswered.Visible = false;
        btnFollowed.Visible = false;
    }
    
    protected void saveClicked()
    {
        btnQuesAsked.Visible = true;
        btnAnswered.Visible = true;
        btnFollowed.Visible = true;

        UserImg.Visible = false; 
        
        Privacy.Visible = true;
        Save.Visible = false;

        txtFName.Visible = false;
        txtFName.Enabled = false;

        txtLName.Visible = false;
        txtLName.Enabled = false;
        
        rdbtnMale.Visible = false;
        rdbtnMale.Enabled = false;
        
        rdbtnFemale.Visible = false;
        rdbtnFemale.Enabled = false;
        
        txtDob.Visible = false;
        txtDob.Enabled = false;
        
        txtFrom.Visible = false;
        txtFrom.Enabled = false;
        
        txtAbout.Visible = false;
        txtAbout.Enabled = false;

        txtMobile.Visible = false;
        txtMobile.Enabled = false;
        
        txtEmail.Visible = false;
        txtEmail.Enabled = false;

        lblMobile.Visible = true;
        lblEmail.Visible = true;
        lblFName.Visible = true;
        lblLName.Visible = true;
        lblGender.Visible = true;
        lblDOB.Visible = true;
        lblFrom.Visible = true;
        lblAbout.Visible = true;

        lblMobile.Visible = true;
        lblEmail.Visible = true;

        btnEdit.Visible = true;
    }
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnQuesAsked.Visible = false;
        btnAnswered.Visible = false;
        btnFollowed.Visible = false;

        UserImg.Visible = true;

        Privacy.Visible = false;
        Save.Visible = true;

        txtFName.Visible = true;
        txtFName.Enabled = true;
        
        txtLName.Visible = true;
        txtLName.Enabled = true;
        
        rdbtnMale.Visible = true;
        rdbtnMale.Enabled = true;
        
        rdbtnFemale.Visible = true;
        rdbtnFemale.Enabled = true;
        
        txtDob.Visible = true;
        txtDob.Enabled = true;
        
        txtFrom.Visible = true;
        txtFrom.Enabled = true;
        
        txtAbout.Visible = true;
        txtAbout.Enabled = true;
        
        txtMobile.Visible = true;
        txtMobile.Enabled = true;
        
        txtEmail.Visible = true;
        txtEmail.Enabled = true;

        lblFName.Visible = false;
        lblLName.Visible = false;
        lblGender.Visible = false;
        lblDOB.Visible = false;
        lblFrom.Visible = false;
        lblAbout.Visible = false;

        lblMobile.Visible = false;
        lblEmail.Visible = false;

        btnEdit.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        saveClicked();
    }
    
    protected void btnSOCancel_Click(object sender, EventArgs e)
    {
        Info.Visible = true;
        Security.Visible = false;
        btnEdit.Visible = true;
        btnQuesAsked.Visible = true;
        btnAnswered.Visible = true;
        btnFollowed.Visible = true;
    }
    
    protected void btnSNCancel_Click(object sender, EventArgs e)
    {
        Info.Visible = true;
        Security.Visible = false;
        btnEdit.Visible = true;
        btnQuesAsked.Visible = true;
        btnAnswered.Visible = true;
        btnFollowed.Visible = true;
    }
    
    protected void btnPCancel_Click(object sender, EventArgs e)
    {
        Info.Visible = true;
        Password.Visible = false;

        btnEdit.Visible = true;

        txtPPass.Enabled = false;
        txtNPass.Enabled = false;
        txtCPass.Enabled = false;

        btnQuesAsked.Visible = true;
        btnAnswered.Visible = true;
        btnFollowed.Visible = true;
    }

    //btnAsked, btnAnswered, btnFollowed
    protected void btnQuesAsked_Click(object sender, EventArgs e)
    {
        Response.Redirect("uqun.aspx");
    }

    protected void btnAnswered_Click(object sender, EventArgs e)
    {
        Response.Redirect("uans.aspx");
    }
    
    protected void btnFollowed_Click(object sender, EventArgs e)
    {
        Response.Redirect("UFollow.aspx");
    }
}