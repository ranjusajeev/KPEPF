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

public partial class Contents_WithdrawalsEmpCurr : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    WithdrawalPDEDAO wthdp;
    Withdrawals wth;
    WithdrwalDAO wthd;
    Employee emp;
    EmployeeDAO empD;

    CorrectionEntry corr;
    CorrectionEntryDao corrDao;
    GeneralDAO gendao;

    static int intyr = 0;
    public int cntclick = 0;
    int corrType = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["flgBillType"] != "")
            {
                Session["fltBillAmount"] = Convert.ToDouble(Request.QueryString["fltBillAmount"]);
                Session["flgBillTypeOnline"] = Convert.ToDouble(Request.QueryString["flgBillType"]);
                if (Convert.ToInt32(Session["flgBillTypeOnline"]) != 4)
                {
                    if ((Request.QueryString["numBillID"] != "") && (Request.QueryString["numBillID"] != "0"))
                    {
                        Session["numBillID"] = Convert.ToInt32(Request.QueryString["numBillID"]);
                        Session["intTreasuryId"] = Convert.ToInt32(Request.QueryString["intTreasuryId"]);
                        FillBillDate();
                       
                        //int dd = Convert.ToInt16(Session["intTreasuryId"]);
                        FillChalanS();
                        FillLbls();
                        SetCtrls();
                    }
                    else if ((Convert.ToInt16(Session["flgPageBackW"]) == 7) || (Request.QueryString["numBillID"] == ""))
                    {
                        Response.Redirect("DebitPlusCurr.aspx");
                        intyr = Convert.ToInt16(Session["intYearAGCurr"]);
                    }
                    else if (Convert.ToInt16(Session["flgOAODt"]) == 2 || Convert.ToInt16(Session["flgOAODt"]) == 1)
                    {
                        Response.Redirect("DAERDt.aspx");
                        intyr = Convert.ToInt16(Session["intYearAGCurr"]);
                    }
                    else
                    {
                        Response.Redirect("WithdrawalsEntry.aspx");
                        intyr = Convert.ToInt16(Session["IntYearIdWit"]);
                    }
                }
                else if (Convert.ToInt32(Session["flgPageBack"]) == 3)
                {
                    FillLbls();
                    FillChalanS();
                    SetCtrls();
                }
                else
                {
                    Response.Redirect("WithdrawalsEntry.aspx");
                }
            }
            else
            {
                Response.Redirect("WithdrawalsEntry.aspx");
            }
            if (Request.QueryString["numWithdrawalID"] != null)
            {

                FillDdlsSing();
                FillEmpTxts();
                FillChalanS();
            }
        }
    }   
    private void FillEmpTxts()
    {
        wthd = new WithdrwalDAO();
        Mdlchl.Show();
        Session["numWithdrawalID"] = Convert.ToDouble(Request.QueryString["numWithdrawalID"]);
        DataSet dsW1 = new DataSet();
        ArrayList arr1 = new ArrayList();
        if (Session["numWithdrawalID"] != null)
        {
            arr1.Add(Session["numWithdrawalID"]);

            dsW1 = wthd.GetWithdrawaEmpSing(arr1);
            if (dsW1.Tables[0].Rows.Count > 0)
            {
                lblWithId.Text = Convert.ToInt32(Session["numWithdrawalID"]).ToString();
                txtAccNo.Text = dsW1.Tables[0].Rows[0].ItemArray[1].ToString();
               
                lblName.Text = dsW1.Tables[0].Rows[0].ItemArray[2].ToString();
                txtAmt.Text = dsW1.Tables[0].Rows[0].ItemArray[4].ToString();
                drwnby.SelectedValue = dsW1.Tables[0].Rows[0].ItemArray[22].ToString();
                ddlType.SelectedValue = dsW1.Tables[0].Rows[0].ItemArray[5].ToString();
                if (Convert.ToInt16(ddlType.SelectedValue) == 2 || Convert.ToInt16(ddlType.SelectedValue) == 3)
                {
                    txtprevtaDt.Enabled = false;
                    txtprevTaAmt.Enabled = false;
                    txtprevTABal.Enabled = false;
                    txtconsAmt.Enabled = false;
                    txtinstNo.Enabled = false;
                    txtinstAmt.Enabled = false;

                }
                else
                {
                    txtprevtaDt.Enabled = true;
                    txtprevTaAmt.Enabled = true;
                    txtprevTABal.Enabled = true;
                    txtconsAmt.Enabled = true;
                    txtinstNo.Enabled = true;
                    txtinstAmt.Enabled = true;
                }
                ddldesig.SelectedValue = dsW1.Tables[0].Rows[0].ItemArray[23].ToString();
                ddlLB.SelectedValue = dsW1.Tables[0].Rows[0].ItemArray[24].ToString();
                txtorderNo.Text = dsW1.Tables[0].Rows[0].ItemArray[25].ToString();
                txtSDate.Text = dsW1.Tables[0].Rows[0].ItemArray[26].ToString();

                ddlobj.SelectedValue = dsW1.Tables[0].Rows[0].ItemArray[27].ToString();
                txtprevtaDt.Text = dsW1.Tables[0].Rows[0].ItemArray[28].ToString();
                txtprevTaAmt.Text = dsW1.Tables[0].Rows[0].ItemArray[29].ToString();
                txtprevTABal.Text = dsW1.Tables[0].Rows[0].ItemArray[30].ToString();
                txtconsAmt.Text = dsW1.Tables[0].Rows[0].ItemArray[31].ToString();
                txtinstNo.Text = dsW1.Tables[0].Rows[0].ItemArray[32].ToString();
                txtinstAmt.Text = dsW1.Tables[0].Rows[0].ItemArray[33].ToString();
                txtWithDt.Text = dsW1.Tables[0].Rows[0].ItemArray[12].ToString();

                lblBillId.Text = dsW1.Tables[0].Rows[0].ItemArray[0].ToString();

                lblNewAcc.Text = dsW1.Tables[0].Rows[0].ItemArray[11].ToString();
                lblOldAcc.Text = dsW1.Tables[0].Rows[0].ItemArray[11].ToString();

                lblOldAmt.Text = dsW1.Tables[0].Rows[0].ItemArray[4].ToString();

                if (Convert.ToInt16(dsW1.Tables[0].Rows[0].ItemArray[6]) == 1)
                {
                    chkUnP.Checked = true;
                    ddlUnP.SelectedValue = dsW1.Tables[0].Rows[0].ItemArray[7].ToString();
                    ddlUnP.Enabled = true;
                }
                else
                {
                    chkUnP.Checked = false;
                    ddlUnP.Enabled = false;
                }    
                lblOType.Text = dsW1.Tables[0].Rows[0].ItemArray[5].ToString();
            }
            else
            {

            }
        }
    }
    private void FillChalanS()
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();
        wthdp = new WithdrawalPDEDAO();
        wthd = new WithdrwalDAO();

        GetYearNdMonth();
        DataSet dsW = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numBillID"]));
        dsW = wthd.GetWithdrawaEmp(ar);

        ////FillDdls()//////////
        //DataSet dsl = new DataSet();
        //dsl = wthdp.GetLoanType();

        //DataSet dsD = new DataSet();
        //dsD = wthdp.Getdrawnby();

        //DataSet dsM = new DataSet();
        //ArrayList arrIn = new ArrayList();

        //arrIn.Add(2);
        //dsM = gen.GetMisClassRsn(arrIn);

        //DataSet dslb = new DataSet();
        ////dslb = ted.GetLB();
        //ArrayList arr = new ArrayList();
        //arr.Add(Convert.ToInt32(Session["intTreasuryId"]));
        //dslb = gen.GetLBFromTreasury(arr);

        //DataSet dsdesig = new DataSet();
        //dsdesig = GenDao.GetDesignationGp();

        ////FillDdls()//////////

        if (dsW.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsW;
            gdvChalanS.DataBind();
            //FillDdls();
            //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
            //{
            //    GridViewRow gdvrow = gdvChalanS.Rows[i];
            //    CheckBox chkUnIdentAss = (CheckBox)gdvrow.FindControl("chkUnIdent");
            //    TextBox txtSDateAss = (TextBox)gdvrow.FindControl("txtSDate");
            //    Label lblOMnthAss = (Label)gdvrow.FindControl("lblOMnth");
            //    Label lblsanctnYrOldAss = (Label)gdvrow.FindControl("lblsanctnYrOld");
            //    Label lblNewAccAss1 = (Label)gdvrow.FindControl("lblNewAcc");
            //    Label lblOldAccAss = (Label)gdvrow.FindControl("lblOldAcc");

            //    Label lblOldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
            //    Label lblWithIdAss = (Label)gdvrow.FindControl("lblWithId");

            //    CheckBox chkUnPAss = (CheckBox)gdvrow.FindControl("chkUnPo");
            //    Label lblWMnthAss = (Label)gdvrow.FindControl("lblWMnth");
            //    ArrayList ar1 = new ArrayList();
            //    ar1.Add(txtSDateAss.Text);
            //    int yrDt = GenDao.gFunFindYearIdFromDate(ar1);
            //    lblsanctnYrOldAss.Text = yrDt.ToString();
            //    lblOMnthAss.Text = dsW.Tables[0].Rows[i].ItemArray[26].ToString();
            //    lblWMnthAss.Text = dsW.Tables[0].Rows[i].ItemArray[12].ToString();
            //    lblNewAccAss1.Text = dsW.Tables[0].Rows[i].ItemArray[11].ToString();
            //    lblOldAccAss.Text = dsW.Tables[0].Rows[i].ItemArray[11].ToString();
            //    lblOldAmtAss.Text = dsW.Tables[0].Rows[i].ItemArray[4].ToString();
            //    lblWithIdAss.Text = dsW.Tables[0].Rows[i].ItemArray[14].ToString();
            //    Session["WithID"] = dsW.Tables[0].Rows[i].ItemArray[14].ToString();

            //    if (Convert.ToInt16(dsW.Tables[0].Rows[i].ItemArray[6]) == 1)
            //    {
            //        chkUnPAss.Checked = true;
            //    }
            //    else
            //    {
            //        chkUnPAss.Checked = false;
            //    }
            //}
            lblBillNo.Text = dsW.Tables[0].Rows[0].ItemArray[34].ToString();
            gblObj.SetFooterTotals(gdvChalanS, 5);
            //dtBill = dsW.Tables[0].Rows[0].ItemArray[37].ToString();
        }
        else
        {
            SetGridDefault();
            //FillDdls();
            //Session["flgAppWithOnline"] = 2;
            Session["WithID"] = 0;
            FillBillDate();
        }
        gblObj.SetFooterTotalsTempField(gdvChalanS, 6, "txtAmt", 1);
        btnSave.Enabled = true;
    }
    private void FillBillDate()
    {
        WithdrawalCDao wthc = new WithdrawalCDao();
        ArrayList ar = new ArrayList();
        DataSet dsB = new DataSet();
        ar.Add(Convert.ToInt64(Session["numBillID"]));
        dsB = wthc.FillBillPDE(ar);
        if (dsB.Tables[0].Rows.Count > 0)
        {
            //dtBill = dsB.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["Billdt"] = dsB.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvChalanS.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
            DropDownList ddlUnPAss = (DropDownList)gvRw.FindControl("ddlUnP");
            if (chkAppAss.Checked == true)
            {
                ddlUnPAss.Enabled = true;
            }
            else
            {
                ddlUnPAss.Enabled = false;
            }
        }
    }
    private void InitialSettings()
    {

        SetGridDefault();
        //FillDdls();
    }
    //private void FillDdls()
    //{
    //    gblObj = new clsGlobalMethods();
    //    GenDao = new KPEPFGeneralDAO();
    //    gen = new GeneralDAO();
    //    wthdp = new WithdrawalPDEDAO();

    //    DataSet dsD = new DataSet();
    //    dsD = wthdp.Getdrawnby();

    //    DataSet dsl = new DataSet();
    //    dsl = wthdp.GetLoanType();

    //    DataSet dsM = new DataSet();
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(2);
    //    dsM = gen.GetMisClassRsn(arrIn);

    //    DataSet dsdesig = new DataSet();
    //    dsdesig = GenDao.GetDesignationGp();

    //    DataSet dsprpse = new DataSet();
    //    ArrayList arrp = new ArrayList();
    //    arrp.Add(1);
    //    dsprpse = GenDao.GetLoanPurpose(arrp);


    //    DataSet dslb = new DataSet();
    //    ArrayList arr = new ArrayList();
    //    arr.Add(Convert.ToInt32(Session["intTreasuryId"]));
    //    dslb = gen.GetLBFromTreasury(arr);
    //    //dslb = ted.GetLB();
    //    for (int i = 0; i < gdvChalanS.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvChalanS.Rows[i];
    //        DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
    //        gblObj.FillCombo(ddlTypeAss, dsl, 1);

    //        DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");
    //        gblObj.FillCombo(ddlUnPAss, dsM, 1);

    //        DropDownList drwnbyAss = (DropDownList)gdvrow.FindControl("drwnby");
    //        gblObj.FillCombo(drwnbyAss, dsD, 1);

    //        DropDownList ddldesigAss = (DropDownList)gdvrow.FindControl("ddldesig");
    //        gblObj.FillCombo(ddldesigAss, dsdesig, 1);

    //        DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
    //        gblObj.FillCombo(ddlLBAss, dslb, 1);

    //        DropDownList ddlobjAss = (DropDownList)gdvrow.FindControl("ddlobj");
    //        gblObj.FillCombo(ddlobjAss, dsprpse, 1);
    //        ddlobjAss.Width = 200;
    //    }




    //}
    private void FillDdlsSing()
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();
        wthdp = new WithdrawalPDEDAO();

        DataSet dsD = new DataSet();
        dsD = wthdp.Getdrawnby();

        DataSet dsl = new DataSet();
        dsl = wthdp.GetLoanType();

        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(2);
        dsM = gen.GetMisClassRsn(arrIn);

        DataSet dsdesig = new DataSet();
        dsdesig = GenDao.GetDesignationGp();

        DataSet dsprpse = new DataSet();
        ArrayList arrp = new ArrayList();
        arrp.Add(1);
        dsprpse = GenDao.GetLoanPurpose(arrp);


        DataSet dslb = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["intTreasuryId"]));
        dslb = gen.GetLBFromTreasury(arr);
        //dslb = ted.GetLB();      

        gblObj.FillCombo(ddlType, dsl, 1);
        gblObj.FillCombo(ddlUnP, dsM, 1);
        gblObj.FillCombo(drwnby, dsD, 1);
        gblObj.FillCombo(ddldesig, dsdesig, 1);
        gblObj.FillCombo(ddlLB, dslb, 1);
        gblObj.FillCombo(ddlobj, dsprpse, 1);
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("fltAllottedAmt");
        ar.Add("chvOrderNo");
        ar.Add("sanctiondate");
        ar.Add("chvOdrNoDtOfPrevTA");
        ar.Add("fltamtPrevTA");
        ar.Add("fltbalancePrevTA");
        ar.Add("fltconsolidatedAmt");
        ar.Add("intnoOfInstalment");
        ar.Add("fltamtinstalment");
        ar.Add("dtmDateOfWith");
        ar.Add("intTrnTypeID");
        ar.Add("dtmDateOfSanction");
        ar.Add("numWithdrawalID");
        ar.Add("flgUnPosted");
        ar.Add("intUnPostedRsn");
        ar.Add("numEmpID");
        ar.Add("chvDesignation");
        ar.Add("chvEngLBName");
        ar.Add("charType");
        ar.Add("chvLoanPurpose");
        ar.Add("chvReason");
        ar.Add("chvLoanType");
        ar.Add("numBillID");
        ar.Add("flgBillType");
        ar.Add("fltBillAmount");
        ar.Add("intTreasuryId");

        gblObj.SetGridDefault(gdvChalanS, ar);
    }
    private void FillLbls()
    {
        gen = new GeneralDAO();
        ArrayList ary = new ArrayList();
        if (Convert.ToInt32(Session["flgPageBackW"]) == 7)
        {
            ary.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        }
        else
        {
            ary.Add(Convert.ToInt16(Session["IntYearIdWit"]));
        }
        lblYear.Text = gen.GetYearFromId(ary);

        ArrayList arm = new ArrayList();
        if (Convert.ToInt32(Session["flgPageBackW"]) == 7)
        {
            arm.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        }
        else
        {
            arm.Add(Convert.ToInt16(Session["IntMonthIdWit"]));
        }
        lblMonth.Text = gen.GetMonthFromId(arm);

        ArrayList art = new ArrayList();
        art.Add(Convert.ToInt16(Session["intTreasuryId"]));
        lblDT.Text = gen.GetDisTreasuryFromId(art);

        lblBillDt.Text = Session["fltBillAmount"].ToString();
        if (Convert.ToDouble(lblBillDt.Text) == Convert.ToDouble(gdvChalanS.FooterRow.Cells[6].Text))
        {
            lblmm.Text = "";
        }
        else
        {
            lblmm.Text = "Amount mismatch";
        }
    }
    private void SetCtrls()
    {
        int f = Convert.ToInt16(Session["flgAppWithOnline"]);
        if (Convert.ToInt16(Session["flgPageBackW"]) == 7)
        {
            if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0 || Convert.ToInt16(Session["flgAppAgCurr"]) == 10)
            {
                SetCtrlsEnable();
            }
            else
            {
                SetCtrlsDisable();
            }
        }
        else
        {
            if (Convert.ToInt16(Session["flgAppWithOnline"]) == 2 || Convert.ToInt16(Session["flgAppWithOnline"]) == 0 || Convert.ToInt16(Session["flgAppWithOnline"]) == 10)
            {
                SetCtrlsEnable();
            }
            else
            {
                SetCtrlsDisable();
            }
        }
    }

    private void SetCtrlsDisable()
    {
        btnSave.Enabled = false;
        lnkChal.Enabled = false;
        Mdlchl.Enabled = false;
    }

    private void SetCtrlsEnable()
    {
        btnSave.Enabled = true;
        lnkChal.Enabled = true;
        Mdlchl.Enabled = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //gblObj = new clsGlobalMethods();
        //var today = Convert.ToDateTime("25/01/2020");

        //var lastmonth = today.AddMonths(-1);
        //gblObj.MsgBoxOk(""+lastmonth,this);
    }
    private Boolean CheckMandatory()
    {
        gblObj = new clsGlobalMethods();
        Boolean flg = true;
        int cnt = 0;
        if (txtAmt.Text.ToString() == "" || txtAmt.Text.ToString() == "0" || txtAccNo.Text.ToString() == "" || txtAccNo.Text.ToString() == "0"
            || txtorderNo.Text.ToString() == "" || txtorderNo.Text.ToString() == "0" || txtSDate.Text.ToString() == "" || txtSDate.Text.ToString() == "0"
            || txtWithDt.Text.ToString() == "" || txtWithDt.Text.ToString() == "0" || ddlLB.SelectedValue == "0" || ddlLB.SelectedValue == "")
        {
            gblObj.MsgBoxOk("Enter all details!", this);
            cnt = cnt + 1;
        }
        if (cnt > 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }

    public Boolean checkSameYr(string dt1, int oldYrId)
    {
        GenDao = new KPEPFGeneralDAO();
        bool Success;
        int nwyrDt;
        if (dt1 != "" && dt1 != "0")
        {
            ArrayList ar = new ArrayList();
            ar.Add(dt1);
            nwyrDt = GenDao.gFunFindYearIdFromDate(ar);
        }
        else
        {
            nwyrDt = 0;
        }
        if (nwyrDt == oldYrId)
        {
            Success = true;
        }
        else
        {
            Success = false;
        }
        return Success;
    }
    private void GetYearNdMonth()   
    {
        wthd = new WithdrwalDAO();
        DataSet dsyr = new DataSet();
        ArrayList arryr = new ArrayList();
        arryr.Add( Convert.ToInt32(Session["numBillID"]));
        dsyr = wthd.GetYrFrmBill(arryr);
        if (dsyr.Tables[0].Rows.Count > 0)
        {
            Session["WithYrID"]=Convert.ToInt32(dsyr.Tables[0].Rows[0].ItemArray[0]);
            Session["WithMnthID"] = Convert.ToInt32(dsyr.Tables[0].Rows[0].ItemArray[1]);
        }
    }
 
    protected void txtAccNo_TextChanged1(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        DataSet dsName = new DataSet();
        emp.NumEmpID = Convert.ToDouble(txtAccNo.Text.ToString());
        dsName = empD.GetEmployeeDetails(emp, 1);
        if (dsName.Tables[0].Rows.Count > 0)
        {
            txtAccNo.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
            lblNewAcc.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
        }
        else
        {
            lblNewAcc.Text = "0";
            gblObj.MsgBoxOk("AccountNumber does not exists", this);
            txtAccNo.Text = "";
        }
        if (Convert.ToInt32(lblOldAcc.Text) != Convert.ToInt32(lblNewAcc.Text))
        {
            lblEditMod.Text = "1";
        }
        else
        {
            lblEditMod.Text = "0";
        }
        Mdlchl.Show();
    }

    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (Convert.ToDouble(lblOldAmt.Text) != Convert.ToDouble(txtAmt.Text))
        {
            lblEditMod.Text = "1";
        }
        else
        {
            lblEditMod.Text = "0";
        }
        if (txtAmt.Text.ToString() != "" || txtAmt.Text.ToString() != "0")
        {
            if (txtprevTABal.Text.ToString() == "" || txtprevTABal.Text.ToString() == "0")
            {
                txtprevTABal.Text = "0";
            }
            if (txtprevTaAmt.Text.ToString() == "" || txtprevTaAmt.Text.ToString() == "0")
            {
                txtprevTaAmt.Text = "0";
            }
            txtconsAmt.Text = Convert.ToString(Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(txtprevTABal.Text)) ;
        }

        //}
        Mdlchl.Show();

        gblObj.SetFooterTotalsTempField(gdvChalanS, 6, "txtAmt", 1);
    }
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblObj.checkLastRowStatus(myControls, arrControlid, gdvChalanS);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblObj.AddNewRow(myControls, arrControlid, arrDT, gdvChalanS);
            DataSet ds = new DataSet();
            gdvChalanS.DataSource = dtgdRow;
            gdvChalanS.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvChalanS, ds);
        }
        btnSave.Enabled = true;
    }
    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        // myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new Label());
        myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new Label());
        myControls.Add(new Label());
        myControls.Add(new CheckBox());
        myControls.Add(new DropDownList());

        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        //  arrControlid.Add("ddFloorArea");
        arrControlid.Add("drwnby");
        arrControlid.Add("txtAccNo");
        arrControlid.Add("lblName");
        arrControlid.Add("ddldesig");
        arrControlid.Add("ddlLB");
        arrControlid.Add("ddlType");
        arrControlid.Add("txtorderNo");
        arrControlid.Add("txtSDate");
        arrControlid.Add("txtAmt");
        arrControlid.Add("ddlobj");
        arrControlid.Add("txtprevtaDt");
        arrControlid.Add("txtprevTaAmt");
        arrControlid.Add("txtprevTABal");
        arrControlid.Add("txtconsAmt");
        arrControlid.Add("txtinstNo");
        arrControlid.Add("txtinstAmt");
        arrControlid.Add("txtWDate");
        arrControlid.Add("lblWithId");
        arrControlid.Add("lblNewAcc");
        arrControlid.Add("chkUnP");
        arrControlid.Add("ddlUnP");



        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();
        arrControlid.Add("intDrawnId");
        arrControlid.Add("chvPF_No");
        arrControlid.Add("chvName");
        arrControlid.Add("intdesigId");
        arrControlid.Add("intlbId");
        arrControlid.Add("intTrnTypeID");
        arrControlid.Add("chvOrderNo");
        arrControlid.Add("sanctiondate");
        arrControlid.Add("fltAllottedAmt");
        arrControlid.Add("intobjAdv");
        arrControlid.Add("chvOdrNoDtOfPrevTA");
        arrControlid.Add("fltamtPrevTA");
        arrControlid.Add("fltbalancePrevTA");
        arrControlid.Add("fltconsolidatedAmt");
        arrControlid.Add("intnoOfInstalment");
        arrControlid.Add("fltamtinstalment");
        arrControlid.Add("dtmDateOfWith");
        arrControlid.Add("numWithdrawalID");
        arrControlid.Add("numEmpId");
        arrControlid.Add("flgUnPosted");
        arrControlid.Add("intUnPostedRsn");

        return arrControlid;
    }
    protected void btnDelN_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        wthd = new WithdrwalDAO();
        gendao = new GeneralDAO();

        if (lblWithId.Text != "")
        {
            Session["intYrCal"] = gendao.GetCCYearId();
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblWithId.Text));
            wthd.UpdWithdrawalMode(arrin);
            int a = Convert.ToInt32(Session["WithYrID"]);
            int b = Convert.ToInt32(Session["intYrCal"]);
            if (Convert.ToInt32(Session["WithYrID"]) <= Convert.ToInt32(Session["intYrCal"]))
            {
                saveCorrectionEntry(Convert.ToInt64(lblWithId.Text), 1);
            }
        }
        FillChalanS();
        if (Convert.ToDouble(lblBillDt.Text) == Convert.ToDouble(gdvChalanS.FooterRow.Cells[6].Text))
        {
            lblmm.Text = "";
        }
        else
        {
            lblmm.Text = "Amount mismatch";
        }
        gblObj.MsgBoxOk("Row Deleted   !", this);
    }
 
    private void saveCorrectionEntry(float schedId, int intDel)
    {
        GenDao = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();
        gendao = new GeneralDAO();
        ArrayList ardt = new ArrayList();
        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Double numWithId = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        string ss = Session["Billdt"].ToString();

        ardt.Add(txtWithDt.Text.ToString());
        yr = GenDao.gFunFindPDEYearIdFromDateOnline(ardt);
        mth = Convert.ToDateTime(txtWithDt.Text).Month;
        //mth = Convert.ToInt16(Session["Billdt"]);
        intDy = 4;

        numWithId = Convert.ToDouble(lblWithId.Text);
        amtO = Convert.ToDouble(lblOldAmt.Text);
        amtN = Convert.ToDouble(txtAmt.Text);
        accO = Convert.ToInt32(lblOldAcc.Text);
        accN = Convert.ToInt32(lblNewAcc.Text);

        findCorrType(amtO, amtN, accO, accN, intDel);
        if (corrType == 2)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    corr.IntAccNo = Convert.ToInt32(lblOldAcc.Text);
                    amtCalc = amtN;
                    corr.FltAmountBefore = amtO;
                    corr.FltAmountAfter = 0;
                }
                else
                {
                    corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
                    amtCalc = -amtN;
                    corr.FltAmountBefore = 0;
                    corr.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                corr.IntYearID = yr;
                corr.IntMonthID = mth;
                corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                corr.FltCalcAmount = dblAmtAdjusted;
                corr.FlgCorrected = 1;      //Just added not incorporated in CCard
                corr.IntChalanId = Convert.ToInt64(Session["numBillID"]);
                corr.IntSchedId = numWithId;
                corr.FlgType = 2;           //Remittance
                corr.FltRoundingAmt = 0;
                corr.IntCorrectionType = corrType;
                //corr.IntChalanType = 4;
                if (Convert.ToInt16(Session["flgPageBackW"]) == 7)
                {
                    corr.IntChalanType = 4;
                }
                else
                {
                    corr.IntChalanType = 2;
                }
                corr.IntTblTp = 2;
                corrDao.CreateCorrEntryCalcTblTp(corr);
            }
        }
        else
        {
            if (corrType == 4)
            {
                amtCalc = -amtN;
                corr.FltAmountBefore = 0;
                corr.FltAmountAfter = amtN;
            }
            else if (corrType == 5)
            {
                amtCalc = amtN;
                corr.FltAmountBefore = amtN;
                corr.FltAmountAfter = 0;
            }
            else
            {
                //amtCalc = amtN - amtO;
                amtCalc = amtO - amtN;
                corr.FltAmountBefore = amtO;
                corr.FltAmountAfter = amtN;
            }
            double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
            ///// Save to CorrEntry/////////
            corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
            corr.IntYearID = yr;
            corr.IntMonthID = mth;
            corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            corr.FltCalcAmount = dblAmtAdjusted;
            corr.FlgCorrected = 1;      //Just added not incorporated in CCard
            corr.IntChalanId = Convert.ToInt64(Session["numBillID"]);
            corr.IntSchedId = numWithId;
            corr.FlgType = 2;           //Remittance
            corr.FltRoundingAmt = 0;
            corr.IntCorrectionType = corrType;
            //corr.IntChalanType = 4;
            if (Convert.ToInt16(Session["flgPageBackW"]) == 7)
            {
                corr.IntChalanType = 4;
            }
            else
            {
                corr.IntChalanType = 2;
            }
            corr.IntTblTp = 2;
            corrDao.CreateCorrEntryCalcTblTp(corr);
        }
    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 5;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 4;
            }
            else if (acco != accn)  // acc no change  (From local master)
            {
                corrType = 2;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 3;
            }
        }
    }
   
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {
        //FillDdls();
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {

                    CheckBox chkUnPAss = (CheckBox)gdRow.FindControl("chkUnP");
                    DropDownList ddlUnPAss = (DropDownList)gdRow.FindControl("ddlUnP");
                    DropDownList ddlTypeAss = (DropDownList)gdRow.FindControl("ddlType");
                    DropDownList drwnbyAss = (DropDownList)gdRow.FindControl("drwnby");
                    DropDownList ddldesigAss = (DropDownList)gdRow.FindControl("ddldesig");
                    DropDownList ddlLBAss = (DropDownList)gdRow.FindControl("ddlLB");
                    DropDownList ddlobjAss = (DropDownList)gdRow.FindControl("ddlobj");
                    if ((ds.Tables[0].Rows[gdRow.RowIndex][19].ToString()) != "")
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[gdRow.RowIndex][19]) == true)
                        {
                            chkUnPAss.Checked = true;
                        }
                        else
                        {
                            chkUnPAss.Checked = false;
                        }
                    }

                    ddlUnPAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[20].ToString();
                    ddlTypeAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[5].ToString();
                    drwnbyAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[0].ToString();
                    ddldesigAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[3].ToString();
                    ddlLBAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[4].ToString();
                    ddlobjAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[9].ToString();


                }
            }
        }
    }
    protected void txtSDate_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (txtSDate.Text != "")
        {
            if (gblObj.isValidDate(txtSDate, this) == true)
            {
                //DateTime dtSDate = Convert.ToDateTime(txtSDate.Text).AddMonths(-1);
                //if (gblObj.CheckWithDate(dtSDate, Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"])) == true)
                //{
                //    if (gblObj.CheckDate2(Session["Billdt"].ToString(), txtSDate.Text.ToString()) == false)
                //    {

                //    }
                //    else
                //    {
                //        gblObj.MsgBoxOk("Invalid Date", this);
                //        txtSDate.Text = "";
                //    }
                //}
                //else
                //{
                //    gblObj.MsgBoxOk("Invalid Date", this);
                //    txtSDate.Text = "";
                //}
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtSDate.Text = "";
            }
        }

        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtSDate.Text = "";
        }
        Mdlchl.Show();

        //gblObj = new clsGlobalMethods();
        //if (txtSDate.Text != "")
        //{
        //    if (gblObj.isValidDate(txtSDate, this) == true)
        //    {
        //        DateTime dtSDate = Convert.ToDateTime(txtSDate.Text).AddMonths(-1);
        //        if (gblObj.CheckWithDate(dtSDate, Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"])) == true)
        //        {
        //            if (gblObj.CheckDate2(Session["Billdt"].ToString(), txtSDate.Text.ToString()) == false)
        //            {
        //                //txtWithDt.Text = Session["Billdt"].ToString();
        //            }
        //            else
        //            {
        //                gblObj.MsgBoxOk("Invalid Date", this);
        //                txtSDate.Text = "";
        //            }
        //        }
        //        else
        //        {
        //            gblObj.MsgBoxOk("Invalid Date", this);
        //            txtSDate.Text = "";
        //        }
        //    }
        //    else
        //    {
        //        gblObj.MsgBoxOk("Invalid Date", this);
        //        txtSDate.Text = "";
        //    }
        //}

        //else
        //{
        //    gblObj.MsgBoxOk("Invalid Date", this);
        //    txtSDate.Text = "";
        //}
        //Mdlchl.Show();


  
    }
    private Boolean CheckChalanDateL(string dt1, int yr, int mth)
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        Boolean flg;
        ArrayList ar = new ArrayList();     
        ar.Add(Convert.ToDateTime(dt1));
        if (GenDao.gFunFindYearIdFromDate(ar) != yr || Convert.ToDateTime(dt1).Month != mth)
        {
            gblObj.MsgBoxOk("Invalid Date", this);           
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    public Boolean checkSameMonth(string dt1, string dt2)
    {
        bool Success;
        string OldMnth;
        string nwMnth;
        nwMnth = Convert.ToDateTime(dt1).Month.ToString();
        if (dt2 != "" && dt2 != "0")
        {
            OldMnth = Convert.ToDateTime(dt2).Month.ToString();
            //if (nwMnth == OldMnth)
            //   {
            //       Success = true;
            //   }
        }
        else
        {
            OldMnth = "";
        }
        if (nwMnth == OldMnth)
        {
            Success = true;
        }
        else
        {
            Success = false;
        }
        return Success;
    }
    //protected void txtWDate_TextChanged(object sender, EventArgs e)
    //{
    //    //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
    //    //GridViewRow gvr = gdvChalanS.Rows[index];
    //    //TextBox txtWDate = (TextBox)gvr.FindControl("txtWDate");
    //    if (txtWDate.Text != "")
    //    {
    //        if (gblObj.isValidDate(txtWDate, this) == true)
    //        {
    //            if (gblObj.CheckDate2(txtWDate.Text.ToString(), DateTime.Now.ToString()) == true)
    //            {
    //                if (gblObj.CheckDate2(dtBill.ToString(), txtWDate.Text.ToString()) == true)
    //                {

    //                }
    //                else
    //                {
    //                    gblObj.MsgBoxOk("Invalid Date", this);
    //                    txtWDate.Text = "";
    //                }
    //            }
    //            else
    //            {
    //                gblObj.MsgBoxOk("Invalid Date", this);
    //                txtWDate.Text = "";
    //            }
    //        }
    //        else
    //        {
    //            gblObj.MsgBoxOk("Invalid Date", this);
    //            txtWDate.Text = "";
    //        }
    //    }

    //    else
    //    {
    //        gblObj.MsgBoxOk("Invalid Date", this);
    //        txtWDate.Text = "";
    //    }

    //    //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
    //    //GridViewRow gvr = gdvChalanS.Rows[index];
    //    //TextBox txtWDate = (TextBox)gvr.FindControl("txtWDate");
    //    //TextBox txtSDate = (TextBox)gvr.FindControl("txtSDate");
    //    //if (txtWDate.Text != "")
    //    //{

    //    //    if (gblObj.isValidDate(txtWDate, this) == true)
    //    //    {
    //    //        if (Convert.ToInt16(Session["flgPageBackW"]) == 1)
    //    //        {
                    
    //    //            if (gblObj.CheckDate3(txtSDate.Text.ToString(), txtWDate.Text.ToString(), DateTime.Now.ToString()) == false)
    //    //            {
    //    //                gblObj.MsgBoxOk("Invalid Date", this);
    //    //                txtWDate.Text = "";
    //    //            }
    //    //            else if (CheckChalanDateL(txtWDate.Text.ToString(), Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"])) == false)
    //    //            {
    //    //                gblObj.MsgBoxOk("Invalid Date", this);
    //    //                txtWDate.Text = "";
    //    //            }
    //    //        }
    //    //        else
    //    //        {
    //    //           if (gblObj.CheckDate2(txtSDate.Text.ToString(), DateTime.Now.ToString()) == false)
    //    //            {
    //    //                gblObj.MsgBoxOk("Invalid Date", this);
    //    //                txtSDate.Text = "";
    //    //            }
                  
    //    //            else
    //    //            {


    //    //                if (gblObj.CheckChalanDate(txtSDate, Convert.ToInt16(Session["WithYrID"]), Convert.ToInt16(Session["WithMnthID"])) == false)
    //    //                {
    //    //                    gblObj.MsgBoxOk("Invalid Date", this);
    //    //                    txtSDate.Text = "";
    //    //                }
                       
    //    //            }

    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        gblObj.MsgBoxOk("Invalid Date", this);
    //    //        txtWDate.Text = "";
    //    //    }



    //    //}
    //    Mdlchl.Show();

    //}
    protected void txtprevTABal_TextChanged(object sender, EventArgs e)
    {
        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvChalanS.Rows[index];
        //TextBox txtprevTA = (TextBox)gvr.FindControl("txtprevTaAmt");
        //TextBox txtprevTABal = (TextBox)gvr.FindControl("txtprevTABal");
        //TextBox txtconsAmt = (TextBox)gvr.FindControl("txtconsAmt");
        //TextBox txtAmt = (TextBox)gvr.FindControl("txtAmt");
        //TextBox txtinstAmt = (TextBox)gvr.FindControl("txtinstAmt");
        //TextBox txtinstNo = (TextBox)gvr.FindControl("txtinstNo");
        //if ((txtAmt.Text.ToString() != "" || txtAmt.Text.ToString() != "0") ||(txtprevTABal.Text.ToString() != "" || txtprevTABal.Text.ToString() != "0"))
        //{
        //    txtconsAmt.Text = Convert.ToString(Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(txtprevTABal.Text));
        //    txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
        //}
        if (txtAmt.Text.ToString() != "" || txtAmt.Text.ToString() != "0")
        {
            if (txtprevTABal.Text.ToString() == "" || txtprevTABal.Text.ToString() == "0")
            {
                txtprevTABal.Text = "0";
            }

            if (txtprevTaAmt.Text.ToString() == "" || txtprevTaAmt.Text.ToString() == "0")
            {
                txtprevTaAmt.Text = "0";
            }
            txtconsAmt.Text = Convert.ToString(Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(txtprevTABal.Text));

            //if (txtinstNo.Text.ToString() != "" && txtinstNo.Text.ToString() != "0")
            //{
            //    txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
            //}
            //else
            //{
            //    txtinstNo.Text = "1";
            //    txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
            //}

        }
        Mdlchl.Show();
    }
    protected void txtinstNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (Convert.ToInt16(txtinstNo.Text) > 36 || Convert.ToInt16(txtinstNo.Text) < 12)
        {
            gblObj.MsgBoxOk("Invalid value.", this);
            txtinstNo.Text = "";
        }
        else
        {
            if (txtinstNo.Text.ToString() != "" && txtinstNo.Text.ToString() != "0")
            {
                txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
            }
        }
        Mdlchl.Show();
    }
    protected void gdvChalanS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SetTabIndexes();
    }
    private void SetTabIndexes()
    {
        //short currentTabIndex = 0;
        ////inputFieldBeforeGridView.TabIndex = ++currentTabIndex;

        //foreach (GridViewRow gvr in gdvChalanS.Rows)
        //{
        //    TextBox txtAccNo = (TextBox)gvr.FindControl("txtAccNo");
        //    txtAccNo.TabIndex = ++currentTabIndex;

        //    DropDownList ddldesig = (DropDownList)gvr.FindControl("ddldesig");
        //    ddldesig.TabIndex = ++currentTabIndex;

        //    DropDownList ddlLB = (DropDownList)gvr.FindControl("ddlLB");
        //    ddlLB.TabIndex = ++currentTabIndex;

        //    TextBox txtAmt = (TextBox)gvr.FindControl("txtAmt");
        //    txtAmt.TabIndex = ++currentTabIndex;

        //    DropDownList drwnby = (DropDownList)gvr.FindControl("drwnby");
        //    drwnby.TabIndex = ++currentTabIndex;

        //    DropDownList ddlType = (DropDownList)gvr.FindControl("ddlType");
        //    ddlType.TabIndex = ++currentTabIndex;

        //    TextBox txtorderNo = (TextBox)gvr.FindControl("txtorderNo");
        //    txtorderNo.TabIndex = ++currentTabIndex;

        //    TextBox txtSDate = (TextBox)gvr.FindControl("txtSDate");
        //    txtSDate.TabIndex = ++currentTabIndex;

        //    DropDownList ddlobj = (DropDownList)gvr.FindControl("ddlobj");
        //    ddlobj.TabIndex = ++currentTabIndex;

        //    TextBox txtprevtaDt = (TextBox)gvr.FindControl("txtprevtaDt");
        //    txtprevtaDt.TabIndex = ++currentTabIndex;

        //    TextBox txtprevTaAmt = (TextBox)gvr.FindControl("txtprevTaAmt");
        //    txtprevTaAmt.TabIndex = ++currentTabIndex;
        //    TextBox txtprevTABal = (TextBox)gvr.FindControl("txtprevTABal");
        //    txtprevTABal.TabIndex = ++currentTabIndex;
        //    TextBox txtconsAmt = (TextBox)gvr.FindControl("txtconsAmt");
        //    txtconsAmt.TabIndex = ++currentTabIndex;

        //    TextBox txtinstNo = (TextBox)gvr.FindControl("txtinstNo");
        //    txtinstNo.TabIndex = ++currentTabIndex;
        //    TextBox txtinstAmt = (TextBox)gvr.FindControl("txtinstAmt");
        //    txtinstAmt.TabIndex = ++currentTabIndex;
        //    TextBox txtWDate = (TextBox)gvr.FindControl("txtWDate");
        //    txtWDate.TabIndex = ++currentTabIndex;

        //}

        //someLinkAfterGridView.TabIndex = ++currentTabIndex;
    }
    //private List<Control> createControl()
    //{
    //    List<Control> myControls = new List<Control>();
    //    myControls.Add(new TextBox());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new DropDownList());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());

    //    return myControls;
    //}
    protected void chkUnP_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gvr = gdvChalanS.Rows[i];
        //    DropDownList ddlUnP = (DropDownList)gvr.FindControl("ddlUnP");
        //    CheckBox chkUnP = (CheckBox)gvr.FindControl("chkUnP");
        //    if (chkUnP.Checked == true)
        //    {
        //        ddlUnP.Enabled = true;
        //    }
        //    else
        //    {
        //        ddlUnP.Enabled = false;
        //    }
        //}

        //intCurRw = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
        //GridViewRow gvr = gdvChalanS.Rows[intCurRw];
        //DropDownList ddlUnP = (DropDownList)gvr.FindControl("ddlUnP");
        //CheckBox chkUnP = (CheckBox)gvr.FindControl("chkUnP");
        if (chkUnP.Checked == true)
        {
            ddlUnP.Enabled = true;
        }
        else
        {
            ddlUnP.Enabled = false;
        }
        Mdlchl.Show();
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (Convert.ToDouble(lblOType.Text) != Convert.ToInt16(ddlType.SelectedValue))
        {
            lblEditMod.Text = "1";
        }
        else
        {
            lblEditMod.Text = "0";
        }
        if (Convert.ToInt16(ddlType.SelectedValue) == 2 || Convert.ToInt16(ddlType.SelectedValue) == 3)
        {
            txtprevtaDt.Enabled = false;
            txtprevTaAmt.Enabled = false;
            txtprevTABal.Enabled = false;
            txtconsAmt.Enabled = false;
            txtinstNo.Enabled = false;
            txtinstAmt.Enabled = false;

        }
        else
        {
            txtprevtaDt.Enabled = true;
            txtprevTaAmt.Enabled = true;
            txtprevTABal.Enabled = true;
            txtconsAmt.Enabled = true;
            txtinstNo.Enabled = true;
            txtinstAmt.Enabled = true;
        }
        Mdlchl.Show();
    }
    protected void ddlobj_SelectedIndexChanged(object sender, EventArgs e)
    {
        Mdlchl.Show();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["flgOAODt"]) == 1)
        {
            btnBack.PostBackUrl = "~/Contents/DAERDt.aspx";
        }
        else if (Convert.ToInt16(Session["flgOAODt"]) == 2)
        {
            btnBack.PostBackUrl = "~/Contents/DAERDt.aspx";
        }
        else
        {
            if (Convert.ToInt16(Session["flgPageBackW"]) == 1)
            {
                Session["flgPageBackW"] = 1001;
                btnBack.PostBackUrl = "~/Contents/WithdrawalsEntry.aspx";
            }

            else if (Convert.ToInt16(Session["flgPageBackW"]) == 3)
            {
                btnBack.PostBackUrl = "~/Contents/WithdrawalsPDE.aspx";
            }
            else if (Convert.ToInt16(Session["flgPageBackW"]) == 4)
            {
                btnBack.PostBackUrl = "~/Contents/WithdrawalsCurr.aspx";
            }
            else if (Convert.ToInt16(Session["flgPageBackW"]) == 7)
            {
                btnBack.PostBackUrl = "~/Contents/DebitPlusCurr.aspx";
            }
        }
    }
    protected void txtprevTaAmt_TextChanged(object sender, EventArgs e)
    {
        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvChalanS.Rows[index];
        //TextBox txtprevTA = (TextBox)gvr.FindControl("txtprevTaAmt");
        //TextBox txtprevTABal = (TextBox)gvr.FindControl("txtprevTABal");
        //TextBox txtconsAmt = (TextBox)gvr.FindControl("txtconsAmt");
        //TextBox txtAmt = (TextBox)gvr.FindControl("txtAmt");
        //TextBox txtinstAmt = (TextBox)gvr.FindControl("txtinstAmt");
        //TextBox txtinstNo = (TextBox)gvr.FindControl("txtinstNo");
        //if ((txtAmt.Text.ToString() != "" || txtAmt.Text.ToString() != "0") ||(txtprevTABal.Text.ToString() != "" || txtprevTABal.Text.ToString() != "0"))
        //{
        //    txtconsAmt.Text = Convert.ToString(Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(txtprevTABal.Text));
        //    txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
        //}
        if (txtAmt.Text.ToString() != "" || txtAmt.Text.ToString() != "0")
        {
            if (txtprevTABal.Text.ToString() == "" || txtprevTABal.Text.ToString() == "0")
            {
                txtprevTABal.Text = "0";
            }
            if (txtprevTaAmt.Text.ToString() == "" || txtprevTaAmt.Text.ToString() == "0")
            {
                txtprevTaAmt.Text = "0";
            }
            txtconsAmt.Text = Convert.ToString(Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(txtprevTABal.Text));

            //if (txtinstNo.Text.ToString() != "" && txtinstNo.Text.ToString() != "0")
            //{
            //    txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
            //}
            //else
            //{
            //    txtinstNo.Text = "1";
            //    txtinstAmt.Text = Convert.ToString(Convert.ToDouble(txtconsAmt.Text) / Convert.ToInt16(txtinstNo.Text));
            //}

        }
        Mdlchl.Show();
    }
    protected void btnNewEmp_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        cntclick = cntclick + 1;
        if (cntclick == 1)
        {
            if ((CheckMandatory()) == true)
            {
                if (CheckDupl() == false)
                {
                    SaveWithEmp();
                    FillChalanS();
                    if (Convert.ToDouble(lblBillDt.Text) == Convert.ToDouble(gdvChalanS.FooterRow.Cells[6].Text))
                    {
                        lblmm.Text = "";
                    }
                    else
                    {
                        lblmm.Text = "Amount mismatch";
                    }
                    gblObj.MsgBoxOk("Updated", this);
                    btnSave.Enabled = false;
                }
                else
                {
                    gblObj.MsgBoxOk("Duplicate Entry!", this);
                }
            }
            else
            {
                gblObj.MsgBoxOk("Enter all details", this);
            }
        }
    }
    private Boolean CheckDupl()
    {
        wth = new Withdrawals();
        wthd = new WithdrwalDAO();

        ArrayList arw = new ArrayList();
        DataSet dsw = new DataSet();
        Boolean flg = true;
        arw.Add(Convert.ToInt32(lblNewAcc.Text));
        arw.Add(Convert.ToInt16(Session["IntYearIdWit"]));
        arw.Add(Convert.ToInt16(Session["IntMonthIdWit"]));
        if (lblWithId.Text == "" || lblWithId.Text == null)
        {
            wth.NumWithdrawalID = 0;
        }
        else
        {
            wth.NumWithdrawalID = Convert.ToInt32(lblWithId.Text.ToString());
        }
        arw.Add(Convert.ToInt32(wth.NumWithdrawalID)); 
        //arw.Add(Convert.ToInt64(txtAmt.Text));
        dsw = wthd.getEmpDupl(arw);
        if (dsw.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsw.Tables[0].Rows[0].ItemArray[0]) > 0)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    private void SaveWithEmp()
    {
        wth = new Withdrawals();
        wthd = new WithdrwalDAO();
        gendao = new GeneralDAO();
        //if (Convert.ToInt16(lblEditMod.Text) == 1)
        //{
            if (lblWithId.Text == "")
            {
                wth.NumWithdrawalID = 0;
            }
            else
            {
                wth.NumWithdrawalID = Convert.ToInt32(lblWithId.Text.ToString());
            }
            //wth.NumWithdrawalID  = Convert.ToInt32(Session["WithID"]);
            if (lblNewAcc.Text == "")
            {
                wth.NumEmpID = 0;
            }
            else
            {
                wth.NumEmpID = Convert.ToInt32(lblNewAcc.Text);
            }
            if (ddlType.SelectedIndex > 0)
            {
                wth.IntTrnTypeID = Convert.ToInt16(ddlType.SelectedValue);
            }
            else
            {
                wth.IntTrnTypeID = 0;
            }
            if (txtAmt.Text == "")
            {
                wth.FltAllottedAmt = 0;
            }
            else
            {
                wth.FltAllottedAmt = Convert.ToInt64(txtAmt.Text);
            }
            if (txtconsAmt.Text == "")
            {
                wth.FltConsolidatedAmt = 0;
            }
            else
            {
                wth.FltConsolidatedAmt = Convert.ToInt64(txtconsAmt.Text);
            }
            wth.IntUserId = Convert.ToInt64(Session["intUserId"]);
            if (txtWithDt.Text == "")
            {
                wth.DtmWithdrawalEmp = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                wth.DtmWithdrawalEmp = Convert.ToDateTime(txtWithDt.Text);
            }
            wth.NumBillID = Convert.ToInt32(Session["numBillID"]);
            wth.FlgBillType = 0;

            int d = Convert.ToInt16(Session["flgPageBackW"]);
            if (Convert.ToInt16(Session["flgPageBackW"]) == 1)
            {
                wth.intYearID = Convert.ToInt16(Session["IntYearIdWit"]);
                wth.intMonthID = Convert.ToInt16(Session["IntMonthIdWit"]);

            }
            else
            {
                wth.intYearID = Convert.ToInt16(Session["WithYrID"]);
                wth.intMonthID = Convert.ToInt16(Session["WithMnthID"]);
            }
            if (chkUnP.Checked == true)
            {
                wth.FlgUnPosted = 1;
            }
            else
            {
                wth.FlgUnPosted = 0;
            }
            if (ddlUnP.SelectedIndex > 0)
            {
                wth.IntUnPostedRsn = Convert.ToInt16(ddlUnP.SelectedValue);
            }
            else
            {
                wth.IntUnPostedRsn = 0;
            }
            wth.IntModeChange = 3;
            if (drwnby.SelectedIndex > 0)
            {
                wth.IntDrawnId = Convert.ToInt16(drwnby.SelectedValue);
            }
            else
            {
                wth.IntDrawnId = 0;
            }
            if (ddldesig.SelectedIndex > 0)
            {
                wth.IntDesigId = Convert.ToInt16(ddldesig.SelectedValue);
            }
            else
            {
                wth.IntDesigId = 0;
            }
            if (ddlLB.SelectedIndex > 0)
            {
                wth.IntLBId = Convert.ToInt16(ddlLB.SelectedValue);
            }
            else
            {
                wth.IntLBId = 0;
            }
            if (txtorderNo.Text == "")
            {
                wth.ChvOrderNo = "";
            }
            else
            {
                wth.ChvOrderNo = txtorderNo.Text;
            }
            if (txtSDate.Text == "")
            {
                wth.DtmDateOfOrder = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                wth.DtmDateOfOrder = Convert.ToDateTime(txtSDate.Text);
            }
            if (ddlobj.SelectedIndex > 0)
            {
                wth.IntObjAdv = Convert.ToInt16(ddlobj.SelectedValue);
            }
            else
            {
                wth.IntObjAdv = 0;
            }
            if (txtprevtaDt.Text == "")
            {
                wth.ChvOdrNoDtOfPrevTA = "";
            }
            else
            {
                wth.ChvOdrNoDtOfPrevTA = txtprevtaDt.Text;
            }
            if (txtprevTaAmt.Text == "")
            {
                wth.FltAmtPrevTA = 0;
            }
            else
            {
                wth.FltAmtPrevTA = Convert.ToDouble(txtprevTaAmt.Text);
            }
            if (txtprevTABal.Text == "")
            {
                wth.FltBalancePrevTA = 0;
            }
            else
            {
                wth.FltBalancePrevTA = Convert.ToDouble(txtprevTABal.Text);
            }
            if (txtinstNo.Text == "")
            {
                wth.IntNoOfInstalment = 0;
            }
            else
            {
                wth.IntNoOfInstalment = Convert.ToInt32(txtinstNo.Text);
            }
            if (txtinstAmt.Text == "")
            {
                wth.FltAmtInstalment = 0;
            }
            else
            {
                wth.FltAmtInstalment = Convert.ToInt64(Math.Round(Convert.ToDouble(txtinstAmt.Text)));
            }
            DataSet ds = new DataSet();
            ds = wthd.SaveWithdrawals(wth);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                wth.NumWithdrawalID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
                lblWithId.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            Session["intCCYearId"] = gendao.GetCCYearId();
            if (Convert.ToInt16(Session["IntYearIdWit"]) <= Convert.ToInt16(Session["intCCYearId"]))
            {
                saveCorrectionEntry(Convert.ToInt64(wth.NumWithdrawalID), 0);
            }
        //}
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        FillDdlsSing();
        Mdlchl.Show();
        cleartexts();
        Session["Sessionclear"] = 1;         
    }
    private void cleartexts()
    {
        lblWithId.Text = "";
        txtAccNo.Text = "";
        ddldesig.SelectedIndex  =0;
        ddlLB.SelectedIndex = 0;
        txtAmt.Text = "";
        drwnby.SelectedIndex = 0;
        ddlType.SelectedIndex = 0;
        txtorderNo.Text = "";
        txtSDate.Text = "";
        ddlobj.SelectedIndex = 0;
        txtprevtaDt.Text = "";
        txtprevTaAmt.Text = "";
        txtprevTABal.Text = "";
        txtconsAmt.Text = "";
        txtinstNo.Text = "";
        txtinstAmt.Text = "";
        txtWithDt.Text = "";
        ddlUnP.SelectedIndex = 0;
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {

    }
    protected void txtWithDt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (txtWithDt.Text != "")
        {
            if (gblObj.isValidDate(txtSDate, this) == true)
            {
                //string dt = Session["Billdt"].ToString(); //commented on 051021 as per the direction from ao,kpepf
                //if (gblObj.CheckDate2(Session["Billdt"].ToString(), txtWithDt.Text.ToString()) == false)
                //{
                //    gblObj.MsgBoxOk("Invalid Date", this);
                //    txtWithDt.Text = "";
                //}
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtWithDt.Text = "";
            }
        }

        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtWithDt.Text = "";
        }
        Mdlchl.Show();
    }
}