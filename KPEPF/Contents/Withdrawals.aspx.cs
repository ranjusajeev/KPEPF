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

public partial class Contents_Withdrawals : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    WithdrwalDAO wthDAO = new WithdrwalDAO();
    Withdrawals with = new Withdrawals();
    ChalanDAO chDAO = new ChalanDAO();
    public static int Billtype = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt16(Session["numBillID"]) > 0 || Convert.ToInt16(Session["IntTreIdWit"]) > 0)
            {
                InitialSettings();
                FillGrids();
                SetCtrls();
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
        if (Convert.ToInt16(Session["flgAppWithOnline"]) == 1)
        {
            SetGridsDisable();
        }
        else
        {
            SetGridsEnable();
        }
    }
    private void SetGridsDisable()
    {
        txtInt.ReadOnly = true;
        txtInt.Enabled = false;
        txtAmt.ReadOnly = true;
        txtRem.ReadOnly = true;
        btnEntry.Enabled = false;

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

            //ddlSubTre.Enabled = false;
            txtExBillNo.ReadOnly = true;
            txtExBillDt.ReadOnly = true;
            txtExAmount.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            btnAddFloorNew.Enabled = false;
            btndelete.Enabled = false;
        }
    }
    private void SetGridsEnable()
    {
        txtInt.ReadOnly = false;
        txtInt.Enabled = true ;
        txtAmt.ReadOnly = false;
        txtRem.ReadOnly = false;
        btnEntry.Enabled = true;

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
            ddlReason.Enabled = true;
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

            //ddlSubTre.Enabled = false;
            txtExBillNo.ReadOnly = false;
            txtExBillDt.ReadOnly = false;
            txtExAmount.ReadOnly = false;
            txtRemarks.ReadOnly = false;
            btnAddFloorNew.Enabled = true;
            btndelete.Enabled = true;
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["IntYearIdWit"] = Convert.ToInt16(ddlYear.SelectedValue);
            ddlDis.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
        }
        else
        {
            Session["IntYearIdWit"] = 0;
        }
    }
    protected void ddlDis_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
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
    }
    private void InitialSettings()
    {
        DataSet ds = new DataSet();
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
    }
    private void gridDefault()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SlNo");
        arr.Add("dtBillDate");
        arr.Add("fltBillAmount");
        arr.Add("numBillID");
        arr.Add("chvBillNo");
        gblobj.SetGridDefault(gdvWith, arr);
        ArrayList arr1 = new ArrayList();
        arr1.Add("SlNo");
        arr1.Add("chvBillNo");
        arr1.Add("dtBillDate");

        arr1.Add("fltBillAmount");
        arr1.Add("flgBillType");
        arr1.Add("flgUnposted");
        arr1.Add("intUnPostedRsn");
        arr1.Add("numBillID");
        gblobj.SetGridDefault(gdvExtra, arr1);
        //FillGdvComboBillType();
    }
    private void FillGrids()
    {
        if (Convert.ToInt16(Session["IntTreIdWit"].ToString()) > 0)
        {
            FillGrid();
            FillTxts();
            SetCmbs();
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
        DataSet dsTreas = new DataSet();
        ArrayList arrd = new ArrayList();
        arrd.Add(Convert.ToInt16(Session["IntDistWit"]));
        dsTreas = gendao.GetDisTreasury(arrd);
        gblobj.FillCombo(ddlTresury, dsTreas, 1);
    }
    private void FillTxts()
    {
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
            Session["numTreasuryDIdWith"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[4]);

            //if (Convert.ToInt16(Session["flgAppWithOnline"]) == 1)
            //{
            //    DisableCtrls();
            //}
            //else
            //{
            //    EnableCtrls();
            //}
        }
        else
        {
            Session["numTreasuryDIdWith"] = 0;
            ClearCtrl();
        }
    }
    //private void DisableCtrls()
    //{
    //    //gdvWith.Enabled = false;
    //    //gdvExtra.Enabled = false;

    //    for (int i = 0; i < gdvWith.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvWith.Rows[i];
    //        CheckBox chkApp1Ass = (CheckBox)gdvrow.FindControl("chkApp1");
    //        DropDownList ddlReasonAss = (DropDownList)gdvrow.FindControl("ddlReason");

    //        chkApp1Ass.Enabled = false;
    //        ddlReasonAss.Enabled = false;
    //    }

    //    for (int i = 0; i < gdvExtra.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvExtra.Rows[i];
    //        TextBox txtExBillNoAss = (TextBox)gdvrow.FindControl("txtExBillNo");
    //        TextBox txtExBillDtAss = (TextBox)gdvrow.FindControl("txtExBillDt");
    //        TextBox txtExAmountAss = (TextBox)gdvrow.FindControl("txtExAmount");
    //        DropDownList ddlInstAss = (DropDownList)gdvrow.FindControl("ddlInst");
    //        DropDownList ddlBillAss = (DropDownList)gdvrow.FindControl("ddlBill");

    //        //CheckBox chkAllAss = (CheckBox)gdvrow.FindControl("chkAll");
    //        CheckBox chkNonUnpostAss = (CheckBox)gdvrow.FindControl("chkNonUnpost");
    //        DropDownList ddlResonAss = (DropDownList)gdvrow.FindControl("ddlReson");


    //        txtExBillNoAss.ReadOnly = true;
    //        //txtExBillNoAss.Enabled = false;
    //        txtExBillDtAss.ReadOnly = true;
    //        //txtExBillDtAss.Enabled = false;
    //        txtExAmountAss.ReadOnly = true;

    //        ddlInstAss.Enabled = false;
    //        ddlBillAss.Enabled = false;
    //        //chkAllAss.Enabled = false;
    //        chkNonUnpostAss.Enabled = false;
    //        ddlResonAss.Enabled = false;
    //    }
    //    ///////////Header row/////////////
    //    GridViewRow gvrh = gdvWith.HeaderRow;       //Header row of 1st grid
    //    CheckBox Allchk1Ass = (CheckBox)gvrh.FindControl("Allchk1");
    //    Allchk1Ass.Enabled = false;

    //    GridViewRow gvrhe = gdvExtra.HeaderRow;     //Header row of 2nd grid
    //    CheckBox chkAllAss = (CheckBox)gvrhe.FindControl("chkAll");
    //    chkAllAss.Enabled = false;      //Header row of 1st grid

    //    ///////////Header row/////////////

    //    btnEntry.Enabled = false;
    //    txtAmt.ReadOnly = true;
    //    txtInt.ReadOnly = true;
    //    txtRem.ReadOnly = true;
    //    btnNonLBSave.Enabled = false;
    //}
    //private void EnableCtrls()
    //{
        
    //    for (int i = 0; i < gdvWith.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvWith.Rows[i];
    //        CheckBox chkApp1Ass = (CheckBox)gdvrow.FindControl("chkApp1");
    //        DropDownList ddlReasonAss = (DropDownList)gdvrow.FindControl("ddlReason");
    //        chkApp1Ass.Enabled = true ;
    //        ddlReasonAss.Enabled = true ;
    //    }
    //    for (int i = 0; i < gdvExtra.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvExtra.Rows[i];
    //        TextBox txtExBillNoAss = (TextBox)gdvrow.FindControl("txtExBillNo");
    //        TextBox txtExBillDtAss = (TextBox)gdvrow.FindControl("txtExBillDt");
    //        TextBox txtExAmountAss = (TextBox)gdvrow.FindControl("txtExAmount");
    //        DropDownList ddlInstAss = (DropDownList)gdvrow.FindControl("ddlInst");
    //        DropDownList ddlBillAss = (DropDownList)gdvrow.FindControl("ddlBill");

    //        CheckBox chkNonUnpostAss = (CheckBox)gdvrow.FindControl("chkNonUnpost");
    //        DropDownList ddlResonAss = (DropDownList)gdvrow.FindControl("ddlReson");

    //        txtExBillNoAss.ReadOnly = false ;
    //        //txtExBillNoAss.Enabled = true;
    //        txtExBillDtAss.ReadOnly = false ;
    //        //txtExBillDtAss.Enabled = true;
    //        txtExAmountAss.ReadOnly =  false ;

    //        ddlInstAss.Enabled = true;
    //        ddlBillAss.Enabled = true;
    //        //chkAllAss.Enabled = true;
    //        chkNonUnpostAss.Enabled = true;
    //        ddlResonAss.Enabled = true;
    //    }

    //    ///////////Header row/////////////
    //    GridViewRow gvrh = gdvWith.HeaderRow;       //Header row of 1st grid

    //    GridViewRow gvrhe = gdvExtra.HeaderRow;     //Header row of 2nd grid

    //    ///////////Header row/////////////

    //    btnEntry.Enabled = true;
    //    txtAmt.ReadOnly = false;
    //    txtInt.ReadOnly = false;
    //    txtRem.ReadOnly = false;
    //    btnNonLBSave.Enabled = true;
    //}
    private void ClearCtrl()
    {
        txtInt.Text = "";
        txtRem.Text = "";
        txtAmt.Text = "";
        Session["flgAppWith"] = 0;
        gridDefault();
    }
    //private void FillGrid()
    //{
    //    //ddlYear.SelectedValue = Session["IntYearIdWit"].ToString();
    //    //ddlMonth.SelectedValue = Session["IntMonthIdWit"].ToString();
    //    //ddlDis.SelectedValue = Session["IntDistWit"].ToString();
    //    //ArrayList arr = new ArrayList();
    //    //DataSet ds = new DataSet();
    //    //arr.Add(Session["IntDistWit"]);
    //    //ds = gendao.GetDisTreasury(arr);
    //    //if (ds.Tables[0].Rows.Count > 0)
    //    //{
    //    //    gblobj.FillCombo(ddlTresury, ds, 1);
    //    //}
    //    //ddlTresury.SelectedValue = Session["IntTreIdWit"].ToString();
    //    GetBillDetails();
    //}
    protected void ddlTresury_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlTresury.SelectedValue) > 0)
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
        FillGrid();
        FillExtraGrid();
        FillTotLbl();
        SetCtrls();
    }
    private void FillTotLbl()
    {
        if (Convert.ToInt16(gdvWith.Rows.Count) > 0 && Convert.ToInt16(gdvExtra.Rows.Count) > 0)
        {
            lblTotA.Text = Convert.ToString(Convert.ToDouble(gdvWith.FooterRow.Cells[2].Text) + Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text));
        }
    }
    
    protected void btnEntry_Click(object sender, EventArgs e)
    {
        if ((txtInt.Text.ToString() == "") || (txtAmt.Text.ToString() == "") || (txtRem.Text.ToString() == ""))
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
        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["IntMonthIdWit"] = Convert.ToInt16(ddlMonth.SelectedValue);
            ddlDis.SelectedIndex = 0;
            gblobj.CheckValidMonth(Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"]), this, txtAmt);
        }
        else
        {
            Session["IntMonthIdWit"] = 0;
        }
    }
    protected void btnTreasRpt_Click(object sender, EventArgs e)
    {
        if (Convert.ToDouble(gdvWith.FooterRow.Cells[3].Text.ToString()) > 0)
        {
            Response.Redirect("WithdrawalsCurr.aspx");
        }
        else
        {
            gblobj.MsgBoxOk("Enter details", this);
        }
    }
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {
        GridView gdv = gdvWith;
        CheckBox chkAll = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        for (int i = 0; i < gdvWith.Rows.Count; i++)
        {
            GridViewRow gvr = gdvWith.Rows[i];
            CheckBox ChkApp = (CheckBox)gvr.FindControl("chkV");
            //DropDownList ddlReason = (DropDownList)gvr.FindControl("ddlReason");
            if (chkAll.Checked == true)
            {
                ChkApp.Checked = true;
                //ddlReason.Enabled = true;
            }
            else
            {
                ChkApp.Checked = false;
                //ddlReason.Enabled = false;
            }
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
    protected void btnNonLBSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(txtInt.Text) != "" && Convert.ToDouble(txtAmt.Text) > 0)
        {
            if (Convert.ToInt64(Session["numTreasuryDIdWith"]) > 0)
            {
                UpdateBillLb();             //Update TreasuryDId in Chalan tbl.
                //DeleteFromExtra();
                SaveExtra();
                UpdateTreasuryD();
                FillGrid();
                FillExtraGrid();
                gblobj.MsgBoxOk("Saved", this);
            }
            else
            {
                gblobj.MsgBoxOk("Session expired!", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Enter all details!", this);
        }
    }
    //private void DeleteFromExtra()
    //{
    //    // delete from Bill as TAGId = ? and type = 2 or 3 
    //    // delete from BillOther as TAGId = ?

    //    ArrayList ar = new ArrayList();
    //    ar.Add(Convert.ToDouble(Session["numTreasuryDIdWith"]));
    //    wthDAO.DeleteBillExtra(ar);
    //}
    private void UpdateTreasuryD()
    {
        ArrayList arn = new ArrayList();
        arn.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        arn.Add(FindAmt(1));
        arn.Add(FindAmt(2));
        arn.Add(FindAmt(4));
        arn.Add(0);
        arn.Add(2);
        wthDAO.UpdateTreasuryDMiss(arn);

        //ArrayList arn = new ArrayList();
        //arn.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        //arn.Add(FindAmt(1));
        //arn.Add(FindAmt(2));
        //arn.Add(FindAmt(4));
        //arn.Add(FindAmtLB());
        //arn.Add(1);
        //chDao.UpdateTreasuryDMiss(arn);
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
    private void  UpdateBillLb()
    {
        int flag = 0;
        double amt = 0;
        for (int i = 0; i < gdvWith.Rows.Count; i++)
        {
            //if (Convert.ToDouble(gdvWith.Rows[i].Cells[3].Text) > 0)
            if (Convert.ToDouble(gdvWith.FooterRow.Cells[2].Text) > 0)
            {
                ArrayList Arr = new ArrayList();
                GridViewRow gvr = gdvWith.Rows[i];
                LinkButton LbBill = (LinkButton)gvr.FindControl("lbBill");
                CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
                DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
                Label lblBillIdAss = (Label)gvr.FindControl("lblBillId");
                CheckBox chkVAss = (CheckBox)gvr.FindControl("chkV");
                //amt = amt + Convert.ToDouble(gdvWith.Rows[i].Cells[3].Text);

                Arr.Add(Convert.ToInt16(lblBillIdAss.Text));
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
                gblobj.MsgBoxOk("Save Successfully", this);

            }
        }
    }
    //private void UpdateTreasuryDetails(double amt)
    //{
    //    ArrayList arr1 = new ArrayList();
    //    arr1.Add(Session["IntYearIdWit"]);
    //    arr1.Add(Session["IntMonthIdWit"]);
    //    arr1.Add(Session["IntTreIdWit"]);
    //    arr1.Add(2);
    //    arr1.Add(amt);
    //    chDAO.UpdateTreasuryD(arr1);
    //}
    protected void ddlBill_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        setControlDisabled(index);
    }
    protected void txtExAmount_TextChanged(object sender, EventArgs e)
    {
        double tAmt = 0;
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdr = gdvExtra.Rows[index];
        TextBox txtExAmount = (TextBox)gdr.FindControl("txtExAmount");
        gblobj.SetFooterTotalsTempField(gdvExtra, 3, "txtExAmount", 1);
        FillTotLbl();
    }
    protected void txtExBillDt_TextChanged(object sender, EventArgs e)
    {
        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvExtra.Rows[index];
        //TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
        //if (Validchalandate(txtExBillDt) == false)
        //{
        //    txtExBillDt.Text = "";
        //    gblobj.MsgBoxOk("Invalid Date", this);
        //}


        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvExtra.Rows[index];
        TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
        if (gblobj.CheckChalanDate(txtExBillDt, ddlYear, ddlMonth) == false)
        {
            gblobj.MsgBoxOk("Invalid Date", this);
        }
    }
    protected void txtInt_TextChanged(object sender, EventArgs e)
    {
        //if (gblobj.CheckChalanDate(txtInt, ddlYear, ddlMonth) == false)
        //{
        //    gblobj.MsgBoxOk("Invalid Date", this);
        //}

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
    private void SetGridDefault1()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvBillNo");
        ar.Add("numBillID");
        ar.Add("dtBillDate");
        ar.Add("fltBillAmount");
        ar.Add("flgUnposted");
        ar.Add("intUnPostedRsn");

        gblobj.SetGridDefault(gdvWith, ar);
        gblobj.SetGridGrey(gdvWith);
    }
    private void SetGridDefault2()
    {
        //ArrayList ar = new ArrayList();
        //ar.Add("SlNo");
        //ar.Add("chvTreasuryName");
        //ar.Add("chvEngLBName");
        //ar.Add("numChalanId");
        //ar.Add("ChNodtChalanDate");
        //ar.Add("fltChalanAmt");
        //gblobj.SetGridDefault(gdvchRem, ar);
        //gblobj.SetGridGrey(gdvchRem);
    }
    private void FillGrid()
    {
        SetGridDefault1();
        ArrayList arr1 = new ArrayList();
        arr1.Add(Session["IntYearIdWit"]);
        arr1.Add(Session["IntMonthIdWit"]);
        arr1.Add(Session["IntTreIdWit"]);
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
                gblobj.FillCombo(DdlReason, ds1, 1);
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12].ToString()) == 1)
                {
                    ChkApp1.Checked = false;
                    DdlReason.Enabled = false;
                    DdlReason.SelectedValue = 0.ToString();
                }
                else
                {
                    ChkApp1.Checked = true;
                    DdlReason.Enabled = true;
                    DdlReason.SelectedValue = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                }
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[16].ToString()) == 1)
                {
                    chkVAss.Checked = true;
                }
                else
                {
                    chkVAss.Checked = false ;
                }
           

                lblBillIdAss.Text = ds.Tables[0].Rows[i].ItemArray[15].ToString();
            }
            //gblobj.SetFooterTotals(gdvWith, 2);
        }
        gblobj.SetFooterTotals(gdvWith, 2);
    }

    protected void chkApp1_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvWith.Rows.Count; i++)
        {
            GridViewRow gvr = gdvWith.Rows[i];
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
    }
    //protected void txtNonLBAmount_TextChanged(object sender, EventArgs e)
    //{
    //    int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
    //    GridViewRow gdr = gdvchNonLB.Rows[index];
    //    TextBox txtNonLBAmount = (TextBox)gdr.FindControl("txtNonLBAmount");

    //    gblObj.SetFooterTotalsTempField(gdvchNonLB, 4, "txtNonLBAmount", 1);
    //    FillTotLbl();
    //}
    private void FillExtraGrid()
    {
        //DataTable dtExtra = gblobj.SetInitialRow(gdvExtra);
        //ViewState["extra"] = dtExtra;
        FillExtraGridCombo();
        FillGdvComboBillType();
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        SetGridDefaultOthers();
        if (Session["numTreasuryDIdWith"] != null)
        {
            arr.Add(Session["numTreasuryDIdWith"]);
        }
        else
        {
            Session["numTreasuryDIdWith"] = 0;
            arr.Add(0);
        }

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
                DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
                ddlInst.SelectedValue = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
                ddlBill.SelectedValue = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
                DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");

                Label lblBillIdOAss = (Label)gvr.FindControl("lblBillIdO");
                lblBillIdOAss.Text = ds.Tables[0].Rows[i].ItemArray[15].ToString();

                TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");
                txtRemarks.Text = ds.Tables[0].Rows[i].ItemArray[16].ToString();

                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12].ToString()) == 2)
                {
                    if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[11]) == 4)
                    {
                        chkNonUnpost.Checked = true;
                        ddlReson.SelectedValue = 6.ToString();
                        chkNonUnpost.Enabled = false;
                    }
                    else
                    {
                        chkNonUnpost.Checked = true;
                        ddlReson.SelectedValue = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                        ddlReson.Enabled = true;
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
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvBillNo");
        ar.Add("fltBillAmount");
        ar.Add("numBillID");
        ar.Add("dtBillDate");
        ar.Add("flgBillType");
        //ar.Add("flgChalanType");
        gblobj.SetGridDefault(gdvExtra,ar);
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
            dr["Type"] = "Extra From Treasury";
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
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Session["IntDistWit"]);
        arrIn.Add(5);
        ds = genDAO.GetAllInstitution(arrIn);
        DataSet ds2 = new DataSet();
        ArrayList arrre = new ArrayList();
        arrre.Add(2);
        ds2 = genDAO.getReason(arrre);
        for (int i = 0; i < gdvExtra.Rows.Count; i++)
        {
            GridViewRow gvr = gdvExtra.Rows[i];
            DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
            gblobj.FillCombo(ddlInst, ds, 1);
            DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
            gblobj.FillCombo(ddlReson, ds2, 1);
            ddlReson.Enabled = false;
        }
    }
    private void SaveExtra()
    {
        if (Convert.ToDouble(gdvExtra.FooterRow.Cells[3].Text) > 0)
        {
            for (int i = 0; i < gdvExtra.Rows.Count; i++)
            {
                GridViewRow gvr = gdvExtra.Rows[i];
                TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
                DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
                TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
                TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
                TextBox txtRem1 = (TextBox)gvr.FindControl("txtRemarks");
                CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
                DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
                DropDownList ddlBillAss = (DropDownList)gvr.FindControl("ddlBill");

                Label lblBillIdOAss = (Label)gvr.FindControl("lblBillIdO");
                if (CheckMandatory(txtExAmount, txtExBillNo, txtExBillDt) == true)
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
                    arr.Add(" ");
                    arr.Add(1);
                    arr.Add(0);
                    arr.Add(Convert.ToInt16(ddlBillAss.Text));
                    arr.Add(Convert.ToDouble(Session["numTreasuryDIdWith"]));
                     wthDAO.SaveExtraBill(arr);
                    gblobj.MsgBoxOk("Save Bill,Please enter Withdrawal Details", this);
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
                        arr.Add(Convert.ToDouble(Session["numTreasuryDIdWith"]));
                        arr.Add(1);
                        arr.Add(Convert.ToDouble(lblBillIdOAss.Text));
                        wthDAO.SaveBillOthers(arr);
                }
                }
            }
        }
    }
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt)
    {
        Boolean flg = true;
        if (txtAmt.Text.ToString() == "" || txtNo.Text.ToString() == "" || txtDt.Text.ToString() == "")
        {
        //if (Convert.ToDouble(txtAmt.Text) == 0 || Convert.ToInt16(txtNo.Text) == 0 || Convert.ToString(txtDt.Text) == "" || Convert.ToInt16(ddlCh.SelectedValue) == 0)
        //{
            gblobj.MsgBoxOk("Enter all details!", this);
            flg = false;
            //}
            //else
            //{
            //    flg = true;
            //}
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
        if (chkNonUnpost.Checked == true)
        {
            ddlReson.Enabled = true;
        }
        else
        {
            ddlReson.Enabled = false;
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
    private void GetBillStatus(ArrayList arr)
    {
    //    DataSet ds1 = new DataSet();
    //    ArrayList arr1 = new ArrayList();
    //    arr1.Add(2);
    //    ds1 = wthDAO.GetReason(arr1);
    //    DataSet ds = new DataSet();
    //    ds = wthDAO.CheckAvail(arr);
    //    if (ds.Tables[0].Rows.Count <= 0)
    //    {
    //        gblobj.MsgBoxOk("No data Found", this);
    //        Clearctrl();
    //    }
    //    else
    //    {
    //        GetEnteredDetails();
        //}
    }

    protected void btnCon_Click(object sender, EventArgs e)
    {
    //    Response.Redirect("WithConsol.aspx");
    }
    //protected void btnVeri_Click(object sender, EventArgs e)
    //{
    //       Updateflag();
    //}
    //private void  Updateflag()
    //{
    //    int flag = 0;
    //    double amt = 0;

    //    for (int i = 0; i < gdvWith.Rows.Count; i++)
    //    {
    //        ArrayList Arr = new ArrayList();
    //        GridViewRow gvr = gdvWith.Rows[i];
    //        LinkButton LbBill = (LinkButton)gvr.FindControl("lbBill");
    //        CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
    //        DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
    //        amt = amt + Convert.ToDouble(gdvWith.Rows[i].Cells[3].Text);
    //        Arr.Add(Convert.ToInt16(LbBill.Text));
    //        if (ChkApp1.Checked == true)
    //        {
    //            if (DdlReason.SelectedIndex > 0)
    //            {
    //                Arr.Add(2);
    //                Arr.Add(Convert.ToInt16(DdlReason.SelectedValue));
    //            }
    //            else
    //            {
    //                gblobj.MsgBoxOk("Please Select Reason", this);
    //            }
    //        }
    //        else
    //        {
    //            Arr.Add(1);
    //            Arr.Add(Convert.ToInt16(DdlReason.SelectedValue));
    //        }
    //   int r = wthDAO.UpdateBill(Arr);
    //    }
    //    gblobj.MsgBoxOk("Save Successfully", this);
    //    UpdateTreasuryDetails(amt);
    //}
    //private void UpdateTreasuryDetails(double amt)
    //{
    //    ArrayList arr1 = new ArrayList();
    //    arr1.Add(Session["IntYearIdWit"]);
    //    arr1.Add(Session["IntMonthIdWit"]);
    //    arr1.Add(Session["IntTreIdWit"]);
    //    arr1.Add(2);
    //    arr1.Add(amt);
    //    chDAO.UpdateTreasuryD(arr1);
    //}
    //private void SaveTreasuryDetails()
    //{
    //    ArrayList arr1 = new ArrayList();
    //    //arr1.Add(1);
    //    arr1.Add(Session["IntYearIdWit"]);
    //    arr1.Add(Session["IntMonthIdWit"]);
    //    arr1.Add(Session["IntTreIdWit"]);
    //    arr1.Add(2);
    //    arr1.Add(Convert.ToInt32(gblobj.IntiAmtWith));
    //    arr1.Add(Convert.ToInt32(Session["intUserId"]));
    //    arr1.Add(0);
    //    arr1.Add("");
    //    //arr1.Add(0);
    //    arr1.Add(gblobj.DtIntiWith);
    //    arr1.Add(0);
    //    arr1.Add(0);
    //    arr1.Add(gblobj.StrWith);
    //    long n=wthDAO.SaveBillToTreasury(arr1);
    //    gblobj.IntTreasuryDId = n;
    //}
    ////protected void btnEntry_Click(object sender, EventArgs e)
    ////{
    ////    if ((txtInt.Text.ToString() == "") || (txtAmt.Text.ToString() == "") || (txtRem.Text.ToString() == ""))
    ////    {
    ////        gblobj.MsgBoxOk("Enter All Details Above", this);
    ////    }
    ////    else
    ////    {
    ////        gblobj.DtIntiWith = txtInt.Text;
    ////        gblobj.IntiAmtWith = Convert.ToInt32(txtAmt.Text);
    ////        gblobj.StrWith = txtRem.Text;
    ////        SaveTreasuryDetails();
    ////        GetBillDetails();
    ////    }
    ////}
    //private void DisableCtrls()
    //{
    //    gdvExtra.Enabled = false;
    //    btnEntry.Enabled = false;
    //    txtAmt.ReadOnly = true;
    //    txtInt.ReadOnly = true;
    //    txtRem.ReadOnly = true;
    //}
    //private void GetBillDetails()
    //{
    //    ArrayList arr1 = new ArrayList();
    //    arr1.Add(Session["IntYearIdWit"]);
    //    arr1.Add(Session["IntMonthIdWit"]);
    //    arr1.Add(Session["IntTreIdWit"]);
    //    DataSet ds = new DataSet();
    //    DataSet ds1 = new DataSet();
    //    ds = wthDAO.GetBills(arr1);
    //    ArrayList arr2= new ArrayList();
    //    arr2.Add(2);
    //    ds1 = wthDAO.GetReason(arr2);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
            
    //        gdvWith.DataSource = ds;
    //        gdvWith.DataBind();
    //        for (int i = 0; i < gdvWith.Rows.Count; i++)
    //        {
    //            GridViewRow gvr = gdvWith.Rows[i];
    //            LinkButton LbBill = (LinkButton)gvr.FindControl("lbBill");
    //            LbBill.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
    //            CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
    //            if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12].ToString()) == 1)
    //            {
    //                ChkApp1.Checked = false;
    //            }
    //            else
    //            {
    //                ChkApp1.Checked = true;
    //            }
    //            DropDownList DdlReason = (DropDownList)gvr.FindControl("ddlReason");
    //            gblobj.FillCombo(DdlReason, ds1, 1);
    //            DdlReason.SelectedValue = ds.Tables[0].Rows[i].ItemArray[14].ToString();
    //            DdlReason.Enabled = false;

    //        }
    //        gblobj.SetFooterTotals(gdvWith, 3);
    //    }
    //}
    //protected void lnkdepu_Click1(object sender, EventArgs e)
    //{
    //    //lblExtraHead.Text = "Deputation";
    //    gblobj.FlgBillType= 2;
    //}
    //private void FillExtraGrid()
    //{
    //    DataTable dtExtra = gblobj.SetInitialRow(gdvExtra);
    //    ViewState["extra"] = dtExtra;
    //    FillExtraGridCombo();
    //    FillGdvComboBillType();
    //    ArrayList arr = new ArrayList();
    //    DataSet ds = new DataSet();
    //    arr.Add(Session["IntYearIdWit"]);
    //    arr.Add(Session["IntMonthIdWit"]);
    //    arr.Add(Session["IntTreIdWit"]);
    //    //arr.Add(gblobj.FlgBillType);
    //    ds=wthDAO.GetBillsextra(arr);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        dtExtra = gblobj.SetGridTableRows(gdvExtra, ds.Tables[0].Rows.Count);
    //        ViewState["extra"] = dtExtra;
    //        FillExtraGridCombo();
    //        FillGdvComboBillType();
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            GridViewRow gvr = gdvExtra.Rows[i];
    //            TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
    //            txtExBillNo.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
    //            TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
    //            txtExBillDt.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
    //            TextBox txtExAmount = (TextBox)gvr.FindControl("txtExAmount");
    //            txtExAmount.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
    //            DropDownList ddlInst = (DropDownList)gvr.FindControl("ddlInst");
    //            ddlInst.SelectedValue = ds.Tables[0].Rows[i].ItemArray[3].ToString();
    //            DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
    //            ddlBill.SelectedValue = ds.Tables[0].Rows[i].ItemArray[11].ToString();
    //            CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
    //            DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
    //            if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12].ToString()) == 2)
    //            {
    //                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[11]) == 4)
    //                {
    //                    chkNonUnpost.Checked = true;
    //                    ddlReson.SelectedValue = 6.ToString();
    //                    chkNonUnpost.Enabled = false;
    //                }
    //                else
    //                {
    //                    chkNonUnpost.Checked = true;
    //                    ddlReson.SelectedValue = ds.Tables[0].Rows[i].ItemArray[14].ToString();
    //                    ddlReson.Enabled = true;
    //                }
    //            }
    //            else
    //            {
    //                chkNonUnpost.Checked = false;
    //                ddlReson.SelectedValue = 0.ToString();
    //                ddlReson.Enabled = false;
    //            }
    //            double tAmt = FindTotal(gdvExtra, txtExAmount);
    //            gdvExtra.FooterRow.Cells[3].Text = tAmt.ToString();

    //        }
    //    }
    //}
    

    //private int checkRowinGrid()
    //{
    //    int flag = 0;
    //    for (int i = 0; i < gdvExtra.Rows.Count; i++)
    //    {
    //        GridViewRow gvr = gdvExtra.Rows[i];
    //        TextBox txtExBillNo = (TextBox)gvr.FindControl("txtExBillNo");
    //        if (txtExBillNo.Text=="")
    //        {
    //            flag = 1;
    //            break;
    //        }
    //    }
    //    return flag;
    //}
    //protected void txtExAmount_TextChanged(object sender, EventArgs e)
    //{
    //    double tAmt = 0;
    //    int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
    //    GridViewRow gdr = gdvExtra.Rows[index];
    //    TextBox txtExAmount = (TextBox)gdr.FindControl("txtExAmount");
    //    tAmt = FindTotal(gdvExtra, txtExAmount);
    //    gdvExtra.FooterRow.Cells[3].Text = tAmt.ToString();
    //}
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
    //protected void txtExBillDt_TextChanged(object sender, EventArgs e)
    //{
    //    int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
    //    GridViewRow gvr = gdvExtra.Rows[index];
    //    TextBox txtExBillDt = (TextBox)gvr.FindControl("txtExBillDt");
    //    if (Validchalandate(txtExBillDt) == false)
    //    {
    //        txtExBillDt.Text = "";
    //        gblobj.MsgBoxOk("Invalid Date", this);
    //    }
    //}
    
    //protected void txtInt_TextChanged(object sender, EventArgs e)
    //{
    //    if (ValidIntimationdate(txtInt) == false)
    //    {
    //        txtInt.Text = "";
    //        gblobj.MsgBoxOk("Invalid Date", this);
    //    }
    //}
    
    //protected void ddlBill_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
    //    setControlDisabled(index);
    //}
    //private void setControlDisabled(int i)
    //{
    //    GridViewRow gvr = gdvExtra.Rows[i];
    //    DropDownList ddlBill = (DropDownList)gvr.FindControl("ddlBill");
    //    CheckBox chkNonUnpost = (CheckBox)gvr.FindControl("chkNonUnpost");
    //    DropDownList ddlReson = (DropDownList)gvr.FindControl("ddlReson");
    //    if (Convert.ToInt16(ddlBill.SelectedValue) == 4)
    //    {
    //        chkNonUnpost.Enabled = false;
    //        chkNonUnpost.Checked = true;
    //        ddlReson.Enabled = false;
    //        ddlReson.SelectedValue = 6.ToString();
    //    }
    //    else
    //    {
    //        chkNonUnpost.Enabled = true;
    //        ddlReson.SelectedIndex = 0;
    //    }
    //}
    //protected void btnTreasRpt_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnNonLBSave_Click(object sender, EventArgs e)
    //{
    //    Updateflag();
    //    SaveExtra();
    //}
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {

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


        return arrControlid;
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        //  int rowIndex = Convert.ToInt32(e.RowIndex);

        Label lblBillIdO = (Label)gdvExtra.Rows[rowIndex].FindControl("lblBillIdO");
        if (lblBillIdO.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblBillIdO.Text));
            try
            {
                wthDAO.UpdateBillModeCurr(arrin);
                deleteUnsavedwith();

            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
        }
        FillExtraGrid();
        gblobj.MsgBoxOk("Row Deleted   !", this);

        // FillHeadLbls();
        //}
        //else
        //{
        //}

    }
    private void deleteUnsavedwith()
    {
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
}
