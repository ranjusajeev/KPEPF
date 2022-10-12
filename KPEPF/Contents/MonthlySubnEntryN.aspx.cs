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

public partial class Contents_MonthlySubnEntryN : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO gen = new KPEPFGeneralDAO();
    Chalan chal = new Chalan();
    ChalanDAO chalDao = new ChalanDAO();
    Schedule sch = new Schedule();
    ScheduleDAO schObj = new ScheduleDAO();
    Employee emp = new Employee();
    EmployeeDAO empD = new EmployeeDAO();
    Approval approvalObj = new Approval();
    ApprovalDAO approvalDAOObj = new ApprovalDAO();

    static float chalanId = 0;
    static int ScheduleMainId = 0;
    static int treasuryId = 0;
    static int MnthId = 0;
    static int intBillTypeID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));

            if (Convert.ToInt16(Session["intMenuItem"]) == 6)         //Through Inbox
            {
                if (Convert.ToInt64(Request.QueryString["numChalanId"]) > 0)
                {
                    Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
                    Session["IntFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
                    btnSec.Visible = true;
                    btnSec.Text = "Back to inbox";
                    btnSec.PostBackUrl = "~/Contents/InboxMonthlyTrn.aspx";
                    FillChalanTxts(2);
                    FillGridChalanIDWise();
                    FillSchedule(2);
                    SetControls();

                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 3)         //Data entry
            {
                {
                    Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
                    Session["IntFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
                    btnSec.Visible = false;
                    FillChalanTxts(2);
                    FillGridChalan();
                    FillSchedule(2);
                    SetControls();
                }
            }
            SetAddNewBtns();
            //else 
            //    {
            //        Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
            //        Session["IntFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
            //        btnSec.Visible = false;
            //        FillDet();
            //        SetControls();
            //    }
            //}
            //else if (Convert.ToInt16(Session["intMenuItem"]) == 5)        //Through View
            //{
            //    Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
            //    Session["IntFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
            //    btnSec.Visible = true;
            //    btnSec.Text = "Back to View";
            //    btnSec.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
            //    FillDet();
            //    SetControls();
            //}
            //else if (Convert.ToInt16(Session["intMenuItem"]) == 10)        //Through Ann Statement
            //{
            //    Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
            //    gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
            //    btnSec.Visible = true;
            //    btnSec.Text = "Back to Annual Statement";
            //    btnSec.PostBackUrl = "~/Contents/AnnStatement.aspx";
            //    FillDet();
            //    SetControls();
            //}
        }
    }
    private void SetAddNewBtns()
    {
        if (Convert.ToInt16(Session["intMenuItem"]) == 6)         //Through Inbox
        {
            btnAdd.Enabled = false;
            btnNew.Enabled = false;
            ddlYear.Enabled = false;
            ddlMonth.Enabled = false;
        }
        else
        {
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
        }
    }
    private void FillChalanTxts(int intFirst)
    {
        ArrayList ar = new ArrayList();
        DataSet dsCh = new DataSet();
        if (intFirst == 1)
        {
            ar.Add(Convert.ToDouble(Session["NumChalanIDFirst"]));
        }
        else
        {
            ar.Add(Convert.ToDouble(Session["NumChalanID"]));
        }
        dsCh = chalDao.GetChalanFrmChalId(ar);
        if (dsCh.Tables[0].Rows.Count > 0)
        {
            txtChlNo.Text = dsCh.Tables[0].Rows[0].ItemArray[1].ToString();
            txtChlDt.Text = dsCh.Tables[0].Rows[0].ItemArray[2].ToString();
            txtChlAmt.Text = dsCh.Tables[0].Rows[0].ItemArray[3].ToString();
            ddlYear.SelectedValue = dsCh.Tables[0].Rows[0].ItemArray[6].ToString();
            ddlMonth.SelectedValue = dsCh.Tables[0].Rows[0].ItemArray[7].ToString();
            lblTreas.Text = dsCh.Tables[0].Rows[0].ItemArray[9].ToString();
            Session["NumChalanID"] = Convert.ToDouble(dsCh.Tables[0].Rows[0].ItemArray[4].ToString());
        }
    }
    private void FillSchedule(int intFirst)
    {
        SetGridDefaultSch();
        ArrayList arrCh = new ArrayList();
        DataSet dsSch = new DataSet();
        if (intFirst == 1)
        {
            arrCh.Add(Session["NumChalanIDFirst"]);
        }
        else
        {
            arrCh.Add(Session["NumChalanID"]);
        }
        dsSch = schObj.CheckScheduleExist(arrCh);
        if (dsSch.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsSch.Tables[0].Rows.Count.ToString();
            gdvMonthlySubn.DataSource = dsSch;
            gdvMonthlySubn.DataBind();
            for (int i = 0; i < dsSch.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvMonthlySubn.Rows[i];

                TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
                txtAccNoAss.Text = dsSch.Tables[0].Rows[i].ItemArray[0].ToString();

                Label lblNameAss = (Label)gdv.FindControl("lblName");
                lblNameAss.Text = dsSch.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
                txtSubnAss.Text = dsSch.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
                txtRepAss.Text = dsSch.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtArr1Ass = (TextBox)gdv.FindControl("txtArr1");
                txtArr1Ass.Text = dsSch.Tables[0].Rows[i].ItemArray[4].ToString();
                TextBox txtArr2Ass = (TextBox)gdv.FindControl("txtArr2");
                txtArr2Ass.Text = dsSch.Tables[0].Rows[i].ItemArray[5].ToString();
                TextBox txtArr3Ass = (TextBox)gdv.FindControl("txtArr3");
                txtArr3Ass.Text = dsSch.Tables[0].Rows[i].ItemArray[6].ToString();

                Label lblTotAss = (Label)gdv.FindControl("lblTot");
                lblTotAss.Text = dsSch.Tables[0].Rows[i].ItemArray[7].ToString();

                DropDownList ddlGoAss = (DropDownList)gdv.FindControl("ddlGo");
                DataSet ds1 = gen.GetGO();
                gblObj.FillCombo(ddlGoAss, ds1, 1);

                ddlGoAss.SelectedValue = dsSch.Tables[0].Rows[i].ItemArray[8].ToString();

                CheckBox chkUpAss = (CheckBox)gdv.FindControl("chkUp");
                if (Convert.ToInt16(dsSch.Tables[0].Rows[i].ItemArray[9]) == 1)
                {
                    chkUpAss.Checked = true;
                }
                else
                {
                    chkUpAss.Checked = false;
                }

                DropDownList ddlUpRsnAss = (DropDownList)gdv.FindControl("ddlUpRsn");
                ddlUpRsnAss.SelectedValue = dsSch.Tables[0].Rows[i].ItemArray[10].ToString();

                TextBox txtRemAss = (TextBox)gdv.FindControl("txtRem");
                txtRemAss.Text = dsSch.Tables[0].Rows[i].ItemArray[11].ToString();

                Label lblEmpIdAss = (Label)gdv.FindControl("lblEmpId");
                lblEmpIdAss.Text = dsSch.Tables[0].Rows[i].ItemArray[12].ToString();

                Label lblSched = (Label)gdv.FindControl("lblSched");
                lblSched.Text = dsSch.Tables[0].Rows[i].ItemArray[14].ToString();

            }
            ArrayList ar = new ArrayList();
            ar.Add("txtSubn");
            ar.Add("txtRep");
            ar.Add("txtArr1");
            ar.Add("txtArr2");
            ar.Add("txtArr3");

            gblObj.SetFooterTotalsTempFieldMltpl(gdvMonthlySubn, 3, 7, ar, 1);
            gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 8, "lblTot", 2);
            txtHddn.Text = gdvMonthlySubn.FooterRow.Cells[8].Text.ToString();
        }
        else
        {
            SetGridDefaultSch();
            txtCnt.Text = "1";
            txtHddn.Text = "0";
        }
    }
    private void InitialSettings()
    {
        SetGridDefaultChalan();
        SetGridDefaultSch();
        DataSet dsY = new DataSet();
        dsY = gen.GetYearOnLine();
        gblObj.FillCombo(ddlYear, dsY, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        gblObj.FillCombo(ddlMonth, dsM, 1);

        SetGridDefaultChalan();
        SetGridDefaultSch();

        //FillGridGo();
    }
    private void FillGridGo()
    {

        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gdv = gdvMonthlySubn.Rows[i];
            DropDownList ddlGoAss = (DropDownList)gdv.FindControl("ddlGo");
            DataSet ds1 = gen.GetGO();
            gblObj.FillCombo(ddlGoAss, ds1, 1);
        }
    }
    private void SetControls()
    {
        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();

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
        txtChlDt.ReadOnly = false;
        txtChlDt.Enabled = true;
        txtChlNo.ReadOnly = false;
        btnFinal.Enabled = true;
        txtChlAmt.ReadOnly = false;
        txtCnt.Enabled = true;
    }
    public void DisableControls()
    {
        SetGridDisable();
        txtChlAmt.ReadOnly = true;
        txtChlDt.ReadOnly = true;
        txtChlDt.Enabled = false;
        txtChlNo.ReadOnly = true;
        btnFinal.Enabled = false;
        txtCnt.Enabled = false;
    }
    private void SetGridEnable()
    {
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvMonthlySubn.Rows[i];
            DropDownList ddlGoAss = (DropDownList)gdvrow.FindControl("ddlGo");
            //if (Convert.ToInt64(gdvrow.Cells[6].Text) > 0)
            //{
            ddlGoAss.Enabled = true;
            //}
            //else
            //{
            //    ddlGoAss.Enabled = false;
            //}
            CheckBox chkUpAss = (CheckBox)gdvrow.FindControl("chkUp");
            chkUpAss.Enabled = true;
            DropDownList ddlUpRsnAss = (DropDownList)gdvrow.FindControl("ddlUpRsn");
            ddlUpRsnAss.Enabled = true;
            TextBox txtRemAss = (TextBox)gdvrow.FindControl("txtRem");
            txtRemAss.ReadOnly = false;

            TextBox txtAccNo = (TextBox)gdvrow.FindControl("txtAccNo");
            txtAccNo.ReadOnly = false;
            TextBox txtSubn = (TextBox)gdvrow.FindControl("txtSubn");
            txtSubn.ReadOnly = false;
            TextBox txtRep = (TextBox)gdvrow.FindControl("txtRep");
            txtRep.ReadOnly = false;
            TextBox txtArr1 = (TextBox)gdvrow.FindControl("txtArr1");
            txtArr1.ReadOnly = false;
            TextBox txtArr2 = (TextBox)gdvrow.FindControl("txtArr2");
            txtArr2.ReadOnly = false;
            TextBox txtArr3 = (TextBox)gdvrow.FindControl("txtArr3");
            txtArr3.ReadOnly = false;

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

            TextBox txtAccNo = (TextBox)gdvrow.FindControl("txtAccNo");
            txtAccNo.ReadOnly = true;
            TextBox txtSubn = (TextBox)gdvrow.FindControl("txtSubn");
            txtSubn.ReadOnly = true;
            TextBox txtRep = (TextBox)gdvrow.FindControl("txtRep");
            txtRep.ReadOnly = true;
            TextBox txtArr1 = (TextBox)gdvrow.FindControl("txtArr1");
            txtArr1.ReadOnly = true;
            TextBox txtArr2 = (TextBox)gdvrow.FindControl("txtArr2");
            txtArr2.ReadOnly = true;
            TextBox txtArr3 = (TextBox)gdvrow.FindControl("txtArr3");
            txtArr3.ReadOnly = true;

        }
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
        SetGridDefaultChalan();
        SetGridDefaultSch();
    }
    private Boolean ChalanExistsMth(int YrId, int MthId)
    {
        Boolean chal = true;
        DataSet dsChkChal = new DataSet();
        ArrayList arrChal = new ArrayList();

        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            arrChal.Add(YrId);
            arrChal.Add(MthId);
            arrChal.Add(Convert.ToInt32(Session["intLBID"]));
            dsChkChal = chalDao.ChalanExistsMth(arrChal);
            if (dsChkChal.Tables[0].Rows.Count > 0)
            {
                chal = true;
                Session["flgAppChalCurr"] = Convert.ToInt16(dsChkChal.Tables[0].Rows[0].ItemArray[8]);
            }
            else
            {
                chal = false;
            }
        }
        else
        {
            chal = false;
        }
        return chal;
    }
    private void ClearChalDet()
    {
        txtChlAmt.Text = "";
        txtChlNo.Text = "";
        txtChlDt.Text = "";
        lblTreas.Text = "";
    }

    protected void btnFinal_Click(object sender, EventArgs e)
    {
        if (Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[8].Text) > 0 && Convert.ToDouble(Session["NumChalanID"]) > 0)
        {
            SetlblMisMatch();
            //SaveChalan();
            SaveSchedule();
            if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
            {
                Approval(Convert.ToInt16(Session["intFlgApp"]));
            }
            btnPrint.Enabled = true;
            EnbleControls();
            gblObj.MsgBoxOk("Saved successfully", this);
            FillSchedule(1);
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details!!!", this);
        }
    }
    private void SetlblMisMatch()
    {
        if (Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[8].Text) != Convert.ToDouble(txtChlAmt.Text))
        {
            gblObj.MsgBoxOk("Amount mismatch!!!", this);
        }

    }
    public void Approval(int flgApp)
    {
        if (Convert.ToInt16(Session["intMenuItem"]) == 3)        //Normal DE
        {
            approvalObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
            approvalObj.NumTrnID = Convert.ToInt64(Session["NumServiceTrnID"]);
            approvalObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
            approvalObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
            approvalObj.ChvRem = "";
            approvalDAOObj.CreateApproval(approvalObj);
        }
    }
    public bool ValidateFieldsSch(int i)
    {
        bool Valid;
        Valid = true;
        GridViewRow gvr = gdvMonthlySubn.Rows[i];

        Label lblEmpIdAss = (Label)gvr.FindControl("lblEmpId");
        Label lblTotAss = (Label)gvr.FindControl("lblTot");
        if (lblEmpIdAss.Text.ToString() != "" && lblEmpIdAss.Text.ToString() != "0" && lblTotAss.Text.ToString() != "" && lblTotAss.Text.ToString() != "0")
        {
            Valid = true;
        }
        else
        {
            Valid = false;
        }
        return Valid;
    }

    private void SaveSchedule()
    {
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gvr = gdvMonthlySubn.Rows[i];

            TextBox txtSubnAss = (TextBox)gvr.FindControl("txtSubn");
            TextBox txtRepAss = (TextBox)gvr.FindControl("txtRep");
            TextBox txtArr1Ass = (TextBox)gvr.FindControl("txtArr1");
            TextBox txtArr2Ass = (TextBox)gvr.FindControl("txtArr2");
            TextBox txtArr3Ass = (TextBox)gvr.FindControl("txtArr3");
            Label lblTotAss = (Label)gvr.FindControl("lblTot");

            Label lblEmpIdAss = (Label)gvr.FindControl("lblEmpId");
            DropDownList ddlGoAss = (DropDownList)gvr.FindControl("ddlGo");
            CheckBox chkUpAss = (CheckBox)gvr.FindControl("chkUp");
            DropDownList ddlUpRsnAss = (DropDownList)gvr.FindControl("ddlUpRsn");
            TextBox txtRemAss = (TextBox)gvr.FindControl("txtRem");

            Label lblSched = (Label)gvr.FindControl("lblSched");

            if (ValidateFieldsSch(i) == true)
            {
                sch.NumChalanID = Convert.ToDouble(Session["NumChalanID"]); //chalanId;//ChalanID;
                if (lblEmpIdAss.Text == "")
                {
                    sch.NumEmpID = 0;
                }
                else
                {
                    sch.NumEmpID = float.Parse(lblEmpIdAss.Text);
                }
                if (txtSubnAss.Text.ToString() == "" || txtSubnAss.Text.ToString() == "0")
                {
                    sch.FltSubnAmt = 0;
                }
                else
                {
                    sch.FltSubnAmt = float.Parse(txtSubnAss.Text);
                }
                if (txtRepAss.Text.ToString() == "" || txtRepAss.Text.ToString() == "0")
                {
                    sch.FltRePaymentAmt = 0;
                }
                else
                {
                    sch.FltRePaymentAmt = float.Parse(txtRepAss.Text);
                }
                if (txtArr1Ass.Text.ToString() == "" || txtArr1Ass.Text.ToString() == "0")
                {
                    sch.FltArearPFAmt = 0;
                }
                else
                {
                    sch.FltArearPFAmt = float.Parse(txtArr1Ass.Text);
                }
                if (txtArr2Ass.Text.ToString() == "" || txtArr2Ass.Text.ToString() == "0")
                {
                    sch.FltArearDA = 0;
                }
                else
                {
                    sch.FltArearDA = float.Parse(txtArr2Ass.Text);
                }
                if (txtArr3Ass.Text.ToString() == "" || txtArr3Ass.Text.ToString() == "0")
                {
                    sch.FltArearPay = 0;
                }
                else
                {
                    sch.FltArearPay = float.Parse(txtArr3Ass.Text);
                }
                //if (gdvMonthlySubn.Rows[i].Cells[9].Text == "")
                //{
                //    sch.FltTotal = 0;
                //}
                //else
                //{
                //    sch.FltTotal = double.Parse(lblTotAss.Text);
                //}
                if (lblTotAss.Text.ToString() == "" || lblTotAss.Text.ToString() == "0")
                {
                    sch.FltTotal = 0;
                }
                else
                {
                    sch.FltTotal = float.Parse(lblTotAss.Text);
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
                //sch.IntSlNo = 1;
                sch.IntSlNo = FindSlNo(sch.NumEmpID);
                if (lblSched.Text == "")
                {
                    sch.NumScheduleID = 0;
                }
                else
                {
                    sch.NumScheduleID = Convert.ToInt32(lblSched.Text);
                }
                sch.FlgUnIdentifiedEmp = 0;
                schObj.SaveSchedule(sch);
            }
            else
            {
                gblObj.MsgBoxOk("Enter all details.", this);
                break;
            }
        }
    }

    private int FindSlNo(double accno)
    {
        int slno = 1;
        DataSet dsSched = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["numChalanIdOnline"]));
        arr.Add(accno);
        dsSched = schObj.FindSlnofrmScheduleTR104(arr);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            slno = Convert.ToInt16(dsSched.Tables[0].Rows[0].ItemArray[0]);
        }
        return slno;
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
        chal.IntUnPostedRsn = 1;
        chal.IntSlNo = 1;
        chal.FlgSource = 1;
        chal.IntDay = Convert.ToDateTime(txtChlDt.Text).Day;
        chal.IntSthapnaBillID = 1;
        //if (Convert.ToDouble(txtChlAmt.Text.Trim()) == Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[9].Text))
        //{
        chal.FlgAmtMismatch = 1;
        //}
        //else
        //{
        //    chal.FlgAmtMismatch = 2;
        //}
        chal.FlgChalanType = 1;
        chal.tENo = 0;
        chal.IntTreasuryDAGID = 0;
        ds = chalDao.CreateChalan(chal);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Session["NumChalanID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
        }
    }

    public bool ValidateFields()
    {
        bool Valid;
        Valid = true;
        if (txtChlAmt.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Please enter the Chalan amount.", this);
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
        //else if (CheckChalDate() == false)    //Check chal date must b after year and month combo
        //{
        //    gblObj.MsgBoxOk("Invalid Chalan date!", this);
        //    Valid = false;
        //}
        else
        {
            Valid = true;
        }
        return Valid;
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        //{
        //    Session["intMonthIdMs"] = Convert.ToInt16(ddlMonth.SelectedValue);
        //    gblObj.CheckValidMonthDdl(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), this, ddlYear, btnAdd);
        //    if (ChalanExistsMth(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"])) == true)
        //    {
        //        FillGridChalan();
        //        FillSchedule(1);
        //        FillChalanTxts(1);
        //        if (Convert.ToInt16(Session["flgAppChalCurr"]) != 20)
        //        {
        //            SetControls();
        //        }
        //        else
        //        {
        //            DisableControls();
        //        }
        //    }
        //    else
        //    {
        //        SetGridDefaultChalan();
        //        SetGridDefaultSch();
        //        ClearChalDet();
        //        //EnbleControls();
        //    }
        //}
        //else
        //{
        //    Session["intMonthIdMs"] = 0;
        //}
        //SetMonthFlag();
        //if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        //{
        //    DisableControls();
        //    btnAdd.Enabled = false;
        //    btnNew.Enabled = false;
        //}
        //else
        //{
        //    EnbleControls();
        //    btnAdd.Enabled = true;
        //    btnNew.Enabled = true;
        //}

        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["intMonthIdMs"] = Convert.ToInt16(ddlMonth.SelectedValue);
            gblObj.CheckValidMonthDdl(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), this, ddlYear, btnAdd);
            if (ChalanExistsMth(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"])) == true)
            {
                FillGridChalan();
                FillSchedule(1);
                FillChalanTxts(1);
                if (Convert.ToInt16(Session["flgAppChalCurr"]) != 20)
                {
                    SetControls();
                }
                else
                {
                    DisableControls();
                }
            }
            else
            {
                SetGridDefaultChalan();
                SetGridDefaultSchFrmMaster();
                ClearChalDet();
            }
        }
        else
        {
            Session["intMonthIdMs"] = 0;
        }
        SetMonthFlag();
        if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        {
            DisableControls();
            btnAdd.Enabled = false;
            btnNew.Enabled = false;
        }
        else
        {
            EnbleControls();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
        }
    }
    private void SetGridDefaultSchFrmMaster()
    {
        DataSet dsSch = new DataSet();
        dsSch = gen.GetEmpLBWise(Convert.ToInt32(Session["intLBID"])); //gblObj.IntInstId
        if (dsSch.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsSch.Tables[0].Rows.Count.ToString();
            gdvMonthlySubn.DataSource = dsSch;
            gdvMonthlySubn.DataBind();
            for (int i = 0; i < dsSch.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvMonthlySubn.Rows[i];

                TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
                txtAccNoAss.Text = dsSch.Tables[0].Rows[i].ItemArray[1].ToString();

                Label lblNameAss = (Label)gdv.FindControl("lblName");
                lblNameAss.Text = dsSch.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
                txtSubnAss.Text = dsSch.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblTotAss = (Label)gdv.FindControl("lblTot");
                lblTotAss.Text = dsSch.Tables[0].Rows[i].ItemArray[5].ToString();
            }
        }

        ArrayList ar = new ArrayList();
        ar.Add("txtSubn");
        ar.Add("txtRep");
        ar.Add("txtArr1");
        ar.Add("txtArr2");
        ar.Add("txtArr3");
        gblObj.SetFooterTotalsTempFieldMltpl(gdvMonthlySubn, 3, 7, ar, 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 8, "lblTot", 2);
        txtHddn.Text = gdvMonthlySubn.FooterRow.Cells[8].Text.ToString();
    }
    private void SetMonthFlag()
    {
        //int intMId;
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdMs"]));
        DataSet ds = new DataSet();
        //ds = genDAO.CheckMonth(ar);
        ds = gen.CheckMonth(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) <= 7)
            {
                Session["intMonthFlag"] = 1;
            }
            else
            {
                Session["intMonthFlag"] = 2;
            }
        }
    }
    private void SetGridDefaultSch()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        gblObj.SetGridDefault(gdvMonthlySubn, ar);
        gblObj.SetFooterTotals(gdvMonthlySubn, 8);
        FillGridGo();

        txtCnt.Text = "1";
        txtHddn.Text = "0";
    }
    private void SetGridDefaultChalan()
    {
        ArrayList arc = new ArrayList();
        arc.Add("SlNo");
        arc.Add("intChalanNo");
        arc.Add("dtChalanDate");
        arc.Add("fltChalanAmt");
        arc.Add("numChalanId");
        arc.Add("flgApproval");
        arc.Add("chvApproval");

        gblObj.SetGridDefault(gdvChalan, arc);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["NumChalanID"] = Convert.ToInt16(chalanId);
        Response.Redirect("Reportviewer.aspx?ReportID=3");
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlGo");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            DataSet dsGo = new DataSet();
            dsGo = gen.GetGO();
            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dsGo);
            ////Store Temp in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsMs = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToDouble(Session["NumChalanID"]));
            dsMs = schObj.CheckScheduleExist(arr);
            ////Ds to fill Grid//////////

            gblObj.SetGridRowsWithData(dsMs, Convert.ToInt16(txtCnt.Text), gdvMonthlySubn, arDdl, arCols, arDdlDs);
        }
        else
        {
            gblObj.SetRowsCnt(gdvMonthlySubn, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtAccNo");
        arCols.Add("lblName");
        arCols.Add("txtSubn");
        arCols.Add("txtRep");
        arCols.Add("txtArr1");
        arCols.Add("txtArr2");
        arCols.Add("txtArr3");
        arCols.Add("lblTot");
        arCols.Add("ddlGo");
        arCols.Add("chkUp");
        arCols.Add("ddlUpRsn");
        arCols.Add("txtRem");
        arCols.Add("lblEmpId");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidateFields() == true)
        {
            SaveChalan();
            if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
            {
                gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["NumChalanID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]), "");
            }
            FillGridChalan();
        }
    }
    private void FillGridChalanIDWise()
    {
        SetGridDefaultChalan();
        DataSet dsChal = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["NumChalanID"]));
        dsChal = chalDao.SelectChalanIDWise(ar);
        if (dsChal.Tables[0].Rows.Count > 0)
        {
            gdvChalan.DataSource = dsChal;
            gdvChalan.DataBind();
            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvChalan.Rows[i];

                Label lblChalIdAss = (Label)gdv.FindControl("lblChalId");
                lblChalIdAss.Text = dsChal.Tables[0].Rows[i].ItemArray[4].ToString();
                //if (dsChal.Tables[0].Rows.Count == 1)
                //{
                //Session["NumChalanIDFirst"] = Convert.ToDouble(dsChal.Tables[0].Rows[0].ItemArray[4]);
                //}
            }
            gblObj.SetFooterTotals(gdvChalan, 3);
        }
        else
        {
            SetGridDefaultChalan();
        }
    }

    private void FillGridChalan()
    {
        SetGridDefaultChalan();
        DataSet dsChal = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearIdMs"]));
        ar.Add(Convert.ToInt16(Session["intMonthIdMs"]));
        ar.Add(Convert.ToInt32(Session["intLBID"]));
        dsChal = chalDao.ChalanExistsMth(ar);
        if (dsChal.Tables[0].Rows.Count > 0)
        {
            gdvChalan.DataSource = dsChal;
            gdvChalan.DataBind();
            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvChalan.Rows[i];

                Label lblChalIdAss = (Label)gdv.FindControl("lblChalId");
                lblChalIdAss.Text = dsChal.Tables[0].Rows[i].ItemArray[4].ToString();
                //if (dsChal.Tables[0].Rows.Count == 1)
                //{
                Session["NumChalanIDFirst"] = Convert.ToDouble(dsChal.Tables[0].Rows[0].ItemArray[4]);
                //}
            }
            //lblStatus.Text = "ss";
            gblObj.SetFooterTotals(gdvChalan, 3);
        }
        else
        {
            SetGridDefaultChalan();
        }
    }
    protected void txtChlDt_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.isValidDate(txtChlDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtChlDt, ddlYear, ddlMonth) == false)
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtChlDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtChlDt.Text = "";
        }
    }
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        int intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        DataSet dsName = new DataSet();
        GridViewRow gdr = gdvMonthlySubn.Rows[intCurRw];
        Label lblAccNoAss = (Label)gdr.FindControl("lblAccNo");
        TextBox txtAccNoAss = (TextBox)gdr.FindControl("txtAccNo");
        Label lblNameAss = (Label)gdr.FindControl("lblName");
        Label lblEmpIdAss = (Label)gdr.FindControl("lblEmpId");

        if (gblObj.CheckNumericOnly(txtAccNoAss.Text.ToString(), this) == true)
        {
            emp.NumEmpID = Convert.ToDouble(txtAccNoAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(dsName.Tables[0].Rows[0].ItemArray[2]) != 1)
                {
                    txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                    lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                    lblEmpIdAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
                }
                else
                {
                    txtAccNoAss.Text = "";
                    lblNameAss.Text = "";
                    lblEmpIdAss.Text = "0";
                    gblObj.MsgBoxOk("Closed Account!", this);
                }
            }
            else
            {
                txtAccNoAss.Text = "";
                lblNameAss.Text = "";
                lblEmpIdAss.Text = "0";
                gblObj.MsgBoxOk("Account number doesnot exists", this);
            }
        }
    }
    protected void txtSubn_TextChanged(object sender, EventArgs e)
    {
        int intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvMonthlySubn);
        FillFooterTotals();
    }
    protected void txtRep_TextChanged(object sender, EventArgs e)
    {
        int intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvMonthlySubn);
        FillFooterTotals();
    }
    protected void txtArr1_TextChanged(object sender, EventArgs e)
    {
        int intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvMonthlySubn);
        FillFooterTotals();
    }
    protected void txtArr2_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gvr = gdvMonthlySubn.Rows[i];
            TextBox txtArr2Ass = (TextBox)gvr.FindControl("txtArr2");
            DropDownList ddlGoAss = (DropDownList)gvr.FindControl("ddlGo");
            if (txtArr2Ass.Text != "")
            {
                if (Convert.ToDouble(txtArr2Ass.Text) > 0)
                {
                    ddlGoAss.Enabled = true;
                }
                else
                {
                    ddlGoAss.Enabled = false;
                }
            }
        }
        int intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvMonthlySubn);
        FillFooterTotals();
    }
    protected void txtArr3_TextChanged(object sender, EventArgs e)
    {
        int intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvMonthlySubn);
        FillFooterTotals();
    }
    private void FillFooterTotals()
    {
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 3, "txtSubn", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 4, "txtRep", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 5, "txtArr1", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 6, "txtArr2", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 7, "txtArr3", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 8, "lblTot", 2);
        txtHddn.Text = gdvMonthlySubn.FooterRow.Cells[8].Text.ToString();
    }
    private void CalcNewTotal(int intCurRwSched, GridView gdv)
    {
        GridViewRow gvr = gdv.Rows[intCurRwSched];
        TextBox txtSubnAss = (TextBox)gvr.FindControl("txtSubn");
        TextBox txtRepAss = (TextBox)gvr.FindControl("txtRep");
        TextBox txtPfAss = (TextBox)gvr.FindControl("txtArr1");
        TextBox txtDaAss = (TextBox)gvr.FindControl("txtArr2");
        TextBox txtPayAss = (TextBox)gvr.FindControl("txtArr3");

        Label lblTotAss = (Label)gvr.FindControl("lblTot");
        if (txtSubnAss.Text == "")
        {
            txtSubnAss.Text = 0.ToString();
        }
        if (txtRepAss.Text == "")
        {
            txtRepAss.Text = 0.ToString();
        }
        if (txtPfAss.Text == "")
        {
            txtPfAss.Text = 0.ToString();
        }
        if (txtDaAss.Text == "")
        {
            txtDaAss.Text = 0.ToString();
        }
        if (txtPayAss.Text == "")
        {
            txtPayAss.Text = 0.ToString();
        }
        lblTotAss.Text = Convert.ToString(Convert.ToDouble(txtSubnAss.Text) + Convert.ToDouble(txtRepAss.Text) + Convert.ToDouble(txtPfAss.Text) + Convert.ToDouble(txtDaAss.Text) + Convert.ToDouble(txtPayAss.Text));

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //if (Convert.ToInt16(Session["intMonthIdMs"]) >= 4 && Convert.ToInt16(Session["intMonthIdMs"]) < 11)
        //{
        //    btnNew.Enabled = false ;
        //}
        Session["NumChalanID"] = 0;
        ClearChalDet();
        SetGridDefaultSch();
        SetMonthFlag();
        if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        {
            DisableControls();
            btnAdd.Enabled = false;
            btnNew.Enabled = false;
        }
        else
        {
            EnbleControls();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
        }
    }
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
}