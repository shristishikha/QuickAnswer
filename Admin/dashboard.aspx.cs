using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class dashboard : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Profile"] = "0";
            QuesAsked();
            QunsAns();
            Userd();
            QRejected();

        }
    }
    protected void QuesAsked()
    {
        string qry = "select count(*) as QunAsked from QuesMaster";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        lblQunAsked.Text = Convert.ToString(dt.Rows[0]["QunAsked"]);
    }
    protected void QunsAns()
    {
        string qry = "select count(distinct(Qid)) as Answer from AnsNotes";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        lblQunans.Text = Convert.ToString(dt.Rows[0]["Answer"]);
    }
    protected void Userd()
    {
        string qry = "select count(*) as userdetail from Details where Status = 'Active'";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        lbluserd.Text = Convert.ToString(dt.Rows[0]["userdetail"]);
    }
    protected void QRejected()
    {
        string qry = "select Q_Rejected as ques from dbo.loginmaster";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        lblQRej.Text = Convert.ToString(dt.Rows[0]["ques"]);
        
    }
}