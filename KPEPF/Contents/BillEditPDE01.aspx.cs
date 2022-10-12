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
public partial class Contents_BillEdit : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblObj;
    AORecorrection aoRecorr;
    AORecorrectionDAO aoRecorrDAO;
    Employee emp;
    EmployeeDAO empD;
    WithdrawalPDE wth;
    WithdrawalPDEDAO wthd;

    CorrectionEntry cor;
    CorrectionEntryDao cord;

    int corrType = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettings();
            //FillGrid();
        }
    }
    private void Initialsettings()
    {
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();

        DataSet ds2 = new DataSet();
        ds2 = genDAO.GetYearPDEOnly();
        gblObj.FillCombo(ddlYear, ds2, 1);

        DataSet ds1 = new DataSet();
        ds1 = genDAO.GetMonth();
        gblObj.FillCombo(ddlMonth, ds1, 1);

        DataSet dsD = new DataSet();
        dsD = genDAO.GetDistrict();
        gblObj.FillCombo(ddlDistrict, dsD, 1);
        
        //DataSet dsR = new DataSet();
        //ArrayList ar = new ArrayList();
        //ar.Add(1);                      //1 - UnPosted Reason
        //dsR = genDAO.getReason(ar);
        //gblObj.FillCombo(ddlDistrict, dsR, 1);

        SetGridDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 1;
    }
    private void FillGrid()
    {
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        aoRecorr = new AORecorrection();
        aoRecorrDAO = new AORecorrectionDAO();
        wthd = new WithdrawalPDEDAO();

        DataSet dsApp = new DataSet();
        DataSet dsAppFlg = new DataSet();

        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdBillEdit"]);
        aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdBillEdit"]);
        aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdBillEdit"]);
        aoRecorr.IntType = 2;
        dsAppFlg = aoRecorrDAO.SelectApprovalPDEWithFlg(aoRecorr);

        dsApp = aoRecorrDAO.SelectApprovalPDELnk1With(aoRecorr);
        if (dsApp.Tables[0].Rows.Count > 0)
        {
            gdvBill.DataSource = dsApp;
            gdvBill.DataBind();
            txtCnt.Text = dsApp.Tables[0].Rows.Count.ToString();
            for (int i = 0; i < dsApp.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvBill.Rows[i];
                TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
                txtAccNoAss.Text = dsApp.Tables[0].Rows[i].ItemArray[9].ToString();

                Label lblNameAss = (Label)gdv.FindControl("lblName");
                lblNameAss.Text = dsApp.Tables[0].Rows[i].ItemArray[1].ToString();

                CheckBox chkUnIdntAss = (CheckBox)gdv.FindControl("chkUnIdnt");
                CheckBox chkUpAss = (CheckBox)gdv.FindControl("chkUp");
                
                if (dsApp.Tables[0].Rows[i].ItemArray[15].ToString() == "1")
                {
                    chkUnIdntAss.Checked = true;
                }
                else
                {
                    chkUnIdntAss.Checked = false;
                }
                
                TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
                txtAmtAss.Text = dsApp.Tables[0].Rows[i].ItemArray[7].ToString();

                TextBox txtSanction = (TextBox)gdv.FindControl("txtSanction");
                txtSanction.Text = dsApp.Tables[0].Rows[i].ItemArray[22].ToString();

                
                TextBox txtDtSanctionAss = (TextBox)gdv.FindControl("txtDtSanction");
                txtDtSanctionAss.Text = dsApp.Tables[0].Rows[i].ItemArray[5].ToString();

                TextBox txtDtWithAss = (TextBox)gdv.FindControl("txtDtWith");
                txtDtWithAss.Text = dsApp.Tables[0].Rows[i].ItemArray[6].ToString();

                TextBox txtConsAss = (TextBox)gdv.FindControl("txtCons");
                txtConsAss.Text = dsApp.Tables[0].Rows[i].ItemArray[12].ToString();

                TextBox txtInstNoAss = (TextBox)gdv.FindControl("txtInstNo");
                txtInstNoAss.Text = dsApp.Tables[0].Rows[i].ItemArray[13].ToString();

                TextBox txtInstAmtAss = (TextBox)gdv.FindControl("txtInstAmt");
                txtInstAmtAss.Text = dsApp.Tables[0].Rows[i].ItemArray[14].ToString();

                DropDownList ddlTypeAss = (DropDownList)gdv.FindControl("ddlType");
                DataSet dsl = new DataSet();
                dsl = wthd.GetLoanType();
                gblObj.FillCombo(ddlTypeAss, dsl, 1);
                ddlTypeAss.SelectedValue = dsApp.Tables[0].Rows[i].ItemArray[21].ToString();

                DropDownList ddlRsnAss = (DropDownList)gdv.FindControl("ddlRsn");
                DataSet dsR = new DataSet();
                ArrayList ar = new ArrayList();
                ar.Add(1);                      //1 - UnPosted Reason
                dsR = genDAO.getReason(ar);
                gblObj.FillCombo(ddlRsnAss, dsR, 1);
                ddlRsnAss.SelectedValue = dsApp.Tables[0].Rows[i].ItemArray[18].ToString();

                if (dsApp.Tables[0].Rows[i].ItemArray[4].ToString() == "1")
                {
                    chkUpAss.Checked = true;
                    ddlRsnAss.Enabled = true;
                }
                else
                {
                    chkUpAss.Checked = false;
                    ddlRsnAss.Enabled = false;
                }

                Label lblWithIdAss = (Label)gdv.FindControl("lblWithId");
                lblWithIdAss.Text = dsApp.Tables[0].Rows[i].ItemArray[10].ToString();

                Label lblCorrIdAss = (Label)gdv.FindControl("lblCorrId");
                lblCorrIdAss.Text = dsApp.Tables[0].Rows[i].ItemArray[10].ToString();

                Label lblAccNoAss = (Label)gdv.FindControl("lblAccNo");
                lblAccNoAss.Text = dsApp.Tables[0].Rows[i].ItemArray[0].ToString();

                Label lblNewAccNoAss = (Label)gdv.FindControl("lblNewAccNo");
                lblNewAccNoAss.Text = dsApp.Tables[0].Rows[i].ItemArray[0].ToString();

                Label lblOldAmtAss = (Label)gdv.FindControl("lblOldAmt");
                lblOldAmtAss.Text = dsApp.Tables[0].Rows[i].ItemArray[7].ToString();

                Label lblEditModeAss = (Label)gdv.FindControl("lblEditMode");
                lblEditModeAss.Text = "0";

                TextBox txtODtPrev = (TextBox)gdv.FindControl("txtODtPrev");
                TextBox txtAmtPrev = (TextBox)gdv.FindControl("txtAmtPrev");
                txtODtPrev.Text = dsApp.Tables[0].Rows[i].ItemArray[23].ToString();
                txtAmtPrev.Text = dsApp.Tables[0].Rows[i].ItemArray[24].ToString();
            }
            gblObj.SetFooterTotalsTempField(gdvBill, 4, "txtAmt",1);
            //lblTotAmt.Text = gdvBill.FooterRow.Cells[4].Text;
            SetGridStatus(dsAppFlg);
        }
        else
        {
            SetGridDefault();
        }

    }
    private void SetGridStatus(DataSet ds)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "2")
            {
                SetGridEnable();
                lblType.Text = "Rejected";
                btnOK.Enabled = true;
                txtCnt.Enabled = true;
            }
            else
            {
                SetGridDisable();
                lblType.Text = "Approved";
                btnOK.Enabled = false;
                txtCnt.Enabled = false;
            }
        }
    }
    private void SetGridEnable()
    {
        for (int i = 0; i < gdvBill.Rows.Count; i++)
        {
            GridViewRow gdv = gdvBill.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
            CheckBox chkUnIdntAss = (CheckBox)gdv.FindControl("chkUnIdnt");
            CheckBox chkUpAss = (CheckBox)gdv.FindControl("chkUp");
            TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
            TextBox txtDtSanctionAss = (TextBox)gdv.FindControl("txtDtSanction");
            TextBox txtDtWithAss = (TextBox)gdv.FindControl("txtDtWith");
            TextBox txtConsAss = (TextBox)gdv.FindControl("txtCons");
            TextBox txtInstNoAss = (TextBox)gdv.FindControl("txtInstNo");
            TextBox txtInstAmtAss = (TextBox)gdv.FindControl("txtInstAmt");
            DropDownList ddlTypeAss = (DropDownList)gdv.FindControl("ddlType");
            ImageButton btndelete = (ImageButton)gdv.FindControl("btndelete");
            TextBox txtSanction = (TextBox)gdv.FindControl("txtSanction");

            txtAccNoAss.ReadOnly = false;
            chkUnIdntAss.Enabled = true;
            chkUpAss.Enabled = true;
            txtAmtAss.ReadOnly = false;

            //txtDtSanctionAss.ReadOnly = false;
            //txtDtWithAss.ReadOnly = false;
            txtDtSanctionAss.Enabled = true;
            txtDtWithAss.Enabled = true;

            txtConsAss.ReadOnly = false;
            txtInstNoAss.ReadOnly = false;
            txtInstAmtAss.ReadOnly = false;
            ddlTypeAss.Enabled = true;
            btndelete.Enabled = true;
            txtSanction.ReadOnly = false;

            TextBox txtODtPrev = (TextBox)gdv.FindControl("txtODtPrev");
            TextBox txtAmtPrev = (TextBox)gdv.FindControl("txtAmtPrev");
            txtODtPrev.ReadOnly = false;
            txtODtPrev.Enabled = true;
            txtAmtPrev.ReadOnly = false;
            txtAmtPrev.Enabled = true;
        }
    }
    private void SetGridDisable()
    {
        for (int i = 0; i < gdvBill.Rows.Count ; i++)
        {
            GridViewRow gdv = gdvBill.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
            CheckBox chkUnIdntAss = (CheckBox)gdv.FindControl("chkUnIdnt");
            CheckBox chkUpAss = (CheckBox)gdv.FindControl("chkUp");
            TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
            TextBox txtDtSanctionAss = (TextBox)gdv.FindControl("txtDtSanction");
            TextBox txtDtWithAss = (TextBox)gdv.FindControl("txtDtWith");
            TextBox txtConsAss = (TextBox)gdv.FindControl("txtCons");
            TextBox txtInstNoAss = (TextBox)gdv.FindControl("txtInstNo");
            TextBox txtInstAmtAss = (TextBox)gdv.FindControl("txtInstAmt");
            DropDownList ddlTypeAss = (DropDownList)gdv.FindControl("ddlType");
            ImageButton btndelete = (ImageButton)gdv.FindControl("btndelete");

            TextBox txtSanction = (TextBox)gdv.FindControl("txtSanction");
            txtAccNoAss.ReadOnly = true;
            chkUnIdntAss.Enabled = false ;
            chkUpAss.Enabled = false ;
            txtAmtAss.ReadOnly = true;

            //txtDtSanctionAss.ReadOnly = true;
            //txtDtWithAss.ReadOnly = true;
            txtDtSanctionAss.Enabled = false;
            txtDtWithAss.Enabled = false;

            txtConsAss.ReadOnly = true;
            txtInstNoAss.ReadOnly = true;
            txtInstAmtAss.ReadOnly = true;

            ddlTypeAss.Enabled = false;
            btndelete.Enabled = false;
            txtSanction.ReadOnly = true;

            TextBox txtODtPrev = (TextBox)gdv.FindControl("txtODtPrev");
            TextBox txtAmtPrev = (TextBox)gdv.FindControl("txtAmtPrev");
            txtODtPrev.ReadOnly = true;
            txtODtPrev.Enabled = false;
            txtAmtPrev.ReadOnly = true;
            txtAmtPrev.Enabled = false;
        }
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        //ar.Add("dtSantion");
        //ar.Add("dtWithdraw");
        gblObj.SetGridDefault(gdvBill, ar);
    }
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        int intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        DataSet dsName = new DataSet();
        GridViewRow gdr = gdvBill.Rows[intCurRw];
        Label lblAccNoAss = (Label)gdr.FindControl("lblAccNo");
        TextBox txtAccNoAss = (TextBox)gdr.FindControl("txtAccNo");
        Label lblNameAss = (Label)gdr.FindControl("lblName");
        Label lblNewAccNoAss = (Label)gdr.FindControl("lblNewAccNo");
        Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");

        if (gblObj.CheckNumericOnly(txtAccNoAss.Text.ToString(), this) == true)
        {
            emp.NumEmpID = Convert.ToDouble(txtAccNoAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                lblNewAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            if (Convert.ToInt16(lblAccNoAss.Text) != Convert.ToInt16(lblNewAccNoAss.Text))
            {
                lblEditModeAss.Text = "1";
            }
            else
            {
                lblEditModeAss.Text = "0";
            }
        }
    }  
    protected void btnOK_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        UpdateWithdrawals();
        gblObj.MsgBoxOk("Updated", this);
        FillGrid();
    }
    private Boolean CheckMandatory(TextBox txtAmt, TextBox txtNo, TextBox txtDt)
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (Convert.ToDouble(txtAmt.Text) == 0 || txtNo.Text.ToString() == "" || Convert.ToString(txtDt.Text) == "")
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
    private void UpdateWithdrawals()
    {
        wth = new WithdrawalPDE();
        wthd = new WithdrawalPDEDAO();
        //cor = new CorrectionEntry();

        for (int i = 0; i < gdvBill.Rows.Count; i++)
        {
            GridViewRow gvrow = gdvBill.Rows[i];
            Label lblEditModeAss = (Label)gvrow.FindControl("lblEditMode");

            if (Convert.ToInt16(lblEditModeAss.Text) >= 1)
            {
                Label lblWithIdAss = (Label)gvrow.FindControl("lblWithId");
                TextBox txtAccNoAss = (TextBox)gvrow.FindControl("txtAccNo");
                CheckBox chkUnIdntAss = (CheckBox)gvrow.FindControl("chkUnIdnt");
                TextBox txtAmtAss = (TextBox)gvrow.FindControl("txtAmt");
                TextBox txtSanctionAss = (TextBox)gvrow.FindControl("txtSanction");
                TextBox txtDtSanctionAss = (TextBox)gvrow.FindControl("txtDtSanction");
                TextBox txtDtWithAss = (TextBox)gvrow.FindControl("txtDtWith");
                TextBox txtConsAss = (TextBox)gvrow.FindControl("txtCons");
                TextBox txtInstNoAss = (TextBox)gvrow.FindControl("txtInstNo");
                TextBox txtInstAmtAss = (TextBox)gvrow.FindControl("txtInstAmt");
                CheckBox chkUpAss = (CheckBox)gvrow.FindControl("chkUp");
                DropDownList ddlRsn = (DropDownList)gvrow.FindControl("ddlRsn");
                CheckBox chkDelAss = (CheckBox)gvrow.FindControl("chkDel");
                Label lblAccNoAss = (Label)gvrow.FindControl("lblAccNo");
                Label lblNewAccNoAss = (Label)gvrow.FindControl("lblNewAccNo");
                Label lblOldAmtAss = (Label)gvrow.FindControl("lblOldAmt");
                DropDownList ddlTypeAss = (DropDownList)gvrow.FindControl("ddlType");
                TextBox txtODtPrev = (TextBox)gvrow.FindControl("txtODtPrev");
                TextBox txtAmtPrev = (TextBox)gvrow.FindControl("txtAmtPrev");
                if (CheckMandatory(txtAmtAss, txtSanctionAss, txtDtSanctionAss) == true)
                {
                    DataSet dsw = new DataSet();
                    wth.IntId = Convert.ToInt32(lblWithIdAss.Text);
                    //cor.IntCorrectionType = 4;
                    wth.IntAccNo = Convert.ToInt16(lblNewAccNoAss.Text);
                    if (chkUnIdntAss.Checked == true)
                    {
                        wth.FlgUnidentified = 1;
                    }
                    else
                    {
                        wth.FlgUnidentified = 0;
                    }
                    if (txtAmtAss.Text == "" || txtAmtAss.Text == null)
                    {
                        wth.FltAdvAmt = 0;
                        //cor.FltAmountAfter = 0;
                    }
                    else
                    {
                        wth.FltAdvAmt = Convert.ToInt64(txtAmtAss.Text);
                        //cor.FltAmountAfter = Convert.ToInt64(txtAmtAss.Text);
                    }
                    //cor.FltAmountBefore = 0;
                    if (ddlTypeAss.SelectedIndex > 0)
                    {
                        wth.IntLoan = Convert.ToInt16(ddlTypeAss.SelectedValue);
                    }
                    else
                    {
                        wth.IntLoan = 0;
                    }
                    if (txtSanctionAss.Text == "")
                    {
                        wth.ChvSantionNo = "";
                    }
                    else
                    {
                        wth.ChvSantionNo = txtSanctionAss.Text.ToString();
                    }
                    if (txtDtSanctionAss.Text == "")
                    {
                        wth.DtSantion = Convert.ToDateTime("");
                    }
                    else
                    {
                        wth.DtSantion = Convert.ToDateTime(txtDtSanctionAss.Text);
                    }
                    if (txtDtWithAss.Text == "")
                    {
                        wth.DtWithdraw = Convert.ToDateTime("");
                    }
                    else
                    {
                        wth.DtWithdraw = Convert.ToDateTime(txtDtWithAss.Text);
                    }
                    if (txtConsAss.Text == "")
                    {
                        wth.FltConsolidate = 0;
                    }
                    else
                    {
                        wth.FltConsolidate = Convert.ToInt64(txtConsAss.Text);
                    }

                    if (txtInstNoAss.Text == "")
                    {
                        wth.IntNoOfInstalments = 0;
                    }
                    else
                    {
                        wth.IntNoOfInstalments = Convert.ToInt16(txtInstNoAss.Text);
                    }
                    if (txtInstAmtAss.Text == "")
                    {
                        wth.FltInstalmentAmt = 0;
                    }
                    else
                    {
                        wth.FltInstalmentAmt = Convert.ToInt64(txtInstAmtAss.Text);
                    }
                    wth.Intmid = Convert.ToInt16(Session["intMonthIdBillEdit"]);
                    wth.IntYrId = Convert.ToInt16(Session["intYearIdBillEdit"]);
                    wth.IntUserId = Convert.ToInt64(Session["intUserId"]);
                    if (chkUpAss.Checked == true)
                    {
                        wth.FlgUnPosted = 1;
                    }
                    else
                    {
                        wth.FlgUnPosted = 0;
                    }
                    wth.IntUnPostedRsn = Convert.ToInt16(ddlRsn.SelectedValue);
                    //wth.IntModeOfChgId = 3;
                    wth.IntDisId = Convert.ToInt32(Session["intDistIdBillEdit"]);
                    wth.IntModeOfChgId = 2;
                    wth.ChvOdrNoDtOfPrevTA = txtODtPrev.Text.ToString();
                    if (txtAmtPrev.Text == "" || txtAmtPrev.Text == null)
                    {
                        wth.FltAmtPrevTA = 0;
                    }
                    else
                    {
                        wth.FltAmtPrevTA = Convert.ToInt64(txtAmtPrev.Text);
                    }
                    dsw = wthd.UpdateWithPde(wth);
                    if (dsw.Tables[0].Rows.Count > 0)
                    {
                        wth.IntId = Convert.ToInt32(dsw.Tables[0].Rows[0].ItemArray[0]);
                    }
                    saveCorrectionEntry(i, wth.IntId, 0);
                }
            }
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIdBillEdit"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearIdBillEdit"] = 0;
        }
        if (Convert.ToInt16(Session["intYearIdBillEdit"]) >= 49)
        {
            gblObj.MsgBoxOk("Select year <2013-14", this);
            ddlMonth.Enabled = false;
        }
        else
        {
            ddlMonth.Enabled = true;
        }
        //if (Convert.ToInt16(Session["intYearIdBillEdit"]) > 0 && Convert.ToInt16(Session["intMonthIdBillEdit"]) > 0 && Convert.ToInt16(Session["intDistIdBillEdit"]) > 0)
        //{
        //    FillGrid();
        //}
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0)
        {
            Session["intMonthIdBillEdit"] = Convert.ToInt16(ddlMonth.SelectedValue);
        }
        else
        {
            Session["intMonthIdBillEdit"] = 0;
        }
        //if (Convert.ToInt16(Session["intYearIdBillEdit"]) > 0 && Convert.ToInt16(Session["intMonthIdBillEdit"]) > 0 && Convert.ToInt16(Session["intDistIdBillEdit"]) > 0)
        //{
        //    FillGrid();
        //}
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedIndex > 0)
        {
            Session["intDistIdBillEdit"] = Convert.ToInt16(ddlDistrict.SelectedValue);
        }
        else
        {
            Session["intDistIdBillEdit"] = 0;
        }
        if (Convert.ToInt16(Session["intYearIdBillEdit"]) > 0 && Convert.ToInt16(Session["intMonthIdBillEdit"]) > 0 && Convert.ToInt16(Session["intDistIdBillEdit"]) > 0)
        {
            FillGrid();
        }
    }
    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        int intCurRwAmt = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        GridViewRow gdr = gdvBill.Rows[intCurRwAmt];
        Label lblOldAmtAss = (Label)gdr.FindControl("lblOldAmt");
        TextBox txtAmtAss = (TextBox)gdr.FindControl("txtAmt");
        Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");

        if (Convert.ToDouble(txtAmtAss.Text) != Convert.ToDouble(lblOldAmtAss.Text))
        {
            lblEditModeAss.Text = "1";
        }
        else
        {
            lblEditModeAss.Text = "0";
        }
        gblObj.SetFooterTotalsTempField(gdvBill, 4, "txtAmt", 1);
        //lblTotAmt.Text = gdvBill.FooterRow.Cells[4].Text.ToString();
    }
    protected void chkUp_CheckedChanged(object sender, EventArgs e)
    {
        int intCurRwUnIdn = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
        GridViewRow gdr = gdvBill.Rows[intCurRwUnIdn];
        CheckBox chkUpAss = (CheckBox)gdr.FindControl("chkUp");
        DropDownList ddlRsnAss = (DropDownList)gdr.FindControl("ddlRsn");
        if (chkUpAss.Checked == true)
        {
            ddlRsnAss.Enabled = true;
        }
        else
        {
            ddlRsnAss.Enabled = false;
        }

    }
    protected void txtDtSanction_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        //int intCurRwDt1 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        //GridViewRow gdr = gdvBill.Rows[intCurRwDt1];
        //TextBox txtDtSanctionAss = (TextBox)gdr.FindControl("txtDtSanction");
        //Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");
        //if (gblObj.isValidDate(txtDtSanctionAss, this) == false)
        //{
        //    gblObj.MsgBoxOk("Invalid Date!", this);
        //    txtDtSanctionAss.Text = "";
        //}
        //lblEditModeAss.Text = "1";

        int intCurRwDt1 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        GridViewRow gdr = gdvBill.Rows[intCurRwDt1];
        TextBox txtDtSanctionAss = (TextBox)gdr.FindControl("txtDtSanction");
        Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");
        if (gblObj.isValidDate(txtDtSanctionAss, this) == false)
        {
            gblObj.MsgBoxOk("Invalid Date!", this);
            txtDtSanctionAss.Text = "";
        }
        else
        {
            if (gblObj.CheckChalanDate(txtDtSanctionAss, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue)) == true)
            {
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtDtSanctionAss.Text = "";
            }
        }
        lblEditModeAss.Text = "1";

    }
    //protected void txtChalDt_TextChanged(object sender, EventArgs e)
    //{
    //    clsGlobalMethods gblobj = new clsGlobalMethods();
    //    DateTime dtm = new DateTime();
    //    if (txtBillDt.Text != "")
    //    {
    //        if (gblobj.isValidDate(txtBillDt, this) == true)
    //        {
    //            if (gblobj.CheckChalanDate(txtBillDt, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMnth.SelectedValue)) == true)
    //            {
    //            }
    //            else
    //            {
    //                gblobj.MsgBoxOk("Invalid Date", this);
    //                txtBillDt.Text = "";
    //            }
    //        }
    //        else
    //        {
    //            gblobj.MsgBoxOk("Invalid Date", this);
    //            txtBillDt.Text = "";
    //        }
    //    }
    //    mdlConfirm.Show();
    //}
    protected void txtDtWith_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        int intCurRwDt2 = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

        GridViewRow gdr = gdvBill.Rows[intCurRwDt2];
        TextBox txtDtWithAss = (TextBox)gdr.FindControl("txtDtWith");
        Label lblEditModeAss = (Label)gdr.FindControl("lblEditMode");
        if (gblObj.isValidDate(txtDtWithAss, this) == false)
        {
            gblObj.MsgBoxOk("Invalid Date!", this);
            txtDtWithAss.Text = "";
        }
        lblEditModeAss.Text = "1";
    }


    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        aoRecorr = new AORecorrection();
        aoRecorrDAO = new AORecorrectionDAO();
        wthd = new WithdrawalPDEDAO();

        if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlType");
            arDdl.Add("ddlRsn");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            DataSet dsl = new DataSet();
            dsl = wthd.GetLoanType();

            DataSet dsR1 = new DataSet();
            ArrayList ar1 = new ArrayList();
            ar1.Add(1);                      //1 - UnPosted Reason
            dsR1 = genDAO.getReason(ar1);


            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dsl);
            arDdlDs.Add(dsR1);
            ////Store Ds to fill Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsApp = new DataSet();         
            aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdBillEdit"]);
            aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdBillEdit"]);
            aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdBillEdit"]);
         
            dsApp = aoRecorrDAO.SelectApprovalPDELnk1WithCNT(aoRecorr);
            ////Ds to fill Grid//////////
            //DataSet dsAppFlg = new DataSet();      
            //aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdBillEdit"]);
            //aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdBillEdit"]);
            //aoRecorr.IntDistID = Convert.ToInt16(Session["intDistIdBillEdit"]);
            //dsAppFlg = aoRecorrDAO.SelectApprovalPDEWithFlg(aoRecorr);
            //SetGridStatus(dsAppFlg);

            gblObj.SetGridRowsWithData(dsApp, Convert.ToInt16(txtCnt.Text), gdvBill, arDdl, arCols, arDdlDs);
            FillFooterTotals();
        }
        else
        {
            gblObj.SetRowsCnt(gdvBill, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("lblSlNo");
        arCols.Add("txtAccNo");
        arCols.Add("lblName");
        arCols.Add("chkUnIdnt");
        arCols.Add("txtAmt");
        arCols.Add("ddlType");
        arCols.Add("txtSanction");
        
        arCols.Add("txtDtSanction");
        arCols.Add("txtDtWith");
        arCols.Add("txtCons");
        arCols.Add("txtInstNo");
        arCols.Add("txtInstAmt");
        arCols.Add("lblWithId");
        arCols.Add("lblCorrId");
        arCols.Add("lblAccNo");
        arCols.Add("lblNewAccNo");
        arCols.Add("lblEditMode");
        arCols.Add("lblOldAmt");
        arCols.Add("chkUp");
        arCols.Add("ddlRsn");
        arCols.Add("chkDel");
     
    }
    private void FillFooterTotals()
    {
        gblObj = new clsGlobalMethods();

        gblObj.SetFooterTotalsTempField(gdvBill, 4, "txtAmt", 1);
    }
    protected void txtCons_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvBill.Rows[index];
        TextBox txtInstNo = (TextBox)gvr.FindControl("txtInstNo");
        TextBox txtInstAmt = (TextBox)gvr.FindControl("txtInstAmt");
        TextBox txtCons = (TextBox)gvr.FindControl("txtCons");
        Label lblEditMode = (Label)gvr.FindControl("lblEditMode");
        //if (Convert.ToInt16(txtInstNo.Text) > 36 || Convert.ToInt16(txtInstNo.Text) < 12)
        //{
        //    gblObj.MsgBoxOk("Invalid value.", this);
        //    txtInstNo.Text = "";
        //}
        //else
        //{
            if ((txtCons.Text.ToString() != "" && txtCons.Text.ToString() != "0") && (txtInstNo.Text.ToString() != "" && txtInstNo.Text.ToString() != "0"))
            {
                txtInstAmt.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtCons.Text) / Convert.ToInt16(txtInstNo.Text)));
                lblEditMode.Text = "1";
            }
        //}
    }
    protected void txtInstNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvBill.Rows[index];
        TextBox txtInstNo = (TextBox)gvr.FindControl("txtInstNo");
        TextBox txtInstAmt = (TextBox)gvr.FindControl("txtInstAmt");
        TextBox txtCons = (TextBox)gvr.FindControl("txtCons");
        Label lblEditMode = (Label)gvr.FindControl("lblEditMode");
        if (Convert.ToInt16(txtInstNo.Text) > 36 || Convert.ToInt16(txtInstNo.Text) < 12)
        {
            gblObj.MsgBoxOk("Invalid value.", this);
            txtInstNo.Text = "";
        }
        else
        {
            if ((txtCons.Text.ToString() != "" || txtCons.Text.ToString() != "0") && (txtInstNo.Text.ToString() != "" || txtInstNo.Text.ToString() != "0"))
            {
                txtInstAmt.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtCons.Text) / Convert.ToInt16(txtInstNo.Text)));
                lblEditMode.Text = "1";
            }
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        wthd = new WithdrawalPDEDAO();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblWithIdAss = (Label)gdvBill.Rows[rowIndex].FindControl("lblWithId");
        TextBox txtAmt = (TextBox)gdvBill.Rows[rowIndex].FindControl("txtAmt");
        Label lblAccNo = (Label)gdvBill.Rows[rowIndex].FindControl("lblAccNo");

        if (lblWithIdAss.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblWithIdAss.Text));
            try
            {
                wthd.UpdateVoucherMode(arrin);
                saveCorrectionEntry(rowIndex, Convert.ToInt64(lblWithIdAss.Text), 1);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }          
        }
        gblObj.MsgBoxOk("Row Deleted   !", this);
        FillGrid();
    }
    private void saveCorrectionEntry(int rw, float schedId, int intDel)
    {
        /////
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        //gFunFindPDEYearIdFromDate
        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        yr = Convert.ToInt16(Session["intYearIdBillEdit"]);
        mth = Convert.ToInt16(Session["intMonthIdBillEdit"]);
        intDy = 10;

        GridViewRow gvrow = gdvBill.Rows[rw];
        Label lblOTot = (Label)gvrow.FindControl("lblOldAmt");
        TextBox lblNewTot = (TextBox)gvrow.FindControl("txtAmt");
        Label lblOAcc = (Label)gvrow.FindControl("lblAccNo");
        Label lblNewAcc = (Label)gvrow.FindControl("lblNewAccNo");

        amtO = Convert.ToDouble(lblOTot.Text);
        amtN = Convert.ToDouble(lblNewTot.Text);
        accO = Convert.ToInt16(lblOAcc.Text);
        accN = Convert.ToInt16(lblNewAcc.Text);

        findCorrType(amtO, amtN, accO, accN, intDel);
        //findCorrAmt(amtO, amtN);
        if (corrType == 2)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    cor.IntAccNo = Convert.ToInt32(lblOAcc.Text);
                    amtCalc = amtN;
                    cor.FltAmountBefore = amtO;
                    cor.FltAmountAfter = 0;
                }
                else
                {
                    cor.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
                    amtCalc = -amtN;
                    cor.FltAmountBefore = 0;
                    cor.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                cor.IntYearID = yr;
                cor.IntMonthID = mth;
                cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                cor.FltCalcAmount = dblAmtAdjusted;
                cor.FlgCorrected = 1;      //Just added not incorporated in CCard
                cor.IntChalanId = Convert.ToInt64(Session["numChalanIdEdit"]);
                cor.IntSchedId = schedId;
                cor.FlgType = 2;           //Remittance
                cor.FltRoundingAmt = 0;
                cor.IntCorrectionType = corrType;
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
        }
        else
        {
            if (corrType == 4)
            {
                amtCalc = -amtN;
                cor.FltAmountBefore = 0;
                cor.FltAmountAfter = amtN;
            }
            else if (corrType == 5)
            {
                amtCalc = amtN;
                cor.FltAmountBefore = amtN;
                cor.FltAmountAfter = 0;
            }
            else
            {
                amtCalc = amtO - amtN;
                cor.FltAmountBefore = amtO;
                cor.FltAmountAfter = amtN;
            }
            double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
            ///// Save to CorrEntry/////////
            cor.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
            cor.IntYearID = yr;
            cor.IntMonthID = mth;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltCalcAmount = dblAmtAdjusted;
            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = Convert.ToInt64(Session["numChalanIdEdit"]);
            cor.IntSchedId = schedId;
            cor.FlgType = 2;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = corrType;
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
    }

    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        /////
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
    protected void txtAmtPrev_TextChanged(object sender, EventArgs e)
    {
        int intCurRwAmt = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvBill.Rows[intCurRwAmt];
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");
        TextBox txtAmtPrev = (TextBox)gvr.FindControl("txtAmtPrev");
        Label txtAmtPrevO = (Label)gvr.FindControl("txtAmtPrevO");
        if (Convert.ToDouble(txtAmtPrevO.Text) != Convert.ToDouble(txtAmtPrev.Text))
        {
            lblEditModeAss.Text = "1";
        }
        else
        {
            lblEditModeAss.Text = "0";
        }
    }
    protected void txtODtPrev_TextChanged(object sender, EventArgs e)
    {
        int intCurRwAmt = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvBill.Rows[intCurRwAmt];
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
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intCurRwAmt = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvBill.Rows[intCurRwAmt];
        DropDownList ddlType = (DropDownList)gvr.FindControl("ddlType");
        TextBox txtCons = (TextBox)gvr.FindControl("txtCons");
        TextBox txtInstNo = (TextBox)gvr.FindControl("txtInstNo");
        TextBox txtInstAmt = (TextBox)gvr.FindControl("txtInstAmt");
        if (Convert.ToInt16(ddlType.SelectedValue) > 0)
        {
            Session["tp"] = int.Parse(ddlType.SelectedValue.ToString());
        }
        else
        {
            Session["tp"] = 0;
        }
        if (Convert.ToInt16(Session["tp"]) == 1)
        {
            txtCons.Enabled = true;
            txtInstNo.Enabled = true;
            txtInstAmt.Enabled = true;
        }
        else
        {
            txtCons.Enabled = false;
            txtInstNo.Enabled = false;
            txtInstAmt.Enabled = false;
        }
    }
}
