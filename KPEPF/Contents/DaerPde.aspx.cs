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


public partial class Contents_DaerPde : System.Web.UI.Page
{

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    TEDAO teDAO;

    ChalanPDEAGDAO ChalAGDao;
    ChalanPDEAG chl;
    ChalanDAO chDao;
    balancetrans bl;

    BalanTrPDE blPDE;
    BalanceTransPDEDao blPDEDao;

    CorrectionEntry cor = new CorrectionEntry();
    CorrectionEntryDao cord = new CorrectionEntryDao();
    SchedulePDEDao schedPdeDao;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToDouble(Session["numChalanIdEdit"]) > 0)
            {
                ViewGrid();
                ShowCRPlus();
                SetCtrls();
                FillHeadLbls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAg"]) == 2 || Convert.ToInt16(Session["flgAppAg"]) == 0)
        {
            SetCtrlsEnable();
            btnwithdocs.Enabled = true;
            txtCnt.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            btnwithdocs.Enabled = false;
            txtCnt.Enabled = false;
        }
        if (Convert.ToInt32(Session["trnTypeAG"]) == 30)
        {
            lblHead.Text = "DAER_Credit";
            lbl11.Text = "DAER Plus ";
            lblTotET.Text = "DAER Entered";
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 40)
        {
            lblHead.Text = "OAO_Credit";
            lbl11.Text = "OAO Plus ";
            lblTotET.Text = "OAO Entered";
        }

    }
    private void SetCtrlsEnable()
    {
        SetWithDocsGridEnable();

    }
    private void SetCtrlsDisable()
    {
        SetWithDocsGridDisable();
        //gdvCPW.Enabled = false;

    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvCPW.Rows[i];
            TextBox txtTeCPWAss = (TextBox)gdvrow.FindControl("txtTeCPW");
            txtTeCPWAss.ReadOnly = false;
            txtTeCPWAss.Enabled = true;

            TextBox txtchnoAss = (TextBox)gdvrow.FindControl("txtchno");
            txtchnoAss.ReadOnly = false;
            txtchnoAss.Enabled = true;


            TextBox txtChlnDtCPWAss = (TextBox)gdvrow.FindControl("txtChlnDtCPW");
            txtChlnDtCPWAss.ReadOnly = false;
            txtChlnDtCPWAss.Enabled = true;


            TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            txtChlAmtCPWAss.ReadOnly = false;
            txtChlAmtCPWAss.Enabled = true;


            DropDownList ddlDistAss = (DropDownList)gdvrow.FindControl("ddlDist");
            ddlDistAss.Enabled = true;

            DropDownList ddlTreCPWOAss = (DropDownList)gdvrow.FindControl("ddlTreCPWO");
            ddlTreCPWOAss.Enabled = true;

            DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLBAss.Enabled = true;


            CheckBox chkUnpostCPWAss = (CheckBox)gdvrow.FindControl("chkUnpostCPW");
            chkUnpostCPWAss.Enabled = true;

            DropDownList ddlreasonAss = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreasonAss.Enabled = true;

            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = true;


            TextBox txtRemarksAss = (TextBox)gdvrow.FindControl("txtRemarks");
            txtRemarksAss.ReadOnly = false;
            txtRemarksAss.Enabled = true;

            ImageButton btndeleteCrplus = (ImageButton)gdvrow.FindControl("btndeleteCrplus");
            btndeleteCrplus.Enabled = true;

            //DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            //ddlStatusAss.Enabled = true;

            //Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");
            //lblintIdAss.ReadOnly = false;
            //lblintIdAss.Enabled = true;

            //Button BtnwithDtAss = (Button)gdvrow.FindControl("BtnwithDt");
            //BtnwithDtAss.Enabled = true;


            //TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            //txtChlAmtCPWAss.ReadOnly = false;
            //txtChlAmtCPWAss.Enabled = true;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = false;
            //RelMnthAss.Enabled = true;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = false;
            //RelYearIdAss.Enabled = true;

        }
    }
    private void SetWithDocsGridDisable()
    {
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvCPW.Rows[i];
            TextBox txtTeCPWAss = (TextBox)gdvrow.FindControl("txtTeCPW");
            txtTeCPWAss.ReadOnly = true;
            txtTeCPWAss.Enabled = false;

            TextBox txtchnoAss = (TextBox)gdvrow.FindControl("txtchno");
            txtchnoAss.ReadOnly = true;
            txtchnoAss.Enabled = false;


            TextBox txtChlnDtCPWAss = (TextBox)gdvrow.FindControl("txtChlnDtCPW");
            txtChlnDtCPWAss.ReadOnly = true;
            txtChlnDtCPWAss.Enabled = false;


            TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            txtChlAmtCPWAss.ReadOnly = true;
            txtChlAmtCPWAss.Enabled = false;


            DropDownList ddlDistAss = (DropDownList)gdvrow.FindControl("ddlDist");
            ddlDistAss.Enabled = false;

            DropDownList ddlTreCPWOAss = (DropDownList)gdvrow.FindControl("ddlTreCPWO");
            ddlTreCPWOAss.Enabled = false;

            DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLBAss.Enabled = false;


            CheckBox chkUnpostCPWAss = (CheckBox)gdvrow.FindControl("chkUnpostCPW");
            chkUnpostCPWAss.Enabled = false;

            DropDownList ddlreasonAss = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreasonAss.Enabled = false;

            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = false;


            TextBox txtRemarksAss = (TextBox)gdvrow.FindControl("txtRemarks");
            txtRemarksAss.ReadOnly = true;
            txtRemarksAss.Enabled = false;

            ImageButton btndeleteCrplus = (ImageButton)gdvrow.FindControl("btndeleteCrplus");
            btndeleteCrplus.Enabled = false;



        }
    }
    private void ViewGrid()
    {
        //gblobj.SetRowsCnt(gdvBT, 1);
        //gblobj.SetRowsCnt(gdvCPW, 1);
        //gblobj.SetRowsCnt(gdvCPWO, 1);
        //gblobj.SetBlankRow(gdvBT);
        SetGridDefault();

        //SetGridDefaultWOD();
        //gblobj.SetBlankRow(gdvCPWO);
    }
    private void SetGridDefault()
    {
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intChalanNo");
        ar.Add("intChalanId");
        ar.Add("intGroupId");
        ar.Add("flgPrevYear");
        ar.Add("flgApproval");
        gblobj.SetGridDefault(gdvCPW, ar);
    }

    public void fillGridcombos(GridView gdv)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();

        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreCPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreCPWO");
            gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);

        }
        DataSet dsdist = new DataSet();
        dsdist = teDAO.GetDist();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlDistAss = (DropDownList)grdVwRow.FindControl("ddlDist");
            gblobj.FillCombo(ddlDistAss, dsdist, 1);

        }
        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {

            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            gblobj.FillCombo(ddlLBAss, dslb, 1);

        }


        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);


        }
        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gendao.GetMisClassRsn(arrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlreasonAs = (DropDownList)grdVwRow.FindControl("ddlreason");
            gblobj.FillCombo(ddlreasonAs, dsM, 1);


        }

    }

    public void fillGridcomboswithoutDocs(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();

        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreCPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreasuryCPWO");
            gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);

        }

        //DataSet dslb = new DataSet();
        //dslb = teDAO.GetLB();
        //for (int i = 0; i < gdv.Rows.Count; i++)
        //{
        //    GridViewRow grdVwRow = gdv.Rows[i];
        //    DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
        //    gblobj.FillCombo(ddlLBAss, dslb, 1);

        //}
        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);
        }
    }
    public void fillCombo()
    {
        //    ArrayList ArrIn = new ArrayList();
        //    ArrIn.Add(1);
        //    DataSet ds = new DataSet();
        //    ds = teDAO.GetTrntype(ArrIn);
        //    gblobj.FillCombo(ddlTrnType, ds, 1);
    }
    private void InitialSettings()
    {
        Session["flgPageBack"] = 7;
        ViewGrid();

        fillGridcombos(gdvCPW);
        ShowCRPlus();
        SetCtrls();

        FillHeadLbls();
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

        //lblTot.Text = Session["dblAmtDaerCr"].ToString();
        if (Convert.ToInt32(Session["trnTypeAG"]) == 30)
        {
            lblTot.Text = Session["dblAmtDaerPlus"].ToString();
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 40)
        {
            lblTot.Text = Session["dblAmtOAOPlus"].ToString();
        }
        //lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) );
        //lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    //protected void btnOK_Click(object sender, EventArgs e)
    //{

    //}
    public void ShowCRPlus()
    {
        gblobj = new clsGlobalMethods();
        ChalAGDao = new ChalanPDEAGDAO();
        chDao = new ChalanDAO();

        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();

        SetGridDefault();
        arr.Add(Convert.ToInt64(Session["GintTEMonthWiseId"]));
        if (Convert.ToInt32(Session["trnTypeAG"]) == 30)
        {
            arr.Add(3);
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 40)
        {
            arr.Add(4);
        }
        arr.Add(Convert.ToInt16(Session["flgAppAg"]));
        dscrplus = ChalAGDao.FillCrPlusDaer(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvCPW.DataSource = dscrplus;
            gdvCPW.DataBind();

            fillGridcombos(gdvCPW);
            int count = gdvCPW.Rows.Count;
            for (int i = 0; i < dscrplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCPW.Rows[i];
                TextBox txtTeCPWAss = (TextBox)gdv.FindControl("txtTeCPW");
                txtTeCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtChNoCPWAss = (TextBox)gdv.FindControl("txtchno");
                txtChNoCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtChlnDtCPWAss = (TextBox)gdv.FindControl("txtChlnDtCPW");
                txtChlnDtCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtChlAmtCPWAss = (TextBox)gdv.FindControl("txtChlAmtCPW");
                txtChlAmtCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[3].ToString();

                DropDownList ddlTreCPWOAss = (DropDownList)gdv.FindControl("ddlTreCPWO");
                ddlTreCPWOAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();

                DropDownList ddlDistAss = (DropDownList)gdv.FindControl("ddlDist");
                ddlDistAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[6].ToString();

                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                ddlLBAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();

                TextBox txtRsnCPWAss = (TextBox)gdv.FindControl("txtRemarks");
                txtRsnCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[8].ToString();

                Label lblintIdWthAss = (Label)gdv.FindControl("lblintIdWth");
                lblintIdWthAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[10].ToString();

                Label lblRelMthId = (Label)gdv.FindControl("lblRelMthId");
                lblRelMthId.Text = dscrplus.Tables[0].Rows[i].ItemArray[16].ToString();

                CheckBox chkUnpostCPW = (CheckBox)gdv.FindControl("chkUnpostCPW");
                DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");
                if (Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[14]) == 1)
                {
                    chkUnpostCPW.Checked = false;
                    ddlreasonAss.Enabled = false;                    
                }
                else
                {
                    chkUnpostCPW.Checked = true;                   
                    ddlreasonAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[15].ToString();
                    ddlreasonAss.Enabled = true;
                }
                Label lblSchMnId = (Label)gdv.FindControl("lblSchMnId");
                lblSchMnId.Text = dscrplus.Tables[0].Rows[i].ItemArray[17].ToString();

                Label lblGrpId = (Label)gdv.FindControl("lblGrpId");
                lblGrpId.Text = dscrplus.Tables[0].Rows[i].ItemArray[12].ToString();

                Label txtintChalId = (Label)gdv.FindControl("txtintChalId");
                txtintChalId.Text = dscrplus.Tables[0].Rows[i].ItemArray[18].ToString();

                Label lblDy = (Label)gdv.FindControl("lblDy");
                lblDy.Text = Convert.ToDateTime(dscrplus.Tables[0].Rows[i].ItemArray[1]).Day.ToString();

                Label oldYear = (Label)gdv.FindControl("lblYearId");
                Label oldMnth = (Label)gdv.FindControl("lblMnth");
                Label oldDay = (Label)gdv.FindControl("lblDay");
                oldYear.Text = dscrplus.Tables[0].Rows[i].ItemArray[21].ToString();
                oldMnth.Text = dscrplus.Tables[0].Rows[i].ItemArray[19].ToString();
                oldDay.Text = dscrplus.Tables[0].Rows[i].ItemArray[20].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
            if (Convert.ToDouble(gdvCPW.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWCP.Text = gdvCPW.FooterRow.Cells[4].Text.ToString();
                ArrayList ar = new ArrayList();
                DataSet dsS = new DataSet();
                ar.Add(Convert.ToInt16(Session["IntYearAG"]));
                ar.Add(Convert.ToInt16(Session["IntMonthAG"]));
                dsS = ChalAGDao.GetScheduleTotal(ar);
            }
            else
            {
                lblAmtWCP.Text = "0";
            }
        }
        else
        {
            lblAmtWCP.Text = "0";
            fillGridcombos(gdvCPW);
            SetGridDefault();
        }
        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }
    protected void chkUnpostCPW_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvCPW.Rows[index];

        CheckBox chkUnpostCPW = (CheckBox)gdvr.FindControl("chkUnpostCPW");
        DropDownList ddlReason = (DropDownList)gdvr.FindControl("ddlreason");
        if (chkUnpostCPW.Checked == true)
        {
            ddlReason.Enabled = true;
        }
        else
        {
            ddlReason.Enabled = false;
        }
    }
    public void Savechalan()
    {
        //DataSet ds = new DataSet();
        //ArrayList ar = new ArrayList();
        //chal.PerMonthId = Convert.ToInt32(ddlTreCPW.SelectedValue);

    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        DropDownList ddlDistAss = (DropDownList)gvr.FindControl("ddlDist");
        DropDownList ddlTreasuryCPWO = (DropDownList)gvr.FindControl("ddlTreCPWO");
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");

        if (Convert.ToInt16(ddlDistAss.SelectedValue) > 0)
        {
            Session["intDist"] = Convert.ToInt16(ddlDistAss.SelectedValue);
            FillLbDtWiseWithdocs(Convert.ToInt16(Session["intDist"]), ddlLBAss);
            FillTreasDtWise(Convert.ToInt16(Session["intDist"]), ddlTreasuryCPWO);
        }
        else
        {
            Session["intDist"] = 0;
        }

    }


    private void FillLbDtWiseWithdocs(int LBID, DropDownList ddlLBAss)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intDist"]));
        //ar.Add(5);
        DataSet dslb = new DataSet();
        dslb = gendao.GetLBGp(ar);
        gblobj.FillCombo(ddlLBAss, dslb, 1);
    }
    private void FillTreasDtWise(int TresId, DropDownList ddlTreasuryCPWO)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList art = new ArrayList();
        art.Add(Convert.ToInt16(Session["intDist"]));
        DataSet dst = new DataSet();
        dst = gendao.GetTreasury(art);
        gblobj.FillCombo(ddlTreasuryCPWO, dst, 1);

    }
    private int FindSlNo()
    {
        int slno = 1;
        return slno;
    }
    public void fillLB()
    {

    }
    protected void ddlLB_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    //{
    //    gendao = new GeneralDAO();
    //    gblobj = new clsGlobalMethods();
    //    schedPdeDao = new SchedulePDEDao();
    //    cor = new CorrectionEntry();
    //    cord = new CorrectionEntryDao();

    //    int cntEmp = 0;
    //    ArrayList ar = new ArrayList();
    //    DataSet dsChal = new DataSet();
    //    ar.Add(chalId);
    //    ar.Add(1);
    //    dsChal = schedPdeDao.GetSchedDet4CorrEntryAg(ar);
    //    cntEmp = dsChal.Tables[0].Rows.Count;
    //    Session["intCCYearId"] = gendao.GetCCYearId() + 1;
    //    for (int i = 0; i <= cntEmp - 1; i++)
    //    {
    //        int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[0]);
    //        double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        double dblCalcAmt = gblobj.CalculateAmtToCalc(yr, amt);
    //        double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpd(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, amt, intEditMode);
    //        cor.IntAccNo = accNo;
    //        cor.IntYearID = yr;
    //        cor.IntMonthID = mth;
    //        cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //        cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);

    //        cor.FltAmountAfter = Math.Round(dblCalcAmt);
    //        cor.FltCalcAmount = dblAmtAdjusted;

    //        cor.FlgCorrected = 1;      //Just added not incorporated in CCard
    //        cor.IntChalanId = chalId;
    //        cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
    //        cor.FlgType = 1;           //Remittance
    //        cor.FltRoundingAmt = 0;
    //        cor.IntCorrectionType = 1; //Edit Chal Date
    //        cor.IntChalanType = 4;
    //        cor.IntTblTp = 1;
    //        cord.CreateCorrEntryCalcTblTp(cor);
    //    }

    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}
    protected void btnwithdocs_Click(object sender, EventArgs e)
    {
        SaveWithDocs();
        ShowCRPlus();
        // lblAmtWOCP.Text = Convert.ToString(gdvCPWO.FooterRow.Cells[4].Text);
        lblAmtWCP.Text = Convert.ToString(gdvCPW.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        //gblobj.MsgBoxOk("Saved successfully", this);
    }
    public void SaveWithDocs()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        chl = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();

        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();

        if (Convert.ToDouble(gdvCPW.FooterRow.Cells[4].Text) > 0)
        {
            for (int i = 0; i < gdvCPW.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvCPW.Rows[i];
                DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
                DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
                TextBox txtChNoCPWAss = (TextBox)gdvrw.FindControl("txtchno");
                TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
                TextBox txtRemarksAss = (TextBox)gdvrw.FindControl("txtRemarks");
                CheckBox chkUnpostCPW = (CheckBox)gdvrw.FindControl("chkUnpostCPW");
                DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
                TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
                TextBox txtTeCPWAss = (TextBox)gdvrw.FindControl("txtTeCPW");
                Label lblintIdWthAss = (Label)gdvrw.FindControl("lblintIdWth");

                Label lblRelMthId = (Label)gdvrw.FindControl("lblRelMthId");
                Label RelMnth = (Label)gdvrw.FindControl("RelMnth");
                Label lblSchMnId = (Label)gdvrw.FindControl("lblSchMnId");
                Label lblGrpId = (Label)gdvrw.FindControl("lblGrpId");

                ArrayList ardt = new ArrayList();
                ardt.Add(txtChlnDtCPWAss.Text.ToString());

                DataSet ds = new DataSet();
                ArrayList ar = new ArrayList();

                if (CheckMandatory(ddlTreCPWOass, ddlLBAss, txtChlAmtCPWAss, txtChlnDtCPWAss) == true)
                {
                    if (lblintIdWthAss.Text == "")
                    {
                        chl.IntChalanAGID = 0;
                    }
                    else
                    {
                        chl.IntChalanAGID = Convert.ToInt32(lblintIdWthAss.Text);
                    }
                    chl.IntTreasID = Convert.ToInt32(ddlTreCPWOass.SelectedValue);
                    chl.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
                    chl.IntChalanNo = Convert.ToInt32(txtChNoCPWAss.Text);
                    chl.DtmChalanDt = txtChlnDtCPWAss.Text.ToString();
                    chl.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
                    //chl.IntYearID = genDAO.gFunFindYearIdFromDate(ardt);
                    chl.IntYearID = genDAO.gFunFindPDEYearIdFromDate(ardt);
                    
                    chl.IntUserId = Convert.ToInt32(Session["intUserId"]);
                    chl.IntModeOfChgID = 2;

                    if (chkUnpostCPW.Checked == true)
                    {
                        chl.FlgUnPosted = 2;
                        chl.IntReasonID = Convert.ToInt32(ddlreasonAss.SelectedValue);
                    }
                    else
                    {
                        chl.FlgUnPosted = 1;
                    }
                    if (Convert.ToInt32(Session["trnTypeAG"]) == 30)
                    {
                        chl.IntChalanType = 3;
                    }
                    else if (Convert.ToInt32(Session["trnTypeAG"]) == 40)
                    {
                        chl.IntChalanType = 4;
                    }

                    chl.ChvTENo = Convert.ToString(txtTeCPWAss.Text);
                    ////////////// RelMolnthWise ////////////////
                    //if (Convert.ToInt32(Convert.ToInt32(lblRelMthId.Text)) == 0)
                    //{
                    DataSet dsBal = new DataSet();
                    blPDE.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
                    blPDE.IntRelYearId = Convert.ToInt16(Convert.ToInt32(Session["IntYearAG"]));
                    blPDE.IntRelMonthId = Convert.ToInt16(Convert.ToInt32(Session["IntMonthAG"]));
                    blPDE.FltAmtPDE = 0;

                    if (Convert.ToInt32(Session["trnTypeAG"]) == 30)
                    {
                        blPDE.IntTrnType = 30;
                    }
                    else if (Convert.ToInt32(Session["trnTypeAG"]) == 40)
                    {
                        blPDE.IntTrnType = 40;
                    }
                    blPDE.IntTreasId = 0;
                    blPDE.IntModeChgPDE = 2;

                    if (Convert.ToInt32(lblRelMthId.Text.ToString()) == 0)
                    {
                        blPDE.IntRelMonthWiseId = 0;
                    }
                    else
                    {
                        blPDE.IntRelMonthWiseId = Convert.ToInt32(lblRelMthId.Text.ToString());
                    }
                    blPDE.IntLBId = 0;
                    blPDE.ChvTEIdPDE = "";
                    dsBal = blPDEDao.CreateBalanceTransRel(blPDE);
                    if (dsBal.Tables[0].Rows.Count > 0)
                    {
                        chl.IntTERelMonthWiseID = Convert.ToInt32(dsBal.Tables[0].Rows[0].ItemArray[0]);
                    }

                    ds = ChalAGDao.CreateChalanAG(chl);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        Label lblintIdWth = (Label)gdvrw.FindControl("lblintIdWth");
                        lblintIdWth.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                        SaveChalan(i, Convert.ToInt32(lblintIdWth.Text));
                        if (Convert.ToInt32(lblGrpId.Text) == 0)
                        {
                            lblGrpId.Text = Session["intGrpId"].ToString();
                        }
                    }
                    gblobj.MsgBoxOk("Saved successfully", this);
                }
                else
                {
                    gblobj.MsgBoxOk("Enter all details!!!", this);
                }
            }           
        }
        else
        {
            gblobj.MsgBoxOk("No data", this);
        }
    }
    private void SaveScheduleMain(int lblSchMnId,int lbId,int grpId,decimal chalAmt)
    {
        SchedulePDEDao schedPdeDao = new SchedulePDEDao();

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(lblSchMnId);      //Sched MainId
        ar.Add(lbId);     //LB Id
        ar.Add(grpId);     //Group Id
        ar.Add(Convert.ToInt64(Session["intUserId"]));     //User Id
        ar.Add(chalAmt);
        ds = schedPdeDao.ScheduleMainSavePDE01Ag(ar);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Session["intSchMainId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        //}
    }

    private void SaveChalan(int j, int intchalaAGId)
    {
        genDAO = new KPEPFGeneralDAO();
        chl = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();
        ArrayList ardt = new ArrayList();

        GridViewRow gdvrw = gdvCPW.Rows[j];
        Label lblintIdWth = (Label)gdvrw.FindControl("lblintIdWth");
        if (lblintIdWth.Text == "")
        {
            chl.ChalanId = 0;
        }
        else
        {
            chl.ChalanId = Convert.ToInt32(lblintIdWth.Text);
        }
        DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chl.IntTreasID = Convert.ToInt32(ddlTreCPWOass.SelectedValue);
        }
        else
        {
            chl.IntTreasID = 0;
        }
        TextBox txtchno = (TextBox)gdvrw.FindControl("txtchno");
        chl.IntChalanNo = Convert.ToInt16(txtchno.Text);

        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        if (txtChlnDtCPWAss.Text == "")
        {
            chl.DtmChalanDt = "";
        }
        else
        {
            chl.DtmChalanDt = txtChlnDtCPWAss.Text.ToString();           
            ardt.Add(txtChlnDtCPWAss.Text.ToString());
            chl.IntYearID = genDAO.gFunFindPDEYearIdFromDate(ardt);
        }
        TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
        if (txtChlAmtCPWAss.Text == "")
        {
            chl.FltChalanAmt = 0;
        }
        else
        {
            chl.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
        }
        chl.IntModeOfChgID = 2;
        chl.IntUserId = Convert.ToInt32(Session["intUserId"]);

        chl.IntChalanAGID = intchalaAGId;
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chl.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            chl.IntLBID = 0;
        }
        CheckBox chkUnpostCPW = (CheckBox)gdvrw.FindControl("chkUnpostCPW");
        DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
        if (chkUnpostCPW.Checked == true)
        {
            chl.FlgUnPosted = 2;
            chl.IntReasonID = Convert.ToInt32(ddlreasonAss.SelectedValue);
        }
        else
        {
            chl.FlgUnPosted = 1;
        }
        DataSet dschl = new DataSet();

        dschl = ChalAGDao.SaveChalandetailsAG(chl);
        if (dschl.Tables[0].Rows.Count > 0)
        {
            Session["intGrpId"] = Convert.ToInt32(dschl.Tables[0].Rows[0].ItemArray[0]);
        }

        Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
        Label txtintChalId = (Label)gdvrw.FindControl("txtintChalId");
        Label lblDy = (Label)gdvrw.FindControl("lblDy");

        ////////////// Correction  ////////////////
        if (Convert.ToInt16(lblEditId.Text) > 0)
        {
            Label oldYear = (Label)gdvrw.FindControl("lblYearId");
            Label oldMnth = (Label)gdvrw.FindControl("lblMnth");
            //TextBox oldDay = (TextBox)gdvrw.FindControl("RelDay");
            Label oldDay = (Label)gdvrw.FindControl("lblDay");

            int yr1 = Convert.ToInt16(oldYear.Text);
            int mth1 = Convert.ToInt16(oldMnth.Text);
            int intDy1 = Convert.ToInt16(oldDay.Text);

            int yr2 = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
            int mth2 = Convert.ToDateTime(txtChlnDtCPWAss.Text).Month;
            int intDy2 = Convert.ToDateTime(txtChlnDtCPWAss.Text).Day;

            SaveCorrectionEntryChal(Convert.ToInt32(txtintChalId.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, intDy1, yr2, mth2, intDy2);
        }
        //if (Convert.ToInt16(lblEditId.Text) > 0)
        //{
        //    SaveCorrectionEntryChal(Convert.ToInt32(txtintChalId.Text), Convert.ToInt16(lblEditId.Text), Convert.ToInt16(Session["IntYearAG"]), Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(lblDy.Text));
        //}
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr1, int mth1, int inyDy1, int yr2, int mth2, int inyDy2)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        schedPdeDao = new SchedulePDEDao();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        ar.Add(1);
        dsChal = schedPdeDao.GetSchedDet4CorrEntryAg(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        for (int i = 0; i <= cntEmp - 1; i++)
        {
            int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[0]);
            double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr2, amt);
            double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpdLat(yr1, yr2, Convert.ToInt16(Session["intCCYearId"]), mth1, mth2, inyDy1, inyDy2, amt, intEditMode);
            cor.IntAccNo = accNo;
            cor.IntYearID = yr2;
            cor.IntMonthID = mth2;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = chalId;
            cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
            cor.FlgType = 1;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = 1; //Edit Chal Date
            cor.IntChalanType = 4;
            cor.IntTblTp = 1;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    }
    private Boolean CheckMandatory(DropDownList ddltreas, DropDownList ddlLb, TextBox txt, TextBox txtDt)
    {
        gblobj = new clsGlobalMethods();

        Boolean flg = true;
        if (ddltreas.SelectedValue == "0" || ddltreas.SelectedValue == "" || ddlLb.SelectedValue == "0" || ddlLb.SelectedValue == "" || txt.Text.ToString() == "" || txt.Text.ToString() == "0" || txtDt.Text.ToString() == "")
        {
            gblobj.MsgBoxOk("Enter all details!", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        if (ViewState["Withdoc"] != null)
        {
            DataTable dt = (DataTable)ViewState["Withdoc"];
            int count = gdvCPW.Rows.Count;
            //DropDownList drp1 = (DropDownList)gdvCPW.Rows[count - 1].Cells[5].FindControl("ddlTreCPWO");
            //DropDownList drp2 = (DropDownList)gdvCPW.Rows[count - 1].Cells[6].FindControl("ddlDist");
            //DropDownList drp3 = (DropDownList)gdvCPW.Rows[count - 1].Cells[7].FindControl("ddlLB");
            //if (drp1.SelectedIndex == 0)
            //{
            //   // ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Data');", true);
            //    objClass.setFocus(drp1, this);
            //}
            //else
            //{
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtTeCPW");
            arrIN.Add("txtChNoCPW");
            arrIN.Add("txtChlnDtCPW");
            arrIN.Add("txtChlAmtCPW");
            arrIN.Add("ddlTreCPWO");
            arrIN.Add("ddlDist");
            arrIN.Add("ddlLB");
            arrIN.Add("chkUnpostCPW");
            arrIN.Add("ddlStusCPW");
            arrIN.Add("Button1");
            dt = gblobj.AddNewRowToGrid(dt, gdvCPW, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList drpnewtreas = (DropDownList)gdvCPW.Rows[count].FindControl("ddlTreCPWO");
            DropDownList drpnewDist = (DropDownList)gdvCPW.Rows[count].FindControl("ddlDist");
            DropDownList drpnewLB = (DropDownList)gdvCPW.Rows[count].FindControl("ddlLB");
            gblobj.setFocus(drpnewtreas, this);
            //}
            fillGridcombos(gdvCPW);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drptr = (DropDownList)gdvCPW.Rows[i].FindControl("ddlTreCPWO");
                drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();
                DropDownList drpDist = (DropDownList)gdvCPW.Rows[i].FindControl("ddlDist");
                drpDist.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
                DropDownList drpLB = (DropDownList)gdvCPW.Rows[i].FindControl("ddlLB");
                drpLB.SelectedValue = dt.Rows[i].ItemArray[7].ToString();
            }
        }
    }
    protected void gdvCPW_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnBckCP_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGstatementsPDE.aspx");
    }
    protected void btnClsCP_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");
    }
    protected void txtChlnDtCPW_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ardt = new ArrayList();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtChlnDtCPW");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");
        Label lblDy = (Label)gvr.FindControl("lblDy");

        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        Label oldDay = (Label)gvr.FindControl("lblDay");


        DateTime dtm;
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
                            else
                            {
                                if (dynw <= 4 && Convert.ToInt16(oldDay.Text) > 4)
                                {
                                    lblEditId.Text = "1";
                                }
                                else
                                {
                                    if (dynw > 4 && Convert.ToInt16(oldDay.Text) <= 4)
                                    {
                                        lblEditId.Text = "2";
                                    }
                                }
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
        }
    }
    protected void txtFrmAcCPBT_TextChanged(object sender, EventArgs e)
    {

    }

    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        // myControls.Add(new DropDownList());
        myControls.Add(new Label());

        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        //  arrControlid.Add("ddFloorArea");
        arrControlid.Add("lblintIdWtht");

        arrControlid.Add("txtChlnCPWO");
        arrControlid.Add("txtChlnDateCPWO");
        arrControlid.Add("txtAmtCPWO");
        arrControlid.Add("ddlTreasuryCPWO");
        arrControlid.Add("ddlLB");
        arrControlid.Add("txtRemCPWO");
        arrControlid.Add("txtteCPWO");

        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();

        arrControlid.Add("intId");

        arrControlid.Add("intChalNo");
        arrControlid.Add("dtmChalDt");
        arrControlid.Add("fltAmt");
        arrControlid.Add("intTreasID");
        arrControlid.Add("intLBID");

        arrControlid.Add("chvDetails");
        arrControlid.Add("chvTEId");

        return arrControlid;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    }
    protected void txtCntRow_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        //chDao = new ChalanDAO();
        ChalAGDao = new ChalanPDEAGDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlTreCPWO");
            arDdl.Add("ddlDist");
            arDdl.Add("ddlLB");
            arDdl.Add("ddlStatus");
            arDdl.Add("ddlreason");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDs.Add(dstreas);

            DataSet dsdist = new DataSet();
            dsdist = teDAO.GetDist();
            arDdlDs.Add(dsdist);

            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDs.Add(dslb);

            DataSet dsstatus = new DataSet();
            dsstatus = teDAO.GetStatus();
            arDdlDs.Add(dsstatus);

            DataSet dsM = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(1);
            dsM = gendao.GetMisClassRsn(arrIn);
            arDdlDs.Add(dsM);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dscrplus = new DataSet();
            ArrayList arr = new ArrayList();

            arr.Add(Convert.ToInt32(Session["GintTEMonthWiseId"]));
            if (Convert.ToInt32(Session["trnTypeAG"]) == 30)
            {
                arr.Add(3);
            }
            else if (Convert.ToInt32(Session["trnTypeAG"]) == 40)
            {
                arr.Add(4);
            }
            dscrplus = ChalAGDao.FillCrPlusDaerAddCol(arr);
            //dscrplus = chDao.FillCrPlusBind(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("intChalanId");
            arHp.Add("flgApproval");
            arHp.Add("flgPrevYear");
            arHp.Add("intGroupId");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs, arHp);
            gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCPW, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeCPW");
        arCols.Add("txtchno");
        arCols.Add("txtChlnDtCPW");
        arCols.Add("txtChlAmtCPW");
        arCols.Add("ddlDist");
        arCols.Add("ddlTreCPWO");
        arCols.Add("ddlLB");
        arCols.Add("chkUnpostCPW");
        arCols.Add("ddlreason");
        arCols.Add("ddlStatus");
        arCols.Add("txtRemarks");
        arCols.Add("lblintIdWth");
        arCols.Add("lblRelMthId");

        arCols.Add("lblSchMnId");
        arCols.Add("lblGrpId");

        arCols.Add("lblMnth");
        arCols.Add("lblDay");
        arCols.Add("lblYearId");
    }
    protected void chkCollect_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void txtChlAmtCPW_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }
    private void FillLbDtWise(int TresId, DropDownList ddlLBAss)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();

        ArrayList arL = new ArrayList();
        DataSet dsL = new DataSet();

        ar.Add(TresId);
        ds = gendao.GetDistIdfromTreasId(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["IntDistIdTECurr"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            arL.Add(Convert.ToInt32(Session["IntDistIdTECurr"]));
            dsL = gendao.GetLBGp(arL);
            gblobj.FillCombo(ddlLBAss, dsL, 1);
        }
    }


    protected void btnDeleteCrplus_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        ChalAGDao = new ChalanPDEAGDAO();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;

        GridViewRow gdvrw = gdvCPW.Rows[rowIndex];
        Label lblintIdWthAss = (Label)gdvrw.FindControl("lblintIdWth");
        Label lblSchMnId = (Label)gdvrw.FindControl("lblSchMnId");
        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        Label txtintChalId = (Label)gdvrw.FindControl("txtintChalId");

        CorrectionEntryForDel(Convert.ToInt32(txtintChalId.Text), txtChlnDtCPWAss.Text.ToString()); //Corr Entry


        ArrayList arrin = new ArrayList();
        int schMainId =Convert.ToInt32(lblSchMnId.Text);
        arrin.Add(Convert.ToInt32(lblintIdWthAss.Text));
        ChalAGDao.DeleteChalanAG(arrin);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(txtintChalId.Text));
        ChalAGDao.DeleteChalanPDE01(ar);

        //DelFromSched(schMainId, txtintChalId, txtChlnDtCPWAss); //Corr Entry
        DelFromSched(Convert.ToInt32(txtintChalId.Text));
        
        ShowCRPlus();
        gblobj.MsgBoxOk("Row Deleted   !", this);

        FillHeadLbls();

    }
    private void CorrectionEntryForDel(float numChalId, string chalDt)
    {
        schedPdeDao = new SchedulePDEDao();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ar.Add(1);
        ds = schedPdeDao.GetSchedDet4CorrEntryAg(ar);
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
        cor.FlgType = 1;           //Remittance
        cor.FltRoundingAmt = 0;
        cor.IntCorrectionType = intCorrTp; //Edit Chal Date
        cor.IntChalanType = ChalType;
        cor.IntTblTp = 1;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
    private void DelFromSched(int chalId)
    {
        schedPdeDao = new SchedulePDEDao();
        genDAO = new KPEPFGeneralDAO();

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(chalId);
        schedPdeDao.delScheduleTR104(ar);
    }
    //private void DelFromSched(int schMainId, Label txtchlIdTBchl, TextBox txtChalDt)
    //{
    //    schedPde = new SchedulePDE();
    //    schedPdeDao = new SchedulePDEDao();
    //    genDAO = new KPEPFGeneralDAO();
    //    double amt;
    //    int chlId;
    //    int NumID;
    //    int NumEmpID;
    //    double fltAmtBfr;
    //    double fltAmtAfr;
    //    ArrayList ar = new ArrayList();
    //    DataSet ds = new DataSet();
    //    ar.Add(schMainId);
    //    ds = schedPdeDao.GetSchedDet4CorrEntry(ar);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[1].ToString());
    //            //amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[2].ToString());
    //            fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[2].ToString());
    //            fltAmtAfr = 0;
    //            amt = fltAmtAfr - fltAmtBfr;
    //            NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
    //            chlId = Convert.ToInt32(txtchlIdTBchl.Text);
    //            ////yr mnth day///////
    //            DateTime dt;
    //            dt = Convert.ToDateTime(txtChalDt.Text.ToString());

    //            intMth = dt.Month;
    //            intDy = dt.Day;

    //            ArrayList ardt = new ArrayList();
    //            ardt.Add(txtChalDt.Text.ToString());
    //            intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);


    //            /////////////////////
    //          //  SaveCorrectionEntry(NumEmpID, chlId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 1);
    //            schedPdeDao.DelTR104PDEMode(ar);
    //        }
    //    }


    //}
    //private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType)
    //{
    //    gendao = new GeneralDAO();
    //    gblobj = new clsGlobalMethods();
    //    cor = new CorrectionEntry();
    //    cord = new CorrectionEntryDao();

    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    //double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //    //double dblCalcAmt = amt;
    //    double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
    //    ///// Save to CorrEntry/////////
    //    cor.IntAccNo = intAccNo;
    //    cor.IntYearID = yr;
    //    cor.IntMonthID = mth;
    //    cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    //if (ChngType == 1)
    //    //{
    //    //    corr.FltAmountBefore = 0;
    //    //}
    //    //else
    //    //{
    //    cor.FltAmountBefore = fltAmtBfr;
    //    //}
    //    cor.FltAmountAfter = fltAmtAfr;
    //    cor.FltCalcAmount = dblAmtAdjusted;
    //    cor.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    cor.IntChalanId = chalId;
    //    cor.IntSchedId = intSchedId;
    //    cor.FlgType = 1;           //Remittance
    //    cor.FltRoundingAmt = 0;
    //    cor.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //    {
    //        cor.IntChalanType = 1;
    //    }
    //    else
    //    {
    //        cor.IntChalanType = 2;
    //    }
    //    cord.CreateCorrEntry(cor);
    //    ///// Save to CorrEntry/////////
    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}
}