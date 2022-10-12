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

public partial class Contents_DebitPlusPDE : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    Missing ms;
    MissingDAO msDao;
    TEDAO teDAO;
    BalancetransDAO blDAO;
    WithdrawalPDEAG withAG;
    WithdrawalPDEAGDAO PDEAgDao;
    BalanTrPDE blPDE;
    BalanceTransPDEDao blPDEDao;

    CorrectionEntry cor;
    CorrectionEntryDao cord;

    Employee emp;
    EmployeeDAO empD;

    public int Trntype = 0;
    public int mnthId;
    public int yrId;
    public int RelMnthID;
    int corrType = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToDouble(Session["intVoucherIDEdit"]) > 0)
            {
                ShowDBPlus();
                ShowWithoutDocs();
                ShowBalanceTransDt();
                SetEnable();
                FillHeadLbls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetEnable()
    {
        if (Convert.ToInt16(Session["flgAppAg"]) == 2)
        {
            SetCtrlsEnable();
        }
        else
        {
            SetCtrlsDisable();
        }
    }
    protected void  txtCntRow_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        PDEAgDao = new WithdrawalPDEAGDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddldrawn");
            arDdl.Add("ddlTreasDBplus");
            arDdl.Add("ddlreason");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();
            DataSet dsdr = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(2);
            dsdr = PDEAgDao.GetDrawnBy(arrIn);
            arDdlDs.Add(dsdr);

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDs.Add(dstreas);

            DataSet dsM = new DataSet();
            ArrayList arrIn1 = new ArrayList();
            arrIn1.Add(2);
            dsM = gendao.GetMisClassRsn(arrIn1);
            arDdlDs.Add(dsM);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsdbplus = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(3);
            dsdbplus = PDEAgDao.FillDBPlusPDEAddrw(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("intVoucherID");
            arHp.Add("intVoucherNo");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////
         
            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dsdbplus, Convert.ToInt16(txtCnt.Text), gdvDPWith, arDdl, arCols, arDdlDs, arHp);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }

    private void SetCtrlsEnable()
    {
        gdvDPWithOut.Enabled = true;
        gdvBlnsDP.Enabled = true;
        SetWithDocsGridEnable();
        txtCnt.Enabled = true;
        btnOkWithouDocsDb.Enabled = true;
        btnSaveDBPlus.Enabled = true;
        btnbalance.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        gdvDPWithOut.Enabled = false;
        gdvBlnsDP.Enabled = false;
        SetWithDocsGridDisable();
        txtCnt.Enabled = false;
        btnOkWithouDocsDb.Enabled = false;
        btnSaveDBPlus.Enabled = false;
        btnbalance.Enabled = false;
    }
    private void SetWithDocsGridDisable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = true;
            txtTeDPAss.Enabled = false;

            TextBox txtBillNoWDAss = (TextBox)gdvrow.FindControl("txtBillNoWD");
            txtBillNoWDAss.ReadOnly = true;
            txtBillNoWDAss.Enabled = false;


            TextBox txtBilldateDBplusAss = (TextBox)gdvrow.FindControl("txtBilldateDBplus");
            txtBilldateDBplusAss.ReadOnly = true;
            txtBilldateDBplusAss.Enabled = false;

            DropDownList ddldrawnAss = (DropDownList)gdvrow.FindControl("ddldrawn");
            ddldrawnAss.Enabled = false;


            TextBox txtAmtDbPlusAss = (TextBox)gdvrow.FindControl("txtAmtDbPlus");
            txtAmtDbPlusAss.ReadOnly = true;
            txtAmtDbPlusAss.Enabled = false;

            DropDownList ddlTreasDBplusAss = (DropDownList)gdvrow.FindControl("ddlTreasDBplus");
            ddlTreasDBplusAss.Enabled = false;

            CheckBox chlUnpostDPW = (CheckBox)gdvrow.FindControl("chlUnpostDPW");
            chlUnpostDPW.Enabled = false;

            DropDownList ddlreason = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreason.Enabled = false;

            //TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            //txtRelMnthWiseIdWAss.ReadOnly = true;
            //txtRelMnthWiseIdWAss.Enabled = false;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = true;
            //RelMnthAss.Enabled = false;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = true;
            //RelYearIdAss.Enabled = false;

        }
    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = false ;
            txtTeDPAss.Enabled = true;

            TextBox txtBillNoWDAss = (TextBox)gdvrow.FindControl("txtBillNoWD");
            txtBillNoWDAss.ReadOnly = false;
            txtBillNoWDAss.Enabled = true;


            TextBox txtBilldateDBplusAss = (TextBox)gdvrow.FindControl("txtBilldateDBplus");
            txtBilldateDBplusAss.ReadOnly = false;
            txtBilldateDBplusAss.Enabled = true;

            DropDownList ddldrawnAss = (DropDownList)gdvrow.FindControl("ddldrawn");
            ddldrawnAss.Enabled = true;


            TextBox txtAmtDbPlusAss = (TextBox)gdvrow.FindControl("txtAmtDbPlus");
            txtAmtDbPlusAss.ReadOnly = false;
            txtAmtDbPlusAss.Enabled = true;

            DropDownList ddlTreasDBplusAss = (DropDownList)gdvrow.FindControl("ddlTreasDBplus");
            ddlTreasDBplusAss.Enabled = true;

            CheckBox chlUnpostDPW = (CheckBox)gdvrow.FindControl("chlUnpostDPW");
            chlUnpostDPW.Enabled = true;

            //DropDownList ddlreason = (DropDownList)gdvrow.FindControl("ddlreason");
            //ddlreason.Enabled = true;

            //TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            //txtRelMnthWiseIdWAss.ReadOnly = false;
            //txtRelMnthWiseIdWAss.Enabled = true;


            //Label RelMnthAss = (TextBox)gdvrow.FindControl("lblMnth");
            //RelMnthAss.ReadOnly = false;
            //RelMnthAss.Enabled = true;

            //Label RelYearIdAss = (TextBox)gdvrow.FindControl("lblYearId");
            //RelYearIdAss.ReadOnly = false;
            //RelYearIdAss.Enabled = true;

        }
    }
    private void InitialSettings()
    {
        Session["flgPageBack"] = 6;
        SetGridDefault(gdvDPWith);
        ViewGrid();
       
        fillGridcombos(gdvDPWith);
        fillGridcomboswithoutDocs(gdvDPWithOut);
        fillGridcombosBT(gdvBlnsDP);

        ShowDBPlus();
        ShowWithoutDocs();
        ShowBalanceTransDt();
        SetEnable();
        FillHeadLbls();
    }
    private void SetGridDefault(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intVoucherNo");
        ar.Add("intVoucherID");
       // ar.Add("flgPrevYear");
      //  ar.Add("flgApproval");
        //ar.Add("Dist");
        //ar.Add("Localbody");
        //ar.Add("Unposted");
        //ar.Add("Reason");
        //ar.Add("Status");
        //ar.Add("Add");
        gblobj.SetGridDefault(gdv, ar);
    }
    private void ViewGrid()
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetBlankRow(gdvDPWithOut);
        gblobj.SetBlankRow(gdvBlnsDP);
    }
    public void fillGridcombosBT(GridView gdv)
    {
        //DataSet dsstatus = new DataSet();
        //dsstatus = PDEAgDao.GetStatus();

        //for (int i = 0; i < gdv.Rows.Count; i++)
        //{
        //    GridViewRow grdVwRow = gdv.Rows[i];
        //    DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
        //    gblobj.FillCombo(ddlStatus, dsstatus, 1);
        //}
    }
    public void fillGridcombos(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        gendao = new GeneralDAO();
        teDAO = new TEDAO();
        PDEAgDao = new WithdrawalPDEAGDAO();
        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreasDBplusAss = (DropDownList)grdVwRow.FindControl("ddlTreasDBplus");
            gblobj.FillCombo(ddlTreasDBplusAss, dstreas, 1);

        }
        DataSet dsdist = new DataSet();
        dsdist = teDAO.GetDist();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlDistDbplusAss = (DropDownList)grdVwRow.FindControl("ddlDist");
            gblobj.FillCombo(ddlDistDbplusAss, dsdist, 1);

        }
        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {

            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            gblobj.FillCombo(ddlLBAss, dslb, 1);

        }
        DataSet dsdr = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(2);
        dsdr = PDEAgDao.GetDrawnBy(arrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddldrawn = (DropDownList)grdVwRow.FindControl("ddldrawn");
            gblobj.FillCombo(ddldrawn, dsdr, 1);

        }
        DataSet dsM = new DataSet();
        ArrayList aIn = new ArrayList();
        aIn.Add(2);
        dsM = gendao.GetMisClassRsn(aIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlreasonAs = (DropDownList)grdVwRow.FindControl("ddlreason");
            gblobj.FillCombo(ddlreasonAs, dsM, 1);
        }
    }
    public void fillGridcomboswithoutDocs(GridView gdv)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        DataSet dstreas = new DataSet();
        dstreas = gendao.GetDisTreasuryWithOutDistId();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreasuryDPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreasuryDPWO");
            gblobj.FillCombo(ddlTreasuryDPWOAss, dstreas, 1);
        }
    }
    protected void btnSaveDBPlus_Click(object sender, EventArgs e)
    {
        SaveWithDocsDB();
    }
    private Boolean lFunEditable(Int32 chId, int trid, int chno, string chdt, double amt, string teno,int drnBy,CheckBox chk)
    {
        PDEAgDao = new WithdrawalPDEAGDAO();
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(chId);
        ar.Add(trid);
        ar.Add(chno);
        ar.Add(chdt);
        ar.Add(amt);
        ar.Add(teno);
        ar.Add(drnBy);
        if (chk.Checked == true)
        {
            ar.Add(2);
        }
        else
        {
            ar.Add(1);
        }
        ds = PDEAgDao.getEditable(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    public void SaveWithDocsDB()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        msDao = new MissingDAO();
        int cnt = 0;
        if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
        {
            for (int i = 0; i < gdvDPWith.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvDPWith.Rows[i];
                TextBox txtBilldateDBplus = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
                TextBox RelMnthAss = (TextBox)gdvrw.FindControl("RelMnth");
                TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
                TextBox txtAmtDbPlus = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
                DropDownList ddlTreasDBplus = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
                TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrw.FindControl("txtRelMnthWiseIdW");
                TextBox txtTeDPW = (TextBox)gdvrw.FindControl("txtTeDP");
                TextBox txtRelMnthWise = (TextBox)gdvrw.FindControl("txtRelMnthWiseIdW");
                Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
                TextBox txtBillNo = (TextBox)gdvrw.FindControl("txtBillNoWD");
                DropDownList ddldrawn = (DropDownList)gdvrw.FindControl("ddldrawn");
                CheckBox chlUnpostDPW = (CheckBox)gdvrw.FindControl("chlUnpostDPW");

                if (MandatoryFldsWithDocs(i) == true)
                {
                    if (lFunEditable(Convert.ToInt32(lblintIdAss.Text), Convert.ToInt16(ddlTreasDBplus.Text), Convert.ToInt16(txtBillNo.Text), txtBilldateDBplus.Text.ToString(), Convert.ToDouble(txtAmtDbPlus.Text), txtTeDPW.Text.ToString(), Convert.ToInt16(ddldrawn.SelectedValue), chlUnpostDPW) == false)
                    {
                        DataSet ds = new DataSet();
                        ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);

                        if (txtBilldateDBplus.Text == "")
                        {
                            ms.DtmChalanBilllDt = "";
                        }
                        else
                        {
                            ms.DtmChalanBilllDt = txtBilldateDBplus.Text.ToString();
                            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
                            mnthId = billDate.Month;

                            ArrayList ardt = new ArrayList();
                            ardt.Add(txtBilldateDBplus.Text.ToString());
                            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
                            //RelMnthAss.Text = mnthId.ToString();
                            //ms.IntRelMonthId = Convert.ToInt32(RelMnthAss.Text);
                            ms.IntRelMonthId = mnthId;
                            //RelYearIdAss.Text = yrId.ToString();
                            //ms.IntRelYearId = Convert.ToInt32(RelYearIdAss.Text);
                            ms.IntRelYearId = yrId;
                        }
                        if (txtAmtDbPlus.Text == "")
                        {
                            ms.FltAmtPDE = 0;
                        }
                        else
                        {
                            ms.FltAmtPDE = Convert.ToDecimal(txtAmtDbPlus.Text);
                        }
                        ms.IntTrnType = 3;

                        if (ddlTreasDBplus.SelectedIndex > 0)
                        {
                            ms.IntTreaId = Convert.ToInt32(ddlTreasDBplus.SelectedValue);
                        }
                        else
                        {
                            ms.IntTreaId = 0;
                        }
                        ms.IntModeChg = 2;

                        if (txtRelMnthWiseIdWAss.Text == "")
                        {
                            ms.IntRelMonthWiseId = 0;
                        }
                        else
                        {
                            ms.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdWAss.Text);
                        }
                        if (txtTeDPW.Text == "")
                        {
                            ms.ChvTEIdPDE = "";
                        }
                        else
                        {
                            ms.ChvTEIdPDE = txtTeDPW.Text.ToString();
                        }
                        ds = msDao.TERelMonthWiseUpd(ms);
                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            ms.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                            txtRelMnthWise.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                            RelMnthID = ms.IntRelMonthWiseId;
                        }
                        SaveWithAG(i);
                    }
                }
                else
                {
                    cnt = cnt + 1;
                }
            }
        }
        if (cnt > 0)
        {
            gblobj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            gblobj.MsgBoxOk("Saved successfully", this);
            ShowDBPlus();
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blPDEDao = new BalanceTransPDEDao();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvBlnsDP.Rows[rowIndex];
        Label lblintId = (Label)gdvrw.FindControl("lblintId");
        Label lblAccNo = (Label)gdvrw.FindControl("lblAccNo");
        TextBox txtAmount = (TextBox)gdvrw.FindControl("txtAmount");

        Label oldAcc = (Label)gdvrw.FindControl("lbloldAcc");
        Label oldAmt = (Label)gdvrw.FindControl("lbloldAmt");

        double amtO = Convert.ToDouble(oldAmt.Text);
        double amtN = Convert.ToDouble(txtAmount.Text);
        int accO = Convert.ToInt32(oldAcc.Text);
        int accN = Convert.ToInt32(lblAccNo.Text);
        saveCorrectionEntryBT(Convert.ToInt32(lblintId.Text), amtO, amtN, accO, accN, 1);
        //////////////saveCorrectionEntryBT//////////////////////

        ArrayList arrin = new ArrayList();
        if (lblintId.Text != "")
        {
            arrin.Add(Convert.ToInt32(lblintId.Text));
            try
            {
                blPDEDao.DeleteBalancetransCrPDE(arrin);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }

            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowBalanceTransDt();
        FillHeadLbls();

    }
    private void saveCorrectionEntryBT(float schedId, double amtO, double amtN, Int32 accO, Int32 accN, int intDel)
    {

        genDAO = new KPEPFGeneralDAO();
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();
        int yr;
        int mth;
        int intDy;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        yr = Convert.ToInt16(Session["IntYearAG"]);
        mth = Convert.ToInt16(Session["IntMonthAG"]);
        intDy = 1;

        findCorrType(amtO, amtN, accO, accN, intDel);
        if (corrType == 10)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    cor.IntAccNo = accO;
                    amtCalc = amtN;
                    cor.FltAmountBefore = amtO;
                    cor.FltAmountAfter = 0;
                }
                else
                {
                    cor.IntAccNo = accN;
                    amtCalc = -amtN;
                    cor.FltAmountBefore = 0;
                    cor.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                cor.IntYearID = yr;
                cor.IntMonthID = mth;
                cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                cor.FltCalcAmount = dblAmtAdjusted;
                cor.FlgCorrected = 1;      //Just added not incorporated in CCard
                cor.IntChalanId = schedId;
                cor.IntSchedId = schedId;
                cor.FlgType = 2;           //Remittance
                cor.FltRoundingAmt = 0;
                cor.IntCorrectionType = corrType;
                cor.IntChalanType = 4;
                cor.IntTblTp = 1;
                cord.CreateCorrEntryCalcTblTp(cor);
            }
        }
        else
        {
            if (corrType == 13)
            {
                amtCalc = -amtN;
                cor.FltAmountBefore = 0;
                cor.FltAmountAfter = amtN;
            }
            else if (corrType == 12)
            {
                amtCalc = amtN;
                cor.FltAmountBefore = amtN;
                cor.FltAmountAfter = 0;
            }
            else
            {
                amtCalc = amtO - amtN;
                cor.FltAmountBefore = amtO;
                cor.FltAmountAfter = amtN;
            }
            double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
            ///// Save to CorrEntry/////////
            cor.IntAccNo = accN;
            cor.IntYearID = yr;
            cor.IntMonthID = mth;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltCalcAmount = dblAmtAdjusted;
            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = schedId;
            cor.IntSchedId = schedId;
            cor.FlgType = 2;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = corrType;
            cor.IntChalanType = 4;
            cor.IntTblTp = 1;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 12;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 13;
            }
            else if (acco != accn)  // acc no change  (From local master)
            {
                corrType = 10;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 11;
            }
        }
    }
    //private void SaveCorrectionEntry(int intAccNo, float chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType)
    //{
    //    gendao = new GeneralDAO();
    //    gblobj = new clsGlobalMethods();
    //    cor = new CorrectionEntry();
    //    cord = new CorrectionEntryDao();

    //    Session["intCCYearId"] = gendao.GetCCYearId() + 1;
    //    double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
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
    //    cor.FlgType = 1;           //Remittance
    //    cor.FltRoundingAmt = 0;
    //    cor.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    cor.IntChalanType = ChalType;
    //    cor.IntTblTp = 1;
    //    cord.CreateCorrEntryCalcTblTp(cor);
    //}
    private Boolean MandatoryFldsWithDocs(int i)
    {
        Boolean flg;
        GridViewRow gdv = gdvDPWith.Rows[i];
        TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
        TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
        TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
        DropDownList ddlTreasDBplusAss = (DropDownList)gdv.FindControl("ddlTreasDBplus");
        TextBox txtTeDP = (TextBox)gdv.FindControl("txtTeDP");

        //if (txtBilldateDBplusAss.Text == null || txtBilldateDBplusAss.Text == "" || Convert.ToInt32(txtBillNoDBPlusAss.Text) >= 9999)
        if (txtBilldateDBplusAss.Text == null || txtBilldateDBplusAss.Text == "" || txtBillNoDBPlusAss.Text == null || txtBillNoDBPlusAss.Text == "" || Convert.ToInt32(txtBillNoDBPlusAss.Text) == 0 || txtTeDP.Text == null || txtTeDP.Text == "")
        {
            flg = false;
        }
        else if (txtAmtDbPlusAss.Text == null || txtAmtDbPlusAss.Text == "")
        {
            flg = false;
        }
        else if (Convert.ToInt32(ddlTreasDBplusAss.SelectedValue) == 0)
        {
            flg = false;
        }       
        else
        {
            flg = true;
        }
        return flg;
    }
    private void SaveWithAG(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        withAG = new WithdrawalPDEAG();
        PDEAgDao = new WithdrawalPDEAGDAO();
        ArrayList ardt = new ArrayList();

        GridViewRow gdvrw = gdvDPWith.Rows[j];
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
        Label lblintId = (Label)gdvrw.FindControl("lblintId");
        if (lblintIdAss.Text == "")
        {
            withAG.IntVoucherID = 0;
        }
        else
        {
            withAG.IntVoucherID = Convert.ToInt32(lblintIdAss.Text);
        }
        withAG.IntRelMonthWsID = RelMnthID;
        TextBox txtTeDP = (TextBox)gdvrw.FindControl("txtTeDP");
        if (txtTeDP.Text == "")
        {
            withAG.ChvTENo = "";
        }
        else
        {
            withAG.ChvTENo = txtTeDP.Text.ToString();
        }
        TextBox txtBillNoDBPlusAss = (TextBox)gdvrw.FindControl("txtBillNoWD");
        if (txtBillNoDBPlusAss.Text == "")
        {
            withAG.IntVoucherNo = 0;
        }
        else
        {
            withAG.IntVoucherNo = Convert.ToInt32(txtBillNoDBPlusAss.Text);
        }

        DropDownList ddlTreasDBplus = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
        if (ddlTreasDBplus.SelectedIndex > 0)
        {
            withAG.IntDTreaID = Convert.ToInt32(ddlTreasDBplus.SelectedValue);
        }
        else
        {
            withAG.IntDTreaID = 0;
        }
        TextBox txtBilldateDBplus = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
        if (txtBilldateDBplus.Text == "")
        {
            withAG.DtmVoucherDt = "";
        }
        else
        {
            withAG.DtmVoucherDt = txtBilldateDBplus.Text.ToString();
            ardt.Add(txtBilldateDBplus.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
            //TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            //RelYearIdAss.Text = yrId.ToString();
            withAG.IntYearID = yrId;
        }
        TextBox txtAmtDbPlus = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
        if (txtAmtDbPlus.Text == "")
        {
            withAG.FltAmount = 0;
        }
        else
        {
            withAG.FltAmount = Convert.ToDecimal(txtAmtDbPlus.Text);
        }
        withAG.IntModeOfChgId = 2;
        withAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        CheckBox chlUnpostDPW = (CheckBox)gdvrw.FindControl("chlUnpostDPW");
        if (chlUnpostDPW.Checked == true)
        {
            withAG.FlgUnPosted = 2;
            DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
            withAG.IntReasonID = Convert.ToInt32(ddlreasonAss.SelectedValue);
        }
        else
        {
            withAG.FlgUnPosted = 1;
            withAG.IntReasonID = 0;
        }

        DropDownList ddldrawn = (DropDownList)gdvrw.FindControl("ddldrawn");
        if (ddldrawn.SelectedIndex > 0)
        {
            withAG.IntDrawnBy = Convert.ToInt32(ddldrawn.SelectedValue);
        }
        else
        {
            withAG.IntDrawnBy = 0;
        }

        DataSet ds = new DataSet();
        ds = PDEAgDao.SaveVoucherAG(withAG);
        if (ds.Tables[0].Rows.Count >= 1)
        {

            lblintId.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        ////////////// Correction  ////////////////
        if (Convert.ToInt16(lblEditId.Text) > 0)
        {
            Label oldYear = (Label)gdvrw.FindControl("lblYearId");
            Label oldMnth = (Label)gdvrw.FindControl("lblMnth");

            int yr1 = Convert.ToInt16(oldYear.Text);
            int mth1 = Convert.ToInt16(oldMnth.Text);
            int yr2 = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
            int mth2 = Convert.ToDateTime(txtBilldateDBplus.Text).Month;
            SaveCorrectionEntryChal(Convert.ToInt32(lblintId.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, yr2, mth2);
        }
        ////////////// Correction  ////////////////
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr1, int mth1, int yr2, int mth2)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        dsChal = PDEAgDao.withPDEForCorrectionEntry(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        for (int i = 0; i <= cntEmp - 1; i++)
        {
            int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[0]);
            double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            //double dblCalcAmt = gblobj.CalculateAmtToCalc(yr, amt);
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr2, amt);
            //double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpd(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, amt, intEditMode);
            double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpdLat(yr1, yr2, Convert.ToInt16(Session["intCCYearId"]), mth1, mth2, 1, 1, amt, intEditMode);
            cor.IntAccNo = accNo;
            cor.IntYearID = yr2;
            cor.IntMonthID = mth2;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = -dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = chalId;
            cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
            cor.FlgType = 2;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = 1; //Edit Chal Date
            cor.IntChalanType = 4;
            cor.IntTblTp = 1;
            cord.CreateCorrEntryCalcTblTp(cor);
        }

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }  
    public void ShowDBPlus()
    {
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();
        Session["flgPageBack"] =6;
        //DataTable dtWithdocDb = gblobj.SetInitialRow(gdvDPWith);
        //ViewState["Withdoc"] = dtWithdocDb;

        DataSet dsdbplus = new DataSet();
        ArrayList arr = new ArrayList();
        SetGridDefault(gdvDPWith);
        fillGridcombos(gdvDPWith);  
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(3);
        dsdbplus = PDEAgDao.FillDBPlusPDE(arr);
        if (dsdbplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsdbplus.Tables[0].Rows.Count.ToString();
            gdvDPWith .DataSource = dsdbplus;
            gdvDPWith.DataBind();
            fillGridcombos(gdvDPWith);       
            for (int i = 0; i < dsdbplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWith.Rows[i];

                TextBox txtTeDPAss = (TextBox)gdv.FindControl("txtTeDP");
                txtTeDPAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[0].ToString();

                DropDownList ddldrawn = (DropDownList)gdv.FindControl("ddldrawn");
                ddldrawn.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[2].ToString();


                TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
                txtBillNoDBPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
                txtBilldateDBplusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
                txtAmtDbPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[5].ToString();

                DropDownList ddlTreasDBplusAss = (DropDownList)gdv.FindControl("ddlTreasDBplus");
                ddlTreasDBplusAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[1].ToString();


                //TextBox txtReasonDBPlusAss = (TextBox)gdv.FindControl("txtReasonDBPlus");
                //txtReasonDBPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[7].ToString();


                Label lblintIdAss = (Label)gdv.FindControl("lblintId");
                lblintIdAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[10].ToString();

                //DropDownList ddlStatus = (DropDownList)gdv.FindControl("ddlStatus");
                //ddlStatus.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[8].ToString();

                CheckBox chlUnpostDPW = (CheckBox)gdv.FindControl("chlUnpostDPW");
                DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");

                if (Convert.ToInt16(dsdbplus.Tables[0].Rows[i].ItemArray[6]) == 1)
                {
                    chlUnpostDPW.Checked = false;
                    ddlreasonAss.SelectedValue = "0";
                    ddlreasonAss.Enabled = false;
                }
                else
                {
                    chlUnpostDPW.Checked = true;
                    //DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");
                    ddlreasonAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[7].ToString();
                    ddlreasonAss.Enabled = true;
                }
                if (Convert.ToInt16(dsdbplus.Tables[0].Rows[i].ItemArray[6]) == 2 && Convert.ToInt16(dsdbplus.Tables[0].Rows[i].ItemArray[7]) == 9)
                {
                    gdv.Cells[9].Enabled = false;
                }

                Label oldYear = (Label)gdv.FindControl("lblYearId");
                Label oldMnth = (Label)gdv.FindControl("lblMnth");
                oldYear.Text = dsdbplus.Tables[0].Rows[i].ItemArray[13].ToString();
                oldMnth.Text = dsdbplus.Tables[0].Rows[i].ItemArray[14].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
            if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
            {
                lblAmtWCP.Text = gdvDPWith.FooterRow.Cells[5].Text.ToString();
                //ArrayList ar = new ArrayList();
                //DataSet dsS = new DataSet();
                //ar.Add(Convert.ToInt16(Session["IntYearAG"]));
                //ar.Add(Convert.ToInt16(Session["IntMonthAG"]));
                //dsS = PDEAgDao.GetEmpWsTotal(ar);
                //if (dsS.Tables[0].Rows.Count > 0)
                //{
                //    lblAmtWCP.Text = dsS.Tables[0].Rows[0].ItemArray[2].ToString();
                //}
            }
            else
            {
                lblAmtWCP.Text = "0";
            }
        }
        else
        {
            lblAmtWCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
    }
    public void ShowBalanceTransDt()
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();
        //DataTable dtBTdoc = gblobj.SetInitialRow(gdvBlnsDP);
        //ViewState["BTDt"] = dtBTdoc;

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(6);

        ds = blDAO.FillBalancetransDtPDE(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntb.Text = ds.Tables[0].Rows.Count.ToString();
            gdvBlnsDP.DataSource = ds;
            gdvBlnsDP.DataBind();

            fillGridcombosBT(gdvBlnsDP);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvBlnsDP.Rows[i];
                TextBox txtTeNoAss = (TextBox)gdv.FindControl("txtTeNo");
                txtTeNoAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtFromACcAss = (TextBox)gdv.FindControl("txtFromACc");
                txtFromACcAss.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtfrmName = (TextBox)gdv.FindControl("txtfrmName");
                txtfrmName.Text = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                
                TextBox txtNameAss = (TextBox)gdv.FindControl("txtName");
                txtNameAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();


                TextBox txtAmountAss = (TextBox)gdv.FindControl("txtAmount");
                txtAmountAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();


                TextBox txtRemarksAss = (TextBox)gdv.FindControl("txtRemarks");
                txtRemarksAss.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();


                Label lblintIdAss = (Label)gdv.FindControl("lblintId");
                lblintIdAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

                Label lblAccNo = (Label)gdv.FindControl("lblAccNo");
                lblAccNo.Text = ds.Tables[0].Rows[i].ItemArray[13].ToString();

                Label oldAcc = (Label)gdv.FindControl("lbloldAcc");
                oldAcc.Text = ds.Tables[0].Rows[i].ItemArray[13].ToString();

                Label oldAmt = (Label)gdv.FindControl("lbloldAmt");
                oldAmt.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvBlnsDP, 6, "txtAmount", 1);
            if (Convert.ToDouble(gdvBlnsDP.FooterRow.Cells[6].Text) > 0)
            {
                lblAmtBTCP.Text = gdvBlnsDP.FooterRow.Cells[6].Text.ToString();
            }
            else
            {
                lblAmtBTCP.Text = "0";
            }
        }
        else
        {
            lblAmtBTCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvBlnsDP, 6, "txtAmount", 1);
    }
    protected void btnOkWithouDocsDb_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        if (Convert.ToDouble(gdvDPWithOut.FooterRow.Cells[4].Text) > 0)
        {
            for (int i = 0; i < gdvDPWithOut.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvDPWithOut.Rows[i];
                CheckBox chkCollect = (CheckBox)gdvrw.FindControl("chkCollect");
                if (chkCollect.Checked == true)
                {
                    if (MandatoryFlds(i) == true)
                    {                 
                        UpdateMissing(i, 2);
                        SaveBillAGCollect(i);     // AP_VoucherAG
                        gblobj.MsgBoxOk("Updated!", this);
                    }
                    else
                    {
                        gblobj.MsgBoxOk("Enter all details!!!", this);
                    }
                }
                else
                {
                    UpdateMissing(i, 1);
                    gblobj.MsgBoxOk("Saved!", this);
                }
            }
            ShowWithoutDocs();
            ShowDBPlus();
            lblAmtWOCP.Text = Convert.ToString(gdvDPWithOut.FooterRow.Cells[4].Text);
            lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        }
    }
    public void UpdateMissing(int i, int flgMissingPDE)
    {
        gblobj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        ms = new Missing();
        msDao = new MissingDAO();
        int cnt = 0;

        GridViewRow gdvrw = gdvDPWithOut.Rows[i];
        DataSet ds = new DataSet();
        ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
        TextBox txtChlnDateDPWOAss = (TextBox)gdvrw.FindControl("txtChlnDateDPWO");
        if (txtChlnDateDPWOAss.Text == "")
        {
            ms.DtmChalanBilllDt = "";
        }
        else
        {
            ms.DtmChalanBilllDt = txtChlnDateDPWOAss.Text.ToString();
            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
            mnthId = billDate.Month;
            //  yrId = billDate.Year;
            TextBox RelMnthAss = (TextBox)gdvrw.FindControl("RelMnth");
            RelMnthAss.Text = mnthId.ToString();
            ms.IntRelMonthId = Convert.ToInt32(RelMnthAss.Text);
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateDPWOAss.Text.ToString());
            yrId = genDAO.gFunFindYearIdFromDate(ardt);
            ms.IntRelYearId = yrId;
            TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            RelYearIdAss.Text = yrId.ToString();
        }
        TextBox txtAmtDPWOAss = (TextBox)gdvrw.FindControl("txtAmtDPWO");
        if (txtAmtDPWOAss.Text == "")
        {
            ms.FltAmtPDE = 0;
        }
        else
        {
            ms.FltAmtPDE = Convert.ToDecimal(txtAmtDPWOAss.Text);
        }
        ms.IntTrnType = 3;
        DropDownList ddlTreasuryDPWOAss = (DropDownList)gdvrw.FindControl("ddlTreasuryDPWO");
        if (ddlTreasuryDPWOAss.SelectedIndex > 0)
        {
            ms.IntTreaId = Convert.ToInt32(ddlTreasuryDPWOAss.SelectedValue);
        }
        else
        {
            ms.IntTreaId = 0;
        }
        ms.IntModeChg = 2;
        TextBox txtRelMnthWiseIdAss = (TextBox)gdvrw.FindControl("txtRelMnthWiseId");
        if (txtRelMnthWiseIdAss.Text == "")
        {
            ms.IntRelMonthWiseId = 0;
        }
        else
        {
            ms.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdAss.Text);
        }
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            ms.lBId = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            ms.lBId = 0;
        }
        TextBox txtteDPWOAss = (TextBox)gdvrw.FindControl("txtteDPWO");
        if (txtteDPWOAss.Text == "")
        {
            ms.ChvTEIdPDE = "";
        }
        else
        {
            ms.ChvTEIdPDE = txtteDPWOAss.Text.ToString();
        }
        ds = msDao.TERelMonthWiseUpd(ms);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            ms.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            TextBox txtRelIdAss = (TextBox)gdvrw.FindControl("txtRelMnthWiseId");
            txtRelIdAss.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            RelMnthID = ms.IntRelMonthWiseId;
        }
        SaveTEMissDebit(i, flgMissingPDE);
        //gblobj.MsgBoxOk("Saved successfully", this);
    }

    private void SaveTEMissDebit(int j, int flgMissingPDE)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        msDao = new MissingDAO();
        GridViewRow gdvrw = gdvDPWithOut.Rows[j];
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        if (lblintIdAss.Text == "")
        {
            ms.IntId = 0;
        }
        else
        {
            ms.IntId = Convert.ToInt32(lblintIdAss.Text);
        }
        TextBox txtteDPWOAss = (TextBox)gdvrw.FindControl("txtteDPWO");
        if (txtteDPWOAss.Text == "")
        {
            ms.ChvTEIdPDE = "";
        }
        else
        {
            ms.ChvTEIdPDE = txtteDPWOAss.Text.ToString();
        }
        TextBox txtAmtDPWOAss = (TextBox)gdvrw.FindControl("txtAmtDPWO");
        if (txtAmtDPWOAss.Text == "")
        {
            ms.FltAmtPDE = 0;
        }
        else
        {
            ms.FltAmtPDE = Convert.ToDecimal(txtAmtDPWOAss.Text);
        }
        TextBox txtRemDPWO = (TextBox)gdvrw.FindControl("txtRemDPWO");
        if (txtRemDPWO.Text == "")
        {
            ms.ChvRemarksPDE = "";
        }
        else
        {
            ms.ChvRemarksPDE = txtRemDPWO.Text.ToString();
        }
        ms.IntRelMonthWiseId = RelMnthID;
        ms.IntTrnType = 3;
        ms.FlgMissingPDE = flgMissingPDE;
        TextBox txtChlnDPWO = (TextBox)gdvrw.FindControl("txtChlnDPWO");
        if (txtChlnDPWO.Text == "")
        {
            ms.IntChalNo  = 0;
        }
        else
        {
            ms.IntChalNo = Convert.ToInt32(txtChlnDPWO.Text);
        }
        TextBox txtChlnDateDPWO = (TextBox)gdvrw.FindControl("txtChlnDateDPWO");
        if (txtChlnDateDPWO.Text == "")
        {
            ms.DtmChalanBilllDtPDE = "";
        }
        else
        {
            ms.DtmChalanBilllDtPDE = txtChlnDateDPWO.Text.ToString();
            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDtPDE.ToString());
            mnthId = billDate.Month;
            TextBox RelMnthAss = (TextBox)gdvrw.FindControl("RelMnth");
            RelMnthAss.Text = mnthId.ToString();
            ms.IntRelMonthId = Convert.ToInt32(RelMnthAss.Text);
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateDPWO.Text.ToString());
            yrId = genDAO.gFunFindYearIdFromDate(ardt);
            ms.IntRelYearId = yrId;
            TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            RelYearIdAss.Text = yrId.ToString();
        }
        DropDownList ddlTreasuryDPWO = (DropDownList)gdvrw.FindControl("ddlTreasuryDPWO");
        if (ddlTreasuryDPWO.SelectedIndex > 0)
        {
            ms.IntTreaId = Convert.ToInt32(ddlTreasuryDPWO.SelectedValue);
        }
        else
        {
            ms.IntTreaId = 0;
        }
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            ms.lBId = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            ms.lBId = 0;
        }
        ms.IntRelMonthId = mnthId;
        ms.IntRelYearId = yrId; 
        DataSet ds = new DataSet();
        ds = msDao.CreateTEPlusMissingPDE(ms);
    }
    private Boolean MandatoryFlds(int i)
    {
        Boolean flg;
        flg = true;
        GridViewRow gvr = gdvDPWithOut.Rows[i];
        TextBox txtChlnDateDPWOAss = (TextBox)gvr.FindControl("txtChlnDateDPWO");
        TextBox txtAmtDPWOAss = (TextBox)gvr.FindControl("txtAmtDPWO");
        DropDownList ddlTreasuryDPWOAss = (DropDownList)gvr.FindControl("ddlTreasuryDPWO");
        TextBox txtChlnDPWOAss = (TextBox)gvr.FindControl("txtChlnDPWO");
        TextBox txtteDPWO = (TextBox)gvr.FindControl("txtteDPWO");

        //if (txtChlnDateDPWOAss.Text == null || txtChlnDateDPWOAss.Text == "" || txtChlnDateDPWOAss.Text == "01/01/1900" || Convert.ToInt32(txtChlnDPWOAss.Text) >= 9999)
        if (txtChlnDateDPWOAss.Text == null || txtChlnDateDPWOAss.Text == "" || txtChlnDPWOAss.Text == null || txtChlnDPWOAss.Text == "" || Convert.ToInt32(txtChlnDPWOAss.Text) == 0 || txtteDPWO.Text == null || txtteDPWO.Text == "")
        {
            flg = false;
        }
        else if (txtAmtDPWOAss.Text == null || txtAmtDPWOAss.Text == "")
        {
            flg = false;
        }
        else if (Convert.ToInt32(ddlTreasuryDPWOAss.SelectedValue) == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void SaveBillAGCollect(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        withAG = new WithdrawalPDEAG();
        PDEAgDao = new WithdrawalPDEAGDAO();
        GridViewRow gdvrw = gdvDPWithOut.Rows[j];
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        if (lblintIdAss.Text == "")
        {
            withAG.IntVoucherID = 0;
        }
        else
        {
            withAG.IntVoucherID = Convert.ToInt32(lblintIdAss.Text);
        }
        withAG.IntRelMonthWsID = RelMnthID;
        TextBox txtteDPWO = (TextBox)gdvrw.FindControl("txtteDPWO");
        if (txtteDPWO.Text == "")
        {
            withAG.ChvTENo = "";
        }
        else
        {
            withAG.ChvTENo = txtteDPWO.Text.ToString();
        }
        TextBox txtChlnDPWO = (TextBox)gdvrw.FindControl("txtChlnDPWO");
        if (txtChlnDPWO.Text == null || txtChlnDPWO.Text == "")
        {
            withAG.IntVoucherNo = 0;
        }
        else
        {
            withAG.IntVoucherNo = Convert.ToInt16(txtChlnDPWO.Text);
        }

        DropDownList ddlTreasuryDPWO = (DropDownList)gdvrw.FindControl("ddlTreasuryDPWO");
        if (ddlTreasuryDPWO.SelectedIndex > 0)
        {
            withAG.IntDTreaID = Convert.ToInt32(ddlTreasuryDPWO.SelectedValue);
        }
        else
        {
            withAG.IntDTreaID = 0;
        }
        TextBox txtChlnDateDPWO = (TextBox)gdvrw.FindControl("txtChlnDateDPWO");
        if (txtChlnDateDPWO.Text == "")
        {
            withAG.DtmVoucherDt = "";
        }
        else
        {
            withAG.DtmVoucherDt = txtChlnDateDPWO.Text.ToString();
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateDPWO.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
            TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            RelYearIdAss.Text = yrId.ToString();
            withAG.IntYearID = yrId;
        }
        TextBox txtAmtDPWO = (TextBox)gdvrw.FindControl("txtAmtDPWO");
        if (txtAmtDPWO.Text == "")
        {
            withAG.FltAmount = 0;
        }
        else
        {
            withAG.FltAmount = Convert.ToDecimal(txtAmtDPWO.Text);
        }
        withAG.IntModeOfChgId = 3;
        withAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        withAG.FlgUnPosted = 1;
        withAG.IntReasonID = 0;
        withAG.IntDrawnBy = 0;

        TextBox txtRelMnthWiseId = (TextBox)gdvrw.FindControl("txtRelMnthWiseId");
        withAG.IntRelMonthWsID = Convert.ToInt32(txtRelMnthWiseId.Text);
        DataSet ds = new DataSet();
        ds = PDEAgDao.SaveVoucherAG(withAG);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Label lblintId = (Label)gdvrw.FindControl("lblintId");
            lblintId.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        //gblobj.MsgBoxOk("Saved successfully", this);
    }
    public void ShowWithoutDocsOld()
    {
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();
        DataTable dtWithoutdoc = gblobj.SetInitialRow(gdvDPWithOut);
        ViewState["WithoutdocDt"] = dtWithoutdoc;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(3);
        ds = msDao.FillCrWithoutDocsPDE(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvDPWithOut.DataSource = ds;
            gdvDPWithOut.DataBind();

            dtWithoutdoc = gblobj.SetGridTableRows(gdvDPWithOut, ds.Tables[0].Rows.Count);
            ViewState["WithoutdocDt"] = dtWithoutdoc;

            fillGridcomboswithoutDocs(gdvDPWithOut);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWithOut.Rows[i];
                TextBox txtteDPWOAss = (TextBox)gdv.FindControl("txtteDPWO");
                txtteDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtChlnDPWOAss = (TextBox)gdv.FindControl("txtChlnDPWO");
                txtChlnDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtChlnDateDPWOAss = (TextBox)gdv.FindControl("txtChlnDateDPWO");
                txtChlnDateDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAmtDPWOAss = (TextBox)gdv.FindControl("txtAmtDPWO");
                txtAmtDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                DropDownList ddlTreasuryDPWOAss = (DropDownList)gdv.FindControl("ddlTreasuryDPWO");
                ddlTreasuryDPWOAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                ddlLBAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[10].ToString();

                TextBox txtRemDPWOAss = (TextBox)gdv.FindControl("txtRemDPWO");
                txtRemDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblintId = (Label)gdv.FindControl("lblintId");
                lblintId.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[6]);

                TextBox txtRelMnthWiseId = (TextBox)gdv.FindControl("txtRelMnthWiseId");
                txtRelMnthWiseId.Text = ds.Tables[0].Rows[i].ItemArray[7].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
            if (Convert.ToDouble(gdvDPWithOut.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWOCP.Text = gdvDPWithOut.FooterRow.Cells[4].Text.ToString();
            }
            else
            {
                lblAmtWOCP.Text = "0";
            }
        }

        else
        {
            fillGridcomboswithoutDocs(gdvDPWithOut);
            lblAmtWOCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
    }
    public void ShowWithoutDocs()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();
        DataTable dtWithoutdoc = gblobj.SetInitialRow(gdvDPWithOut);
        ViewState["WithoutdocDt"] = dtWithoutdoc;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(3);
        ds = msDao.FillCrWithoutDocsPDE(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntWO.Text = ds.Tables[0].Rows.Count.ToString();
            gdvDPWithOut.DataSource = ds;
            gdvDPWithOut.DataBind();

            dtWithoutdoc = gblobj.SetGridTableRows(gdvDPWithOut, ds.Tables[0].Rows.Count);
            ViewState["WithoutdocDt"] = dtWithoutdoc;

            fillGridcomboswithoutDocs(gdvDPWithOut);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWithOut.Rows[i];
                TextBox txtteDPWOAss = (TextBox)gdv.FindControl("txtteDPWO");
                txtteDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                TextBox txtChlnDPWOAss = (TextBox)gdv.FindControl("txtChlnDPWO");
                txtChlnDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                TextBox txtChlnDateDPWOAss = (TextBox)gdv.FindControl("txtChlnDateDPWO");
                txtChlnDateDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                TextBox txtAmtDPWOAss = (TextBox)gdv.FindControl("txtAmtDPWO");
                txtAmtDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                DropDownList ddlTreasuryDPWOAss = (DropDownList)gdv.FindControl("ddlTreasuryDPWO");
                ddlTreasuryDPWOAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                DataSet dslb = new DataSet();
                ArrayList arDt = new ArrayList();
                arDt.Add(Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[4]));
                dslb = gendao.GetLBFromTreasury(arDt);
                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                gblobj.FillCombo(ddlLBAss, dslb, 1);
                ddlLBAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                TextBox txtRemDPWOAss = (TextBox)gdv.FindControl("txtRemDPWO");
                txtRemDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                Label lblintId = (Label)gdv.FindControl("lblintId");
                lblintId.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[6]);
                TextBox txtRelMnthWiseId = (TextBox)gdv.FindControl("txtRelMnthWiseId");
                txtRelMnthWiseId.Text = ds.Tables[0].Rows[i].ItemArray[7].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
            if (Convert.ToDouble(gdvDPWithOut.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWOCP.Text = gdvDPWithOut.FooterRow.Cells[4].Text.ToString();
            }
            else
            {
                lblAmtWOCP.Text = "0";
            }
        }

        else
        {
            fillGridcomboswithoutDocs(gdvDPWithOut);
            lblAmtWOCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
    }
    public void SaveBalanceDt()
    {
        ShowBalanceTransDt();
    }
    protected void btnbalance_Click(object sender, EventArgs e)
    {
        SaveBalanceDtPDE();
        ShowBalanceTransDt();
    }
    public void SaveBalanceDtPDE()
    {
        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();
        for (int i = 0; i < gdvBlnsDP.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvBlnsDP.Rows[i];
            DataSet ds = new DataSet();
            blPDE.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
            blPDE.IntRelYearId = Convert.ToInt16(Session["IntYearAG"]);
            blPDE.IntRelMonthId = Convert.ToInt16(Session["IntMonthAG"]);
            TextBox txtAmountAss = (TextBox)gdvrw.FindControl("txtAmount");
            if (txtAmountAss.Text == "")
            {
                blPDE.FltAmtPDE = 0;
            }
            else
            {
                blPDE.FltAmtPDE = Convert.ToDecimal(txtAmountAss.Text);
            }
            blPDE.IntTrnType = 6;
            blPDE.IntTreasId = 0;
            blPDE.IntModeChgPDE = 2;
            TextBox txtRelMnthIDbalDbAss = (TextBox)gdvrw.FindControl("txtRelMnthIDbalDb");
            if (txtRelMnthIDbalDbAss.Text == "")
            {
                blPDE.IntRelMonthWiseId = 0;
            }
            else
            {
                blPDE.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthIDbalDbAss.Text.ToString());
            }
            blPDE.IntLBId = 0;

            TextBox txtTeNoAss = (TextBox)gdvrw.FindControl("txtTeNo");
            if (txtTeNoAss.Text == "")
            {
                blPDE.ChvTEIdPDE = "";
            }
            else
            {
                blPDE.ChvTEIdPDE = txtTeNoAss.Text;
            }
            ds = blPDEDao.CreateBalanceTransRel(blPDE);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                blPDE.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

                TextBox txtRelMnthIDbalDbk = (TextBox)gdvrw.FindControl("txtRelMnthIDbalDb");
                txtRelMnthIDbalDbk.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            }
            lSubSaveBalTransferDb(i);
        }
    }
    public void lSubSaveBalTransferDb(int j)
    {
        gblobj = new clsGlobalMethods();
        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();
        GridViewRow gdvrw = gdvBlnsDP.Rows[j];
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        if (lblintIdAss.Text == "")
        {
            blPDE.IntIDPDE = 0;
        }
        else
        {
            blPDE.IntIDPDE = Convert.ToInt32(lblintIdAss.Text);
        }
        TextBox txtRelMnthIDbalDbAs = (TextBox)gdvrw.FindControl("txtRelMnthIDbalDb");
        if (txtRelMnthIDbalDbAs.Text == "")
        {
            blPDE.IntRelMonthWiseId = 0;
        }
        else
        {
            blPDE.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthIDbalDbAs.Text);
        }
        TextBox txtTeNoas = (TextBox)gdvrw.FindControl("txtTeNo");
        if (txtTeNoas.Text == "")
        {
            blPDE.ChvTEIdPDE = "";
        }
        else
        {
            blPDE.ChvTEIdPDE = txtTeNoas.Text.ToString();
        }

        TextBox txtFrmAcCPBTAss = (TextBox)gdvrw.FindControl("txtFromACc");
        if (txtFrmAcCPBTAss.Text == "")
        {
            blPDE.ChvFrmAccNoPDE = "";
        }
        else
        {
            blPDE.ChvFrmAccNoPDE = txtFrmAcCPBTAss.Text.ToString();
        }
        blPDE.IntToAccNoPDE = 0;
        Label lblAccNo = (Label)gdvrw.FindControl("lblAccNo");
        if (lblAccNo.Text == "")
        {
            blPDE.IntFrmAccNoPDE = 0;
        }
        else
        {
            blPDE.IntFrmAccNoPDE = Convert.ToInt32(lblAccNo.Text);
        }
        TextBox txtName = (TextBox)gdvrw.FindControl("txtName");
        if (txtName.Text == "")
        {
            blPDE.ChvToAccNoPDE = "";
        }
        else
        {
            blPDE.ChvToAccNoPDE = txtName.Text.ToString();
        }
        ////////////////Changed//////////////////////

        TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmount");
        if (txtAmtCPBT.Text == "")
        {
            blPDE.FltAmtPDE = 0;
        }
        else
        {
            blPDE.FltAmtPDE = Convert.ToDecimal(txtAmtCPBT.Text);
        }
        TextBox txtRmkCPBT = (TextBox)gdvrw.FindControl("txtRemarks");
        if (txtRmkCPBT.Text == "")
        {
            blPDE.ChvRemarksPDE = "";
        }
        else
        {
            blPDE.ChvRemarksPDE = txtRmkCPBT.Text.ToString();
        }
        blPDE.IntModeChgPDE = 2;
        blPDE.IntFlag = 6;

        //////////////saveCorrectionEntryBT//////////////////////
        Label lbloldAcc = (Label)gdvrw.FindControl("lbloldAcc");
        Label lbloldAmt = (Label)gdvrw.FindControl("lbloldAmt");

        double amtO = Convert.ToDouble(lbloldAmt.Text);
        double amtN = Convert.ToDouble(txtAmtCPBT.Text);
        int accO = Convert.ToInt32(lbloldAcc.Text);
        int accN = Convert.ToInt32(lblAccNo.Text);
        if (lFunEditMode(Convert.ToInt32(lblintIdAss.Text), Convert.ToDouble(txtAmtCPBT.Text), Convert.ToInt32(lblAccNo.Text)) == false)
        {
            saveCorrectionEntryBT(Convert.ToInt32(lblintIdAss.Text), amtO, amtN, accO, accN, 0);
        }
        //////////////saveCorrectionEntryBT//////////////////////

        DataSet ds = new DataSet();
        ds = blPDEDao.CreateBalanceTransCr(blPDE);
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    private Boolean lFunEditMode(Int32 intBtID, double amt, Int32 acc)
    {
        blPDEDao = new BalanceTransPDEDao();
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intBtID);
        ar.Add(amt);
        ar.Add(acc);
        ds = blPDEDao.getEditStatusDt(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    //public void ShowBalanceTransDt()
    //{
    //    //DataTable dtBTdoc = gblobj.SetInitialRow(gdvBlnsDP);
    //    //ViewState["BTDt"] = dtBTdoc;

    //    DataSet ds = new DataSet();
    //    ArrayList arr = new ArrayList();

    //    arr.Add(Convert.ToInt16(Session["IntYearAG"]));
    //    arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
    //    arr.Add(6);

    //    ds = blDAO.FillBalancetransDtPDE(arr);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        gdvBlnsDP.DataSource = ds;
    //        gdvBlnsDP.DataBind();

    //        fillGridcombosBT(gdvBlnsDP);

    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            GridViewRow gdv = gdvBlnsDP.Rows[i];
    //            TextBox txtTeNoAss = (TextBox)gdv.FindControl("txtTeNo");
    //            txtTeNoAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

    //            TextBox txtFromACcAss = (TextBox)gdv.FindControl("txtFromACc");
    //            txtFromACcAss.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();

    //            TextBox txtNameAss = (TextBox)gdv.FindControl("txtName");
    //            txtNameAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();


    //            TextBox txtAmountAss = (TextBox)gdv.FindControl("txtAmount");
    //            txtAmountAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();


    //            TextBox txtRemarksAss = (TextBox)gdv.FindControl("txtRemarks");
    //            txtRemarksAss.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();


    //            TextBox lblintIdAss = (TextBox)gdv.FindControl("lblintId");
    //            lblintIdAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

    //            DropDownList ddlStatus = (DropDownList)gdv.FindControl("ddlStatus");
    //            ddlStatus.SelectedValue = ds.Tables[0].Rows[i].ItemArray[11].ToString();
    //        }
    //    }

    //}
    protected void Btnwithout_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (ViewState["Withoutdoc"] != null)
        {
            DataTable dt = (DataTable)ViewState["Withoutdoc"];
            int count = gdvDPWithOut.Rows.Count;
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtteDPWO");
            arrIN.Add("txtChlnDPWO");
            arrIN.Add("txtChlnDateDPWO");
            arrIN.Add("txtAmtCPWO");
            arrIN.Add("ddlTreasuryDPWO");
            arrIN.Add("ddlLB");
            arrIN.Add("txtRemDPWO");
            //  arrIN.Add("ddlStusCPW");
            arrIN.Add("lblintId");
            arrIN.Add("Btnwithout");
            arrIN.Add("RelMnth");
            arrIN.Add(" RelYearId");
            dt = gblobj.AddNewRowToGrid(dt, gdvDPWithOut, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList drpnewtreas = (DropDownList)gdvDPWithOut.Rows[count].FindControl("ddlTreasuryCPWO");

            DropDownList drpnewLB = (DropDownList)gdvDPWithOut.Rows[count].FindControl("ddlLB");
            gblobj.setFocus(drpnewtreas, this);
            fillGridcomboswithoutDocs(gdvDPWithOut);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drptr = (DropDownList)gdvDPWithOut.Rows[i].FindControl("ddlTreasuryCPWO");
                drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();

                DropDownList drpLB = (DropDownList)gdvDPWithOut.Rows[i].FindControl("ddlLB");
                drpLB.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
            }
        }

    }
    //protected void BtnwithDt_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["Withdoc"] != null)
    //    {
    //        DataTable dt = (DataTable)ViewState["Withdoc"];
    //        int count = gdvDPWith.Rows.Count;
           
    //        ArrayList arrIN = new ArrayList();
    //        arrIN.Add("txtTeDP");
    //        arrIN.Add("txtBillNoDBPlus");
    //        arrIN.Add("txtBilldateDBplus");
    //        arrIN.Add("txtAmtDbPlus");
    //        arrIN.Add("ddlTreasDBplus");
    //        arrIN.Add("chkUnpostDPW");
    //        arrIN.Add("txtReasonDBPlus");
    //        arrIN.Add("lblintId");
    //        arrIN.Add("BtnwithDt");
    //      //  arrIN.Add("ddlStusCPW");
    //       // arrIN.Add("Button1");
    //        dt = gblobj.AddNewRowToGrid(dt, gdvDPWith , arrIN);
    //        ViewState["SpecTable"] = dt;
    //        DropDownList drpnewtreas = (DropDownList)gdvDPWith.Rows[count].FindControl("ddlTreasDBplus");
            
    //        gblobj.setFocus(drpnewtreas, this);
    //        //}
    //        fillGridcombos(gdvDPWith);
    //        for (int i = 0; i < dt.Rows.Count - 1; i++)
    //        {
    //            DropDownList drptr = (DropDownList)gdvDPWith.Rows[i].FindControl("ddlTreasDBplus");
    //            drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();
              
    //        }
    //    }
    //}
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlLB_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void BtnBTDt_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (ViewState["BTDt"] != null)
        {
            DataTable dt = (DataTable)ViewState["BTDt"];
            int count = gdvBlnsDP.Rows.Count;
           
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtTeNo");
            arrIN.Add("txtFromACc");
            arrIN.Add("txtName");
            arrIN.Add("txtAmount");
            arrIN.Add("txtRemarks");
            arrIN.Add("lblintId");
            arrIN.Add("BtnBTDt");

            dt = gblobj.AddNewRowToGrid(dt, gdvBlnsDP, arrIN);
            ViewState["BTBTDt"] = dt;
          
        }
    }
    private void FillHeadLbls()
    {
        gendao = new GeneralDAO();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearAG"]));
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["IntMonthAG"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        lblTot.Text = Session["dblAmtDtPlus"].ToString();
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    protected void txtFromACc_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();
        int  intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        DataSet dsName = new DataSet();
        GridViewRow gdr = gdvBlnsDP.Rows[intCurRw];

        TextBox txtFromACcAss = (TextBox)gdr.FindControl("txtFromACc");
        Label lblAccNoAss = (Label)gdr.FindControl("lblAccNo");
        TextBox txtfrmName = (TextBox)gdr.FindControl("txtfrmName");

        if (gblobj.CheckNumericOnly(txtFromACcAss.Text.ToString(), this) == true)
        {
            emp.NumEmpID = Convert.ToDouble(txtFromACcAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                txtFromACcAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                txtfrmName.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                lblAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            else
            {
                txtFromACcAss.Text = "";
                txtfrmName.Text = "";
                lblAccNoAss.Text = "";
            }
        }
    }
    //protected void btnBack_Click(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    }
    protected void ddlTreasuryDPWO_SelectedIndexChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        DataSet dsLb = new DataSet();
        ArrayList arrDt = new ArrayList();

        int rowIndex = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvDPWithOut.Rows[rowIndex];

        DropDownList ddlTreasuryDPWO = (DropDownList)gdvr.FindControl("ddlTreasuryDPWO");
        DropDownList ddlLB = (DropDownList)gdvr.FindControl("ddlLB");

        if (Convert.ToInt16(ddlTreasuryDPWO.SelectedValue) > 0)
        {
            arrDt.Add(Convert.ToInt16(ddlTreasuryDPWO.SelectedValue));
        }
        else
        {
            arrDt.Add(1);
        }

        dsLb = gendao.GetLBFromTreasury(arrDt);
        gblobj.FillCombo(ddlLB, dsLb, 1);


        //for (int i = 0; i < gdvDPWithOut.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvDPWithOut.Rows[i]; 
        //    DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");
        //    DropDownList ddlTreCPWOAss = (DropDownList)gvr.FindControl("ddlTreasuryDPWO");

        //    if (Convert.ToInt16(ddlTreCPWOAss.SelectedValue) > 0)
        //    {
        //        Session["intTreas"] = Convert.ToInt16(ddlTreCPWOAss.SelectedValue);
        //    }
        //    else
        //    {
        //        Session["intTreas"] = 0;
        //    }


        //    ArrayList art = new ArrayList();
        //    art.Add(Convert.ToInt16(Session["intTreas"]));
        //    DataSet dst = new DataSet();
        //    dst = gendao.GetDistIdfromTreasId(art);
        //    if (dst.Tables[0].Rows.Count > 0)
        //    {
        //        Session["intDist"] = dst.Tables[0].Rows[0].ItemArray[0].ToString();
        //    }
        //    ArrayList ar = new ArrayList();
        //    ar.Add(Convert.ToInt16(Session["intDist"]));
        //    ar.Add(5);
        //    DataSet dslb = new DataSet();
        //    dslb = gendao.GetLB(ar);
        //    gblobj.FillCombo(ddlLBAss, dslb, 1);
        //}
    }
    private void SetArrColsWO(ArrayList arCols)
    {
        arCols.Add("txtteDPWO");
        arCols.Add("txtChlnDPWO");
        arCols.Add("txtChlnDateDPWO");
        arCols.Add("txtAmtDPWO");
        arCols.Add("ddlTreasuryDPWO");
        arCols.Add("ddlLB");
        arCols.Add("txtRemDPWO");
        arCols.Add("chkCollect");
        //arCols.Add("ddlStatus");
        arCols.Add("lblintId");
        arCols.Add("RelMnth");
        arCols.Add("RelYearId");
        arCols.Add("txtRelMnthWiseId");
    }
    private void SetArrColsBT(ArrayList arCols)
    {
        arCols.Add("txtTeNo");
        arCols.Add("txtFromACc");
        arCols.Add("txtfrmName");
        arCols.Add("txtName");
        arCols.Add("txtToName");
        arCols.Add("txtAmount");
        arCols.Add("txtRemarks");
        arCols.Add("lblintId");
        arCols.Add("txtRelMnthIDbalDb");
        arCols.Add("lblAccNo");
        arCols.Add("lbloldAcc");
        arCols.Add("lbloldAmt");
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeDP");
        arCols.Add("txtBilldateDBplus");
        arCols.Add("ddldrawn");
        arCols.Add("txtAmtDbPlus");
        arCols.Add("ddlTreasDBplus");
        arCols.Add("chlUnpostDPW");
        arCols.Add("ddlreason");
        arCols.Add("txtBillNoWD");
        arCols.Add("lblintId");

        arCols.Add("lblMnth");
        arCols.Add("lblYearId");
    }

    protected void txtChlnDateDPWO_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDPWithOut.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtChlnDateDPWO");

        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();
        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtDt, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(Session["IntYearAG"]));
                if (gblobj.CheckChalanDateAg(txtDt, dt) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
                else
                {
                    ArrayList ar = new ArrayList();
                    ar.Add(txtDt.Text.ToString());
                    Session["IntYearSearchChal"] = genDAO.FindYearIdFromDate(ar);
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
        }
    }
    protected void txtBilldateDBplus_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ardt = new ArrayList();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDPWith.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtBilldateDBplus");

        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();

        DateTime dtm = new DateTime();
        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");

        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtDt, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(Session["IntYearAG"]));
                if (gblobj.CheckChalanDateAg(txtDt, dt) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
                else
                {
                    if (Convert.ToInt16(oldYear.Text) > 0)
                    {
                        dtm = Convert.ToDateTime(txtDt.Text);
                        ardt.Add(txtDt.Text);
                        int yrnw = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
                        int mthnw = dtm.Month;
                        int dynw = dtm.Day;
                        if (yrnw < Convert.ToInt16(oldYear.Text))
                        {
                            lblEditId.Text = "1";
                        }
                        else if (yrnw > Convert.ToInt16(oldYear.Text))
                        {
                            lblEditId.Text = "2";
                        }
                        else
                        {
                            if (genDAO.getMonthIdCalYear(mthnw) < genDAO.getMonthIdCalYear(Convert.ToInt16(oldMnth.Text)))
                            {
                                lblEditId.Text = "1";
                            }
                            else if (genDAO.getMonthIdCalYear(mthnw) > genDAO.getMonthIdCalYear(Convert.ToInt16(oldMnth.Text)))
                            {
                                lblEditId.Text = "2";
                            }
                        }
                    }
                    else
                    {
                        lblEditId.Text = "0";
                    }
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtDt.Text = "";
        }
    }
    protected void txtAmtDPWO_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
        if (Convert.ToDouble(gdvDPWithOut.FooterRow.Cells[4].Text) > 0)
        {
            lblAmtWOCP.Text = gdvDPWithOut.FooterRow.Cells[4].Text.ToString();
        }
        else
        {
            lblAmtWOCP.Text = "0";
        }
        FillHeadLbls();
    }
    protected void txtAmtDbPlus_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
        if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
        {
            lblAmtWCP.Text = gdvDPWith.FooterRow.Cells[5].Text.ToString();
           
        }
        else
        {
            lblAmtWCP.Text = "0";
        }
        FillHeadLbls();

    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvBlnsDP, 6, "txtAmount", 1);
        if (Convert.ToDouble(gdvBlnsDP.FooterRow.Cells[6].Text) > 0)
        {
            lblAmtBTCP.Text = gdvBlnsDP.FooterRow.Cells[6].Text.ToString();

        }
        else
        {
            lblAmtBTCP.Text = "0";
        }
        FillHeadLbls();
    }
    protected void chlUnpostDPW_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvDPWith.Rows[index];

        CheckBox chlUnpostDPW = (CheckBox)gdvr.FindControl("chlUnpostDPW");
        DropDownList ddlReason = (DropDownList)gdvr.FindControl("ddlreason");
        if (chlUnpostDPW.Checked == true)
        {
            ddlReason.Enabled = true;
        }
        else
        {
            ddlReason.Enabled = false;
            ddlReason.SelectedValue = "0";
        }
    }
    protected void txtCntb_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();
        if (txtCntb.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrColsBT(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsdbplusBT = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(6);

           // dsdbplusBT = PDEAgDao.FillDBPlusPDEAddrw(arr);
            dsdbplusBT = blDAO.FillBalancetransDtPDEForCnt(arr);
            //Ds to fill Grid//////////

            gblobj.SetGridRowsWithData(dsdbplusBT, Convert.ToInt16(txtCntb.Text), gdvBlnsDP, arDdl, arCols, arDdlDs);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }
    protected void txtCntWO_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();
        teDAO = new TEDAO();
        if (txtCntWO.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlTreasuryDPWO");
            arDdl.Add("ddlLB");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();
            DataSet dstreas = new DataSet();
            //dstreas = teDAO.GetTreasury();
            dstreas = gendao.GetDisTreasuryWithOutDistId();
            
            arDdlDs.Add(dstreas);
            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDs.Add(dslb);
            ////Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrColsWO(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsdbplusBT = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(3);

            // dsdbplusBT = PDEAgDao.FillDBPlusPDEAddrw(arr);
            dsdbplusBT = msDao.FillCrWithoutDocsPDEForCnt(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("intVoucherID");
            arHp.Add("intVoucherNo");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            gblobj.SetGridRowsWithDataNew(dsdbplusBT, Convert.ToInt16(txtCntWO.Text), gdvDPWithOut, arDdl, arCols, arDdlDs, arHp);
            gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }
    protected void btndeletedTplusMissing_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;

        GridViewRow gdvrw = gdvDPWithOut.Rows[rowIndex];
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        ArrayList arrin = new ArrayList();
        if (lblintIdAss.Text != "")
        {
            arrin.Add(Convert.ToInt32(lblintIdAss.Text));
            //arrin.Add(2);
            try
            {
                msDao.DeleteDebitWithoutDocsPDE(arrin);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }

            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowWithoutDocs();
        FillHeadLbls();
    }
    protected void btnDeleteWth_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblintId = (Label)gdvDPWith.Rows[rowIndex].FindControl("lblintId");
        
        CorrectionEntryForDel(Convert.ToInt32(lblintId.Text)); //Corr Entry

        ArrayList arrin = new ArrayList();
        arrin.Add(Convert.ToInt32(lblintId.Text));
        PDEAgDao.DeleteVoucher(arrin);
        PDEAgDao.delWithPDE(arrin);
        gblobj.MsgBoxOk("deleted!!!", this);
        FillHeadLbls();
        ShowDBPlus();
    }
    private void CorrectionEntryForDel(float numChalId)
    {
        PDEAgDao = new WithdrawalPDEAGDAO();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        float NumID;
        double fltAmtBfr;
        double fltAmtAfr;
        int intYrId;
        int intMth;

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ds = PDEAgDao.withPDEForCorrectionEntry(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                amt = fltAmtBfr - fltAmtAfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                intYrId = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[3].ToString());
                intMth = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[4].ToString());

                SaveCorrectionEntry(Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]), numChalId, intYrId, intMth, 1, Convert.ToDouble(amt), NumID, 9, fltAmtBfr, fltAmtAfr, 4);
                //schedPdeDao.DelTR104PDEMode(ar);
            }
        }
    }
    private void SaveCorrectionEntry(int intAccNo, float chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
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
        cor.IntChalanType = ChalType;
        cor.IntTblTp = 1;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
}
