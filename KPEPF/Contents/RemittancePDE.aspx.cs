
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

public partial class Contents_RemittancePDE : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    RemPDE rem = new RemPDE();
    RemPDEDao remD = new RemPDEDao();
    GeneralDAO gen = new GeneralDAO();
    RemPDED remd = new RemPDED();
    RemPDEDDao remdDao = new RemPDEDDao();
    RemPDES rems = new RemPDES();
    RemPDESDao remsd = new RemPDESDao();
    RemPDEL reml = new RemPDEL();
    RemPDELDao remld = new RemPDELDao();

    static int intCurRwChal = 0;

    //Schedule sch = new Schedule();
    //ScheduleDAO schDao = new ScheduleDAO();
    //WithdrwalDAO withDAO = new WithdrwalDAO();

    //public static int intSTreasDetId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["flgPageBackNew"] = 4;
            if (Convert.ToInt32(Request.QueryString["intSTreasuryDetId"]) > 0)
            {
                Session["intSTreasDetId"] = Convert.ToInt32(Request.QueryString["intSTreasuryDetId"]);
                Session["flgtp"] = Convert.ToInt16(Request.QueryString["flgtp"]);
                FillCons();
                FillChalanS();
                if (Convert.ToInt16(Session["flgtp"]) == 1)
                {
                    FillChalanTxts();
                }
                else
                {
                    FillSchedule(Convert.ToInt32(Session["intSTreasDetId"]));
                }
                SetCtrls();
            }
            else if (Convert.ToInt32(Session["flgPageBack"]) == 3)
            {
                FillCons();
                FillChalanS();
                FillSchedule(Convert.ToInt32(Session["intSTreasDetId"]));
                SetCtrls();
            }
            else
            {
                Session["intSTreasDetId"] = 0;
                InitialSettings();
            }
        }
    }
    private void SetDdls()
    {
        //InitialSettings();
        //ddlYear.SelectedValue = Session["IntYearRem1"].ToString();
        //ddlMnth.SelectedValue = Session["IntMonthRem1"].ToString();
        //ddldist.SelectedValue = Session["IntDistRem1"].ToString();
        //ddlDT.SelectedValue = Session["IntDTRem1"].ToString();

    }
    private void FillSchedule(int intSTreasDet)
    {
        DataSet dsRemS = new DataSet();
        if (intSTreasDet > 0)
        {
            rem.IntSTreasuryDetId = intSTreasDet;
            dsRemS = remD.GetChalanPDE(rem);
        }
        else
        {
            rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
            rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
            rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
            dsRemS = remD.GetChalanPDEAll(rem);
        }
        if (dsRemS.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRemS;
            gdvChalanLB.DataBind();
            //FillGridCombo();

            DataSet dsM = new DataSet();
            ArrayList arrIn1 = new ArrayList();
            arrIn1.Add(1);
            dsM = gen.GetMisClassRsn(arrIn1);

            //DataSet dsS = new DataSet();
            //ArrayList arrIn2 = new ArrayList();
            //arrIn2.Add(Convert.ToInt16(Session["IntDTRem1"]));
            //dsS = GenDao.getsubTreasury(arrIn2);

            //DataSet dsL = new DataSet();
            //ArrayList arrIn3 = new ArrayList();
            //arrIn3.Add(Convert.ToInt16(Session["IntDistRem1"]));
            //arrIn3.Add(5);
            //dsL = gen.GetLB(arrIn3);

            if (dsM.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
                {
                    GridViewRow gvr = gdvChalanLB.Rows[i];
                    //DropDownList ddlSTAss = (DropDownList)gvr.FindControl("ddlST");
                    //DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");
                    DropDownList ddlReasonAss = (DropDownList)gvr.FindControl("ddlReason");

                    gblObj.FillCombo(ddlReasonAss, dsM, 1);
                    ddlReasonAss.SelectedValue = dsRemS.Tables[0].Rows[i].ItemArray[13].ToString();
                    //gblObj.FillCombo(ddlSTAss, dsS, 1);
                    //ddlSTAss.SelectedValue = dsRemS.Tables[0].Rows[i].ItemArray[10].ToString();
                    //gblObj.FillCombo(ddlLBAss, dsL, 1);
                    //ddlLBAss.SelectedValue = dsRemS.Tables[0].Rows[i].ItemArray[7].ToString();

                    //TextBox txtChalanDtAss = (TextBox)gvr.FindControl("txtChalanDt");
                    //txtChalanDtAss.Text = dsRemS.Tables[0].Rows[0].ItemArray[18].ToString();
                    //TextBox txtChalanNoAss = (TextBox)gvr.FindControl("txtChalanNo");
                    //txtChalanNoAss.Text = dsRemS.Tables[0].Rows[0].ItemArray[17].ToString();

                    CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
                    ddlReasonAss.SelectedValue = dsRemS.Tables[0].Rows[i].ItemArray[13].ToString();

                    //TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
                    //txtAmtAss.Text = dsRemS.Tables[0].Rows[0].ItemArray[8].ToString();

                    if (Convert.ToInt16(dsRemS.Tables[0].Rows[i].ItemArray[9]) == 2)
                    {
                        chkAppAss.Checked = true;
                        //chkAppAss.Enabled = true;
                    }
                    else
                    {
                        chkAppAss.Checked = false;
                        //chkAppAss.Enabled = false;
                    }

                    Label lblSlNo = (Label)gvr.FindControl("lblSlNo");
                    lblSlNo.Text = Convert.ToString(i + 1);
                }
                gblObj.SetFooterTotals(gdvChalanLB, 4);
                if (intSTreasDet > 0)
                {
                    lblSTDet.Text = dsRemS.Tables[0].Rows[0].ItemArray[0].ToString() + " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
                }
                else
                {
                    lblSTDet.Text = " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
                }
            }
        }
        else
        {
            SetChalanLBDefault();
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
        Session["flgPageBack"] = 3;

        //DataSet ds = new DataSet();
        //ds = gen.GetDistrict();
        //gblObj.FillCombo(ddldist, ds, 1);
        //DataSet dsyr = new DataSet();
        //dsyr = gen.GetYear();
        //gblObj.FillCombo(ddlYear, dsyr, 1);
        //DataSet dsmnth = new DataSet();
        //dsmnth = gen.GetMonth();
        //gblObj.FillCombo(ddlMnth, dsmnth, 1);

        //DataSet dsTreas = new DataSet();
        //ArrayList arr = new ArrayList();
        //if (Convert.ToInt16(Session["IntDistRem1"]) == 0)
        //{
        //    Session["IntDistRem1"] = 1;
        //}
        //arr.Add(Session["IntDistRem1"]);
        //dsTreas = gen.GetDisTreasury(arr);
        //gblObj.FillCombo(ddlDT, dsTreas, 1);

        SetChalanSDefault();
        SetChalanLBDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 1;
    }
    private void FillGridCombo()
    {
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
    private void SetChalanSDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        //ar.Add("dtmAccDate");
        //ar.Add("dtmTrnDate");
        ar.Add("chvTreasuryNameDisp");
        //ar.Add("HSum");
        ar.Add("intSTreasuryDetId");
        gblObj.SetGridDefault(gdvChalanS, ar);
    }
    private void SetChalanLBDefault()
    {
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
        gblObj.SetGridDefault(gdvChalanLB, ar);
    }
    //protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYear.SelectedIndex > 0)
    //    {
    //        Session["IntYearRem1"] = Convert.ToInt16(ddlYear.SelectedValue);
    //        ddlMnth.SelectedValue = "0";
    //        ddldist.SelectedValue = "0";
    //        ddlDT.SelectedValue = "0";
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }
    //    else
    //    {
    //        Session["IntYearRem1"] = 0;
    //        ddlMnth.SelectedValue = "0";
    //        ddldist.SelectedValue = "0";
    //        ddlDT.SelectedValue = "0";
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }
    //}
    //protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlMnth.SelectedIndex > 0)
    //    {
    //        Session["IntMonthRem1"] = Convert.ToInt16(ddlMnth.SelectedValue);
    //        ddldist.SelectedValue = "0";
    //        ddlDT.SelectedValue = "0";
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }
    //    else
    //    {
    //        Session["IntMonthRem1"] = 0;
    //        ddldist.SelectedValue = "0";
    //        ddlDT.SelectedValue = "0";
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }
    //}
    //protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddldist.SelectedIndex > 0)
    //    {
    //        Session["IntDistRem1"] = Convert.ToInt16(ddldist.SelectedValue);
    //        DataSet dsTreas = new DataSet();
    //        ArrayList arr = new ArrayList();
    //        //Session["IntDistRemi"] = Convert.ToInt32(ddldist.SelectedValue);
    //        arr.Add(Session["IntDistRem1"]);
    //        dsTreas = gen.GetDisTreasury(arr);
    //        gblObj.FillCombo(ddlDT, dsTreas, 1);
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }
    //    else
    //    {
    //        Session["IntDistRem1"] = 0;
    //        ddlDT.SelectedValue = "0";
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }
    //}



    private void FillLabelsMain()
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearRem1"]));
        Year.Text = gen.GetYearFromId(ar);
        ar.Clear();
        ar.Add(Convert.ToInt16(Session["IntMonthRem1"]));
        Label2.Text = gen.GetMonthFromId(ar);
        ar.Clear();
        ar.Add(Convert.ToInt16(Session["IntDTRem1"]));
        Label4.Text = gen.GetDisTreasuryFromId(ar);
    }
    private void FillChalanS()
    {
        DataSet dsRem = new DataSet();
        rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        rem.FlgSource = 1;
        dsRem = remD.GetSTreasuryDetPDE(rem);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsRem;
            gdvChalanS.DataBind();
            for (int i = 0; i < gdvChalanS.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanS.Rows[i];
                TextBox txtAccDateAss = (TextBox)gvr.FindControl("txtAccDate");
                TextBox txtTrnDateAss = (TextBox)gvr.FindControl("txtTrnDate");
                TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
                Label lblSTDetIdAss = (Label)gvr.FindControl("lblSTDetId");
                Label lblTreasIdAss = (Label)gvr.FindControl("lblTreasId");
                Label lblOldAmtAss = (Label)gvr.FindControl("lblOldAmt");
                Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");

                txtAccDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[0].ToString();
                txtTrnDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[1].ToString();
                txtAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[14].ToString();
                lblSTDetIdAss.Text = dsRem.Tables[0].Rows[i].ItemArray[11].ToString();
                lblTreasIdAss.Text = dsRem.Tables[0].Rows[i].ItemArray[8].ToString();
                lblOldAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[7].ToString();
                lblEditModeAss.Text = "0";
            }
            gblObj.SetFooterTotalsTempField(gdvChalanS, 4, "txtAmt", 1);
        }
    }
    //protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlDT.SelectedIndex > 0)
    //    {
    //        Session["IntDTRem1"] = Convert.ToInt16(ddlDT.SelectedValue);
    //        FillCons();
    //        FillChalanS();
    //        FillSchedule(0);
    //        SetCtrls();
    //    }
    //    else
    //    {
    //        Session["IntDTRem1"] = 0;
    //        SetChalanSDefault();
    //        SetChalanLBDefault();
    //    }

    //}
    private void SetCtrlsDisable()
    {
        //txtInt.ReadOnly = true;
        //txtInt.Enabled = false;
        //txtAmt.ReadOnly = true;
        //txtRem.ReadOnly = true;
        btnSave.Enabled = false;
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanS.Rows[i];
            TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
            TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
            TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            Label lblSTDetIdAss = (Label)gdvrow.FindControl("lblSTDetId");

            txtAccDateAss.ReadOnly = true;
            txtAccDateAss.Enabled = false;
            txtTrnDateAss.ReadOnly = true;
            txtTrnDateAss.Enabled = false;
            txtAmtAss.ReadOnly = true;

        }

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvChalanLB.Rows[i];
            //DropDownList ddlSTAss = (DropDownList)gdvrowS.FindControl("ddlST");
            //ddlSTAss.Enabled = false;

            //DropDownList ddlLBAss = (DropDownList)gdvrowS.FindControl("ddlLB");
            //ddlLBAss.Enabled = false;

            //TextBox txtAmtAss = (TextBox)gdvrowS.FindControl("txtAmt");
            //txtAmtAss.ReadOnly = true;
            //txtAmtAss.Enabled = false;

            //CheckBox chkAppAss = (CheckBox)gdvrowS.FindControl("chkApp");
            //chkAppAss.Enabled = false;

            //DropDownList ddlReasonAss = (DropDownList)gdvrowS.FindControl("ddlReason");
            //ddlReasonAss.Enabled = false;

        }
        lnkChal.Enabled = false;
    }
    private void FillChalanTxts()
    {

        clsGlobalMethods gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();

        pnlChalNew.Visible = true;
        FillCmbDT();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["intSTreasDetId"] != null)
        {
            arr.Add(Session["intSTreasDetId"]);
            ds = chDao.RemitanceTextfill(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAccDtE.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtTrnDtE.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtChalAmt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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

    private void FillCmbDT()
    {
        KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        DataSet ds1 = new DataSet();
        ArrayList arr1 = new ArrayList();
        arr1.Add(Session["IntDTRem1"]);
        ds1 = GenDao.getsubTreasury(arr1);
        gblObj.FillCombo(ddlsubTreas, ds1, 1);
    }
    private void SetCtrlsEnable()
    {
        //txtInt.ReadOnly = false;
        //txtInt.Enabled = true ;
        //txtAmt.ReadOnly = false;
        //txtRem.ReadOnly = false;
        btnSave.Enabled = true;
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanS.Rows[i];
            TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
            TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
            TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            Label lblSTDetIdAss = (Label)gdvrow.FindControl("lblSTDetId");

            txtAccDateAss.ReadOnly = false;
            txtTrnDateAss.ReadOnly = false;
            txtAmtAss.ReadOnly = false;

        }

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvChalanLB.Rows[i];
            //DropDownList ddlSTAss = (DropDownList)gdvrowS.FindControl("ddlST");
            //ddlSTAss.Enabled = true ;

            //DropDownList ddlLBAss = (DropDownList)gdvrowS.FindControl("ddlLB");
            //ddlLBAss.Enabled = true;

            //TextBox txtAmtAss = (TextBox)gdvrowS.FindControl("txtAmt");
            //txtAmtAss.ReadOnly = false ;
            //txtAmtAss.Enabled = true;

            //CheckBox chkAppAss = (CheckBox)gdvrowS.FindControl("chkApp");
            //chkAppAss.Enabled = true;

            //DropDownList ddlReasonAss = (DropDownList)gdvrowS.FindControl("ddlReason");
            //ddlReasonAss.Enabled = true;
        }
        lnkChal.Enabled = true;
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
        DataSet dsCons = new DataSet();
        rem.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        rem.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        rem.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        rem.FlgSource = 1;
        dsCons = remD.GetConsTreasuryPDE(rem);
        if (dsCons.Tables[0].Rows.Count > 0)
        {
            //txtInt.Text = dsCons.Tables[0].Rows[0].ItemArray[0].ToString();
            //txtAmt.Text = dsCons.Tables[0].Rows[0].ItemArray[4].ToString();
            //txtRem.Text = dsCons.Tables[0].Rows[0].ItemArray[5].ToString();
            Session["flgApp"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[7]);
            Session["intDTreaasuryId"] = Convert.ToInt64(dsCons.Tables[0].Rows[0].ItemArray[6]);
            lblStatus.Text = dsCons.Tables[0].Rows[0].ItemArray[8].ToString();
        }
        FillLabelsMain();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToDouble(gdvChalanS.FooterRow.Cells[4].Text) > 0)
        {
            if (ValidateFields() == true)
            {
                SaveTreasuryD();
                SaveTreasuryS();
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
    private void SaveTreasuryS()
    {
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvChalanS.Rows[i];
            Label lblSTDetIdAss = (Label)gvRw.FindControl("lblSTDetId");
            Label lblTreasIdAss = (Label)gvRw.FindControl("lblTreasId");
            TextBox txtAccDateAss = (TextBox)gvRw.FindControl("txtAccDate");
            TextBox txtTrnDateAss = (TextBox)gvRw.FindControl("txtTrnDate");
            TextBox txtAmtAss = (TextBox)gvRw.FindControl("txtAmt");
            Label lblOldAmtAss = (Label)gvRw.FindControl("lblOldAmt");
            Label lblEditModeAss = (Label)gvRw.FindControl("lblEditMode");

            if (Convert.ToInt16(lblEditModeAss.Text) > 0)
            {
                rems.IntDTreasuryDetId = Convert.ToInt32(Session["intDTreaasuryId"]);
                rems.IntSTreasuryDetId = Convert.ToInt32(lblSTDetIdAss.Text.ToString());
                rems.IntTreasuryId = Convert.ToInt32(lblTreasIdAss.Text.ToString());
                rems.DtmAccDate = Convert.ToDateTime(txtAccDateAss.Text.ToString());
                rems.DtmTrnDate = Convert.ToDateTime(txtTrnDateAss.Text.ToString());
                rems.FltCashAmount = Convert.ToDouble(txtAmtAss.Text.ToString());
                rems.FltNetAmount = Convert.ToDouble(txtAmtAss.Text.ToString());
                remsd.SaveTreasuryS(rems);
            }
        }
    }
    private void SaveTreasuryD()
    {
        //remd.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
        //remd.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
        //remd.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
        //remd.IntSource = 1;
        //remd.DtmIntimation = Convert.ToDateTime(txtInt.Text.ToString());
        //remd.FltNetAmount = Convert.ToDouble(txtAmt.Text.ToString());
        //remd.StrParticulars = txtRem.Text.ToString();
        //remdDao.SaveTreasuryD(remd);
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
    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        intCurRwChal = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvChalanS.Rows[intCurRwChal];
        Label lblOldAmtAss = (Label)gvr.FindControl("lblOldAmt");
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
        TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
        if (Convert.ToDouble(txtAmtAss.Text) != Convert.ToDouble(lblOldAmtAss.Text))
        {
            lblEditModeAss.Text = "1";
        }
    }
    //protected void btnBack_Click(object sender, EventArgs e)
    //{

    //}
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        FillCmbDT();
        pnlChalNew.Visible = true;

    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        RemPDESDao remSdn = new RemPDESDao();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intSTreasDetId"]));
        ar.Add(Convert.ToInt16(Session["IntYearRem1"]));
        ar.Add(Convert.ToInt16(Session["IntMonthRem1"]));
        ar.Add(Convert.ToInt16(Session["IntDTRem1"]));
        ar.Add(1);
        ar.Add(ddlsubTreas.SelectedValue);
        ar.Add(txtAccDtE.Text);
        ar.Add(txtTrnDtE.Text);
        ar.Add(Convert.ToDouble(txtChalAmt.Text));
        remSdn.SaveTreasurySNew(ar);
        gblObj.MsgBoxOk("Added!!!", this);
        FillChalanS();
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        pnlChalNew.Visible = false;
    }
    protected void txtChalNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlsubTreas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtTrnDtE_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.isValidDate(txtTrnDtE, this) == true)
        {
            if (gblObj.CheckChalanDate(txtTrnDtE, Convert.ToInt16(Session["IntYearRem1"]), Convert.ToInt16(Session["IntMonthRem1"])) == true)
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
            txtTrnDtE.Text = "";
        }
    }
    protected void txtAccDtE_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.isValidDate(txtAccDtE, this) == true)
        {
            if (gblObj.CheckChalanDate(txtAccDtE, Convert.ToInt16(Session["IntYearRem1"]), Convert.ToInt16(Session["IntMonthRem1"])) == true)
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
            txtAccDtE.Text = "";
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/RemittancePDEPrev.aspx";
    }
}
