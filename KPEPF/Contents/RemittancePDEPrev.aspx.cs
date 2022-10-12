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

public partial class Contents_RemittancePDEPrev : System.Web.UI.Page
{

    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    RemPDE rem;
    RemPDEDao remD;
    RemPDESDao remsd;
    GeneralDAO gen;
    RemPDED remd;
    RemPDEDDao remdDao;

    RemPDEL reml;
    RemPDELDao remld;
    static int intMth = 0;
    static int intDy = 0;
    static int intYrId = 0;

    ChalanPDEDao chalDao;
    ChalanPDEAG chalPde;
    ChalanPDEAGDAO chalPDao;
    SchedulePDEDao schedPdeDao;
    ScheduleMainDAO schMn;
    CorrectionEntry cor = new CorrectionEntry();
    CorrectionEntryDao cord = new CorrectionEntryDao();
    SchedulePDE schedPde;
    static int intCurRwChal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            InitialSettings();
            if (Convert.ToDouble(Session["numChalanIdEdit"]) > 0)
            {
                SetDdls();
                FillCons();
                FillSchedule();
                SetCtrls();
            }
            if (Request.QueryString["intChalanId"] != null)
            {
                SetDdls();
                FillCons();
                FillChalanTxts();
            }
            if (Convert.ToInt32(Session["flgPageBackNew"]) == 4)
            {
                SetDdls();
                FillCons();
                //FillChalanTxts();
                FillSchedule();
            }
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
        GenDao = new KPEPFGeneralDAO();
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
    private void FillGridDataset()
    {
        gblObj = new clsGlobalMethods();
        rem = new RemPDE();
        remD = new RemPDEDao();

        DataSet dsCons = new DataSet();
        rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        rem.FlgSource = 1;
        dsCons = remD.GetConsTreasuryPDE(rem);
        if (dsCons.Tables[0].Rows.Count > 0)
        {
            lblStatus.Text = dsCons.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["flgApp"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[7]);
            lnkChal.Enabled = true;
        }
        else
        {
            SetChalanLBDefault();
            Session["flgApp"] = 0;
        }
    }
    private void FillChalanTxts()
    {
        gblObj = new clsGlobalMethods();
        chalPDao = new ChalanPDEAGDAO();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        mdlConfirm.Show();
        if (Request.QueryString["numChalanId"] != null && Request.QueryString["numChalanId"] != "")
        {
            Session["intChalanId"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
            arr.Add(Session["intChalanId"]);
            ds = chalPDao.RemitancechlntextfillPDE01(arr);
            Session["flgPde"] = 1;
        }
        else
        {
            Session["numChalanId"] = Convert.ToDouble(Request.QueryString["intChalanId"]);
            arr.Add(Session["numChalanId"]);
            ds = chalPDao.RemitancechlntextfillPDE01Replacement(arr);
            Session["flgPde"] = 2;
        }
        FillGridDataset();
        FillCmbLbDt();
        FillComboRsn();
        FillCmb4NewChalan();

        //if (Session["intChalanId"] != null)
        //{
        //arr.Add(Session["intChalanId"]);
        //ds = chalPDao.RemitancechlntextfillPDE01(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtChalNo.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            txtChalDt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtChalAmt.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            ddlLBNew.SelectedValue = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            //ddlchlType.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtchlnId.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString(); // AP_Tresury chalanId
            txtchlIdTBchl.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString(); //TB_chln id
            txtSchMainId.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            txtGrpId.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            lblYr.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            lblMonth.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            lblDy.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[15].ToString()) == 2)
            {
                chkUpN.Checked = true;
                ddlRsnN.SelectedValue = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            }
            else
            {
                chkUpN.Checked = false;
                ddlRsnN.Enabled = false;
                ddlRsnN.SelectedValue = "0";
            }
            ddlsubd.SelectedValue = Request.QueryString["intSTreasuryDetId"];
            ddlFrm.SelectedValue = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        }
        else
        {

        }
    }

    private void SetDdls()
    {
        InitialSettings();
        ddlYear.SelectedValue = Session["IntYearRem1"].ToString();
        ddlMnth.SelectedValue = Session["IntMonthRem1"].ToString();
        ddldist.SelectedValue = Session["IntDistRem1"].ToString();
        ddlDT.SelectedValue = Session["IntDTRem1"].ToString();

    }
    private void FillSchedule()
    {
        gblObj = new clsGlobalMethods();
        rem = new RemPDE();
        remD = new RemPDEDao();
        gen = new GeneralDAO();

        DataSet dsRemS = new DataSet();
        rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        dsRemS = remD.GetChalanPDEAll(rem);
        if (dsRemS.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRemS;
            gdvChalanLB.DataBind();

            DataSet dsM = new DataSet();
            ArrayList arrIn1 = new ArrayList();
            arrIn1.Add(1);
            dsM = gen.GetMisClassRsn(arrIn1);

            if (dsM.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
                {
                    GridViewRow gvr = gdvChalanLB.Rows[i];
                    DropDownList ddlReasonAss = (DropDownList)gvr.FindControl("ddlReason");

                    gblObj.FillCombo(ddlReasonAss, dsM, 1);
                    ddlReasonAss.SelectedValue = dsRemS.Tables[0].Rows[i].ItemArray[13].ToString();
                    CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
                    ddlReasonAss.SelectedValue = dsRemS.Tables[0].Rows[i].ItemArray[13].ToString();

                    if (Convert.ToInt16(dsRemS.Tables[0].Rows[i].ItemArray[9]) == 2)
                    {
                        chkAppAss.Checked = true;
                    }
                    else
                    {
                        chkAppAss.Checked = false;
                    }
                    if (Convert.ToBoolean(dsRemS.Tables[0].Rows[i].ItemArray[11].Equals(DBNull.Value)))
                    {
                        gdvChalanLB.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Red;
                        gdvChalanLB.Rows[i].Cells[1].Font.Bold = true;
                    }

                }
                gblObj.SetFooterTotals(gdvChalanLB, 3);
            }
        }
    }
    //private void FillSTLabel()
    //{
    //    if (intSTreasDet > 0)
    //    {
    //        lblSTDet.Text = dsRemS.Tables[0].Rows[0].ItemArray[0].ToString() + " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
    //    }
    //    else
    //    {
    //        lblSTDet.Text = " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
    //    }
    //}

    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        Session["flgPageBack"] = 3;

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
        if (Convert.ToInt16(Session["IntDistRem1"]) == 0)
        {
            Session["IntDistRem1"] = 1;
        }
        arr.Add(Session["IntDistRem1"]);
        dsTreas = gen.GetDisTreasury(arr);
        gblObj.FillCombo(ddlDT, dsTreas, 1);

        //SetChalanSDefault();
        SetChalanLBDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 1;

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
    private void FillGridCombo()
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();

        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gen.GetMisClassRsn(arrIn);

        DataSet dsS = new DataSet();
        ArrayList arrIn2 = new ArrayList();
        arrIn2.Add(Convert.ToInt16(Session["IntDTRem1"]));
        dsS = GenDao.getsubTreasury(arrIn2);

        DataSet dsL = new DataSet();
        ArrayList arrIn3 = new ArrayList();
        arrIn3.Add(Convert.ToInt16(Session["IntDistRemi"]));
        arrIn3.Add(5);
        dsL = gen.GetLB(arrIn3);

        //if (dsM.Tables[0].Rows.Count > 0)
        //{
        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdvChalanLB.Rows[i];
            DropDownList ddlReasonAss = (DropDownList)grdVwRow.FindControl("ddlReason");
            gblObj.FillCombo(ddlReasonAss, dsM, 1);

            //DropDownList ddlSTAss = (DropDownList)grdVwRow.FindControl("ddlST");
            //gblObj.FillCombo(ddlSTAss, dsS, 1);

            //DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            //gblObj.FillCombo(ddlLBAss, dsL, 1);

        }

        //}
    }
    //private void SetChalanSDefault()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("SlNo");
    //    //ar.Add("dtmAccDate");
    //    //ar.Add("dtmTrnDate");
    //    ar.Add("chvTreasuryNameDisp");
    //    //ar.Add("HSum");
    //    ar.Add("intSTreasuryDetId");
    //    gblObj.SetGridDefault(gdvChalanS, ar);
    //}
    private void SetChalanLBDefault()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        //ar.Add("chvTreasuryNameDisp");
        ar.Add("chvEngLBName");
        ar.Add("NetAmt");
        //ar.Add("intChalanNo");
        //ar.Add("ChalanDt");
        ar.Add("intChalanDet");
        ar.Add("numChalanId");
        ar.Add("intGroupId");
        ar.Add("flgPrevYear");
        ar.Add("flgApproval");
        ar.Add("intChalanId");
        ar.Add("intSTreasuryDetId");
        ar.Add("charType");
        gblObj.SetGridDefault(gdvChalanLB, ar);
        chkShow.Checked = false;
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["IntYearRem1"] = Convert.ToInt16(ddlYear.SelectedValue);
            ddlMnth.SelectedValue = "0";
            ddldist.SelectedValue = "0";
            ddlDT.SelectedValue = "0";
        }
        else
        {
            Session["IntYearRem1"] = 0;
            ddlMnth.SelectedValue = "0";
            ddldist.SelectedValue = "0";
            ddlDT.SelectedValue = "0";
        }
        SetChalanLBDefault();
    }
    protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMnth.SelectedIndex > 0)
        {
            Session["IntMonthRem1"] = Convert.ToInt16(ddlMnth.SelectedValue);
            ddldist.SelectedValue = "0";
            ddlDT.SelectedValue = "0";
        }
        else
        {
            Session["IntMonthRem1"] = 0;
            ddldist.SelectedValue = "0";
            ddlDT.SelectedValue = "0";
        }
        SetChalanLBDefault();
    }
    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        if (ddldist.SelectedIndex > 0)
        {
            Session["IntDistRem1"] = Convert.ToInt16(ddldist.SelectedValue);
            DataSet dsTreas = new DataSet();
            ArrayList arr = new ArrayList();
            //Session["IntDistRemi"] = Convert.ToInt32(ddldist.SelectedValue);
            arr.Add(Session["IntDistRem1"]);
            dsTreas = gen.GetDisTreasury(arr);
            gblObj.FillCombo(ddlDT, dsTreas, 1);
        }
        else
        {
            Session["IntDistRem1"] = 0;
            ddlDT.SelectedValue = "0";
        }
        SetChalanLBDefault();
    }
    //private void FillChalanS()
    //{
    //    DataSet dsRem = new DataSet();
    //    rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
    //    rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
    //    rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
    //    rem.FlgSource = 1;
    //    dsRem = remD.GetSTreasuryDetPDE(rem);
    //    if (dsRem.Tables[0].Rows.Count > 0)
    //    {
    //        gdvChalanS.DataSource = dsRem;
    //        gdvChalanS.DataBind();
    //        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
    //        {
    //            GridViewRow gvr = gdvChalanS.Rows[i];
    //            TextBox txtAccDateAss = (TextBox)gvr.FindControl("txtAccDate");
    //            TextBox txtTrnDateAss = (TextBox)gvr.FindControl("txtTrnDate");
    //            TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
    //            Label lblSTDetIdAss = (Label)gvr.FindControl("lblSTDetId");
    //            Label lblTreasIdAss = (Label)gvr.FindControl("lblTreasId");
    //            Label lblOldAmtAss = (Label)gvr.FindControl("lblOldAmt");
    //            Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");

    //            txtAccDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[0].ToString();
    //            txtTrnDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[1].ToString();
    //            txtAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[7].ToString();
    //            lblSTDetIdAss.Text = dsRem.Tables[0].Rows[i].ItemArray[11].ToString();
    //            lblTreasIdAss.Text = dsRem.Tables[0].Rows[i].ItemArray[8].ToString();
    //            lblOldAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[7].ToString();
    //            lblEditModeAss.Text = "0";
    //        }
    //        gblObj.SetFooterTotalsTempField(gdvChalanS, 4, "txtAmt", 1);
    //    }
    //}
    protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDT.SelectedIndex > 0)
        {
            Session["IntDTRem1"] = Convert.ToInt16(ddlDT.SelectedValue);
            FillCons();
            SetCtrls();
            //btnTreasRpt.Enabled = true;
        }
        else
        {
            Session["IntDTRem1"] = 0;
            btnTreasRpt.Enabled = false;
        }
        SetChalanLBDefault();
        FillCmbLbDt();
        FillComboRsn();
    }
    private void SetCtrlsDisable()
    {
        txtInt.ReadOnly = true;
        txtInt.Enabled = false;
        txtAmt.ReadOnly = true;
        txtRem.ReadOnly = true;
        btnSave.Enabled = false;
        ddlsubd.Enabled = false;
        ddlRsnN.Enabled = false;
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
        //    Label lblSTDetIdAss = (Label)gdvrow.FindControl("lblSTDetId");

        //    txtAccDateAss.ReadOnly = true;
        //    txtAccDateAss.Enabled = false;
        //    txtTrnDateAss.ReadOnly = true;
        //    txtTrnDateAss.Enabled = false;
        //    txtAmtAss.ReadOnly = true;

        //}

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvChalanLB.Rows[i];
            gdvrowS.Cells[0].Enabled = false;
        } 
    }

    private void SetCtrlsEnable()
    {
        txtInt.ReadOnly = false;
        txtInt.Enabled = true;
        txtAmt.ReadOnly = false;
        txtRem.ReadOnly = false;
        btnSave.Enabled = true;
        ddlsubd.Enabled = true;
        ddlRsnN.Enabled = true;
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
        //    Label lblSTDetIdAss = (Label)gdvrow.FindControl("lblSTDetId");

        //    txtAccDateAss.ReadOnly = false;
        //    txtTrnDateAss.ReadOnly = false;
        //    txtAmtAss.ReadOnly = false;

        //}

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvChalanLB.Rows[i];
            gdvrowS.Cells[0].Enabled = true;
        } 
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgApp"]) == 2)
        {
            SetCtrlsEnable();
        }
        else
        {
            SetCtrlsDisable();
        }
    }
    private void FillCons()
    {
        rem = new RemPDE();
        remD = new RemPDEDao();

        DataSet dsCons = new DataSet();
        rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        rem.FlgSource = 1;
        dsCons = remD.GetConsTreasuryPDE(rem);
        if (dsCons.Tables[0].Rows.Count > 0)
        {
            txtInt.Text = dsCons.Tables[0].Rows[0].ItemArray[0].ToString();
            txtAmt.Text = dsCons.Tables[0].Rows[0].ItemArray[4].ToString();
            txtRem.Text = dsCons.Tables[0].Rows[0].ItemArray[5].ToString();
            Session["flgApp"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[7]);
            Session["intDTreaasuryId"] = Convert.ToInt64(dsCons.Tables[0].Rows[0].ItemArray[6]);
            lblStatus.Text = dsCons.Tables[0].Rows[0].ItemArray[8].ToString();
            if (Convert.ToInt16(Session["flgApp"]) == 2)
            {
                lnkChal.Enabled = true;
            }
            else
            {
                lnkChal.Enabled = false;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        //if (Convert.ToDouble(gdvChalanLB.FooterRow.Cells[3].Text) > 0)
        if (Convert.ToDouble(txtAmt.Text) > 0)
        {
            if (ValidateFields() == true)
            {
                SaveTreasuryD();
                //SaveTreasuryS();
                gblObj.MsgBoxOk("Saved!", this);
            }
            else
            {
                gblObj.MsgBoxOk("Enter details!", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter details!", this);
        }
    }
    public bool ValidateFields()
    {
        bool Valid = true;
        //Valid = true;
        //if (txtEmpName.Text.Trim() == "")
        //{
        //    gblObj.MsgBoxOk("Enter the name of employee ", this);
        //    Valid = false;
        //}
        //else if (ddlDesig.SelectedIndex == 0)
        //{
        //    gblObj.MsgBoxOk("Select the designation of the employee", this);
        //    Valid = false;
        //}
        return Valid;
    }
    //private void SaveTreasuryS()
    //{
    //    for (int i = 0; i < gdvChalanS.Rows.Count; i++)
    //    {
    //        GridViewRow gvRw = gdvChalanS.Rows[i];
    //        Label lblSTDetIdAss = (Label)gvRw.FindControl("lblSTDetId");
    //        Label lblTreasIdAss = (Label)gvRw.FindControl("lblTreasId");
    //        TextBox txtAccDateAss = (TextBox)gvRw.FindControl("txtAccDate");
    //        TextBox txtTrnDateAss = (TextBox)gvRw.FindControl("txtTrnDate");
    //        TextBox txtAmtAss = (TextBox)gvRw.FindControl("txtAmt");
    //        Label lblOldAmtAss = (Label)gvRw.FindControl("lblOldAmt");
    //        Label lblEditModeAss = (Label)gvRw.FindControl("lblEditMode");

    //        if (Convert.ToInt16(lblEditModeAss.Text) > 0)
    //        {
    //            rems.IntDTreasuryDetId = Convert.ToInt32(Session["intDTreaasuryId"]);
    //            rems.IntSTreasuryDetId = Convert.ToInt32(lblSTDetIdAss.Text.ToString());
    //            rems.IntTreasuryId = Convert.ToInt32(lblTreasIdAss.Text.ToString());
    //            rems.DtmAccDate = Convert.ToDateTime(txtAccDateAss.Text.ToString());
    //            rems.DtmTrnDate = Convert.ToDateTime(txtTrnDateAss.Text.ToString());
    //            rems.FltCashAmount = Convert.ToDouble(txtAmtAss.Text.ToString());
    //            rems.FltNetAmount = Convert.ToDouble(txtAmtAss.Text.ToString());
    //            remsd.SaveTreasuryS(rems);
    //        }
    //    }
    //}
    private void SaveTreasuryD()
    {
        remd = new RemPDED();
        remdDao = new RemPDEDDao();

        remd.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        remd.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        remd.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        remd.IntSource = 1;
        remd.DtmIntimation = Convert.ToDateTime(txtInt.Text.ToString());
        remd.FltNetAmount = Convert.ToDouble(txtAmt.Text.ToString());
        remd.StrParticulars = txtRem.Text.ToString();
        remdDao.SaveTreasuryD(remd);
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
        //        ddlReasonAss.Enabled = false ;
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
    //protected void txtAmt_TextChanged(object sender, EventArgs e)
    //{
    //    intCurRwChal = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
    //    GridViewRow gvr = gdvChalanS.Rows[intCurRwChal];
    //    Label lblOldAmtAss = (Label)gvr.FindControl("lblOldAmt");
    //    Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
    //    TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
    //    if (Convert.ToDouble(txtAmtAss.Text) != Convert.ToDouble(lblOldAmtAss.Text))
    //    {
    //        lblEditModeAss.Text = "1";
    //    }
    //}
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShow.Checked == true)
        {
            FillSchedule();          
        }
        else
        {
            SetChalanLBDefault();
        }
        SetCtrls();
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        SetChalanLBDefault();
        FillCmbLbDt();
        FillCmb4NewChalan();
        FillComboRsn();
        mdlConfirm.Show();
    }
    public void clearnewchalan()
    {
        txtchlIdTBchl.Text = "0";
        txtchlnId.Text = "0";
        txtChalNo.Text = "0";
        txtChalDt.Text = "";
        txtChalAmt.Text = "0";
        ddlLBNew.SelectedValue = "0";
        ddlsubTreas.SelectedValue = "0";
        Session["numchalanId"] = "0";
        lblOl.Text = "0";
        lblNw.Text = "0";
        lblEditMode.Text = "0";
        lblDy.Text = "0";
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (CheckMandatoryAccDate(ddlsubd) == true)
        {
            if (CheckMandatory(txtChalAmt, txtChalNo, txtChalDt, ddlsubTreas) == true)
            {
                SaveGrpNdSchMn();
                SaveSchMn();
                SaveTreasuryLB();
                SaveNewChalan();
                if (Convert.ToInt16(lblEditMode.Text) > 0)
                {
                    SaveCorrectionEntryChal(Convert.ToInt32(txtchlnId.Text), Convert.ToInt16(lblEditMode.Text), Convert.ToInt16(Session["IntYearRem1"]), Convert.ToInt16(Session["IntMonthRem1"]), Convert.ToDateTime(txtChalDt.Text).Day);
                }
                gblObj.MsgBoxOk("Saved successfully!!!", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Check  Consolidated grid!", this);
        }
        FillSchedule();
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        schedPdeDao = new SchedulePDEDao();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        ar.Add(2);
        dsChal = schedPdeDao.GetSchedDet4CorrEntryCorr(ar);
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
            cor.IntMonthID = Convert.ToInt16(Session["IntMonthRem1"]);
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            //corr.FltAmountAfter = Math.Round(dblAmtAdjusted);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = Convert.ToInt32(txtchlIdTBchl.Text);
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
                cor.IntTblTp = 1;
                cord.CreateCorrEntryCalcTblTp(cor);
            ///// Save to CorrEntry/////////
        }

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        chalPDao = new ChalanPDEAGDAO();
        chalPde = new ChalanPDEAG();
        schedPdeDao = new SchedulePDEDao();
        ArrayList ar = new ArrayList();

        CorrectionEntryForDel(Convert.ToInt32(txtchlnId.Text)); //Corr Entry
        ar.Add(Convert.ToInt32(Session["intChalanId"]));
        if (Convert.ToInt16(Session["flgPde"]) == 1)
        {
            chalPDao.DeleteChalanPDE01Lat(ar);
            chalPDao.DeleteChalanPDELat(ar);
        }
        else
        {
            chalPDao.DeleteChalanPDELat(ar);
        }

        schedPdeDao.UpdScheduleTR104ModeChalanIdWise(ar);
        FillSchedule();
        gblObj.MsgBoxOk("Deleted ", this);

    }
    private void CorrectionEntryForDel(double numChalId)
    {
        schedPde = new SchedulePDE();
        schedPdeDao = new SchedulePDEDao();
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
        ar.Add(2);
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
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                chlId = Convert.ToInt32(txtchlIdTBchl.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(txtChalDt.Text.ToString());

                intMth = dt.Month;
                intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(txtChalDt.Text.ToString());
                intYrId = GenDao.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, chlId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 1);
                //schedPdeDao.DelTR104PDEMode(ar);
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

    }
    protected void btnCan_Click(object sender, EventArgs e)
    {

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
    //protected void txtChalDt_TextChanged(object sender, EventArgs e)
    //{

    //}
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt, DropDownList ddltre)
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (Convert.ToDouble(txtAmt.Text) == 0 || Convert.ToInt16(txtNo.Text) == 0 || Convert.ToString(txtDt.Text) == "" || Convert.ToInt16(ddltre.SelectedValue) == 0)
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
    private Boolean CheckMandatoryAccDate(DropDownList ddltre)
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (Convert.ToInt32(ddltre.SelectedValue) == 0) 
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
   

    private void SaveGrpNdSchMn()
    {
        schMn = new ScheduleMainDAO();

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(txtGrpId.Text));
        ar.Add(Convert.ToInt64(txtSchMainId.Text));
        ar.Add(Convert.ToInt64(txtChalAmt.Text));
        ar.Add(Convert.ToInt16(ddlLBNew.SelectedValue));
        ds = schMn.AddGroupNdSchMn(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["intGrpId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        }
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
    private void SaveNewChalan()
    {
        GenDao = new KPEPFGeneralDAO();
        chalPde = new ChalanPDEAG();
        chalPDao = new ChalanPDEAGDAO();

        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();
        {
            chalPde.ChalanId = Convert.ToInt32(txtchlIdTBchl.Text);
            chalPde.IntTreasID = Convert.ToInt16(ddlsubTreas.SelectedValue);
            chalPde.IntChalanNo = Convert.ToInt16(txtChalNo.Text);
            chalPde.DtmChalanDt = txtChalDt.Text.ToString();
            chalPde.FltChalanAmt = Convert.ToInt64(txtChalAmt.Text);

            ar.Add(Convert.ToInt16(Session["IntYearRem1"]));
            dsyr = GenDao.GetPDEYrId(ar);
            if (dsyr.Tables[0].Rows.Count > 0)
            {
                chalPde.IntYearID = Convert.ToInt16(dsyr.Tables[0].Rows[0].ItemArray[0]);
            }
            else
            {
                chalPde.IntYearID = 0;
            }
            chalPde.IntModeOfChgID = 2;
            chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
            chalPde.IntChalanAGID = Convert.ToInt32(Session["intChalanRefId"]);
            chalPde.IntLBID = Convert.ToInt16(ddlLBNew.SelectedValue);
            chalPde.IntGroupId  = Convert.ToInt32(Session["intGrpId"]);     //Group Id
            chalPde.IntFrmWhomId = Convert.ToInt16(ddlFrm.SelectedValue);
            chalPDao.SaveChalandetails(chalPde);
        }
    }
    private void FillCmb4NewChalan()
    {
        remsd = new RemPDESDao();
        DataSet dsn = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intDTreaasuryId"]));
        dsn = remsd.GetSTreasuryDet4NewChalan(ar);
        gblObj.FillCombo(ddlsubd, dsn, 1);
    } 
    private void SaveTreasuryLB()  //AP_TreasuryDetailsLB_I1
    {
        gblObj = new clsGlobalMethods();
        reml = new RemPDEL();
        remld = new RemPDELDao();

        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();
        //if (Convert.ToInt32(Session["intSTreasDetId"]) > 0)
        //{
            reml.IntChalanId = Convert.ToInt32(txtchlnId.Text);
            reml.IntSTreasuryDetId = Convert.ToInt32(Session["intSTreasDetId"]);
            reml.IntLBId = Convert.ToInt16(ddlLBNew.SelectedValue);
            reml.IntTreasuryId = Convert.ToInt16(ddlsubTreas.SelectedValue);
            reml.IntChalanType = 1;
            reml.IntChalanNo = Convert.ToInt16(txtChalNo.Text);
            reml.DtmChalanDate = Convert.ToDateTime(txtChalDt.Text.ToString());
            reml.FltAmount = Convert.ToInt64(txtChalAmt.Text);
            if (chkUpN.Checked == true)
            {
                reml.FlgUnPosted = 2;
                reml.IntUnPosingReasonId = Convert.ToInt16(ddlRsnN.SelectedValue);
            }
            else
            {
                reml.FlgUnPosted = 1;
                reml.IntUnPosingReasonId = 0;
            }
            reml.IntModeChg = 2;
            reml.FromWhom = ddlFrm.SelectedItem.ToString();
            dsyr = remld.SaveTreasuryLBPDE(reml);
            if (dsyr.Tables[0].Rows.Count > 0)
            {
                Session["intChalanRefId"] = Convert.ToInt32(dsyr.Tables[0].Rows[0].ItemArray[0]);
            }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Check 4 dat Chalan in d grid!", this);
        //}
    }
    protected void btnTreasRpt_Click(object sender, EventArgs e)
    {
        Response.Redirect("RemittancePDE.aspx");
    }
    //protected void txtChalDt_TextChanged(object sender, EventArgs e)
    //{
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    DateTime dtm = new DateTime();
    //    if (gblObj.isValidDate(txtChalDt, this) == true)
    //    {
    //        if (gblObj.CheckChalanDate(txtChalDt, ddlYear, ddlMnth) == true)
    //        {
    //            dtm = Convert.ToDateTime(txtChalDt.Text);
    //            int monthId = dtm.Month;
    //            //if (monthId != Convert.ToInt32(lblMonth.Text))
    //            if (monthId != Convert.ToInt16(ddlMnth.SelectedValue))
    //            {
    //                gblObj.MsgBoxOk("Month cannot be changed", this);
    //                txtChalDt.Text = "";
    //            }
    //            else
    //            {
    //                if (dtm.Day <= 4 && Convert.ToInt16(lblDy.Text) > 4)
    //                {
    //                    lblEditMode.Text = "1";
    //                }
    //                else if (dtm.Day > 4 && Convert.ToInt16(lblDy.Text) <= 4)
    //                {
    //                    lblEditMode.Text = "2";
    //                }
    //                else
    //                {
    //                    lblEditMode.Text = "0";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            gblObj.MsgBoxOk("Invalid Date", this);
    //        }
    //    }
    //    else
    //    {
    //        gblObj.MsgBoxOk("Invalid Date", this);
    //        txtChalDt.Text = "";
    //    }
    //    mdlConfirm.Show();
    //}
    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        DateTime dtm = new DateTime();
        if (gblObj.isValidDate(txtChalDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtChalDt, ddlYear, ddlMnth) == true)
            {
                if (gblObj.CheckChalanDate(txtChalDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMnth.SelectedValue)) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtChalDt.Text = "";
                }
                else
                {
                    dtm = Convert.ToDateTime(txtChalDt.Text);
                    int monthId = dtm.Month;
                    if (Convert.ToInt16(lblDy.Text) != 0)
                    {
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
                        lblEditMode.Text = "0";
                    }
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtChalDt.Text = "";
        }
        mdlConfirm.Show();
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
    protected void ddlsubd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubd.SelectedIndex > 0)
        {
            Session["intSTreasDetId"] = Convert.ToInt32(ddlsubd.SelectedValue);
        }
        
    }
    protected void ddlRsnN_SelectedIndexChanged(object sender, EventArgs e)
    {
        mdlConfirm.Show();
    }
    protected void ddlsubTreas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
