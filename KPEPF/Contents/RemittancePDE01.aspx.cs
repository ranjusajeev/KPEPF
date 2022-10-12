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

public partial class Contents_RemittancePDE01 : System.Web.UI.Page
{

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblObj;
    AORecorrection aoRecorr;
    AORecorrectionDAO aoRecorrDAO;
    CorrectionEntry cor;
    CorrectionEntryDao cord;

    ChalanPDEAG chalPde;
    ChalanPDEDao chalDao;
    ChalanPDEAGDAO chalPDao;
    ScheduleMainDAO schMn;
    static int intMth = 0;
    static int intDy = 0;
    static int intYrId = 0;

    SchedulePDE schedPde;
    SchedulePDEDao schedPdeDao;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettings();
            if (Convert.ToDouble(Session["numChalanIdEdit"]) > 0)
            {
                double dd = Convert.ToDouble(Session["numChalanIdEdit"]);
                FillBack();
                FillGridDataset();
            }
            if (Request.QueryString["intChalanId"] != null)
            {
                //Initialsettings();
                //ddlYear.SelectedValue = Session["intYearIdRem01"].ToString();
                //ddlMonth.SelectedValue = Session["intMonthIdRem01"].ToString();
                //ddlDistrict.SelectedValue = Session["intDistIdRem01"].ToString();
                //FillBack();
                FillBack();
                FillChalanTxts();
            }
            //else
            //{
            //    Initialsettings();
            //}
        }
    }
    private void FillBack()
    {
        Initialsettings();
        ddlYear.SelectedValue = Session["intYearIdRem01"].ToString();
        ddlMonth.SelectedValue = Session["intMonthIdRem01"].ToString();
        ddlDistrict.SelectedValue = Session["intDistIdRem01"].ToString();
        FillGrid();
        chkShow.Checked = true;
    }
    private void Initialsettings()
    {
        gblObj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        Session["flgPageBack"] = 4;

        DataSet ds2 = new DataSet();
        ds2 = genDAO.GetYearPDEOnly();
        gblObj.FillCombo(ddlYear, ds2, 1);

        DataSet ds1 = new DataSet();
        ds1 = genDAO.GetMonth();
        gblObj.FillCombo(ddlMonth, ds1, 1);

        DataSet dsD = new DataSet();
        dsD = genDAO.GetDistrict();
        gblObj.FillCombo(ddlDistrict, dsD, 1);

        SetGridDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 1;
        clearnewchalan();
        chkShow.Checked = false;

        FillCmbFrm();
    }
    private void FillCmbFrm()
    {
        gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        GeneralDAO gen = new GeneralDAO();

        ArrayList arr1 = new ArrayList();
        arr1.Add(1);
        DataSet dsfrm = new DataSet();
        dsfrm = GenDao.getFromWhom(arr1);
        gblObj.FillCombo(ddlFrm, dsfrm, 1);
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intDistID");
        ar.Add("chvEngLBName");
        ar.Add("ChalDet");
        ar.Add("fltChalanAmt");
        ar.Add("fltTotalSum");
        ar.Add("intChalanId");
        ar.Add("flgPrevYear");
        ar.Add("intGroupId");
        ar.Add("flgApproval");
        ar.Add("intSchMainId");
        ar.Add("charType");
        gblObj.SetGridDefault(gdvRem01, ar);
        clearnewchalan();
        chkShow.Checked = false;
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIdRem01"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearIdRem01"] = 0;
        }
        if (Convert.ToInt16(Session["intYearIdBillEdit"]) >= 49)
        {
            gblObj.MsgBoxOk("Select year <2013-14", this);
            ddlMonth.Enabled = false;
        }
        else
        {
            ddlMonth.Enabled = true;
        }
        ddlMonth.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";
        SetGridDefault();
        //chkShow.Checked = false;
        //if (Convert.ToInt16(Session["intYearIdRem01"]) > 0 && Convert.ToInt16(Session["intMonthIdRem01"]) > 0 && Convert.ToInt16(Session["intDistIdRem01"]) > 0)
        //{
        //    lnkChal.Enabled = true;

        //}
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0)
        {
            Session["intMonthIdRem01"] = Convert.ToInt16(ddlMonth.SelectedValue);
        }
        else
        {
            Session["intMonthIdRem01"] = 0;
        }
        ddlDistrict.SelectedValue = "0";
        SetGridDefault();
        //chkShow.Checked = false;
        //if (Convert.ToInt16(Session["intYearIdRem01"]) > 0 && Convert.ToInt16(Session["intMonthIdRem01"]) > 0 && Convert.ToInt16(Session["intDistIdRem01"]) > 0)
        //{
        //    lnkChal.Enabled = true;
        //    //FillGrid();
        //}
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedIndex > 0)
        {
            Session["intDistIdRem01"] = Convert.ToInt16(ddlDistrict.SelectedValue);
        }
        else
        {
            Session["intDistIdRem01"] = 0;
        }
        if (Convert.ToInt16(Session["intYearIdRem01"]) > 0 && Convert.ToInt16(Session["intMonthIdRem01"]) > 0 && Convert.ToInt16(Session["intDistIdRem01"]) > 0)
        {

            FillGridDataset();
            FillCmbLbDt();
            //FillComboRsn();
            if (Convert.ToInt16(Session["intAppFlgPde"]) == 2 || Convert.ToInt16(Session["intAppFlgPde"]) == 0)
            {
                lnkChal.Enabled = true;
            }
            else
            {
                lnkChal.Enabled = false;
            }
        }
        SetGridDefault();
        //chkShow.Checked = false;
    }
    public void clearnewchalan()
    {
        txtchlnId.Text = "0";
        txtChalNo.Text = "0";
        txtChalDt.Text = "";
        txtChalAmt.Text = "0";
        ddlLBNew.SelectedValue = "0";
        ddlsubTreas.SelectedValue = "0";
        Session["numchalanId"] = "0";
        lblOl.Text = "0";
        lblNw.Text = "0";
        chkShow.Checked = false;

        ddlFrm.SelectedValue = "0";
        chkUpN.Checked = false;
        ddlRsnN.SelectedValue = "0";
        ddlRsnN.Enabled = false;
    }
    //private void FillComboRsn()
    //{
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    GeneralDAO gen = new GeneralDAO();

    //    ArrayList ar = new ArrayList();
    //    DataSet ds = new DataSet();
    //    ar.Add(1);
    //    ds = gen.GetMisClassRsn(ar);
    //    gblObj.FillCombo(ddlRsnN, ds, 1);
    //}
    private void FillCmbLbDt()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        GeneralDAO gen = new GeneralDAO();

        DataSet dslb = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intDistIdRem01"]));
        dslb = gen.GetLBDistwise(arr);
        gblObj.FillCombo(ddlLBNew, dslb, 1);

        DataSet ds1 = new DataSet();
        ds1 = gen.GetTreasury(arr);
        gblObj.FillCombo(ddlsubTreas, ds1, 1);

    }

    //private void FillGrid()
    //{
    //    gblObj = new clsGlobalMethods();

    //    DataSet dsRem01 = new DataSet();
    //    aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdRem01"]);
    //    aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdRem01"]);
    //    aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdRem01"]);
    //    dsRem01 = aoRecorrDAO.SelectApprovalPDELnk1(aoRecorr);
    //    if (dsRem01.Tables[0].Rows.Count > 0)
    //    {
    //        gdvRem01.DataSource = dsRem01;
    //        gdvRem01.DataBind();
    //        for (int i = 0; i < gdvRem01.Rows.Count; i++)
    //        {
    //            if (Convert.ToInt16(dsRem01.Tables[0].Rows[i].ItemArray[11]) == 1)
    //            {
    //                gblObj.HeighlightRow(gdvRem01, i, 3 );
    //                gblObj.HeighlightRow(gdvRem01, i, 4 );
    //            }
    //        }
    //        gblObj.SetFooterTotals(gdvRem01, 3);
    //        gblObj.SetFooterTotals(gdvRem01, 4);

    //        lblStatus.Text = dsRem01.Tables[0].Rows[0].ItemArray[12].ToString();
    //    }
    //    else
    //    {
    //        SetGridDefault();
    //    }
    //}

    private void FillGridDataset()
    {
        gblObj = new clsGlobalMethods();
        aoRecorr = new AORecorrection();
        aoRecorrDAO = new AORecorrectionDAO();
        DataSet dsRem01 = new DataSet();
        aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdRem01"]);
        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdRem01"]);
        aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdRem01"]);
        aoRecorr.IntType = 1;
        dsRem01 = aoRecorrDAO.SelectApprovalPDEWithFlg(aoRecorr);
        if (dsRem01.Tables[0].Rows.Count > 0)
        {

            lblStatus.Text = dsRem01.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["intAppFlgPde"] = Convert.ToInt16(dsRem01.Tables[0].Rows[0].ItemArray[0]);
            //lnkChal.Enabled = true;
            SetNewChalTxts();
        }
        else
        {
            SetGridDefault();
            Session["intAppFlgPde"] = 0;
        }
    }
    private void FillChalanTxts()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        ChalanPDEAGDAO chalPDao = new ChalanPDEAGDAO();

        mdlConfirm.Show();
        Session["intChalanId"] = Convert.ToDouble(Request.QueryString["intChalanId"]);
        Session["intSchMainId"] = Convert.ToDouble(Request.QueryString["intSchMainId"]);
        //FillCmbDT();
        //FillCmbLb();
        //FillComboChalanType();
        FillGridDataset();
        FillCmbLbDt();
        FillComboRsn();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["intChalanId"] != null)
        {
            arr.Add(Session["intChalanId"]);
            ds = chalPDao.RemitancechlntextfillPDE2001(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtChalNo.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                txtChalDt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                txtChalAmt.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                ddlLBNew.SelectedValue = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                //ddlchlType.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtchlnId.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                txtSchMainId.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                txtGrpId.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                lblYr.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                lblMonth.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                lblDy.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                ddlFrm.SelectedValue = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[16].ToString()) == 2)
                {
                    chkUpN.Checked = true;
                    ddlRsnN.Enabled = true;
                    ddlRsnN.SelectedValue = ds.Tables[0].Rows[0].ItemArray[17].ToString();
                }
                else
                {
                    chkUpN.Checked = false;
                    ddlRsnN.Enabled = false;
                    ddlRsnN.SelectedValue = "0";
                }
            }
            else
            {

            }
            SetNewChalTxts();
        }
        else
        {
            Session["intChalanId"] = 0;
        }
    }
    private void SetNewChalTxts()
    {
        if (Convert.ToInt16(Session["intAppFlgPde"]) == 1)
        {
            txtChalNo.ReadOnly = true;
            txtChalDt.ReadOnly = true;
            txtChalDt.Enabled = false;
            txtChalAmt.ReadOnly = true;
            ddlLBNew.Enabled = false;
            ddlsubTreas.Enabled = false;
            btnDel.Enabled = false;
            btnNewChal.Enabled = false;

            lnkChal.Enabled = false;
        }
        else
        {
            txtChalNo.ReadOnly = false;
            txtChalDt.ReadOnly = false;
            txtChalDt.Enabled = true;
            txtChalAmt.ReadOnly = false;
            ddlLBNew.Enabled = true;
            ddlsubTreas.Enabled = true;
            btnDel.Enabled = true;
            btnNewChal.Enabled = true;

            lnkChal.Enabled = true;
        }
        SetGrid();
    }
    private void FillGrid()
    {
        gblObj = new clsGlobalMethods();
        aoRecorr = new AORecorrection();
        aoRecorrDAO = new AORecorrectionDAO();
        DataSet dsRem01 = new DataSet();
        aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdRem01"]);
        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdRem01"]);
        aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdRem01"]);
        dsRem01 = aoRecorrDAO.SelectApprovalPDELnk1(aoRecorr);
        if (dsRem01.Tables[0].Rows.Count > 0)
        {
            gdvRem01.DataSource = dsRem01;
            gdvRem01.DataBind();
            for (int i = 0; i < gdvRem01.Rows.Count; i++)
            {
                if (Convert.ToInt16(dsRem01.Tables[0].Rows[i].ItemArray[11]) == 1)
                {
                    gblObj.HeighlightRow(gdvRem01, i, 3);
                    gblObj.HeighlightRow(gdvRem01, i, 4);
                }

                GridViewRow gvr = gdvRem01.Rows[i];
                Label lblSchMn = (Label)gvr.FindControl("lblSchMn");
                lblSchMn.Text = dsRem01.Tables[0].Rows[i].ItemArray[13].ToString();

            }
            gblObj.SetFooterTotals(gdvRem01, 3);
            gblObj.SetFooterTotals(gdvRem01, 4);

            //lblStatus.Text = dsRem01.Tables[0].Rows[0].ItemArray[12].ToString();
        }
        else
        {
            SetGridDefault();
        }
    }

    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        SaveSchMn();
        SaveNewChalan();
        if (Convert.ToInt16(lblEditMode.Text) > 0)
        {
            SaveCorrectionEntryChal(Convert.ToInt32(txtchlnId.Text), Convert.ToInt16(lblEditMode.Text), Convert.ToInt16(Session["intYearIdRem01"]), Convert.ToInt16(Session["intMonthIdRem01"]), Convert.ToDateTime(txtChalDt.Text).Day);
        }

        gblObj.MsgBoxOk("Saved successfully!!!", this);
        FillBack();
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        schedPdeDao = new SchedulePDEDao();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        ar.Add(1);
        dsChal = schedPdeDao.GetSchedDet4CorrEntryCorr(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        for (int i = 0; i <= cntEmp - 1; i++)
        {
            int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[0]);
            double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
            //double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, dblCalcAmt);
            double dblAmtAdjusted = gblObj.CalculateAdjAmtDtUpd(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, amt, intEditMode);
            ///// Save to CorrEntry/////////
            cor.IntAccNo = accNo;
            cor.IntYearID = yr;
            cor.IntMonthID = Convert.ToInt16(Session["intMonthIdRem01"]);
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            //corr.FltAmountAfter = Math.Round(dblAmtAdjusted);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = chalId;
            cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
            cor.FlgType = 1;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = 1; //Edit Chal Date
            //if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
            //{
            //    cor.IntChalanType = 1;
            //}
            //else
            //{
            cor.IntChalanType = 2;
            //}
            cord.CreateCorrEntry(cor);
            ///// Save to CorrEntry/////////
        }

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }

    private void SaveSchMn()
    {
        schedPdeDao = new SchedulePDEDao();

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(txtSchMainId.Text));      //Sched MainId
        ar.Add(Convert.ToInt16(ddlLBNew.SelectedValue));     //LB Id
        ar.Add(Convert.ToInt32(Session["intGrpId"]));     //Group Id
        ar.Add(Convert.ToInt64(Session["intUserId"]));     //User Id
        ar.Add(Convert.ToInt64(txtChalAmt.Text));
        ds = schedPdeDao.ScheduleMainSavePDE01(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["intSchMainId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            Session["intGrpId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);
        }
    }
    //private void saveCorrectionEntry(int rw, float schedId, int intDel)
    //{
    //    gendao = new GeneralDAO();
    //    gblObj = new clsGlobalMethods();
    //    corr = new CorrectionEntry();
    //    corrDao = new CorrectionEntryDao();
    //    int yr;
    //    int mth;
    //    int intDy;
    //    Double amtO = 0;
    //    Double amtN = 0;
    //    int accO = 0;
    //    int accN = 0;
    //    Double amtCalc = 0;
    //    Session["intCCYearId"] = gendao.GetCCYearId() + 1;

    //    yr = Convert.ToInt16(Session["intYearIdRem01"]);
    //    mth = Convert.ToDateTime(Session["chalDate"]).Month;
    //    intDy = Convert.ToDateTime(Session["chalDate"]).Day;

    //    amtO = Convert.ToDouble(lblOTot.Text);
    //    amtN = Convert.ToDouble(lblNewTot.Text);
    //    accO = Convert.ToInt16(lblOAcc.Text);
    //    accN = Convert.ToInt16(lblNewAcc.Text);

    //    amtCalc = amtN;
    //    corr.FltAmountBefore = 0;
    //    corr.FltAmountAfter = amtN;

    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
    //    ///// Save to CorrEntry/////////
    //    corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
    //    corr.IntYearID = yr;
    //    corr.IntMonthID = mth;
    //    corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    corr.FltCalcAmount = dblAmtAdjusted;
    //    corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    corr.IntChalanId = Convert.ToInt64(Session["numChalanIdEdit"]);
    //    corr.IntSchedId = schedId;
    //    corr.FlgType = 1;           //Remittance
    //    corr.FltRoundingAmt = 0;
    //    corr.IntCorrectionType = corrType;
    //    if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //    {
    //        corr.IntChalanType = 1;
    //    }
    //    else
    //    {
    //        corr.IntChalanType = 2;
    //    }
    //    corrDao.CreateCorrEntry(corr);

    //}
    private void SaveNewChalan()
    {
        chalPde = new ChalanPDEAG();
        chalPDao = new ChalanPDEAGDAO();
        genDAO = new KPEPFGeneralDAO();
        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();
        {
            chalPde.ChalanId = Convert.ToInt32(txtchlnId.Text);
            chalPde.IntChalanNo = Convert.ToInt16(txtChalNo.Text);
            chalPde.DtmChalanDt = txtChalDt.Text.ToString();
            chalPde.FltChalanAmt = Convert.ToInt64(txtChalAmt.Text);
            chalPde.IntLBID = Convert.ToInt16(ddlLBNew.SelectedValue);
            chalPde.IntTreasID = Convert.ToInt16(ddlsubTreas.SelectedValue);
            chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
            chalPde.IntModeOfChgID = 2;
            ar.Add(Convert.ToInt16(Session["intYearIdRem01"]));
            dsyr = genDAO.GetPDEYrId(ar);
            if (dsyr.Tables[0].Rows.Count > 0)
            {
                chalPde.IntYearID = Convert.ToInt16(dsyr.Tables[0].Rows[0].ItemArray[0]);
            }
            else
            {
                chalPde.IntYearID = 0;
            }
            chalPde.IntGroupId = Convert.ToInt32(Session["intGrpId"]);
            chalPde.IntFrmWhomId = Convert.ToInt16(ddlFrm.SelectedValue);

            if (chkUpN.Checked == true)
            {
                chalPde.FlgUnPosted = 2;
                chalPde.IntReasonID = Convert.ToInt16(ddlRsnN.SelectedValue);
            }
            else
            {
                chalPde.FlgUnPosted = 1;
                chalPde.IntReasonID = 0;
            }

            chalPDao.SaveChalandetailsPDE01(chalPde);
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        //pnlChalNew.Visible = false;
        mdlConfirm.Hide();
    }
    protected void ddlchlType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        DateTime dtm = new DateTime();
        if (gblObj.isValidDate(txtChalDt, this) == true)
        {
            //if (gblObj.CheckChalanDate(txtChalDt, ddlYear, ddlMonth) == true)
            if (gblObj.CheckChalanDate(txtChalDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue)) == true)
            {
                dtm = Convert.ToDateTime(txtChalDt.Text);
                int monthId = dtm.Month;
                if (dtm.Day <= 4 && Convert.ToInt16(lblDy.Text) > 4)
                {
                    lblEditMode.Text = "1";
                }
                else if (dtm.Day > 4 && Convert.ToInt16(lblDy.Text) <= 4)
                {
                    lblEditMode.Text = "2";
                }
                else
                {
                    lblEditMode.Text = "0";
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtChalDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtChalDt.Text = "";
        }
        mdlConfirm.Show();
    }

    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        FillCmbLbDt();
        //FillComboRsn();
        SetGridDefault();
        mdlConfirm.Show();
    }
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShow.Checked == true)
        {

            FillGrid();
            SetGrid();
        }
        else
        {
            SetGridDefault();
        }
    }
    private void SetGrid()
    {
        if (Convert.ToInt16(Session["intAppFlgPde"]) == 1)
        {
            for (int i = 0; i < gdvRem01.Rows.Count; i++)
            {
                GridViewRow gdvrowS = gdvRem01.Rows[i];
                gdvrowS.Cells[0].Enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < gdvRem01.Rows.Count; i++)
            {
                GridViewRow gdvrowS = gdvRem01.Rows[i];
                gdvrowS.Cells[0].Enabled = true;
            }
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        chalPDao = new ChalanPDEAGDAO();
        chalPde = new ChalanPDEAG();
        schedPdeDao = new SchedulePDEDao();
        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();

        CorrectionEntryForDel(Convert.ToInt32(txtchlnId.Text)); //Corr Entry
        ar.Add(Convert.ToInt32(txtchlnId.Text));
        chalPDao.DeleteChalan01(ar);
        schedPdeDao.UpdScheduleTR104ModeChalanIdWise(ar);

        gblObj.MsgBoxOk("Deleted ", this);
        FillBack();
    }
    private void CorrectionEntryForDel(double numChalId)
    {
        schedPde = new SchedulePDE();
        schedPdeDao = new SchedulePDEDao();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        int chlId;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ar.Add(1);
        ds = schedPdeDao.GetSchedDet4CorrEntryCorr(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                chlId = Convert.ToInt32(txtchlnId.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(txtChalDt.Text.ToString());

                intMth = dt.Month;
                intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(txtChalDt.Text.ToString());
                intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, chlId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 1);
                //schedPdeDao.DelTR104PDEMode(ar);
            }
        }
    }

    private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType)
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
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
        cor.FlgType = 1;           //Remittance
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
        ///// Save to CorrEntry/////////
        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }
    private void FillComboRsn()
    {
        gblObj = new clsGlobalMethods();
        gendao = new GeneralDAO();

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(1);
        ds = gendao.GetMisClassRsn(ar);
        gblObj.FillCombo(ddlRsnN, ds, 1);
    }

    protected void chkUpN_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUpN.Checked == true)
        {
            ddlRsnN.Enabled = true;
            FillComboRsn();
        }
        else
        {
            ddlRsnN.Enabled = false;
        }
        mdlConfirm.Show();
    }
}
