using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Wfaq : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["search"] = "1";
            
            Session["ansPage"] = "1";
            
            show();
        }
    }

    protected void show()
    {
        string qry = "select * from dbo.faqs order by fid desc";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Nothing.Visible = false;
            rptQues.Visible = true;
            rptQues.DataSource = dt;
            rptQues.DataBind();
        }
        else
        {
            Nothing.Visible = true;
            rptQues.Visible = false;
        }
    }
}