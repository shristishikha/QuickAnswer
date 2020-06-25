using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class qcato : System.Web.UI.Page
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
        string qry = "select * from dbo.QuesTypeMaster order by Q_id desc";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            rptQues.DataSource = dt;
            rptQues.DataBind();
            Nothing.Visible = false;
            rptQues.Visible = true;
        }
        else
        {
            Nothing.Visible = true;
            rptQues.Visible = false;
        }
    }


    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (txtCat.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please fill category name');", true);

        }
        else
        {
            try
            {
                cn.Open();
                string qry = "insert into dbo.QuesTypeMaster(Ques_type, Date)values('" + txtCat.Text.Trim() + "','" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')";
                SqlCommand cmd = new SqlCommand(qry, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                txtCat.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Insertion Successful');", true);
                show();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Insertion Failed');", true);
                cn.Close();
                show();
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

            string qry = "delete from dbo.QuesTypeMaster where Q_id=" + id;
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
        TextBox ct = (TextBox)rpt.FindControl("txtCat");
        Label lct = (Label)rpt.FindControl("lblContactName");
        Label dt = (Label)rpt.FindControl("lbladate");

        ed.Visible = false;
        sv.Visible = true;
        cn.Visible = true;
        rm.Visible = false;
        ct.Visible = true;
        lct.Visible = false;
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
        TextBox ct = (TextBox)rpt.FindControl("txtCat");
        Label lct = (Label)rpt.FindControl("lblContactName");
        Label dt = (Label)rpt.FindControl("lbladate");

        try
        {
            cn.Open();
            string qry = "update dbo.QuesTypeMaster set Ques_type ='" + ct.Text + "' where Q_id=" + id;
            SqlCommand cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Modification Saved');", true);

            ed.Visible = true;
            sv.Visible = false;
            cnx.Visible = false;
            rm.Visible = true;
            ct.Visible = false;
            lct.Visible = true;
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
        TextBox ct = (TextBox)rpt.FindControl("txtCat");
        Label lct = (Label)rpt.FindControl("lblContactName");
        Label dt = (Label)rpt.FindControl("lbladate");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Modification Discarded');", true);

        ed.Visible = true;
        sv.Visible = false;
        cn.Visible = false;
        rm.Visible = true;
        ct.Visible = false;
        lct.Visible = true;
        dt.Visible = true;
    }
}