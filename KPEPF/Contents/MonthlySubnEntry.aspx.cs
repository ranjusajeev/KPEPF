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
using System.Collections.Generic;
using KPEPFClassLibrary;

public partial class Contents_MonthlySubnEntry : System.Web.UI.Page
{
    //clsGlobalMethods gblObj = new clsGlobalMethods();
    //KPEPFGeneralDAO gen = new KPEPFGeneralDAO();
    //Chalan chal = new Chalan();
    //ChalanDAO chalDao = new ChalanDAO();
    //Schedule sch = new Schedule();
    //ScheduleDAO schObj = new ScheduleDAO();
    //Employee emp = new Employee();
    //EmployeeDAO empD = new EmployeeDAO();
    //Approval approvalObj = new Approval();
    //ApprovalDAO approvalDAOObj = new ApprovalDAO();


    clsGlobalMethods gblObj;
    KPEPFGeneralDAO gen;
    Chalan chal;
    ChalanDAO chalDao;
    Schedule sch;
    ScheduleDAO schObj;
    Employee emp;
    EmployeeDAO empD;
    Approval approvalObj;
    ApprovalDAO approvalDAOObj;


    //static float chalanId = 0;
    //static int ScheduleMainId = 0;
    //static int treasuryId = 0;
    //static int MnthId = 0;
    //static int intBillTypeID = 0;
    //static int ScheduleMainId = 0;

    static int intCnt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        
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
                    intCnt = 0;
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
        chalDao = new ChalanDAO();
        
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
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();
        schObj = new ScheduleDAO();

        SetGridDefaultSch();
        ArrayList arrCh = new ArrayList();
        DataSet dsSch = new DataSet();
        if (intFirst == 1)
        {
            arrCh.Add(Convert.ToInt64(Session["NumChalanIDFirst"]));
        }
        else
        {
            arrCh.Add(Convert.ToInt64(Session["NumChalanID"]));
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


                DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");
                DataSet dsFm = gen.GetMonth();
                gblObj.FillCombo(ddlFm, dsFm, 1);

                ddlFm.SelectedValue = dsSch.Tables[0].Rows[i].ItemArray[17].ToString();


                DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
                DataSet dsTm = gen.GetMonth();
                gblObj.FillCombo(ddlTm, dsTm, 1);

                ddlTm.SelectedValue = dsSch.Tables[0].Rows[i].ItemArray[18].ToString();


            }
            ArrayList ar=new ArrayList();
            ar.Add("txtSubn");
            ar.Add("txtRep");
            ar.Add("txtArr1");
            ar.Add("txtArr2");
            ar.Add("txtArr3");

