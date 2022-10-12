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
using System.Data.SqlClient;
using KPEPFClassLibrary;

public partial class Contents_MonthlySubn : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO gen = new KPEPFGeneralDAO();
    Chalan chal = new Chalan();
    ChalanDAO chalDao = new ChalanDAO();
    Schedule sch = new Schedule();
    ScheduleMain SchMain = new ScheduleMain();
    ScheduleMainDAO SchMainDAO = new ScheduleMainDAO();
    ScheduleDAO schObj = new ScheduleDAO();
    MonthlySubnDAO mthDao = new MonthlySubnDAO();
    Approval app = new Approval();
    ApprovalDAO appDao = new ApprovalDAO();

    static float  chalanId = 0;
    static int ScheduleMainId = 0;
    static int treasuryId = 0;
    static int MnthId = 0;
    static int intBillTypeID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //pnlAmountmismatch.Visible = false;
            InitialSettings();
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //gblObj.SetAppFlagsInSession(ds);
            //if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            //{
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //}
            FillGridCombos();

            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                if (Convert.ToInt64(Request.QueryString["numChalanId"]) > 0)
                {
                    Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
                    gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
                    btnSec.Visible = true;
                    btnSec.Text = "Back to inbox";
                    btnSec.PostBackUrl = "~/Contents/InboxMonthlyTrn.aspx";
                    FillDet();
                    SetControls();
                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 5)        //Through View
            {
                //Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
                //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
                Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
                Session["IntFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
                btnSec.Visible = true;
                btnSec.Text = "Back to View";
                btnSec.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
                FillDet();
                SetControls();
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 10)        //Through Ann Statement
            {
                Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
                gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
                btnSec.Visible = true;
                btnSec.Text = "Back to Annual Statement";
                btnSec.PostBackUrl = "~/Contents/AnnStatement.aspx";
                FillDet();
                SetControls();
            }
        }
    }
    private void SetControls()
    {
        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();

        if (gblObj.IntAppFlgInbox == 1)
        {
            Session["IntFlgOrg"] = Convert.ToInt16(Session["intFlgAppInbx"]);
        }
        else if (gblObj.IntAppFlgInbox == 2)
        {
            Session["IntFlgOrg"] = Convert.ToInt16(Session["intFlgRejInbx"]);
        }
        else
        {
            //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
        }

        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        //arr.Add(Convert.ToInt16(Session["intTrnType"]));
        arr.Add(Convert.ToInt64(Session["NumChalanID"]));
        arr.Add(Convert.ToInt16(Session["IntFlgOrg"]));
        dsE = gen.GetEnableStatusChalan(arr);
        if (dsE.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsE.Tables[0].Rows[0].ItemArray[0]) == true)
            {
                if (Convert.ToInt16(Session["intLBID"]) == ChalanLBId())
                {
                    EnbleControls();
                }
                else
                {
                    DisableControls();
                }
            }
            else
            {
                DisableControls();
            }
        }
    }
    private double ChalanLBId()
    {
        double lb = 0;
        DataSet dsLB = new DataSet();
        ArrayList arrLB = new ArrayList();
        arrLB.Add(Convert.ToInt64(Session["NumChalanID"]));
        dsLB = chalDao.GetChalanFrmChalId(arrLB);
        if (dsLB.Tables[0].Rows.Count > 0)
        {
            lb = Convert.ToDouble(dsLB.Tables[0].Rows[0].ItemArray[10]);
        }
        return lb;
    }
    public void EnbleControls()
    {
        SetGridEnable();
        //txtChlAmt.ReadOnly = false ;
        txtChlDt.ReadOnly = false ;
        txtChlDt.Enabled = true ;
        txtChlNo.ReadOnly = false ;
        btnFinal.Enabled = true;
    }
    public void DisableControls()
    {
        SetGridDisable();
        //pnlChal.Enabled = false  ;
        txtChlAmt.ReadOnly = true;
        txtChlDt.ReadOnly = true;
        txtChlDt.Enabled = false;
        txtChlNo.ReadOnly = true;
        btnFinal.Enabled = false;
    }
    private void SetGridEnable()
    {
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvMonthlySubn.Rows[i];
            DropDownList ddlGoAss = (DropDownList)gdvrow.FindControl("ddlGo");
            if (Convert.ToInt64(gdvrow.Cells[6].Text) > 0)
            {
                ddlGoAss.Enabled = true;
            }
            else
            {
                ddlGoAss.Enabled = false;
            }
            CheckBox chkUpAss = (CheckBox)gdvrow.FindControl("chkUp");
            chkUpAss.Enabled = true;
            DropDownList ddlUpRsnAss = (DropDownList)gdvrow.FindControl("ddlUpRsn");
            ddlUpRsnAss.Enabled = true;
            TextBox txtRemAss = (TextBox)gdvrow.FindControl("txtRem");
            txtRemAss.ReadOnly = false;
        }
    }
    private void SetGridDisable()
    {
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvMonthlySubn.Rows[i];
            DropDownList ddlGoAss = (DropDownList)gdvrow.FindControl("ddlGo");
            ddlGoAss.Enabled = false;
            CheckBox chkUpAss = (CheckBox)gdvrow.FindControl("chkUp");
            chkUpAss.Enabled = false;
            DropDownList ddlUpRsnAss = (DropDownList)gdvrow.FindControl("ddlUpRsn");
            ddlUpRsnAss.Enabled = false;
            TextBox txtRemAss = (TextBox)gdvrow.FindControl("txtRem");
            txtRemAss.ReadOnly = true;
        }
    }
    private void FillDet()
    {
        ArrayList arrCh = new ArrayList();
        DataSet dsCh = new DataSet();
        arrCh.Add(Session["NumChalanID"]);
        dsCh = chalDao.GetChalanFrmChalId(arrCh);
        if (dsCh.Tables[0].Rows.Count > 0)
        {
            txtChlAmt.Text = dsCh.Tables[0].Rows[0].ItemArray[3].ToString();
            txtChlNo.Text = dsCh.Tables[0].Rows[0].ItemArray[1].ToString();
            txtChlDt.Text = dsCh.Tables[0].Rows[0].ItemArray[2].ToString();
            lblTreas.Text = dsCh.Tables[0].Rows[0].ItemArray[9].ToString();
        }

        DataSet dsSch = new DataSet();
        dsSch = schObj.CheckScheduleExist(arrCh);
        if (dsSch.Tables[0].Rows.Count > 0)
        {
            FillGrid(dsSch);
        }
        else
        {
            SetGridDefault();
        }

        ddlYear.SelectedValue = dsCh.Tables[0].Rows[0].ItemArray[6].ToString();
        ddlMonth.SelectedValue = dsCh.Tables[0].Rows[0].ItemArray[7].ToString();
        DataSet dsBillType = new DataSet();
        ArrayList arr = new ArrayList();
        int YrId = Convert.ToInt32(ddlYear.SelectedValue);
        int MnthId = Convert.ToInt32(ddlMonth.SelectedValue);

        arr.Add(Convert.ToInt32(Session["intLBID"]));
        arr.Add(YrId);
        arr.Add(MnthId);

        dsBillType = gen.GetBillType(arr);
        gblObj.FillCombo(ddlBillType, dsBillType, 1);
        
        ddlBillType.SelectedValue  = dsCh.Tables[0].Rows[0].ItemArray[8].ToString();
    }
    private void FillGridCombos()
    {

    }
    private void InitialSettings()
    {
        SetGridDefault();
        DataSet dsY = new DataSet();
        dsY = gen.GetYearOnLine();
        gblObj.FillCombo(ddlYear , dsY, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        gblObj.FillCombo(ddlMonth, dsM, 1);
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("fltSubnAmt");
        ar.Add("fltRePaymentAmt");
        ar.Add("fltArearPFAmt");
        ar.Add("fltArearDA");
        ar.Add("fltArearPay");
        ar.Add("TotRem");

        gblObj.SetGridDefault(gdvMonthlySubn, ar);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["intYearIdMs"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearIdMs"] = 0;
        }
        SetGridDefault();
    }
    private Boolean ChalanExists(int YrId, int MthId,int intBillID)
    {
        Boolean chal = true;
        DataSet dsChkChal = new DataSet();
        ArrayList arrChal = new ArrayList();
    
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            arrChal.Add(YrId);
            arrChal.Add(MthId);
            arrChal.Add(intBillID);
            arrChal.Add(Convert.ToInt32(Session["intLBID"]));
            dsChkChal = chalDao.ChalanExists(arrChal);
            if (dsChkChal.Tables[0].Rows.Count > 0)
            {
                chal = true;
                txtChlAmt.Text = dsChkChal.Tables[0].Rows[0].ItemArray[5].ToString();
                txtChlNo.Text = dsChkChal.Tables[0].Rows[0].ItemArray[3].ToString();
                txtChlDt.Text = dsChkChal.Tables[0].Rows[0].ItemArray[4].ToString();
                Session["NumChalanID"] = Convert.ToInt64(dsChkChal.Tables[0].Rows[0].ItemArray[0].ToString());
                Session["IntFlgOrg"] = Convert.ToInt32(dsChkChal.Tables[0].Rows[0].ItemArray[8]);
            }
            else
            {
                ClearChalDet();
                chal = false;
            }
        }
        else
        {
            chal = false;
        }
        return chal;
    }
   
    private void FillFrmMonthlyTrn(int  intYearID, int intMonthID,int intBillTypeID)
    {
        DataSet dsMTrn = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["intLBID"]));
        arr.Add(intYearID);
        arr.Add(intMonthID);
        arr.Add(intBillTypeID);
        dsMTrn = mthDao.FillMonthTrn(arr);
        if (dsMTrn.Tables[0].Rows.Count > 0)
        {
            FillGrid(dsMTrn);
            lblTreas.Text = Session["strTreasury"].ToString();
            treasuryId = Convert.ToInt32(dsMTrn.Tables[0].Rows[0].ItemArray[12]);
            
        }
        else
        {
            SetGridDefault();
            ClearChalDet();
            gblObj.MsgBoxOk("Chalan not generated!",this);
        }
    }
    private void ClearChalDet()
    {
        txtChlAmt.Text = "";
        txtChlNo.Text = "";
        txtChlDt.Text = "";
        lblTreas.Text = "";
    }
    private void FillGrid(DataSet dsChkSched)
    {
        gdvMonthlySubn.DataSource = dsChkSched;
        gdvMonthlySubn.DataBind();
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gdv = gdvMonthlySubn.Rows[i];
            DropDownList GO = (DropDownList)gdv.Cells[9].FindControl("ddlGo");

            DataSet ds1 = gen.GetGO();
            gblObj.FillCombo(GO, ds1, 1);
            GO.SelectedValue = dsChkSched.Tables[0].Rows[i].ItemArray[10].ToString();

            Label lblEmpIdAss = (Label)gdv.FindControl("lblEmpId");
            lblEmpIdAss.Text = dsChkSched.Tables[0].Rows[i].ItemArray[0].ToString();

            TextBox txtRemAss = (TextBox)gdv.FindControl("txtRem");
            txtRemAss.Text = dsChkSched.Tables[0].Rows[i].ItemArray[15].ToString();

            DropDownList ddlUpRsnAss = (DropDownList)gdv.Cells[9].FindControl("ddlUpRsn");
            ArrayList ar = new ArrayList();
            ar.Add(1);
            DataSet dsR = gen.getReason(ar);
            gblObj.FillCombo(ddlUpRsnAss, dsR, 1);
            ddlUpRsnAss.SelectedValue = dsChkSched.Tables[0].Rows[i].ItemArray[9].ToString();
        }
        //gblObj.SetFooterTotals(gdvMonthlySubn, 3);
        //gblObj.SetFooterTotals(gdvMonthlySubn, 4);
        //gblObj.SetFooterTotals(gdvMonthlySubn, 5);
        //gblObj.SetFooterTotals(gdvMonthlySubn, 6);
        //gblObj.SetFooterTotals(gdvMonthlySubn, 7);
        //gblObj.SetFooterTotals(gdvMonthlySubn, 9);
        gblObj.SetFooterTotalsMltpl(gdvMonthlySubn, 3, 7);
        gblObj.SetFooterTotals(gdvMonthlySubn, 9);
        txtChlAmt.Text = gdvMonthlySubn.FooterRow.Cells[9].Text.ToString();
    }
    private int FindOrderByMonth(int Mn)
    {
        int M = 0;
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(Mn);
        ds = gen.CheckMonth(ArrIn);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            M = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
        return M;
    }
    protected void txtArrPayAmt_TextChanged(Object sender, EventArgs e)
    {

    }
    protected void ddlTreasury_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnFinal_Click(object sender, EventArgs e)
    {
        if (ValidateFields() == true)
        {
            if (Convert.ToDouble(txtChlAmt.Text.Trim()) != Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[9].Text))
            {
                DisableControls();
                pnlAmountmismatch.Visible = true;
            }
            else
            {
                SaveChalan();
                SaveSchedule();
                if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
                {
                    gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["NumChalanID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]),"");
                }
                btnPrint.Enabled = true;
                EnbleControls();
                gblObj.MsgBoxOk("Saved successfully",this);
            }
        }
    }
    private void SaveSchedule()
    {
        for (int count = 0; count < gdvMonthlySubn.Rows.Count; count++)
        {

            GridViewRow gdvSchdRw = gdvMonthlySubn.Rows[count];
            Label lblEmpIdAssgn = (Label)gdvSchdRw.FindControl("lblEmpId");
            DropDownList ddlGoAss = (DropDownList)gdvSchdRw.FindControl("ddlGo");
            CheckBox chkUpAss = (CheckBox)gdvSchdRw.FindControl("chkUp");
            DropDownList ddlUpRsnAss = (DropDownList)gdvSchdRw.FindControl("ddlUpRsn");
            TextBox txtRemAss = (TextBox)gdvSchdRw.FindControl("txtRem");

            sch.NumChalanID = Convert.ToDouble(Session["NumChalanID"]); //chalanId;//ChalanID;
            //scheduleObj.NumEmpID = Convert.ToDouble(gdvMonthlySubn.Rows[cnt].Cells[0].Text);
            if (lblEmpIdAssgn.Text == "")
            {
                sch.NumEmpID = 0;
            }
            else
            {
                sch.NumEmpID = float.Parse(lblEmpIdAssgn.Text);
            }
            if (gdvMonthlySubn.Rows[count].Cells[3].Text == "")
            {
                sch.FltSubnAmt = 0;
            }
            else
            {
                sch.FltSubnAmt = Convert.ToDouble(gdvMonthlySubn.Rows[count].Cells[3].Text);
            }
            if (gdvMonthlySubn.Rows[count].Cells[4].Text == "")
            {
                sch.FltRePaymentAmt = 0;
            }
            else
            {
                sch.FltRePaymentAmt = Convert.ToDouble(gdvMonthlySubn.Rows[count].Cells[4].Text);
            }
            if (gdvMonthlySubn.Rows[count].Cells[5].Text == "")
            {
                sch.FltArearPFAmt = 0;
            }
            else
            {
                sch.FltArearPFAmt = Convert.ToDouble(gdvMonthlySubn.Rows[count].Cells[5].Text);
            }
            if (gdvMonthlySubn.Rows[count].Cells[6].Text == "")
            {
                sch.FltArearDA = 0;
            }
            else
            {
                sch.FltArearDA = Convert.ToDouble(gdvMonthlySubn.Rows[count].Cells[6].Text);
            }
            if (gdvMonthlySubn.Rows[count].Cells[7].Text == "")
            {
                sch.FltArearPay = 0;
            }
            else
            {
                sch.FltArearPay = Convert.ToDouble(gdvMonthlySubn.Rows[count].Cells[7].Text);
            }
            if (gdvMonthlySubn.Rows[count].Cells[9].Text == "")
            {
                sch.FltTotal = 0;
            }
            else
            {
                sch.FltTotal = Convert.ToDouble(gdvMonthlySubn.Rows[count].Cells[9].Text);
            }
            //scheduleObj.IntGOId = Convert.ToInt16(gdvMonthlySubn.Rows[cnt].Cells[10].Text); //Convert.ToInt32(GO.SelectedValue);
            if (ddlGoAss.SelectedValue == "")
            {
                sch.IntGOId = 0;
            }
            else
            {
                sch.IntGOId = int.Parse(ddlGoAss.Text);
            }
            sch.IntNoOfInst = 1;
            if (chkUpAss.Checked == true)
            {
                sch.FlgUnPosted = 1;
            }
            else
            {
                sch.FlgUnPosted = 0;
            }
            if (ddlUpRsnAss.SelectedValue == "")
            {
                sch.IntUnPostedRsn = 0;
            }
            else
            {
                sch.IntUnPostedRsn = Convert.ToInt16(ddlUpRsnAss.SelectedValue.ToString());
            }
            sch.IntModeChange = 1;
            if (txtRemAss.Text == "")
            {
                sch.ChvRem = "";
            }
            else
            {
                sch.ChvRem = txtRemAss.Text;
            }
            schObj.SaveSchedule(sch);
        }
    }
    private void SaveChalan()
    {
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(txtChlDt.Text.ToString());

        chal.NumChalanId = Convert.ToInt64(Session["NumChalanID"]);//ChalanID;
        chal.IntTreasuryId = Convert.ToInt32(Session["intTreasuryID"]);
        chal.IntLBId = Convert.ToInt32(Session["intLBID"]);
        chal.IntChalanNo = Convert.ToInt32(txtChlNo.Text);
        chal.DtChalanDate = txtChlDt.Text.ToString();
        chal.FltChalanAmt = Convert.ToDecimal(txtChlAmt.Text);
        chal.YearId = gen.gFunFindYearIdFromDate(ar);
        chal.MonthId = Convert.ToDateTime(txtChlDt.Text).Month;
        chal.PerYearId = Convert.ToInt32(ddlYear.SelectedValue);
        chal.PerMonthId = Convert.ToInt32(ddlMonth.SelectedValue);
        chal.ChvRemarks = "";
        chal.IntUserId = Convert.ToInt32(Session["intUserId"]);
        chal.FlgUnposted = 1;
        //chal.DtmDDTreasury = "";
        //chal.IntUnPostedRsn = 0;
        //chal.IntModeChange = 1;
        //chal.ChvBankName = "";
        //chal.IntSlNo = FindSlNo(chal.YearId, chal.PerMonthId, chal.IntLBId);
        chal.IntSlNo = Convert.ToInt16(Session["intBillIdMs"]);
        chal.FlgSource = 1;
        chal.IntDay = Convert.ToDateTime(txtChlDt.Text).Day;
        chal.IntSthapnaBillID = Convert.ToInt32(ddlBillType.SelectedValue);
        if (Convert.ToDouble(txtChlAmt.Text.Trim()) == Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[9].Text))
        {
            chal.FlgAmtMismatch = 1;
        }
        else
        {
            chal.FlgAmtMismatch = 2;
        }
        chal.FlgChalanType = 1;
        chal.tENo = 0;
        chal.IntTreasuryDAGID = 0;
        ds = chalDao.CreateChalan(chal);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
            Session["NumChalanID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
        }
    }
    //private void Approval(int flgApp)
    //{
    //    app.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
    //    app.NumTrnID = chalanId;
    //    app.FlgApproval = flgApp;
    //    app.IntUserID = Convert.ToInt32(Session["intUserId"]);
    //    appDao.CreateApproval(app);
    //}
    //public void GenerateChalan()
    //{
    //    DataSet ds = new DataSet();
    //    chal.NumChalanId = chalanId;//ChalanID;
    //    chal.IntTreasuryId = Convert.ToInt32(Session["intTreasuryID"]);
    //    chal.IntLBId = Convert.ToInt32(Session["intLBID"]);
    //    chal.IntChalanNo = Convert.ToInt32(txtChlNo.Text);
    //    chal.DtChalanDate = txtChlDt.Text.ToString();
    //    chal.FltChalanAmt = Convert.ToDecimal(txtChlAmt.Text);
    //    chal.PerYearId = Convert.ToInt32(ddlYear.SelectedValue);
    //    chal.PerMonthId = Convert.ToInt32(ddlMonth.SelectedValue);
    //    chal.ChvRemarks = "";
    //    chal.IntUserId = Convert.ToInt32(Session["UserId"]);
    //    chal.FlgUnposted = 1;
    //    chal.DtmDDTreasury = "";
    //    chal.IntUnPostedRsn = 0;
    //    chal.IntModeChange = 1;
    //    //chal.IntSlNo = 1;
    //    chal.IntSlNo = FindSlNo();
    //    ds = chalDao.CreateChalan(chal);
    //    if (ds.Tables[0].Rows.Count >= 1)
    //    {
    //        chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    //UpdateChalan(Convert.ToDecimal(txtChalanId.Text));
    //}
    //private int FindSlNo(int yr,int mth,int lb)
    //{
    //    int slno = 1;
    //    //DataSet ds = new DataSet();
    //    //ArrayList ar = new ArrayList();
    //    //ar.Add(yr);
    //    //ar.Add(mth);
    //    //ar.Add(lb);
    //    //ar.Add(Convert.ToInt16(Session["intBillIdMs"]));

    //    return slno;
    //}
    public void GenerateSchedule()
    {
    }

    public void GenerateChalanTRN()
    {

        ArrayList arr = new ArrayList();
        arr.Add(DBNull.Value);
        arr.Add(1);
        arr.Add(DBNull.Value);
        arr.Add(Convert.ToInt32(Session["intTreasuryID"]));
        arr.Add(Convert.ToInt32(Session["intLBID"]));
        arr.Add(txtChlNo.Text);
        arr.Add(txtChlDt.Text);
        arr.Add(txtChlAmt.Text);
        arr.Add(Convert.ToInt32(ddlMonth.SelectedValue));
        arr.Add(Convert.ToInt32(ddlMonth.SelectedValue));
        arr.Add(DBNull.Value);
        arr.Add(DBNull.Value);
        arr.Add(Convert.ToInt32(ddlYear.SelectedValue));
        arr.Add(1);
        arr.Add(Convert.ToInt32(Session["UserId"]));

        arr.Add(DBNull.Value);
        arr.Add(DBNull.Value);
        arr.Add(DBNull.Value);
        arr.Add(DBNull.Value);

        KPEPFGeneralDAO kpepf = new KPEPFGeneralDAO();
       //DataSet ds = kpepf.InsChalanTRN(arr);

        
    }
    public bool ValidateFields()
    {
        bool Valid;
        Valid = true;
        if (Convert.ToDouble(txtChlAmt.Text.Trim()) == 0)
        {
            gblObj.MsgBoxOk("Please enter the Chalan amount.",this);
            Valid = false;
        }
        else if (txtChlDt.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Please enter the Chalan date", this);
            Valid = false;
        }

        else if (Convert.ToDateTime(txtChlDt.Text) > Convert.ToDateTime(DateTime.Now.Date))
        {
            gblObj.MsgBoxOk("Schedule date should be less than system date", this);
            Valid = false;
        }
        else if (txtChlNo.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Please enter Chalan no.", this);
            Valid = false;
        }
        else if (CheckChalDate() == false)    //Check chal date must b after year and month combo
        {
            gblObj.MsgBoxOk("Invalid Chalan date!", this);
            Valid = false;
        }
        else
        {
            Valid = true;
        }
        return Valid;
    }
    private Boolean CheckChalDate()
    {
        ArrayList ar = new ArrayList();
        Boolean flg = true;
        int intYr, intMth, intYrC, intMthC;
        intYr = Convert.ToInt16(ddlYear.SelectedItem.Value);
        intMth = Convert.ToInt16(ddlMonth.SelectedItem.Value);
        //intYrC = Convert.ToDateTime(txtChlDt.Text).Year;
        ar.Add(txtChlDt.Text.ToString());
        intYrC = gen.gFunFindYearIdFromDate(ar);
        intMthC = Convert.ToDateTime(txtChlDt.Text).Month;
        if (intYrC < intYr)
        {
            flg = false;
        }
        else
        {
            if (intMth >= 4)
            {
                if (intMthC < intMth)
                {
                    flg = false;
                }
                else
                {
                    flg = true;
                }
            }
            else if (intMth < 4)
            {
                if (intMthC > intMth)
                {
                    flg = false;
                }
                else
                {
                    flg = true;
                }
            }
        }
        return flg;
    }
    protected void chkUp_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["intMonthIdMs"] = Convert.ToInt16(ddlMonth.SelectedValue);
            gblObj.CheckValidMonthDdl(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), this, ddlBillType, btnFinal);

            DataSet dsBillType = new DataSet();
            ArrayList arr = new ArrayList();
            //int YrId = Convert.ToInt32(ddlYear.SelectedValue);
            //int MnthId = Convert.ToInt32(ddlMonth.SelectedValue);
            arr.Add(Convert.ToInt32(Session["intLBID"]));
            arr.Add(Convert.ToInt32(Session["intYearIdMs"]));
            arr.Add(Convert.ToInt32(Session["intMonthIdMs"]));
            dsBillType = gen.GetBillType(arr);
            gblObj.FillCombo(ddlBillType, dsBillType, 1);
        }
        else
        {
            Session["intMonthIdMs"] = 0;
        }
        
        SetGridDefault();
    }
    protected void ddlBillType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlBillType.SelectedValue) > 0)
        {
            Session["intBillIdMs"] = Convert.ToInt16(ddlBillType.SelectedValue);
            if (ChalanExists(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), Convert.ToInt16(Session["intBillIdMs"])) == true)
            {
                FillFrmMonthlyTrn(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), Convert.ToInt16(Session["intBillIdMs"]));
                if (Convert.ToInt16(Session["IntFlgOrg"]) == 0)
                {
                    EnbleControls();
                    gblObj.MsgBoxOk("Already generated", this);
                }
                else
                {
                    DisableControls();
                    gblObj.MsgBoxOk("Already Forwarded", this);
                }
            }
            else
            {
                Session["NumChalanID"] = 0;
                if (MatchEmployees() == true)
                {
                    FillFrmMonthlyTrn(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), Convert.ToInt16(Session["intBillIdMs"]));
                    EnbleControls();
                }
                else
                {
                    FillFrmMonthlyTrn(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), Convert.ToInt16(Session["intBillIdMs"]));
                    gblObj.MsgBoxOk("Set employees in LB", this);
                    EnbleControls();
                }
            }
        }
        else
        {
            Session["intBillIdMs"] = 0;
        }
    }
    private Boolean MatchEmployees()
    {
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(ddlYear.SelectedValue));
        ar.Add(Convert.ToInt16(ddlMonth.SelectedValue));
        ar.Add(Convert.ToInt32(Session["intLBID"]));
        ar.Add(Convert.ToInt16(ddlBillType.SelectedValue));
        DataSet dsMatch = new DataSet();
        dsMatch = mthDao.MatchEmp(ar);
        if (dsMatch.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsMatch.Tables[0].Rows[0].ItemArray[0]) == 0)
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["NumChalanID"] = Convert.ToInt16(Session["NumChalanID"]);
        Response.Redirect("Reportviewer.aspx?ReportID=3");
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        SaveChalan();
        SaveSchedule();
        if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
        {
            gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["NumChalanID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]),"");
        }
        btnPrint.Enabled = true;
        pnlAmountmismatch.Visible = false;
        EnbleControls();
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        pnlAmountmismatch.Visible = false;
        EnbleControls();
    }
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
}
