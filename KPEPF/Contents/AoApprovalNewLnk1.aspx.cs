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

public partial class Contents_AoApprovalNewLnk1 : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    AORecorrection aoRecorr = new AORecorrection();
    AORecorrectionDAO aoRecorrDAO = new AORecorrectionDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettings();
            if (Convert.ToInt16(Session["intDistIdApp"]) > 0)
            {
                FillGrid(Convert.ToInt16(Session["intTrnType"]));
            }
            else
            {
                Response.Redirect("AoApprovalNew.aspx");
            }
        }
    }
    private void Initialsettings()
    {
        
        if (Convert.ToInt16(Request.QueryString["intDistrictId"]) > 0)
        {
            Session["intDistIdApp"] = Convert.ToInt16(Request.QueryString["intDistrictId"]);
        }
        SetLbl();
        //FillGrid(Convert.ToInt16(Session["intTrnType"]));

        //if (gblObj.IntTreIdAO > 0)
        //{
        //    FillOnBack();
        //}
        //else
        //{
        //    //SelectionRadio();
        //}

        //if (Convert.ToInt16(gblObj.IntTreIdAO) > 0)
        //{
        //    ddlYear.SelectedValue = gblObj.IntYearIdAo.ToString();
        //    ddlMonth.SelectedValue = gblObj.IntMonthIdAo.ToString();
        //    ddlDistrict.SelectedValue = gblObj.IntDistAO.ToString();
        //    FillDTreasury();
        //    ddlDistricttre.SelectedValue = gblObj.IntTreIdAO.ToString();
        //    FillGridView();
        //}
    }
    private void FillOnBack()
    {

    }
    private void SetLbl()
    {
        string strDist = "";
        string strType = "";

        string strYear = "";
        string strMonth = "";

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt64(Session["intYearIdApp"]));
        strYear = gendao.GetYearFromId(ar1);
        Label2.Text = strYear;

        ArrayList ar2 = new ArrayList();
        ar2.Add(Convert.ToInt64(Session["intMonthIdApp"]));
        strMonth = gendao.GetMonthFromId(ar2);
        Label3.Text = strMonth;

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["intDistIdApp"]));
        strDist = gendao.GetDistrictFromId(ar);
        if (Convert.ToInt16(Session["intTrnType"]) == 36)
        {
            strType = "Remittance";
        }
        else
        {
            strType = "Withdrawal";   
        }
        lblType.Text = strType + " -  " + strDist;
    }
    private void FillGrid(int intTrnTypeApp)
    {
        DataSet dsApp = new DataSet();
        if (Convert.ToInt16(Request.QueryString["intDistrictId"]) > 0)
        {
            aoRecorr.IntDistID = Convert.ToInt16(Request.QueryString["intDistrictId"]);
        }
        else
        {
            aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdApp"]);
        }
        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdApp"]);
        aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdApp"]);
        if (intTrnTypeApp == 36)
        {
            gdvAOApprov.Visible = true;
            gdvAOApprovWith.Visible = false;
            dsApp = aoRecorrDAO.SelectApprovalPDELnk1(aoRecorr);
            if (dsApp.Tables[0].Rows.Count > 0)
            {
                gdvAOApprov.DataSource = dsApp;
                gdvAOApprov.DataBind();
                gblObj.SetFooterTotals(gdvAOApprov, 3);
            }
            else
            {
                SetGridDefault();
            }
        }
        else
        {
            gdvAOApprov.Visible = false;
            gdvAOApprovWith.Visible = true;
            dsApp = aoRecorrDAO.SelectApprovalPDELnk1With(aoRecorr);
            if (dsApp.Tables[0].Rows.Count > 0)
            {
                gdvAOApprovWith.DataSource = dsApp;
                gdvAOApprovWith.DataBind();
                gblObj.SetFooterTotals(gdvAOApprovWith, 3);
            }
            else
            {
                SetGridDefaultWith();
            }
        }
        //if (dsApp.Tables[0].Rows.Count > 0)
        //{
        //    gdvAOApprov.DataSource = dsApp;
        //    gdvAOApprov.DataBind();
        //}
        //else
        //{
        //    SetGridDefault();
        //}
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("ChalDet");

        ar.Add("fltChalanAmt");
        ar.Add("fltTotalSum");
        ar.Add("intChalanId");
        ar.Add("intDistID");
        gblObj.SetGridDefault(gdvAOApprov, ar);
    }
    private void SetGridDefaultWith()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("AccNo");
        ar.Add("chvName");

        ar.Add("fltAdvAmt");
        ar.Add("dtSantion");
        gblObj.SetGridDefault(gdvAOApprovWith, ar);
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AoApprovalNew.aspx");
    }
}
