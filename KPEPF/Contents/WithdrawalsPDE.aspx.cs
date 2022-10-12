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

public partial class Contents_WithdrawalsPDE : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    GeneralDAO gen = new GeneralDAO();
    WithdrawalC wth = new WithdrawalC();
    WithdrawalCDao wthd = new WithdrawalCDao();
    WithdrawalB wthb = new WithdrawalB();
    WithdrawalBDao wthbd = new WithdrawalBDao();

    public int consamt = 0;
    public int Lbtotamt = 0;
    public int flgamtchange = 0;

    //public static int intWithdrawConId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["intWithdrawConId"]) > 0 && Convert.ToInt32(Request.QueryString["slNo"]) > 0)
            {
                Session["intWithdrawConId"] = Convert.ToInt32(Request.QueryString["intWithdrawConId"]);
                consamt = Convert.ToInt32(Request.QueryString["fltNetAmt"]);
                FillCons();
                //FillChalanS(1);
                SetCtrls();
                SetColorChange(Convert.ToInt32(Request.QueryString["SlNo"]));
                //rdChecked.SelectedItem = Session["flg"].ToString();
                if (Convert.ToInt16(Session["flg"]) == 1)
                {
                    rdChecked.Items[0].Selected = true;
                    FillChalanS(1);
                }
                else if (Convert.ToInt16(Session["flg"]) == 2)
                {
                    rdChecked.Items[1].Selected = true;
                    FillChalanS(2);
                }
                else
                {
                    rdChecked.Items[2].Selected = true;
                    FillChalanS(3);
                }
            }
            else if (Convert.ToInt32(Request.QueryString["intWithdrawConId"]) > 0)
            {
                Session["intWithdrawConId"] = Convert.ToInt32(Request.QueryString["intWithdrawConId"]);
                fillModal();

                consamt = Convert.ToInt32(Request.QueryString["fltNetAmt"]);
                FillCons();
                FillChalanS(1);
                SetCtrls();

                //Session["intWithdrawConId"] = Convert.ToInt32(Request.QueryString["intWithdrawConId"]);
                //consamt = Convert.ToInt32(Request.QueryString["fltNetAmt"]);
                //FillCons();
                //FillChalanS(1);
                //SetCtrls();
                //SetColorChange(Convert.ToInt32(Request.QueryString["SlNo"]));
            }
            else if (Convert.ToInt32(Session["flgPageBackW"]) == 3)
            {
                //SetDdls();
                FillCons();
                FillChalanS(1);
                SetCtrls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetColorChange(int rw)
    {
        gdvChalanS.Rows[rw - 1].BackColor = System.Drawing.Color.HotPink;
    }
    private void SetColorReset()
    {
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            gdvChalanS.Rows[i].BackColor = System.Drawing.Color.White;
        }
    }
    private void fillModal()
    {
        mdlConfirm.Show();
        DataSet dsw = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intWithdrawConId"]));
        dsw = wthbd.GetTreasuryDetDataTxtsPrev(ar);
        if (dsw.Tables[0].Rows.Count > 0)
        {
            txtAccDt.Text = dsw.Tables[0].Rows[0].ItemArray[1].ToString();
            txtTrnDtn.Text = dsw.Tables[0].Rows[0].ItemArray[2].ToString();
            txtAccAmt.Text = dsw.Tables[0].Rows[0].ItemArray[3].ToString();

        }
    }
    //private void SetDdls()
    //{
    //    InitialSettings();
    //    ddlYear.SelectedValue = Session["IntYearWith1"].ToString();
    //    ddlMnth.SelectedValue = Session["IntMonthWith1"].ToString();
    //    ddldist.SelectedValue = Session["IntDistWith1"].ToString();
    //    ddlDT.SelectedValue = Session["IntDTWith1"].ToString();
    //}
    private void InitialSettings()
    {
        Session["flgPageBackW"] = 3;

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
        //if (Convert.ToInt16(Session["IntDistWith1"]) == 0)
        //{
        //    Session["IntDistWith1"] = 1;
        //}
        //arr.Add(Session["IntDistWith1"]);
        //dsTreas = gen.GetDisTreasuryWith(arr);
        //gblObj.FillCombo(ddlDT, dsTreas, 1);

        SetWith1Default();
        SetWithSTDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 1;
    }
    private void SetWith1Default()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("AccDate");
        ar.Add("TrnDate");
        ar.Add("intWithdrawConId");
        ar.Add("fltNetAmt");
        gblObj.SetGridDefault(gdvChalanS, ar);
        //gdvChalanS.Enabled = false;
    }
    private void SetWithSTDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmBillDaten");
        ar.Add("intBillWiseId");
        ar.Add("fltNetAmt");
        ar.Add("dtmBillDate");
        
        gblObj.SetGridDefault(gdvChalanLB, ar);
        //gdvChalanLB.Enabled = false;
    }
    //protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYear.SelectedIndex > 0)
    //    {
    //        Session["IntYearWith1"] = Convert.ToInt16(ddlYear.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntYearWith1"] = 0;
    //    }
    //    ddlMnth.SelectedValue = "0";
    //    ddldist.SelectedValue = "0";
    //    ddlDT.SelectedValue = "0";
    //    SetWith1Default();
    //    SetWithSTDefault();
    //}
    //protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlMnth.SelectedIndex > 0)
    //    {
    //        Session["IntMonthWith1"] = Convert.ToInt16(ddlMnth.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntMonthWith1"] = 0;
    //    }
    //    ddldist.SelectedValue = "0";
    //    ddlDT.SelectedValue = "0";
    //    SetWith1Default();
    //    SetWithSTDefault();
    //}
    //protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddldist.SelectedIndex > 0)
    //    {
    //        Session["IntDistWith1"] = Convert.ToInt16(ddldist.SelectedValue);
    //        DataSet dsWith = new DataSet();
    //        ArrayList arr = new ArrayList();
    //        arr.Add(Session["IntDistWith1"]);
    //        dsWith = gen.GetDisTreasuryWith(arr);
    //        gblObj.FillCombo(ddlDT, dsWith, 1);
    //    }
    //    else
    //    {
    //        Session["IntDistWith1"] = 0;
    //    }

    //    ddlDT.SelectedValue = "0";
    //    SetWith1Default();
    //    SetWithSTDefault();
    //}
    private void FillChalanS(int tp)
    {
        SetWithSTDefault();
        //gdvChalanS.Enabled = true;
        //gdvChalanLB.Enabled = true;
        DataSet dsRem = new DataSet();
        if (tp == 1)
        {
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToInt16(Session["IntYearWith1"]));
            ar.Add(Convert.ToInt16(Session["IntMonthWith1"]));
            ar.Add(Convert.ToInt16(Session["IntDTWith1"]));
            dsRem = wthbd.GetWithBillsAll(ar);
        }
        else if (tp == 2)
        {
            ArrayList ary = new ArrayList();
            ary.Add(Convert.ToInt16(Session["intWithdrawConId"]));
            dsRem = wthbd.getBillstMapped(ary);
        }
        else 
        {
            ArrayList arn = new ArrayList();
            arn.Add(Convert.ToInt16(Session["intWithdrawConId"]));
            arn.Add(Convert.ToInt32(Session["IntYearWith1"]));
            arn.Add(Convert.ToInt32(Session["IntMonthWith1"]));
            arn.Add(Convert.ToInt32(Session["IntDTWith1"]));
            dsRem = wthbd.getBillsNotMapped(arn);
        }
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsRem;
            gdvChalanLB.DataBind();

            //DataSet dsM = new DataSet();
            //ArrayList arrIn1 = new ArrayList();
            //arrIn1.Add(1);
            //dsM = gen.GetMisClassRsn(arrIn1);

            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");
                TextBox txtBillId = (TextBox)gvr.FindControl("txtBillId");
                txtBillId.Text = dsRem.Tables[0].Rows[i].ItemArray[3].ToString();
                if (Convert.ToInt16(dsRem.Tables[0].Rows[i].ItemArray[4]) == 1)
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
            gblObj.SetFooterTotals(gdvChalanLB, 3);
            //lblSTDet3.Text = gdvChalanLB.FooterRow.Cells[3].Text.ToString();
            //Lbtotamt = Convert.ToInt32(lblSTDet3.Text);
            if (consamt != 0)
            {
                if (consamt != Lbtotamt)
                {
                    gdvChalanLB.FooterRow.Cells[3].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        if (tp == 1)
        {
            SetColorReset();
        }
    }
    //protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlDT.SelectedIndex > 0)
    //    {
    //        Session["IntDTWith1"] = Convert.ToInt16(ddlDT.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntDTWith1"] = 0;
    //    }
    //    SetWith1Default();
    //    SetWithSTDefault();

    //    FillCons();
    //    FillChalanS(2);
    //    SetCtrls();
    //}
    private void SetCtrlsDisable()
    {
        btnSave.Enabled = false;
        lnkChal.Enabled = false;
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");

        //    txtTrnDateAss.ReadOnly = true;
        //    txtTrnDateAss.Enabled = false;
        //    txtAmtAss.ReadOnly = true;

        //}

        //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        //{
        //    GridViewRow gdvrowS = gdvChalanLB.Rows[i];

        //    CheckBox chkAppAss = (CheckBox)gdvrowS.FindControl("chkApp");
        //    chkAppAss.Enabled = false;

        //    //DropDownList ddlReasonAss = (DropDownList)gdvrowS.FindControl("ddlReason");
        //    //ddlReasonAss.Enabled = false;

        //    //TextBox txtBDateAss = (TextBox)gdvrowS.FindControl("txtBDate");
        //    //txtBDateAss.ReadOnly = true;

        //    //TextBox txtAmtAss = (TextBox)gdvrowS.FindControl("txtAmt");
        //    //txtAmtAss.ReadOnly = true;
        //    //txtAmtAss.Enabled = false;

        //}
    }

    private void SetCtrlsEnable()
    {
        btnSave.Enabled = true;
        lnkChal.Enabled = true;
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");

        //    txtTrnDateAss.ReadOnly = false;
        //    txtTrnDateAss.Enabled = true ;
        //    txtAmtAss.ReadOnly = false;

        //}
        //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        //{
        //    GridViewRow gdvrowS = gdvChalanLB.Rows[i];

        //    CheckBox chkAppAss = (CheckBox)gdvrowS.FindControl("chkApp");
        //    chkAppAss.Enabled = true;

        //    //DropDownList ddlReasonAss = (DropDownList)gdvrowS.FindControl("ddlReason");
        //    //ddlReasonAss.Enabled = true;

        //    //TextBox txtBDateAss = (TextBox)gdvrowS.FindControl("txtBDate");
        //    //txtBDateAss.ReadOnly = false;

        //    //TextBox txtAmtAss = (TextBox)gdvrowS.FindControl("txtAmt");
        //    //txtAmtAss.ReadOnly = false ;
        //    //txtAmtAss.Enabled = true;

        //}
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgApp"]) == 2)
        {
            SetCtrlsEnable();
            lblStat.Text = "Rejected";
        }
        else
        {
            SetCtrlsDisable();
            lblStat.Text = "Approved";
        }
    }
    private void FillCons()
    {
        //SetWith1Default();
        gdvChalanS.Enabled = true;
        DataSet dsCons = new DataSet();
        wth.IntYearId = Convert.ToInt16(Session["IntYearWith1"]);
        wth.IntMonthId = Convert.ToInt16(Session["IntMonthWith1"]);
        wth.IntDTId = Convert.ToInt16(Session["IntDTWith1"]);
        wth.IntSourceId = 1;
        dsCons = wthd.GetWithCons(wth);

        if (dsCons.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsCons;
            gdvChalanS.DataBind();
            for (int i = 0; i < gdvChalanS.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanS.Rows[i];
                Label lblWithConIdAss = (Label)gvr.FindControl("lblWithConId");
            
                lblWithConIdAss.Text = dsCons.Tables[0].Rows[i].ItemArray[0].ToString();

            }
            Session["flgApp"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[14]);
            gblObj.SetFooterTotals(gdvChalanS, 3);
        }
        FillLabelsMain();
    }
    private void FillLabelsMain()
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearWith1"]));
        Year.Text = gen.GetYearFromId(ar);
        ar.Clear();
        ar.Add(Convert.ToInt16(Session["IntMonthWith1"]));
        Label2.Text = gen.GetMonthFromId(ar);
        ar.Clear();
        ar.Add(Convert.ToInt16(Session["IntDTWith1"]));
        Label4.Text = gen.GetDisTreasuryFromId(ar);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveWithdrawCon();
        gblObj.MsgBoxOk("Updated!", this);
    }
    private void SaveWithdrawCon()
    {
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvChalanS.Rows[i];
        //    TextBox txtTrnDateAss = (TextBox)gvr.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
        //    Label lblWithConIdAss = (Label)gvr.FindControl("lblWithConId");

        //    wth.IntYearId = Convert.ToInt16(Session["IntYearWith1"]);
        //    wth.IntMonthId = Convert.ToInt16(Session["IntMonthWith1"]);
        //    wth.IntDTId = Convert.ToInt16(Session["IntDistWith1"]);
        //    wth.IntSourceId = 1;
        //    wth.DtTrnDate = Convert.ToDateTime(txtTrnDateAss.Text);
        //    wth.FltTAdvAmt = Convert.ToInt32(txtAmtAss.Text);
        //    wth.IntWithdrawConId = Convert.ToInt32(lblWithConIdAss.Text);
        //    wth.IntModeChg = 3;
        //    wthd.SaveWithdrawCons(wth);
        //}
        //FillCons();
        saveTr_Bill_Pde();
        FillChalanS(3);
    }
    private void saveTr_Bill_Pde()
    {
        ArrayList aru = new ArrayList();
        aru.Add(Convert.ToInt32(Session["intWithdrawConId"]));
        wthbd.updTr_Bill_Pde(aru);
        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();
            GridViewRow gvr = gdvChalanLB.Rows[i];
            TextBox txtBillId = (TextBox)gvr.FindControl("txtBillId");
            CheckBox chkApp=(CheckBox) gvr.FindControl("chkApp");
            if (chkApp.Checked == true)
            {
                ar.Add(Convert.ToInt32(txtBillId.Text));
                ar.Add(Convert.ToInt32(Session["intWithdrawConId"]));
                ar.Add(3);
                wthd.saveBillAccDtMapping(ar);
            }
        }
    }
    //protected void chkApp_CheckedChanged(object sender, EventArgs e)
    //{
    //    //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
    //    //{
    //    //    GridViewRow gvRw = gdvChalanLB.Rows[i];
    //    //    CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
    //    //    DropDownList ddlReasonAss = (DropDownList)gvRw.FindControl("ddlReason");
    //    //    //FillGridCombo();
    //    //    if (chkAppAss.Checked == true)
    //    //    {
    //    //        ddlReasonAss.Enabled = true;
    //    //        FillGridCombo();
    //    //        //ddlReasonAss.SelectedValue = 4;
    //    //    }
    //    //    else
    //    //    {
    //    //        ddlReasonAss.Enabled = false;
    //    //    }
    //    //}
    //}
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void txtInt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtAccDt_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.isValidDate(txtAccDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtAccDt, Convert.ToInt16(Session["IntYearWith1"]), Convert.ToInt16(Session["IntMonthWith1"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date!!!", this);
                txtAccDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date!!!", this);
        }

        mdlConfirm.Show();
    }
    protected void txtTrnDtn_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.isValidDate(txtTrnDtn, this) == true)
        {
            if (gblObj.CheckChalanDate(txtTrnDtn, Convert.ToInt16(Session["IntYearWith1"]), Convert.ToInt16(Session["IntMonthWith1"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date!!!", this);
                txtTrnDtn.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date!!!", this);
        }

        mdlConfirm.Show();
    }
    protected void gdvChalanS_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        flgamtchange = 1;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("WithdrawalsPDEPrev.aspx");
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        SetWithSTDefault();
        mdlConfirm.Show();
    }
    public void clearnewchalan()
    {
        Session["intSlno"] = 0;
        txtAccDt.Text = "";
        txtTrnDtn.Text = "";
        txtAccAmt.Text = "";
        Session["intWithdrawConId"] = 0;
        //chkShow.Checked = false;
    }
    
    protected void btnDell_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();
        if (Convert.ToInt64(Session["intWithdrawConId"]) > 0)
        {
            //ar.Add(Convert.ToInt64(Session["intWithdrawConId"]));
            //wthd.DelTreasuryDEntries(ar);
            //gblObj.MsgBoxOk("Deleted ", this);
            //FillWithTxts();
            //FillGrid1();
            //FillGrid2(1);
        }
        else
        {
            gblObj.MsgBoxOk("Select data... ", this);
        }
    }
    //private void SaveAccDate()
    //{
    //    ArrayList arr = new ArrayList();
    //    arr.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
    //    arr.Add(Convert.ToDateTime(txtAccDt.Text));


    //    arr.Add(Convert.ToDateTime(txtTrnDtn.Text));
    //    arr.Add(Convert.ToDouble(txtAccAmt.Text));

    //    arr.Add(Convert.ToInt64(Session["intUserId"]));
    //    arr.Add(Convert.ToInt32(Session["intWithdrawConId"]));

    //    wthbd.SaveTreasuryDEntries(arr);
    //}
    private void FillGrid1New()
    {
        DataSet dsRem = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        dsRem = wthbd.GetTreasuryDetData(ar);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsRem;
            gdvChalanS.DataBind();
            gblObj.SetFooterTotals(gdvChalanS, 3);
        }
        else
        {
            SetGridDefault1();
        }
    }
    private void SetGridDefault1()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmAccDate");
        ar.Add("dtmTrnDate");
        ar.Add("fltChalanAmt");
        ar.Add("fltAmt");
        ar.Add("intWithdrawConId");
        gblObj.SetGridDefault(gdvChalanS, ar);
    }
    private void SaveWithdrawConsModal()
    {
        wth.IntYearId = Convert.ToInt16(Session["IntYearWith1"]);
        wth.IntMonthId = Convert.ToInt16(Session["IntMonthWith1"]);
        wth.IntDTId = Convert.ToInt16(Session["IntDTWith1"]); 
        wth.IntSourceId = 1;
        wth.DtAccDate = Convert.ToDateTime(txtAccDt.Text);
        wth.DtTrnDate = Convert.ToDateTime(txtTrnDtn.Text);
        wth.FltTAdvAmt = Convert.ToInt32(txtAccAmt.Text);
        wth.IntWithdrawConId = Convert.ToInt32(Session["intWithdrawConId"]);
        wth.IntModeChg = 3;
        wthd.SaveWithdrawCons(wth);
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        if (CheckMandatoryAccDate() == true)
        {
            SaveWithdrawConsModal();
            gblObj.MsgBoxOk("Saved successfully!!!", this);
            FillCons();
        }
        else
        {
            gblObj.MsgBoxOk("Check  Consolidated grid!", this);
        }
    }
    private Boolean CheckMandatoryAccDate()
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (txtAccDt.Text.ToString() == "" || txtAccDt.Text.ToString() == null)
        {
            gblObj.MsgBoxOk("Must Select Accounting Date", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        if (txtTrnDtn.Text.ToString() == "" || txtTrnDtn.Text.ToString() == null)
        {
            gblObj.MsgBoxOk("Must Select Transaction Date", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    protected void txtTrnDate_TextChanged(object sender, EventArgs e)
    {

    }
    private void SetSaveBtn()
    {
        if (Convert.ToInt16(Session["flg"]) == 3 && Convert.ToInt32(Session["intWithdrawConId"]) > 0)
        {
            btnSave.Enabled = true;
        }
        else
        {
            btnSave.Enabled = false;
        }
    }
    protected void rdChecked_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["flg"] = rdChecked.SelectedValue;
        SetSaveBtn();
        if (Convert.ToInt16(Session["flg"]) == 1)           //Show all
        {
            FillChalanS(1);
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)       // Only checked    
        {
            if (Convert.ToInt32(Session["intWithdrawConId"]) == 0)
            {
                gblObj.MsgBoxOk("Select an item!!", this);
            }
            else
            {
                FillChalanS(2);
            }
        }
        else                                                // Only checked    
        {
            if (Convert.ToInt32(Session["intWithdrawConId"]) == 0)
            {
                gblObj.MsgBoxOk("Select an item!!", this);
            }
            else
            {
                FillChalanS(3);
            }
        }
    }

}
