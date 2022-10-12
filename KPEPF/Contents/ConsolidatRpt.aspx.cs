using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using KPEPFClassLibrary;


public partial class Contents_ConsolidatRpt : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO kgen = new KPEPFGeneralDAO();
    GeneralDAO gen = new GeneralDAO();
    WithdrawalCDao wth = new WithdrawalCDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();
        }
    }
    private void InitialSettings()
    {
        DataSet dsY = new DataSet();
        dsY = gen.GetYearRem();
        gblObj.FillCombo(ddlYear, dsY, 1);

        DataSet dsM = new DataSet();
        dsM = kgen.GetMonth();
        gblObj.FillCombo(ddlMonth, dsM, 1);

        Session["tp"] = 1;
    }
    protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdCategory.Items[0].Selected == true)
        {
            Session["tp"] = 1;
            gdvChalan.Visible = false ;
            gdvClosure.Visible = false;
            gdvAcc.Visible = false;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
        }
        else if (rdCategory.Items[1].Selected == true)
        {
            Session["tp"] = 2;
            gdvChalan.Visible = false;
            gdvClosure.Visible = false;
            gdvAcc.Visible = false;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
        }
        else if (rdCategory.Items[2].Selected == true)
        {
            Session["tp"] = 3;
            gdvChalan.Visible = false;
            gdvClosure.Visible = true;
            gdvAcc.Visible = false;
            ddlYear.Enabled = false;
            ddlMonth.Enabled = false;
            FillClosure();
        }
        else if (rdCategory.Items[3].Selected == true)
        {
            Session["tp"] = 4;
            gdvChalan.Visible = true;
            gdvClosure.Visible = false;
            gdvAcc.Visible = false;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
        }
        else if (rdCategory.Items[4].Selected == true)
        {
            Session["tp"] = 5;
            gdvChalan.Visible = true;
            gdvClosure.Visible = false;
            gdvAcc.Visible = false;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
        }
        else if (rdCategory.Items[5].Selected == true)
        {
            Session["tp"] = 6;
            gdvChalan.Visible = false;
            gdvClosure.Visible = false;
            gdvAcc.Visible = true;
            ddlYear.Enabled = false;
            ddlMonth.Enabled = false;
            FillAcc();
        }
        ddlYear.SelectedValue = "0";
        ddlMonth.SelectedValue = "0";
        //FillData(Convert.ToInt16(Session["tp"]));
    }
    private void SetGridDefault()
    {
        ArrayList arc = new ArrayList();
        arc.Add("SlNo");
        arc.Add("Cnt");
        arc.Add("ttlAmt");
        gblObj.SetGridDefault(gdvChalan, arc);
    }
    private void SetGridDefaultC()
    {
        ArrayList arc = new ArrayList();
        arc.Add("chvYear");
        arc.Add("cnt");
        arc.Add("fltAmt");
        gblObj.SetGridDefault(gdvClosure, arc);
    }
    private void SetGridDefaultA()
    {
        ArrayList arc = new ArrayList();
        arc.Add("chvYear");

        gblObj.SetGridDefault(gdvAcc, arc);
    }
    private void FillData(int tp)
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt16(Session["intYearWC"]));
        ar.Add(Convert.ToInt16(Session["intMonthWC"]));
        ar.Add(tp);

        ds = wth.FillConsAmt(ar);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblAmt.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            lblAmt.Text = "...";
        }
    }
    private void FillGrid(int tp)
    {
        SetGridDefault();
        
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt16(Session["intYearWC"]));
        ar.Add(Convert.ToInt16(Session["intMonthWC"]));
        if (tp == 4)
        {
            //if (Convert.ToInt16(Session["intYearWC"]) < 50)
            //{
                ds = wth.FillConsAmtToGPF(ar);
            //}
            //else
            //{
            //    ds = wth.FillConsAmtToGPF14(ar);
            //}
        }
        else
        {
            if (Convert.ToInt16(Session["intYearWC"]) < 50)
            {
                ds = wth.FillConsAmtToKPEPF(ar);
            }
            else
            {
                ds = wth.FillConsAmtToKPEPF14(ar);
            }
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvChalan.DataSource = ds;
            gdvChalan.DataBind();
            //lblAmt.Text = "...";
            gdvChalan.Visible = true;
        }
        else
        {
            SetGridDefault();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["intYearWC"] = Convert.ToInt16(ddlYear.SelectedValue);
            FillData(Convert.ToInt16(Session["tp"]));
        }
        else
        {
            Session["intYearWC"] = 0;
            lblAmt.Text = "...";
        }

    }
    private void FillClosure()
    {
        DataSet ds = new DataSet();
        ds = wth.FillClosure();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvClosure.DataSource = ds;
            gdvClosure.DataBind();
        }
        else
        {
            SetGridDefaultC();
        }
    }
    private void FillAcc()
    {
        EmployeeDAO empd = new EmployeeDAO();
        DataSet ds = new DataSet();
        DataSet dsy = new DataSet();
        
        dsy = kgen.GetYearOnLineNdPDE();
        if (dsy.Tables[0].Rows.Count > 0)
        {
            gdvAcc.DataSource = dsy;
            gdvAcc.DataBind();
        }
        else
        {
            SetGridDefaultA();
        }

        for (int i = 0; i < gdvAcc.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();
            GridViewRow gdvrow = gdvAcc.Rows[i];

            Label lblYr = (Label)gdvrow.FindControl("lblYr");
            Label lblCnt = (Label)gdvrow.FindControl("lblCnt");
            Label lblAmt = (Label)gdvrow.FindControl("lblAmt");
            
            lblYr.Text = dsy.Tables[0].Rows[i].ItemArray[0].ToString();

            ar.Add(Convert.ToInt16(lblYr.Text));
            ds = empd.FillAccYearWise(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCnt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblAmt.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                if (i >= 1)
                {
                    GridViewRow gdvrowP = gdvAcc.Rows[i - 1];
                    Label lblAmtP = (Label)gdvrowP.FindControl("lblAmt");
                    lblAmt.Text = Convert.ToString(Convert.ToInt32(lblCnt.Text) + Convert.ToInt32(lblAmtP.Text));
                }
            }
        }

        

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["intMonthWC"] = Convert.ToInt16(ddlMonth.SelectedValue);
        }
        else
        {
            Session["intMonthWC"] = 0;
        }
        if (Convert.ToInt16(Session["intYearWC"]) > 0)
        {
            if (Convert.ToInt16(Session["tp"]) <= 3)
            {
                FillData(Convert.ToInt16(Session["tp"]));
            }
            else
            {
                FillGrid(Convert.ToInt16(Session["tp"]));
            }
        }
    }
}
