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

public partial class Contents_WithdrawalPDEAG : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    WithdrawalPDE wth;
    WithdrawalPDEDAO wthd;
    Employee emp;
    EmployeeDAO empD;
    WithdrawalPDEAG pdeAG;
    WithdrawalPDEAGDAO pdeAGDAO;
    CorrectionEntry corr;
    CorrectionEntryDao corrDao;
    public int mnthId;
    static double fltAmtBfr = 0;
    static int intCorrType = 0;
    static int intCurRw = 0;
    static int intCurRwA = 0;
    public int cntclick = 0;
    int corrType = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Convert.ToInt16(Session["flgPageBack"]) == 6) || (Convert.ToInt16(Session["flgPageBack"]) == 7))
            {
                if (Request.QueryString["intVoucherID"] != "" && Request.QueryString["intVoucherID"] != "0")
                {
                    Session["intVoucherIDEdit"] = Convert.ToDouble(Request.QueryString["intVoucherID"]);
                    InitialSettings();
                    FillWithdrawal();
                    lSubFillBillAmt();
                    SetCtrls();
                }
                else
                {
                    Response.Redirect("DebitPlusPDE.aspx");
                }
            }
            else
            {
                InitialSettings();
            }
          
        }

    }
    private void InitialSettings()
    {
        SetGridDefault();
        FillDdls();
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        gblObj.SetGridDefault(gdvWithAG, ar);
    }
    private void FillDdls()
    {
        gblObj = new clsGlobalMethods();
        gendao = new GeneralDAO();
        pdeAGDAO = new WithdrawalPDEAGDAO();

        DataSet dsdesig = new DataSet();
        dsdesig = pdeAGDAO.Getdesignation();

        DataSet dsl = new DataSet();
        dsl = pdeAGDAO.GetLoanType();


        DataSet dspurpse = new DataSet();
        dspurpse = pdeAGDAO.GetLoanPurpose();


        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(2);
        dsM =gendao.GetMisClassRsn(arrIn);

        DataSet dsstatus = new DataSet();
        dsstatus = pdeAGDAO.GetStatus();
      
        for (int i = 0; i < gdvWithAG.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvWithAG.Rows[i];
            DropDownList ddldesig = (DropDownList)gdvrow.FindControl("ddldesig");
            gblObj.FillCombo(ddldesig, dsdesig, 1);

            DropDownList ddlType = (DropDownList)gdvrow.FindControl("ddlType");
            gblObj.FillCombo(ddlType, dsl, 1);

            DropDownList ddlpurpose = (DropDownList)gdvrow.FindControl("ddlpurpose");
            gblObj.FillCombo(ddlpurpose, dspurpse, 1);
            
            DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");
            gblObj.FillCombo(ddlUnPAss, dsM, 1);

            DropDownList ddlStatus = (DropDownList)gdvrow.FindControl("ddlStatus");
            gblObj.FillCombo(ddlStatus, dsstatus, 1);


        }

    }
    private void lSubFillBillAmt()
    {
        pdeAG = new WithdrawalPDEAG();
        pdeAGDAO = new WithdrawalPDEAGDAO();

        DataSet dsbill = new DataSet();
        pdeAG.IntVoucherAGID = Convert.ToInt32(Session["intVoucherIDEdit"]);
        dsbill = pdeAGDAO.GetBillDetails(pdeAG);
        if (dsbill.Tables[0].Rows.Count > 0)
        {
            lblAmt.Text = dsbill.Tables[0].Rows[0].ItemArray[0].ToString();
            txtDate.Text = dsbill.Tables[0].Rows[0].ItemArray[1].ToString();
            lblDate.Text = dsbill.Tables[0].Rows[0].ItemArray[1].ToString();
        }

    }
    private void FillWithdrawal()
    {
        gblObj = new clsGlobalMethods();
        pdeAG = new WithdrawalPDEAG();
        pdeAGDAO = new WithdrawalPDEAGDAO();

        DataSet dsW = new DataSet();
        pdeAG.IntVoucherAGID = Convert.ToInt32(Session["intVoucherIDEdit"]);
        dsW = pdeAGDAO.GetWithdrawaEmp(pdeAG);
        if (dsW.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsW.Tables[0].Rows.Count.ToString();
            gdvWithAG.DataSource = dsW;
            gdvWithAG.DataBind();
            FillDdls();
            for (int i = 0; i < gdvWithAG.Rows.Count; i++)
            {
                GridViewRow gdvrow = gdvWithAG.Rows[i];
                TextBox txtAccNoAss = (TextBox)gdvrow.FindControl("txtAccNo");
                Label lblName = (Label)gdvrow.FindControl("lblName");
                DropDownList ddldesigAss = (DropDownList)gdvrow.FindControl("ddldesig");
                DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
                TextBox txtOrderNoAss = (TextBox)gdvrow.FindControl("txtOrderNo");
                TextBox txtOrderDateAss = (TextBox)gdvrow.FindControl("txtOrderDate");
                TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
                DropDownList ddlpurposeAss = (DropDownList)gdvrow.FindControl("ddlpurpose");
                TextBox txtOrderNoDateAss = (TextBox)gdvrow.FindControl("txtOrderNoDate");

                TextBox txtAmtPreTaAss = (TextBox)gdvrow.FindControl("txtAmtPreTa");
                TextBox txtBalTAAss = (TextBox)gdvrow.FindControl("txtBalTA");
                TextBox txtConsolidatedAss = (TextBox)gdvrow.FindControl("txtConsolidated");

                TextBox txtInstNoAss = (TextBox)gdvrow.FindControl("txtInstNo");
                TextBox instAmtAss = (TextBox)gdvrow.FindControl("txtinstAmt");

                CheckBox chkUnPAss = (CheckBox)gdvrow.FindControl("chkUnP");
                DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");

                TextBox txtRemarksAss = (TextBox)gdvrow.FindControl("txtRemarks");
                DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");

                Label AccNoAss = (Label)gdvrow.FindControl("lblNewAcc");
                TextBox UnpostedReasonIdAss = (TextBox)gdvrow.FindControl("txtUnpostedReasonId");

                TextBox TypeIdAss = (TextBox)gdvrow.FindControl("txtTypeId");
                TextBox VoucherIdAss = (TextBox)gdvrow.FindControl("txtVoucherId");
                TypeIdAss.Text = dsW.Tables[0].Rows[i].ItemArray[3].ToString();

                Label  WithIDPDEAss = (Label)gdvrow.FindControl("lblWithIDPDE");
                TextBox desigIdAss = (TextBox)gdvrow.FindControl("txtdesigId");

                Label  OldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
                Label OldAccNoAss = (Label)gdvrow.FindControl("lblOldAcc");

                txtAccNoAss.Text = dsW.Tables[0].Rows[i].ItemArray[18].ToString();
                OldAccNoAss.Text = dsW.Tables[0].Rows[i].ItemArray[0].ToString();
                lblName.Text = dsW.Tables[0].Rows[i].ItemArray[1].ToString();
                ddldesigAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[2].ToString();
                ddlTypeAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[3].ToString();
                txtOrderNoAss.Text = dsW.Tables[0].Rows[i].ItemArray[4].ToString();
                txtOrderDateAss.Text = dsW.Tables[0].Rows[i].ItemArray[5].ToString();
                //Session["chalDate"] = dsW.Tables[0].Rows[i].ItemArray[5].ToString();
                txtAmtAss.Text = dsW.Tables[0].Rows[i].ItemArray[6].ToString();
                OldAmtAss.Text = dsW.Tables[0].Rows[i].ItemArray[6].ToString();
                ddlpurposeAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[7].ToString();

                txtOrderNoDateAss.Text = dsW.Tables[0].Rows[i].ItemArray[8].ToString();
                txtAmtPreTaAss.Text = dsW.Tables[0].Rows[i].ItemArray[9].ToString();
                txtBalTAAss.Text = dsW.Tables[0].Rows[i].ItemArray[10].ToString();

                txtConsolidatedAss.Text = dsW.Tables[0].Rows[i].ItemArray[11].ToString();
                txtInstNoAss.Text = dsW.Tables[0].Rows[i].ItemArray[12].ToString();

                instAmtAss.Text = dsW.Tables[0].Rows[i].ItemArray[13].ToString();

                if (Convert.ToInt16(dsW.Tables[0].Rows[i].ItemArray[14]) == 2)
                {
                    chkUnPAss.Checked = true;
                }
                else
                {
                    chkUnPAss.Checked = false;
                }
                ddlUnPAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[15].ToString();
                UnpostedReasonIdAss.Text = dsW.Tables[0].Rows[i].ItemArray[15].ToString();

                ddlStatusAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[16].ToString();
                AccNoAss.Text = dsW.Tables[0].Rows[i].ItemArray[0].ToString();

                VoucherIdAss.Text = (Session["intVoucherIDEdit"]).ToString();
                WithIDPDEAss.Text = dsW.Tables[0].Rows[i].ItemArray[17].ToString();
            }
            gblObj.SetFooterTotalsTempField(gdvWithAG, 7, "txtAmt", 1);
            btnSave.Enabled = true;
        }
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAg"]) == 2)
        {
            gdvWithAG.Enabled = true;
            txtCnt.Enabled = true;
            btnSave.Enabled = true;
        }
        else
        {
            gdvWithAG.Enabled = false;
            txtCnt.Enabled = false;
            btnSave.Enabled = false;
        }
    }
    //protected void btnBack_Click(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["flgPageBack"]) == 6)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/DebitPlusPDE.aspx";
    //    }
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["flgPageBack"]) == 6)
        {
            btnBack.PostBackUrl = "~/Contents/DebitPlusPDE.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 7)
        {
            btnBack.PostBackUrl = "~/Contents/DAERDBPlus.aspx";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        cntclick = cntclick + 1;
        if (cntclick == 1)
        {
            lSubSaveWithdrawIdPDE();
        }
        else
        {
            btnSave.Enabled = false;
        }
        btnSave.Enabled = false;
    }
    //private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr)
    //{
    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    //double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, fltAmtBfr - fltAmtAfr);
    //    double dblCalcAmt = fltAmtBfr - fltAmtAfr;
    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, 1, dblCalcAmt);
    //    ///// Save to CorrEntry/////////
    //    corr.IntAccNo = intAccNo;
    //    corr.IntYearID = yr;
    //    corr.IntMonthID = mth;
    //    corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    corr.FltAmountBefore = fltAmtBfr;
    //    corr.FltAmountAfter = fltAmtAfr;  
    //    corr.FltCalcAmount = dblAmtAdjusted;
    //    corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    corr.IntChalanId = chalId;
    //    corr.IntSchedId = intSchedId;
    //    corr.FlgType = 2;           //Remittance
    //    corr.FltRoundingAmt = 0;
    //    corr.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    corr.IntChalanType = 2;
    //    corrDao.CreateCorrEntry(corr);
    //    ///// Save to CorrEntry/////////
    //}
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtDt)
    {
        gblObj = new clsGlobalMethods();
        Boolean flg = true;
        if (txtAmt.Text.ToString() == "" || txtDt.Text.ToString() == "")
        {
            //if (Convert.ToDouble(txtAmt.Text) == 0 || Convert.ToInt16(txtNo.Text) == 0 || Convert.ToString(txtDt.Text) == "" || Convert.ToInt16(ddlCh.SelectedValue) == 0)
            //{
            gblObj.MsgBoxOk("Enter all details!", this);
            flg = false;
            //}
            //else
            //{
            //    flg = true;
            //}
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void lSubSaveWithdrawIdPDE()
    {
        gblObj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        wth = new WithdrawalPDE();
        pdeAG = new WithdrawalPDEAG();
        pdeAGDAO = new WithdrawalPDEAGDAO();

        for (int i = 0; i < gdvWithAG.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvWithAG.Rows[i];
            TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            TextBox txtOrderDateAss = (TextBox)gdvrow.FindControl("txtOrderDate");
            Label lblEditModeAss = (Label)gdvrow.FindControl("lblEditMode");

            //// setEditMdForTp //////////////
            TextBox txtTypeId = (TextBox)gdvrow.FindControl("txtTypeId");
            DropDownList ddlType = (DropDownList)gdvrow.FindControl("ddlType");
            if (Convert.ToInt16(ddlType.SelectedValue) != Convert.ToInt16(txtTypeId.Text))
            {
                lblEditModeAss.Text = "1";
            }
            //// setEditMdForTp //////////////

            if (CheckMandatory(txtAmtAss, txtOrderDateAss) == true)
            {
                if (Convert.ToInt16(lblEditModeAss.Text) >= 1)
                {
                    Label WithIDPDEAss = (Label)gdvrow.FindControl("lblWithIDPDE");
                    TextBox txtAccNoAss = (TextBox)gdvrow.FindControl("txtAccNo");
                    DropDownList ddldesigAss = (DropDownList)gdvrow.FindControl("ddldesig");
                    TextBox txtOrderNoAss = (TextBox)gdvrow.FindControl("txtOrderNo");
                    DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
                    TextBox txtConsolidatedAss = (TextBox)gdvrow.FindControl("txtConsolidated");
                    TextBox txtInstNoAss = (TextBox)gdvrow.FindControl("txtInstNo");
                    TextBox instAmtAss = (TextBox)gdvrow.FindControl("txtinstAmt");
                    DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
                    DropDownList ddlpurposeAss = (DropDownList)gdvrow.FindControl("ddlpurpose");
                    TextBox txtOrderNoDateAss = (TextBox)gdvrow.FindControl("txtOrderNoDate");
                    TextBox txtAmtPreTaAss = (TextBox)gdvrow.FindControl("txtAmtPreTa");
                    TextBox txtBalTAAss = (TextBox)gdvrow.FindControl("txtBalTA");
                    CheckBox chkUnPAss = (CheckBox)gdvrow.FindControl("chkUnP");
                    DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");
                    DateTime billDate = Convert.ToDateTime(txtDate.Text.ToString());
                    Label lblNewAccAss = (Label)gdvrow.FindControl("lblNewAcc");
                    Label lblOldAccAss = (Label)gdvrow.FindControl("lblOldAcc");
                    Label lblOldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
                    //TextBox txtVoucherId = (TextBox)gdvrow.FindControl("txtVoucherId");
                    
                    if (WithIDPDEAss.Text == "")
                    {
                        pdeAG.IntId = 0;
                    }
                    else
                    {
                        pdeAG.IntId = Convert.ToInt32(WithIDPDEAss.Text);

                    }
                    if (txtAccNoAss.Text == "")
                    {
                        pdeAG.IntAccNo = 0;
                    }
                    else
                    {
                        pdeAG.IntAccNo = Convert.ToInt32(lblNewAccAss.Text);
                    }
                    if (ddldesigAss.SelectedIndex > 0)
                    {
                        pdeAG.IntDesignation = Convert.ToInt32(ddldesigAss.SelectedValue);
                    }
                    else
                    {
                        pdeAG.IntDesignation = 0;
                    }
                    if (txtAmtAss.Text == "")
                    {
                        pdeAG.FltAdvAmt = 0;
                    }
                    else
                    {
                        pdeAG.FltAdvAmt = Convert.ToDecimal(txtAmtAss.Text);
                    }
                    if (txtOrderNoAss.Text == "")
                    {
                        pdeAG.ChvSantionNo = "";
                    }
                    else
                    {
                        pdeAG.ChvSantionNo = txtOrderNoAss.Text.ToString();
                    }
                    if (txtOrderDateAss.Text == "")
                    {
                        pdeAG.DtSantion = "";
                    }
                    else
                    {
                        pdeAG.DtSantion = txtOrderDateAss.Text.ToString();
                    }
                    if (ddlTypeAss.SelectedIndex > 0)
                    {
                        pdeAG.IntLoan = Convert.ToInt32(ddlTypeAss.SelectedValue);
                    }
                    else
                    {
                        pdeAG.IntLoan = 0;
                    }
                    if (txtDate.Text == "")
                    {
                        pdeAG.DtWithdraw = "";
                    }
                    else
                    {
                        pdeAG.DtWithdraw = txtDate.Text.ToString();
                    }
                    if (txtConsolidatedAss.Text == "")
                    {
                        pdeAG.FltConsolidate = 0;
                    }
                    else
                    {
                        pdeAG.FltConsolidate = Convert.ToDecimal(txtConsolidatedAss.Text);
                    }
                    if (txtInstNoAss.Text == "")
                    {
                        pdeAG.IntNoOfInstalments = 0;
                    }
                    else
                    {
                        pdeAG.IntNoOfInstalments = Convert.ToInt32(txtInstNoAss.Text);
                    }
                    if (instAmtAss.Text == "")
                    {
                        pdeAG.FltInstalmentAmt = 0;
                    }
                    else
                    {
                        pdeAG.FltInstalmentAmt = Convert.ToInt32(instAmtAss.Text);
                    }
                    ArrayList ardt1 = new ArrayList();
                    ardt1.Add(txtDate.Text.ToString());
                    pdeAG.IntYrId = genDAO.gFunFindPDEYearIdFromDate(ardt1);
                    if (ddlStatusAss.SelectedIndex > 0)
                    {
                        pdeAG.IntModeOfChgId = Convert.ToInt32(ddlStatusAss.SelectedValue);
                    }
                    else
                    {
                        pdeAG.IntModeOfChgId = 2;
                    }
                    pdeAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
                    pdeAG.DtmDateOfUpdation = DateTime.Now.ToString();
                    pdeAG.IntVoucherAGID = Convert.ToInt32(Session["intVoucherIDEdit"]);
                    if (ddlpurposeAss.SelectedIndex > 0)
                    {
                        pdeAG.IntLoanPurpose = Convert.ToInt32(ddlpurposeAss.SelectedValue);
                    }
                    else
                    {
                        pdeAG.IntLoanPurpose = 0;
                    }
                    pdeAG.IntDrawnBy = 1;
                    if (txtOrderNoDateAss.Text == "")
                    {
                        pdeAG.ChvOdrNoDtOfPrevTA = "";
                    }
                    else
                    {
                        pdeAG.ChvOdrNoDtOfPrevTA = txtOrderNoDateAss.Text.ToString();
                    }
                    if (txtAmtPreTaAss.Text == "")
                    {
                        pdeAG.FltAmtPrevTA = 0;
                    }
                    else
                    {
                        pdeAG.FltAmtPrevTA = Convert.ToInt32(txtAmtPreTaAss.Text);
                    }
                    if (txtBalTAAss.Text == "")
                    {
                        pdeAG.FltBalancePrevTA = 0;
                    }
                    else
                    {
                        pdeAG.FltBalancePrevTA = Convert.ToInt32(txtBalTAAss.Text);
                    }
                    if (chkUnPAss.Checked == true)
                    {
                        pdeAG.FlgUnPosted = 2;
                    }
                    else
                    {
                        pdeAG.FlgUnPosted = 1;
                    }
                    if (ddlUnPAss.SelectedIndex > 0)
                    {
                        pdeAG.IntUnPostedRsn = Convert.ToInt32(ddlUnPAss.SelectedValue);
                    }
                    else
                    {
                        pdeAG.IntUnPostedRsn = 0;
                    }
                    mnthId = billDate.Month;
                    pdeAG.Intmid = Convert.ToInt32(mnthId.ToString());
                    pdeAG.IntDisId = FindDistId(Convert.ToInt32(Session["intVoucherIDEdit"]));
                    DataSet ds = new DataSet();
                    ds = pdeAGDAO.UpdateWithPde1(pdeAG);
                    WithIDPDEAss.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    saveCorrectionEntry(i, Convert.ToInt32(WithIDPDEAss.Text), 0);
                }
            }

        }
        FillWithdrawal();
        gblObj.MsgBoxOk("Saved successfully", this);
    }
    //private void lSubSaveWithdrawIdPDE()
    //{
    //    gblObj = new clsGlobalMethods();
    //    genDAO = new KPEPFGeneralDAO();
    //    wth = new WithdrawalPDE();
    //    pdeAG = new WithdrawalPDEAG();
    //    pdeAGDAO = new WithdrawalPDEAGDAO();

    //    for (int i = 0; i < gdvWithAG.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvWithAG.Rows[i];

    //        Label  WithIDPDEAss = (Label)gdvrow.FindControl("WithIDPDE");
    //        TextBox txtAccNoAss = (TextBox)gdvrow.FindControl("txtAccNo");
    //        TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
    //        DropDownList ddldesigAss = (DropDownList)gdvrow.FindControl("ddldesig");
    //        TextBox txtOrderNoAss = (TextBox)gdvrow.FindControl("txtOrderNo");
    //        TextBox txtOrderDateAss = (TextBox)gdvrow.FindControl("txtOrderDate");
    //        DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
    //        TextBox txtConsolidatedAss = (TextBox)gdvrow.FindControl("txtConsolidated");
    //        TextBox txtInstNoAss = (TextBox)gdvrow.FindControl("txtInstNo");
    //        TextBox instAmtAss = (TextBox)gdvrow.FindControl("instAmt");
    //        DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
    //        DropDownList ddlpurposeAss = (DropDownList)gdvrow.FindControl("ddlpurpose");
    //        TextBox txtOrderNoDateAss = (TextBox)gdvrow.FindControl("txtOrderNoDate");
    //        TextBox txtAmtPreTaAss = (TextBox)gdvrow.FindControl("txtAmtPreTa");
    //        TextBox txtBalTAAss = (TextBox)gdvrow.FindControl("txtBalTA");
    //        CheckBox chkUnPAss = (CheckBox)gdvrow.FindControl("chkUnP");
    //        DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");
    //        DateTime billDate = Convert.ToDateTime(txtDate.Text.ToString());
    //        Label lblNewAccAss = (Label)gdvrow.FindControl("lblNewAcc");
    //        Label lblOldAccAss = (Label)gdvrow.FindControl("lblOldAcc");
    //        Label lblOldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
    //        Label lblEditModeAss = (Label)gdvrow.FindControl("lblEditMode");
    //        if (CheckMandatory(txtAmtAss, txtOrderDateAss) == true)
    //        {

    //            if (WithIDPDEAss.Text == "")
    //            {
    //                pdeAG.IntId = 0;
    //            }
    //            else
    //            {
    //                pdeAG.IntId = Convert.ToInt32(WithIDPDEAss.Text);

    //            }
    //            if (txtAccNoAss.Text == "")
    //            {
    //                pdeAG.IntAccNo = 0;
    //            }
    //            else
    //            {
    //                pdeAG.IntAccNo = Convert.ToInt32(lblNewAccAss.Text);
    //            }
    //            if (ddldesigAss.SelectedIndex > 0)
    //            {
    //                pdeAG.IntDesignation = Convert.ToInt32(ddldesigAss.SelectedValue);
    //            }
    //            else
    //            {
    //                pdeAG.IntDesignation = 0;
    //            }
    //            if (txtAmtAss.Text == "")
    //            {
    //                pdeAG.FltAdvAmt = 0;
    //            }
    //            else
    //            {
    //                pdeAG.FltAdvAmt = Convert.ToDecimal(txtAmtAss.Text);
    //            }
    //            if (txtOrderNoAss.Text == "")
    //            {
    //                pdeAG.ChvSantionNo = "";
    //            }
    //            else
    //            {
    //                pdeAG.ChvSantionNo = txtOrderNoAss.Text.ToString();
    //            }
    //            if (txtOrderDateAss.Text == "")
    //            {
    //                pdeAG.DtSantion = "";
    //            }
    //            else
    //            {
    //                pdeAG.DtSantion = txtOrderDateAss.Text.ToString();
    //            }
    //            if (ddlTypeAss.SelectedIndex > 0)
    //            {
    //                pdeAG.IntLoan = Convert.ToInt32(ddlTypeAss.SelectedValue);
    //            }
    //            else
    //            {
    //                pdeAG.IntLoan = 0;
    //            }
    //            if (txtDate.Text == "")
    //            {
    //                pdeAG.DtWithdraw = "";
    //            }
    //            else
    //            {
    //                pdeAG.DtWithdraw = txtDate.Text.ToString();
    //            }
    //            if (txtConsolidatedAss.Text == "")
    //            {
    //                pdeAG.FltConsolidate = 0;
    //            }
    //            else
    //            {
    //                pdeAG.FltConsolidate = Convert.ToDecimal(txtConsolidatedAss.Text);
    //            }
    //            if (txtInstNoAss.Text == "")
    //            {
    //                pdeAG.IntNoOfInstalments = 0;
    //            }
    //            else
    //            {
    //                pdeAG.IntNoOfInstalments = Convert.ToInt32(txtInstNoAss.Text);
    //            }
    //            if (instAmtAss.Text == "")
    //            {
    //                pdeAG.FltInstalmentAmt = 0;
    //            }
    //            else
    //            {
    //                pdeAG.FltInstalmentAmt = Convert.ToInt32(instAmtAss.Text);
    //            }
    //            ArrayList ardt1 = new ArrayList();
    //            ardt1.Add(txtDate.Text.ToString());
    //            pdeAG.IntYrId = genDAO.gFunFindPDEYearIdFromDate(ardt1);
    //            if (ddlStatusAss.SelectedIndex > 0)
    //            {
    //                pdeAG.IntModeOfChgId = Convert.ToInt32(ddlStatusAss.SelectedValue);
    //            }
    //            else
    //            {
    //                pdeAG.IntModeOfChgId = 2;
    //            }
    //            pdeAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
    //            pdeAG.DtmDateOfUpdation = DateTime.Now.ToString();
    //            pdeAG.IntVoucherAGID = Convert.ToInt32(Session["intVoucherIDEdit"]);
    //            if (ddlpurposeAss.SelectedIndex > 0)
    //            {
    //                pdeAG.IntLoanPurpose = Convert.ToInt32(ddlpurposeAss.SelectedValue);
    //            }
    //            else
    //            {
    //                pdeAG.IntLoanPurpose = 0;
    //            }
    //            pdeAG.IntDrawnBy = 1;
    //            if (txtOrderNoDateAss.Text == "")
    //            {
    //                pdeAG.ChvOdrNoDtOfPrevTA = "";
    //            }
    //            else
    //            {
    //                pdeAG.ChvOdrNoDtOfPrevTA = txtOrderNoDateAss.Text.ToString();
    //            }
    //            if (txtAmtPreTaAss.Text == "")
    //            {
    //                pdeAG.FltAmtPrevTA = 0;
    //            }
    //            else
    //            {
    //                pdeAG.FltAmtPrevTA = Convert.ToInt32(txtAmtPreTaAss.Text);
    //            }
    //            if (txtBalTAAss.Text == "")
    //            {
    //                pdeAG.FltBalancePrevTA = 0;
    //            }
    //            else
    //            {
    //                pdeAG.FltBalancePrevTA = Convert.ToInt32(txtBalTAAss.Text);
    //            }
    //            if (chkUnPAss.Checked == true)
    //            {
    //                pdeAG.FlgUnPosted = 2;
    //            }
    //            else
    //            {
    //                pdeAG.FlgUnPosted = 1;
    //            }
    //            if (ddlUnPAss.SelectedIndex > 0)
    //            {
    //                pdeAG.IntUnPostedRsn = Convert.ToInt32(ddlUnPAss.SelectedValue);
    //            }
    //            else
    //            {
    //                pdeAG.IntUnPostedRsn = 0;
    //            }
    //            mnthId = billDate.Month;
    //            pdeAG.Intmid = Convert.ToInt32(mnthId.ToString());
    //            pdeAG.IntDisId = FindDistId(Convert.ToInt32(Session["intVoucherIDEdit"]));
    //            DataSet ds = new DataSet();
    //            ds = pdeAGDAO.UpdateWithPde1(pdeAG);
    //            saveCorrectionEntry(i, Convert.ToInt32(lblWithIdPfoAss.Text), 0);
    //        }
           
    //    }
    //    FillWithdrawal();
    //    gblObj.MsgBoxOk("Saved successfully", this);
    //}
    private int FindDistId(int intVchrId)
    {
        pdeAGDAO = new WithdrawalPDEAGDAO();
        int distId = 0;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(intVchrId);
        ds = pdeAGDAO.GetDistId(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
           distId  = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
        return distId;

    }

    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();
        DataSet dsName = new DataSet();

        intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gdr = gdvWithAG.Rows[intCurRw];
        Label lblAccNoAss = (Label)gdr.FindControl("lblNewAcc");
        TextBox txtAccNoAss = (TextBox)gdr.FindControl("txtAccNo");
        Label lblNameAss = (Label)gdr.FindControl("lblName");
        Label lblNewAccAss = (Label)gdr.FindControl("lblNewAcc");
        Label lblOldAccAss = (Label)gdr.FindControl("lblOldAcc");
        Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");
        if (gblObj.CheckNumericOnly(txtAccNoAss.Text.ToString(), this) == true)
        {
            emp.NumEmpID = Convert.ToDouble(txtAccNoAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                lblNewAccAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            else
            {
                txtAccNoAss.Text = "";
                lblNameAss.Text = "";
                gblObj.MsgBoxOk("Doesn't exist!", this);
            }
            if (Convert.ToInt32(lblOldAccAss.Text) != Convert.ToInt32(lblNewAccAss.Text))
            {
                lblEditModeAss.Text = "1";
            }
            else
            {
                lblEditModeAss.Text = "0";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter Numeric Value", this);
            txtAccNoAss.Text = "";
            lblNameAss.Text = "";
        }
    }
    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        intCurRwA = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvWithAG.Rows[intCurRwA];
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
        TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
        Label lblOldAmtAss = (Label)gvr.FindControl("lblOldAmt");
        if (Convert.ToDouble(lblOldAmtAss.Text) != Convert.ToDouble(txtAmtAss.Text))
        {
            lblEditModeAss.Text = "1";
        }
        else
        {
            lblEditModeAss.Text = "0";
        }

        gblObj.SetFooterTotalsTempField(gdvWithAG, 6, "txtAmt", 1);
    }
    protected void txtOrderDate_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        int intCurRwDt2 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        GridViewRow gdr = gdvWithAG.Rows[intCurRwDt2];
        TextBox txtSDateAss = (TextBox)gdr.FindControl("txtOrderDate");
        //Label lblEditMode = (Label)gdr.FindControl("lblEditMode");
        if (gblObj.isValidDate(txtSDateAss, this) == false)
        {
            gblObj.MsgBoxOk("Invalid Date!", this);
            txtSDateAss.Text = "";
        }
        else if (gblObj.CheckDate2(txtSDateAss.Text.ToString(), DateTime.Now.ToString()) == false)
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtSDateAss.Text = "";
        }

        //lblEditMode.Text = "1";
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gendao = new GeneralDAO();
        pdeAG = new WithdrawalPDEAG();
        pdeAGDAO = new WithdrawalPDEAGDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddldesig");
            arDdl.Add("ddlType");
            arDdl.Add("ddlpurpose");
            arDdl.Add("ddlUnP");
            //////Store Ddls in an array//////////  

            //////Store Ds to fill Ddls in an array//////////
            DataSet dsdesig = new DataSet();
            dsdesig = pdeAGDAO.Getdesignation();

            DataSet dsl = new DataSet();
            dsl = pdeAGDAO.GetLoanType();

            DataSet dspurpse = new DataSet();
            dspurpse = pdeAGDAO.GetLoanPurpose();

            DataSet dsM = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(2);
            dsM = gendao.GetMisClassRsn(arrIn);

            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dsdesig);
            arDdlDs.Add(dsl);
            arDdlDs.Add(dspurpse);
            arDdlDs.Add(dsM);
            //////Store Ds to fill Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsW = new DataSet();
            pdeAG.IntVoucherAGID = Convert.ToInt32(Session["intVoucherIDEdit"]);
            dsW = pdeAGDAO.GetWithdrawaEmpBind(pdeAG);


            ////Ds to fill Grid//////////

            gblObj.SetGridRowsWithData(dsW, Convert.ToInt16(txtCnt.Text), gdvWithAG, arDdl, arCols, arDdlDs);
            //FillFooterTotals();
        }
        else
        {
            gblObj.SetRowsCnt(gdvWithAG, 1);
        }
        btnSave.Enabled = true;
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        wthd = new WithdrawalPDEDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblWithIdAss = (Label)gdvWithAG.Rows[rowIndex].FindControl("lblWithIDPDE");
        TextBox txtAmt = (TextBox)gdvWithAG.Rows[rowIndex].FindControl("txtAmt");
        Label lblAccNo = (Label)gdvWithAG.Rows[rowIndex].FindControl("lblOldAcc");
        if (lblWithIdAss.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblWithIdAss.Text));
            try
            {
                wthd.UpdateVoucherMode(arrin);
                saveCorrectionEntry(rowIndex, Convert.ToInt64(lblWithIdAss.Text), 1);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
        }
        FillWithdrawal();
        gblObj.MsgBoxOk("Row Deleted   !", this);
    }
    private void saveCorrectionEntry(int rw, float schedId, int intDel)
    {
        gendao = new GeneralDAO();
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();
        ArrayList ardt = new ArrayList();

        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;

        ardt.Add(txtDate.Text.ToString());
        yr = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
        mth = Convert.ToDateTime(txtDate.Text).Month;
        intDy = Convert.ToDateTime(txtDate.Text).Day; 

        GridViewRow gvrow = gdvWithAG.Rows[rw];
        Label lblOTot = (Label)gvrow.FindControl("lblOldAmt");
        TextBox lblNewTot = (TextBox)gvrow.FindControl("txtAmt");
        Label lblOAcc = (Label)gvrow.FindControl("lblOldAcc");
        Label lblNewAcc = (Label)gvrow.FindControl("lblNewAcc");
        Label lblSched = (Label)gvrow.FindControl("WithIDPDE");
        //TextBox txtVoucherId = (TextBox)gvrow.FindControl("txtVoucherId");
        
        amtO = Convert.ToDouble(lblOTot.Text);
        amtN = Convert.ToDouble(lblNewTot.Text);
        accO = Convert.ToInt32(lblOAcc.Text);
        accN = Convert.ToInt32(lblNewAcc.Text);

        findCorrType(amtO, amtN, accO, accN, intDel);
        if (corrType == 2)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    corr.IntAccNo = Convert.ToInt32(lblOAcc.Text);
                    amtCalc = amtN;
                    corr.FltAmountBefore = amtO;
                    corr.FltAmountAfter = 0;
                }
                else
                {
                    corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
                    amtCalc = -amtN;
                    corr.FltAmountBefore = 0;
                    corr.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                corr.IntYearID = yr;
                corr.IntMonthID = mth;
                corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                corr.FltCalcAmount = dblAmtAdjusted;
                corr.FlgCorrected = 1;      //Just added not incorporated in CCard
                corr.IntChalanId = Convert.ToInt64(Session["intVoucherIDEdit"]);
               
                corr.IntSchedId = schedId;
                corr.FlgType = 2;           //Remittance
                corr.FltRoundingAmt = 0;
                corr.IntCorrectionType = corrType;
                corr.IntChalanType = 4;
                corr.IntTblTp = 1;
                corrDao.CreateCorrEntryCalcTblTp(corr);
            }
        }
        else
        {
            if (corrType == 4)
            {
                amtCalc = -amtN;
                corr.FltAmountBefore = 0;
                corr.FltAmountAfter = amtN;
            }
            else if (corrType == 5)
            {
                amtCalc = amtN;
                corr.FltAmountBefore = amtN;
                corr.FltAmountAfter = 0;
            }
            else
            {
                amtCalc = amtO - amtN;
                corr.FltAmountBefore = amtO;
                corr.FltAmountAfter = amtN;
            }
            double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
            ///// Save to CorrEntry/////////
            corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
            corr.IntYearID = yr;
            corr.IntMonthID = mth;
            corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            corr.FltCalcAmount = dblAmtAdjusted;
            corr.FlgCorrected = 1;      //Just added not incorporated in CCard
            corr.IntChalanId = Convert.ToInt64(Session["intVoucherIDEdit"]);
            corr.IntSchedId = schedId;
            corr.FlgType = 2;           //Remittance
            corr.FltRoundingAmt = 0;
            corr.IntCorrectionType = corrType;
            corr.IntChalanType = 4;
            corr.IntTblTp = 1;
            corrDao.CreateCorrEntryCalcTblTp(corr);
        }
    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 5;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 4;
            }
            else if (acco != accn)  // acc no change  (From local master)
            {
                corrType = 2;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 3;
            }
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        //arCols.Add("txtAccNo");
        //arCols.Add("lblName");
        //arCols.Add("ddldesig");
        //arCols.Add("ddlType");
        //arCols.Add("txtOrderNo");
        //arCols.Add("txtOrderDate");
        //arCols.Add("txtAmt");
        //arCols.Add("ddlpurpose");
        //arCols.Add("txtOrderNoDate");
        //arCols.Add("txtAmtPreTa");
        //arCols.Add("txtBalTA");
        //arCols.Add("txtConsolidated");
        //arCols.Add("txtInstNo");
        //arCols.Add("instAmt");
        //arCols.Add("chkUnP");
        //arCols.Add("ddlUnP");

        arCols.Add("txtAccNo");
        arCols.Add("lblName");
        arCols.Add("ddldesig");
        arCols.Add("ddlType");
        arCols.Add("txtOrderNo");
        arCols.Add("txtOrderDate");
        arCols.Add("txtAmt");
        arCols.Add("ddlpurpose");
        arCols.Add("txtOrderNoDate");
        arCols.Add("txtAmtPreTa");
        arCols.Add("txtBalTA");
        arCols.Add("txtConsolidated");
        arCols.Add("txtInstNo");
        arCols.Add("txtinstAmt");
        arCols.Add("chkUnP");
        arCols.Add("ddlUnP");
        //arCols.Add("txtRemarks");
        arCols.Add("ddlStatus");
        arCols.Add("lblNewAcc");
        arCols.Add("txtUnpostedReasonId");
        arCols.Add("txtTypeId");
        arCols.Add("txtVoucherId");
        arCols.Add("lblWithIDPDE");
        arCols.Add("txtdesigId");
        arCols.Add("lblOldAmt");
        arCols.Add("lblOldAcc");
        arCols.Add("lblEditMode");
    }
    protected void chkUnP_CheckedChanged(object sender, EventArgs e)
    {
        intCurRw = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvWithAG.Rows[intCurRw];
        DropDownList ddlUnP = (DropDownList)gvr.FindControl("ddlUnP");
        CheckBox chkUnP = (CheckBox)gvr.FindControl("chkUnP");
        if (chkUnP.Checked == true)
        {
            ddlUnP.Enabled = true;
        }
        else
        {
            ddlUnP.Enabled = false;
        }
    }
}
