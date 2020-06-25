using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class faq : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            rptQues.DataSource = dt;
            rptQues.DataBind();
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (txtqun.Text == "" || txtans.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please fill question and answer');", true);

        }
        else
        {
            try
            {
                cn.Open();
                string qry = "insert into dbo.faqs(fqun,fans,date) values ('" + txtqun.Text.Trim() + "','" + txtans.Text.Trim() + "','" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')";
                SqlCommand cmd = new SqlCommand(qry, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                txtqun.Text = "";
                txtans.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Insertion Successful');", true);
                show();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Insertion Failed');", true);
                cn.Close();
            }


        }

    }

    protected void lbtnRem_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();

            var rpt = ((Control)sender).NamingContainer;
            HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
            id = Convert.ToInt32(hf.Value);

            string qry = "delete from dbo.faqs where fid=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Removed');", true);

            cn.Close();
            show();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sorry...This question cannot be removed');", true);
            cn.Close();
            show();
        }
    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        var rpt = ((Control)sender).NamingContainer;
        LinkButton ed = (LinkButton)rpt.FindControl("lbtnEdit");
        LinkButton sv = (LinkButton)rpt.FindControl("lbtnSave");
        LinkButton cn = (LinkButton)rpt.FindControl("lbtnCancel");
        LinkButton rm = (LinkButton)rpt.FindControl("lbtnRem");
        TextBox qn = (TextBox)rpt.FindControl("txtEQun");
        TextBox an = (TextBox)rpt.FindControl("txtEAns");
        Label lqn = (Label)rpt.FindControl("lblContactName");
        Label lan = (Label)rpt.FindControl("Label3");
        Label dt = (Label)rpt.FindControl("lbladate"); 

        ed.Visible = false;
        sv.Visible = true;
        cn.Visible = true;
        rm.Visible = false;
        qn.Visible = true;
        an.Visible = true;
        lqn.Visible = false;
        lan.Visible = false;
        dt.Visible = false;
    }
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        var rpt = ((Control)sender).NamingContainer;
        
        HiddenField hf = (HiddenField)rpt.FindControl("hfCustomerId");
        id = Convert.ToInt32(hf.Value);
        
        LinkButton ed = (LinkButton)rpt.FindControl("lbtnEdit");
        LinkButton sv = (LinkButton)rpt.FindControl("lbtnSave");
        LinkButton cnx = (LinkButton)rpt.FindControl("lbtnCancel");
        LinkButton rm = (LinkButton)rpt.FindControl("lbtnRem");
        TextBox qn = (TextBox)rpt.FindControl("txtEQun");
        TextBox an = (TextBox)rpt.FindControl("txtEAns");
        Label lqn = (Label)rpt.FindControl("lblContactName");
        Label lan = (Label)rpt.FindControl("Label3");
        Label dt = (Label)rpt.FindControl("lbladate");

        try
        {
            cn.Open();
            string qry = "update dbo.faqs set fqun='" + qn.Text + "', fans='" + an.Text + "' where fid=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Modification Saved');", true);

            ed.Visible = true;
            sv.Visible = false;
            cnx.Visible = false;
            rm.Visible = true;
            qn.Visible = false;
            an.Visible = false;
            lqn.Visible = true;
            lan.Visible = true;
            dt.Visible = true;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('An error occured modification...try again...');", true);
            cn.Close();
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        var rpt = ((Control)sender).NamingContainer;
        LinkButton ed = (LinkButton)rpt.FindControl("lbtnEdit");
        LinkButton sv = (LinkButton)rpt.FindControl("lbtnSave");
        LinkButton cn = (LinkButton)rpt.FindControl("lbtnCancel");
        LinkButton rm = (LinkButton)rpt.FindControl("lbtnRem");
        TextBox qn = (TextBox)rpt.FindControl("txtEQun");
        TextBox an = (TextBox)rpt.FindControl("txtEAns");
        Label lqn = (Label)rpt.FindControl("lblContactName");
        Label lan = (Label)rpt.FindControl("Label3");
        Label dt = (Label)rpt.FindControl("lbladate");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Modification Discarded');", true);

        ed.Visible = true;
        sv.Visible = false;
        cn.Visible = false;
        rm.Visible = true;
        qn.Visible = false;
        an.Visible = false;
        lqn.Visible = true;
        lan.Visible = true;
        dt.Visible = true;
    }
}