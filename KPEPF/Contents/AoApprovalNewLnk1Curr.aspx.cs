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

public partial class Contents_AoApprovalNewLnk1Curr : System.Web.UI.Page
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
            FillGrid(Convert.ToInt16(Session["intTrnType"]));
        }
    }
    private void Initialsettings()
    {
        if (Convert.ToInt16(Request.QueryString["intDTreasuryId"]) > 0)
        {
            Session["intDTreasuryId"] = Convert.ToInt16(Request.QueryString["intDTreasuryId"]);
        }
        else
        {
            FillGrid(Convert.ToInt16(Session["intTrnType"]));
        }
        
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
        ar.Add(Convert.ToInt16(Session["intDTreasuryId"]));
        strDist = gendao.GetDisTreasuryFromId(ar);
        if (Convert.ToInt16(Session["intTrnType"]) == 38)
        {
            strType = "Remittance";
            lblAmt.Text = gdvAOApprov.FooterRow.Cells[3].Text.ToString();
        }
        else
        {
            strType = "Withdrawal";
            lblAmt.Text = gdvAOApprovWith.FooterRow.Cells[3].Text.ToString();
        }
        lblType.Text = strType + " -  " + strDist;

    }
    private void FillGrid(int intTrnTypeApp)
    {
        DataSet dsApp = new DataSet();
        if (Convert.ToInt16(Request.QueryString["intDTreasuryId"]) > 0)
        {
            aoRecorr.IntDistTID = Convert.ToInt16(Request.QueryString["intDTreasuryId"]);
        }
        else
        {
            aoRecorr.IntDistTID = Convert.ToInt16(Session["intDTreasuryId"]);
        }
        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdApp"]);
        aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdApp"]);
        if (intTrnTypeApp == 38)
        {
            gdvAOApprov.Visible = true;
            gdvAOApprovWith.Visible = false;
            dsApp = aoRecorrDAO.SelectApprovalPDELnk1Curr(aoRecorr);
            if (dsApp.Tables[0].Rows.Count > 0)
            {
                gdvAOApprov.DataSource = dsApp;
                gdvAOApprov.DataBind();
                for (int i = 0; i < dsApp.Tables[0].Rows.Count; i++)
                {
                    GridViewRow gvRw = gdvAOApprov.Rows[i];
                    if (Convert.ToDouble(dsApp.Tables[0].Rows[i].ItemArray[5]) != Convert.ToDouble(dsApp.Tables[0].Rows[i].ItemArray[6]))
                    {
                        gvRw.Cells[3].ForeColor = System.Drawing.Color.Red;
                        gvRw.Cells[3].Font.Bold = true;

                        gvRw.Cells[4].ForeColor = System.Drawing.Color.Red;
                        gvRw.Cells[4].Font.Bold = true;
                    }

                }
                gblObj.SetFooterTotals(gdvAOApprov, 3);
                gblObj.SetFooterTotals(gdvAOApprov, 4);
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
            dsApp = aoRecorrDAO.SelectApprovalPDELnk1WithCurr(aoRecorr);
            if (dsApp.Tables[0].Rows.Count > 0)
            {
                gdvAOApprovWith.DataSource = dsApp;
                gdvAOApprovWith.DataBind();
                gblObj.SetFooterTotals(gdvAOApprovWith, 3);
                //gblObj.SetFooterTotals(gdvAOApprovWith, 4);
            }
            else
            {
                SetGridDefaultWith();
            }
        }
        SetLbl();
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
        ar.Add("ChalType");
        
        gblObj.SetGridDefault(gdvAOApprov, ar);
    }
    private void SetGridDefaultWith()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");

        ar.Add("fltAllottedAmt");
        ar.Add("dtmWithdrawalEmp");
        gblObj.SetGridDefault(gdvAOApprovWith, ar);
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AoApprovalNewCurr.aspx";
    }
    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/AoApprovalNewCurr.aspx";
    //}
}
