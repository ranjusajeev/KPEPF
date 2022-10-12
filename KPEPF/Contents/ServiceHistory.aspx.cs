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
using KPEPFClassLibrary;

public partial class Contents_ServiceHistory : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();
        }
    }
    private void InitialSettings()
    {
        setCtrls();
        SetGridDefault();
        Session["trType"] = 1;
        Session["rptType"] = 1;
    }
    private void setCtrls()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 5)
        {
            pnlMissEntry.Visible = true;
            pnlSer.Visible = false;
            DataSet ds2 = new DataSet();
            ds2 = genDAO.GetYearOnLine();
            gblObj.FillCombo(ddlYear, ds2, 1);
        }
        else
        {
            pnlMissEntry.Visible = false;
            pnlSer.Visible = true;
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("Period");
        gblObj.SetGridDefault(gdvSerHis, ar);
    }
    private void SetGridDefaultMissRem()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvEngDistName");
        ar.Add("chvEngLBName");
        ar.Add("chalDet");
        ar.Add("fltChalanAmt");
        ar.Add("amt");
        ar.Add("DT");
        ar.Add("ST");
        gblObj.SetGridDefault(gdvRem, ar);
    }
    private void SetGridDefaultMissW()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvEngDistName");
        ar.Add("chvTreasuryName");
        ar.Add("billDet");
        ar.Add("fltBillAmount");
        ar.Add("amt");
        gblObj.SetGridDefault(gdvWith, ar);
    }
    private void SetGridDefaultMissCons()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvYear");
        ar.Add("chvMonth");
        ar.Add("chvTreasuryName");
        ar.Add("fltAmountTreasury");
        ar.Add("fltBillAmount");
        ar.Add("diff");
        gblObj.SetGridDefault(gdvCons, ar);
    }
    private void SetGridDefaultLedger()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("chvYear");
        ar.Add("chvPeriod");
        //ar.Add("Rem");
        //ar.Add("fltWithdrawAmt");
        gblObj.SetGridDefault(gdvSerHisLedger, ar);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccNo.Text) > 0)
        {
            FillNameAccNo();
        }
        
        DataSet dsHis = new DataSet();
        ArrayList arHis = new ArrayList();
        arHis.Add(Convert.ToInt32(txtAccNo.Text));
        //dsHis = empDao.GetSerHistory(arHis);          Service history from EmpLBHistory table
        dsHis = empDao.GetSerHistoryFrmLedger(arHis);            //Service history from TB_Ledger_TRN table table
        SetGridDefault();   
        if (dsHis.Tables[0].Rows.Count > 0)
        {
            gdvSerHisLedger.DataSource = dsHis;
            gdvSerHisLedger.DataBind();
        }
        else
        {
            SetGridDefaultLedger();
            gblObj.MsgBoxOk("No data available!", this);
        }
    }
    private void FillNameAccNo()
    {
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(txtAccNo.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
            lblDistName.Text = dsN.Tables[0].Rows[0].ItemArray[8].ToString();
        }
    }
    protected void rdTrn_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlYear.SelectedValue = "0";
        if (rdTrn.Items[0].Selected == true)
        {
            Session["trType"] = 1;
        }
        else
        {
            Session["trType"] = 2;
        }
        if (Convert.ToInt16(Session["rptType"]) == 1)
        {
            gdvRem.Visible = false;
            gdvWith.Visible = false;
            gdvCons.Visible = true;
            fillGridCons(Convert.ToInt16(Session["trType"]));
        }
        else
        {
            if (rdTrn.Items[0].Selected == true)
            {
                gdvRem.Visible = true;
                gdvWith.Visible = false;
            }
            else
            {
                gdvRem.Visible = false;
                gdvWith.Visible = true;
            }
        }
    }
    private void fillGridCons(int tp)
    {
        SetGridDefaultMissCons();
        DataSet dsCons = new DataSet();
        if (tp == 1)
        {
            dsCons = empDao.getMissingRemCons();            
        }
        else
        {
            dsCons = empDao.getMissingWithCons();            //Service history from TB_Ledger_TRN table table            
        }
        gdvCons.DataSource = dsCons;
        gdvCons.DataBind();
        for (int i = 0; i < gdvCons.Rows.Count; i++)
        {
            GridViewRow gvr = gdvCons.Rows[i];
            Label lblsl = (Label)gvr.FindControl("lblsl");
            lblsl.Text = (i + 1).ToString();
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["yrMiss"] = Convert.ToInt16(ddlYear.SelectedValue);
            if (Convert.ToInt16(Session["trType"]) > 0)
            {
                FillGrid(Convert.ToInt16(Session["trType"]));
            }
        }
        else
        {
            Session["yrMiss"] = 0;
        }
    }
    private void FillGrid(int tp)
    {
        DataSet dsRem = new DataSet();
        DataSet dsW = new DataSet();
        ArrayList arRem = new ArrayList();
        arRem.Add(Convert.ToInt16(Session["yrMiss"]));
        if (tp == 1)
        {
            dsRem = empDao.getMissingRem(arRem);            //Service history from TB_Ledger_TRN table table
            SetGridDefaultMissRem();
            if (dsRem.Tables[0].Rows.Count > 0)
            {
                gdvRem.DataSource = dsRem;
                gdvRem.DataBind();
            }
            else
            {
                SetGridDefaultMissRem();
                gblObj.MsgBoxOk("No data available!", this);
            }
        }
        else
        {
            dsW = empDao.getMissingWith(arRem);            //Service history from TB_Ledger_TRN table table
            SetGridDefaultMissW();
            if (dsW.Tables[0].Rows.Count > 0)
            {
                gdvWith.DataSource = dsW;
                gdvWith.DataBind();
            }
            else
            {
                SetGridDefaultMissRem();
                gblObj.MsgBoxOk("No data available!", this);
            }
        }
    }
    protected void rdRptType_SelectedIndexChanged(object sender, EventArgs e)
    {
        gdvRem.Visible = false;
        gdvWith.Visible = false;
        gdvCons.Visible = true;
        if (rdRptType.Items[0].Selected == true)
        {
            Session["rptType"] = 1;
            ddlYear.Enabled = false;
            gdvRem.Visible = false;
            gdvWith.Visible = false;
            gdvCons.Visible = true;
        }
        else
        {           
            Session["rptType"] = 2;
            ddlYear.Enabled = true;
            gdvRem.Visible = true;
            gdvWith.Visible = true;
            gdvCons.Visible = false;
        }
    }
}
