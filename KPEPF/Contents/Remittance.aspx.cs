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
using System.Collections.Generic;
using KPEPFClassLibrary;
public partial class Contents_Remittance : System.Web.UI.Page
{
  
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    Chalan ch;
    ChalanDAO chDao;

    ScheduleDAO schedDao;

    CorrectionEntry cor;
    CorrectionEntryDao cord;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GeneralDAO gendao = new GeneralDAO();
            clearcontrols();
            Session["flgPageBack"] = 2;
            Session["intCCYearId"] = gendao.GetCCYearId();
            if ((Convert.ToInt32(Session["numChalanIdOnline"]) > 0 || Convert.ToInt16(Session["IntTreIdRemi"]) > 0) && Convert.ToInt32(Session["Sessionclear"]) == 1)
            {
                FillCmbs();
                SetCmbs();
                FillChalanLb();
                FillCmbFrm();
                FillChalanOther();
                FillTxts();
                FillChalanTxts();
                SetCtrls();
                //SetCmbs();
            }
            else
            {
                if (Request.QueryString["numChalanId"] != null)
                {
                    Session["chalTp14"] = 2;
                    FillCmbs();
                    SetCmbs();
                    FillCmbFrm();
                    //FillChalanLb();

                    //FillChalanOther();
                    FillTxts();
                    FillChalanTxts();
                    SetCtrls();
                }
                else if (Request.QueryString["numChalanId14"] != null)
                {
                    //setLnkEnable();
                    //if (Convert.ToInt16(Session["IntYearIdRemi"]) == 50 && Convert.ToInt16(Session["IntMonthIdRemi"]) <= 10 && Convert.ToInt16(Session["IntMonthIdRemi"]) >= 4 )
                    //{
                        Session["chalTp14"] = 1;
                        FillCmbs();
                        SetCmbs();
                        FillCmbFrm();
                        FillTxts();
                        FillChalanTxts14();
                        SetCtrls();
                    //}
                }
                else
                {
                    Session["Sessionclear"] = 0;
                    InitialSettings();
                }
            }
            Session["Sessionclear"] = 0;
        }
    }
    private void setLnkEnable()
    {
        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchRem.Rows[i];
            gvr.Cells[0].Enabled = true;
        }


        //if (Convert.ToInt16(Session["IntYearIdRemi"]) == 50 && Convert.ToInt16(Session["IntMonthIdRemi"]) <= 10 && Convert.ToInt16(Session["IntMonthIdRemi"]) >= 4)
        //{
        //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //    {
        //        GridViewRow gvr = gdvchRem.Rows[i];
        //        gvr.Cells[0].Enabled = true;
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //    {
        //        GridViewRow gvr = gdvchRem.Rows[i];
        //        gvr.Cells[0].Enabled = true;
        //    }
        //}
    }
    private void setLnkDisable()
    {
        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchRem.Rows[i];
            gvr.Cells[0].Enabled = false;
        }

        //if (Convert.ToInt16(Session["IntYearIdRemi"]) == 50 && Convert.ToInt16(Session["IntMonthIdRemi"]) <= 10 && Convert.ToInt16(Session["IntMonthIdRemi"]) >= 4)
        //{
        //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //    {
        //        GridViewRow gvr = gdvchRem.Rows[i];
        //        gvr.Cells[0].Enabled = false;
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //    {
        //        GridViewRow gvr = gdvchRem.Rows[i];
        //        gvr.Cells[0].Enabled = false;
        //    }
        //}
    }
    public void clearcontrols()
    {
        ClearCtrl();
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppTOnline"]) == 2)
        {
            SetGridsEnable();
            lblStat.Text = "Rejected";
            lnkChal.Enabled = true;
        }
        else if (Convert.ToInt16(Session["flgAppTOnline"]) == 0)
        {
            SetGridsEnable();
            lblStat.Text = "Not Verified";
            lnkChal.Enabled = true;
        }
        else if (Convert.ToInt16(Session["flgAppTOnline"]) == 10)
        {
            SetGridsEnable();
            lblStat.Text = "Verified";
            lnkChal.Enabled = true;
        }
        else
        {
            lblStat.Text = "Approved";
            SetGridsDisable();
            lnkChal.Enabled = false ;
        }
    }
    private void SetGridsDisable()
    {
        txtInt.ReadOnly = true;
        txtInt.Enabled = false;
        txtAmt.ReadOnly = true;
        txtRem.ReadOnly = true;
        btnEntry.Enabled = false;
        chkVerified.Enabled = false;
        btnLBSave.Enabled = false;
        btnNonLBSave.Enabled = false;
        lnkChal.Enabled = false;

        GridView gdv = gdvchRem;
        CheckBox Allchk = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        Allchk.Enabled = false;

        setLnkDisable();

        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchRem.Rows[i];
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
            CheckBox chkV = (CheckBox)gvr.FindControl("chkV");
            ImageButton btndeleteCh = (ImageButton)gvr.FindControl("btndeleteCh");
            DropDownList ddlFrmWhm = (DropDownList)gvr.FindControl("ddlFrmWhm");

            chkApp.Enabled = false;
            ddlReason.Enabled = false;
            chkV.Enabled = false;
            btndeleteCh.Enabled = false;
            ddlFrmWhm.Enabled = false;

            gvr.Cells[0].Enabled = false;
        }
        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");
            btndelete.Enabled = false;
            gvr.Cells[2].Enabled = false;
        }
        //for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvchNonLB.Rows[i];
        //    DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
        //    //TextBox txtNonLBChNo = (TextBox)gvr.FindControl("txtNonLBChNo");
        //    TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
        //    TextBox txtNonLBAmount = (TextBox)gvr.FindControl("txtNonLBAmount");
        //    DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
        //    DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
        //    CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
        //    DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
        //    ImageButton btnAddFloorNew = (ImageButton)gvr.FindControl("btnAddFloorNew");
        //    ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");

        //    ddlSubTre.Enabled = false;
        //    //txtNonLBChNo.ReadOnly = true;
        //    txtNonChDate.ReadOnly = true;
        //    txtNonChDate.Enabled = false;
        //    txtNonLBAmount.ReadOnly = true;
        //    ddlInst.Enabled = false;
        //    ddlChalan.Enabled = false;
        //    chkNonUnpost.Enabled = false;
        //    ddlReson.Enabled = false;
        //    btnAddFloorNew.Enabled = false;
        //    btndelete.Enabled = false;
        //}

    }
    //private void SetGridBelowDisable()
    //{
    //    for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
    //    {
    //        GridViewRow gvr = gdvchNonLB.Rows[i];
    //        DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
    //        //TextBox txtNonLBChNo = (TextBox)gvr.FindControl("txtNonLBChNo");
    //        TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
    //        TextBox txtNonLBAmount = (TextBox)gvr.FindControl("txtNonLBAmount");
    //        DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
    //        DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
    //        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
    //        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
    //        ImageButton btnAddFloorNew = (ImageButton)gvr.FindControl("btnAddFloorNew");
    //        ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");

    //        ddlSubTre.Enabled = false;
    //        //txtNonLBChNo.ReadOnly = true;
    //        txtNonChDate.ReadOnly = true;
    //        txtNonChDate.Enabled = false;
    //        txtNonLBAmount.ReadOnly = true;
    //        ddlInst.Enabled = false;
    //        ddlChalan.Enabled = false;
    //        chkNonUnpost.Enabled = false;
    //        ddlReson.Enabled = false;
    //        btnAddFloorNew.Enabled = false;
    //        btndelete.Enabled = false;
    //    }
    //}
    private void SetGridsEnable()
    {
        txtInt.ReadOnly = false;
        txtInt.Enabled = true;
        txtAmt.ReadOnly = false;
        txtRem.ReadOnly = false;
        btnEntry.Enabled = true;
        chkVerified.Enabled = true;
        btnLBSave.Enabled = true;
        btnNonLBSave.Enabled = true;
        lnkChal.Enabled = true;
        
        GridView gdv = gdvchRem;
        CheckBox Allchk = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        Allchk.Enabled = true;

        setLnkEnable();

        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gvrh = gdvchRem.HeaderRow;

            GridViewRow gvr = gdvchRem.Rows[i];
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
            CheckBox chkV = (CheckBox)gvr.FindControl("chkV");
            ImageButton btndeleteCh = (ImageButton)gvr.FindControl("btndeleteCh");
            DropDownList ddlFrmWhm = (DropDownList)gvr.FindControl("ddlFrmWhm");

            chkApp.Enabled = true;
            ddlReason.Enabled = true;
            btndeleteCh.Enabled = true;
            chkV.Enabled = true;
            ddlFrmWhm.Enabled = true;


        }
        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");
            btndelete.Enabled = true;
            gvr.Cells[2].Enabled = true ;
        }
        //for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvchNonLB.Rows[i];
        //    DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
        //    //TextBox txtNonLBChNo = (TextBox)gvr.FindControl("txtNonLBChNo");
        //    TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
        //    TextBox txtNonLBAmount = (TextBox)gvr.FindControl("txtNonLBAmount");
        //    DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
        //    DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
        //    CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
        //    DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
        //    ImageButton btnAddFloorNew = (ImageButton)gvr.FindControl("btnAddFloorNew");
        //    ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");

        //    ddlSubTre.Enabled = true;
        //    //txtNonLBChNo.ReadOnly = false;
        //    txtNonChDate.ReadOnly = false;
        //    txtNonChDate.Enabled = true;
        //    txtNonLBAmount.ReadOnly = false;
        //    ddlInst.Enabled = true;
        //    ddlChalan.Enabled = true;
        //    chkNonUnpost.Enabled = true;
        //    ddlReson.Enabled = true;
        //    btnAddFloorNew.Enabled = true;
        //    btndelete.Enabled = true;
        //}
    }
    private void InitialSettings()
    {
        //Session["flgPageBack"] = 2;
        FillCmbs();
        SetGridDefault();
        SetGridDefaultOtherChal();
        Session["flgChalanEditFrmTreasOrAg"] = 1;
        pnlChalNew.Visible = false;
    }
    private void SetCmbs()
    {
        ddlYear.SelectedValue = Session["IntYearIdRemi"].ToString();
        ddlMnth.SelectedValue = Session["IntMonthIdRemi"].ToString();
        ddldist.SelectedValue = Session["IntDistRemi"].ToString();
        FillDT();
        ddlDT.SelectedValue = Session["IntTreIdRemi"].ToString();
    }
    private void FillCmbs()
    {
        gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        GeneralDAO gen = new GeneralDAO();

        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddldist, ds, 1);

        DataSet dsyr = new DataSet();
       // dsyr = GenDao.GetYearOnLineBlockPrev();
        dsyr = GenDao.GetYearOnLine();
        gblObj.FillCombo(ddlYear, dsyr, 1);

        DataSet dsmnth = new DataSet();
        dsmnth = gen.GetMonth();
        gblObj.FillCombo(ddlMnth, dsmnth, 1);

    }
    private void FillCmbLb()
    {
        gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        GeneralDAO gen = new GeneralDAO();

        DataSet dslb = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntDistRemi"]));
        dslb = gen.GetLBDistwise(arr);
        gblObj.FillCombo(ddlLBNew, dslb, 1);
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
        gblObj.FillCombo(ddlFrm , dsfrm, 1);
    }

    private void FillCmbDT()
    {
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        DataSet ds1 = new DataSet();
        ArrayList arr1 = new ArrayList();
        arr1.Add(Session["IntTreIdRemi"]);
        ds1 = GenDao.getsubTreasury(arr1);
        gblObj.FillCombo(ddlsubTreas, ds1, 1);
    }

    private void FillComboChalanType()
    {
        gblObj = new clsGlobalMethods();
        GeneralDAO gen = new GeneralDAO();

        // DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
        DataTable dt = new DataTable();
        DataRow dr = null;
        DataColumn dcol1 = new DataColumn("Index", typeof(System.Int16));
        DataColumn dcol2 = new DataColumn("Type", typeof(System.String));
        dt.Columns.Add(dcol1);
        dt.Columns.Add(dcol2);
        dr = dt.NewRow();
        dr["Index"] = 2;
        dr["Type"] = "Deputation";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["Index"] = 3;
        dr["Type"] = "Extra From LB";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["Index"] = 4;
        dr["Type"] = "Misclassified";
        dt.Rows.Add(dr);
        gblObj.FillComboDirect(ddlchlType, dt, 1);

        ArrayList ar=new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(1);
        ds = gen.GetMisClassRsn(ar);
        gblObj.FillCombo(ddlRsnN,ds, 1);
        
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        //Session["intCCYearId"] = gendao.GetCCYearId();
        SetGridDefault();
        FillCmbFrm();
        SetGridDefaultOtherChal();
        if (Convert.ToDouble(txtAmt.Text) > 0)
        {
            pnlChalNew.Visible = true;
            Session["Sessionclear"] = 1;
            clearnewchalan();
            txtchlnId.Text = "0";
        }
        else
        {
            gblObj.MsgBoxOk("Enter Treasury consolidation!", this);
        }
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        schedDao = new ScheduleDAO();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        dsChal = schedDao.GetSchedDet4CorrEntryCurrCorr(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gen.GetCCYearId() + 1;
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
            cor.IntMonthID = mth;
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
                cor.IntTblTp = 2;
            cord.CreateCorrEntryCalcTblTp(cor);
            ///// Save to CorrEntry/////////
        }

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        GeneralDAO gendao = new GeneralDAO();
        //Session["intCCYearId"] = gendao.GetCCYearId();
        gblObj = new clsGlobalMethods();
        if (Convert.ToInt32(Session["intTreasuryDId"]) > 0)
        {
            if (txtChalDt.Text == "" || txtChalDt.Text == null)
            {
                gblObj.MsgBoxOk("Enter all details!", this);
            }
            else
            {
                SaveNewChalan();
                UpdateTreasuryD();
                gblObj.MsgBoxOk("Saved successfully!!!", this);
                clearnewchalan();
                pnlChalNew.Visible = false;
                FillChalanLb();
                FillChalanOther();
                if (Convert.ToInt16(Session["IntYearIdRemi"]) <= Convert.ToInt16(Session["intCCYearId"]))
                {
                    if (Convert.ToInt16(lblEditMode.Text) > 0)
                    {
                        SaveCorrectionEntryChal(Convert.ToInt32(txtchlnId.Text), Convert.ToInt16(lblEditMode.Text), Convert.ToInt16(Session["IntYearIdRemi"]), Convert.ToInt16(Session["IntMonthIdRemi"]), Convert.ToInt16(lblDy.Text));
                    }
                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Session expired!", this);
        }
    }

    //private void showcombo()
    //{
    //    ddlYear.SelectedValue = Session["IntYearIdRemi"].ToString();
    //    ddlMnth.SelectedValue = Session["IntMonthIdRemi"].ToString();
    //    ddldist.SelectedValue = Session["IntDistRemi"].ToString();
    //    DataSet dsTreas = new DataSet();
    //    ArrayList arr = new ArrayList();
    //    //DistId = Convert.ToInt32(DistId);
    //    arr.Add(Session["IntDistRemi"]);
    //    dsTreas = gen.GetDisTreasury(arr);
    //    gblObj.FillCombo(ddlDT, dsTreas, 1);
    //    ddlDT.SelectedValue = Session["IntTreIdRemi"].ToString();
    //}
    //private void fillChalanTotal()
    //{
    //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
    //    {
    //        chalantotal = Convert.ToInt32(chalantotal) + Convert.ToInt16(gdvchRem.Rows[i].Cells[3].Text.ToString());
    //    }
    //}
    private void FillChalanLb()
    {
        gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();

        ArrayList ar = new ArrayList();
        ar.Add(Session["IntYearIdRemi"]);
        ar.Add(Session["IntMonthIdRemi"]);
        ar.Add(Session["IntTreIdRemi"]);

        DataSet ds2 = new DataSet();
        ds2 = chDao.ChalanRemittance(ar);
        SetGridDefault();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gdvchRem.DataSource = ds2;
            gdvchRem.DataBind();
            fillgridCombo();
            for (int i = 0; i < gdvchRem.Rows.Count; i++)
            {
                if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[6].ToString()) > 0)
                {
                    GridViewRow grdVwRow = gdvchRem.Rows[i];
                    TextBox TxtChNo = (TextBox)grdVwRow.FindControl("txtChNo");
                    Label lblChalIdAss = (Label)grdVwRow.FindControl("lblChalId");
                    

                    LinkButton hlChAmount = (LinkButton)grdVwRow.FindControl("hlChAmount");
                    CheckBox chkApp = (CheckBox)grdVwRow.FindControl("chkApp");
                    CheckBox chkVAss = (CheckBox)grdVwRow.FindControl("chkV");
                    DropDownList ddlReason = (DropDownList)grdVwRow.FindControl("ddlReason");
                    DropDownList ddlFrmWhm = (DropDownList)grdVwRow.FindControl("ddlFrmWhm");

                    Label txtchlDt = (Label)grdVwRow.FindControl("txtchlDt");
                    txtchlDt.Text = ds2.Tables[0].Rows[i].ItemArray[13].ToString();

                    //Label lblSlNoLB = (Label)grdVwRow.FindControl("lblSlNoLB");
                    //lblSlNoLB.Text = (i + 1).ToString();

                    if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[6]) == 2)
                    {
                        chkApp.Checked = true;
                        ddlReason.Enabled = true;
                        ddlReason.SelectedValue = ds2.Tables[0].Rows[i].ItemArray[7].ToString();
                    }
                    else
                    {
                        chkApp.Checked = false;
                        ddlReason.Enabled = false;
                    }

                    if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[11]) == 1)
                    {
                        chkVAss.Checked = true;
                    }
                    else
                    {
                        chkVAss.Checked = false;
                        //chkApp.Checked = true;
                        //ddlReason.Enabled = true;
                        //ddlReason.SelectedValue = ds2.Tables[0].Rows[i].ItemArray[7].ToString();
                        //chkApp.Enabled = false;
                    }

                    ddlFrmWhm.SelectedValue = ds2.Tables[0].Rows[i].ItemArray[14].ToString();
                    lblChalIdAss.Text = ds2.Tables[0].Rows[i].ItemArray[0].ToString();
                    Session["NumChalanID"] = ds2.Tables[0].Rows[i].ItemArray[0].ToString();
                }
            }
            //gblObj.SetFooterTotalsGray(gdvchRem, 3);
            //gblObj.SetGridGrey(gdvchRem);
            //fillgridCombo();
        }
        else
        {
            SetGridDefault();
        }
        gblObj.SetFooterTotalsGray(gdvchRem, 3);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["IntYearIdRemi"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["IntYearIdRemi"] = 0;
        }
        ClearCtrl();
        ddlMnth.SelectedValue = "0";
        ddldist.SelectedValue = "0";
        ddlDT.SelectedValue = "0";
        //if (Convert.ToInt16(Session["IntYearIdRemi"]) > 0 && Convert.ToInt16(Session["IntMonthIdRemi"]) > 0 && Convert.ToInt16(Session["IntTreIdRemi"]) > 0)
        //{
        //    FillTxts();
        //    FillChalanLb();
        //    FillChalanOther();
        //}
    }
    private void fillgridCombo()
    {
        gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();

        ArrayList arr = new ArrayList();
        arr.Add(1);
        DataSet dsrsn = new DataSet();
        dsrsn = GenDao.getReason(arr);


        ArrayList arr1 = new ArrayList();
        arr1.Add(1);
        DataSet dsfrm = new DataSet();
        dsfrm = GenDao.getFromWhom(arr1);


        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdvchRem.Rows[i];
            DropDownList ddlReasonAss = (DropDownList)grdVwRow.FindControl("ddlReason");
            gblObj.FillCombo(ddlReasonAss, dsrsn, 1);
            ddlReasonAss.Enabled = false;


            DropDownList ddlFrmWhm = (DropDownList)grdVwRow.FindControl("ddlFrmWhm");
            gblObj.FillCombo(ddlFrmWhm, dsfrm, 1);
        }
    }
    protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (ddlMnth.SelectedIndex > 0)
        {
            Session["IntMonthIdRemi"] = Convert.ToInt16(ddlMnth.SelectedValue);
            gblObj.CheckValidMonth(Convert.ToInt16(Session["IntYearIdRemi"]), Convert.ToInt16(Session["IntMonthIdRemi"]), this, txtAmt);
        }
        else
        {
            Session["IntMonthIdRemi"] = 0;
        }
        ClearCtrl();
        Session["intTreasuryDId"] = 0;
        ddldist.SelectedValue = "0";
        ddlDT.SelectedValue = "0";
        //if (Convert.ToInt16(Session["IntYearIdRemi"]) > 0 && Convert.ToInt16(Session["IntMonthIdRemi"]) > 0 && Convert.ToInt16(Session["IntTreIdRemi"]) > 0)
        //{
        //    FillTxts();
        //    FillChalanLb();
        //    FillChalanOther();
        //}
    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvchRem.Rows[index];

        CheckBox chkApp = (CheckBox)gdvr.FindControl("chkApp");
        DropDownList ddlReason = (DropDownList)gdvr.FindControl("ddlReason");
        if (chkApp.Checked == true)
        {
            ddlReason.Enabled = true;
        }
        else
        {
            ddlReason.Enabled = false;
        }
    }
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {
        GridView gdv = gdvchRem;
        CheckBox chkAll = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchRem.Rows[i];
            CheckBox ChkApp = (CheckBox)gvr.FindControl("chkV");
            if (chkAll.Checked == true)
            {
                ChkApp.Checked = true;
            }
            else
            {
                ChkApp.Checked = false;
            }
        }
    }
    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldist.SelectedIndex > 0)
        {
            Session["IntDistRemi"] = Convert.ToInt32(ddldist.SelectedValue);
        }
        else
        {
            Session["IntDistRemi"] = 0;
        }
        FillDT();
        FillCmbLb(); 
        FillComboChalanType();
        pnlChalNew.Visible = false;

        ClearCtrl();
        Session["intTreasuryDId"] = 0;
        ddlDT.SelectedValue = "0";
    }
    private void FillDT()
    {
        gblObj = new clsGlobalMethods();
        GeneralDAO gen = new GeneralDAO();

        DataSet dsTreas = new DataSet();
        ArrayList arrd = new ArrayList();
        arrd.Add(Convert.ToInt16(Session["IntDistRemi"]));
        dsTreas = gen.GetDisTreasury(arrd);
        gblObj.FillCombo(ddlDT, dsTreas, 1);
    }
    protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (ddlDT.SelectedIndex > 0)
        {
            Session["IntTreIdRemi"] = Convert.ToInt32(ddlDT.SelectedValue);
        }
        else
        {
            Session["IntTreIdRemi"] = 0;
            ClearCtrl();
        }
        if (Convert.ToInt16(Session["IntYearIdRemi"]) > 0 && Convert.ToInt16(Session["IntMonthIdRemi"]) > 0 && Convert.ToInt16(Session["IntTreIdRemi"]) > 0)
        {
            FillTxts();
            FillCmbDT();
            SetCtrls();      // on 29/01/2020
        }
        else
        {
            Session["intTreasuryDId"] = 0;
            SetGridDefault();
            SetGridDefaultOtherChal();
            gblObj.MsgBoxOk("Select all!", this);
        }
        //ClearCtrl();
        SetGridDefault();
        SetGridDefaultOtherChal();
    }
    private void FillTotLbl()
    {
        lblTotA.Text = Convert.ToString(FindVerfdTot() + Convert.ToDouble(gdvchNonLB.FooterRow.Cells[4].Text));
        if (txtAmt.Text != "" && txtAmt.Text != "0")
        {
            if (Convert.ToDouble(lblTotA.Text) != Convert.ToDouble(txtAmt.Text))
            {
                lblTotA.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblTotA.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    private double FindVerfdTot()
    {
        double verAmt = 0;
        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gdv = gdvchRem.Rows[i];
            CheckBox chkV = (CheckBox)gdv.FindControl("chkV");
            if (chkV.Checked == true)
            {
                verAmt = verAmt + Convert.ToDouble(gdvchRem.Rows[i].Cells[3].Text);
            }
        }
        return verAmt;
    }
    //private double FindTreasId()
    //{
    //    double fltAmt = 0;
    //    DataSet ds = new DataSet();
    //    ArrayList arr = new ArrayList();
    //    arr.Add(Session["IntYearIdRemi"]);
    //    arr.Add(Session["IntMonthIdRemi"]);
    //    arr.Add(Session["IntTreIdRemi"]);
    //    arr.Add(1);
    //    ds = chDao.GetAmtLBTot(arr);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        fltAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[1]);
    //    }
    //    return fltAmt;
    //}
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvTreasuryName");
        ar.Add("chvEngLBName");
        ar.Add("numChalanId");
        ar.Add("ChNodtChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("flgApproval");
        gblObj.SetGridDefault(gdvchRem, ar);
        gblObj.SetFooterTotals(gdvchRem, 3);
        //gblObj.SetGridGrey(gdvchRem);

        GridViewRow gvr = gdvchRem.Rows[0];
        gvr.Cells[2].Enabled = false;

    }
    private void SetGridDefaultOtherChal()
    {
        gblObj = new clsGlobalMethods();

        //ArrayList ar = new ArrayList();
        //ar.Add("SlNo");
        //ar.Add("numChalanId");
        //ar.Add("intChalanNo");
        //ar.Add("dtChalanDate");
        //ar.Add("fltChalanAmt");
        //ar.Add("flgUnposted");
        //ar.Add("flgChalanType");
        //gblObj.SetGridDefault(gdvchNonLB, ar);
        //gblObj.SetFooterTotals(gdvchNonLB, 4);

        //FillNonLBgridCombo();
        //FillGdvComboChalanType();

        ArrayList ar = new ArrayList();
        ar.Add("chvTreasuryName");
        ar.Add("chvEngLBName");
        ar.Add("numChalanId");
        ar.Add("dtChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("flgUnposted");
        ar.Add("chvChalanType");
        ar.Add("intChalanNo");
        ar.Add("flgChalanType");
        ar.Add("chvUnPostedRsn");
        ar.Add("charType");

        gblObj.SetGridDefault(gdvchNonLB, ar);
        gblObj.SetFooterTotals(gdvchNonLB, 4);


        GridViewRow gvr = gdvchNonLB.Rows[0];
        gvr.Cells[9].Enabled = false;

    }
    //private void UpdateTreasuryDetails()
    //{
    //    ArrayList arr = new ArrayList();
    //    double trnamt = 0;
    //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
    //    {
    //        GridViewRow gdv = gdvchRem.Rows[i];
    //        LinkButton hlChAmount = (LinkButton)gdv.FindControl("hlChAmount");
    //        trnamt = trnamt + Convert.ToInt16(hlChAmount.Text.ToString());
    //    }
    //    arr.Add(Session["IntYearIdRemi"]);
    //    arr.Add(Session["IntMonthIdRemi"]);
    //    arr.Add(Session["IntTreIdRemi"]);
    //    arr.Add(1);
    //    arr.Add(trnamt);
    //    chDao.UpdateTreasuryD(arr);
    //}
    //private void SaveToChalan()
    //{

    //    for (int i = 0;i < gdvchRem.Rows.Count; i++)
    //    {
    //        DataSet ds = new DataSet();
    //        ArrayList arr = new ArrayList();
    //        GridViewRow gdvrw = gdvchRem.Rows[i];
    //        CheckBox chkAss = (CheckBox) gdvrw.FindControl("chkApp");
    //        DropDownList ddlRsnass =(DropDownList) gdvrw.FindControl("ddlReason");
    //        LinkButton hlChAmount = (LinkButton)gdvrw.FindControl("hlChAmount");
    //        int chalanID = Convert.ToInt16(gdvchRem.Rows[i].Cells[5].Text.ToString());
    //        arr.Add(chalanID);
    //        if (chkAss.Checked == true)
    //        {
    //            if (ddlRsnass.SelectedIndex > 0)
    //            {
    //                arr.Add(2);
    //                arr.Add(ddlRsnass.SelectedValue);
    //            }
    //            else
    //            {
    //                gblObj.MsgBoxOk("Please Select Reason",this);
    //                break;
    //            }
    //            //arr.Add(0);
    //        }
    //        else
    //        {
    //            //arr.Add(Convert.ToInt16(gdvchRem.Rows[i].Cells[3].Text.ToString()));
    //           // arr.Add(Convert.ToInt16(hlChAmount.Text.ToString()));
    //            arr.Add(1);
    //            arr.Add(ddlRsnass.SelectedValue);
    //            //arr.Add(0);
    //        }
    //        chDao.Updatchalan(arr);
    //        gblObj.MsgBoxOk("Updated", this);
    //    }
    //}
    private void SaveTreasuryDetails()
    {
        ChalanDAO chDao = new ChalanDAO();

        ArrayList arr = new ArrayList();
        //arr.Add(2);
        arr.Add(Session["IntYearIdRemi"]);
        arr.Add(Session["IntMonthIdRemi"]);
        arr.Add(Session["IntTreIdRemi"]);
        arr.Add(1);
        arr.Add(Convert.ToDouble(txtAmt.Text.ToString()));
        //arr.Add(DateTime.Now);
        arr.Add(Session["intUserId"]);
        if (chkVerified.Checked == true)
        {
            arr.Add(10);
        }
        else
        {
            arr.Add(0);
        }
        arr.Add(" ");
        arr.Add(txtInt.Text.ToString());
        arr.Add(0);
        //if (Convert.ToInt64(gdvchRem.Rows[0].Cells[3].Text) > 0)
        //{
        //    arr.Add(Convert.ToDouble(gdvchRem.FooterRow.Cells[3].Text));
        //}
        //else
        //{
        //    arr.Add(0);
        //}

        if (Convert.ToInt64(lblTotA.Text) > 0)
        {
            arr.Add(Convert.ToDouble(lblTotA.Text));
        }
        else
        {
            arr.Add(0);
        }

        arr.Add(txtRem.Text.ToString());
        DataSet ds = chDao.SaveChalanToTreasuryD(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["intTreasuryDId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        }
    }
    private double FindAmt(int tp)
    {
        double fltAmt = 0;
        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
            Label lblAmountN = (Label)gvr.FindControl("lblAmountN");
            if (Convert.ToDouble(lblAmountN.Text) > 0)
            {
                if (lblAmountN.Text.ToString() != "")
                {
                    if (Convert.ToInt16(lblChalTp.Text) == tp)
                    {
                        fltAmt = fltAmt + Convert.ToDouble(lblAmountN.Text);
                    }
                }
            }
        }
        return fltAmt;
    }
    protected void btnEntry_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        //if (Convert.ToDouble(gdvchRem.Rows[0].Cells[3].Text) > 0)
        //{
        if ((txtInt.Text.ToString() == "") || (txtAmt.Text.ToString() == ""))
        {
            gblObj.MsgBoxOk("Enter All Details Above", this);
        }
        else
        {
            if (chkShow.Checked == true)
            {
                SaveTreasuryDetails();
                gblObj.MsgBoxOk("Saved", this);
            }
            else
            {
                gblObj.MsgBoxOk("Check Show and then Save!", this);
            }
        }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("No chalans availble!", this);
        //}
    }
    private void FillTxts()
    {
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Session["IntYearIdRemi"]);
        arr.Add(Session["IntMonthIdRemi"]);
        arr.Add(Session["IntTreIdRemi"]);
        arr.Add(1);
        ds = GenDao.GetEntryDetail(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtInt.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtRem.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtAmt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["intTreasuryDId"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[4]);
            Session["flgAppTOnline"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]);
            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]) == 10 || Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]) == 1 || Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]) == 2)
            {
                chkVerified.Checked = true;
            }
            else
            {
                chkVerified.Checked = false;
            }
            btnTreasRpt.Enabled = true;
        }
        else
        {
            Session["intTreasuryDId"] = 0;
            ClearCtrl();
            Session["flgAppTOnline"] = 0;
            btnTreasRpt.Enabled = false;
        }
        //else
        //{
        //    txtInt.Text = "";
        //    txtRem.Text = "";
        //    txtAmt.Text = "";
        //    Session["flgAppTOnline"] = 0;
        //}
    }
    private void ClearCtrl()
    {
        txtInt.Text = "";
        txtRem.Text = "";
        txtAmt.Text = "0";
        Session["flgAppTOnline"] = 0;
        //IntTreIdRemi
        SetGridDefault();
        SetGridDefaultOtherChal();
        chkShow.Checked = false;
        lblTotA.Text = "...";
    }
    private void FillGdvComboChalanType()
    {
        gblObj = new clsGlobalMethods();

        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
            DataTable dt = new DataTable();
            DataRow dr = null;
            DataColumn dcol1 = new DataColumn("Index", typeof(System.Int16));
            DataColumn dcol2 = new DataColumn("Type", typeof(System.String));
            dt.Columns.Add(dcol1);
            dt.Columns.Add(dcol2);
            dr = dt.NewRow();
            dr["Index"] = 2;
            dr["Type"] = "Deputation";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Index"] = 3;
            dr["Type"] = "Extra From LB";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Index"] = 4;
            dr["Type"] = "Misclassified";
            dt.Rows.Add(dr);
            gblObj.FillComboDirect(ddlChalan, dt, 1);
        }
    }
    private void FillChalanOther()
    {
        gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["intTreasuryDId"] != null)
        {
            arr.Add(Session["intTreasuryDId"]);
        }
        else
        {
            Session["intTreasuryDId"] = 0;
            arr.Add(0);
        }
        ds = chDao.RemitanceNonLB(arr);
        SetGridDefaultOtherChal();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvchNonLB.DataSource = ds;
            gdvchNonLB.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvchNonLB.Rows[i];
                Label lblSlNo = (Label)gvr.FindControl("lblSlNo");
                lblSlNo.Text = Convert.ToString(i + 1);

                Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
                lblChalTp.Text = ds.Tables[0].Rows[i].ItemArray[7].ToString();

                Label lblAmountN = (Label)gvr.FindControl("lblAmountN");
                lblAmountN.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
                Label txtchlId = (Label)gvr.FindControl("txtchlId");
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[10].ToString()) == 2)
                {
                    chkNonUnpost.Checked = true;
                }
                else
                {
                    chkNonUnpost.Checked = false;
                }
                txtchlId.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            }
        }
        gblObj.SetFooterTotals(gdvchNonLB, 4);
    }
    private void FillNonLBgridCombo()
    {
        gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        ChalanDAO chDao = new ChalanDAO();
        GeneralDAO gen = new GeneralDAO();

        DataSet ds1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Session["IntTreIdRemi"]);
        ds1 = GenDao.getsubTreasury(arr);
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Session["IntDistRemi"]);
        //arrIn.Add(5);
        ds = gen.GetLBDistwise(arrIn);
        DataSet ds2 = new DataSet();
        ArrayList arrre = new ArrayList();
        arrre.Add(1);
        ds2 = chDao.Fillreason(arrre);
        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
            gblObj.FillCombo(ddlSubTre, ds1, 1);
            DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
            gblObj.FillCombo(ddlInst, ds, 1);
            DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
            gblObj.FillCombo(ddlReson, ds2, 1);
            ddlReson.Enabled = false;
        }
    }
    protected void lbAddrow_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (ViewState["nonRemi"] != null)
        {
            DataTable dt = (DataTable)ViewState["nonRemi"];
            int count = gdvchNonLB.Rows.Count;
            ArrayList arrIN = new ArrayList();
            arrIN.Add("ddlSubTre");
            arrIN.Add("txtNonLBChNo");
            arrIN.Add("txtNonChDate");
            arrIN.Add("txtNonLBAmount");
            arrIN.Add("ddlInst");
            arrIN.Add("ddlChalan");
            arrIN.Add("chkNonUnpost");
            arrIN.Add("ddlReson");
            arrIN.Add("btnAddrow");
            dt = gblObj.AddNewRowToGrid(dt, gdvchNonLB, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList ddlSubTre = (DropDownList)gdvchNonLB.Rows[count].FindControl("ddlSubTre");
            DropDownList ddlInst = (DropDownList)gdvchNonLB.Rows[count].FindControl("ddlInst");
            DropDownList ddlChalan = (DropDownList)gdvchNonLB.Rows[count].FindControl("ddlChalan");
            DropDownList ddlReson = (DropDownList)gdvchNonLB.Rows[count].FindControl("ddlReson");
            gblObj.setFocus(ddlSubTre, this);
            //}
            FillNonLBgridCombo();
            FillGdvComboChalanType();
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList DdlSubTre = (DropDownList)gdvchNonLB.Rows[i].FindControl("ddlSubTre");
                DdlSubTre.SelectedValue = dt.Rows[i].ItemArray[1].ToString();
                DropDownList DdlInst = (DropDownList)gdvchNonLB.Rows[i].FindControl("ddlInst");
                DdlInst.SelectedValue = dt.Rows[i].ItemArray[5].ToString();
                DropDownList DdlChalan = (DropDownList)gdvchNonLB.Rows[i].FindControl("ddlChalan");
                DdlChalan.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
                DropDownList DdlReson = (DropDownList)gdvchNonLB.Rows[i].FindControl("ddlReson");
                DdlInst.SelectedValue = dt.Rows[i].ItemArray[8].ToString();
            }
        }
    }
    protected void btnNonLBSave_Click(object sender, EventArgs e)
    {
        //clsGlobalMethods gblObj = new clsGlobalMethods();

        //if (Convert.ToString(txtInt.Text) != "" && Convert.ToDouble(txtAmt.Text) > 0)
        //{
        //    SaveExtraLBChalan();
        //    UpdateTreasuryD();

        //    FillChalanLb();
        //    FillChalanOther();
        //    AddApproval();

        //    gblObj.MsgBoxOk("Saved!", this);
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter all details!", this);
        //}
    }
    private void AddApproval()
    {
        gblObj = new clsGlobalMethods();
        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            Label txtchlIdAss = (Label)gvr.FindControl("txtchlId");
            gblObj.UppdApproval(1, Convert.ToInt32(txtchlIdAss.Text), 20, Convert.ToInt32(Session["intUserId"]), "");
        }
    }
    //private void DeleteFromExtra()
    //{
    //    // delete from Chalan as TAGId = ? and type = 2 or 3 
    //    // delete from ChalanOther as TAGId = ?

    //    ArrayList ar = new ArrayList();
    //    ar.Add(Convert.ToDouble(Session["intTreasuryDId"]));
    //    chDao.DeleteChalanExtra(ar);
    //}
    private void UpdateChalanLB()
    {
        ChalanDAO chDao = new ChalanDAO();

        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            ArrayList arn = new ArrayList();
            GridViewRow gvr = gdvchRem.Rows[i];
            Label lblChalIdAss = (Label)gvr.FindControl("lblChalId");
            CheckBox chkVAss = (CheckBox)gvr.FindControl("chkV");
            CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
            DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
            DropDownList ddlFrmWhm = (DropDownList)gvr.FindControl("ddlFrmWhm");


            arn.Add(Convert.ToInt64(lblChalIdAss.Text));
            arn.Add(Convert.ToInt32(Session["intTreasuryDId"]));
            //if (chkVAss.Checked == true)
            //{
            //    arn.Add(1);
            //    if (chkAppAss.Checked == true)
            //    {
            //        arn.Add(2);
            //        arn.Add(Convert.ToInt16(ddlReason.SelectedValue));
            //    }
            //    else
            //    {
            //        arn.Add(1);
            //        arn.Add(0);
            //    }
            //}
            //else
            //{
            //    arn.Add(2);
            //    arn.Add(2);
            //    arn.Add(1);
            //}
            if (chkVAss.Checked == true)
            {
                arn.Add(1);
            }
            else
            {
                arn.Add(2);
            }
            if (chkAppAss.Checked == true)
            {
                arn.Add(2);
                arn.Add(Convert.ToInt16(ddlReason.SelectedValue));
            }
            else
            {
                arn.Add(1);
                arn.Add(0);
            }
            arn.Add(Convert.ToInt16(ddlFrmWhm.SelectedValue));
            chDao.UpdateChalTreasId(arn);
            FillTotLbl();
        }
    }
    private void UpdateTreasuryD()
    {
        ChalanDAO chDao = new ChalanDAO();

        ArrayList arn = new ArrayList();
        arn.Add(Convert.ToInt32(Session["intTreasuryDId"]));
        arn.Add(FindAmt(3));
        arn.Add(FindAmt(2));
        arn.Add(FindAmt(4));
        arn.Add(FindAmtLB());
        arn.Add(1);
        chDao.UpdateTreasuryDMiss(arn);
    }
    private double FindAmtLB()
    {
        double fltAmt = 0;
        fltAmt = Convert.ToDouble(gdvchRem.FooterRow.Cells[3].Text.ToString());
        //for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvchRem.Rows[i];
        //    DropDownList ddlChalanAss = (DropDownList)gvr.FindControl("ddlChalan");
        //    TextBox txtNonLBAmountAss = (TextBox)gvr.FindControl("txtNonLBAmount");
        //    //if (Convert.ToDouble(txtNonLBAmountAss.Text) > 0)
        //    if (txtNonLBAmountAss.Text.ToString() != "")
        //    {
        //        if (Convert.ToInt16(ddlChalanAss.SelectedValue) == tp)
        //        {
        //            fltAmt = fltAmt + Convert.ToDouble(txtNonLBAmountAss.Text);
        //        }
        //    }
        //}
        return fltAmt;
    }
    //private void SaveExtraLBChalan()
    //{
    //    for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
    //    {
    //        DataSet ds = new DataSet();
    //        GridViewRow gvr = gdvchNonLB.Rows[i];
    //        TextBox txtNonLBAmountAss = (TextBox)gvr.FindControl("txtNonLBAmount");
    //        DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
    //        DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
    //        TextBox txtNonLBChNo = (TextBox)gvr.FindControl("txtNonLBChNo");
    //        TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
    //        Label txtchlIdAss = (Label)gvr.FindControl("txtchlId");
    //        DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
    //        if (CheckMandatory(txtNonLBAmountAss, txtNonLBChNo, txtNonChDate) == true)
    //        {
    //            ArrayList arrIn = new ArrayList();
    //            arrIn.Add(Convert.ToInt16(ddlSubTre.SelectedValue));
    //            arrIn.Add(Convert.ToInt16(txtNonLBChNo.Text));
    //            arrIn.Add(txtNonChDate.Text.ToString());
    //            arrIn.Add(Convert.ToDouble(txtNonLBAmountAss.Text));
    //            arrIn.Add(Session["intUserId"]);
    //            arrIn.Add(1);
    //            arrIn.Add(Convert.ToInt32(Session["intTreasuryDId"]));
    //            if (txtchlIdAss.Text == "")
    //            {
    //                arrIn.Add(0);
    //            }
    //            else
    //            {
    //                arrIn.Add(Convert.ToInt32(txtchlIdAss.Text));
    //            }
    //            arrIn.Add(Convert.ToInt16(ddlInst.SelectedValue));
    //            ds = chDao.SaveOtherChalan(arrIn);
    //        }
    //    }
    //}

    //private void SaveExtraLBChalan()
    //{
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    //    Chalan ch = new Chalan();
    //    ChalanDAO chDao = new ChalanDAO();

    //    for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
    //    {
    //        DataSet ds = new DataSet();
    //        //ch.NumChalanId = 0;// gblObj.NumChalanID;
    //        GridViewRow gvr = gdvchNonLB.Rows[i];
    //        TextBox txtNonLBAmountAss = (TextBox)gvr.FindControl("txtNonLBAmount");
    //        DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
    //        DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
    //        TextBox txtNonLBChNo = (TextBox)gvr.FindControl("txtNonLBChNo");
    //        TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
    //        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
    //        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
    //        Label txtchlIdAss = (Label)gvr.FindControl("txtchlId");
    //        DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");

    //        Label lblO = (Label)gvr.FindControl("lblO");
    //        Label lblN = (Label)gvr.FindControl("lblN");
    //        if (Convert.ToInt16(lblO.Text) > 0)
    //        {
    //            if (Convert.ToInt16(lblO.Text) != Convert.ToInt16(lblN.Text))
    //            {
    //                ArrayList arrin = new ArrayList();
    //                arrin.Add(Convert.ToInt32(txtchlIdAss.Text));
    //                arrin.Add(Convert.ToInt16(lblO.Text));
    //                chDao.UpdateChalanMode(arrin);
    //            }
    //        }
    //        if (CheckMandatory(txtNonLBAmountAss, txtNonLBChNo, txtNonChDate, ddlChalan) == true)
    //        {
    //            if (txtchlIdAss.Text == "")
    //            {
    //                ch.NumChalanId = 0;
    //            }
    //            else
    //            {
    //                ch.NumChalanId = Convert.ToInt32(txtchlIdAss.Text.ToString());
    //            }
    //            ch.IntTreasuryId = Convert.ToInt16(ddlSubTre.SelectedValue);
    //            ch.IntLBId = Convert.ToInt16(ddlInst.SelectedValue);
    //            ch.IntChalanNo = Convert.ToInt16(txtNonLBChNo.Text);                       //,[intChalanNo]
    //            ch.DtChalanDate = txtNonChDate.Text;                                        //,[dtChalanDate]
    //            ch.FltChalanAmt = Convert.ToDecimal(txtNonLBAmountAss.Text.ToString());                        //,[fltChalanAmt]
    //            ArrayList arr = new ArrayList();
    //            arr.Add(txtNonChDate.Text);
    //            int YearId = GenDao.FindYearIdFromDate(arr);
    //            ch.YearId = YearId;               //,[YearId]
    //            DateTime dtchal = Convert.ToDateTime(txtNonChDate.Text);
    //            int MonthId = dtchal.Month;
    //            ch.MonthId = Convert.ToInt16(MonthId);              //,[MonthId]
    //            ch.PerYearId = Convert.ToInt16(Session["IntYearIdRemi"]);                 //,[PerYearId]
    //            ch.PerMonthId = Convert.ToInt16(Session["IntMonthIdRemi"]);                //[PerMonthId]
    //            ch.ChvRemarks = " ";                                                      //,[chvRemarks]
    //            ch.IntUserId = Convert.ToInt64(Session["intUserId"]);                     //,[intUserId]

    //            if (chkNonUnpost.Checked == true)
    //            {
    //                ch.FlgUnposted = 2;   //,[flgUnposted]
    //                ch.IntUnPostedRsn = Convert.ToInt16(ddlReson.SelectedValue.ToString());    //[intUnPostedRsn]  
    //            }
    //            else
    //            {
    //                ch.FlgUnposted = 1;       //,[flgUnposted]
    //                ch.IntUnPostedRsn = 0;   //,[intUnPostedRsn]
    //            }
    //            ch.IntSlNo = FindSlNo(ch.IntLBId);     //,[intSlNo]
    //            ch.FlgSource = 1;       //,[flgSource]
    //            int intDay = dtchal.Day;
    //            ch.IntDay = intDay;      //,[intDay]
    //            ch.IntSthapnaBillID = 0;        //,[intSthapnaBillID]
    //            ch.FlgAmtMismatch = 0;       //,[flgAmtMismatch]

    //            ch.FlgChalanType = Convert.ToInt16(ddlChalan.SelectedValue);    //,[flgChalanType]
    //            if (ch.FlgChalanType <= 3)
    //            {
    //                ch.tENo = 0;    //,[TENo]
    //                ch.IntTreasuryDAGID = Convert.ToInt32(Session["intTreasuryDId"]);
    //                if (chalanValid(ch) == true)
    //                {
    //                    ds = chDao.CreateExtraChalan(ch);
    //                }
    //                else
    //                {
    //                    gblObj.MsgBoxOk("Chalan is  not valid " + ch.IntChalanNo, this);
    //                }
    //            }
    //            else
    //            {
    //                ArrayList arrIn = new ArrayList();
    //                //arrIn.Add(Convert.ToInt16(Session["IntTreIdRemi"]));
    //                arrIn.Add(Convert.ToInt16(ddlSubTre.SelectedValue));
    //                arrIn.Add(Convert.ToInt16(txtNonLBChNo.Text));
    //                arrIn.Add(txtNonChDate.Text.ToString());
    //                arrIn.Add(Convert.ToDouble(txtNonLBAmountAss.Text));
    //                arrIn.Add(Session["intUserId"]);
    //                arrIn.Add(1);
    //                arrIn.Add(Convert.ToInt32(Session["intTreasuryDId"]));
    //                arrIn.Add(ch.NumChalanId);
    //                arrIn.Add(Convert.ToInt16(ddlInst.SelectedValue));
    //                ds = chDao.SaveOtherChalan(arrIn);
    //            }
    //        }
    //    }
    //}
    //private void SaveExtraLBChalan()
    //{
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    //    Chalan ch = new Chalan();
    //    ChalanDAO chDao = new ChalanDAO();

    //    for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
    //    {
    //        DataSet ds = new DataSet();
    //        //ch.NumChalanId = 0;// gblObj.NumChalanID;
    //        GridViewRow gvr = gdvchNonLB.Rows[i];
    //        TextBox txtNonLBAmountAss = (TextBox)gvr.FindControl("txtNonLBAmount");
    //        DropDownList ddlSubTre = (DropDownList)gvr.FindControl("ddlSubTre");
    //        DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
    //        TextBox txtNonLBChNo = (TextBox)gvr.FindControl("txtNonLBChNo");
    //        TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
    //        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
    //        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
    //        Label txtchlIdAss = (Label)gvr.FindControl("txtchlId");
    //        DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");

    //        Label lblO = (Label)gvr.FindControl("lblO");
    //        Label lblN = (Label)gvr.FindControl("lblN");
    //        if (Convert.ToInt16(lblO.Text) > 0)
    //        {
    //            if (Convert.ToInt16(lblO.Text) != Convert.ToInt16(lblN.Text))
    //            {
    //                ArrayList arrin = new ArrayList();
    //                arrin.Add(Convert.ToInt32(txtchlIdAss.Text));
    //                arrin.Add(Convert.ToInt16(lblO.Text));
    //                chDao.UpdateChalanMode(arrin);
    //            }
    //        }
    //        if (CheckMandatory(txtNonLBAmountAss, txtNonLBChNo, txtNonChDate, ddlChalan) == true)
    //        {
    //            if (txtchlIdAss.Text == "")
    //            {
    //                ch.NumChalanId = 0;
    //            }
    //            else
    //            {
    //                ch.NumChalanId = Convert.ToInt32(txtchlIdAss.Text.ToString());
    //            }
    //            ch.IntTreasuryId = Convert.ToInt16(ddlSubTre.SelectedValue);
    //            ch.IntLBId = Convert.ToInt16(ddlInst.SelectedValue);
    //            ch.IntChalanNo = Convert.ToInt16(txtNonLBChNo.Text);                       //,[intChalanNo]
    //            ch.DtChalanDate = txtNonChDate.Text;                                        //,[dtChalanDate]
    //            ch.FltChalanAmt = Convert.ToDecimal(txtNonLBAmountAss.Text.ToString());                        //,[fltChalanAmt]
    //            ArrayList arr = new ArrayList();
    //            arr.Add(txtNonChDate.Text);
    //            int YearId = GenDao.FindYearIdFromDate(arr);
    //            ch.YearId = YearId;               //,[YearId]
    //            DateTime dtchal = Convert.ToDateTime(txtNonChDate.Text);
    //            int MonthId = dtchal.Month;
    //            ch.MonthId = Convert.ToInt16(MonthId);              //,[MonthId]
    //            ch.PerYearId = Convert.ToInt16(Session["IntYearIdRemi"]);                 //,[PerYearId]
    //            ch.PerMonthId = Convert.ToInt16(Session["IntMonthIdRemi"]);                //[PerMonthId]
    //            ch.ChvRemarks = " ";                                                      //,[chvRemarks]
    //            ch.IntUserId = Convert.ToInt64(Session["intUserId"]);                     //,[intUserId]

    //            if (chkNonUnpost.Checked == true)
    //            {
    //                ch.FlgUnposted = 2;   //,[flgUnposted]
    //                ch.IntUnPostedRsn = Convert.ToInt16(ddlReson.SelectedValue.ToString());    //[intUnPostedRsn]  
    //            }
    //            else
    //            {
    //                ch.FlgUnposted = 1;       //,[flgUnposted]
    //                ch.IntUnPostedRsn = 0;   //,[intUnPostedRsn]
    //            }
    //            ch.IntSlNo = FindSlNo(ch.IntLBId);     //,[intSlNo]
    //            ch.FlgSource = 1;       //,[flgSource]
    //            int intDay = dtchal.Day;
    //            ch.IntDay = intDay;      //,[intDay]
    //            ch.IntSthapnaBillID = 0;        //,[intSthapnaBillID]
    //            ch.FlgAmtMismatch = 0;       //,[flgAmtMismatch]

    //            ch.FlgChalanType = Convert.ToInt16(ddlChalan.SelectedValue);    //,[flgChalanType]
    //            if (ch.FlgChalanType <= 3)
    //            {
    //                ch.tENo = 0;    //,[TENo]
    //                ch.IntTreasuryDAGID = Convert.ToInt32(Session["intTreasuryDId"]);
    //                if (chalanValid(ch) == true)
    //                {
    //                    //ds = chDao.CreateExtraChalan(ch);

    //                    try
    //                    {
    //                        ds = chDao.CreateExtraChalan(ch);
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        string err = ex.Message;
    //                        gblObj.MsgBoxOk(err,this );
    //                        //ScriptManager.RegisterStartupScript(this, GetType(), err, "alert('Check the Error!!!');", true);
    //                    }
    //                }
    //                else
    //                {
    //                    gblObj.MsgBoxOk("Chalan is  not valid " + ch.IntChalanNo, this);
    //                }
    //            }
    //            else
    //            {
    //                ArrayList arrIn = new ArrayList();
    //                //arrIn.Add(Convert.ToInt16(Session["IntTreIdRemi"]));
    //                arrIn.Add(Convert.ToInt16(ddlSubTre.SelectedValue));
    //                arrIn.Add(Convert.ToInt16(txtNonLBChNo.Text));
    //                arrIn.Add(txtNonChDate.Text.ToString());
    //                arrIn.Add(Convert.ToDouble(txtNonLBAmountAss.Text));
    //                arrIn.Add(Session["intUserId"]);
    //                arrIn.Add(1);
    //                arrIn.Add(Convert.ToInt32(Session["intTreasuryDId"]));
    //                arrIn.Add(ch.NumChalanId);
    //                arrIn.Add(Convert.ToInt16(ddlInst.SelectedValue));
    //                ds = chDao.SaveOtherChalan(arrIn);
    //            }
    //        }
    //    }
    //}

    private int FindSlNo(int lb)
    {
        ChalanDAO chDao = new ChalanDAO();

        int slno = 1;
        DataSet dsSched = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearIdRemi"]));
        arr.Add(Convert.ToInt16(Session["IntMonthIdRemi"]));
        arr.Add(lb);

        dsSched = chDao.FindSlnofrmScheduleTR104(arr);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            slno = Convert.ToInt16(dsSched.Tables[0].Rows[0].ItemArray[0]);
        }
        return slno;
    }
    //private bool chalanValid(Chalan ch1)
    //{
    //    //ch1 = new Chalan();
    //    ChalanDAO chDao = new ChalanDAO();

    //    DataSet ds = new DataSet();
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(ch1.YearId);
    //    arrIn.Add(ch1.MonthId);
    //    arrIn.Add(ch1.IntDay);
    //    arrIn.Add(ch1.IntChalanNo);
    //    arrIn.Add(ch1.IntTreasuryId);
    //    arrIn.Add(ch1.FlgChalanType);
    //    ds = chDao.ChalannonLBValid(arrIn);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}

    //private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt)
    //{
    //    Boolean flg = true;
    //    if (Convert.ToDouble(txtAmt.Text) == 0 || Convert.ToInt16(txtNo.Text) == 0 || Convert.ToString(txtDt.Text) == "")
    //    {
    //        gblObj.MsgBoxOk("Enter all details!", this);
    //        flg = false;
    //    }
    //    else
    //    {
    //        flg = true;
    //    }
    //    return flg;
    //}
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt, DropDownList ddlCh, DropDownList ddltre)
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (txtAmt.Text == "" || txtAmt.Text == null || txtNo.Text == "" || txtNo.Text == null || txtDt.Text == "" || txtDt.Text == null || Convert.ToInt16(ddlCh.SelectedValue) == 0 || Convert.ToInt16(ddltre.SelectedValue) == 0)
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
    //private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt, DropDownList ddlCh, DropDownList ddltre)
    //{
    //    gblObj = new clsGlobalMethods();

    //    Boolean flg = true;
    //    if (Convert.ToDouble(txtAmt.Text) == 0 || Convert.ToInt32(txtNo.Text) == 0 || Convert.ToString(txtDt.Text) == "" || Convert.ToInt16(ddlCh.SelectedValue) == 0 || Convert.ToInt16(ddltre.SelectedValue) == 0)
    //    {
    //        gblObj.MsgBoxOk("Enter all details!", this);
    //        flg = false;
    //    }
    //    else
    //    {
    //        flg = true;
    //    }
    //    return flg;
    //}
    //private bool chalanValid()
    //{
    //    DataSet ds = new DataSet();
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(ch.YearId);
    //    arrIn.Add(ch.MonthId);
    //    arrIn.Add(ch.IntDay);
    //    arrIn.Add(ch.IntChalanNo);
    //    arrIn.Add(ch.IntTreasuryId);
    //    arrIn.Add(ch.FlgChalanType);
    //    ds = chDao.ChalannonLBValid(arrIn);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}

    protected void ddlInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdv = gdvchNonLB.Rows[index];
        DropDownList ddlInst = (DropDownList)gdv.FindControl("ddlInst");
        gblObj.OtherInst = Convert.ToInt16(ddlInst.SelectedValue);
    }
    protected void btnNonLBSched_Click1(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        // pnlLB.Enabled = true;
        Response.Redirect("ChalanSchedule.aspx?&intflg=" + gblObj.FlgChalanType);
    }

    //protected void chkNonUnpost_CheckedChanged(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
    //    {
    //        GridViewRow gdvr = gdvchNonLB.Rows[i];
    //        CheckBox chkNonUnpost = (CheckBox)gdvr.FindControl("chkNonUnpost");
    //        DropDownList ddlReson = (DropDownList)gdvr.FindControl("ddlReson");
    //        if (chkNonUnpost.Checked == true)
    //        {
    //            ddlReson.Enabled = true;
    //        }
    //        else
    //        {
    //            ddlReson.Enabled = false;
    //        }

    //    }
    //}
    //protected void chkAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    GridView gdv = gdvchNonLB;
    //    CheckBox chkAll = (CheckBox)gdv.HeaderRow.FindControl("chkAll");
    //    for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
    //    {
    //        GridViewRow gvr = gdvchNonLB.Rows[i];
    //        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
    //        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
    //        if (chkAll.Checked == true)
    //        {
    //            chkNonUnpost.Checked = true;
    //            ddlReson.Enabled = true;
    //        }
    //        else
    //        {
    //            chkNonUnpost.Checked = false;
    //            ddlReson.Enabled = false;
    //        }
    //    }

    //}
    protected void txtNonChDate_TextChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvchNonLB.Rows[index];
        TextBox txtNonChDate = (TextBox)gvr.FindControl("txtNonChDate");
        if (txtNonChDate.Text != "")
        {
            if (gblObj.isValidDate(txtNonChDate, this) == true)
            {
                if (gblObj.CheckChalanDate(txtNonChDate, ddlYear, ddlMnth) == true)
                {
                }
                else
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtNonChDate.Text = "";
            }
        }
    }
    protected void txtNonLBAmount_TextChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdr = gdvchNonLB.Rows[index];
        TextBox txtNonLBAmount = (TextBox)gdr.FindControl("txtNonLBAmount");

        gblObj.SetFooterTotalsTempField(gdvchNonLB, 5, "txtNonLBAmount", 1);
        //FillTotLbl();
    }
    //private double FindTotal(GridView gdv, TextBox txt1)
    //{
    //    double total = 0;
    //    for (int i = 0; i < gdv.Rows.Count; i++)
    //    {
    //        GridViewRow gdr = gdv.Rows[i];
    //        TextBox txtnew = (TextBox)gdr.FindControl("txt1");
    //        total = total + Convert.ToDouble(txt1.Text);
    //    }
    //    gdv.FooterRow.Cells[0].Text = "Total";
    //    gdv.FooterRow.Font.Bold = true;
    //    gdv.FooterRow.ForeColor = System.Drawing.Color.Blue;
    //    return total;

    //}
    protected void txtInt_TextChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        if (gblObj.isValidDate(txtInt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtInt, ddlYear, ddlMnth) == false)
            {
                gblObj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtInt.Text = "";
        }
    }
    private bool ValidIntimationdaterem(TextBox txtIntiDate)
    {
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();

        bool value = true;
        ArrayList arr = new ArrayList();
        int Yearid;
        arr.Add(txtIntiDate.Text);
        Yearid = GenDao.FindYearIdFromDate(arr);
        int MonthId = Convert.ToDateTime(txtIntiDate.Text).Month;
        DateTime dt = DateTime.Now;
        DataSet ds = new DataSet();
        ArrayList arr1 = new ArrayList();
        arr1.Add(Session["intMonthIdRemi"]);
        arr1.Add(Session["intYearIdRemi"]);
        ds = GenDao.GetDate(arr1);
        DateTime dt1 = new DateTime();
        dt1 = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[0]);
        if ((Yearid < Convert.ToInt16(Session["intYearIdRemi"]) || (dt1 > Convert.ToDateTime(txtIntiDate.Text)) || (dt <= Convert.ToDateTime(txtIntiDate.Text))))
        {
            value = false;
        }
        return value;
    }
    protected void ddlChalan_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        setControlDisabled(index);
        GridViewRow gvr = gdvchNonLB.Rows[index];
        DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
        Label lblN = (Label)gvr.FindControl("lblN");
        if (Convert.ToInt16(ddlChalan.SelectedValue) > 0)
        {
            lblN.Text = ddlChalan.SelectedValue.ToString();
        }
    }
    private void setControlDisabled(int i)
    {
        GridViewRow gvr = gdvchNonLB.Rows[i];
        DropDownList ddlChalan = (DropDownList)gvr.FindControl("ddlChalan");
        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
        if (Convert.ToInt16(ddlChalan.SelectedValue) == 4)
        {
            chkNonUnpost.Enabled = false;
            chkNonUnpost.Checked = true;
            ddlReson.Enabled = false;
            ddlReson.SelectedValue = 8.ToString();
        }
        else
        {
            chkNonUnpost.Enabled = true;
            ddlReson.SelectedIndex = 0;

            //ddlReson.Enabled = true;
        }
    }
    protected void lnksch_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvchNonLB.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchNonLB.Rows[i];
            LinkButton lnkschAss = (LinkButton)gvr.FindControl("lnksch");
            lnkschAss.PostBackUrl = "~/Contents/ChalanEditNew.aspx";
        }
    }
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        //clsGlobalMethods gblObj = new clsGlobalMethods();

        //List<Control> myControls = creategdFloorControl();
        //ArrayList arrControlid = creategdFloorControlId();
        //ArrayList arrDT = getDataTablegdFloor();
        //bool chkLastRow = gblObj.checkLastRowStatus(myControls, arrControlid, gdvchNonLB);
        //if (chkLastRow)
        //{
        //    DataTable dtgdRow = gblObj.AddNewRow(myControls, arrControlid, arrDT, gdvchNonLB);
        //    DataSet ds = new DataSet();
        //    gdvchNonLB.DataSource = dtgdRow;
        //    gdvchNonLB.DataBind();
        //    ds.Tables.Add(dtgdRow);
        //    fillDropDownGridExistsFloor(gdvchNonLB, ds);
        //}

    }
    //private List<Control> creategdFloorControl()
    //{
    //    List<Control> myControls = new List<Control>();
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new CheckBox());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new LinkButton());


    //    return myControls;
    //}
    //private ArrayList creategdFloorControlId()
    //{
    //    ArrayList arrControlid = new ArrayList();

    //    arrControlid.Add("ddlSubTre");
    //    arrControlid.Add("txtNonLBChNo");
    //    arrControlid.Add("txtNonChDate");
    //    arrControlid.Add("txtNonLBAmount");
    //    arrControlid.Add("ddlInst");
    //    arrControlid.Add("ddlChalan");
    //    arrControlid.Add("chkNonUnpost");
    //    arrControlid.Add("ddlReson");
    //    arrControlid.Add("lnksch");

    //    return arrControlid;
    //}
    //private ArrayList getDataTablegdFloor()
    //{
    //    ArrayList arrControlid = new ArrayList();
    //    // arrControlid.Add("SlNo");
    //    arrControlid.Add("intTreasuryId");
    //    arrControlid.Add("intChalanNo");
    //    arrControlid.Add("dtChalanDate");
    //    arrControlid.Add("fltChalanAmt");
    //    arrControlid.Add("intLBId");
    //    arrControlid.Add("flgChalanType");
    //    arrControlid.Add("flgUnposted");
    //    arrControlid.Add("intUnPostedRsn");
    //    arrControlid.Add("numChalanId");


    //    return arrControlid;
    //}
    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        //myControls.Add(new CheckBox());
        //myControls.Add(new DropDownList());
        myControls.Add(new Label());
        return myControls;
    }

    private ArrayList creategdFloorControlId()
    {

        ArrayList arrControlid = new ArrayList();
        arrControlid.Add("ddlSubTre");
        arrControlid.Add("txtNonLBChNo");
        arrControlid.Add("txtNonChDate");
        arrControlid.Add("txtNonLBAmount");
        arrControlid.Add("ddlInst");
        arrControlid.Add("ddlChalan");
        //arrControlid.Add("chkNonUnpost");
        //arrControlid.Add("ddlReson");
        arrControlid.Add("txtchlId");
        return arrControlid;

    }

    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();
        // arrControlid.Add("SlNo");
        arrControlid.Add("intTreasuryId");
        arrControlid.Add("intChalanNo");
        arrControlid.Add("dtChalanDate");
        arrControlid.Add("fltChalanAmt");
        arrControlid.Add("intLBId");
        arrControlid.Add("flgChalanType");
        //arrControlid.Add("flgUnposted");
        //arrControlid.Add("intUnPostedRsn");
        arrControlid.Add("numChalanId");
        return arrControlid;
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();
        schedDao = new ScheduleDAO();
        GeneralDAO gendao = new GeneralDAO();
        //Session["intCCYearId"] = gendao.GetCCYearId();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label txtchlIdAss = (Label)gdvchNonLB.Rows[rowIndex].FindControl("txtchlId");
        Label lblChalTp = (Label)gdvchNonLB.Rows[rowIndex].FindControl("lblChalTp");
        Label txtchlDt = (Label)gdvchRem.Rows[rowIndex].FindControl("txtchlDt");
        if (txtchlIdAss.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            //int a = Convert.ToInt16(Session["IntYearIdRemi"]);
            //int b = Convert.ToInt16(Session["intCCYearId"]);

            if (Convert.ToInt16(Session["IntYearIdRemi"]) <= Convert.ToInt16(Session["intCCYearId"]))
            {
                CorrectionEntryForDel(Convert.ToInt32(txtchlIdAss.Text), txtchlDt.Text.ToString()); //Corr Entry
            }
            string strDt = gdvchNonLB.Rows[rowIndex].Cells[3].Text.ToString();
            arrin.Add(Convert.ToInt32(txtchlIdAss.Text));
            arrin.Add(Convert.ToInt16(lblChalTp.Text));
            chDao.UpdateChalanMode(arrin);
            schedDao.UpdScheduleDel(arrin);
            //Build April2022
            ArrayList procin = new ArrayList();
            procin.Add("Remittance.aspx-Remittance_MisClassified-btnDelete_Click-event-update chalan and shedule mode of change to 4 (numChalanID is the ID param)");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(txtchlIdAss.Text));
            chDao.Processtracking(procin); 
        }

        gblObj.MsgBoxOk("Row Deleted   !", this);
        FillChalanOther();



        //clsGlobalMethods gblObj = new clsGlobalMethods();
        //ChalanDAO chDao = new ChalanDAO();

        //int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        ////  int rowIndex = Convert.ToInt32(e.RowIndex);

        //Label txtchlIdAss = (Label)gdvchNonLB.Rows[rowIndex].FindControl("txtchlId");
        //Label lblChalTp = (Label)gdvchNonLB.Rows[rowIndex].FindControl("lblChalTp");
        //if (txtchlIdAss.Text.ToString() != "")
        //{
        //    ArrayList arrin = new ArrayList();
        //    arrin.Add(Convert.ToInt32(txtchlIdAss.Text));
        //    arrin.Add(Convert.ToInt16(lblChalTp.Text));
        //    try
        //    {
        //        chDao.UpdateChalanMode(arrin);
        //        //deleteUnsavedchRem();
        //    }
        //    catch (Exception ex)
        //    {
        //        Session["ERROR"] = ex.ToString();
        //        Response.Redirect("Error.aspx");
        //    }
        //}

        //gblObj.MsgBoxOk("Row Deleted   !", this);
        //FillChalanOther();
    }
    private void deleteUnsavedchRem()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblObj.deleteRows(myControls, arrControlid, arrDT, gdvchNonLB);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvchNonLB.DataSource = dtgdRow;
            gdvchNonLB.DataBind();
            ds.Tables.Add(dtgdRow);
            // fillDropDownGridExistsFloor(gdvCM, ds);
        }
        else
        {
            FillChalanOther();
        }
    }
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {
        FillNonLBgridCombo();
        FillGdvComboChalanType();
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arrin = new ArrayList();
                    arrin.Add(Session["intLBID"].ToString());
                    DropDownList ddlSubTreAss = (DropDownList)gdRow.FindControl("ddlSubTre");
                    DropDownList ddlInstAss = (DropDownList)gdRow.FindControl("ddlInst");
                    DropDownList ddlChalanAss = (DropDownList)gdRow.FindControl("ddlChalan");
                    //DropDownList ddlResonAss = (DropDownList)gdRow.FindControl("ddlReson");

                    ddlSubTreAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][0].ToString();
                    ddlInstAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][4].ToString();
                    ddlChalanAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][5].ToString();
                    //ddlResonAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][7].ToString();

                    //CheckBox chkNonUnpost = (CheckBox)gdRow.FindControl("chkNonUnpost");
                    //if ((ds.Tables[0].Rows[gdRow.RowIndex][6].ToString()) != "")
                    //{
                    //    if (Convert.ToBoolean(ds.Tables[0].Rows[gdRow.RowIndex][6]) == true)
                    //    {
                    //        chkNonUnpost.Checked = true;
                    //    }
                    //    else
                    //    {
                    //        chkNonUnpost.Checked = false;
                    //    }
                    //}
                }
            }
        }
    }
    protected void btnTreasRpt_Click(object sender, EventArgs e)
    {
        //if(Convert.ToDouble(gdvchRem.Rows[0].Cells[3].Text) > 0 )
        //{
        //Response.Redirect("RemittanceCurr.aspx");
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter details", this);
        //}

        //clsGlobalMethods gblObj = new clsGlobalMethods();

        //if (Convert.ToDouble(gdvchRem.FooterRow.Cells[3].Text.ToString()) > 0)
        //{
            Response.Redirect("RemittanceCurr.aspx");
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter details", this);
        //}
    }
    protected void btnLBSave_Click(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        if (Convert.ToInt32(Session["intTreasuryDId"]) > 0)
        {
            UpdateChalanLB();   //Update TreasuryDId in Chalan tbl.
            gblObj.MsgBoxOk("Saved!", this);
        }
        else
        {
            gblObj.MsgBoxOk("Enter all values!", this);
        }
    }
    protected void chkV_CheckedChanged(object sender, EventArgs e)
    {

        //for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //{
        //    GridViewRow gdvr = gdvchRem.Rows[i];
        //    CheckBox chkApp = (CheckBox)gdvr.FindControl("chkApp");
        //    CheckBox chkV = (CheckBox)gdvr.FindControl("chkV");
        //    DropDownList ddlReason = (DropDownList)gdvr.FindControl("ddlReason");
        //    if (chkV.Checked == false)
        //    {
        //        chkApp.Checked = true;
        //        chkApp.Enabled = false;
        //        ddlReason.Enabled = false;
        //        ddlReason.SelectedValue = "1";
        //    }
        //    else
        //    {
        //        chkApp.Enabled = true;
        //        chkApp.Checked = false;
        //        ddlReason.Enabled = true;
        //        ddlReason.SelectedValue = "0";
        //    }
        //}
    }
    //protected void chkVerified_CheckedChanged(object sender, EventArgs e)
    //{

    //}
    protected void chkVerified_CheckedChanged(object sender, EventArgs e)
    {
        //if (chkVerified.Checked == true)
        //{
        //    int cnt = 0;
        //    GridView gdv = gdvchRem;
        //    CheckBox chkAll = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        //    for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //    {
        //        GridViewRow gvr = gdvchRem.Rows[i];
        //        CheckBox ChkApp = (CheckBox)gvr.FindControl("chkV");
        //        if (chkAll.Checked == true)
        //        {
        //            cnt = cnt + 1;
        //        }
        //    }
        //    if (cnt == 0)
        //    {
        //        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        //        {
        //            GridViewRow gvr = gdvchRem.Rows[i];
        //            CheckBox ChkApp = (CheckBox)gvr.FindControl("chkV");
        //            ChkApp.Checked = true;
        //        }
        //    }
        //}


        int cnt = 0;
        GridView gdv = gdvchRem;
        CheckBox chkAll = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            GridViewRow gvr = gdvchRem.Rows[i];
            CheckBox ChkApp = (CheckBox)gvr.FindControl("chkV");
            if (ChkApp.Checked == true)
            {
                cnt = cnt + 1;
            }
        }
        if (cnt == 0)
        {
            if (chkVerified.Checked == true)
            {
                for (int i = 0; i < gdvchRem.Rows.Count; i++)
                {
                    GridViewRow gvr = gdvchRem.Rows[i];
                    CheckBox ChkApp = (CheckBox)gvr.FindControl("chkV");
                    ChkApp.Checked = true;
                }
            }
        }
    }
    private void SetLblEditMode()
    {
        DateTime dtmNew = new DateTime();
        DateTime dtmOld = new DateTime();
        if (Convert.ToInt16(Session["IntYearIdRemi"]) < Convert.ToInt16(Session["intCCYearId"]))
        {
            if (lblDtOld.Text != "0" && lblDtOld.Text != null)
            {
                dtmNew = Convert.ToDateTime(txtChalDt.Text);
                dtmOld = Convert.ToDateTime(lblDtOld.Text);
                if (dtmNew.Day <= 4 && Convert.ToInt16(dtmOld.Day) > 4)
                {
                    lblEditMode.Text = "1";
                }
                else if (dtmNew.Day > 4 && Convert.ToInt16(dtmOld.Day) <= 4)
                {
                    lblEditMode.Text = "2";
                }
                else
                {
                    lblEditMode.Text = "0";
                }
            }
        }
    }
    public void SaveNewChalan()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        Chalan ch = new Chalan();
        ChalanDAO chDao = new ChalanDAO();
        DataSet ds = new DataSet();

        SetLblEditMode();
        if (Convert.ToInt16(lblOl.Text) > 0 && Convert.ToInt16(lblOl.Text) == 4 && Convert.ToInt16(lblNw.Text) != 4)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(txtchlnId.Text));
            arrin.Add(4);
            chDao.UpdateChalanMode(arrin);
            txtchlnId.Text = "0";
        }
        else if (Convert.ToInt16(lblOl.Text) > 0 && Convert.ToInt16(lblOl.Text) != 4 && Convert.ToInt16(lblNw.Text) == 4)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(txtchlnId.Text));
            arrin.Add(2);
            chDao.UpdateChalanMode(arrin);
            txtchlnId.Text = "0";
        }
        if (Convert.ToInt32(Session["intTreasuryDId"]) > 0)
        {
            if (CheckMandatory(txtChalAmt, txtChalNo, txtChalDt, ddlchlType, ddlsubTreas) == true)
            {
                if (Convert.ToInt32(txtchlnId.Text) > 0)
                {
                    ch.NumChalanId = Convert.ToInt32(txtchlnId.Text);
                }
                else
                {
                    ch.NumChalanId = 0;
                }
                if (ddlsubTreas.SelectedIndex > 0)
                {
                    ch.IntTreasuryId = Convert.ToInt16(ddlsubTreas.SelectedValue);
                }
                else
                {
                    ch.IntTreasuryId = 1;
                }
                if (ddlLBNew.SelectedIndex > 0)
                {
                    ch.IntLBId = Convert.ToInt16(ddlLBNew.SelectedValue);
                }
                else
                {
                    ch.IntLBId = 0;
                }
                ch.IntChalanNo = Convert.ToInt32(txtChalNo.Text);                       //,[intChalanNo]
                ch.DtChalanDate = txtChalDt.Text;                                        //,[dtChalanDate]
                ch.FltChalanAmt = Convert.ToDecimal(txtChalAmt.Text.ToString());                        //,[fltChalanAmt]
                ArrayList arr = new ArrayList();
                arr.Add(txtChalDt.Text);
                int YearId = GenDao.FindYearIdFromDate(arr);
                ch.YearId = YearId;               //,[YearId]
                DateTime dtchal = Convert.ToDateTime(txtChalDt.Text);
                int MonthId = dtchal.Month;
                ch.MonthId = Convert.ToInt16(MonthId);              //,[MonthId]
                ch.PerYearId = Convert.ToInt16(Session["IntYearIdRemi"]);                 //,[PerYearId]
                ch.PerMonthId = Convert.ToInt16(Session["IntMonthIdRemi"]);                //[PerMonthId]
                ch.ChvRemarks = " ";                                                      //,[chvRemarks]
                ch.IntUserId = Convert.ToInt64(Session["intUserId"]);                     //,[intUserId]
                ch.FlgUnposted = 1;       //,[flgUnposted]
                ch.IntUnPostedRsn = 0;   //,[intUnPostedRsn]
                ch.IntSlNo = FindSlNo(ch.IntLBId);     //,[intSlNo]
                ch.FlgSource = 1;       //,[flgSource]
                int intDay = dtchal.Day;
                ch.IntDay = intDay;      //,[intDay]
                ch.IntSthapnaBillID = 0;        //,[intSthapnaBillID]
                ch.FlgAmtMismatch = 0;       //,[flgAmtMismatch]
                if (Convert.ToInt16(Session["chalTp14"]) == 1)
                {
                    ch.FlgChalanType = 1;
                }
                else
                {
                    ch.FlgChalanType = Convert.ToInt16(ddlchlType.SelectedValue);    //,[flgChalanType]
                }
                //ch.FlgChalanType = 1;    //,[flgChalanType]
                if (chkUpN.Checked == true)
                {
                    ch.FlgUnposted = 2;
                    ch.IntUnPostedRsn = Convert.ToInt16(ddlRsnN.SelectedValue);
                }
                else
                {
                    ch.FlgUnposted = 1;
                    ch.IntUnPostedRsn =0;
                }
                
                if (ch.FlgChalanType <= 3)
                {
                    ch.tENo = 0;    //,[TENo]
                    ch.IntTreasuryDAGID = Convert.ToInt32(Session["intTreasuryDId"]);
                    //if (chalanValid(ch) == true)
                    //{
                    ds = chDao.CreateExtraChalan(ch);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        
                        ArrayList arrfrm = new ArrayList();
                        arrfrm.Add(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]));
                        arrfrm.Add( Convert.ToInt16(ddlFrm.SelectedValue));
                        chDao.UpdateChalanFrm(arrfrm);
                    }
                }
                else
                {
                    ArrayList arrIn = new ArrayList();
                    //arrIn.Add(Convert.ToInt16(Session["IntTreIdRemi"]));
                    arrIn.Add(Convert.ToInt16(ddlsubTreas.SelectedValue));
                    arrIn.Add(Convert.ToInt32(txtChalNo.Text));
                    arrIn.Add(txtChalDt.Text.ToString());
                    arrIn.Add(Convert.ToDouble(txtChalAmt.Text));
                    arrIn.Add(Session["intUserId"]);
                    arrIn.Add(1);
                    arrIn.Add(Convert.ToInt32(Session["intTreasuryDId"]));
                    arrIn.Add(ch.NumChalanId);
                    arrIn.Add(Convert.ToInt16(ddlLBNew.SelectedValue));
                    ds = chDao.SaveOtherChalan(arrIn);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ArrayList arrfrm = new ArrayList();
                        arrfrm.Add(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]));
                        arrfrm.Add(Convert.ToInt16(ddlFrm.SelectedValue));
                        chDao.UpdateChalanOtherFrm(arrfrm);
                    }
                }
            }
            else
            {
                gblObj.MsgBoxOk("Enter all detials!", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Session expired!", this);
        }
}
    public void clearnewchalan()
    {
        txtChalNo.Text = "0";
        txtChalDt.Text = "";
        txtChalAmt.Text = "0";
        ddlLBNew.SelectedValue = "0";
        ddlsubTreas.SelectedValue = "0";
        ddlchlType.SelectedValue = "0";
        ddlFrm.SelectedValue = "0";
        Session["numchalanId"] = "0";
        lblOl.Text = "0";
        lblNw.Text = "0";
    }
    private void FillChalanTxts()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();

        pnlChalNew.Visible = true;
        Session["numchalanId"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
        FillCmbDT();
        FillCmbLb();
        FillComboChalanType();
        FillCmbFrm();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["numchalanId"] != null)
        {
            arr.Add(Session["numchalanId"]);
            ds = chDao.Remitancechlntextfill(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtChalNo.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                txtChalDt.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                lblDtOld.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                txtChalAmt.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                ddlLBNew.SelectedValue = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                ddlchlType.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtchlnId.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                lblNw.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblOl.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblDy.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                ddlFrm.SelectedValue = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[10]) == 2)
                {
                    chkUpN.Checked = true;
                    ddlRsnN.SelectedValue = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                }
                else
                {
                    chkUpN.Checked = false;
                }
            }
            else
            {
                pnlChalNew.Visible = false;
            }
        }
        else
        {
            Session["numchalanId"] = 0;
        }
    }
    private void FillChalanTxts14()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();

        pnlChalNew.Visible = true;
        Session["numchalanId"] = Convert.ToDouble(Request.QueryString["numChalanId14"]);
        FillCmbDT();
        FillCmbLb();
        FillComboChalanType();
        FillCmbFrm();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["numchalanId"] != null)
        {
            arr.Add(Session["numchalanId"]);
            ds = chDao.Remitancechlntextfill14(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtChalNo.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                txtChalDt.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                lblDtOld.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                txtChalAmt.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                ddlLBNew.SelectedValue = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                ddlchlType.SelectedValue = 3.ToString();
                ddlchlType.Enabled = false;
                txtchlnId.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                lblNw.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblOl.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblDy.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                ddlFrm.SelectedValue = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[10]) == 2)
                {
                    chkUpN.Checked = true;
                    ddlRsnN.SelectedValue = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                }
                else
                {
                    chkUpN.Checked = false;
                }
            }
            else
            {
                pnlChalNew.Visible = false;
            }
        }
        else
        {
            Session["numchalanId"] = 0;
        }
    }
    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        DateTime dtm = new DateTime();
        if (gblObj.isValidDate(txtChalDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtChalDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMnth.SelectedValue)) == true)
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
    }
    //private Boolean CheckChalanDateL(TextBox txtChlDt, int yr, int mth)
    //{
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    //    Boolean flg;
    //    ArrayList ar = new ArrayList();
    //    GenDao = new KPEPFGeneralDAO();
    //    ar.Add(Convert.ToDateTime(txtChlDt.Text));
    //    if (GenDao.gFunFindYearIdFromDate(ar) != yr || Convert.ToDateTime(txtChlDt.Text).Month != mth)
    //    {
    //        gblObj.MsgBoxOk("Invalid Date", this);
    //        txtChlDt.Text = "";
    //        flg = false;
    //    }
    //    else
    //    {
    //        flg = true;
    //    }
    //    return flg;
    //}
    protected void ddlchlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlchlType.SelectedValue) > 0)
        {
            lblNw.Text = ddlchlType.SelectedValue.ToString();
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        pnlChalNew.Visible = false;
        FillChalanLb();
        FillChalanOther();
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
    }
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShow.Checked == true)
        {
            FillChalanLb();
            FillChalanOther();
            FillTotLbl();
            SetCtrls();
        }
        else
        {
            SetGridDefault();
            SetGridDefaultOtherChal();
            lblTotA.Text = "0";
        }
        
    }
    private void CorrectionEntryForDel(float numChalId,string chalDt)
    {
        schedDao = new ScheduleDAO();
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
        ds = schedDao.GetSchedDet4CorrEntryCurrCorr(ar);
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
                int intYrId = GenDao.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 1);
                //schedPdeDao.DelTR104PDEMode(ar);
            }
        }
    }
    private void SaveCorrectionEntry(int intAccNo, float chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType)
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
        cor.IntTblTp = 2;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
    protected void btnDeleteCh_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        chDao = new ChalanDAO();
        schedDao = new ScheduleDAO();
        GeneralDAO gendao = new GeneralDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblChalId = (Label)gdvchRem.Rows[rowIndex].FindControl("lblChalId");
        Label txtchlDt = (Label)gdvchRem.Rows[rowIndex].FindControl("txtchlDt");

        if (lblChalId.Text != "")
        {
            ArrayList arrin = new ArrayList();
            //int a = Convert.ToInt16(Session["IntYearIdRemi"]);
            //int b = Convert.ToInt16(Session["intCCYearId"]);

            if (Convert.ToInt16(Session["IntYearIdRemi"]) <= Convert.ToInt16(Session["intCCYearId"]))
            {
                CorrectionEntryForDel(Convert.ToInt32(lblChalId.Text), txtchlDt.Text.ToString()); //Corr Entry
            }
            arrin.Add(Convert.ToInt64(lblChalId.Text));
            arrin.Add(1);
            chDao.UpdateChalanMode(arrin);
            schedDao.UpdScheduleDel(arrin);
            FillChalanLb();
            //Build April2022
            ArrayList procin = new ArrayList();
            procin.Add("Remittance.aspx-Remittance_Localbody-btnDeleteCh-event-update chalan and shedule mode of change to 4 (numChalanID is the ID param)");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblChalId.Text));
            chDao.Processtracking(procin);         
        }
        gblObj.MsgBoxOk("Row Deleted   !", this);

    }

    //private void SaveCorrectionEntryChal(float chalId, int yr, int mth, int inyDy)
    //{

    //    GeneralDAO gendao = new GeneralDAO();
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    ChalanDAO chaldao = new ChalanDAO();
    //    CorrectionEntry corr = new CorrectionEntry();
    //    CorrectionEntryDao corrDao = new CorrectionEntryDao();

    //    int cntEmp = 0;
    //    ArrayList ar = new ArrayList();
    //    DataSet dsChal = new DataSet();
    //    ar.Add(chalId);
    //    dsChal = chaldao.FindCntEmpInChalanCurr(ar);
    //    cntEmp = dsChal.Tables[0].Rows.Count;
    //    //Session["intCCYearId"] = gendao.GetCCYearId();
    //    for (int i = 0; i <= cntEmp - 1; i++)
    //    {
    //        int accNo = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[0]);
    //        double amt = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //        double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, dblCalcAmt);
    //        ///// Save to CorrEntry/////////
    //        corr.IntAccNo = accNo;
    //        corr.IntYearID = yr;
    //        corr.IntMonthID = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[3]);
    //        corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //        corr.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        //corr.FltAmountAfter = Math.Round(dblAmtAdjusted);

    //        corr.FltAmountAfter = 0;
    //        corr.FltCalcAmount = dblAmtAdjusted;

    //        corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //        corr.IntChalanId = chalId;
    //        corr.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
    //        corr.FlgType = 1;           //Remittance
    //        corr.FltRoundingAmt = 0;
    //        corr.IntCorrectionType = 1; //Edit Chal Date
    //        //corr.StrFrmChalDt = System.DBNull.Value.ToString();
    //        //corr.StrToChalDt = System.DBNull.Value.ToString();
    //        if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //        {
    //            corr.IntChalanType = 1;
    //        }
    //        else
    //        {
    //            corr.IntChalanType = 2;
    //        }
    //        corrDao.CreateCorrEntry(corr);
    //        ///// Save to CorrEntry/////////
    //    }
    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}

    protected void gdvchNonLB_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gblObj.SetColWidthGrid(gdvchNonLB, e, 1, 0);
        gblObj.SetColWidthGrid(gdvchNonLB, e, 5, 3);
    }
}

