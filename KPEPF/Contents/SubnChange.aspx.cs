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

public partial class Contents_SubnChange : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    SubnChange Subn = new SubnChange();
    SubnChangeDAO SubnDao = new SubnChangeDAO();
    Approval approvalObj = new Approval();
    ApprovalDAO approvalDAOObj = new ApprovalDAO();

    static string DtmRtrmnt = "";
    static double PfCrdt = 0;
    static int intDesigId;
    static int ReqId = 0;
    static int NumEmpId = 0;
    static double FltOrgTAAmt = 0;
    static int IntDesigId = 0;
    static double FltPFCresdit = 0;
    static double FltMaxAdmsblTA = 0;
    static double FltPndingAmt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
            //if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            //{
            if (Convert.ToInt16(Request.QueryString["k"]) > 0)
            {
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            }
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
                Session["IntFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    btnSec.Visible = true;
                    btnSec.Text = "Back to inbox";
                    btnSec.PostBackUrl = "~/Contents/InboxSub.aspx";
                    Session["intTrnType"] = 7;
                    FillSubnChgDet();
                    SetControls();
                }
                else
                {
                    gblObj.MsgBoxOk("No data!", this);
                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 1)        //Through view
            {
                //Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["numTrnID"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    btnSec.Visible = true;
                    btnSec.Text = "Back to view";
                    btnSec.PostBackUrl = "~/Contents/View.aspx";
                    Session["intTrnType"] = 7;
                    FillSubnChgDet();
                    SetControls();
                }
            }
            else
            {
                Session["NumServiceTrnID"] = 0;
                btnSec.Visible = false;
                //SetControls();
            }
        }
    }
    private void SetControls()
    {
        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();

        //if (gblObj.IntAppFlgInbox == 1)
        //{
        //    gblObj.IntFlgOrg = Convert.ToInt16(Session["intFlgAppInbx"]);
        //}
        //else if (gblObj.IntAppFlgInbox == 2)
        //{
        //    gblObj.IntFlgOrg = Convert.ToInt16(Session["intFlgRejInbx"]);
        //}
        //else
        //{
        //    //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
        //}
        
        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        arr.Add(Session["NumServiceTrnID"]);
        //arr.Add(gblObj.IntFlgOrg);
        arr.Add(Convert.ToInt16(Session["IntFlgOrg"]));
        dsE = Kgen.GetEnableStatus(arr);
        if (dsE.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsE.Tables[0].Rows[0].ItemArray[0]) == true)
            {
                EnbleControls();
            }
            else
            {
                DisableControls();
            }
        }
    }
    private void ClearControls()
    {
        //txtInwNo.ReadOnly = true   ;
        txtAppDate.Text  = "";
        lblNameApplDisp.Text = "";
        txtCSubnAmt.Text = "";      
        txtPSubnAmt.Text = "";
        
    }
    private void EnbleControls()
    {
        //txtInwNo.ReadOnly = true   ;
        txtAppDate.ReadOnly = false;
        txtAppDate.Enabled = true;
        txtEmpID.ReadOnly = false ;
        txtPSubnAmt.ReadOnly = false;
        btnSave.Enabled = true;
    }
    private void DisableControls()
    {
        //txtInwNo.ReadOnly = true ;
        txtAppDate.ReadOnly = true;
        txtAppDate.Enabled = false;
        txtEmpID.ReadOnly = true;
        txtPSubnAmt.ReadOnly = true;
        btnSave.Enabled = false ;
    }
    private void FillSubnChgDet()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Session["NumServiceTrnID"]);
        ds = SubnDao.GetSubnChgDetails(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            //txtFileNo.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            //gblObj.StrFileNo = txtFileNo.Text.ToString();
            txtAppDate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txtEmpID.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            GetEmpName();
            txtCSubnAmt.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtPSubnAmt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        }
    }
    //protected void txtInwNo_TextChanged(object sender, EventArgs e)
    //{
    //    gblObj.FillFileNo(txtInwNo, txtFileNo, Session["File"].ToString(), this, Convert.ToInt32(Session["intLBID"]));
    //    //txtFileNo.Text = "";
    //    //txtAppDate.Text = "";
    //    //if (txtInwNo.Text != "")
    //    //{

    //    //    ArrayList ArrIn = new ArrayList();
    //    //    DataSet ds = new DataSet();
    //    //    ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
    //    //    ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
    //    //    ds = gen.CheckDuplicateInwardNo(ArrIn);
    //    //    if (ds.Tables[0].Rows.Count > 0)
    //    //    {
    //    //        gblObj.MsgBoxOk("Duplicate inward No.", this);
    //    //    }
    //    //    else
    //    //    {
    //    //        txtFileNo.Text = Session["File"] + "/" + txtInwNo.Text + "/" + DateTime.Now.Year.ToString();
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    gblObj.MsgBoxOk("Enter inward No.", this);
    //    //}
    //}
    protected void txtEmpID_TextChanged(object sender, EventArgs e)
    {
        ClearControls();
        fillEmpdet();
    }
    private void GetEmpName()
    {
        if (txtEmpID.Text != "")
        {
            DataSet ds = new DataSet();
            Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
            emp.NumEmpID = Convert.ToInt64(Session["NumEmpId"]);
            ds = empDoa.GetEmployeeBasicDet(emp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblDesig.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtCSubnAmt.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                Session["flgClosed"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[23].ToString());
            }
        }
    }
    private void CreateSubnChngRequest()
    {
        DataSet ds = new DataSet();
        Subn.SubnChangeId = Convert.ToInt64(Session["NumServiceTrnID"]);
        Subn.NumEmpId = Convert.ToInt64(Session["NumEmpId"]);
        //Subn.IntYearId = FindYrId(txtAppDate);

        ArrayList ar = new ArrayList();
        ar.Add(txtAppDate.Text.ToString());
        Subn.IntYearId = Kgen.gFunFindYearIdFromDate(ar);

        Subn.IntMonthId = Convert.ToInt16(Convert.ToDateTime(txtAppDate.Text).Month);
        
        Subn.FltOldSubnAmt = Convert.ToDouble(txtCSubnAmt.Text);
        Subn.FltProposedSubnAmt = Convert.ToDouble(txtPSubnAmt.Text);
        Subn.FltNewSubnAmt = Convert.ToDouble(txtPSubnAmt.Text);
        Subn.FlgChangeType = lFunFindType();
        Subn.IntUserId = Convert.ToInt32(Session["intUserId"]);
        Subn.DtApp = txtAppDate.Text.ToString();
        SubnDao.CreateSubnChange(Subn);
    }
    protected void btnDet_Click(object sender, EventArgs e)
    {       
        if (txtEmpID.Text != "")
        {
            pnlEmpDet.Visible = true;
            fillEmpdet();
            SetControls();
        }
        else
        {
            gblObj.MsgBoxOk("Please enter account number", this);
        }

    }
    private void fillEmpdet() //
    {
        Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        GetEmpName();
        if (Convert.ToInt16(Session["flgClosed"]) == 0 || Convert.ToInt16(Session["flgClosed"]) == 2)
        {
            if (gblObj.WhetherLBMatch(Convert.ToInt64(Session["NumEmpId"]), Convert.ToInt16(Session["intLBId"])) == true)
            {
                FillBasicDet();
                if (Eligible() == true)
                {
                    EnbleControls();
                }
                else
                {
                    gblObj.MsgBoxOk("Already Applied", this);
                    DisableControls();
                    txtEmpID.ReadOnly = false;
                    txtEmpID.Enabled = true;
                    txtEmpID.Text = "";
                }
            }
            else
            {
                gblObj.MsgBoxOk("Not beleongs to this Localbody!", this);
                txtEmpID.Text = "";
                lblNameApplDisp.Text = "";
                txtPSubnAmt.Text = "";
            }
        }
        else 
        {
            gblObj.MsgBoxOk("Closed Account!", this);
            txtEmpID.Text = "";
            lblNameApplDisp.Text = "";
            txtPSubnAmt.Text = "";
        }
    }
    private void FillBasicDet()
    {
        if (txtEmpID.Text != "")
        {
            DataSet ds = new DataSet();
            Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
            emp.NumEmpID = Convert.ToInt64(Session["NumEmpId"]);
            ds = empDoa.GetEmployeeBasicDet(emp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                lblDesig.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                DtmRtrmnt = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                if (ds.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    PfCrdt = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[5]);
                }
                else
                {
                    PfCrdt = 0;
                }
                if (ds.Tables[0].Rows[0].ItemArray[10].ToString() != "")
                {
                    intDesigId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[10]);
                }
                else
                {
                    intDesigId = 0;
                }
                txtEmpID.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                lblPFNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                //lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                //lblDesig.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                lblPFCr.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                lblLoanOutstnd.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                lblBPay.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                lblDBirth.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                lblJoinDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                lblDRetire.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                lblDEnroll.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();

                NumEmpId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[8].ToString());
                ///TA////
                FltPndingAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[15].ToString());
                FltOrgTAAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[6].ToString());
                //IntDesigId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[10].ToString());
                FltPFCresdit = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[5].ToString());
                FltMaxAdmsblTA = ((3 * FltPFCresdit) - FltPndingAmt) / 4;
                DtmRtrmnt = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                lblAdmloan.Text = FltMaxAdmsblTA.ToString(); ;
            }
        }
    }

    public int lFunFindType()
    {
        int intChangeType = 1;
        if (Convert.ToDouble(txtCSubnAmt.Text) < Convert.ToDouble(txtPSubnAmt.Text))
        {
            intChangeType = 1;
        }
        else
        {
            intChangeType = 2;
        }
        return intChangeType;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateCtrls() == true)
        {
            if (Eligible() == true)
            {
                CreateSerTrn();
                CreateSubnChngRequest();
                if (Convert.ToInt16(Session["intMenuItem"]) == 3)        //Not Through Inbox
                {
                    //gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt64(Session["NumServiceTrnID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]), "");
                    Approval(Convert.ToInt16(Session["intFlgApp"]));
                }
                gblObj.MsgBoxOk("Saved!",this);
            }
            else
            {
                gblObj.MsgBoxOk("You are not eligible.", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("", this);
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
    private void CreateSerTrn()
    {
        ArrayList ar = new ArrayList();
        if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
        {
            ar.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
        }
        else
        {
            ar.Add(0);
        }
        //ar.Add(txtFileNo.Text.Trim());
        ar.Add(0);
        ar.Add(Session["NumEmpId"]);
        ar.Add(Convert.ToInt16(Session["intLBID"]));
        ar.Add(Convert.ToInt16(Session["intTrnType"]));
        ar.Add(txtAppDate.Text);
        ar.Add(Convert.ToInt64(Session["intUserId"]));
        //ar.Add(Convert.ToInt16(txtInwNo.Text));
        //ar.Add(0);
        DataSet ds = Kgen.CreateServiceTransaction(ar);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Session["NumServiceTrnID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    private Boolean ValidateCtrls()
    {
        Boolean flg = true;
        //if (txtInwNo.Text == "")
        //{
        //    flg = false;
        //    gblObj.MsgBoxOk("Enter inward No.", this);
        //}
        //else
        if (txtEmpID.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Acc. No.", this);
        }
        
        else if (txtPSubnAmt.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter proposed amount", this);
        }
        else if (txtAppDate.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Date of Application", this);
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private Boolean Eligible()
    {
        Boolean eligbl;
        if (Convert.ToInt64(Session["NumServiceTrnID"]) != 0)
        {
            eligbl = true;
        }
        else
        {
            DataSet dsV = new DataSet();
            ArrayList vArrIn = new ArrayList();
            vArrIn.Add(Session["NumEmpId"]);
            vArrIn.Add(Convert.ToInt32(Session["intTrnType"]));
            //vArrIn.Add(txtAppDate.Text.ToString());
            vArrIn.Add(DateTime.Now.ToShortDateString());
            dsV = Kgen.ValidateEligibility(vArrIn);
            if (dsV.Tables[0].Rows[0].ItemArray[0].ToString() == "1")
            {
                eligbl = false;
            }
            else
            {
                eligbl = true;
            }
        }
        return eligbl;
    }
    protected void OkBtn_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = false;
    }
    protected void txtAppDate_TextChanged(object sender, EventArgs e)
    {
        if (txtAppDate.Text != "")
        {
            if (gblObj.CheckAppDate(txtAppDate, this) == true)
            {
                
            }
            //if (gblObj.isValidDate(txtAppDate, this) == true)
            //{
            //    if (gblObj.CheckDateInBetween(txtAppDate, gblobj.GenerateStartDate("2001-02", 4)) == true)
            //    {
            //    }
            //    else
            //    {
            //        gblObj.MsgBoxOk("Invalid Date", this);
            //        txtAppDate.Text = "";
            //    }
            //}
            //else
            //{
            //    gblObj.MsgBoxOk("Invalid Date", this);
            //    txtAppDate.Text = "";
            //}
        }

    }
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
}