            gblObj.SetFooterTotalsTempFieldMltpl(gdvMonthlySubn, 3, 7, ar, 1);
            gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 10, "lblTot", 2);
            txtHddn.Text = gdvMonthlySubn.FooterRow.Cells[10].Text.ToString();
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
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();

        SetGridDefaultChalan();
        SetGridDefaultSch();
        DataSet dsY = new DataSet();
        dsY = gen.GetYearOnLineNew();
        gblObj.FillCombo(ddlYear, dsY, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        gblObj.FillCombo(ddlMonth, dsM, 1);

        SetGridDefaultChalan();
        SetGridDefaultSch();

        //FillGridGo();
        gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
        
    }
    private void FillGridGo()
    {
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();

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
        gen = new KPEPFGeneralDAO();

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
            if (Convert.ToInt16(dsE.Tables[0].Rows[0].ItemArray[0]) == 1)
            {
                if (Convert.ToInt16(Session["intLBID"]) == ChalanLBId())
                {
                    EnbleControls();
                    btnDel.Enabled = true;
                }
                else
                {
                    DisableControls();
                    btnDel.Enabled = false;
                }
            }
            else
            {
                DisableControls();
                btnDel.Enabled = false;
            }
        }

    }
    private double ChalanLBId()
    {
        chalDao = new ChalanDAO();
        
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

            ImageButton btndeleteCr = (ImageButton)gdvrow.FindControl("btndeleteCr");
            btndeleteCr.Enabled = true ;

            DropDownList ddlFm = (DropDownList)gdvrow.FindControl("ddlFm");
            ddlFm.Enabled = true;

            DropDownList ddlTm = (DropDownList)gdvrow.FindControl("ddlTm");
            ddlTm.Enabled = true;
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

            ImageButton btndeleteCr = (ImageButton)gdvrow.FindControl("btndeleteCr");
            btndeleteCr.Enabled = false;

            DropDownList ddlFm = (DropDownList)gdvrow.FindControl("ddlFm");
            ddlFm.Enabled = false;

            DropDownList ddlTm = (DropDownList)gdvrow.FindControl("ddlTm");
            ddlTm.Enabled = false;
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIdMs"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearIdMs"] = 0;
        }
        ddlMonth.SelectedValue = "0";
        SetGridDefaultChalan();
        SetGridDefaultSch();
    }
    private Boolean ChalanExistsMth(int YrId, int MthId)
    {
        chalDao = new ChalanDAO();
        
        Boolean chal1 = true;
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
                chal1 = true;
                //Session["flgAppChalCurr"] = Convert.ToInt16(dsChkChal.Tables[0].Rows[0].ItemArray[8]);
                Session["IntFlgOrg"] = Convert.ToInt16(dsChkChal.Tables[0].Rows[0].ItemArray[8]);
            }
            else
            {
                chal1 = false;
            }
        }
        else
        {
            chal1 = false;
        }
        return chal1;
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
        gblObj = new clsGlobalMethods();
        intCnt = intCnt + 1;
        if (Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[10].Text) > 0 && Convert.ToDouble(Session["NumChalanID"]) > 0)
        {
            SetlblMisMatch();
            if (intCnt == 1)
            {
                SaveSchedule();
                if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
                {
                    Approval(Convert.ToInt16(Session["intFlgApp"]));
                }
            }
            btnPrint.Enabled = true;
            EnbleControls();
            gblObj.MsgBoxOk("Saved successfully", this);
            FillSchedule(2);
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details!!!", this);
        }
        btnFinal.Enabled = false;

        //gblObj = new clsGlobalMethods();
        //if (Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[10].Text) > 0 && Convert.ToDouble(Session["NumChalanID"]) > 0)
        //{
        //    SetlblMisMatch();
        //    SaveSchedule();
        //    if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
        //    {
        //        Approval(Convert.ToInt16(Session["intFlgApp"]));
        //    }
        //    btnPrint.Enabled = true;
        //    EnbleControls();
        //    gblObj.MsgBoxOk("Saved successfully", this);
        //    FillSchedule(2);
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter all details!!!", this);
        //}
        //btnFinal.Enabled = false;
    }
    private void SetlblMisMatch()
    {
        gblObj = new clsGlobalMethods();
        
        if (Convert.ToDouble(gdvMonthlySubn.FooterRow.Cells[10].Text) != Convert.ToDouble(txtChlAmt.Text))
        {
            gblObj.MsgBoxOk("Amount mismatch!!!", this);
        }
        
    }
    public void Approval(int flgApp)
    {
        approvalObj = new Approval();
        approvalDAOObj = new ApprovalDAO();

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
        gblObj = new clsGlobalMethods();
        sch = new Schedule();
        schObj = new ScheduleDAO();

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
            DropDownList ddlFm = (DropDownList)gvr.FindControl("ddlFm");
            DropDownList ddlTm = (DropDownList)gvr.FindControl("ddlTm");
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

                if (lblTotAss.Text.ToString() == "" || lblTotAss.Text.ToString() == "0")
                {
                    sch.FltTotal = 0;
                }
                else
                {
                    sch.FltTotal = float.Parse(lblTotAss.Text);
                }
                if (ddlGoAss.SelectedValue == "")
                {
                    sch.IntGOId = 0;
                }
                else
                {
                    sch.IntGOId = int.Parse(ddlGoAss.Text);
                }

                if (ddlFm.SelectedValue == "")
                {
                    sch.IntFm = 0;
                }
                else
                {
                    sch.IntFm = int.Parse(ddlFm.Text);
                }
                if (ddlTm.SelectedValue == "")
                {
                    sch.IntTm = 0;
                }
                else
                {
                    sch.IntTm = int.Parse(ddlTm.Text);
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
   
    private int FindSlNo( double  accno)
    {
        schObj = new ScheduleDAO();
        
        int slno = 1;
        DataSet dsSched = new DataSet();
        ArrayList arr= new ArrayList();
        arr.Add(Convert.ToInt64(Session["NumChalanID"]));
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
        gen = new KPEPFGeneralDAO();
        chal = new Chalan();
        chalDao = new ChalanDAO();

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
        //chal.PerYearId = Convert.ToInt32(ddlYear.SelectedValue);
        //chal.PerMonthId = Convert.ToInt32(ddlMonth.SelectedValue);
        chal.PerYearId = chal.YearId;
        chal.PerMonthId = chal.MonthId;
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
        gblObj = new clsGlobalMethods();
        
        bool Valid;
        Valid = true;
        if (txtChlAmt.Text.Trim() == "" || txtChlAmt.Text.Trim() == "0")
        {
            gblObj.MsgBoxOk("Enter Chalan amount.", this);
            Valid = false;
        }
        else if (txtChlDt.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter Chalan date", this);
            Valid = false;
        }

        else if (Convert.ToDateTime(txtChlDt.Text) > Convert.ToDateTime(DateTime.Now.Date))
        {
            gblObj.MsgBoxOk("Chalan date should be less than current date", this);
            Valid = false;
        }
        else if (txtChlNo.Text.Trim() == "" || txtChlNo.Text.Trim() == "0")
        {
            gblObj.MsgBoxOk("Enter Chalan no.", this);
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
        //        //DisableControls();
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
        //    btnAdd.Enabled = true ;
        //    btnNew.Enabled = true;
        //}

        //DisableControls();

        gblObj = new clsGlobalMethods();

        if (ddlMonth.SelectedIndex > 0)
        {
            Session["intMonthIdMs"] = Convert.ToInt16(ddlMonth.SelectedValue);
            if (gblObj.CheckValidMonthDdl(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"]), this, ddlYear, btnAdd) == true)
            {
                if (ChalanExistsMth(Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"])) == true)
                {
                    FillGridChalan();
                    FillSchedule(1);
                    FillChalanTxts(1);
                }
                else
                {
                    SetGridDefaultChalan();
                    SetGridDefaultSch();
                    ClearChalDet();
                }
                //SetControlsWhetherAppAo();
                DisableControls();
            }
            else
            {
                SetGridDefaultChalan();
                SetGridDefaultSch();
                ClearChalDet();

                DisableControls();
                btnNew.Enabled = false;
                btnAdd.Enabled = false;
            }
        }
        else
        {
            //Session["intMonthIdMs"] = 0;
            gblObj.MsgBoxOk("Select month", this);
        }
        
        //SetControls();
        //SetMonthFlag();
    }
    //private void SetControlsWhetherAppAo()
    //{
    //    approvalDAOObj = new ApprovalDAO();
        
    //    DataSet dsE = new DataSet();
    //    ArrayList arr = new ArrayList();

    //    arr.Add(Convert.ToInt32(Session["intYearIdMs"]));
    //    arr.Add(Convert.ToInt32(Session["intMonthIdMs"]));
    //    arr.Add(Convert.ToInt32(Session["intDTreasuryID"]));
    //    arr.Add(1);
    //    dsE = approvalDAOObj.CheckFlagApp(arr);
    //    if (dsE.Tables[0].Rows.Count > 0)
    //    {
    //        if (Convert.ToInt16(dsE.Tables[0].Rows[0].ItemArray[0]) == 2 || Convert.ToInt16(dsE.Tables[0].Rows[0].ItemArray[0]) == 0)
    //        {
    //            //EnbleControls();
    //            btnNew.Enabled = true ;
    //            btnAdd.Enabled = true;
    //        }
    //        else
    //        {
    //            //DisableControls();
    //            btnNew.Enabled = false;
    //            btnAdd.Enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        //EnbleControls();
    //        btnNew.Enabled = true;
    //        btnAdd.Enabled = true;
    //        //SetControls();
    //    }

    //    //Session["intMonthFlag"] = 1;
    //}
    private void SetMonthFlag()
    {
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt16(Session["intMonthIdMs"]));
        //DataSet ds = new DataSet();
        ////ds = genDAO.CheckMonth(ar);
        //ds = gen.CheckMonth(ar);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) <= 7)
        //    {
        //        Session["intMonthFlag"] = 1;
        //    }
        //    else
        //    {
        //        if (Convert.ToInt16(Session["intYearIdMs"]) > 0 && Convert.ToInt16(Session["intMonthIdMs"]) > 0) 
        //        {
        //            Session["intMonthFlag"] = 2;
        //        }
        //        else
        //        {
        //            Session["intMonthFlag"] = 1;
        //        }
        //    }
        //}
        //else
        //{
        //    Session["intMonthFlag"] = 1;
        //}
        //if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        //{
        //    SetControls();
        //    btnAdd.Enabled = false;
        //    btnNew.Enabled = false;
        //}
        //else
        //{
        //    SetControls();
        //    btnAdd.Enabled = true;
        //    btnNew.Enabled = true;
        //}

        gen = new KPEPFGeneralDAO();

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdMs"]));
        DataSet ds = new DataSet();
        ds = gen.CheckMonth(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) <= 7)
            {
                Session["intMonthFlag"] = 1;
            }
            else
            {
                if (Convert.ToInt16(Session["intYearIdMs"]) > 0 && Convert.ToInt16(Session["intMonthIdMs"]) > 0)
                {
                    Session["intMonthFlag"] = 2;
                }
                else
                {
                    Session["intMonthFlag"] = 1;
                }
            }
        }
        else
        {
            Session["intMonthFlag"] = 1;
        }



        if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        {
            SetControls();
            btnAdd.Enabled = false;
            btnNew.Enabled = false;
        }
        else
        {
            SetControls();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
        }
    }
    private void SetGridDefaultSch()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        gblObj.SetGridDefault(gdvMonthlySubn, ar);
        gblObj.SetFooterTotals(gdvMonthlySubn, 10);
        FillGridGo();
        FillGridCmbM();

        txtCnt.Text = "1";
        txtHddn.Text = "0";
    }
    protected void FillGridCmbM()
    {
        gen = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        for (int i = 0; i < gdvMonthlySubn.Rows.Count; i++)
        {
            GridViewRow gdv = gdvMonthlySubn.Rows[i];
            DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");
            DataSet ds1 = gen.GetMonth();
            gblObj.FillCombo(ddlFm, ds1, 1);

            DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
            DataSet ds2 = gen.GetMonth();
            gblObj.FillCombo(ddlTm, ds1, 1);
        }
    }
    private void SetGridDefaultChalan()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList arc = new ArrayList();
        arc.Add("SlNo");
        arc.Add("intChalanNo");
        arc.Add("dtChalanDate");
        arc.Add("fltChalanAmt");
        arc.Add("numChalanId");
        arc.Add("flgApproval");
        arc.Add("chvApproval");
        gblObj.SetGridDefault(gdvChalan, arc);

        //txtChlAmt.Text = "";
        //txtChlDt.Text = "";
        //txtChlNo.Text = "";
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //Session["NumChalanID"] = Convert.ToInt16(chalanId);
        Response.Redirect("Reportviewer.aspx?ReportID=3");
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();
        schObj = new ScheduleDAO();

        if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlGo");
            arDdl.Add("ddlFm");
            arDdl.Add("ddlTm");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            DataSet dsGo = new DataSet();
            dsGo = gen.GetGO();
            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dsGo);

            DataSet dsFm = new DataSet();
            dsFm = gen.GetMonth();
            arDdlDs.Add(dsFm);

            DataSet dsTm = new DataSet();
            dsTm = gen.GetMonth();
            arDdlDs.Add(dsTm);
            ////Store Temp in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsMs = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToDouble(Session["NumChalanID"]));
            dsMs = schObj.CheckScheduleExist4Cnt(arr);
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
        arCols.Add("ddlFm");
        arCols.Add("ddlTm");
        arCols.Add("lblTot");
        arCols.Add("ddlGo");
        arCols.Add("chkUp");
        arCols.Add("ddlUpRsn");
        arCols.Add("txtRem");
        arCols.Add("lblEmpId");       
        arCols.Add("lblSched");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        
        if (ValidateFields() == true)
        {
            SaveChalan();
            if (Convert.ToInt16(Session["intMenuItem"]) == 3 && Convert.ToInt16(Session["IntFlgOrg"]) == 0)    //Not thru Inbox
            {
                gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt64(Session["NumChalanID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]), "");
            }
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)         //Through Inbox
            {
                FillGridChalanIDWise();
            }
            else
            {
                FillGridChalan();
            }
            
            SetControls();
        }
    }
    private void FillGridChalanIDWise()
    {
        gblObj = new clsGlobalMethods();
        chalDao = new ChalanDAO();

        SetGridDefaultChalan();
        DataSet dsChal = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["NumChalanID"]));
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
        gblObj = new clsGlobalMethods();
        chalDao = new ChalanDAO();

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
                Session["NumChalanIDFirst"] = Convert.ToDouble(dsChal.Tables[0].Rows[0].ItemArray[4]);
                gdv.Cells[5].ToolTip = dsChal.Tables[0].Rows[i].ItemArray[11].ToString();
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
        gblObj = new clsGlobalMethods();
        
        if (checkYrMnth() == true)
        {

            if (gblObj.isValidDate(txtChlDt, this) == true)
            {
                if (gblObj.CheckChalanDate(txtChlDt, Convert.ToInt16(Session["intYearIdMs"]), Convert.ToInt16(Session["intMonthIdMs"])) == false)
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
        else
        {
            gblObj.MsgBoxOk("Select all details",this);
        }
    }
    //private Boolean  CheckChalanDateL(TextBox txtChlDt, int yr, int mth)
    //{
    //    Boolean flg;
    //    ArrayList ar = new ArrayList();
    //    gen=new KPEPFGeneralDAO();
    //    ar.Add(Convert.ToDateTime(txtChlDt.Text));
    //    if (gen.gFunFindYearIdFromDate(ar) != yr || Convert.ToDateTime(txtChlDt.Text).Month != mth)
    //    {
    //        gblObj.MsgBoxOk("Invalid Date", this);
    //        txtChlDt.Text = "";
    //        flg = false;
    //    }
    //    else
    //    {
    //        flg = true ;
    //    }
    //    return flg;
    //}
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

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
                if (Convert.ToInt16(dsName.Tables[0].Rows[0].ItemArray[2])!=1)
                {
                    txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                    lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                    lblEmpIdAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
                }
                else
                {
                    //txtAccNoAss.Text = "";
                    //lblNameAss.Text = "";
                    //lblEmpIdAss.Text = "0";
                    gblObj.MsgBoxOk("Closed Account!", this);
                    txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                    lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                    lblEmpIdAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
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
        intCnt = 0;
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
        intCnt = 0;
    }
    protected void txtArr3_TextChanged(object sender, EventArgs e)
    {
        int intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvMonthlySubn);
        FillFooterTotals();
        intCnt = 0;
    }
    private void FillFooterTotals()
    {
        gblObj = new clsGlobalMethods();
        
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 3, "txtSubn", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 4, "txtRep", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 5, "txtArr1", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 6, "txtArr2", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 7, "txtArr3", 1);
        gblObj.SetFooterTotalsTempField(gdvMonthlySubn, 10, "lblTot", 2);
        txtHddn.Text = gdvMonthlySubn.FooterRow.Cells[10].Text.ToString();
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
        
        //if (Convert.ToInt16(Session["intMonthFlag"]) == 1)
        //{
        //    DisableControls();
        //    btnAdd.Enabled = false;
        //    btnNew.Enabled = false;
        //}
        //else
        //{
            EnbleControls();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            Session["NumChalanID"] = 0;
            Session["IntFlgOrg"] = 0;
            ClearChalDet();
            SetGridDefaultSch();
        //}
    }
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
    protected void txtChlNo_TextChanged(object sender, EventArgs e)
    {
        if (checkYrMnth() == true)
        {
        }
    }
    private Boolean checkYrMnth()
    {
        gblObj = new clsGlobalMethods();
        
        Boolean flg = true;
        if (ddlYear.SelectedValue == "0" || ddlYear.SelectedValue == null)
        {
            gblObj.MsgBoxOk("Please select year and Month", this);
            btnAdd.Enabled = false;
            txtChlNo.Text = "";
            txtChlNo.Enabled = false;
            flg = false;
        }
        else
        {
            btnAdd.Enabled = true;
            txtChlNo.Enabled = true;
            flg = true;
        }
        return flg;
    }
    protected void gdvChalan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
