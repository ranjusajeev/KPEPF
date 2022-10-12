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

public partial class Contents_WithdrawalsPDEEmp : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    WithdrawalPDE wth;
    WithdrawalPDEDAO wthd;
    Employee emp;
    EmployeeDAO empD;

    CorrectionEntry corr;
    CorrectionEntryDao corrDao;
    GeneralDAO gendao;

    //public static int intWithdrawBillId = 0;
    static int intCurRw = 0;
    static int intCurRwA = 0;
    static int intCorrType = 0;
    static string dtBill = "";

    double fltAmtBfr = 0;
    double fltAmtAfr = 0;
    int corrType = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["intBillWiseId"]) > 0)
            {
                Session["intWithdrawBillId"] = Convert.ToInt32(Request.QueryString["intBillWiseId"]);
                Session["dtmBillDate"] =Request.QueryString["dtmBillDate"].ToString();
                FillLbls();
                FillChalanS();
                SetCtrls();
            }
            else if (Convert.ToInt32(Session["flgPageBack"]) == 3)
            {
                FillLbls();
                FillChalanS();
                SetCtrls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void FillChalanS()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        wth = new WithdrawalPDE();
        wthd = new WithdrawalPDEDAO();

        DataSet dsW = new DataSet();
        wth.IntBillId = Convert.ToInt32(Session["intWithdrawBillId"]);
        dsW = wthd.GetWithdrawaEmp(wth);

        ////FillDdls()//////////
        DataSet dsl = new DataSet();
        dsl = wthd.GetLoanType();

        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gen.GetMisClassRsn(arrIn);
        ////FillDdls()//////////
        txtCnt.Text = dsW.Tables[0].Rows.Count.ToString();
        if (dsW.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsW;
            gdvChalanS.DataBind();
            for (int i = 0; i < gdvChalanS.Rows.Count; i++)
            {
                GridViewRow gdvrow = gdvChalanS.Rows[i];
                TextBox txtAccNoAss = (TextBox)gdvrow.FindControl("txtAccNo");
                Label lblNameAss = (Label)gdvrow.FindControl("lblName");
                CheckBox chkUnIdentAss = (CheckBox)gdvrow.FindControl("chkUnIdent");
                TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
                DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
                TextBox txtSDateAss = (TextBox)gdvrow.FindControl("txtSDate");
                TextBox txtWDateAss = (TextBox)gdvrow.FindControl("txtWDate");
                Label lblNewAccAss = (Label)gdvrow.FindControl("lblNewAcc");
                Label lblOldAccAss = (Label)gdvrow.FindControl("lblOldAcc");

                Label lblOldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
                Label lblWithIdAss = (Label)gdvrow.FindControl("lblWithId");
                Label lblWithIdPfoAss = (Label)gdvrow.FindControl("lblWithIdPfo");

                CheckBox chkUnPAss = (CheckBox)gdvrow.FindControl("chkUnP");
                DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");

                Label lblOldTp = (Label)gdvrow.FindControl("lblOldTp");

                ////FillDdls()//////////
                gblObj.FillCombo(ddlTypeAss, dsl, 1);
                gblObj.FillCombo(ddlUnPAss, dsM, 1);
                ////FillDdls()//////////

                txtAccNoAss.Text = dsW.Tables[0].Rows[i].ItemArray[1].ToString();
                lblNameAss.Text = dsW.Tables[0].Rows[i].ItemArray[2].ToString();
                txtAmtAss.Text = dsW.Tables[0].Rows[i].ItemArray[4].ToString();
                ddlTypeAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[6].ToString();
                txtSDateAss.Text = dsW.Tables[0].Rows[i].ItemArray[3].ToString();
                txtWDateAss.Text = dsW.Tables[0].Rows[i].ItemArray[18].ToString();
                lblNewAccAss.Text = dsW.Tables[0].Rows[i].ItemArray[16].ToString();
                lblOldAccAss.Text = dsW.Tables[0].Rows[i].ItemArray[16].ToString();

                lblOldAmtAss.Text = dsW.Tables[0].Rows[i].ItemArray[4].ToString();
                lblWithIdAss.Text = dsW.Tables[0].Rows[i].ItemArray[17].ToString();
                lblWithIdPfoAss.Text = dsW.Tables[0].Rows[i].ItemArray[22].ToString();
                lblOldTp.Text = dsW.Tables[0].Rows[i].ItemArray[6].ToString();


                if (Convert.ToInt16(dsW.Tables[0].Rows[i].ItemArray[15]) == 1)
                {
                    chkUnPAss.Checked = true;
                }
                else
                {
                    chkUnPAss.Checked = false;
                }
                ddlUnPAss.SelectedValue = dsW.Tables[0].Rows[i].ItemArray[16].ToString();

                TextBox txtODtPrev = (TextBox)gdvrow.FindControl("txtODtPrev");
                TextBox txtAmtPrev = (TextBox)gdvrow.FindControl("txtAmtPrev");
                txtODtPrev.Text = dsW.Tables[0].Rows[i].ItemArray[25].ToString();
                txtAmtPrev.Text = dsW.Tables[0].Rows[i].ItemArray[9].ToString();

                Label txtODtPrevO = (Label)gdvrow.FindControl("txtODtPrevO");
                Label txtAmtPrevO = (Label)gdvrow.FindControl("txtAmtPrevO");
                txtODtPrevO.Text = dsW.Tables[0].Rows[i].ItemArray[25].ToString();
                txtAmtPrevO.Text = dsW.Tables[0].Rows[i].ItemArray[9].ToString();

            }
            lblBillDt.Text = dsW.Tables[0].Rows[0].ItemArray[20].ToString();
            lblBillNo.Text = dsW.Tables[0].Rows[0].ItemArray[21].ToString();
            lblBAmt.Text = dsW.Tables[0].Rows[0].ItemArray[23].ToString();
            dtBill = dsW.Tables[0].Rows[0].ItemArray[20].ToString();

            
            gblObj.SetFooterTotalsTempField(gdvChalanS, 4, "txtAmt", 1);
        }
        else
        {
           dtBill = Session["dtmBillDate"].ToString();
            //SetGridDefault();
            InitialSettings();
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
        FillDdls();
    }
    private void FillDdls()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        wthd = new WithdrawalPDEDAO();

        DataSet dsl = new DataSet();
        dsl = wthd.GetLoanType();

        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gen.GetMisClassRsn(arrIn);

        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanS.Rows[i];
            DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
            gblObj.FillCombo(ddlTypeAss, dsl, 1);

            DropDownList ddlUnPAss = (DropDownList)gdvrow.FindControl("ddlUnP");
            gblObj.FillCombo(ddlUnPAss, dsM, 1);
        }

    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        gblObj.SetGridDefault(gdvChalanS, ar);
    }
    private void FillLbls()
    {
        gen = new GeneralDAO();

        ArrayList ary = new ArrayList();
        ary.Add(Convert.ToInt16(Session["IntYearWith1"]));
        lblYear.Text = gen.GetYearFromId(ary);

        ArrayList arm = new ArrayList();
        arm.Add(Convert.ToInt16(Session["IntMonthWith1"]));
        lblMonth.Text = gen.GetMonthFromId(arm);

        ArrayList art = new ArrayList();
        art.Add(Convert.ToInt16(Session["IntDTWith1"]));
        lblDT.Text = gen.GetDisTreasuryFromId(art);
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
    private void SetCtrlsDisable()
    {
        btnSave.Enabled = false;
        txtCnt.Enabled = false;
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanS.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdvrow.FindControl("txtAccNo");
            Label lblNameAss = (Label)gdvrow.FindControl("lblName");
            CheckBox chkUnIdentAss = (CheckBox)gdvrow.FindControl("chkUnIdent");
            TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
            TextBox txtSDateAss = (TextBox)gdvrow.FindControl("txtSDate");
            TextBox txtWDateAss = (TextBox)gdvrow.FindControl("txtWDate");
            Label lblNewAccAss = (Label)gdvrow.FindControl("lblNewAcc");
            Label lblOldAccAss = (Label)gdvrow.FindControl("lblOldAcc");

            Label lblOldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
            Label lblWithIdAss = (Label)gdvrow.FindControl("lblWithId");
            Label lblWithIdPfoAss = (Label)gdvrow.FindControl("lblWithIdPfo");
            ImageButton imgdel = (ImageButton)gdvrow.FindControl("btndelete");

            imgdel.Enabled = false;
            txtAccNoAss.ReadOnly = true;
            chkUnIdentAss.Enabled = false;
            txtAmtAss.ReadOnly = true;
            ddlTypeAss.Enabled = false;

            txtSDateAss.ReadOnly = true;
            txtSDateAss.Enabled = false;
            txtWDateAss.ReadOnly = true;
            txtWDateAss.Enabled = false;

            TextBox txtODtPrev = (TextBox)gdvrow.FindControl("txtODtPrev");
            TextBox txtAmtPrev = (TextBox)gdvrow.FindControl("txtAmtPrev");
            txtODtPrev.ReadOnly = true;
            txtODtPrev.Enabled = false;
            txtAmtPrev.ReadOnly = true;
            txtAmtPrev.Enabled = false;
        }
    }

    private void SetCtrlsEnable()
    {
        btnSave.Enabled = true;
        txtCnt.Enabled = true;
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvChalanS.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdvrow.FindControl("txtAccNo");
            Label lblNameAss = (Label)gdvrow.FindControl("lblName");
            CheckBox chkUnIdentAss = (CheckBox)gdvrow.FindControl("chkUnIdent");
            TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            DropDownList ddlTypeAss = (DropDownList)gdvrow.FindControl("ddlType");
            TextBox txtSDateAss = (TextBox)gdvrow.FindControl("txtSDate");
            TextBox txtWDateAss = (TextBox)gdvrow.FindControl("txtWDate");
            Label lblNewAccAss = (Label)gdvrow.FindControl("lblNewAcc");
            Label lblOldAccAss = (Label)gdvrow.FindControl("lblOldAcc");

            Label lblOldAmtAss = (Label)gdvrow.FindControl("lblOldAmt");
            Label lblWithIdAss = (Label)gdvrow.FindControl("lblWithId");
            Label lblWithIdPfoAss = (Label)gdvrow.FindControl("lblWithIdPfo");
            ImageButton imgdel = (ImageButton)gdvrow.FindControl("btndelete");

            imgdel.Enabled = true;
            txtAccNoAss.ReadOnly = false;
            chkUnIdentAss.Enabled = true;
            txtAmtAss.ReadOnly = false;
            ddlTypeAss.Enabled = true;

            txtSDateAss.ReadOnly = false;
            txtSDateAss.Enabled = true;
            txtWDateAss.ReadOnly = false;
            txtWDateAss.Enabled = true;

            TextBox txtODtPrev = (TextBox)gdvrow.FindControl("txtODtPrev");
            TextBox txtAmtPrev = (TextBox)gdvrow.FindControl("txtAmtPrev");
            txtODtPrev.ReadOnly = false;
            txtODtPrev.Enabled = true;
            txtAmtPrev.ReadOnly = false;
            txtAmtPrev.Enabled = true;

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if ((CheckMandatory()) == true)
        {
            SaveWithEmp();
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details", this);
        }
        FillChalanS();
        gblObj.MsgBoxOk("Updated", this);
        btnSave.Enabled = false;
    }
    private Boolean CheckMandatory()
    {
        gblObj = new clsGlobalMethods();
        Boolean flg = true;
        int cnt = 0;
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvChalanS.Rows[i];
            TextBox txtAmt = (TextBox)gvRw.FindControl("txtAmt");
            TextBox txtAccNo = (TextBox)gvRw.FindControl("txtAccNo");
            //TextBox txtOrderNo = (TextBox)gvRw.FindControl("txtorderNo");
            TextBox OderDt = (TextBox)gvRw.FindControl("txtSDate");
            TextBox WithDt = (TextBox)gvRw.FindControl("txtWDate");

            if (txtAmt.Text.ToString() == "" || txtAmt.Text.ToString() == "0" || txtAccNo.Text.ToString() == "" || txtAccNo.Text.ToString() == "0"
                || OderDt.Text.ToString() == "" || OderDt.Text.ToString() == "0"
                || WithDt.Text.ToString() == "" || WithDt.Text.ToString() == "0" )
            {
                gblObj.MsgBoxOk("Enter all details!", this);
                cnt = cnt + 1;
            }

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
    //private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, double intSchedId, int intCorrTp,double fltAmtBfr, double fltAmtAfr)
    //{
    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    //double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, fltAmtBfr - fltAmtAfr);
    //    double dblCalcAmt = fltAmtBfr - fltAmtAfr;
    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, 1, dblCalcAmt);
    //    ///// Save to CorrEntry/////////
    //    corr.IntAccNo = intAccNo;
    //    corr.IntYearID = yr;
    //    corr.IntMonthID = mth;
    //    corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    corr.FltAmountBefore = fltAmtBfr;
    //    corr.FltAmountAfter = fltAmtAfr;
    //    corr.FltCalcAmount = dblAmtAdjusted;
    //    corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    corr.IntChalanId = chalId;
    //    corr.IntSchedId = intSchedId;
    //    corr.FlgType = 2;           //Remittance
    //    corr.FltRoundingAmt = 0;
    //    corr.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    corr.IntChalanType = 1;
    //    corrDao.CreateCorrEntry(corr);
    //    ///// Save to CorrEntry/////////
    //}
    
    private void SaveWithEmp()
    {
        wth = new WithdrawalPDE();
        wthd = new WithdrawalPDEDAO();

        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvChalanS.Rows[i];
            Label lblEditModeAss = (Label)gvRw.FindControl("lblEditMode");
            if (Convert.ToInt16(lblEditModeAss.Text) >= 1)
            {
                Label lblWithIdPfoAss = (Label)gvRw.FindControl("lblWithIdPfo");
                Label lblWithIdAss = (Label)gvRw.FindControl("lblWithId");
                Label lblNewAccAss = (Label)gvRw.FindControl("lblNewAcc");
                Label lblOldAccAss = (Label)gvRw.FindControl("lblOldAcc");
                Label lblOldAmtAss = (Label)gvRw.FindControl("lblOldAmt");
                CheckBox chkUnIdentAss = (CheckBox)gvRw.FindControl("chkUnIdent");
                TextBox txtAmtAss = (TextBox)gvRw.FindControl("txtAmt");
                DropDownList ddlTypeAss = (DropDownList)gvRw.FindControl("ddlType");
                TextBox txtSDateass = (TextBox)gvRw.FindControl("txtSDate");
                TextBox txtWDateAss = (TextBox)gvRw.FindControl("txtWDate");
                CheckBox chkUnPAss = (CheckBox)gvRw.FindControl("chkUnP");
                DropDownList ddlUnPAss = (DropDownList)gvRw.FindControl("ddlUnP");

                TextBox txtODtPrev = (TextBox)gvRw.FindControl("txtODtPrev");
                TextBox txtAmtPrev = (TextBox)gvRw.FindControl("txtAmtPrev");

                fltAmtBfr = Convert.ToDouble(lblOldAmtAss.Text);
                wth.IntAccNo = Convert.ToInt32(lblNewAccAss.Text);
                intCorrType = 4;
                wth.IntAccNo = Convert.ToInt16(lblNewAccAss.Text);
                if (chkUnIdentAss.Checked == true)
                {
                    wth.FlgUnidentified = 1;
                }
                else
                {
                    wth.FlgUnidentified = 0;
                }
                if (txtAmtAss.Text == "")
                {
                    wth.FltAdvAmt = 0;
                }
                else
                {
                    wth.FltAdvAmt = Convert.ToInt64(txtAmtAss.Text);
                }
                if (ddlTypeAss.SelectedIndex > 0)
                {
                    wth.IntLoan = Convert.ToInt16(ddlTypeAss.SelectedValue);
                }
                else
                {
                    wth.IntLoan = 0;
                }

                wth.DtWithdraw = Convert.ToDateTime(txtWDateAss.Text);
                wth.Intmid = Convert.ToInt16(Session["IntMonthWith1"]);
                wth.IntYrId = Convert.ToInt16(Session["IntYearWith1"]);
                wth.IntUserId = Convert.ToInt64(Session["intUserId"]);
                if (chkUnPAss.Checked == true)
                {
                    wth.FlgUnPosted = 1;
                }
                else
                {
                    wth.FlgUnPosted = 0;
                }
                wth.ChvSantionNo = "";
                wth.FltConsolidate = 0;
                wth.IntNoOfInstalments = 0;
                wth.FltInstalmentAmt = 0;
                wth.Intmid = Convert.ToInt16(Session["IntMonthWith1"]);
                wth.IntYrId = Convert.ToInt16(Session["IntYearWith1"]);
                wth.IntUserId = Convert.ToInt64(Session["intUserId"]);
                if (chkUnPAss.Checked == true)
                {
                    wth.FlgUnPosted = 1;
                }
                else
                {
                    wth.FlgUnPosted = 0;
                }
                wth.IntUnPostedRsn = 0;
                wth.IntDisId = Convert.ToInt16(Session["IntDistWith1"]);
                if (lblWithIdPfoAss.Text == "")
                {
                    wth.IntId = 0;
                }
                else
                {
                    wth.IntId = Convert.ToInt32(lblWithIdPfoAss.Text);
                }
                if (lblWithIdAss.Text == "")
                {
                    wth.IntWithdrawalRefId = 0;
                    wth.IntIdAPWith = 0;
                }
                else
                {
                    wth.IntWithdrawalRefId = Convert.ToInt32(lblWithIdAss.Text);
                    wth.IntIdAPWith = Convert.ToInt32(lblWithIdAss.Text);
                }
                if (txtWDateAss.Text != "" && txtWDateAss.Text != null)
                {
                    wth.DtWithdraw = Convert.ToDateTime(txtWDateAss.Text);
                }
                else
                {
                    wth.DtWithdraw = DateTime.Now;
                }

                if (txtSDateass.Text != "" && txtSDateass.Text != null)
                {
                    wth.DtSantion = Convert.ToDateTime(txtSDateass.Text);
                }
                else
                {
                    wth.DtSantion = DateTime.Now;
                }
                wth.IntBillId = Convert.ToInt32(Session["intWithdrawBillId"]);
                wth.IntLBId = 0;
                wth.IntSlNo = 0;
                wth.IntModeOfChgId = 3;
                wth.ChvOdrNoDtOfPrevTA = txtODtPrev.Text.ToString();
                if (txtAmtPrev.Text == "" || txtAmtPrev.Text == null)
                {
                    wth.FltAmtPrevTA = 0;
                }
                else
                {
                    wth.FltAmtPrevTA = Convert.ToInt64(txtAmtPrev.Text);
                }
                DataSet ds1 = new DataSet();
                ds1 = wthd.UpdateWithPde1(wth);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    wth.IntWithdrawalRefId = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0]);
                }
                wthd.UpdateWithPde(wth);
                saveCorrectionEntry(i, Convert.ToInt32(lblWithIdPfoAss.Text), 0);
            }
        }
    }
    protected void txtAccNo_TextChanged1(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        DataSet dsName = new DataSet();
        GridViewRow gdr = gdvChalanS.Rows[intCurRw];
        Label lblAccNoAss = (Label)gdr.FindControl("lblAccNo");
        TextBox txtAccNoAss = (TextBox)gdr.FindControl("txtAccNo");
        Label lblNameAss = (Label)gdr.FindControl("lblName");
        Label lblNewAccAss = (Label)gdr.FindControl("lblNewAcc");
        Label lblOldAccAss = (Label)gdr.FindControl("lblOldAcc");
        Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");
        if (gblObj.CheckNumericOnly(txtAccNoAss.Text.ToString(), this) == true)
        {

            emp.NumEmpID = Convert.ToDouble(txtAccNoAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                lblNewAccAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            else
            {
                txtAccNoAss.Text = "";
                lblNameAss.Text = "";
                gblObj.MsgBoxOk("Doesn't exist!", this);
            }
            if (Convert.ToInt16(lblOldAccAss.Text) != Convert.ToInt16(lblNewAccAss.Text))
            {
                lblEditModeAss.Text = "1";
            }
            else
            {
                lblEditModeAss.Text = "0";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter Numeric Value", this);
            txtAccNoAss.Text = "";
            lblNameAss.Text = "";
        }
    }

    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        intCurRwA = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvChalanS.Rows[intCurRwA];
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
        TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
        Label lblOldAmtAss = (Label)gvr.FindControl("lblOldAmt");
        if (Convert.ToDouble(lblOldAmtAss.Text) != Convert.ToDouble(txtAmtAss.Text))
        {
            lblEditModeAss.Text = "1";
        }
        else
        {
            lblEditModeAss.Text = "0";
        }

        gblObj.SetFooterTotalsTempField(gdvChalanS, 4, "txtAmt", 1);
    }
    protected void txtSDate_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        int intCurRwDt2 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gdr = gdvChalanS.Rows[intCurRwDt2];
        TextBox txtSDateAss = (TextBox)gdr.FindControl("txtSDate");
        Label lblEditMode = (Label)gdr.FindControl("lblEditMode");
        if (txtSDateAss.Text != "")
        {
            if (gblObj.isValidDate(txtSDateAss, this) == true )
            {
                if (gblObj.CheckDate2(txtSDateAss.Text.ToString(), DateTime.Now.ToString()) == true)
                {
                    if (gblObj.CheckDate2(txtSDateAss.Text.ToString(),dtBill.ToString()) == true)
                    {

                    }
                    else
                    {
                        gblObj.MsgBoxOk("Invalid Date", this);
                        txtSDateAss.Text = "";
                    }
                }
                else
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtSDateAss.Text = "";
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtSDateAss.Text = "";
            }
        }
        lblEditMode.Text = "1";


        //int intCurRwDt2 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        //GridViewRow gdr = gdvChalanS.Rows[intCurRwDt2];
        //TextBox txtSDateAss = (TextBox)gdr.FindControl("txtSDate");
        //Label lblEditMode = (Label)gdr.FindControl("lblEditMode");
        //if (gblObj.isValidDate(txtSDateAss, this) == false)
        //{
        //    gblObj.MsgBoxOk("Invalid Date!", this);
        //    txtSDateAss.Text = "";
        //}
        //else if (gblObj.CheckDate2(txtSDateAss.Text.ToString(), DateTime.Now.ToString()) == false)
        //{
        //    gblObj.MsgBoxOk("Invalid Date", this);
        //    txtSDateAss.Text = "";
        //}
        //lblEditMode.Text = "1";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["flgPageBackW"]) == 1)
        {
            btnBack.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
        }
        //else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
        //{
        //    btnBack.PostBackUrl = "~/Contents/AnnStatement.aspx";
        //}
        else if (Convert.ToInt16(Session["flgPageBackW"]) == 3)
        {
            btnBack.PostBackUrl = "~/Contents/WithdrawalsPDEPrev.aspx";
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        wthd = new WithdrawalPDEDAO();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblWithIdAss = (Label)gdvChalanS.Rows[rowIndex].FindControl("lblWithId");
        TextBox txtAmt = (TextBox)gdvChalanS.Rows[rowIndex].FindControl("txtAmt");
        Label lblAccNo = (Label)gdvChalanS.Rows[rowIndex].FindControl("lblOldAcc");
        if (lblWithIdAss.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblWithIdAss.Text));
            try
            {
                wthd.UpdateWithdrawalMode(arrin);
                saveCorrectionEntry(rowIndex, Convert.ToInt64(lblWithIdAss.Text), 1);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
        }
        gblObj.MsgBoxOk("Row Deleted   !", this);
        FillChalanS();
    }
    private void saveCorrectionEntry(int rw, float schedId, int intDel)
    {
        GenDao = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();
        gendao = new GeneralDAO();

        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
  
        yr = Convert.ToInt16(Session["IntYearWith1"]);
        mth = Convert.ToInt16(Session["IntMonthWith1"]);
        intDy = 10;

        GridViewRow gvrow = gdvChalanS.Rows[rw];
        Label lblOTot = (Label)gvrow.FindControl("lblOldAmt");
        TextBox lblNewTot = (TextBox)gvrow.FindControl("txtAmt");
        Label lblOAcc = (Label)gvrow.FindControl("lblOldAcc");
        Label lblNewAcc = (Label)gvrow.FindControl("lblNewAcc");
        Label lblSched = (Label)gvrow.FindControl("lblWithIdPfo");

        amtO = Convert.ToDouble(lblOTot.Text);
        amtN = Convert.ToDouble(lblNewTot.Text);
        accO = Convert.ToInt32(lblOAcc.Text);
        accN = Convert.ToInt32(lblNewAcc.Text);

        findCorrType(amtO, amtN, accO, accN, intDel);
        //findCorrAmt(amtO, amtN);
        if (corrType == 2)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    corr.IntAccNo = Convert.ToInt32(lblOAcc.Text);
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
                corr.IntChalanId = Convert.ToInt64(Session["intWithdrawBillId"]);
                corr.IntSchedId = Convert.ToInt32(lblSched.Text);
                corr.FlgType = 2;           //Remittance
                corr.FltRoundingAmt = 0;
                corr.IntCorrectionType = corrType;
                //if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
                //{
                //    corr.IntChalanType = 1;
                //}
                //else
                //{
                    corr.IntChalanType = 2;
                //}
                corr.IntTblTp = 1;
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
            corr.IntChalanId = Convert.ToInt64(Session["intWithdrawBillId"]);
            corr.IntSchedId = schedId;
            corr.FlgType = 2;           //Remittance
            corr.FltRoundingAmt = 0;
            corr.IntCorrectionType = corrType;
            //if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
            //{
            //    corr.IntChalanType = 1;
            //}
            //else
            //{
                corr.IntChalanType = 2;
            //}
            corr.IntTblTp = 1;
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
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        wth = new WithdrawalPDE();
        wthd = new WithdrawalPDEDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlType");
            //////Store Ddls in an array//////////

            //////Store Ds to fill Ddls in an array//////////
            DataSet dsl = new DataSet();
            dsl = wthd.GetLoanType();

            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dsl);
            //////Store Ds to fill Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsW = new DataSet();
            wth.IntBillId = Convert.ToInt32(Session["intWithdrawBillId"]);
            dsW = wthd.GetWithdrawaEmpCnt(wth);



            ////Ds to fill Grid//////////

            gblObj.SetGridRowsWithData(dsW, Convert.ToInt16(txtCnt.Text), gdvChalanS, arDdl, arCols, arDdlDs);
            FillFooterTotals();
        }
        else
        {
            gblObj.SetRowsCnt(gdvChalanS, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        //arCols.Add("lblSlNo");
        arCols.Add("txtAccNo");
        arCols.Add("lblName");
        arCols.Add("chkUnIdent");
        arCols.Add("txtAmt");
        arCols.Add("ddlType");
        arCols.Add("txtSDate");
        arCols.Add("txtWDate");

        arCols.Add("lblWithId");
        arCols.Add("lblWithIdPfo");

    }
    private void FillFooterTotals()
    {
        gblObj = new clsGlobalMethods();

        gblObj.SetFooterTotalsTempField(gdvChalanS, 5, "txtAmt", 1);
    }
    protected void txtWDate_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        int intCurRwDt2 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        GridViewRow gdr = gdvChalanS.Rows[intCurRwDt2];
        TextBox txtWDate = (TextBox)gdr.FindControl("txtWDate");
        Label lblEditMode = (Label)gdr.FindControl("lblEditMode");
        if (gblObj.isValidDate(txtWDate, this) == false)
        {
            gblObj.MsgBoxOk("Invalid Date!", this);
            txtWDate.Text = "";
        }
        else if (gblObj.CheckDate2(txtWDate.Text.ToString(), DateTime.Now.ToString()) == false)
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtWDate.Text = "";
        }
        lblEditMode.Text = "1";
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        intCurRw = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
        GridViewRow gdr = gdvChalanS.Rows[intCurRw];
        DropDownList ddlType = (DropDownList)gdr.FindControl("ddlType");
        Label lblOldTp = (Label)gdr.FindControl("lblOldTp");
        Label lblEditMode = (Label)gdr.FindControl("lblEditMode");
        if (Convert.ToInt16(ddlType.SelectedValue) != Convert.ToInt16(lblOldTp.Text))
        {
            lblEditMode.Text = "1";
        }
        else
        {
            lblEditMode.Text = "0";
        }
    }
    protected void txtODtPrev_TextChanged(object sender, EventArgs e)
    {
        intCurRwA = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvChalanS.Rows[intCurRwA];
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
        TextBox txtODtPrev = (TextBox)gvr.FindControl("txtODtPrev");
        Label txtODtPrevO = (Label)gvr.FindControl("txtODtPrevO");
        if (txtODtPrevO.Text.ToString() != txtODtPrev.Text.ToString())
        {
            lblEditModeAss.Text = "1";
        }
        else
        {
            lblEditModeAss.Text = "0";
        }
    }
    protected void txtAmtPrev_TextChanged(object sender, EventArgs e)
    {
        intCurRwA = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvChalanS.Rows[intCurRwA];
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
        TextBox txtAmtPrev = (TextBox)gvr.FindControl("txtAmtPrev");
        Label txtAmtPrevO = (Label)gvr.FindControl("txtAmtPrevO");
        //if (Convert.ToDouble(txtAmtPrevO.Text) != Convert.ToDouble(txtAmtPrev.Text))
        //{
        //    lblEditModeAss.Text = "1";
        //}
        //else
        //{
        //    lblEditModeAss.Text = "0";
        //}

        lblEditModeAss.Text = "1";

    }
}
