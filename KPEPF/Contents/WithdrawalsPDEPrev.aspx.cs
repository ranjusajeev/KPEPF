
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

public partial class Contents_WithdrawalsPDEPrev : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    WithdrawalC wth;
    WithdrawalCDao wthd;
    WithdrawalB wthb;
    WithdrawalBDao wthbd;
    CorrectionEntry cor = new CorrectionEntry();
    CorrectionEntryDao cord = new CorrectionEntryDao();
    RemPDE rem;
    RemPDEDao remD;

    public int consamt = 0;
    public int Lbtotamt = 0;
    public int flgamtchange = 0;
    static int intMth = 0;
    static int intDy = 0;
    static int intYrId = 0;

    AORecorrection aor;
    AORecorrectionDAO aord;
    WithdrawalPDEDAO wthpd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["intWithdrawConId"]) > 0)
            {
                Session["intWithdrawConId"] = Convert.ToInt32(Request.QueryString["intWithdrawConId"]);
                consamt = Convert.ToInt32(Request.QueryString["fltNetAmt"]);
                SetDdls();
                //FillCons();
                FillChalanS(1);
                SetCtrls();
            }
            if (Request.QueryString["intBillWiseId"] != null)
            {
                SetDdls();
                if (Convert.ToInt32(Request.QueryString["intWithdrawConId"]) > 0)
                {
                    FillChalanS(2);
                }
                else
                {
                    FillChalanS(2);
                }
                FillChalanTxts();
            }
            else if (Convert.ToInt32(Session["flgPageBackW"]) == 3)
            {
                SetDdls();
                //FillCons();
                FillChalanS(2);
                SetCtrls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetDdls()
    {
        InitialSettings();
        ddlYear.SelectedValue = Session["IntYearWith1"].ToString();
        ddlMnth.SelectedValue = Session["IntMonthWith1"].ToString();
        ddldist.SelectedValue = Session["IntDistWith1"].ToString();
        ddlDT.SelectedValue = Session["IntDTWith1"].ToString();
    }
    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        Session["flgPageBackW"] = 3;
        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddldist, ds, 1);
        DataSet dsyr = new DataSet();
        dsyr = gen.GetYear();
        gblObj.FillCombo(ddlYear, dsyr, 1);
        DataSet dsmnth = new DataSet();
        dsmnth = gen.GetMonth();
        gblObj.FillCombo(ddlMnth, dsmnth, 1);

        DataSet dsTreas = new DataSet();
        ArrayList arr = new ArrayList();
        if (Convert.ToInt16(Session["IntDistWith1"]) == 0)
        {
            Session["IntDistWith1"] = 1;
        }
        arr.Add(Session["IntDistWith1"]);
        dsTreas = gen.GetDisTreasuryWith(arr);
        gblObj.FillCombo(ddlDT, dsTreas, 1);

        //SetWith1Default();
        SetWithSTDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 1;
    }
    //private void SetWith1Default()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("SlNo");
    //    ar.Add("AccDate");
    //    ar.Add("intWithdrawConId");
    //    ar.Add("fltNetAmt");
    //    gblObj.SetGridDefault(gdvChalanS, ar);
    //    gdvChalanS.Enabled = false;
    //}
    private void SetWithSTDefault()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intBillNo");
        ar.Add("intBillWiseId");
        ar.Add("fltNetAmt");
        ar.Add("dtmBillDate");
        gblObj.SetGridDefault(gdvChalanLB, ar);
        gdvChalanLB.Enabled = false;
        lblStat.Text = "...";
        //lblSTDet3.Text = "...";
    }
    private void FillChalanTxts()
    {
        //gblObj = new clsGlobalMethods();
        //chalPDao = new ChalanPDEAGDAO();
        wthbd = new WithdrawalBDao();
        mdlConfirm.Show();
        Session["intBillId"] = Convert.ToDouble(Request.QueryString["intBillWiseId"]);

        FillGridDataset();
        FillCmb4NewChalan();
        FillCmbLbDt();
        FillComboRsn();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["intBillId"] != null)
        {
            arr.Add(Session["intBillId"]);
            ds = wthbd.GetBillDet(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtBillNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtBillDt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtbillAmt.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                // ddlLBNew.SelectedValue = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                // ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                //ddlchlType.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtBillId.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString(); // AP_Tresury chalanId            
                lblYr.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                lblMonth.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                lblDy.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                txtOldAmt.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                //  txtWthConsId.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                ddlsubd.SelectedValue = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[3].ToString()) == 2)
                {
                    chkUpN.Checked = true;
                    ddlRsnN.SelectedValue = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                }
                else
                {
                    chkUpN.Checked = false;
                    ddlRsnN.SelectedValue = "0";
                }

            }
            else
            {

            }
        }
        else
        {
            Session["intBillId"] = 0;
        }
    }
    private void FillComboRsn()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(1);
        ds = gen.GetMisClassRsn(ar);
        gblObj.FillCombo(ddlRsnN, ds, 1);
    }
    private void FillCmbLbDt()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        DataSet dslb = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntDistRem1"]));
        dslb = gen.GetLBDistwise(arr);
        gblObj.FillCombo(ddlLBNew, dslb, 1);

        DataSet ds1 = new DataSet();
        ds1 = gen.GetTreasury(arr);
        gblObj.FillCombo(ddlsubTreas, ds1, 1);

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["IntYearWith1"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["IntYearWith1"] = 0;
        }
        ddlMnth.SelectedValue = "0";
        ddldist.SelectedValue = "0";
        ddlDT.SelectedValue = "0";
        //SetWith1Default();
        SetWithSTDefault();
    }
    protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMnth.SelectedIndex > 0)
        {
            Session["IntMonthWith1"] = Convert.ToInt16(ddlMnth.SelectedValue);
        }
        else
        {
            Session["IntMonthWith1"] = 0;
        }
        ddldist.SelectedValue = "0";
        ddlDT.SelectedValue = "0";
        //SetWith1Default();
        SetWithSTDefault();
    }
    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        if (ddldist.SelectedIndex > 0)
        {
            Session["IntDistWith1"] = Convert.ToInt16(ddldist.SelectedValue);
            DataSet dsWith = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Session["IntDistWith1"]);
            dsWith = gen.GetDisTreasuryWith(arr);
            gblObj.FillCombo(ddlDT, dsWith, 1);
        }
        else
        {
            Session["IntDistWith1"] = 0;
        }

        ddlDT.SelectedValue = "0";
        //SetWith1Default();
        SetWithSTDefault();
    }
    private void FillGridDataset()
    {
        gblObj = new clsGlobalMethods();
        rem = new RemPDE();
        remD = new RemPDEDao();

        DataSet dsCons = new DataSet();
        rem.IntYearID = Convert.ToInt16(Session["IntYearWith1"]);
        rem.IntMonthId = Convert.ToInt16(Session["IntMonthWith1"]);
        rem.IntDTId = Convert.ToInt16(Session["IntDTWith1"]);
        rem.FlgSource = 2;
        dsCons = remD.GetConsTreasuryPDE(rem);
        if (dsCons.Tables[0].Rows.Count > 0)
        {
            //  lblStatus.Text = dsCons.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["flgApp"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[7]);
            //lnkChal.Enabled = true;
        }
        else
        {
            //  SetChalanLBDefault();
            Session["flgApp"] = 0;
            //lnkChal.Enabled = false;
        }
    }
    private void FillChalanS(int tp)
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        wthb = new WithdrawalB();
        wthbd = new WithdrawalBDao();
        SetWithSTDefault();
        //gdvChalanS.Enabled = true;
        gdvChalanLB.Enabled = true;
        DataSet dsRem = new DataSet();
        if (tp == 1)
        {
            wthb.IntWithdrawConId = Convert.ToInt32(Session["intWithdrawConId"]);
            dsRem = wthbd.GetWithBills(wthb);
        }
        else
        {
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToInt16(Session["IntYearWith1"]));
            ar.Add(Convert.ToInt16(Session["IntMonthWith1"]));
            ar.Add(Convert.ToInt16(Session["IntDTWith1"]));
            ar.Add(1);
            dsRem = wthbd.GetWithBill(ar);
        }

        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRem;
            gdvChalanLB.DataBind();

            DataSet dsM = new DataSet();
            ArrayList arrIn1 = new ArrayList();
            arrIn1.Add(1);
            dsM = gen.GetMisClassRsn(arrIn1);

            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];
                TextBox txtBDateAss = (TextBox)gvr.FindControl("txtBDate");
                TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");

                txtBDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[0].ToString();
                txtAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[2].ToString();

                DropDownList ddlReasonAss = (DropDownList)gvr.FindControl("ddlReason");
                gblObj.FillCombo(ddlReasonAss, dsM, 1);
                ddlReasonAss.SelectedValue = dsRem.Tables[0].Rows[i].ItemArray[6].ToString();

                CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
                if (Convert.ToInt16(dsRem.Tables[0].Rows[i].ItemArray[5]) == 2)
                {
                    chkAppAss.Checked = true;
                    //chkAppAss.Enabled = true;
                }
                else
                {
                    chkAppAss.Checked = false;
                    //chkAppAss.Enabled = false;
                }

            }
            //lblSTDet.Text = dsRem.Tables[0].Rows[0].ItemArray[9].ToString();
            //lblSTDet2.Text = dsRem.Tables[0].Rows[0].ItemArray[10].ToString();
            //lblSTDet3.Text = dsRem.Tables[0].Rows[0].ItemArray[2].ToString();
            gblObj.SetFooterTotalsTempField(gdvChalanLB, 3, "txtAmt", 1);
            //lblSTDet3.Text = gdvChalanLB.FooterRow.Cells[3].Text.ToString();
            Lbtotamt = Convert.ToInt32(gdvChalanLB.FooterRow.Cells[3].Text);
            if (consamt != 0)
            {
                if (consamt != Lbtotamt)
                {
                    gdvChalanLB.FooterRow.Cells[3].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
    protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDT.SelectedIndex > 0)
        {
            Session["IntDTWith1"] = Convert.ToInt16(ddlDT.SelectedValue);
            SetWithSTDefault();
            FillChalanS(2);
            btnSave.Enabled = true;
        }
        else
        {
            Session["IntDTWith1"] = 0;
            SetWithSTDefault();
            btnSave.Enabled = false;
        }
        SetCtrls();
    }
    private void SetCtrlsDisable()
    {
        btnSave.Enabled = false;
        lnkChal.Enabled = false;

        txtBillNo.Enabled = false;
        txtBillDt.Enabled = false;
        txtbillAmt.Enabled = false;
        chkUpN.Enabled = false;
        ddlRsnN.Enabled = false;
        ddlsubd.Enabled = false;

        //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvChalanLB.Rows[i];
        //    gvr.Cells[0].Enabled = false;
        //}
    }

    private void SetCtrlsEnable()
    {
        btnSave.Enabled = true;
        lnkChal.Enabled = true;

        txtBillNo.Enabled = true;
        txtBillDt.Enabled = true;
        txtbillAmt.Enabled = true;
        chkUpN.Enabled = true;
        ddlRsnN.Enabled = true;
        ddlsubd.Enabled = true;

        //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvChalanLB.Rows[i];
        //    gvr.Cells[0].Enabled = true;
        //}
    }
    //private void SetCtrls()
    //{
    //    if (Convert.ToInt16(Session["flgApp"]) == 2)
    //    {
    //        SetCtrlsEnable();
    //        lblStat.Text = "Rejected";
    //    }
    //    else
    //    {
    //        SetCtrlsDisable();
    //        lblStat.Text = "Approved";
    //    }
    //}
    private void SetCtrls()
    {
        DataSet dsr = new DataSet();
        aor = new AORecorrection();
        aord = new AORecorrectionDAO();
        aor.IntYearID = Convert.ToInt16(Session["IntYearWith1"]);
        aor.IntMonthID = Convert.ToInt16(Session["IntMonthWith1"]);
        aor.IntDistID = Convert.ToInt16(Session["IntDistWith1"]);
        aor.IntType = 2;

        dsr = aord.SelectApprovalPDEWithFlg(aor);
        if (dsr.Tables[0].Rows.Count > 0)
        {
            Session["flgApp"] = Convert.ToInt16(dsr.Tables[0].Rows[0].ItemArray[0]);
            lblStat.Text = dsr.Tables[0].Rows[0].ItemArray[1].ToString();
        }
        if (Convert.ToInt16(Session["flgApp"]) == 2)
        {
            SetCtrlsEnable();
        }
        else
        {
            SetCtrlsDisable();
        }
    }
    //private void FillCons()
    //{
    //    //SetWith1Default();
    //   // gdvChalanS.Enabled = true;
    //    DataSet dsCons = new DataSet();
    //    wth.IntYearId = Convert.ToInt16(Session["IntYearWith1"]);
    //    wth.IntMonthId = Convert.ToInt16(Session["IntMonthWith1"]);
    //    wth.IntDTId = Convert.ToInt16(Session["IntDTWith1"]);
    //    wth.IntSourceId = 1;
    //    dsCons = wthd.GetWithCons(wth);
    //    if (dsCons.Tables[0].Rows.Count > 0)
    //    {
    //       // txtChalDt.Text = dsCons.Tables[0].Rows[i].ItemArray[6].ToString();
    //       // txtChalAmt.Text = dsCons.Tables[0].Rows[i].ItemArray[7].ToString();
    //        txtWthConsId.Text = dsCons.Tables[0].Rows[0].ItemArray[0].ToString();
    //    }
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //SaveWithdrawCon();
        //gblObj.MsgBoxOk("Updated!", this);
        Response.Redirect("WithdrawalsPDE.aspx");
    }
    private void SaveWithdrawCon()
    {
        GenDao = new KPEPFGeneralDAO();
        wth = new WithdrawalC();
        wthd = new WithdrawalCDao();
        ArrayList arr = new ArrayList();
        DataSet dsyr = new DataSet();
        arr.Add(Convert.ToInt16(Session["IntYearWith1"]));
        dsyr = GenDao.GetPDEYrId(arr);

        wth.IntYearId = Convert.ToInt32(dsyr.Tables[0].Rows[0].ItemArray[0].ToString());
        wth.IntMonthId = Convert.ToInt16(Session["IntMonthWith1"]);
        wth.IntDTId = Convert.ToInt16(Session["IntDistWith1"]);
        wth.IntSourceId = 1;
        wth.DtAccDate = Convert.ToDateTime(txtBillDt.Text);
        wth.DtTrnDate = Convert.ToDateTime(txtBillDt.Text);
        wth.FltTAdvAmt = Convert.ToInt32(txtbillAmt.Text);
        wth.IntWithdrawConId = Convert.ToInt32(Session["intWithdrwConId"]);
        //Convert.ToInt32(txtWthConsId.Text);
        wth.IntModeChg = 3;

        DataSet ds = new DataSet();
        ds = wthd.SaveWithdrawCons(wth);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Session["intWithConsId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        //}
    }
    private void SaveWithdrawBill()
    {
        wthb = new WithdrawalB();
        wthbd = new WithdrawalBDao();
        if (Convert.ToString(txtBillId.Text.ToString()) == "" || Convert.ToString(txtBillId.Text.ToString()) == "0")
        {
            txtBillId.Text = "0";
        }

        wthb.IntBillWiseId = Convert.ToInt32(txtBillId.Text);
        if (Convert.ToString(txtWthConsId.Text.ToString()) == "" || Convert.ToString(txtWthConsId.Text.ToString()) == "0")
        {
            txtWthConsId.Text = "0";
        }
        wthb.IntWithdrawConId = Convert.ToInt32(Session["intWithdrwConId"]);
        wthb.DtmBillDate = Convert.ToDateTime(txtBillDt.Text);
        wthb.IntBillNo = Convert.ToInt32(txtBillNo.Text);
        wthb.FltNetAmt = Convert.ToInt64(txtbillAmt.Text);
        wthb.IntSlNo = 0;
        wthb.IntModeChgId = 2;
        if (chkUpN.Checked == true)
        {
            wthb.FlgUnPosted = 2;
            wthb.IntUnPostedReason = Convert.ToInt16(ddlRsnN.SelectedValue);
        }
        else if (chkUpN.Checked == false)
        {
            wthb.FlgUnPosted = 1;
            wthb.IntUnPostedReason = 0;
        }

        DataSet ds = new DataSet();
        ds = wthbd.InsBillPDE(wthb);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["intBillId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        }

    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        //{
        //    GridViewRow gvRw = gdvChalanLB.Rows[i];
        //    CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
        //    DropDownList ddlReasonAss = (DropDownList)gvRw.FindControl("ddlReason");
        //    //FillGridCombo();
        //    if (chkAppAss.Checked == true)
        //    {
        //        ddlReasonAss.Enabled = true;
        //        FillGridCombo();
        //        //ddlReasonAss.SelectedValue = 4;
        //    }
        //    else
        //    {
        //        ddlReasonAss.Enabled = false;
        //    }
        //}
    }

    protected void txtInt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtAccDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtTrnDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void gdvChalanS_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        flgamtchange = 1;
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        //SetChalanLBDefault();
        FillCmb4NewChalan();
        FillCmbLbDt();
        FillComboRsn();
        mdlConfirm.Show();
    }
    private void FillCmb4NewChalan()
    {
        gblObj = new clsGlobalMethods();
        wthd = new WithdrawalCDao();
        DataSet dsn = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearWith1"]));
        ar.Add(Convert.ToInt16(Session["IntMonthWith1"]));
        ar.Add(Convert.ToInt16(Session["IntDTWith1"]));
        dsn = wthd.SelWithConDet(ar);
        gblObj.FillCombo(ddlsubd, dsn, 1);
    }
    public void clearnewchalan()
    {
        txtWthConsId.Text = "0";
        txtBillId.Text = "0";
        txtBillNo.Text = "0";
        txtbillAmt.Text = "";
        txtBillDt.Text = "0";
        // ddlLBNew.SelectedValue = "0";
        ddlsubTreas.SelectedValue = "0";
        Session["numchalanId"] = "0";

        //chkShow.Checked = false;
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (CheckMandatoryAccDate(ddlsubd) == true)
        {
            if (CheckMandatory(txtbillAmt, txtBillNo, txtBillDt) == true)
            {
                // SaveWithdrawCon();
                SaveWithdrawBill();
                //if (Convert.ToInt16(lblEditMode.Text) >= 1)
                //{
                //    //if (txtOldAmt.Text != txtbillAmt.Text)
                //    //{
                //    //    int cntEmp = 0;
                //    //    ArrayList ar = new ArrayList();
                //    //    DataSet dsChal = new DataSet();
                //    //    ar.Add(Convert.ToInt32(txtBillId.Text));
                //    //    dsChal = wthbd.GetWithEmpDet(ar);
                //    //    cntEmp = dsChal.Tables[0].Rows.Count;
                //    //    for (int i = 0; i <= cntEmp - 1; i++)
                //    //    {
                //    //        int accNo = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[0]);
                //    //       int  intWithdrawalId = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[2]);
                //    //        SaveCorrectionEntryAmtChnge(accNo, Convert.ToInt32(txtBillId.Text), Convert.ToInt16(lblYr.Text), Convert.ToInt16(lblMonth.Text), intWithdrawalId, 3, Convert.ToInt32(txtOldAmt.Text), Convert.ToInt32(txtbillAmt.Text));
                //    //    }
                //    //}

                //    SaveCorrectionEntryChal(Convert.ToInt32(txtBillId.Text), Convert.ToInt16(lblEditMode.Text), Convert.ToInt16(lblYr.Text), Convert.ToInt16(lblMonth.Text), Convert.ToInt16(lblDy.Text));
                //}
                gblObj.MsgBoxOk("Saved successfully!!!", this);
                FillChalanS(2);
                SetCtrls();
            }
        }
        else
        {
            gblObj.MsgBoxOk("Check  Consolidated grid!", this);
        }
    }
    private Boolean CheckMandatoryAccDate(DropDownList ddltre)
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (Convert.ToInt16(ddltre.SelectedValue) == 0)
        {
            gblObj.MsgBoxOk("Must Select Accounting Date", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    //private void SaveCorrectionEntryAmtChnge(int intAccNo, int chalId, int yr, int mth, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr)
    //{

    //    Session["intCCYearId"] = gen.GetCCYearId();
    //    double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, fltAmtAfr - fltAmtBfr);
    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, 1, fltAmtBfr - fltAmtAfr);
    //    ///// Save to CorrEntry/////////
    //    cor.IntAccNo = intAccNo;
    //    cor.IntYearID = yr;
    //    cor.IntMonthID = mth;
    //    cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    cor.FltAmountBefore = fltAmtBfr;
    //    cor.FltAmountAfter = fltAmtAfr;
    //    cor.FltCalcAmount = dblAmtAdjusted;
    //    cor.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    cor.IntChalanId = chalId;
    //    cor.IntSchedId = intSchedId;
    //    cor.FlgType = 2;           //Remittance
    //    cor.FltRoundingAmt = 0;
    //    cor.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    cor.IntChalanType = 1;
    //    cord.CreateCorrEntry(cor);
    //    ///// Save to CorrEntry/////////
    //}
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt)
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (Convert.ToDouble(txtAmt.Text) == 0 || Convert.ToInt16(txtNo.Text) == 0 || Convert.ToString(txtDt.Text) == "")
        {
            gblObj.MsgBoxOk("Enter all details!", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    //private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    //{
    //    //gendao = new GeneralDAO();
    //    //gblObj = new clsGlobalMethods();
    //    //chalDao = new ChalanPDEDao();
    //    //cor = new CorrectionEntry();
    //    //cord = new CorrectionEntryDao();

    //    int cntEmp = 0;
    //    ArrayList ar = new ArrayList();
    //    DataSet dsChal = new DataSet();
    //    ar.Add(chalId);
    //    dsChal = wthbd.GetWithEmpDet(ar);
    //    cntEmp = dsChal.Tables[0].Rows.Count;
    //    Session["intCCYearId"] = gen.GetCCYearId();
    //    for (int i = 0; i <= cntEmp - 1; i++)
    //    {
    //        int accNo = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[0]);
    //        double amt = Convert.ToInt64(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //        double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, dblCalcAmt);
    //        ///// Save to CorrEntry/////////
    //        cor.IntAccNo = accNo;
    //        cor.IntYearID = yr;
    //        cor.IntMonthID = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[3]);
    //        cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //        cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        //corr.FltAmountAfter = Math.Round(dblAmtAdjusted);
    //        if (intEditMode == 1)
    //        {
    //            cor.FltAmountAfter = Math.Round(cor.FltAmountBefore + dblCalcAmt);
    //            cor.FltCalcAmount = dblAmtAdjusted;
    //        }
    //        else
    //        {
    //            cor.FltAmountAfter = Math.Round(cor.FltAmountBefore - dblCalcAmt);
    //            cor.FltCalcAmount = -dblAmtAdjusted;
    //        }
    //        cor.FlgCorrected = 1;      //Just added not incorporated in CCard
    //        cor.IntChalanId = chalId;
    //        cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
    //        cor.FlgType = 2;           //Remittance
    //        cor.FltRoundingAmt = 0;
    //        cor.IntCorrectionType = 3; //Edit Chal Date
    //        //corr.StrFrmChalDt = System.DBNull.Value.ToString();
    //        //corr.StrToChalDt = System.DBNull.Value.ToString();
    //        if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //        {
    //            cor.IntChalanType = 1;
    //        }
    //        else
    //        {
    //            cor.IntChalanType = 2;
    //        }
    //        cord.CreateCorrEntry(cor);
    //        ///// Save to CorrEntry/////////
    //    }

    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}
    protected void btnDel_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        wthbd = new WithdrawalBDao();
        ArrayList ar = new ArrayList();
        ArrayList Arw = new ArrayList();
        DataSet dsyr = new DataSet();
        {
            ar.Add(Convert.ToInt32(txtBillId.Text));
            wthbd.DeleteBillDet(ar);
            Arw.Add(Convert.ToInt32(txtWthConsId.Text));
            Arw.Add(Convert.ToInt32(txtbillAmt.Text));
            wthbd.DeleteWthCons(Arw);
        }
        DelFromWithEmp(); //Corr Entry
        gblObj.MsgBoxOk("Deleted ", this);
        FillChalanS(2);
        SetCtrls();
    }
    private void DelFromWithEmp()
    {
        GenDao = new KPEPFGeneralDAO();
        wthpd = new WithdrawalPDEDAO();
        wthbd = new WithdrawalBDao();
        double amt;
        int chlId;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt32(txtBillId.Text));
        ds = wthbd.GetWithEmpDet(ar);
        cntEmp = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                //amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                fltAmtAfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = 0;
                amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[4].ToString());
                chlId = Convert.ToInt32(txtBillId.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(txtBillDt.Text.ToString());

                intMth = dt.Month;
                intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(txtBillDt.Text.ToString());
                intYrId = GenDao.gFunFindPDEYearIdFromDateOnline(ardt);

                ArrayList are = new ArrayList();
                are.Add(Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]));
                wthpd.UpdateWithdrawalMode(are);
                wthpd.UpdateVoucherMode(are);
            }
            CorrectionEntryForDel(Convert.ToInt32(txtBillId.Text)); //Corr Entry
        }
    }
    private void CorrectionEntryForDel(Int32 numChalId)
    {
        wthpd = new WithdrawalPDEDAO();
        GenDao = new KPEPFGeneralDAO();
        double amt;
        int chlId;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ds = wthpd.getBillEmps(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                amt = fltAmtBfr - fltAmtAfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());

                int intYrId = Convert.ToInt16(Session["IntYearWith1"]);
                int intMth = Convert.ToInt16(Session["IntMonthWith1"]);
                int intDy = 10;

                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 9, fltAmtBfr, fltAmtAfr, 1);
            }
        }
    }
    private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        Session["intCCYearId"] = gen.GetCCYearId() + 1;
        double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
        ///// Save to CorrEntry/////////
        cor.IntAccNo = intAccNo;
        cor.IntYearID = yr;
        cor.IntMonthID = mth;
        cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        cor.FltAmountBefore = fltAmtBfr;
        cor.FltAmountAfter = fltAmtAfr;
        cor.FltCalcAmount = dblAmtAdjusted;
        cor.FlgCorrected = 1;      //Just added not incorporated in CCard
        cor.IntChalanId = chalId;
        cor.IntSchedId = intSchedId;
        cor.FlgType = 2;           //Remittance
        cor.FltRoundingAmt = 0;
        cor.IntCorrectionType = intCorrTp; //Edit Chal Date
        //if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
        //{
        //    cor.IntChalanType = 1;
        //}
        //else
        //{
        cor.IntChalanType = 2;
        //}
        cor.IntTblTp = 1;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {

    }

    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblobj = new clsGlobalMethods();
        DateTime dtm = new DateTime();
        if (txtBillDt.Text != "")
        {
            if (gblobj.isValidDate(txtBillDt, this) == true)
            {
                if (gblobj.CheckChalanDate(txtBillDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMnth.SelectedValue)) == true)
                {
                }
                else
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                    txtBillDt.Text = "";
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtBillDt.Text = "";
            }
        }
        mdlConfirm.Show();

        //clsGlobalMethods gblObj = new clsGlobalMethods();
        //DateTime dtm = new DateTime();
        //if (gblObj.isValidDate(txtBillDt , this) == true)
        //{
        //    if (gblObj.CheckChalanDate(txtBillDt, ddlYear, ddlMnth) == true)
        //    {
        //        dtm = Convert.ToDateTime(txtBillDt.Text);
        //        int monthId = dtm.Month;
        //        if (monthId > Convert.ToInt32(ddlMnth.SelectedValue))
        //        {
        //            gblObj.MsgBoxOk("Invalid Date", this);
        //            txtBillDt.Text = "";
        //        }
        //        //else if (dtm.Day > 4 && Convert.ToInt16(lblDy.Text) <= 4)
        //        //{
        //        //    lblEditMode.Text = "2";
        //        //}
        //        //else
        //        //{
        //        //    lblEditMode.Text = "0";
        //        //}
        //    }
        //    else
        //    {
        //        gblObj.MsgBoxOk("Invalid Date", this);
        //        txtBillDt.Text = "";
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Invalid Date", this);
        //    txtBillDt.Text = "";
        //}
        //mdlConfirm.Show();
    }
    protected void chkUpN_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUpN.Checked == true)
        {
            ddlRsnN.Enabled = true;
        }
        else
        {
            ddlRsnN.Enabled = false;
        }
        mdlConfirm.Show();
    }
    //protected void txtbillAmt_TextChanged(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt64(txtOldAmt.Text) > 0 && txtOldAmt.Text != txtbillAmt.Text)
    //    {
    //        lblEditMode.Text = "1";
    //    }
    //}

    protected void ddlsubd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubd.SelectedIndex > 0)
        {
            Session["intWithdrwConId"] = Convert.ToInt16(ddlsubd.SelectedValue);
        }
    }
}