protected void  btnDeleteCr_Click(object sender, ImageClickEventArgs e)
{
    gblObj = new clsGlobalMethods();
    
    ScheduleDAO schDao = new ScheduleDAO();
    int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
    //  int rowIndex = Convert.ToInt32(e.RowIndex);
    Label lblSchedAss = (Label)gdvMonthlySubn.Rows[rowIndex].FindControl("lblSched");
    if (lblSchedAss.Text != "")
    {
        ArrayList arrin = new ArrayList();
        arrin.Add(Convert.ToInt32(lblSchedAss.Text));
        try
        {
            schDao.UpdScheduleTR104Mode(arrin);
            deleteUnsavedScheduleTR104();
        }
        catch (Exception ex)
        {
            Session["ERROR"] = ex.ToString();
            Response.Redirect("Error.aspx");
        }
    }

    FillSchedule(2);
    gblObj.MsgBoxOk("Row Deleted   !", this);

    //   FillHeadLbls();
    //}
    //else
    //{
    //}
}
private void deleteUnsavedScheduleTR104()
{
    gblObj = new clsGlobalMethods();
    
    List<Control> myControls = creategdFloorControl();
    ArrayList arrControlid = creategdFloorControlId();
    ArrayList arrDT = getDataTablegdFloor();
    DataTable dtgdRow = gblObj.deleteRows(myControls, arrControlid, arrDT, gdvMonthlySubn);
    if (dtgdRow.Rows.Count > 0)
    {
        DataSet ds = new DataSet();
        gdvMonthlySubn.DataSource = dtgdRow;
        gdvMonthlySubn.DataBind();
        ds.Tables.Add(dtgdRow);
        fillDropDownGridExistsFloor(gdvMonthlySubn, ds);
    }
    else
    {
        FillSchedule(2);
    }
}

