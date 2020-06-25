using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin : System.Web.UI.MasterPage
{  
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    
    int id;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["adid"] == null)
            {
                Session["Session"] = 1;

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "message", "alert('Session timeout. Re-login...');", true);

                Response.Redirect("../User/Main.aspx");

            }
            else
            {
                adname();
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
            }
        }
    }
    private void adname()
    {
        try
        {
            

            String qry = "Select * from dbo.loginmaster where user_id = '" + Session["adid"]+"'";
            SqlDataAdapter da = new SqlDataAdapter(qry, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            lbluname.Text = dt.Rows[0]["name"].ToString();
            Session["name"] = lbluname.Text;

            imga.ImageUrl = "Admin_pics/" + dt.Rows[0]["Profile_pic"].ToString();
        }
        catch (Exception ex)
        { }
    }
    
    protected void imga_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("aprofile.aspx");
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session["adid"] = "";
        Response.Redirect("../User/Main.aspx");
    }
}
