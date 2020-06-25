using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    string gen;
    string newsImage = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    //Clearing fields
    private void clear()
    {

        txtFname.Text = "";
        txtLname.Text = "";
        radMale.Checked = false;
        radFemale.Checked = false;
        txtDob.Text = "";
        drpCoun.SelectedIndex = 0;
        txtMob.Text = "";
        txtPass.Text = "";
        txtMail.Text = "";

    }

    //Register
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string qry = "select Mobile from dbo.Details where Mobile='" + txtMob.Text.Trim() + "'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Mobile Number Already Exists');", true);
        }
        else
        {
            Session["fname"] = txtFname.Text.Trim();
            Session["mob"] = txtMob.Text.Trim();
            Session["lname"] = txtLname.Text.Trim();
            Session["name"] = txtFname.Text.Trim() + " " + txtLname.Text.Trim();
            
            cn.Open();

            Uploadimage();

            string qry1 = "insert into dbo.Details (F_Name, L_Name, Gender, DOB, Country, Mobile, Password, E_mail, Profile_pic, About, Security_ques, Security_ans, Status) values ('" + txtFname.Text.Trim() + "','" + txtLname.Text.Trim() + "','" + gen + "','" + txtDob.Text.ToString() + "','" + drpCoun.SelectedItem + "','" + txtMob.Text.Trim() + "','" + txtPass.Text.Trim() + "','" + txtMail.Text.Trim() + "', '" + newsImage + "', '" + txtAbout.Text.Trim() + "', '" + txtSques.Text.Trim() + "', '" + txtSans.Text.Trim() + "', '" + "Active" + "')";
            SqlCommand cmd = new SqlCommand(qry1, cn);
            cmd.ExecuteNonQuery();

            string qry2 = "select * from dbo.Details where Mobile='" + txtMob.Text.Trim() + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(qry2, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            Session["id"] = dt1.Rows[0]["id"];
            Session["mob"] = dt1.Rows[0]["Mobile"];
            cn.Close();

            Response.Redirect("Pro.aspx");
        }
    }
    
    //getting value for Gender
    protected void radMale_CheckedChanged(object sender, EventArgs e)
    {

        if (radMale.Checked == true)
            gen = "Male";

    }
    protected void radFemale_CheckedChanged(object sender, EventArgs e)
    {
        if (radFemale.Checked == true)
            gen = "Female";
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
        else
        {
            newsImage = "unknownbig.png";
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

    //Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}