private List<Control> creategdFloorControl()
{
    List<Control> myControls = new List<Control>();
    // myControls.Add(new DropDownList());
    myControls.Add(new TextBox());
    myControls.Add(new Label());
    myControls.Add(new TextBox());
    myControls.Add(new TextBox());
    myControls.Add(new TextBox());
    myControls.Add(new TextBox());
    myControls.Add(new TextBox());
    myControls.Add(new Label());
    myControls.Add(new DropDownList());
    myControls.Add(new CheckBox());
    myControls.Add(new DropDownList());
     myControls.Add(new TextBox());
    myControls.Add(new Label());
    myControls.Add(new Label());

    return myControls;
}
private ArrayList creategdFloorControlId()
{
    ArrayList arrControlid = new ArrayList();
    //  arrControlid.Add("ddFloorArea");
    arrControlid.Add("txtAccNo");
    arrControlid.Add("lblName");
    arrControlid.Add("txtSubn");
    arrControlid.Add("txtRep");
    arrControlid.Add("txtArr1");
    arrControlid.Add("txtArr2");
    arrControlid.Add("txtArr3");
    arrControlid.Add("lblTot");
    arrControlid.Add("ddlGo");
    arrControlid.Add("chkUp");
    arrControlid.Add("ddlUpRsn");
    arrControlid.Add("txtRem");
    arrControlid.Add("lblEmpId");
    arrControlid.Add("lblSched");

    return arrControlid;
}
private ArrayList getDataTablegdFloor()
{
    ArrayList arrControlid = new ArrayList();
    // arrControlid.Add("SlNo");
    arrControlid.Add("chvPF_No");
    arrControlid.Add("chvName");
    arrControlid.Add("fltSubnAmt");
    arrControlid.Add("fltRePaymentAmt");
    arrControlid.Add("fltArearPFAmt");
    arrControlid.Add("fltArearDA");
    arrControlid.Add("fltArearPay");
    arrControlid.Add("TotRem");
    arrControlid.Add("intGOID");
    arrControlid.Add("UnPosted");
    arrControlid.Add("UnPostedRsn");
    arrControlid.Add("Rem");
    arrControlid.Add("numEmpId");
    arrControlid.Add("numScheduleID");

    return arrControlid;
}
     
private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
{
    FillGridGo();
    foreach (GridViewRow gdRow in gdView.Rows)
    {
        if (ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList ddlGoAss = (DropDownList)gdRow.FindControl("ddlGo");
                ddlGoAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[8].ToString();
            }
        }
    }
}
protected void btnDel_Click(object sender, EventArgs e)
{
    ChalanDAO chalDao = new ChalanDAO();
    if (Convert.ToInt64(Request.QueryString["numChalanId"]) > 0)
    {
        //if (Convert.ToInt16(Request.QueryString["flgApproval"]) < 3)
        //{
            Session["NumChalanID"] = Convert.ToInt64(Request.QueryString["numChalanId"]);
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(Session["NumChalanID"]));
            arrin.Add(1);
            chalDao.UpdateChalanMode(arrin);
            FillGridChalan();
        //}
    }
}
}
 



               
