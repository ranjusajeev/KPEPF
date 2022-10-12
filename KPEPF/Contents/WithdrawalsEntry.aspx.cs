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

public partial class Contents_WithdrawalsEntry : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    WithdrwalDAO wthDAO;
    //Withdrawals with = new Withdrawals();
    //ChalanDAO chDAO = new ChalanDAO();
    BillDao blD;
    CorrectionEntry cor;
    CorrectionEntryDao cord;

    public static int Billtype = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["numBillID"]) > 0 || Convert.ToInt32(Session["IntTreIdWit"]) > 0)
            {
                InitialSettings();

                FillGrids();
                SetCtrls();
                FillTxts();
                FillTotLbl();
            }
            else
            {
                InitialSettings();
                FillGrid();
                FillTxts();
                FillExtraGrid();
                SetCtrls();
            }
        }
    }
    private void SetCtrls()
    {

        if (Convert.ToInt16(Session["flgAppWithOnline"]) == 2)
        {
            SetGridsEnable();
            lblmm.Text = "Rejected";
        }
        else if (Convert.ToInt16(Session["flgAppWithOnline"]) == 0)
        {
            SetGridsEnable();
            lblmm.Text = "Not Verified";
        }
        else if (Convert.ToInt16(Session["flgAppWithOnline"]) == 10)
        {
            SetGridsEnable();
            lblmm.Text = "Verified";
        }
        else
        {
            lblmm.Text = "Approved";
            SetGridsDisable();
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
        btnNonLBSave.Enabled = false;

        GridView gdv = gdvWith;
        CheckBox Allchk = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        Allchk.Enabled = false;

        for (int i = 0; i < gdvWith.Rows.Count; i++)
        {
            GridViewRow gvr = gdvWith.Rows[i];
            CheckBox chkApp1 = (CheckBox)gvr.FindControl("chkApp1");
            DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
            //CheckBox Allchk = (CheckBox)gvr.FindControl("Allchk");
            CheckBox chkV = (CheckBox)gvr.FindControl("chkV");

            chkApp1.Enabled = false;
            ddlReason.Enabled = false;
            //Allchk.Enabled = false;
            chkV.Enabled = false;
        }

        for (int i = 0; i < gdvExtra.Rows.Count; i++)
        {
            GridViewRow gvr = gdvExtra.Rows[i];
            TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
            TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
            TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
            TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");

            ImageButton btnAddFloorNew = (ImageButton)gvr.FindControl("btnAddFloorNew");
            ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");

            DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");

            //ddlSubTre.Enabled = false;
            txtExBillNo.ReadOnly = true;
            txtExBillDt.ReadOnly = true;
            txtExAmount.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            btnAddFloorNew.Enabled = false;
            btndelete.Enabled = false;

            ddlBill.Enabled = false;
        }
    }
    private void SetGridsEnable()
    {
        txtInt.ReadOnly = false;
        txtInt.Enabled = true;
        txtAmt.ReadOnly = false;
        txtRem.ReadOnly = false;
        btnEntry.Enabled = true;
        btnNonLBSave.Enabled = true;
        chkVerified.Enabled = true;
        GridView gdv = gdvWith;
        CheckBox Allchk = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        Allchk.Enabled = true;

        for (int i = 0; i < gdvWith.Rows.Count; i++)
        {
            GridViewRow gvr = gdvWith.Rows[i];
            CheckBox chkApp1 = (CheckBox)gvr.FindControl("chkApp1");
            DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
            //CheckBox Allchk = (CheckBox)gvr.FindControl("Allchk");
            CheckBox chkV = (CheckBox)gvr.FindControl("chkV");

            chkApp1.Enabled = true;
            //ddlReason.Enabled = true;
            //Allchk.Enabled = false;
            chkV.Enabled = true;
        }

        for (int i = 0; i < gdvExtra.Rows.Count; i++)
        {
            GridViewRow gvr = gdvExtra.Rows[i];
            TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
            TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
            TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
            TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");

            ImageButton btnAddFloorNew = (ImageButton)gvr.FindControl("btnAddFloorNew");
            ImageButton btndelete = (ImageButton)gvr.FindControl("btndelete");

            DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");

            //ddlSubTre.Enabled = false;
            txtExBillNo.ReadOnly = false;
            txtExBillDt.ReadOnly = false;
            txtExAmount.ReadOnly = false;
            txtRemarks.ReadOnly = false;
            btnAddFloorNew.Enabled = true;
            btndelete.Enabled = true;

            ddlBill.Enabled = true;
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["IntYearIdWit"] = Convert.ToInt16(ddlYear.SelectedValue);
            ddlDis.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
        }
        else
        {
            Session["IntYearIdWit"] = 0;
        }
        ClearCtrl();
        ddlMonth.SelectedValue = "0";
        ddlDis.SelectedValue = "0";
        ddlTresury.SelectedValue = "0";
    }
    protected void ddlDis_SelectedIndexChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        if (ddlYear.SelectedIndex > 0)
        {
            Session["IntDistWit"] = Convert.ToInt16(ddlDis.SelectedValue);
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Session["IntDistWit"]);
            ds = gendao.GetDisTreasuryWith(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gblobj.FillCombo(ddlTresury, ds, 1);
            }
        }
        else
        {
            Session["IntDistWit"] = 0;
        }
        ClearCtrl();
        ddlTresury.SelectedValue = "0";
    }
    private void InitialSettings()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        DataSet ds = new DataSet();
       // ds = genDAO.GetYearOnLineBlockPrev();
        ds = genDAO.GetYearOnLine();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gblobj.FillCombo(ddlYear, ds, 1);
        }
        DataSet ds1 = new DataSet();
        ds1 = genDAO.GetMonth();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gblobj.FillCombo(ddlMonth, ds1, 1);
        }
        DataSet ds2 = new DataSet();
        ds2 = genDAO.GetDistrict();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gblobj.FillCombo(ddlDis, ds2, 1);
        }
        gridDefault();

        Session["flgPageBackW"] = 1;
        Session["flgChalanEditFrmTreasOrAg"] = 1;
    }
    private void gridDefault()
    {
        gblobj = new clsGlobalMethods();
        ArrayList arr = new ArrayList();
        arr.Add("SlNo");
        arr.Add("dtBillDate");
        arr.Add("fltBillAmount");
        arr.Add("numBillID");
        arr.Add("chvBillNo");
        arr.Add("flgBillType");
        arr.Add("intTreasuryId");
        gblobj.SetGridDefault(gdvWith, arr);
        gblobj.SetFooterTotals(gdvWith, 2);

        ArrayList arr1 = new ArrayList();
        arr1.Add("SlNo");
        arr1.Add("chvBillNo");
        arr1.Add("dtBillDate");

        arr1.Add("fltBillAmount");
        arr1.Add("flgBillType");
        arr1.Add("flgUnposted");
        arr1.Add("intUnPostedRsn");
        arr1.Add("numBillID");
        arr1.Add("intBillNo");
        arr1.Add("fltAllottedAmt");
        arr1.Add("intTreasuryId");
        gblobj.SetGridDefault(gdvExtra, arr1);
        gblobj.SetFooterTotals(gdvExtra, 3);
        //FillGdvComboBillType();
    }
    private void FillGrids()
    {
        if (Convert.ToInt16(Session["IntTreIdWit"].ToString()) > 0)
        {
            FillGrid();
            FillTxts();
            SetCmbs();
            if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
            {
                FillGrid();
            }
            else
            {
                ClearFirstGrid();
            }
            FillExtraGrid();
        }
    }
    private void SetCmbs()
    {
        ddlYear.SelectedValue = Session["IntYearIdWit"].ToString();
        ddlMonth.SelectedValue = Session["IntMonthIdWit"].ToString();
        ddlDis.SelectedValue = Session["IntDistWit"].ToString();
        FillDT();
        ddlTresury.SelectedValue = Session["IntTreIdWit"].ToString();
    }
    private void FillDT()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        DataSet dsTreas = new DataSet();
        ArrayList arrd = new ArrayList();
        arrd.Add(Convert.ToInt16(Session["IntDistWit"]));
        dsTreas = gendao.GetDisTreasury(arrd);
        gblobj.FillCombo(ddlTresury, dsTreas, 1);
    }
    private void FillTxts()
    {
        genDAO = new KPEPFGeneralDAO();
        ArrayList arr = new ArrayList();
        arr.Add(Session["IntYearIdWit"]);
        arr.Add(Session["IntMonthIdWit"]);
        arr.Add(Session["IntTreIdWit"]);
        arr.Add(2);
        DataSet ds = new DataSet();
        ds = genDAO.GetEntryDetail(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            pnlEntry.Visible = true;
            txtInt.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtRem.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtAmt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["flgAppWithOnline"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]);
            Session["numTreasuryDIdWith"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[4]);

            if (Convert.ToInt16(Session["flgAppWithOnline"]) == 10 || Convert.ToInt16(Session["flgAppWithOnline"]) == 1 || Convert.ToInt16(Session["flgAppWithOnline"]) == 2)
            {
            //if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]) == 10 || Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]) == 1 || Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]) == 2)
            //{
                chkVerified.Checked = true;
            }
            else
            {
                chkVerified.Checked = false;
            }
        }
        else
        {
            Session["numTreasuryDIdWith"] = 0;
            Session["flgAppWithOnline"] = 0;
            ClearCtrl();
        }
    }
    private void ClearCtrl()
    {
        txtInt.Text = "";
        txtRem.Text = "";
        txtAmt.Text = "0";
        Session["flgAppWith"] = 0;
        gridDefault();

    }

    protected void ddlTresury_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTresury.SelectedIndex > 0)
        {
            Session["IntTreIdWit"] = Convert.ToInt16(ddlTresury.SelectedValue);
        }
        else
        {
            Session["IntTreIdWit"] = 0;
        }
        ArrayList arr = new ArrayList();
        arr.Add(Session["IntYearIdWit"]);
        arr.Add(Session["IntMonthIdWit"]);
        arr.Add(Session["IntTreIdWit"]);
        FillTxts();
        FillExtraGrid();
        FillTotLbl();
        SetCtrls();
    }
    private void ClearFirstGrid()
    {
        SetGridDefault1();
        gdvWith.Enabled = false;
    }
    private void FillTotLbl()
    {
        if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        {
            if (Convert.ToInt16(gdvWith.Rows.Count) > 0 && Convert.ToInt16(gdvExtra.Rows.Count) > 0)
            {
                lblTotA.Text = Convert.ToString(Convert.ToDouble(gdvWith.FooterRow.Cells[2].Text) + Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text));
            }
        }
        else
        {
            if (Convert.ToInt16(gdvExtra.Rows.Count) > 0)
            {
                lblTotA.Text = Convert.ToString(Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text));
            }
        }
        setTotalTally();

    }
    private void setTotalTally()
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
    protected void btnEntry_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        wthDAO = new WithdrwalDAO();
        if ((txtInt.Text.ToString() == "") || (txtAmt.Text.ToString() == "") && Convert.ToInt16(ddlYear.SelectedValue) > 0 && Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            gblobj.MsgBoxOk("Enter All Details Above", this);
        }
        else
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(Session["IntYearIdWit"]);
            arr1.Add(Session["IntMonthIdWit"]);
            arr1.Add(Session["IntTreIdWit"]);
            arr1.Add(2);
            arr1.Add(Convert.ToDouble(txtAmt.Text));
            arr1.Add(Session["intUserId"]);
            if (chkVerified.Checked == true)
            {
                arr1.Add(10);
            }
            else
            {
                arr1.Add(0);
            }
            arr1.Add(Convert.ToString(DateTime.Now));
            arr1.Add(txtInt.Text.ToString());
            arr1.Add(0);
            arr1.Add(Convert.ToDouble(gdvWith.FooterRow.Cells[2].Text));
            arr1.Add(txtRem.Text.ToString());
            wthDAO.SaveBillToTreasury(arr1);
            FillTxts();
            gblobj.MsgBoxOk("Saved ", this);
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (ddlMonth.SelectedIndex > 0)
        {
            Session["IntMonthIdWit"] = Convert.ToInt16(ddlMonth.SelectedValue);
            ddlDis.SelectedIndex = 0;
            gblobj.CheckValidMonth(Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"]), this, txtAmt);
        }
        else
        {
            Session["IntMonthIdWit"] = 0;
        }
        //SetMonthFlag();
        ClearCtrl();
        ddlDis.SelectedValue = "0";
        ddlTresury.SelectedValue = "0";
    }

    protected void btnTreasRpt_Click(object sender, EventArgs e)
    {
        Response.Redirect("WithdrawalsCurr.aspx");
    }
    protected void chkV_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvWith.Rows[index];
        DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
        CheckBox chkV = (CheckBox)gvr.FindControl("chkV");

        Label lblVrfO = (Label)gvr.FindControl("lblVrfO");
        Label lblVrf = (Label)gvr.FindControl("lblVrf");
        Label lblMd = (Label)gvr.FindControl("lblMd");

        if (chkV.Checked == true)
        {
            lblVrf.Text = "1";
        }
        else
        {
            lblVrf.Text = "2";
        }
        if (Convert.ToInt16(lblVrfO.Text) != Convert.ToInt16(lblVrf.Text))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void btnNonLBSave_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (Convert.ToInt64(Session["numTreasuryDIdWith"]) > 0)
        {
            if (Convert.ToString(txtInt.Text) != "" && Convert.ToDouble(txtAmt.Text) > 0)
            {
                SaveExtra();
                UpdateTreasuryD();
                FillExtraGrid();
                gblobj.MsgBoxOk("Saved", this);
            }
            else
            {
                gblobj.MsgBoxOk("Enter all details!", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Session expired!", this);
        }
    }
    private void UpdateTreasuryD()
    {
        wthDAO = new WithdrwalDAO();
        ArrayList arn = new ArrayList();
        arn.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        arn.Add(FindAmt(1));
        arn.Add(FindAmt(2));
        arn.Add(FindAmt(4));
        arn.Add(0);
        arn.Add(2);
        wthDAO.UpdateTreasuryDMiss(arn);
    }
    private double FindAmtLB()
    {
        double fltAmt = 0;
        fltAmt = Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text.ToString());
        return fltAmt;
    }
    private double FindAmt(int tp)
    {
        double fltAmt = 0;
        for (int i = 0; i < gdvExtra.Rows.Count; i++)
        {
            GridViewRow gvr = gdvExtra.Rows[i];
            DropDownList ddlBillAss = (DropDownList)gvr.FindControl("ddlBill");
            TextBox txtExAmountAss = (TextBox)gvr.FindControl("txtExAmount");
            //if (Convert.ToDouble(txtExAmountAss.Text) > 0)
            if (txtExAmountAss.Text.ToString() != "")
            {
                if (Convert.ToInt16(ddlBillAss.SelectedValue) == tp)
                {
                    fltAmt = fltAmt + Convert.ToDouble(txtExAmountAss.Text);
                }
            }
        }
        return fltAmt;

    }
    private void UpdateBillLb()
    {
        gblobj = new clsGlobalMethods();
        wthDAO = new WithdrwalDAO();
        int flag = 0;
        double amt = 0;
        for (int i = 0; i < gdvWith.Rows.Count; i++)
        {
            if (Convert.ToDouble(gdvWith.FooterRow.Cells[2].Text) > 0)
            {

                GridViewRow gvr = gdvWith.Rows[i];
                Label lblMd = (Label)gvr.FindControl("lblMd");
                if (Convert.ToInt16(lblMd.Text) == 1)
                {
                    ArrayList Arr = new ArrayList();
                    LinkButton LbBill = (LinkButton)gvr.FindControl("lbBill");
                    CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
                    DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
                    Label lblBillIdAss = (Label)gvr.FindControl("lblBillId");
                    CheckBox chkVAss = (CheckBox)gvr.FindControl("chkV");

                    Arr.Add(Convert.ToInt64(lblBillIdAss.Text));
                    Arr.Add(Convert.ToDouble(Session["numTreasuryDIdWith"]));
                    if (chkVAss.Checked == true)
                    {
                        Arr.Add(1);
                    }
                    else
                    {
                        Arr.Add(2);
                    }
                    if (ChkApp1.Checked == true)
                    {
                        if (DdlReason.SelectedIndex > 0)
                        {
                            Arr.Add(2);
                            Arr.Add(Convert.ToInt16(DdlReason.SelectedValue));
                        }
                        else
                        {
                            gblobj.MsgBoxOk("Please Select Reason", this);
                        }
                    }
                    else
                    {
                        Arr.Add(1);
                        Arr.Add(0);
                    }

                    int r = wthDAO.UpdateBill(Arr);
                    //gblobj.MsgBoxOk("Save Successfully", this);

                }
            }
        }
    }

    protected void ddlBill_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdr = gdvExtra.Rows[index];
        setControlDisabled(index);

        DropDownList ddlBill = (DropDownList)gdr.FindControl("ddlBill");
        Label lbltp = (Label)gdr.FindControl("lbltp");
        Label lblMd1 = (Label)gdr.FindControl("lblMd1");
        if (Convert.ToInt16(lbltp.Text) != Convert.ToInt16(ddlBill.SelectedValue))
        {
            lblMd1.Text = "1";
        }
        else
        {
            lblMd1.Text = "0";
        }
    }
    protected void txtExAmount_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        double tAmt = 0;
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdr = gdvExtra.Rows[index];
        TextBox txtExAmount = (TextBox)gdr.FindControl("txtExAmount");
        Label lblSlNo = (Label)gdr.FindControl("lblSlNo");

        if (Convert.ToString(lblSlNo.Text.ToString()) == "" || Convert.ToString(lblSlNo.Text.ToString()) == "0")
        {
            lblSlNo.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvExtra, 3, "txtExAmount", 1);
        FillTotLbl();

        Label lblamtO = (Label)gdr.FindControl("lblamtO");
        Label lblMd1 = (Label)gdr.FindControl("lblMd1");
        if (Convert.ToDouble(lblamtO.Text) != Convert.ToDouble(txtExAmount.Text))
        {
            lblMd1.Text = "1";
        }
        else
        {
            lblMd1.Text = "0";
        }
    }
    protected void txtExBillDt_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvExtra.Rows[index];
        TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
        DateTime dtm = new DateTime();
        if (txtExBillDt.Text != "")
        {
            if (gblobj.isValidDate(txtExBillDt, this) == true)
            {
                if (gblobj.CheckChalanDate(txtExBillDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue)) == true)
                {

                    //if (CheckChalanDateL(txtExBillDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue)) == false)
                    //{
                    //    gblobj.MsgBoxOk("Invalid Date", this);
                    //    txtExBillDt.Text = "";
                    //}
                }
                else
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                    txtExBillDt.Text = "";
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtExBillDt.Text = "";
            }
        }

        Label lbldtO = (Label)gvr.FindControl("lbldtO");
        Label lblMd1 = (Label)gvr.FindControl("lblMd1");
        if (lbldtO.Text.ToString() != "0")
        {
            if (Convert.ToDateTime(lbldtO.Text) != Convert.ToDateTime(txtExBillDt.Text))
            {
                lblMd1.Text = "1";
            }
            else
            {
                lblMd1.Text = "0";
            }
        }
        else
        {
            lblMd1.Text = "1";
        }
    }
    protected void txtInt_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0 && Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            if (gblobj.isValidDate(txtInt, this) == true)
            {
                if (gblobj.CheckChalanDate(txtInt, ddlYear, ddlMonth) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtInt.Text = "";
            }
        }
        else
        {
            gblobj.MsgBoxOk("Select all details...", this);
        }
    }
    private void SetGridDefault1()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvBillNo");
        ar.Add("numBillID");
        ar.Add("dtBillDate");
        ar.Add("fltBillAmount");
        ar.Add("flgUnposted");
        ar.Add("intUnPostedRsn");
        ar.Add("flgBillType");
        ar.Add("intTreasuryId");
        
        gblobj.SetGridDefault(gdvWith, ar);
        gblobj.SetGridGrey(gdvWith);
        gblobj.SetFooterTotals(gdvWith, 2);
    }

    private void SetCols()
    {
        if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        {
            gdvExtra.Columns[5].Visible = false;
            gdvExtra.Columns[6].Visible = false;
            gdvExtra.Columns[7].Visible = false;
            gdvWith.Enabled = true;
        }
        else
        {
            gdvExtra.Columns[5].Visible = true ;
            gdvExtra.Columns[6].Visible = true;
            gdvExtra.Columns[7].Visible = true;
            gdvWith.Enabled = false;
        }
    }
    private void FillGrid()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        wthDAO = new WithdrwalDAO();
        SetGridDefault1();

        ArrayList arr1 = new ArrayList();
        //arr1.Add(Session["IntYearIdWit"]);
        //arr1.Add(Session["IntMonthIdWit"]);
        //arr1.Add(Session["IntTreIdWit"]);
        if (Convert.ToDouble(Session["numTreasuryDIdWith"]) > 0)
        {
            arr1.Add(Session["numTreasuryDIdWith"]);
        }
        else
        {
            arr1.Add(0);
        }
        //Session["numTreasuryDIdWith"]
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds = wthDAO.GetBills(arr1);
        ArrayList arr2 = new ArrayList();
        arr2.Add(2);
        ds1 = genDAO.getReason(arr2);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvWith.DataSource = ds;
            gdvWith.DataBind();
            for (int i = 0; i < gdvWith.Rows.Count; i++)
            {
                GridViewRow gvr = gdvWith.Rows[i];
                CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
                CheckBox chkVAss = (CheckBox)gvr.FindControl("chkV");
                DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
                Label lblBillIdAss = (Label)gvr.FindControl("lblBillId");

                Label lblUnPRO = (Label)gvr.FindControl("lblUnPRO");
                Label lblVrfO = (Label)gvr.FindControl("lblVrfO");
                Label lblUnPR = (Label)gvr.FindControl("lblUnPR");
                Label lblVrf = (Label)gvr.FindControl("lblVrf");

                gblobj.FillCombo(DdlReason, ds1, 1);
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12].ToString()) == 1)
                {
                    ChkApp1.Checked = false;
                    DdlReason.Enabled = false;
                    DdlReason.SelectedValue = 0.ToString();
                    lblUnPRO.Text = 0.ToString();
                    lblUnPR.Text = 0.ToString();
                }
                else
                {
                    ChkApp1.Checked = true;
                    DdlReason.Enabled = true;
                    DdlReason.SelectedValue = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                    lblUnPRO.Text = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                    lblUnPR.Text = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                }
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[16].ToString()) == 1)
                {
                    chkVAss.Checked = true;
                    lblVrfO.Text = "1";
                    lblVrf.Text = "1";
                }
                else
                {
                    chkVAss.Checked = false;
                    lblVrfO.Text = "2";
                    lblVrf.Text = "2";
                }


                lblBillIdAss.Text = ds.Tables[0].Rows[i].ItemArray[15].ToString();
            }
            //gblobj.SetFooterTotals(gdvWith, 2);
        }
        gblobj.SetFooterTotals(gdvWith, 2);
    }

    protected void chkApp1_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvWith.Rows[index];
        DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
        CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
        
        if (ChkApp1.Checked == true)
        {
            DdlReason.Enabled = true;
        }
        else
        {
            DdlReason.Enabled = false;
        }
    }
    private void FillExtraGrid()
    {
        gblobj = new clsGlobalMethods();
        wthDAO = new WithdrwalDAO();
        //DataTable dtExtra = gblobj.SetInitialRow(gdvExtra);
        //ViewState["extra"] = dtExtra;
        SetCols();
        FillExtraGridCombo();
        FillGdvComboBillType();
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        SetGridDefaultOthers();
        if (Session["numTreasuryDIdWith"] != null)
        {
            arr.Add(Session["numTreasuryDIdWith"]);
            arr.Add(2);
        }
        else
        {
            Session["numTreasuryDIdWith"] = 0;
            arr.Add(0);
        }
        //arr.Add(Convert.ToInt16(Session["intMonthFlag"]));
        
        ds = wthDAO.GetBillsextra(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //dtExtra = gblobj.SetGridTableRows(gdvExtra, ds.Tables[0].Rows.Count);
            //ViewState["extra"] = dtExtra;
            gdvExtra.DataSource = ds;
            gdvExtra.DataBind();
            FillExtraGridCombo();
            FillGdvComboBillType();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvExtra.Rows[i];
                TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
                txtExBillNo.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
                txtExBillDt.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
                txtExAmount.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                //DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
                //ddlInst.SelectedValue = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
                ddlBill.SelectedValue = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
                DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");

                Label lblBillIdOAss = (Label)gvr.FindControl("lblBillIdO");
                lblBillIdOAss.Text = ds.Tables[0].Rows[i].ItemArray[15].ToString(); 

                TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");
                txtRemarks.Text = ds.Tables[0].Rows[i].ItemArray[16].ToString();

                //Label lblSlNo = (Label)gvr.FindControl("lblSlNo");
                //lblSlNo.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();  


                Label lblnoO = (Label)gvr.FindControl("lblnoO");
                Label lbldtO = (Label)gvr.FindControl("lbldtO");
                Label lblamtO = (Label)gvr.FindControl("lblamtO");
                Label lbltp = (Label)gvr.FindControl("lbltp");
                Label lblUnPRO1 = (Label)gvr.FindControl("lblUnPRO1");
                Label lblUnPR1 = (Label)gvr.FindControl("lblUnPR1");

                lblnoO.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                lbldtO.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                lblamtO.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                lbltp.Text = ds.Tables[0].Rows[i].ItemArray[11].ToString();

                lblUnPRO1.Text = ds.Tables[0].Rows[i].ItemArray[12].ToString();
                lblUnPR1.Text = ds.Tables[0].Rows[i].ItemArray[12].ToString();

                //lblUnPRO1.Text = ds.Tables[0].Rows[i].ItemArray[15].ToString(); 


                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12].ToString()) == 2)
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[11]) == 4)
                    {
                        chkNonUnpost.Checked = true;
                        ddlReson.SelectedValue = 6.ToString();
                        chkNonUnpost.Enabled = false;
                        lblUnPRO1.Text = 0.ToString();
                        lblUnPR1.Text = 0.ToString();

                    }
                    else
                    {
                        chkNonUnpost.Checked = true;
                        ddlReson.SelectedValue = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                        ddlReson.Enabled = true;
                        lblUnPRO1.Text = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                        lblUnPR1.Text = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                    }
                }
                else
                {
                    chkNonUnpost.Checked = false;
                    ddlReson.SelectedValue = 0.ToString();
                    ddlReson.Enabled = false;
                }

            }
            //gblobj.SetFooterTotalsTempField(gdvExtra, 3, "txtExAmount", 1);
        }
        gblobj.SetFooterTotalsTempField(gdvExtra, 3, "txtExAmount", 1);
    }
    private void SetGridDefaultOthers()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvBillNo");
        ar.Add("fltBillAmount");
        ar.Add("numBillID");
        ar.Add("dtBillDate");
        //ar.Add("flgBillType");
        ar.Add("intBillNo");
        ar.Add("fltAllottedAmt");
        ar.Add("flgBillType");
        ar.Add("intTreasuryId");
        gblobj.SetGridDefault(gdvExtra, ar);
        FillExtraGridCombo();
        FillGdvComboBillType();
    }
    private bool Validchalandate(TextBox txtChDate)
    {
        bool value = true;
        //ArrayList arr = new ArrayList();
        //int Yearid;
        //arr.Add(txtChDate.Text);
        //Yearid = genDAO.FindYearIdFromDate(arr);
        //int MonthId = Convert.ToDateTime(txtChDate.Text).Month;
        //if ((Yearid != Convert.ToInt16(Session["intYearIdWit"])) || (MonthId != Convert.ToInt16(Session["intMonthIdWit"])))
        //{
        //    value = false;
        //}
        return value;
    }
    private void FillGdvComboBillType()
    {
        gblobj = new clsGlobalMethods();
        for (int i = 0; i < gdvExtra.Rows.Count; i++)
        {
            GridViewRow gvr = gdvExtra.Rows[i];
            DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
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
            dr["Type"] = "From Localbody";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Index"] = 4;
            dr["Type"] = "Misclassified";
            dt.Rows.Add(dr);
            gblobj.FillComboDirect(ddlBill, dt, 1);
        }
    }
    private void FillExtraGridCombo()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        DataSet ds2 = new DataSet();
        ArrayList arrre = new ArrayList();
        arrre.Add(2);
        ds2 = genDAO.getReason(arrre);
        for (int i = 0; i < gdvExtra.Rows.Count; i++)
        {
            GridViewRow gvr = gdvExtra.Rows[i];
            //DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
            //gblobj.FillCombo(ddlInst, ds, 1);
            DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
            gblobj.FillCombo(ddlReson, ds2, 1);
            ddlReson.Enabled = false;
        }
    }
    private void SaveBillOther()
    {
        wthDAO = new WithdrwalDAO();
        if (Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text) > 0)
        {
            for (int i = 0; i < gdvExtra.Rows.Count; i++)
            {
                GridViewRow gvr = gdvExtra.Rows[i];
                Label lblMd1 = (Label)gvr.FindControl("lblMd1");
                if (Convert.ToInt16(lblMd1.Text) == 1)
                {
                    TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
                    DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
                    TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
                    TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
                    TextBox txtRem1 = (TextBox)gvr.FindControl("txtRemarks");
                    CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
                    DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
                    DropDownList ddlBillAss = (DropDownList)gvr.FindControl("ddlBill");

                    Label lblBillIdOAss = (Label)gvr.FindControl("lblBillIdO");
                    if (CheckMandatory(txtExAmount, txtExBillNo, txtExBillDt, ddlBill) == true)
                    {
                        ArrayList arr = new ArrayList();
                        arr.Add(Session["IntTreIdWit"]);
                        arr.Add(txtExBillNo.Text);
                        arr.Add(txtExBillDt.Text);
                        arr.Add(Convert.ToDouble(txtExAmount.Text));
                        arr.Add(txtRem1.Text.ToString());
                        arr.Add(Session["intUserId"]);
                        arr.Add(1);
                        arr.Add(Convert.ToDouble(Session["numTreasuryDIdWith"]));
                        arr.Add(1);
                        if (lblBillIdOAss.Text.ToString() != "")
                        {
                            arr.Add(Convert.ToDouble(lblBillIdOAss.Text.ToString()));
                        }
                        else
                        {
                            arr.Add(0);
                        }
                        wthDAO.SaveBillOthers(arr);
                        //}
                    }
                }
            }
        }
    }

    private void SaveExtra()
    {
        wthDAO = new WithdrwalDAO();
        blD = new BillDao();
        if (Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text) > 0)
        {
            for (int i = 0; i < gdvExtra.Rows.Count; i++)
            {
                GridViewRow gvr = gdvExtra.Rows[i];
                Label lblMd1 = (Label)gvr.FindControl("lblMd1");
                Label lbltp = (Label)gvr.FindControl("lbltp");
                DropDownList ddlBillAss = (DropDownList)gvr.FindControl("ddlBill");
                Label lblBillIdOAss = (Label)gvr.FindControl("lblBillIdO");

                ////////////////// Del and Save
                if (Convert.ToInt16(lbltp.Text) == 4 && Convert.ToInt16(ddlBillAss.SelectedValue) != 4)
                {
                    ArrayList arrin = new ArrayList();
                    arrin.Add(Convert.ToInt32(lblBillIdOAss.Text));
                    arrin.Add(4);
                    blD.UpdateNillMode(arrin);
                    lblBillIdOAss.Text = "0";
                }
                else if (Convert.ToInt16(lbltp.Text) != 4 && Convert.ToInt16(ddlBillAss.SelectedValue) == 4)
                {
                    ArrayList arrin = new ArrayList();
                    if (lblBillIdOAss.Text != "" && lblBillIdOAss.Text != null)
                    {
                        arrin.Add(Convert.ToInt32(lblBillIdOAss.Text));
                    }
                    else
                    {
                        arrin.Add(0);
                    }
                    arrin.Add(2);
                    blD.UpdateNillMode(arrin);
                    lblBillIdOAss.Text = "0";
                }
                /////////////////

                if (Convert.ToInt16(lblMd1.Text) == 1)
                {
                    TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
                    DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
                    TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
                    TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
                    TextBox txtRem1 = (TextBox)gvr.FindControl("txtRemarks");
                    CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
                    DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
                    
                    
                    Label lblSlNo = (Label)gvr.FindControl("lblSlNo");
                    if (CheckMandatory(txtExAmount, txtExBillNo, txtExBillDt, ddlBill) == true)
                    {
                        if (Convert.ToInt16(ddlBill.SelectedValue) <= 3)
                        {
                            ArrayList arr = new ArrayList();
                            arr.Add(txtExBillNo.Text);
                            arr.Add(txtExBillDt.Text);
                            arr.Add(Convert.ToDouble(txtExAmount.Text));
                            arr.Add(Session["intUserId"]);
                            arr.Add(Session["IntTreIdWit"]);

                            if (chkNonUnpost.Checked == true)
                            {
                                arr.Add(2);
                                arr.Add(Convert.ToInt16(ddlReson.SelectedValue));
                            }
                            else if (chkNonUnpost.Checked == false)
                            {
                                arr.Add(1);
                                arr.Add(0);
                            }
                            arr.Add(txtRem1.Text);
                            arr.Add(1);
                            arr.Add(0);
                            arr.Add(Convert.ToInt16(ddlBillAss.Text));
                            arr.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
                            //arr.Add(Convert.ToInt16(lblSlNo.Text));
                            arr.Add(Convert.ToInt32(txtExBillNo.Text));
                            if (Convert.ToString(lblBillIdOAss.Text.ToString()) == "" || Convert.ToString(lblBillIdOAss.Text.ToString()) == "0")
                            {
                                lblBillIdOAss.Text = "0";
                            }
                            arr.Add(Convert.ToInt32(lblBillIdOAss.Text));
                            wthDAO.SaveExtraBill(arr);
                        }
                        else
                        {
                            ArrayList arr = new ArrayList();
                            arr.Add(Session["IntTreIdWit"]);
                            arr.Add(txtExBillNo.Text);
                            arr.Add(txtExBillDt.Text);
                            arr.Add(Convert.ToDouble(txtExAmount.Text));
                            arr.Add(txtRem1.Text.ToString());
                            arr.Add(Session["intUserId"]);
                            arr.Add(1);
                            arr.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
                            arr.Add(1);
                            if (lblBillIdOAss.Text != "" && lblBillIdOAss.Text != null)
                            {
                                arr.Add(Convert.ToInt32(lblBillIdOAss.Text));
                            }
                            else
                            {
                                arr.Add(0);
                            }
                            wthDAO.SaveBillOthers(arr);
                        }
                    }
                }
            }
        }
    }
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt, DropDownList ddlBill)
    {
        gblobj = new clsGlobalMethods();
        Boolean flg = true;
        if (txtAmt.Text.ToString() == "" || txtNo.Text.ToString() == "" || txtDt.Text.ToString() == "" || Convert.ToInt16(ddlBill.SelectedValue) == 0)
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
    protected void chkNonUnpost_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvExtra.Rows[index];
        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");

        Label lblUnPRO1 = (Label)gvr.FindControl("lblUnPRO1");
        Label lblUnPR1 = (Label)gvr.FindControl("lblUnPR1");
        Label lblMd1 = (Label)gvr.FindControl("lblMd1");


        if (chkNonUnpost.Checked == true)
        {
            ddlReson.Enabled = true;
            lblUnPR1.Text = "0";
        }
        else
        {
            ddlReson.Enabled = false;
            lblUnPR1.Text = "1";
        }

        if (Convert.ToInt16(lblUnPRO1.Text) != Convert.ToInt16(lblUnPR1.Text))
        {
            lblMd1.Text = "1";
        }
        else
        {
            lblMd1.Text = "0";
        }
    }
    private void setControlDisabled(int i)
    {
        GridViewRow gvr = gdvExtra.Rows[i];
        DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
        CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
        if (Convert.ToInt16(ddlBill.SelectedValue) == 4)
        {
            chkNonUnpost.Enabled = false;
            chkNonUnpost.Checked = true;
            ddlReson.Enabled = false;
            ddlReson.SelectedValue = 6.ToString();
        }
        else
        {
            chkNonUnpost.Enabled = true;
            ddlReson.SelectedIndex = 0;
        }
    }
    private bool ValidIntimationdate(TextBox txtIntiDate)
    {
        genDAO = new KPEPFGeneralDAO();
        bool value = true;
        ArrayList arr = new ArrayList();
        int Yearid;
        arr.Add(txtIntiDate.Text);
        Yearid = genDAO.FindYearIdFromDate(arr);
        int MonthId = Convert.ToDateTime(txtIntiDate.Text).Month;
        DateTime dt = DateTime.Now;
        DataSet ds = new DataSet();
        ArrayList arr1 = new ArrayList();
        arr1.Add(Session["intMonthIdWit"]);
        arr1.Add(Session["intYearIdWit"]);
        ds = genDAO.GetDate(arr1);
        DateTime dt1 = new DateTime();
        dt1 = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[0]);
        if ((Yearid != Convert.ToInt16(Session["intYearIdWit"])) || (dt1 > Convert.ToDateTime(txtIntiDate.Text)) || (dt >= Convert.ToDateTime(txtIntiDate.Text)))
        {
            value = false;
        }
        return value;
    }
    protected void btnCon_Click(object sender, EventArgs e)
    {
        //    Response.Redirect("WithConsol.aspx");
    }
    
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblobj.checkLastRowStatus(myControls, arrControlid, gdvExtra);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblobj.AddNewRow(myControls, arrControlid, arrDT, gdvExtra);
            DataSet ds = new DataSet();
            gdvExtra.DataSource = dtgdRow;
            gdvExtra.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvExtra, ds);
        }
        gblobj.SetFooterTotalsTempField(gdvExtra, 3, "txtExAmount", 1);
    }
    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new CheckBox());
        myControls.Add(new DropDownList());
        myControls.Add(new Label());
        myControls.Add(new Label());

        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();

        arrControlid.Add("txtExBillNo");
        arrControlid.Add("txtExBillDt");
        arrControlid.Add("txtExAmount");
        arrControlid.Add("ddlBill");
        arrControlid.Add("chkNonUnpost");
        arrControlid.Add("ddlReson");
        arrControlid.Add("lblBillIdO");
        arrControlid.Add("lblSlNo");
            

        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();

        arrControlid.Add("chvBillNo");
        arrControlid.Add("dtBillDate");

        arrControlid.Add("fltBillAmount");
        arrControlid.Add("flgBillType");
        arrControlid.Add("flgUnposted");
        arrControlid.Add("intUnPostedRsn");
        arrControlid.Add("numBillID");
        arrControlid.Add("intBillNo");
        arrControlid.Add("intTreasuryId");


        return arrControlid;
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        wthDAO = new WithdrwalDAO();
        gendao = new GeneralDAO();
        Session["intCCYearId"] = gendao.GetCCYearId();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblBillIdO = (Label)gdvExtra.Rows[rowIndex].FindControl("lblBillIdO");
        DropDownList ddlBill = (DropDownList)gdvExtra.Rows[rowIndex].FindControl("ddlBill");
        int a = Convert.ToInt32(Session["IntYearIdWit"]);
        int b = Convert.ToInt32(Session["intCCYearId"]);
        if (lblBillIdO.Text.ToString() != "")
        {
            if (Convert.ToInt16(Session["IntYearIdWit"]) <= Convert.ToInt16(Session["intCCYearId"]))
            {
                CorrectionEntryForDel(Convert.ToInt32(lblBillIdO.Text)); //Corr Entry
            }
            
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblBillIdO.Text));
            arrin.Add(Convert.ToInt16(ddlBill.SelectedValue));
            wthDAO.UpdateBillModeCurr(arrin);
        }
        FillExtraGrid();
        FillTotLbl();
        gblobj.MsgBoxOk("Row Deleted   !", this);
    }
    private void CorrectionEntryForDel(float numChalId)
    {
        wthDAO = new WithdrwalDAO();
        double amt;
        int chlId;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ds = wthDAO.getEmpBillwise(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                //amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());

                ////yr mnth day///////
                int intYrId = Convert.ToInt16(Session["IntYearIdWit"]);
                int intMth = Convert.ToInt16(Session["IntMonthIdWit"]);
                int intDy = 10;
                ////yr mnth day///////
                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 9, fltAmtBfr, fltAmtAfr, 1);
                //schedPdeDao.DelTR104PDEMode(ar);
            }
        }
    }
    private void SaveCorrectionEntry(int intAccNo, float chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType)
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
        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }
    private void deleteUnsavedwith()
    {
        gblobj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblobj.deleteRows(myControls, arrControlid, arrDT, gdvExtra);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvExtra.DataSource = dtgdRow;
            gdvExtra.DataBind();
            ds.Tables.Add(dtgdRow);
            // fillDropDownGridExistsFloor(gdvCM, ds);
        }
        else
        {
            FillExtraGrid();
        }
    }
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {
        FillGdvComboBillType();
        FillExtraGridCombo();
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {

                    DropDownList ddlBill = (DropDownList)gdRow.FindControl("ddlBill");
                    ddlBill.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][3].ToString();

                    DropDownList ddlReson = (DropDownList)gdRow.FindControl("ddlReson");
                    //ddlReson.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][5].ToString();


                    CheckBox chkNonUnpost = (CheckBox)gdRow.FindControl("chkNonUnpost");
                    //if ((ds.Tables[0].Rows[gdRow.RowIndex][4].ToString()) != "")
                    //{
                    //    if (Convert.ToBoolean(ds.Tables[0].Rows[gdRow.RowIndex][2]) == true)
                    //    {
                    //        chkNonUnpost.Checked = true;
                    //    }
                    //    else
                    //    {
                    //        chkNonUnpost.Checked = false;
                    //    }
                    //}
                    if ((ds.Tables[0].Rows[gdRow.RowIndex][4].ToString()) != "")
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[gdRow.RowIndex][4]) == true)
                        {
                            if (Convert.ToInt32(ds.Tables[0].Rows[gdRow.RowIndex][3]) == 4)
                            {
                                chkNonUnpost.Checked = true;
                                ddlReson.SelectedValue = 6.ToString();
                                chkNonUnpost.Enabled = false;
                            }
                            else
                            {
                                chkNonUnpost.Checked = true;
                                ddlReson.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][5].ToString();
                                ddlReson.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        chkNonUnpost.Checked = false;
                        ddlReson.SelectedValue = 0.ToString();
                        ddlReson.Enabled = false;
                    }
                }
            }
        }
    }

    protected void gdvExtra_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvWith.Rows[index];
        DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
        
        Label lblUnPRO = (Label)gvr.FindControl("lblUnPRO");
        Label lblMd = (Label)gvr.FindControl("lblMd");
        Label lblUnPR = (Label)gvr.FindControl("lblUnPR");
        lblUnPR.Text = ddlReason.SelectedValue.ToString();


        if (Convert.ToInt16(lblUnPRO.Text) != Convert.ToInt16(lblUnPR.Text))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void ddlReson_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvExtra.Rows[index];
        DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");

        Label lblUnPRO1 = (Label)gvr.FindControl("lblUnPRO1");
        Label lblMd1 = (Label)gvr.FindControl("lblMd1");
        Label lblUnPR1 = (Label)gvr.FindControl("lblUnPR1");
        lblUnPR1.Text = ddlReson.SelectedValue.ToString();


        if (Convert.ToInt16(lblUnPRO1.Text) != Convert.ToInt16(lblUnPR1.Text))
        {
            lblMd1.Text = "1";
        }
        else
        {
            lblMd1.Text = "0";
        }
    }
    protected void txtExBillNo_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvExtra.Rows[index];
        TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");

        Label lblnoO = (Label)gvr.FindControl("lblnoO");
        Label lblMd1 = (Label)gvr.FindControl("lblMd1");
        if (Convert.ToInt32(lblnoO.Text) != Convert.ToInt32(txtExBillNo.Text))
        {
            lblMd1.Text = "1";
        }
        else
        {
            lblMd1.Text = "0";
        }

    }
    protected void chkVerified_CheckedChanged(object sender, EventArgs e)
    {

    }

}
