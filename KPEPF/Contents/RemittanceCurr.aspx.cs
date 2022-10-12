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

public partial class Contents_RemittanceCurr : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    //RemPDED remd = new RemPDED();
    //Chalan chl = new Chalan();
    ChalanDAO chld;
    RemPDES remS;
    RemPDESDao remSD;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["flgPageBack"] = 4;
            if (Convert.ToInt32(Request.QueryString["intTreasEntriesID"]) > 0 && Convert.ToInt32(Request.QueryString["SlNo"]) > 0)
            {
                Session["intTreasEntriesID"] = Convert.ToInt32(Request.QueryString["intTreasEntriesID"]);
                SetLbls();
                FillCons();
                FillChalanSNew();

                SetCtrls();
                SetColorChange(Convert.ToInt32(Request.QueryString["SlNo"]));
                if (Convert.ToInt16(Session["flg"]) == 1)
                {
                    FillScheduleAll();
                }
                else if (Convert.ToInt16(Session["flg"]) == 2)
                {
                    FillSchedule(2);
                }
                else 
                {
                    FillSchedule(3);
                }
                SetSaveBtn();
            }
            else if (Request.QueryString["intTreasEntriesID"] != null)
            {
                Session["intTreasEntriesID"] = Convert.ToInt32(Request.QueryString["intTreasEntriesID"]);
                //if (Convert.ToInt32(Request.QueryString["SlNo"]) > 0)
                //{
                //    Session["intSlno"] = Convert.ToInt32(Request.QueryString["SlNo"]);
                //}
                //else
                //{
                //    Session["intSlno"] = 0;
                //}
                //Session["intTreasEntriesID"] = Convert.ToInt32(Request.QueryString["intTreasEntriesID"]);
                SetCtrls();
                FillCmbLbDt();
                FillChalanTxts();
                FillChalanSNew();
                SetGridDefault2();
            }

            else if (Convert.ToInt32(Session["intTreasuryDId"]) > 0)
            {
                SetLbls();
                FillCons();
                //if (TreasDataExists() == false)
                //{
                    FillChalanSNew();
                //}
                //else
                //{
                //    FillChalanSNew();
                //}
                //FillSchedule(1);
                SetCtrls();
                SetGridDefault2();
            }
            //else
            //{
            //    InitialSettings();
            //    Session["intSTreasDetId"] = 0;
            //    SetCtrls();
            //}
            Session["SessionClear"] = 1;
        }
    }
    private void SetColorChange(int rw)
    {
        gdvChalanS.Rows[rw - 1].BackColor = System.Drawing.Color.HotPink;

        //if (Convert.ToInt16(Session["flgChk"]) == 1)
        //{
        //    chkShow.Checked = true;
        //}
        //else
        //{
        //    chkShow.Checked = false;
        //}
    }

    private void FillChalanTxts()
    {
        remSD = new RemPDESDao();
        mdlConfirm.Show();
        DataSet dsRem = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        dsRem = remSD.GetTreasuryDetDataNw(ar);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            //lblSlNo.Text = Session["intSlno"].ToString();
            //txtAccDt.Text = dsRem.Tables[0].Rows[0].ItemArray[1].ToString();
            txtAccDt.Text = Convert.ToDateTime(dsRem.Tables[0].Rows[0].ItemArray[1]).ToString();
            txtTrnDt.Text = dsRem.Tables[0].Rows[0].ItemArray[2].ToString();
            txtAccAmt.Text = dsRem.Tables[0].Rows[0].ItemArray[3].ToString();
            ddlsubd.SelectedValue = dsRem.Tables[0].Rows[0].ItemArray[4].ToString();
        }
    }
    //private Boolean TreasDataExists()
    //{
    //    Boolean flg = true;
    //    ArrayList arr = new ArrayList();
    //    DataSet dsr = new DataSet();
    //    arr.Add(Convert.ToInt32(Session["intTreasuryDId"]));
    //    dsr = remSD.GetTreasuryDetDataExists(arr);
    //    if (dsr.Tables[0].Rows.Count > 0)
    //    {
    //        flg = true;
    //    }
    //    else
    //    {
    //        flg = false;
    //    }
    //    return flg;
    //}
    private void FillScheduleAll()
    {
        chld = new ChalanDAO();
        gblObj = new clsGlobalMethods();
        DataSet dsRemS = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList ar1 = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intTreasuryDId"]));
        ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        ar.Add(1);
        dsRemS = chld.GetChalanPart(ar);

        if (dsRemS.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRemS;
            gdvChalanLB.DataBind();

            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];

                Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
                lblChalIdC.Text = dsRemS.Tables[0].Rows[i].ItemArray[3].ToString();

                Label lblSchedAmtn = (Label)gvr.FindControl("lblSchedAmtn");
                lblSchedAmtn.Text = dsRemS.Tables[0].Rows[i].ItemArray[6].ToString();

                
                Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
                lblChalTp.Text = dsRemS.Tables[0].Rows[i].ItemArray[4].ToString();

                CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");

                if (dsRemS.Tables[0].Rows[i].ItemArray[4].ToString() == "9")
                {
                    gdvChalanLB.Rows[i].Cells[3].Enabled = false;
                    gdvChalanLB.Rows[i].BackColor  = System.Drawing.Color.Yellow;
                }
                if (dsRemS.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
                {
                    chkAppAss.Checked = true;
                }
                else
                {
                    chkAppAss.Checked = false;
                }

                ////// Add ToolTip ///////////////
                gvr.Cells[3].ToolTip = GetToolTip(Convert.ToDouble(dsRemS.Tables[0].Rows[i].ItemArray[3]));
                ////// Add ToolTip ///////////////

                ////// misMatch in diff colour ///////////////
                if (dsRemS.Tables[0].Rows[i].ItemArray[7].ToString() == "2")
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.DeepPink;
                }
                ////// misMatch in diff colour ///////////////
            }
            gblObj.SetFooterTotals(gdvChalanLB, 4);
            gblObj.SetFooterTotalsTempField(gdvChalanLB, 5, "lblSchedAmtn", 2);
            lblSTDet.Text = dsRemS.Tables[0].Rows[0].ItemArray[1].ToString() + " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
        }
        else
        {
            SetGridDefault2();
        }
    }
    private string GetToolTip(double ChalId)
    {
        chld = new ChalanDAO();
        string str = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(ChalId);
        ds = chld.GetToolTipSlNo(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            str = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return str;
    }
    private void FillSchedule(int tp)
    {
        chld = new ChalanDAO();
        gblObj = new clsGlobalMethods();
        DataSet dsRemS = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList ar1 = new ArrayList();

        //if (tp == 2)
        //{
        //    ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        //}
        //else
        //{
        //    ar.Add(Convert.ToInt32(Session["intTreasuryDId"]));
        //}
        ar.Add(Convert.ToInt32(Session["intTreasuryDId"]));
        ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        ar.Add(tp);
        dsRemS = chld.GetChalanPart(ar);

        if (dsRemS.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRemS;
            gdvChalanLB.DataBind();

            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
                Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
                lblChalIdC.Text = dsRemS.Tables[0].Rows[i].ItemArray[3].ToString();

                Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
                lblChalTp.Text = dsRemS.Tables[0].Rows[i].ItemArray[4].ToString();

                ///////////////// MisClassified //////////////////////
                if (dsRemS.Tables[0].Rows[i].ItemArray[4].ToString() == "9")
                {
                    gdvChalanLB.Rows[i].Cells[3].Enabled = false;
                }
                ///////////////// MisClassified //////////////////////

                if (dsRemS.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
                {
                    chkAppAss.Checked = true;
                }
                else
                {
                    chkAppAss.Checked = false;
                }

            }
            gblObj.SetFooterTotals(gdvChalanLB, 4);
            gblObj.SetFooterTotals(gdvChalanLB, 5);
            lblSTDet.Text = dsRemS.Tables[0].Rows[0].ItemArray[1].ToString() + " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
        }
        else
        {
            SetGridDefault2();
        }
    }
    private void InitialSettings()
    {
        SetLbls();
        SetGridDefault1();
        SetGridDefault2();

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

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdvChalanLB.Rows[i];
            DropDownList ddlReasonAss = (DropDownList)grdVwRow.FindControl("ddlReason");
            gblObj.FillCombo(ddlReasonAss, dsM, 1);

        }

    }
    //private void SetChalanSDefault()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("SlNo");
    //    ar.Add("AccDt");
    //    ar.Add("TrnDt");
    //    ar.Add("chvTreasuryNameDisp");
    //    ar.Add("intTreasuryId");
    //    ar.Add("fltChalanAmt");
    //    ar.Add("intDay");
    //    ar.Add("intDayAccDt");
    //    ar.Add("intTreasEntriesID");

    //    gblObj.SetGridDefault(gdvChalanS, ar);
    //}
    //private void SetChalanLBDefault()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("SlNo");
    //    ar.Add("chvTreasuryNameDisp");
    //    ar.Add("chvEngLBName");
    //    ar.Add("fltChalanAmt");
    //    ar.Add("dtChalanDate");
    //    ar.Add("Rsn");
    //    ar.Add("intChalanDet");
    //    ar.Add("numChalanId");
    //    ar.Add("intGroupId");
    //    ar.Add("flgPrevYear");
    //    ar.Add("flgApproval");
    //    ar.Add("flgChalanType");
    //    gblObj.SetGridDefault(gdvChalanLB, ar);
    //}
    private void SetLbls()
    {
        gen = new GeneralDAO();
        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["IntYearIdRemi"]));
        YearVal.Text = gen.GetYearFromId(ar1);

        ArrayList ar2 = new ArrayList();
        ar2.Add(Convert.ToInt16(Session["IntMonthIdRemi"]));
        Label2Val.Text = gen.GetMonthFromId(ar2);

        ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt16(Session["intDTreasuryId"]));
        ar.Add(Convert.ToInt16(Session["IntTreIdRemi"]));
        Label4Val.Text = gen.GetDisTreasuryFromId(ar);


        //lblAmtBk.Text = FindAmtTreasuryD();
    }
    private void FillChalanSNew()
    {
        remSD = new RemPDESDao();
        gblObj = new clsGlobalMethods();
        DataSet dsRem = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["intTreasuryDId"]));
        dsRem = remSD.GetTreasuryDetData(ar);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsRem;
            gdvChalanS.DataBind();
            //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
            //{
            //    GridViewRow gvr = gdvChalanS.Rows[i];
            //    TextBox txtAccDateAss = (TextBox)gvr.FindControl("txtAccDate");
            //    TextBox txtTrnDateAss = (TextBox)gvr.FindControl("txtTrnDate");
            //    TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
            //    Label lblTreasId = (Label)gvr.FindControl("lblTreasId");

            //    txtAccDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[1].ToString();
            //    txtTrnDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[2].ToString();
            //    txtAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[3].ToString();
            //    lblTreasId.Text = dsRem.Tables[0].Rows[i].ItemArray[4].ToString();
            //}
            gblObj.SetFooterTotals(gdvChalanS, 4);
        }
        else
        {
            SetGridDefault1();
        }
    }
    //private void FillChalanS()
    //{
    //    DataSet dsRem = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(Convert.ToInt32(Session["intTreasuryDId"]));
    //    dsRem = chld.GetSTreasuryDet(ar);
    //    //dsRem = remD.GetSTreasuryDetPDE(rem);
    //    if (dsRem.Tables[0].Rows.Count > 0)
    //    {
    //        gdvChalanS.DataSource = dsRem;
    //        gdvChalanS.DataBind();
    //        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
    //        //{
    //        //    GridViewRow gvr = gdvChalanS.Rows[i];
    //        //    TextBox txtAccDateAss = (TextBox)gvr.FindControl("txtAccDate");
    //        //    TextBox txtTrnDateAss = (TextBox)gvr.FindControl("txtTrnDate");
    //        //    TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
    //        //    Label lblTreasIdAss = (Label)gvr.FindControl("lblTreasId");


    //        //    txtAccDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[0].ToString();
    //        //    txtTrnDateAss.Text = dsRem.Tables[0].Rows[i].ItemArray[1].ToString();
    //        //    txtAmtAss.Text = dsRem.Tables[0].Rows[i].ItemArray[3].ToString();
    //        //    lblTreasIdAss.Text = dsRem.Tables[0].Rows[i].ItemArray[4].ToString();
    //        //}
    //        gblObj.SetFooterTotals(gdvChalanS, 4);
    //    }
    //}
    private void SetCtrlsDisable()
    {
        btnSave.Enabled = false;
        txtAccDt.Enabled = false;
        txtTrnDt.Enabled = false;
        ddlsubd.Enabled = false;
        txtAccAmt.Enabled = false;
        btnNewChal.Enabled = false;
        btnDel.Enabled = false;
        lnkChal.Enabled = false;

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanLB.Rows[i];
            CheckBox chkApp = (CheckBox)gdvrow.FindControl("chkApp");
            chkApp.Enabled = false;
        }

        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");

        //    txtAccDateAss.ReadOnly = true;
        //    txtAccDateAss.Enabled = false;
        //    txtTrnDateAss.ReadOnly = true;
        //    txtTrnDateAss.Enabled = false;
        //    txtAmtAss.ReadOnly = true;
        //}
    }
    private void SetCtrlsEnable()
    {
        //btnSave.Enabled = true;
        txtAccDt.Enabled = true;
        txtTrnDt.Enabled = true;
        ddlsubd.Enabled = true;
        txtAccAmt.Enabled = true;
        btnNewChal.Enabled = true;
        btnDel.Enabled = true;
        lnkChal.Enabled = true;
        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanLB.Rows[i];
            CheckBox chkApp = (CheckBox)gdvrow.FindControl("chkApp");
            chkApp.Enabled = true;
        }
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgApp"]) == 2 || Convert.ToInt16(Session["flgApp"]) == 0 || Convert.ToInt16(Session["flgApp"]) == 10)
        {
            SetCtrlsEnable();
        }
        else
        {
            SetCtrlsDisable();
        }
        //int ff = Convert.ToInt16(Session["flg"]);
        if (Convert.ToInt16(Session["flg"]) == 1)
        {
            rdChecked.Items[0].Selected = true;
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)
        {
            rdChecked.Items[1].Selected = true;
        }
        else
        {
            rdChecked.Items[2].Selected = true;
        }

    }
    //flgAppTOnline

    private void FillCons()
    {
        chld = new ChalanDAO();
        DataSet dsCons = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["intTreasuryDId"]));
        ar.Add(1);
        dsCons = chld.GetAmtLBTot(ar);
        if (dsCons.Tables[0].Rows.Count > 0)
        {
            txtInt.Text = dsCons.Tables[0].Rows[0].ItemArray[3].ToString();
            txtAmt.Text = dsCons.Tables[0].Rows[0].ItemArray[2].ToString();
            //txtRem.Text = dsCons.Tables[0].Rows[0].ItemArray[4].ToString();
            Session["flgApp"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[5]);

            lblAmtBk.Text = dsCons.Tables[0].Rows[0].ItemArray[0].ToString();
            //Session["intDTreaasuryId"] = Convert.ToInt64(dsCons.Tables[0].Rows[0].ItemArray[6]);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        chld = new ChalanDAO();
        gblObj = new clsGlobalMethods();
        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            GridViewRow gvr = gdvChalanLB.Rows[i];
            Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
            Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            ar.Add(Convert.ToInt64(lblChalIdC.Text));
            if (chkApp.Checked == true)
            {
                ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
            }
            else
            {
                ar.Add(0);
            }
            ar.Add(Convert.ToInt16(lblChalTp.Text));
            chld.UpdateChalan_C(ar);
        }
        gblObj.MsgBoxOk("Saved!", this);
        FillChalanSNew();

        //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        //{
        //    ArrayList ar = new ArrayList();
        //    DataSet ds = new DataSet();
        //    GridViewRow gvr = gdvChalanLB.Rows[i];
        //    Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
        //    Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
        //    CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
        //    if (chkApp.Checked == true)
        //    {
        //        ar.Add(Convert.ToInt64(lblChalIdC.Text));
        //        ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
        //        ar.Add(Convert.ToInt64(lblChalTp.Text));
        //        chld.UpdateChalan_C(ar);
        //    }
        //}
        //gblObj.MsgBoxOk("Saved!", this);
        //FillChalanSNew();
    }
    //public bool ValidateFields()
    //{
    //    bool Valid = true;
    //    //Valid = true;
    //    //if (txtEmpName.Text.Trim() == "")
    //    //{
    //    //    gblObj.MsgBoxOk("Enter the name of employee ", this);
    //    //    Valid = false;
    //    //}
    //    //else if (ddlDesig.SelectedIndex == 0)
    //    //{
    //    //    gblObj.MsgBoxOk("Select the designation of the employee", this);
    //    //    Valid = false;
    //    //}
    //    return Valid;
    //}
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

    //        //rems.IntDTreasuryDetId = Convert.ToInt32(Session["intDTreaasuryId"]);
    //        //rems.IntSTreasuryDetId = Convert.ToInt32(lblSTDetIdAss.Text.ToString());
    //        //rems.IntTreasuryId = Convert.ToInt32(lblTreasIdAss.Text.ToString());
    //        //rems.DtmAccDate = Convert.ToDateTime(txtAccDateAss.Text.ToString());
    //        //rems.DtmTrnDate = Convert.ToDateTime(txtTrnDateAss.Text.ToString());
    //        //rems.FltCashAmount = Convert.ToDouble(txtAmtAss.Text.ToString());
    //        //rems.FltNetAmount = Convert.ToDouble(txtAmtAss.Text.ToString());
    //        //remsd.SaveTreasuryS(rems);
    //    }
    //}
    //private void SaveTreasuryD()
    //{
    //    //remd.IntYearID = Convert.ToInt16(Session["IntYearRem1"]);
    //    //remd.IntMonthId = Convert.ToInt16(Session["IntMonthRem1"]);
    //    //remd.IntDTId = Convert.ToInt16(Session["IntDTRem1"]);
    //    //remd.IntSource = 1;
    //    //remd.DtmIntimation = Convert.ToDateTime(txtInt.Text.ToString());
    //    //remd.FltNetAmount = Convert.ToDouble(txtAmt.Text.ToString());
    //    //remd.StrParticulars = txtRem.Text.ToString();
    //    //remdDao.SaveTreasuryD(remd);
    //}
    //protected void chkApp_CheckedChanged(object sender, EventArgs e)
    //{
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
    //}
    //protected void Allchk_CheckedChanged(object sender, EventArgs e)
    //{

    //}
    protected void txtInt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtTrnDate_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvChalanS.Rows[index];
        TextBox txtTrnDate = (TextBox)gvr.FindControl("txtTrnDate");

        if (gblObj.isValidDate(txtTrnDate, this) == true)
        {
            if (gblObj.CheckChalanDate(txtTrnDate, Convert.ToInt16(Session["IntYearIdRemi"]), Convert.ToInt16(Session["IntMonthIdRemi"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtTrnDate.Text = "";
            }
            //if (gblObj.CheckChalanDate(txtTrnDate, Convert.ToInt16(Session["IntYearIdRemi"]), Convert.ToInt16(Session["IntMonthIdRemi"])) == true)
            //{

            //}
            //else
            //{
            //    gblObj.MsgBoxOk("Invalid Date", this);
            //    //gblObj.MsgBoxOk("txtTrnDate  1", this);
                
            //    txtTrnDate.Text = "";
            //}
        }
        else
        {
            //gblObj.MsgBoxOk("Invalid Date", this);
            gblObj.MsgBoxOk("txtTrnDate  2", this);
            txtTrnDate.Text = "";
        }
    }
    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/Remittance.aspx";
    //}

    //  Private Sub hrefNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hrefNext.Click
    //If CInt(intCurrIndex.Text) < CInt(intRecordCount.Text) Then
    //          intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) + CInt(intPageSize.Text))
    //      End If
    //      Test()
    //End Sub
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/Remittance.aspx";
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        SetGridDefault2();
        FillCmbLbDt();
        mdlConfirm.Show();
    }
    protected void ddlRsnN_SelectedIndexChanged(object sender, EventArgs e)
    {
        mdlConfirm.Show();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        remSD = new RemPDESDao();
        chld = new ChalanDAO();
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();
        if (Convert.ToInt64(Session["intTreasEntriesID"]) > 0)
        {
            ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
            remSD.DelTreasuryDEntries(ar);
            chld.DelTr_Chalan_C(ar);
            FillChalanSNew();
            gblObj.MsgBoxOk("Deleted ", this);
            mdlConfirm.Hide();
        }
        else
        {
            gblObj.MsgBoxOk("Select data... ", this);
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        mdlConfirm.Hide();
    }
    protected void ddlsubd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlsubTreas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void txtTrnDt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtTrnDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtTrnDt, Convert.ToInt16(Session["IntYearIdRemi"]), Convert.ToInt16(Session["IntMonthIdRemi"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date!!!", this);
                txtTrnDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date!!!", this);
        }
        mdlConfirm.Show();
    }
    protected void txtAccDt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtAccDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtAccDt, Convert.ToInt16(Session["IntYearIdRemi"]), Convert.ToInt16(Session["IntMonthIdRemi"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date!!!", this);
                //gblObj.MsgBoxOk("txtAccDt  1", this);
                txtAccDt.Text = "";
            }
        }
        else
        {
            //gblObj.MsgBoxOk("Invalid Date!!!", this);
            //gblObj.MsgBoxOk("txtAccDt  2", this);
        }

        mdlConfirm.Show();
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        remSD = new RemPDESDao();
        gblObj = new clsGlobalMethods();
        remSD = new RemPDESDao();
        //remSD.SaveTreasuryDEntries
        if (CheckMandatoryAccDate() == true)
        {
            SaveAccDate();
            FillChalanSNew();
            gblObj.MsgBoxOk("Saved successfully!!!", this);
        }
        else
        {
            gblObj.MsgBoxOk("Check  Consolidated grid!", this);
        }
        //FillSchedule();
    }
    private void SaveAccDate()
    {
        remSD = new RemPDESDao();
        remS = new RemPDES();
        ArrayList arr = new ArrayList();
        remS.IntDTreasuryDetId = Convert.ToInt32(Session["intTreasuryDId"]);
        remS.DtmAccDate = Convert.ToDateTime(txtAccDt.Text);
        remS.DtmTrnDate = Convert.ToDateTime(txtTrnDt.Text);
        remS.FltNetAmount = Convert.ToDouble(txtAccAmt.Text);
        remS.IntUserId = Convert.ToInt64(Session["intUserId"]);
        //remS.IntSlNo = Convert.ToInt32(Session["intSlno"]);
        remS.IntTreasuryId = Convert.ToInt16(ddlsubd.SelectedValue);
        remS.IntSTreasuryDetId = Convert.ToInt32(Session["intTreasEntriesId"]);
        remSD.SaveTreasuryDEntries(remS);
    }
    private Boolean CheckMandatoryAccDate()
    {
        gblObj = new clsGlobalMethods();
        Boolean flg = true;
        if (ddlsubd.SelectedValue == "0" || Convert.ToString(txtAccDt.Text) == "" || Convert.ToString(txtTrnDt.Text) == "")
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

    private void FillCmbLbDt()
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        ArrayList arr = new ArrayList();
        GenDao = new KPEPFGeneralDAO();

        arr.Add(Convert.ToInt16(Session["IntTreIdRemi"]));
        DataSet ds1 = new DataSet();
        ds1 = GenDao.getsubTreasury(arr);
        gblObj.FillCombo(ddlsubd, ds1, 1);

    }
    public void clearnewchalan()
    {
        Session["intSlno"] = 0;
        txtAccDt.Text = "";
        txtTrnDt.Text = "";
        txtAccAmt.Text = "";
        ddlsubd.SelectedValue = "0";
        Session["intTreasEntriesID"] = 0;
        //Session["intTreasuryDId"] = 0;
        //chkShow.Checked = false;
    }

    //protected void chkShow_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkShow.Checked == true)
    //    {
    //        FillScheduleAll();
    //        Session["flgChk"] = 1;
    //    }
    //    else
    //    {
    //        SetGridDefault2();
    //        Session["flgChk"] = 0;
    //    }
    //}
    private void SetGridDefault1()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmAccDate");
        ar.Add("dtmTrnDate");
        ar.Add("chvTreasuryName");
        ar.Add("fltAmt");
        ar.Add("intTreasEntriesID");
        ar.Add("intTreasuryId");
        gblObj.SetGridDefault(gdvChalanS, ar);
    }
    private void SetGridDefault2()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        //ar.Add("SlNo");
        ar.Add("dtChalanDate");
        ar.Add("chvTreasuryName");
        ar.Add("fltChalanAmt");
        ar.Add("numChalanId");
        ar.Add("flgChalanType");
        ar.Add("fltSchedAmt");
        gblObj.SetGridDefault(gdvChalanLB, ar);
    }
    private void SetSaveBtn()
    {
        SetCtrls();
        if (Convert.ToInt16(Session["flgApp"]) == 2 || Convert.ToInt16(Session["flgApp"]) == 0 || Convert.ToInt16(Session["flgApp"]) == 10)
        {
            if (Convert.ToInt16(Session["flg"]) == 3 && Convert.ToInt32(Session["intTreasEntriesID"]) > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
        else
        {
            btnSave.Enabled = false;
        }
        //////////////////////// set sched amt  //////////////////
        if (Convert.ToInt16(Session["flg"]) == 1)
        {
            gdvChalanLB.Columns[5].Visible = true;
        }
        else
        {
            gdvChalanLB.Columns[5].Visible = false;
        }
        //////////////////////// set sched amt  //////////////////
    }
    protected void rdChecked_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        Session["flg"] = rdChecked.SelectedValue;
        //SetSaveBtn();
        if (Convert.ToInt16(Session["flg"]) == 1)           //Show all
        {
            FillScheduleAll(); 
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)       // Only checked    
        {
            if (Convert.ToInt32(Session["intTreasEntriesID"]) == 0)
            {
                gblObj.MsgBoxOk("Select an item!!", this);
            }
            else
            {
                FillChecked(2);
            }
        }
        else                                                // Not checked    
        {
            if (Convert.ToInt32(Session["intTreasEntriesID"]) == 0)
            {
                gblObj.MsgBoxOk("Select an item!!", this);
            }
            else
            {
                FillChecked(3);
            }
        }
        SetSaveBtn();
    }
    private void FillChecked(int tp)
    {
        chld = new ChalanDAO();
        gblObj = new clsGlobalMethods();
        DataSet dsRemS = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList ar1 = new ArrayList();

        //if (tp == 2)
        //{
        //    ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        //}
        //else
        //{
        //    ar.Add(Convert.ToInt32(Session["intTreasuryDId"]));
        //}
        ar.Add(Convert.ToInt32(Session["intTreasuryDId"]));
        ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        ar.Add(tp);
        dsRemS = chld.GetChalanPart(ar);

        if (dsRemS.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRemS;
            gdvChalanLB.DataBind();

            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
                Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
                lblChalIdC.Text = dsRemS.Tables[0].Rows[i].ItemArray[3].ToString();

                Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
                lblChalTp.Text = dsRemS.Tables[0].Rows[i].ItemArray[4].ToString();

                ///////////////// MisClassified //////////////////////
                if (dsRemS.Tables[0].Rows[i].ItemArray[4].ToString() == "9")
                {
                    gdvChalanLB.Rows[i].Cells[3].Enabled = false;
                    gdvChalanLB.Rows[i].Cells[3].Enabled = false;
                    gdvChalanLB.Rows[i].BackColor = System.Drawing.Color.Yellow;
                }
                ///////////////// MisClassified //////////////////////
                if (tp == 1)
                {
                    if (dsRemS.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
                    {
                        chkAppAss.Checked = true;
                    }
                    else
                    {
                        chkAppAss.Checked = false;
                    }
                }
                else if (tp == 2)
                {
                    chkAppAss.Checked = true;
                }
                else 
                {
                    if (dsRemS.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
                    {
                        chkAppAss.Checked = true;
                    }
                    else
                    {
                        chkAppAss.Checked = false;
                    }
                }
            }
            gblObj.SetFooterTotals(gdvChalanLB, 4);
            lblSTDet.Text = dsRemS.Tables[0].Rows[0].ItemArray[1].ToString() + " -- " + gdvChalanLB.FooterRow.Cells[4].Text.ToString();
        }
        else
        {
            SetGridDefault2();
        }
    }

}

