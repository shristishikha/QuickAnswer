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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["search"] = "1";
            Session["ansPage"] = "1";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtFeedback.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please provide a feedback...');", true);
        }
        else
        {
            try
            {
                cn.Open();
                string qry = "insert into dbo.Feedback(Feedback, U_id, Date) values('" + txtFeedback.Text.Trim() + "','" + Session["id"] + "','" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')";
                SqlCommand cmd = new SqlCommand(qry, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                txtFeedback.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Thank you for helping us...');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry...cant't submit your feedback now.');", true);
            }
        }
    }
}