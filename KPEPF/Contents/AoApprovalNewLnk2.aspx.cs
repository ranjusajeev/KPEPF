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

public partial class Contents_AoApprovalNewLnk2 : System.Web.UI.Page
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
            //if (Convert.ToInt16(Session["flgTp"]) == 1)
            //{
            //    gblObj.MsgBoxOk("No Schedule 4 Unposted chalan!", this);
            //}
            //else
            //{
            //    btnBack.Text = "Back to Approval";
                Initialsettings();
            //}
            
        }
    }
    private void Initialsettings()
    {
        FillGrid(Convert.ToInt16(Session["intTrnTypeApp"]));
        SetLbl();
    }
    private void FillGrid(int flgApp)
    {
        DataSet dsApp = new DataSet();
        DataSet dsApp2 = new DataSet();
        //aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdApp"]);
        if (Convert.ToInt16(Session["intYearIdApp"]) < 49)
        {
            aoRecorr.FlgYearPrev = 1;
        }
        else
        {
            aoRecorr.FlgYearPrev = 2;
        }
        aoRecorr.NumChalanId = Convert.ToDouble(Request.QueryString["intChalanId"]);

        dsApp = aoRecorrDAO.SelectApprovalPDELnk2(aoRecorr);
        if (dsApp.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsApp;
            gdvAOApprov.DataBind();
            gblObj.SetFooterTotals(gdvAOApprov, 4);
        }
        else
        {
            SetGridDefault();
        }

        dsApp2 = aoRecorrDAO.SelectApprovalPDELnk3(aoRecorr);
        if (dsApp2.Tables[0].Rows.Count > 0)
        {
            gdvAOApprovSched.DataSource = dsApp2;
            gdvAOApprovSched.DataBind();
            gblObj.SetFooterTotalsMltpl(gdvAOApprovSched, 4, 9);
        }
        else
        {
            SetGridDefaultSched();
        }
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
    private void SetGridDefaultSched()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("tnyUnIdentifiedAccNo");

        ar.Add("fltMsAmt");
        ar.Add("fltRfAmt");
        ar.Add("fltPfAmt");
        ar.Add("fltDaAmt");
        ar.Add("fltPayAmt");
        ar.Add("fltTotAmt1");
        
        gblObj.SetGridDefault(gdvAOApprovSched, ar);
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    private void SetLbl()
    {
        string strDist = "";
        string strType = "";

        string strYear = "";
        string strMonth = "";

        ArrayList ar1 = new ArrayList();
        if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
        {
            ar1.Add(Convert.ToInt64(Session["intYearIdRecMltpl"]));
            strYear = gendao.GetYearFromIdPde(ar1);
        }
        else
        {
            ar1.Add(Convert.ToInt64(Session["intYearIdApp"]));
            strYear = gendao.GetYearFromId(ar1);
        }
        Label2.Text = strYear;

        ArrayList ar2 = new ArrayList();
        if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
        {
            ar2.Add(Convert.ToInt64(Session["intMonthIdRecMltpl"]));
        }
        else
        {
            ar2.Add(Convert.ToInt64(Session["intMonthIdApp"]));
        }
        strMonth = gendao.GetMonthFromId(ar2);
        Label3.Text = strMonth;

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Request.QueryString["intDistId"]));
        strDist = gendao.GetDistrictFromId(ar);
        if (Convert.ToInt16(Session["intTrnTypeApp"]) == 1)
        {
            strType = "Remittance";
        }
        else if (Convert.ToInt16(Session["intTrnTypeApp"]) == 2)
        {
            strType = "Withdrawal";
        }
        else
        {
            strType = "Remittance";
        }
        lblType.Text = strType + " -  " + strDist;

        //Set back btn////
        if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
        {
            btnBack.Text = "Back to Reconcilation";
        }
        else
        {
            btnBack.Text = "Back to Approval";
        }
        
        //Set back btn////
    }
    protected void ddlSched_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/ReclMltpl3.aspx";
    //    }
    //    else
    //    {
    //        btnBack.PostBackUrl = "~/Contents/AoApprovalNewLnk1.aspx";
    //    }
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
        {
            btnBack.PostBackUrl = "~/Contents/ReclMltpl3.aspx";
        }
        else
        {
            btnBack.PostBackUrl = "~/Contents/AoApprovalNewLnk1.aspx";
        }
    }
}
