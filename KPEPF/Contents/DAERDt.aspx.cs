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

public partial class Contents_DAERDt : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    Bill bil;
    BillDao bilDao;
    WithdrawalPDEAGDAO PDEAgDao;
    CorrectionEntry cor;
    CorrectionEntryDao cord;
    WithdrwalDAO wDao;
    ChalanDAO chDao;  //Build April2022
    //AOApproval aoapp = new AOApproval();
    //AOApprovalDAO aoappDAO = new AOApprovalDAO();
    //Missing ms = new Missing();
    //MissingDAO msDao = new MissingDAO();
    //TEDAO teDAO = new TEDAO();
    //TE dbplus = new TE();    
    //balancetrans bl = new balancetrans();
    //BalancetransDAO blDAO = new BalancetransDAO();
    //WithdrawalPDEAG withAG = new WithdrawalPDEAG();  
    //BalanTrPDE blPDE = new BalanTrPDE();
    //BalanceTransPDEDao blPDEDao = new BalanceTransPDEDao();

    public int Trntype = 0;
    public int mnthId;
    public int yrId;
    public int RelMnthID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Convert.ToDouble(Session["intVoucherIDEdit"]) > 0)
            {
                ShowDBPlus();
                FillHeadLbls();
                SetCtrls();
                //ShowWithoutDocs();
                if (Convert.ToInt16(Session["flgOAODt"]) == 1)
                {
                    lblTot.Text =  Session["dblAmtDAERDt"].ToString();
                }
                else
                {
                    lblTot.Text =  Session["dblAmtOAODt"].ToString();
                }
                lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            btnSaveDBPlus.Enabled = true;
            txtCnt.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            btnSaveDBPlus.Enabled = false;
            txtCnt.Enabled = false;
        }
    }
    private void SetCtrlsEnable()
    {       
        SetWithDocsGridEnable();       
    }
    private void SetCtrlsDisable()
    {       
        SetWithDocsGridDisable();      
    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = false;
            txtTeDPAss.Enabled = true;

            TextBox txtBilldateDBplusAss = (TextBox)gdvrow.FindControl("txtBilldateDBplus");
            txtBilldateDBplusAss.ReadOnly = false;
            txtBilldateDBplusAss.Enabled = true;


            TextBox txtBillNoWDAss = (TextBox)gdvrow.FindControl("txtBillNoWD");
            txtBillNoWDAss.ReadOnly = false;
            txtBillNoWDAss.Enabled = true;


            DropDownList ddldrawnAss = (DropDownList)gdvrow.FindControl("ddldrawn");
            ddldrawnAss.Enabled = true;


            TextBox txtAmtDbPlusAss = (TextBox)gdvrow.FindControl("txtAmtDbPlus");
            txtAmtDbPlusAss.ReadOnly = false;
            txtAmtDbPlusAss.Enabled = true;

            DropDownList ddlTreasDBplusAss = (DropDownList)gdvrow.FindControl("ddlTreasDBplus");
            ddlTreasDBplusAss.Enabled = true;

            CheckBox chkUnpostDPWAss = (CheckBox)gdvrow.FindControl("chkUnpostDPW");
            chkUnpostDPWAss.Enabled = true;

            Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");

            lblintIdAss.Enabled = true;
            TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            txtRelMnthWiseIdWAss.ReadOnly = false;
            txtRelMnthWiseIdWAss.Enabled = true;


            //Label RelMnthAss = (Label)gdvrow.FindControl("lblMnth");
            //RelMnthAss.Enabled = true;

            //Label RelYearIdAss = (Label)gdvrow.FindControl("lblYearId");
            //RelYearIdAss.Enabled = true;

            ImageButton btndeletedDtlusAss = (ImageButton)gdvrow.FindControl("btndeletedDtlus");
            btndeletedDtlusAss.Enabled = true;

        }
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

            CheckBox chkUnpostDPWAss = (CheckBox)gdvrow.FindControl("chkUnpostDPW");
            chkUnpostDPWAss.Enabled = false;

            Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");

            lblintIdAss.Enabled = false;

            TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            txtRelMnthWiseIdWAss.ReadOnly = true;
            txtRelMnthWiseIdWAss.Enabled = false;


            //Label RelMnthAss = (Label)gdvrow.FindControl("lblMnth");
            //RelMnthAss.Enabled = true;

            //Label RelYearIdAss = (Label)gdvrow.FindControl("lblYearId");
            //RelYearIdAss.Enabled = true;

            ImageButton btndeletedDtlusAss = (ImageButton)gdvrow.FindControl("btndeletedDtlus");
            btndeletedDtlusAss.Enabled = false;


        }
    }
    private void InitialSettings()
    {
        //Session["flgPageBackW"] = 7;
        SetGridDefault(gdvDPWith);
        //ViewGrid();

        fillGridcombos(gdvDPWith);
        ShowDBPlus();
        FillHeadLbls();
        SetCtrls();
    }
    private void FillHeadLbls()
    {
        gendao = new GeneralDAO();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intYearAGCurr"]));


        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt32(Session["intMonthAGCurr"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        //lblTot.Text = Session["dblAmtDtPlusCurr"].ToString();
        if (Convert.ToInt16(Session["flgOAODt"]) == 1)
        {
            lblTot.Text =  Session["dblAmtDAERDt"].ToString();
            lbl11.Text = "Transfer Entry_DAER Debit";
            lblTotET.Text = "DAER Debit entered";
        }
        else
        {
            lblTot.Text =  Session["dblAmtOAODt"].ToString();
            lbl11.Text = "Transfer Entry_OAO Debit";
            lblTotET.Text = "OAO Debit entered";
        }

        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - (Convert.ToDouble(lblAmtWCP.Text)));
        
        if (Convert.ToInt16(Session["flgOAODt"]) == 1)
        {
            lblHead.Text = "DAER_Debit";
        }
        else
        {
            lblHead.Text = "OAO_Debit";
        }
    }
    private void SetGridDefault(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intVoucherNo");
        ar.Add("intVoucherID");
        ar.Add("numBillID");
        ar.Add("fltBillAmount");
        ar.Add("intTreasuryId");
        
        gblobj.SetGridDefault(gdv, ar);
    }
    public void fillGridcombos(GridView gdv)
    {
        PDEAgDao = new WithdrawalPDEAGDAO();
        gblobj = new clsGlobalMethods();
        gendao = new GeneralDAO();
        DataSet dstreas = new DataSet();
        dstreas = gendao.GetDisTreasuryWithOutDistId();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreasDBplusAss = (DropDownList)grdVwRow.FindControl("ddlTreasDBplus");
            gblobj.FillCombo(ddlTreasDBplusAss, dstreas, 1);
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
    public void ShowDBPlus()
    {
        bilDao = new BillDao();
        gblobj = new clsGlobalMethods();
        DataSet dsdbplus = new DataSet();
        ArrayList arr = new ArrayList();
        
        arr.Add(Convert.ToInt32(Session["IntAGId"]));
        if (Convert.ToInt16(Session["flgOAODt"]) == 1)
        {
            arr.Add(6);
        }
        else
        {
            arr.Add(7);
        }
        dsdbplus = bilDao.FillDBPlus(arr);
        if (dsdbplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsdbplus.Tables[0].Rows.Count.ToString();
            gdvDPWith.DataSource = dsdbplus;
            gdvDPWith.DataBind();

            fillGridcombos(gdvDPWith);
            for (int i = 0; i < dsdbplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWith.Rows[i];

                TextBox txtTeDPAss = (TextBox)gdv.FindControl("txtTeDP");
                txtTeDPAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
                txtBillNoDBPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
                txtBilldateDBplusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[2].ToString();

                DropDownList ddldrawnAss = (DropDownList)gdv.FindControl("ddldrawn");
                ddldrawnAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
                txtAmtDbPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[4].ToString();

                DropDownList ddlTreasDBplusAss = (DropDownList)gdv.FindControl("ddlTreasDBplus");
                ddlTreasDBplusAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[5].ToString();

                //TextBox txtReasonDBPlusAss = (TextBox)gdv.FindControl("txtReasonDBPlus");
                //txtReasonDBPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[7].ToString();

                Label lblintIdAss = (Label)gdv.FindControl("lblintId");
                lblintIdAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[8].ToString();

                CheckBox chkUnpostDPW = (CheckBox)gdv.FindControl("chkUnpostDPW");
                DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");


                if (Convert.ToInt16(dsdbplus.Tables[0].Rows[i].ItemArray[10]) == 2)
                {
                    chkUnpostDPW.Checked = true;
                    ddlreasonAss.Enabled = true;
                }
                else
                {
                    chkUnpostDPW.Checked = false;
                    ddlreasonAss.Enabled = false;
                }
                ddlreasonAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[6].ToString();

                Label lblYearId = (Label)gdv.FindControl("lblYearId");
                lblYearId.Text = dsdbplus.Tables[0].Rows[i].ItemArray[12].ToString();
                Label lblMnth = (Label)gdv.FindControl("lblMnth");
                lblMnth.Text = dsdbplus.Tables[0].Rows[i].ItemArray[13].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
            if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
            {
                lblAmtWCP.Text = gdvDPWith.FooterRow.Cells[5].Text.ToString();
            }
            else
            {
                lblAmtWCP.Text = "0";
            }

        }
        else
        {
            SetGridDefault(gdvDPWith);
            lblAmtWCP.Text = "0";
            fillGridcombos(gdvDPWith);
        }
    }
    protected void btnSaveDBPlus_Click(object sender, EventArgs e)
    {
        SaveDebitPlus();
    }
    private Boolean MandatoryFldsWithDocs(int i)
    {
        Boolean flg;
        flg = true;
        GridViewRow gdv = gdvDPWith.Rows[i];
        TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
        TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
        TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
        if (txtBilldateDBplusAss.Text == null || txtBilldateDBplusAss.Text == "" || Convert.ToInt32(txtBillNoDBPlusAss.Text) >= 9999)
        {
            flg = false;
        }
        if (txtAmtDbPlusAss.Text == null || txtAmtDbPlusAss.Text == "")
        {
            flg = false;
        }
        return flg;
    }
    public void SaveDebitPlus()
    {
        gblobj = new clsGlobalMethods();
        bil = new Bill();
        bilDao = new BillDao();
        genDAO = new KPEPFGeneralDAO();
        int cnt = 0;
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvDPWith.Rows[i];
            DataSet ds = new DataSet();
            TextBox txtBillNoDBPlusAss = (TextBox)gdvrw.FindControl("txtBillNoWD");
            if (MandatoryFldsWithDocs(i) == true)
            {
                if (txtBillNoDBPlusAss.Text == "")
                {
                    bil.IntBillNo = 0;
                }
                else
                {
                    bil.IntBillNo = Convert.ToInt32(txtBillNoDBPlusAss.Text);
                }
                TextBox txtBilldateDBplusAss = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
                if (txtBilldateDBplusAss.Text == "")
                {
                    bil.DtmBill = "";
                }
                else
                {
                    bil.DtmBill = txtBilldateDBplusAss.Text.ToString();
                    bil.IntDay = Convert.ToDateTime(txtBilldateDBplusAss.Text.ToString()).Day;
                }

                DropDownList drwnbyAss = (DropDownList)gdvrw.FindControl("ddldrawn");
                if (drwnbyAss.SelectedIndex > 0)
                {
                    bil.IntDrawnBy = Convert.ToInt16(drwnbyAss.SelectedValue);
                }
                else
                {
                    bil.IntDrawnBy = 0;
                }

                TextBox txtAmtDbPlusAss = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
                if (txtAmtDbPlusAss.Text == "")
                {
                    bil.FltBillAmount = 0;
                }
                else
                {
                    bil.FltBillAmount = Convert.ToDecimal(txtAmtDbPlusAss.Text);
                }

                bil.IntUserId = Convert.ToInt32(Session["intUserId"]);
                //bil.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
                //bil.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);
                ArrayList ard = new ArrayList();
                ard.Add(Convert.ToDateTime(txtBilldateDBplusAss.Text));
                bil.IntYearId = genDAO.gFunFindYearIdFromDate(ard);
                bil.IntMonthId = Convert.ToDateTime(txtBilldateDBplusAss.Text).Month;

                DropDownList ddlTreasDBplusAss = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
                if (ddlTreasDBplusAss.SelectedIndex > 0)
                {
                    bil.IntTreasuryId = Convert.ToInt32(ddlTreasDBplusAss.SelectedValue);
                }
                else
                {
                    bil.IntTreasuryId = 0;
                }
                CheckBox chkUnpostDPW = (CheckBox)gdvrw.FindControl("chkUnpostDPW");
                DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
                if (chkUnpostDPW.Checked == true)
                {
                    bil.FlgUnposted = 2;
                }
                else
                {
                    bil.FlgUnposted = 1;
                }

                if (ddlreasonAss.SelectedIndex > 0)
                {
                    bil.IntUnPostedRsn = Convert.ToInt32(ddlreasonAss.SelectedValue);
                }
                else
                {
                    bil.IntUnPostedRsn = 0;
                }
                bil.ChvRem = "";
                if (Convert.ToInt16(Session["flgOAODt"]) == 1)
                {
                    bil.FlgBillType = 6;
                }
                else
                {
                    bil.FlgBillType = 7;
                }
                bil.FlgSource = 2;

                bil.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);
                TextBox txtTeDPAss = (TextBox)gdvrw.FindControl("txtTeDP");
                if (txtTeDPAss.Text == "")
                {
                    bil.tENo = 0;
                }
                else
                {
                    bil.tENo = Convert.ToInt32(txtTeDPAss.Text);
                }
                Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
                if (lblintIdAss.Text == "")
                {
                    bil.NumBillID = 0;
                }
                else
                {
                    bil.NumBillID = Convert.ToInt32(lblintIdAss.Text.ToString());
                }

                ds = bilDao.CreateDebitPlus(bil);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    gblobj.NumBillID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
                }
                Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
                ////////////// Correction  ////////////////
                if (Convert.ToInt16(lblEditId.Text) > 0)
                {
                    Label oldYear = (Label)gdvrw.FindControl("lblYearId");
                    Label oldMnth = (Label)gdvrw.FindControl("lblMnth");

                    int yr1 = Convert.ToInt16(oldYear.Text);
                    int mth1 = Convert.ToInt16(oldMnth.Text);

                    int yr2 = bil.IntYearId;
                    int mth2 = Convert.ToDateTime(txtBilldateDBplusAss.Text).Month;
                    SaveCorrectionEntryChal(Convert.ToInt32(lblintIdAss.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, yr2, mth2);
                }
            }
            else
            {
                cnt = cnt + 1;
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
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr1, int mth1, int yr2, int mth2)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();
        wDao = new WithdrwalDAO();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        dsChal = wDao.getEmpBillwise(ar);
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
            cor.IntTblTp = 2;
            cord.CreateCorrEntryCalcTblTp(cor);
        }

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    } 
    protected void txtBilldateDBplus_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDPWith.Rows[index];
        TextBox txtBilldateDBplus = (TextBox)gvr.FindControl("txtBilldateDBplus");
        ArrayList ardt = new ArrayList();
        DateTime dtm = new DateTime();
        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");

        if (gblobj.isValidDate(txtBilldateDBplus, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtBilldateDBplus, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["intMonthAGCurr"]), Convert.ToInt16(Session["intYearAGCurr"]));
                if (gblobj.CheckChalanDateAg(txtBilldateDBplus, dt) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
                else
                {
                    if (Convert.ToInt16(oldYear.Text) > 0)
                    {
                        dtm = Convert.ToDateTime(txtBilldateDBplus.Text);
                        ardt.Add(txtBilldateDBplus.Text);
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
            txtBilldateDBplus.Text = "";
        }
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
    protected void btndeletedDtlus_Click(object sender, ImageClickEventArgs e)
    {
        chDao = new ChalanDAO();
        bilDao = new BillDao();
        gblobj = new clsGlobalMethods();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;

        GridViewRow gdvrw = gdvDPWith.Rows[rowIndex];
        Label lblintIdAssWith = (Label)gdvrw.FindControl("lblintId");
        TextBox txtBilldateDBplus = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
        if (lblintIdAssWith.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            CorrectionEntryForDel(Convert.ToInt32(lblintIdAssWith.Text), txtBilldateDBplus.Text.ToString()); //Corr Entry
            arrin.Add(Convert.ToInt32(lblintIdAssWith.Text));
            try
            {
                bilDao.DeleteDBPlus(arrin);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
            //Build April2022        
            ArrayList procin = new ArrayList();
            procin.Add("DAERDt.aspx-Bill Entry-btndeletedDtlus_Click-event-DeleteDBPlus");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintIdAssWith.Text));
            chDao.Processtracking(procin);  
            gblobj.MsgBoxOk("Row Deleted   !", this);
            //ShowDBPlus();
            FillHeadLbls();
        }
        else
        {
            gblobj.MsgBoxOk("Invalid data!", this);
        }
        ShowDBPlus();
    }
    private void CorrectionEntryForDel(float numChalId, string chalDt)
    {
        wDao = new WithdrwalDAO();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ds = wDao.getEmpBillwise(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                DateTime dt;
                dt = Convert.ToDateTime(chalDt);

                int intMth = dt.Month;
                int intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(chalDt);
                int intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 9, fltAmtBfr, fltAmtAfr, 4);
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
        cor.IntTblTp = 2;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        PDEAgDao = new WithdrawalPDEAGDAO();
        bilDao = new BillDao();
        gblobj = new clsGlobalMethods();
        gendao = new GeneralDAO();
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
            dstreas = gendao.GetDisTreasuryWithOutDistId();
            arDdlDs.Add(dstreas);

            DataSet dsM = new DataSet();
            ArrayList aIn = new ArrayList();
            aIn.Add(2);
            dsM = gendao.GetMisClassRsn(aIn);
            arDdlDs.Add(dsM);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsdbplus = new DataSet();
            ArrayList arr = new ArrayList();
            
            arr.Add(Convert.ToInt16(Session["IntAGId"]));
            if (Convert.ToInt16(Session["flgOAODt"]) == 1)
            {
                arr.Add(6);
            }
            else

            {
                arr.Add(7);
            }
            dsdbplus = bilDao.FillDBPlusRowCntDaer(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("intVoucherNo");
            arHp.Add("intVoucherID");
            arHp.Add("numBillID");
            arHp.Add("fltBillAmount");
            arHp.Add("intTreasuryId");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dsdbplus, Convert.ToInt16(txtCnt.Text), gdvDPWith, arDdl, arCols, arDdlDs, arHp);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGstatements.aspx";
    }
  
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeDP");
        arCols.Add("txtBillNoWD");
        arCols.Add("txtBilldateDBplus");
        arCols.Add("ddldrawn");
        arCols.Add("txtAmtDbPlus");
        arCols.Add("ddlTreasDBplus");
        arCols.Add("chkUnpostDPW");
        arCols.Add("ddldrawn");
        arCols.Add("lblintId");
    }

    protected void chkUnpostDPW_CheckedChanged(object sender, EventArgs e)
    {
        int intCurRw = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvDPWith.Rows[intCurRw];
        DropDownList ddlUnP = (DropDownList)gvr.FindControl("ddlreason");
        CheckBox chkUnP = (CheckBox)gvr.FindControl("chkUnpostDPW");
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
