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

public partial class Contents_DebitPlusCurr : System.Web.UI.Page
{

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    Missing ms;
    MissingDAO msDao;
    TEDAO teDAO;
    Bill bil;
    BillDao bilDao;
    balancetrans bl;
    BalancetransDAO blDAO;
    WithdrawalPDEAGDAO PDEAgDao;
    BalanceTransPDEDao blPDEDao;
    CorrectionEntry cor;
    CorrectionEntryDao cord;
    WithdrwalDAO wDao;
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
                SetCtrls();
                lblTot.Text = "Debit Plus  " + Session["dblAmtDtPlusCurr"].ToString();
                lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
            }
            else
            {
                InitialSettings();
            }
        }
    }
  
    protected void txtCntRow_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        bilDao = new BillDao();
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
            dstreas = gendao.GetDisTreasuryWithOutDistId();
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

            //arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            //arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
            //arr.Add(2);
            arr.Add(Convert.ToInt32(Session["IntAGId"]));
            arr.Add(4);
            dsdbplus = bilDao.FillDBPlusRowCnt(arr);
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
            gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            btnOkWithouDocsDb.Enabled = true;
            btnSaveDBPlus.Enabled = true;
            btnbalance.Enabled = true;
            txtCntwtht.Enabled = true;
            txtCnt.Enabled = true;
            txtCntBT.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            btnOkWithouDocsDb.Enabled = false;
            btnSaveDBPlus.Enabled = false;
            btnbalance.Enabled = false;
            txtCntwtht.Enabled = false;
            txtCnt.Enabled = false;
            txtCntBT.Enabled = false;
        }
    }
    private void SetCtrlsEnable()
    {
        gdvDPWithOut.Enabled = true;
        SetWithDocsGridEnable();
        gdvBlnsDP.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        gdvDPWithOut.Enabled = false;
        SetWithDocsGridDisable();
        gdvBlnsDP.Enabled = false;
    }
    private void SetWithDocsGridDisable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = true;
            txtTeDPAss.Enabled = true;

            TextBox txtBillNoWDAss = (TextBox)gdvrow.FindControl("txtBillNoWD");
            txtBillNoWDAss.ReadOnly = true;
            txtBillNoWDAss.Enabled = true;

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

            CheckBox chlUnpostDPWAss = (CheckBox)gdvrow.FindControl("chlUnpostDPW");
            chlUnpostDPWAss.Enabled = false;

            //DropDownList ddlreason = (DropDownList)gdvrow.FindControl("ddlreason");
            //ddlreason.Enabled = false;


            //DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            //ddlStatusAss.Enabled = false;

            Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");
        
            lblintIdAss.Enabled = false;

            //Button BtnwithDtAss = (Button)gdvrow.FindControl("BtnwithDt");
            //BtnwithDtAss.Enabled = false;


            TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            txtRelMnthWiseIdWAss.ReadOnly = true;
            txtRelMnthWiseIdWAss.Enabled = false;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = true;
            //RelMnthAss.Enabled = false;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = true;
            //RelYearIdAss.Enabled = false;

            ImageButton btndeletedDtlusAss = (ImageButton)gdvrow.FindControl("btndeletedDtlus");
            btndeletedDtlusAss.Enabled = false;


        }
    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = false;
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

            CheckBox chlUnpostDPWAss = (CheckBox)gdvrow.FindControl("chlUnpostDPW");
            chlUnpostDPWAss.Enabled = true;

            //DropDownList ddlreason = (DropDownList)gdvrow.FindControl("ddlreason");
            //ddlreason.Enabled = true;

            //DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            //ddlStatusAss.Enabled = true;

            Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");
           
            lblintIdAss.Enabled = true;

            //Button BtnwithDtAss = (Button)gdvrow.FindControl("BtnwithDt");
            //BtnwithDtAss.Enabled = true;


            TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            txtRelMnthWiseIdWAss.ReadOnly = false;
            txtRelMnthWiseIdWAss.Enabled = true;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = false;
            //RelMnthAss.Enabled = true;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = false;
            //RelYearIdAss.Enabled = true;

            ImageButton btndeletedDtlusAss = (ImageButton)gdvrow.FindControl("btndeletedDtlus");
            btndeletedDtlusAss.Enabled = true;

        }
    }
    private void InitialSettings()
    {
        Session["flgPageBackW"] = 7;
        SetGridDefault(gdvDPWith);
        ViewGrid();

        //fillGridcombos(gdvDPWith);
        //fillGridcomboswithoutDocs(gdvDPWithOut);
        //fillGridcombosBT(gdvBlnsDP);

        ShowDBPlus();
        ShowWithoutDocs();
        ShowBalanceTransDt();
        SetCtrls();
        FillHeadLbls();
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
    //public void fillGridcombosBT(GridView gdv)
    //{
    //    //DataSet dsstatus = new DataSet();
    //    //dsstatus = PDEAgDao.GetStatus();

    //    //for (int i = 0; i < gdv.Rows.Count; i++)
    //    //{
    //    //    GridViewRow grdVwRow = gdv.Rows[i];
    //    //    DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
    //    //    gblobj.FillCombo(ddlStatus, dsstatus, 1);
    //    //}
    //}
    //public void fillGridcombos(GridView gdv)
    //{

    //    DataSet dstreas = new DataSet();
    //    dstreas = teDAO.GetTreasury();
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gdv.Rows[i];
    //        DropDownList ddlTreasDBplusAss = (DropDownList)grdVwRow.FindControl("ddlTreasDBplus");
    //        gblobj.FillCombo(ddlTreasDBplusAss, dstreas, 1);

    //    }
    //    DataSet dsdist = new DataSet();
    //    dsdist = teDAO.GetDist();
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gdv.Rows[i];
    //        DropDownList ddlDistDbplusAss = (DropDownList)grdVwRow.FindControl("ddlDist");
    //        gblobj.FillCombo(ddlDistDbplusAss, dsdist, 1);

    //    }
    //    DataSet dslb = new DataSet();
    //    dslb = teDAO.GetLB();
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {

    //        GridViewRow grdVwRow = gdv.Rows[i];
    //        DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
    //        gblobj.FillCombo(ddlLBAss, dslb, 1);

    //    }
    //    DataSet dsdr = new DataSet();
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(2);
    //    dsdr = PDEAgDao.GetDrawnBy(arrIn);
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gdv.Rows[i];
    //        DropDownList ddldrawn = (DropDownList)grdVwRow.FindControl("ddldrawn");
    //        gblobj.FillCombo(ddldrawn, dsdr, 1);

    //    }
    //    //DataSet dsstatus = new DataSet();
    //    //dsstatus = PDEAgDao.GetStatus();

    //    //for (int i = 0; i < gdv.Rows.Count; i++)
    //    //{
    //    //    GridViewRow grdVwRow = gdv.Rows[i];
    //    //    DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
    //    //    gblobj.FillCombo(ddlStatus, dsstatus, 1);
    //    //}
    //}
    //public void fillGridcomboswithoutDocs(GridView gdv)
    //{
    //    DataSet dstreas = new DataSet();
    //    //dstreas = teDAO.GetTreasury();
    //    dstreas = gendao.GetDisTreasuryWithOutDistId();
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gdv.Rows[i];
    //        DropDownList ddlTreasuryDPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreasuryDPWO");
    //        gblobj.FillCombo(ddlTreasuryDPWOAss, dstreas, 1);
    //    }
    //    DataSet dslb = new DataSet();
    //    dslb = teDAO.GetLB();
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gdv.Rows[i];
    //        DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
    //        gblobj.FillCombo(ddlLBAss, dslb, 1);
    //    }
    //    //DataSet dsstatus = new DataSet();
    //    //dsstatus = PDEAgDao.GetStatus();

    //    //for (int i = 0; i < gdv.Rows.Count; i++)
    //    //{
    //    //    GridViewRow grdVwRow = gdv.Rows[i];
    //    //    DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
    //    //    gblobj.FillCombo(ddlStatus, dsstatus, 1);
    //    //}
    //}
    protected void btnSaveDBPlus_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
         {
             SaveDebitPlus();
         }
         else
         {
             gblobj.MsgBoxOk("No data!", this);
         }
    }
    private Boolean lFunEditable(Int32 chId, int trid, int chno, string chdt, double amt, string teno, int drnBy)
    {
        bilDao = new BillDao();
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
        ds = bilDao.getEditableCurr(ar);
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
    public void SaveDebitPlus()
    {
        gblobj = new clsGlobalMethods();
        bil = new Bill();
        bilDao = new BillDao();
        genDAO = new KPEPFGeneralDAO();
        int cnt = 0;
        ArrayList ardt = new ArrayList();
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvDPWith.Rows[i];
            DataSet ds = new DataSet();
            DropDownList ddlTreasDBplusAss = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
            TextBox txtAmtDbPlusAss = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
            TextBox txtBillNoDBPlusAss = (TextBox)gdvrw.FindControl("txtBillNoWD");
            TextBox txtTeDPAss = (TextBox)gdvrw.FindControl("txtTeDP");
            TextBox txtBilldateDBplusAss = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
            Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
            DropDownList drwnbyAss = (DropDownList)gdvrw.FindControl("ddldrawn");
            if (CheckMandatory(ddlTreasDBplusAss, txtAmtDbPlusAss, txtBillNoDBPlusAss, txtTeDPAss, txtBilldateDBplusAss) == true)
            {
                if (lFunEditable(Convert.ToInt32(lblintIdAss.Text), Convert.ToInt16(ddlTreasDBplusAss.Text), Convert.ToInt16(txtBillNoDBPlusAss.Text), txtBilldateDBplusAss.Text.ToString(), Convert.ToDouble(txtAmtDbPlusAss.Text), txtTeDPAss.Text.ToString(), Convert.ToInt16(drwnbyAss.SelectedValue)) == false)
                {
                    if (txtBillNoDBPlusAss.Text == "")
                    {
                        bil.IntBillNo = 0;
                    }
                    else
                    {
                        bil.IntBillNo = Convert.ToInt32(txtBillNoDBPlusAss.Text);
                    }


                    if (txtBilldateDBplusAss.Text == "")
                    {
                        bil.DtmBill = "";
                    }
                    else
                    {
                        bil.DtmBill = txtBilldateDBplusAss.Text.ToString();
                        bil.IntDay = Convert.ToDateTime(txtBilldateDBplusAss.Text.ToString()).Day;
                    }
                    
                    if (drwnbyAss.SelectedIndex > 0)
                    {
                        bil.IntDrawnBy = Convert.ToInt16(drwnbyAss.SelectedValue);
                    }
                    else
                    {
                        bil.IntDrawnBy = 0;
                    }

                    bil.FltBillAmount = Convert.ToDecimal(txtAmtDbPlusAss.Text);
                    bil.IntUserId = Convert.ToInt32(Session["intUserId"]);
                    //bil.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
                    //bil.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);                             
                    ArrayList ard = new ArrayList();
                    ard.Add(Convert.ToDateTime(txtBilldateDBplusAss.Text));
                    bil.IntYearId = genDAO.gFunFindYearIdFromDate(ard);
                    bil.IntMonthId = Convert.ToDateTime(txtBilldateDBplusAss.Text).Month;

                    bil.IntTreasuryId = Convert.ToInt32(ddlTreasDBplusAss.SelectedValue);
                    //bil.FlgUnposted = 1;
                    //bil.IntUnPostedRsn = 1;

                    CheckBox chlUnpostDPW = (CheckBox)gdvrw.FindControl("chlUnpostDPW");
                    if (chlUnpostDPW.Checked == true)
                    {
                        bil.FlgUnposted = 2;
                        DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
                        bil.IntUnPostedRsn = Convert.ToInt32(ddlreasonAss.SelectedValue);
                    }
                    else
                    {
                        bil.FlgUnposted = 1;
                        bil.IntUnPostedRsn = 0;
                    }
                    bil.ChvRem = "";
                    bil.FlgSource = 2;

                    bil.FlgBillType = 4;

                    bil.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);

                    if (txtTeDPAss.Text == "")
                    {
                        bil.tENo = 0;
                    }
                    else
                    {
                        bil.tENo = Convert.ToInt32(txtTeDPAss.Text);
                    }
                    
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
                        //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
                        gblobj.NumBillID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
                    }


                    Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
                    ////////////// Correction  ////////////////
                    if (Convert.ToInt16(lblEditId.Text) > 0)
                    {
                        Label oldYear = (Label)gdvrw.FindControl("lblYearId");
                        Label oldMnth = (Label)gdvrw.FindControl("lblMnth");
                        //Label oldDay = (Label)gdvrw.FindControl("lblDay");

                        int yr1 = Convert.ToInt16(oldYear.Text);
                        int mth1 = Convert.ToInt16(oldMnth.Text);
                        //int intDy1 = Convert.ToInt16(oldDay.Text);

                        int yr2 = bil.IntYearId;
                        int mth2 = Convert.ToDateTime(txtBilldateDBplusAss.Text).Month;
                        //int intDy2 = Convert.ToDateTime(txtBilldateDBplusAss.Text).Day;

                        SaveCorrectionEntryChal(Convert.ToInt32(lblintIdAss.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, yr2, mth2);
                    }
                    gblobj.MsgBoxOk("Saved Successfully  !!", this);
                    ShowDBPlus();
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
////////////////////////////////////////////////////////




        //gblobj = new clsGlobalMethods();
        //bil = new Bill();
        //bilDao = new BillDao();
        //genDAO = new KPEPFGeneralDAO();
        //ArrayList ardt = new ArrayList();
        //for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        //{
        //    GridViewRow gdvrw = gdvDPWith.Rows[i];
        //    DataSet ds = new DataSet();
        //    DropDownList ddlTreasDBplusAss = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
        //    TextBox txtAmtDbPlusAss = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
        //    TextBox txtBillNoDBPlusAss = (TextBox)gdvrw.FindControl("txtBillNoWD");
        //    TextBox txtTeDPAss = (TextBox)gdvrw.FindControl("txtTeDP");
        //    TextBox txtBilldateDBplusAss = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
        //    if (CheckMandatory(ddlTreasDBplusAss, txtAmtDbPlusAss, txtBillNoDBPlusAss, txtTeDPAss, txtBilldateDBplusAss) == true)
        //    {                
        //        if (txtBillNoDBPlusAss.Text == "")
        //        {
        //            bil.IntBillNo = 0;
        //        }
        //        else
        //        {
        //            bil.IntBillNo = Convert.ToInt32(txtBillNoDBPlusAss.Text);
        //        }

                
        //        if (txtBilldateDBplusAss.Text == "")
        //        {
        //            bil.DtmBill = "";
        //        }
        //        else
        //        {
        //            bil.DtmBill = txtBilldateDBplusAss.Text.ToString();
        //            bil.IntDay = Convert.ToDateTime(txtBilldateDBplusAss.Text.ToString()).Day;
        //        }

        //        DropDownList drwnbyAss = (DropDownList)gdvrw.FindControl("ddldrawn");
        //        if (drwnbyAss.SelectedIndex > 0)
        //        {
        //            bil.IntDrawnBy = Convert.ToInt16(drwnbyAss.SelectedValue);
        //        }
        //        else
        //        {
        //            bil.IntDrawnBy = 0;
        //        }                
               
        //        bil.FltBillAmount = Convert.ToDecimal(txtAmtDbPlusAss.Text);
        //        bil.IntUserId = Convert.ToInt32(Session["intUserId"]);
        //        //bil.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
        //        //bil.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);                             
        //        ArrayList ard = new ArrayList();
        //        ard.Add(Convert.ToDateTime(txtBilldateDBplusAss.Text));
        //        bil.IntYearId = genDAO.gFunFindYearIdFromDate(ard);
        //        bil.IntMonthId = Convert.ToDateTime(txtBilldateDBplusAss.Text).Month;

        //        bil.IntTreasuryId = Convert.ToInt32(ddlTreasDBplusAss.SelectedValue);              
        //        //bil.FlgUnposted = 1;
        //        //bil.IntUnPostedRsn = 1;

        //        CheckBox chlUnpostDPW = (CheckBox)gdvrw.FindControl("chlUnpostDPW");
        //        if (chlUnpostDPW.Checked == true)
        //        {
        //            bil.FlgUnposted = 2;
        //            DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
        //            bil.IntUnPostedRsn = Convert.ToInt32(ddlreasonAss.SelectedValue);
        //        }
        //        else
        //        {
        //            bil.FlgUnposted = 1;
        //            bil.IntUnPostedRsn = 0;
        //        }
        //        bil.ChvRem = "";
        //        bil.FlgSource = 2;

        //        bil.FlgBillType = 4;

        //        bil.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);
                
        //        if (txtTeDPAss.Text == "")
        //        {
        //            bil.tENo = 0;
        //        }
        //        else
        //        {
        //            bil.tENo = Convert.ToInt32(txtTeDPAss.Text);
        //        }
        //        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        //        if (lblintIdAss.Text == "")
        //        {
        //            bil.NumBillID = 0;
        //        }
        //        else
        //        {
        //            bil.NumBillID = Convert.ToInt32(lblintIdAss.Text.ToString());
        //        }

        //        ds = bilDao.CreateDebitPlus(bil);
        //        if (ds.Tables[0].Rows.Count >= 1)
        //        {
        //            //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
        //            gblobj.NumBillID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
        //        }


        //        Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
        //        ////////////// Correction  ////////////////
        //        if (Convert.ToInt16(lblEditId.Text) > 0)
        //        {
        //            Label oldYear = (Label)gdvrw.FindControl("lblYearId");
        //            Label oldMnth = (Label)gdvrw.FindControl("lblMnth");
        //            //Label oldDay = (Label)gdvrw.FindControl("lblDay");

        //            int yr1 = Convert.ToInt16(oldYear.Text);
        //            int mth1 = Convert.ToInt16(oldMnth.Text);
        //            //int intDy1 = Convert.ToInt16(oldDay.Text);

        //            int yr2 = bil.IntYearId;
        //            int mth2 = Convert.ToDateTime(txtBilldateDBplusAss.Text).Month;
        //            //int intDy2 = Convert.ToDateTime(txtBilldateDBplusAss.Text).Day;

        //            SaveCorrectionEntryChal(Convert.ToInt32(lblintIdAss.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, yr2, mth2);
        //        }
        //        gblobj.MsgBoxOk("Saved Successfully  !!", this);
        //        ShowDBPlus();
        //    }
        //    else
        //    {
        //        gblobj.MsgBoxOk("Enter all details !!", this);
        //    }
        //    //gblobj.MsgBoxOk("Saved Successfully  !!", this);
        //    //ShowDBPlus();
        //}
        
        ////ShowDBPlus();
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
    private Boolean CheckMandatory(DropDownList ddltreas, TextBox txt, TextBox txtNo, TextBox txtTe, TextBox txtDt)
    {
        gblobj = new clsGlobalMethods();
        
        Boolean flg = true;
        //if (ddltreas.SelectedValue == "0" || ddltreas.SelectedValue == "" || txt.Text.ToString() == "" || txt.Text.ToString() == "0")
        if (txtDt.Text == null || txtDt.Text == "" || txtNo.Text == null || txtNo.Text == "" || txtNo.Text.ToString() == "0" || txtTe.Text == null || txtTe.Text == "" || ddltreas.SelectedValue == "0" || ddltreas.SelectedValue == "" || txt.Text.ToString() == "" || txt.Text.ToString() == "0")
        {
            //gblobj.MsgBoxOk("Enter all details!", this);
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
        gblobj = new clsGlobalMethods();
        bil = new Bill();
        bilDao = new BillDao();
        genDAO = new KPEPFGeneralDAO();

        GridViewRow gdvrw = gdvDPWithOut.Rows[j];
        DataSet ds = new DataSet();

        TextBox txtChlnDPWOAss = (TextBox)gdvrw.FindControl("txtChlnDPWO");
        if (txtChlnDPWOAss.Text == "")
        {
            bil.IntBillNo = 0;
        }
        else
        {
            bil.IntBillNo = Convert.ToInt32(txtChlnDPWOAss.Text);
        }
        TextBox txtChlnDateDPWOAss = (TextBox)gdvrw.FindControl("txtChlnDateDPWO");
        if (txtChlnDateDPWOAss.Text == "")
        {
            bil.DtmBill = "";
        }
        else
        {
            bil.DtmBill = txtChlnDateDPWOAss.Text.ToString();
            bil.IntDay = Convert.ToDateTime(txtChlnDateDPWOAss.Text.ToString()).Day;
        }
        bil.IntDrawnBy = 0;
        TextBox txtAmtDbPlusAss = (TextBox)gdvrw.FindControl("txtAmtDPWO");
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

        ArrayList ardt = new ArrayList();
        ardt.Add(txtChlnDateDPWOAss.Text.ToString());
        bil.IntYearId = genDAO.gFunFindYearIdFromDate(ardt);
        bil.IntMonthId = Convert.ToDateTime(txtChlnDateDPWOAss.Text).Month;

        DropDownList ddlTreasuryDPWO = (DropDownList)gdvrw.FindControl("ddlTreasuryDPWO");
        if (ddlTreasuryDPWO.SelectedIndex > 0)
        {
            bil.IntTreasuryId = Convert.ToInt32(ddlTreasuryDPWO.SelectedValue);
        }
        else
        {
            bil.IntTreasuryId = 0;
        }
        bil.FlgUnposted = 1;

        bil.IntUnPostedRsn = 1;

        TextBox txtRemDPWO = (TextBox)gdvrw.FindControl("txtRemDPWO");
        if (txtRemDPWO.Text == "")
        {
            bil.ChvRem = "";
        }
        else
        {
            bil.ChvRem = txtRemDPWO.Text.ToString();
        }
        bil.FlgSource = 2;
        bil.FlgBillType = 4;
        bil.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);
        TextBox txtteDPWO = (TextBox)gdvrw.FindControl("txtteDPWO");
        if (txtteDPWO.Text == "")
        {
            bil.tENo = 0;
        }
        else
        {
            bil.tENo = Convert.ToInt32(txtteDPWO.Text);
        }
        bil.NumBillID = 0;
        ds = bilDao.CreateDebitPlus(bil);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
            gblobj.NumBillID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        gblobj.MsgBoxOk("Saved Successfully  !!", this);
        ShowDBPlus();
    }

    public void ShowDBPlus()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        bilDao = new BillDao();
        PDEAgDao = new WithdrawalPDEAGDAO();

        DataSet dsdbplus = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt32(Session["IntAGId"]));
        arr.Add(4);
        dsdbplus = bilDao.FillDBPlus(arr);
        if (dsdbplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsdbplus.Tables[0].Rows.Count.ToString();
            gdvDPWith .DataSource = dsdbplus;
            gdvDPWith.DataBind();

            //fillGridcombos(gdvDPWith);
            for (int i = 0; i < dsdbplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWith.Rows[i];

                TextBox txtTeDPAss = (TextBox)gdv.FindControl("txtTeDP");
                txtTeDPAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
                txtBillNoDBPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
                txtBilldateDBplusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[2].ToString();

                DataSet dsdr = new DataSet();
                ArrayList arrIn = new ArrayList();
                arrIn.Add(2);
                dsdr = PDEAgDao.GetDrawnBy(arrIn);
                DropDownList ddldrawnAss = (DropDownList)gdv.FindControl("ddldrawn");
                gblobj.FillCombo(ddldrawnAss, dsdr, 1);
                ddldrawnAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
                txtAmtDbPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[4].ToString();

                DataSet dstreas = new DataSet();
                dstreas = gendao.GetDisTreasuryWithOutDistId();
                DropDownList ddlTreasDBplusAss = (DropDownList)gdv.FindControl("ddlTreasDBplus");
                gblobj.FillCombo(ddlTreasDBplusAss, dstreas, 1);
                ddlTreasDBplusAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[5].ToString();
                DataSet dsM = new DataSet();
                ArrayList aIn = new ArrayList();
                aIn.Add(2);
                dsM = gendao.GetMisClassRsn(aIn);
                DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");
                gblobj.FillCombo(ddlreasonAss, dsM, 1);     

                CheckBox chlUnpostDPW = (CheckBox)gdv.FindControl("chlUnpostDPW");
                if (Convert.ToInt16(dsdbplus.Tables[0].Rows[i].ItemArray[10]) == 1)
                {
                    chlUnpostDPW.Checked = false;
                }
                else
                {
                    chlUnpostDPW.Checked = true;
                   
                    ddlreasonAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[11].ToString();
                }

                Label lblintIdAss = (Label)gdv.FindControl("lblintId");
                lblintIdAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[8].ToString();

                Label lblYearId = (Label)gdv.FindControl("lblYearId");
                lblYearId.Text = dsdbplus.Tables[0].Rows[i].ItemArray[12].ToString();
                Label lblMnth = (Label)gdv.FindControl("lblMnth");
                lblMnth.Text = dsdbplus.Tables[0].Rows[i].ItemArray[13].ToString();
                //Label lblDay = (Label)gdv.FindControl("lblDay");
                //lblDay.Text = dsdbplus.Tables[0].Rows[i].ItemArray[14].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvDPWith , 5, "txtAmtDbPlus", 1);
            if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
            {
                lblAmtWCP.Text = gdvDPWith.FooterRow.Cells[5].Text.ToString();
                //ArrayList ar = new ArrayList();
                //DataSet dsS = new DataSet();
                //ar.Add(Convert.ToInt16(Session["IntYearAG"]));
                //ar.Add(Convert.ToInt16(Session["IntMonthAG"]));
                //dsS = bilDao.FillDBPlusAmt(ar);
                //if (dsS.Tables[0].Rows.Count > 0)
                //{
                //    //lblAmtSch.Text = dsS.Tables[0].Rows[0].ItemArray[2].ToString();
                //}
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
            //fillGridcombos(gdvDPWith);
            gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
        }
    }
    public void ShowBalanceTransDt()
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();
        blPDEDao = new BalanceTransPDEDao();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add( Convert.ToInt32(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt32(Session["intMonthAGCurr"]));

        ds = blDAO.FillBalancetransDt(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvBlnsDP.DataSource = ds;
            gdvBlnsDP.DataBind();

            //dtBTdoc = gblobj.SetGridTableRows(gdvBlnsDP, ds.Tables[0].Rows.Count);
            //ViewState["BTDt"] = dtBTdoc;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvBlnsDP.Rows[i];
                TextBox txtTeNoAss = (TextBox)gdv.FindControl("txtTeNo");
                txtTeNoAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtFromACcAss = (TextBox)gdv.FindControl("txtFromACc");
                txtFromACcAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                ArrayList arrin = new ArrayList();
                DataSet dsname = new DataSet();
                if (txtFromACcAss.Text != "" && txtFromACcAss.Text != null)
                {
                    arrin.Add(txtFromACcAss.Text);
                    dsname = blPDEDao.FillName(arrin);
                    if (dsname.Tables[0].Rows.Count > 0)
                    {
                        TextBox txtNameAssfrm = (TextBox)gdv.FindControl("txtfrmName");
                        txtNameAssfrm.Text = dsname.Tables[0].Rows[0].ItemArray[0].ToString();
                        Label txtintAccnoass = (Label)gdv.FindControl("lblaccNo");
                        txtintAccnoass.Text = dsname.Tables[0].Rows[0].ItemArray[1].ToString();
                        //Session["intFrmAccno"] = txtintAccnoass.Text;
                        txtFromACcAss.Text = dsname.Tables[0].Rows[0].ItemArray[4].ToString();
                    }
                }
                TextBox txtNameAss = (TextBox)gdv.FindControl("txtName");
                txtNameAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtAmountAss = (TextBox)gdv.FindControl("txtAmount");
                txtAmountAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtRemarksAss = (TextBox)gdv.FindControl("txtRemarks");
                txtRemarksAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblintIdAss = (Label)gdv.FindControl("lblintId");
                lblintIdAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

                Label lblAccNoNew = (Label)gdv.FindControl("lblAccNoNew");
                lblAccNoNew.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                Label lblAmtOld = (Label)gdv.FindControl("lblAmtOld");
                lblAmtOld.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

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
            SetGridDefault(gdvBlnsDP);
            lblAmtBTCP.Text = "0";
            gblobj.SetFooterTotalsTempField(gdvBlnsDP, 6, "txtAmount", 1);
        }
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
                        SaveWithAG(i);
                        UpdateMissing(i, 2);
                    }
                    else
                    {
                        gblobj.MsgBoxOk("Enter all details!!!", this);
                    }
                }
                else
                {
                    UpdateMissing(i, 1);
                }
            }
            ShowWithoutDocs();
            ShowDBPlus();
            lblAmtWOCP.Text = Convert.ToString(gdvDPWithOut.FooterRow.Cells[4].Text);
            lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
            lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        }
    }
    private Boolean MandatoryFlds(int i)
    {
        Boolean flg;
        GridViewRow gdv = gdvDPWithOut.Rows[i];
        TextBox txtChlnDPWOAss = (TextBox)gdv.FindControl("txtChlnDPWO");
        TextBox txtChlnDateDPWOAss = (TextBox)gdv.FindControl("txtChlnDateDPWO");
        TextBox txtAmtDPWOAss = (TextBox)gdv.FindControl("txtAmtDPWO");
        DropDownList ddlTreasuryDPWOAss = (DropDownList)gdv.FindControl("ddlTreasuryDPWO");
        TextBox txtteDPWO = (TextBox)gdv.FindControl("txtteDPWO");
        
        //if (txtChlnDateDPWOAss.Text == null || txtChlnDateDPWOAss.Text == "" || txtChlnDateDPWOAss.Text == "01/01/1900" || txtChlnDPWOAss.Text == null || txtChlnDPWOAss.Text == "" || txtChlnDPWOAss.Text == "9999")
        if (txtChlnDateDPWOAss.Text == null || txtChlnDateDPWOAss.Text == "" || txtChlnDateDPWOAss.Text == "01/01/1900" || txtChlnDPWOAss.Text == null || txtChlnDPWOAss.Text == "" || Convert.ToInt32(txtChlnDPWOAss.Text) == 0 || txtteDPWO.Text == null || txtteDPWO.Text == "")
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
    public void UpdateMissing(int i, int flgMissingPDE)
    {
        genDAO = new KPEPFGeneralDAO();
        ms = new Missing();
        msDao = new MissingDAO();

        GridViewRow gdvrw = gdvDPWithOut.Rows[i];
        DataSet ds = new DataSet();
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        if (lblintIdAss.Text == "")
        {
            ms.IntId = 0;
        }
        else
        {
            ms.IntId = Convert.ToInt32(lblintIdAss.Text.ToString());
        }
        ms.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);
        TextBox txtteDPWOAss = (TextBox)gdvrw.FindControl("txtteDPWO");
        if (txtteDPWOAss.Text == "")
        {
            ms.ChvTEId = "";
        }
        else
        {
            ms.ChvTEId = txtteDPWOAss.Text;
        }
        ms.FlgType = 2;
        TextBox txtChlnDPWOAss = (TextBox)gdvrw.FindControl("txtChlnDPWO");
        if (txtChlnDPWOAss.Text == "")
        {
            ms.ChvChalanBillNo = "";
        }
        else
        {
            ms.ChvChalanBillNo = txtChlnDPWOAss.Text.ToString();
        }
        TextBox txtChlnDateDPWOAss = (TextBox)gdvrw.FindControl("txtChlnDateDPWO");
        if (txtChlnDateDPWOAss.Text == "")
        {
            ms.DtmChalanBilllDt = "";
        }
        else
        {
            ms.DtmChalanBilllDt = txtChlnDateDPWOAss.Text.ToString();
        }
        TextBox txtAmtDPWOAss = (TextBox)gdvrw.FindControl("txtAmtDPWO");
        if (txtAmtDPWOAss.Text == "")
        {
            ms.FltAmt = 0;
        }
        else
        {
            ms.FltAmt = Convert.ToDecimal(txtAmtDPWOAss.Text);
        }
        //CheckBox chkCollect = (CheckBox)gdvrw.FindControl("chkCollect");
        //if (chkCollect.Checked == true)
        //{       
        //    if (MandatoryFlds(i) == true)
        //    {
        //        ms.FlgMissing = 2;
        //    }
        //    else
        //    {
        //        ms.FlgMissing = 1;
        //        gblobj.MsgBoxOk("Enter all details!", this);
        //    }
        //}
        //else
        //{
        //    ms.FlgMissing = 1;
        //}
        ms.FlgMissing = flgMissingPDE;
        ms.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
        ms.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);

        //ArrayList ardt = new ArrayList();
        //if (txtChlnDateDPWOAss.Text.ToString() == "" || txtChlnDateDPWOAss.Text.ToString() == null)
        //{
        //    ms.IntYearId = 36;
        //    ms.IntMonthId = 4;
        //}
        //else
        //{
        //    ardt.Add(txtChlnDateDPWOAss.Text.ToString());
        //    ms.IntYearId = genDAO.gFunFindYearIdFromDate(ardt);
        //    ms.IntMonthId = Convert.ToDateTime(txtChlnDateDPWOAss.Text).Month;
        //}

        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            ms.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            ms.IntLBID = 0;
        }
        DropDownList ddlTreasuryDPWOAss = (DropDownList)gdvrw.FindControl("ddlTreasuryDPWO");
        if (ddlTreasuryDPWOAss.SelectedIndex > 0)
        {
            ms.IntTreasID = Convert.ToInt32(ddlTreasuryDPWOAss.SelectedValue);
        }
        else
        {
            ms.IntTreasID = 0;
        }
        TextBox txtRemDPWOAss = (TextBox)gdvrw.FindControl("txtRemDPWO");
        if (txtRemDPWOAss.Text == "")
        {
            ms.ChvRemarks = "";
        }
        else
        {
            ms.ChvRemarks = txtRemDPWOAss.Text.ToString();
        }
        ds = msDao.CreateCreditMissing(ms);
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    public void ShowWithoutDocs()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt32(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt32(Session["intMonthAGCurr"]));
        arr.Add(2);
        ds = msDao.FillCrWithoutDocs(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntwtht.Text = ds.Tables[0].Rows.Count.ToString();
            gdvDPWithOut.DataSource = ds;
            gdvDPWithOut.DataBind();

            //dtWithoutdoc = gblobj.SetGridTableRows(gdvDPWithOut, ds.Tables[0].Rows.Count);
            //ViewState["WithoutdocDt"] = dtWithoutdoc;

            //fillGridcomboswithoutDocs(gdvDPWithOut);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWithOut.Rows[i];
                TextBox txtteDPWOAss = (TextBox)gdv.FindControl("txtteDPWO");
                txtteDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtChlnDPWOAss = (TextBox)gdv.FindControl("txtChlnDPWO");         
                txtChlnDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtChlnDateDPWOAss = (TextBox)gdv.FindControl("txtChlnDateDPWO");
                txtChlnDateDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();


                TextBox txtAmtDPWOAss = (TextBox)gdv.FindControl("txtAmtDPWO");
                txtAmtDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                DataSet dstreas = new DataSet();
                dstreas = gendao.GetDisTreasuryWithOutDistId();
                DropDownList ddlTreasuryDPWOAss = (DropDownList)gdv.FindControl("ddlTreasuryDPWO");
                gblobj.FillCombo(ddlTreasuryDPWOAss, dstreas, 1);
                ddlTreasuryDPWOAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[10].ToString();

                //DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                //ddlLBAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRemDPWOAss = (TextBox)gdv.FindControl("txtRemDPWO");
                txtRemDPWOAss.Text = ds.Tables[0].Rows[i].ItemArray[11].ToString();


                Label lblintId = (Label)gdv.FindControl("lblintId");
                lblintId.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
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
            SetGridDefault(gdvDPWithOut);
            //fillGridcomboswithoutDocs(gdvDPWithOut);
            lblAmtWOCP.Text = "0";
            gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
        }

    }
    public void SaveBalanceDt()
    {
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        bl = new balancetrans();
        blDAO = new BalancetransDAO();

        for (int i = 0; i < gdvBlnsDP.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvBlnsDP.Rows[i];
            DataSet ds = new DataSet();

            Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
            //tranEntry.IntId = gblobj.IntId;

            if (lblintIdAss.Text == "")
            {
                bl.IntID = 0;
            }
            else
            {
                bl.IntID = Convert.ToInt32(lblintIdAss.Text.ToString());
            }
            bl.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);
            TextBox txtTeNoAss = (TextBox)gdvrw.FindControl("txtTeNo");
            if (txtTeNoAss.Text == "")
            {
                bl.ChvTEId = "";
            }
            else
            {
                bl.ChvTEId = txtTeNoAss.Text;
            }
            TextBox txtAmountAss = (TextBox)gdvrw.FindControl("txtAmount");
            if (txtAmountAss.Text == "")
            {
                bl.FltAmt = 0;
            }
            else
            {
                bl.FltAmt = Convert.ToDecimal(txtAmountAss.Text);
            }
            Label txtintAccnoass = (Label)gdvrw.FindControl("lblaccNo");
            if (txtintAccnoass.Text == "" || txtintAccnoass.Text == "0")
            {
                bl.IntFrmAccNo = 0;
            }
            else
            {

                bl.IntFrmAccNo = Convert.ToInt32(txtintAccnoass.Text);
            }
            TextBox txtNameAss = (TextBox)gdvrw.FindControl("txtName");
            if (txtNameAss.Text == "")
            {
                bl.ChvToAccNo = "";
            }
            else
            {
                bl.ChvToAccNo = txtNameAss.Text.ToString();
            }
            TextBox txtRemarksAss = (TextBox)gdvrw.FindControl("txtRemarks");
            if (txtRemarksAss.Text == "")
            {
                bl.ChvRemarks = "";
            }
            else
            {

                bl.ChvRemarks = txtRemarksAss.Text.ToString();
            }
            bl.IntModeChg = 1;
            bl.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
            bl.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);

            //////////////saveCorrectionEntryBT//////////////////////
            //Label lblintAccno = (Label)gdvrw.FindControl("lblAccNo");
            //TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmtCPBT");
            Label lbloldAcc = (Label)gdvrw.FindControl("lblAccNoNew");
            Label lbloldAmt = (Label)gdvrw.FindControl("lblAmtOld");

            int amtO = Convert.ToInt32(lbloldAmt.Text);
            int amtN = Convert.ToInt32(txtAmountAss.Text);
            int accO = Convert.ToInt32(lbloldAcc.Text);
            int accN = Convert.ToInt32(txtintAccnoass.Text);
            if (lFunEditMode(Convert.ToInt32(lblintIdAss.Text), Convert.ToDouble(txtAmountAss.Text), Convert.ToInt32(txtintAccnoass.Text)) == false)
            {
                saveCorrectionEntryBT(Convert.ToInt32(lblintIdAss.Text), amtO, amtN, accO, accN, 0);
            }
            //////////////saveCorrectionEntryBT//////////////////////

            ds = blDAO.CreateBalanceTransDt(bl);
        }
        gblobj.MsgBoxOk("Saved successfully", this);
        ShowBalanceTransDt();
    }
    private Boolean lFunEditMode(Int32 intBtID, double amt, Int32 acc)
    {
        gendao = new GeneralDAO();
        blDAO = new BalancetransDAO();
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intBtID);
        ar.Add(amt);
        ar.Add(acc);
        ds = blDAO.getEditStatusDt(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            Session["intCYearId"] = gendao.GetCCYearId();
            if (Convert.ToInt16(Session["intYearAGCurr"]) <= Convert.ToInt16(Session["intCYearId"]))
            {
                flg = false;
            }
            else
            {
                flg = true;
            }
        }
        
        return flg;
    }
    protected void btnbalance_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        if (Convert.ToDouble(gdvBlnsDP.FooterRow.Cells[6].Text) > 0)
        {
            SaveBalanceDt();
        }
        else
        {
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    //protected void Btnwithout_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["Withoutdoc"] != null)
    //    {
    //        DataTable dt = (DataTable)ViewState["Withoutdoc"];
    //        int count = gdvDPWithOut.Rows.Count;
    //        //DropDownList drp1 = (DropDownList)gdvCPW.Rows[count - 1].Cells[5].FindControl("ddlTreCPWO");
    //        //DropDownList drp2 = (DropDownList)gdvCPW.Rows[count - 1].Cells[6].FindControl("ddlDist");
    //        //DropDownList drp3 = (DropDownList)gdvCPW.Rows[count - 1].Cells[7].FindControl("ddlLB");
    //        //if (drp1.SelectedIndex == 0)
    //        //{
    //        //   // ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Data');", true);
    //        //    objClass.setFocus(drp1, this);
    //        //}
    //        //else
    //        //{
    //        ArrayList arrIN = new ArrayList();
    //        arrIN.Add("txtteDPWO");
    //        arrIN.Add("txtChlnDPWO");
    //        arrIN.Add("txtChlnDateDPWO");
    //        arrIN.Add("txtAmtCPWO");
    //        arrIN.Add("ddlTreasuryDPWO");
    //        arrIN.Add("ddlLB");
    //        arrIN.Add("txtRemDPWO");
    //        //  arrIN.Add("ddlStusCPW");
    //        arrIN.Add("lblintId");
    //        arrIN.Add("Btnwithout");
    //        arrIN.Add("RelMnth");
    //        arrIN.Add(" RelYearId");
    //        dt = gblobj.AddNewRowToGrid(dt, gdvDPWithOut, arrIN);
    //        ViewState["SpecTable"] = dt;
    //        DropDownList drpnewtreas = (DropDownList)gdvDPWithOut.Rows[count].FindControl("ddlTreasuryCPWO");

    //        DropDownList drpnewLB = (DropDownList)gdvDPWithOut.Rows[count].FindControl("ddlLB");
    //        gblobj.setFocus(drpnewtreas, this);
    //        //}
    //        fillGridcomboswithoutDocs(gdvDPWithOut);
    //        for (int i = 0; i < dt.Rows.Count - 1; i++)
    //        {
    //            DropDownList drptr = (DropDownList)gdvDPWithOut.Rows[i].FindControl("ddlTreasuryCPWO");
    //            drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();

    //            DropDownList drpLB = (DropDownList)gdvDPWithOut.Rows[i].FindControl("ddlLB");
    //            drpLB.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
    //        }
    //    }

    //}
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
    //        arrIN.Add("txtintId");
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
    //protected void BtnBTDt_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["BTDt"] != null)
    //    {
    //        DataTable dt = (DataTable)ViewState["BTDt"];
    //        int count = gdvBlnsDP.Rows.Count;

    //        ArrayList arrIN = new ArrayList();
    //        arrIN.Add("txtTeNo");
    //        arrIN.Add("txtFromACc");
    //        arrIN.Add("txtName");
    //        arrIN.Add("txtAmount");
    //        arrIN.Add("txtRemarks");
    //        arrIN.Add("lblintId");
    //        arrIN.Add("BtnBTDt");



    //        dt = gblobj.AddNewRowToGrid(dt, gdvBlnsDP, arrIN);
    //        ViewState["BTBTDt"] = dt;

    //    }
    //}
    private void FillHeadLbls()
    {
        gendao = new GeneralDAO();
        
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intYearAGCurr"]));
        
       
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt32(Session["intMonthAGCurr"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        lblTot.Text = Session["dblAmtDtPlusCurr"].ToString();
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    protected void txtFromACc_TextChanged(object sender, EventArgs e)
    {
        blPDEDao = new BalanceTransPDEDao();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvBlnsDP.Rows[index];
        TextBox txtFromACcAss = (TextBox)gdvrw.FindControl("txtFromACc");
        ArrayList arr = new ArrayList();
        DataSet dsname = new DataSet();
        arr.Add(txtFromACcAss.Text);
        dsname = blPDEDao.FillName(arr);
        if (dsname.Tables[0].Rows.Count > 0)
        {
            TextBox txtNameAss = (TextBox)gdvrw.FindControl("txtfrmName");
            txtNameAss.Text = dsname.Tables[0].Rows[0].ItemArray[0].ToString();

            Label txtintAccnoass = (Label)gdvrw.FindControl("lblaccNo");
            txtintAccnoass.Text = dsname.Tables[0].Rows[0].ItemArray[1].ToString();
            //Session["intFrmAccno"] = txtintAccnoass.Text;

            TextBox txtFromACcK = (TextBox)gdvrw.FindControl("txtFromACc");
            txtFromACcK.Text = dsname.Tables[0].Rows[0].ItemArray[4].ToString();

        }

    }
    //protected void btnBack_Click(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/AGstatements.aspx";
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGstatements.aspx";
    }
    protected void ddlTreasuryDPWO_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDPWithOut.Rows[index];
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");
        DropDownList ddlTreCPWOAss = (DropDownList)gvr.FindControl("ddlTreasuryDPWO");

        if (Convert.ToInt16(ddlTreCPWOAss.SelectedValue) > 0)
        {
            Session["intTreas"] = Convert.ToInt16(ddlTreCPWOAss.SelectedValue);
            FillLbDtWise(Convert.ToInt16(Session["intTreas"]), ddlLBAss);
        }
        else
        {
            Session["intTreas"] = 0;
        }
    }
    private void FillLbDtWise(int TresId, DropDownList ddlLBAss)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList art = new ArrayList();
        art.Add(TresId);
        DataSet dst = new DataSet();
        dst = gendao.GetDistIdfromTreasId(art);
        if (dst.Tables[0].Rows.Count > 0)
        {
            Session["intDist"] = dst.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intDist"]));
        ar.Add(5);
        DataSet dslb = new DataSet();
        dslb = gendao.GetLB(ar);
        gblobj.FillCombo(ddlLBAss, dslb, 1);
    }

    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeDP");
        arCols.Add("txtBillNoWD");
        arCols.Add("txtBilldateDBplus");
        arCols.Add("ddldrawn");
        arCols.Add("txtAmtDbPlus");
        arCols.Add("ddlTreasDBplus");
        arCols.Add("chlUnpostDPW");
        arCols.Add("ddlreason");
        arCols.Add("lblintId");

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
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["intMonthAGCurr"]), Convert.ToInt16(Session["intYearAGCurr"]));
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


            //if (gblobj.CheckDate2(dt2, dt1) == true)
            //{
            //    if (gblobj.CheckDate2(dt1, dt3) == true)
            //    {
            //        ArrayList ar = new ArrayList();
            //        ar.Add(txtDt.Text.ToString());
            //        Session["IntYearSearchChal"] = genDAO.FindYearIdFromDate(ar);
            //    }
            //    else
            //    {
            //        gblobj.MsgBoxOk("Invalid Date", this);
            //        txtDt.Text = "";
            //    }
            //}
            //else
            //{
            //    gblobj.MsgBoxOk("Invalid Date", this);
            //    txtDt.Text = "";
            //}
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtDt.Text = "";
        }
    }
    protected void txtBilldateDBplus_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ardt = new ArrayList();
        DateTime dtm;
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDPWith.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtBilldateDBplus");
        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        //Label oldDay = (Label)gvr.FindControl("lblDay");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");

        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();

        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtDt, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["intMonthAGCurr"]), Convert.ToInt16(Session["intYearAGCurr"]));
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
                            //else
                            //{
                            //    if (dynw <= 4 && Convert.ToInt16(oldDay.Text) > 4)
                            //    {
                            //        lblEditId.Text = "1";
                            //    }
                            //    else
                            //    {
                            //        if (dynw > 4 && Convert.ToInt16(oldDay.Text) <= 4)
                            //        {
                            //            lblEditId.Text = "2";
                            //        }
                            //    }
                            //}
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
        }

    }
    protected void txtCntBTRow_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();

        if (txtCntBT.Text.Trim() != "")
        {
            ArrayList arDdl = new ArrayList();
            
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();
            //Store Cols in an array//////////
            ArrayList arColsBT = new ArrayList();
            SetArrColsBT(arColsBT);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsDbBT = new DataSet();
            ArrayList arr = new ArrayList();

            arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));

            dsDbBT = blDAO.FillBalancetransDtCnt(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHpBt = new ArrayList();
            arHpBt.Add("SlNo");
            arHpBt.Add("intVoucherNo");
            arHpBt.Add("intVoucherID");
            arHpBt.Add("numBillID");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dsDbBT, Convert.ToInt16(txtCntBT.Text), gdvBlnsDP,arDdl , arColsBT, arDdlDs , arHpBt);
            gblobj.SetFooterTotalsTempField(gdvBlnsDP, 6, "txtAmount", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }
     private void SetArrColsBT(ArrayList arColsBT)
    {
        arColsBT.Add("txtTeNo");
        arColsBT.Add("txtFromACc");
        arColsBT.Add("txtfrmName");
        arColsBT.Add("txtName");
        arColsBT.Add("txtAmount");
        arColsBT.Add("txtRemarks");
        arColsBT.Add("lblintId");
        arColsBT.Add("lblaccNo");
        arColsBT.Add("lblAccNoNew");
        arColsBT.Add("lblAmtOld");
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtCntwtht_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();
        teDAO = new TEDAO();

        if (txtCntwtht.Text.Trim() != "")
        {
        //Store Ddls in an array//////////
            ArrayList arDdlWT = new ArrayList();
            arDdlWT.Add("ddlTreasuryDPWO");
            arDdlWT.Add("ddlLB");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDsWt = new ArrayList();
            DataSet dstreas = new DataSet();        
            dstreas = gendao.GetDisTreasuryWithOutDistId();
            arDdlDsWt.Add(dstreas);

            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDsWt.Add(dslb);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arColsWt = new ArrayList();
            SetArrColsWT(arColsWt);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsDbwtht = new DataSet();
            ArrayList arr = new ArrayList();

            arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
            arr.Add(2);
            dsDbwtht = msDao.FillCrWithoutDocsRowCnt(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHpWT = new ArrayList();
            arHpWT.Add("SlNo");
            arHpWT.Add("intVoucherNo");
            arHpWT.Add("intVoucherID");
            arHpWT.Add("numBillID");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dsDbwtht, Convert.ToInt16(txtCntwtht.Text), gdvDPWithOut, arDdlWT, arColsWt, arDdlDsWt, arHpWT);
            gblobj.SetFooterTotalsTempField(gdvDPWithOut, 4, "txtAmtDPWO", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWithOut, 1);
        }
    }
    private void SetArrColsWT(ArrayList arColsWt)
    {
        arColsWt.Add("txtteDPWO");
        arColsWt.Add("txtChlnDPWO");
        arColsWt.Add("txtChlnDateDPWO");
        arColsWt.Add("txtAmtDPWO");
        arColsWt.Add("ddlTreasuryDPWO");
        arColsWt.Add("ddlLB");
        arColsWt.Add("txtRemDPWO");       
        arColsWt.Add("lblintId");
       
    }

    protected void chkCollect_CheckedChanged(object sender, EventArgs e)
    {

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
        arrin.Add(2);
        try
        {
            msDao.DeleteDebitWithoutDocs(arrin);
        }
        catch (Exception ex)
        {
            Session["ERROR"] = ex.ToString();
            Response.Redirect("Error.aspx");
        }
        //Build April2022
        ChalanDAO chDao = new ChalanDAO();
        ArrayList procin = new ArrayList();
        procin.Add("DebitPlusCurr.aspx-Without Supporting Documents-btndeletedTplusMissing_Click-event-DeleteDebitWithoutDocs");
        procin.Add(Session["intUserId"]);
        procin.Add(Convert.ToInt64(lblintIdAss.Text));
        chDao.Processtracking(procin); 
        gblobj.MsgBoxOk("Row Deleted   !", this);
    }
    else
    {
        gblobj.MsgBoxOk("No data !", this);
    }
        ShowWithoutDocs();
        FillHeadLbls();
        //}
        //else
        //{
        //}


    }
    protected void btndeletedDtlus_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        bilDao = new BillDao();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvDPWith.Rows[rowIndex];
        Label lblintIdAssWith = (Label)gdvrw.FindControl("lblintId");
        TextBox txtBilldateDBplus = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
        ArrayList arrin = new ArrayList();
        CorrectionEntryForDel(Convert.ToInt32(lblintIdAssWith.Text), txtBilldateDBplus.Text.ToString()); //Corr Entry
        if (lblintIdAssWith.Text != "")
        {
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
            ChalanDAO chDao = new ChalanDAO();
            ArrayList procin = new ArrayList();
            procin.Add("DebitPlusCurr.aspx-btndeletedDtlus_Click-DeleteDBPlus");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintIdAssWith.Text));
            chDao.Processtracking(procin);   
            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowDBPlus();
        FillHeadLbls();
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
                // chlId = Convert.ToInt32(txtchlnId.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(chalDt);

                int intMth = dt.Month;
                int intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(chalDt);
                int intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 4);
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
        cor.IntTblTp = 2;
        cord.CreateCorrEntryCalcTblTp(cor);
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
        yr = Convert.ToInt16(Session["intYearAGCurr"]);
        mth = Convert.ToInt16(Session["intMonthAGCurr"]);
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
                    cor.FltAmountAfter = -amtN;
                }
                double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                cor.IntYearID = yr;
                cor.IntMonthID = mth;
                cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                cor.FltCalcAmount = dblAmtAdjusted;
                cor.FlgCorrected = 1;      //Just added not incorporated in CCard
                cor.IntChalanId = schedId;
                cor.IntSchedId = schedId;
                cor.FlgType = 2;           //Dt
                cor.FltRoundingAmt = 0;
                cor.IntCorrectionType = corrType;
                cor.IntChalanType = 4;
                cor.IntTblTp = 2;
                cord.CreateCorrEntryCalcTblTp(cor);
            }
        }
        else
        {
            if (corrType == 13)
            {
                amtCalc = -amtN;
                cor.FltAmountBefore = 0;
                cor.FltAmountAfter = -amtN;
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
            cor.FlgType = 2;           //Dt
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = corrType;
            cor.IntChalanType = 4;
            cor.IntTblTp = 2;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    }
    protected void btndeletedDtbal_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvBlnsDP.Rows[rowIndex];
        Label  lblintIdBalAss  = (Label)gdvrw.FindControl("lblintId");

        //////////////saveCorrectionEntryBT//////////////////////
        Label lblintAccno = (Label)gdvrw.FindControl("lblaccNo");
        TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmount");
        Label lbloldAcc = (Label)gdvrw.FindControl("lblAccNoNew");
        Label lbloldAmt = (Label)gdvrw.FindControl("lblAmtOld");
        int amtO = Convert.ToInt32(lbloldAmt.Text);
        int amtN = Convert.ToInt32(txtAmtCPBT.Text);
        int accO = Convert.ToInt32(lbloldAcc.Text);
        int accN = Convert.ToInt32(lblintAccno.Text);
        saveCorrectionEntryBT(Convert.ToInt32(lblintIdBalAss.Text), amtO, amtN, accO, accN, 1);
        ////////////////////

        ArrayList arrin = new ArrayList();
        if (Convert.ToInt32(lblintIdBalAss.Text) > 0)
        {
            arrin.Add(Convert.ToInt32(lblintIdBalAss.Text));
            try
            {
                blDAO.DeleteBalancetransDt(arrin);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
            //Build April2022
            ChalanDAO chDao = new ChalanDAO();
            ArrayList procin = new ArrayList();
            procin.Add("DebitPlusCurr.aspx-btndeletedDtbal_Click-DeleteBalancetransDt");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintIdBalAss.Text));
            chDao.Processtracking(procin);
            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowBalanceTransDt();
        FillHeadLbls();

    }
    protected void chlUnpostDPW_CheckedChanged(object sender, EventArgs e)
    {
        int intCurRw = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvDPWith.Rows[intCurRw];
        DropDownList ddlUnP = (DropDownList)gvr.FindControl("ddlreason");
        CheckBox chkUnP = (CheckBox)gvr.FindControl("chlUnpostDPW");
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