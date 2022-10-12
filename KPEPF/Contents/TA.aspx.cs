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
using System.Net;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KPEPFClassLibrary;

public partial class Contents_TANew : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();
    ApprovalDAO apprDao = new ApprovalDAO();

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
            //if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            //{
            //    gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //}

            //InitialSettings();
            //fpUpload.Attributes.Add("onchange", "return checkFileExtension(this);");
            //if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            //{
            //    btnSec.Visible = true;
            //    btnSec.Text = "Back to inbox";
            //    btnSec.PostBackUrl = "~/Contents/InboxService.aspx";
            //    if (Convert.ToInt64(Request.QueryString["TAReqID"]) > 0)
            //    {
            //        Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
            //    }
            //    AddLinkButtons();
            //    if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
            //    {
            //        FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
            //        SetControls();
            //        FillBasicDet();
            //    }
            //}
            //else if (Convert.ToInt16(Session["intMenuItem"]) == 1)        //Through view
            //{
            //    if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
            //    {
            //        btnSec.Visible = true;
            //        btnSec.Text = "Back to view";
            //        btnSec.PostBackUrl = "~/Contents/View.aspx";
            //        FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
            //        SetControls();
            //        FillBasicDet();
            //    }
            //}

            //else if (Convert.ToInt16(Session["intMenuItem"]) == 20)        //Through Rej after App
            //{
            //    btnSec.Visible = true;
            //    btnSec.Text = "Back to Rejection";
            //    btnSec.PostBackUrl = "~/Contents/CorrInApp.aspx";
            //    Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
            //    FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
            //    DisableControls();
            //    FillBasicDet();
            //}

            InitialSettings();
            fpUpload.Attributes.Add("onchange", "return checkFileExtension(this);");
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                btnSec.Visible = true;
                btnSec.Text = "Back to inbox";
                btnSec.PostBackUrl = "~/Contents/InboxService.aspx";
                if (Convert.ToInt64(Request.QueryString["TAReqID"]) > 0)
                {
                    Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
                }
                AddLinkButtons();
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
                    SetControls();
                    FillBasicDet();
                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 1)        //Through view
            {
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    btnSec.Visible = true;
                    btnSec.Text = "Back to view";
                    btnSec.PostBackUrl = "~/Contents/View.aspx";
                    FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
                    SetControls();
                    FillBasicDet();
                }
            }

            else if (Convert.ToInt16(Session["intMenuItem"]) == 20)        //Through Rej after App
            {
                btnSec.Visible = true;
                btnSec.Text = "Back to Rejection";
                btnSec.PostBackUrl = "~/Contents/CorrInApp.aspx";
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
                FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
                DisableControls();
                FillBasicDet();
            }
            else
            {
                if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
                {
                    gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
                }
            }
        }
    }
    private void InitialSettings()
    {
        gblObj.IntOldTrnType = Convert.ToInt16(Session["intTrnType"]);
        if (Convert.ToInt16(Session["intTrnType"]) == 2)
        {
            lblHead.Text = "Temparory advance";
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 3)
        {
            lblHead.Text = "Temparory advance > 75000";
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            lblHead.Text = "Temparory advance > 200000";
        }
        FillLoanPurpose();
        AddLinkButtons();
        if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
        {
            FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
            //SetControls();
            FillBasicDet();
        }
    }
    private void SetControls()
    {
        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();
        if (gblObj.IntAppFlgInbox == 1)
        {
            gblObj.IntFlgOrg = Convert.ToInt16(Session["intFlgAppInbx"]);
        }
        else if (gblObj.IntAppFlgInbox == 2)
        {
            gblObj.IntFlgOrg = Convert.ToInt16(Session["intFlgRejInbx"]);
        }
        else
        {
            //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
        }
        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        //arr.Add(Convert.ToInt16(Session["intTrnType"]));
        arr.Add(Session["NumServiceTrnID"]);
        arr.Add(gblObj.IntFlgOrg);
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
    private void EnbleControls()
    {
        txtEmpID.ReadOnly = true;
        txtInwNo.ReadOnly = true;
        txtAppDate.ReadOnly = false;
        txtAppDate.Enabled = true;
        txtPropAmt.ReadOnly = false;
        txtPropInst.ReadOnly = false;
        ddlPurpose.Enabled = true;
        btnSave.Enabled = true;
        fpUpload.Enabled = true;
        btnSubmit.Enabled = true;
    }
    private void DisableControls()
    {
        txtEmpID.ReadOnly = true;
        txtInwNo.ReadOnly = true;
        txtAppDate.ReadOnly = true;
        txtAppDate.Enabled = false;
        txtPropAmt.ReadOnly = true;
        txtPropInst.ReadOnly = true;
        ddlPurpose.Enabled = false;
        btnSave.Enabled = false;
        fpUpload.Enabled = false;
        btnSubmit.Enabled = false;
    }
    protected void txtInwNo_TextChanged(object sender, EventArgs e)
    {
        gblObj.FillFileNo(txtInwNo, txtFileNo, Session["File"].ToString(), this, Convert.ToInt32(Session["intLBID"]));
        //txtFileNo.Text = "";
        //txtAppDate.Text = "";
        //if (txtInwNo.Text != "")
        //{

        //    ArrayList ArrIn = new ArrayList();
        //    DataSet ds = new DataSet();
        //    ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
        //    ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
        //    ds = gen.CheckDuplicateInwardNo(ArrIn);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        gblObj.MsgBoxOk("Duplicate inward No.",this );
        //    }
        //    else
        //    {
        //        txtFileNo.Text = Session["File"] + "/" + txtInwNo.Text + "/" + DateTime.Now.Year.ToString(); 
        //        //strFileNo = Session["File"] + "/" + txtInwNo.Text + "/" + DateTime.Now.Year.ToString();
                
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter inward No.",this );
        //}
    }
    protected void txtAdmAmt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtPropInst_TextChanged(object sender, EventArgs e)
    {
        if (ValidateInst() == true)
        {
            CheckAndFill();
          
        }
        else
        {
            txtPropInst.Text = "0";
            gblObj.MsgBoxOk("Instalment should be between 12 and 36!", this);
        }
        if (lblConsAmt.Text != "" && txtAdmAmt.Text != "")
        {
            txtConsAmt.Text = Convert.ToString(Convert.ToInt64(lblConsAmt.Text.ToString()) + Convert.ToInt64(txtAdmAmt.Text.ToString()));
        }
    }
    private void FindInstAmt()
    {

        double InstAmt = 0;
        double ConsAmt;
        double rndInstAmt;
        double rndAdmAmt;

        //lblConsAmt.Text = FltPndingAmt.ToString();
        ConsAmt = Convert.ToDouble(txtPropAmt.Text) + FltPndingAmt;
        //lblConsAmt.Text = ConsAmt.ToString();
        InstAmt = ConsAmt / Convert.ToDouble(txtPropInst.Text);
        rndInstAmt = InstAmt - (InstAmt % 10);
        rndAdmAmt = rndInstAmt * Convert.ToDouble(txtPropInst.Text);
        lblRepay.Text = rndInstAmt.ToString();
        //txtAdmAmt.Text = rndAdmAmt.ToString();
        txtAdmAmt.Text = Convert.ToString(rndAdmAmt - FltPndingAmt);
    }
    private void FindInstAmt4FirsttimeEntry()
    {

        double InstAmt = 0;
        double ConsAmt;
        double rndInstAmt;
        double rndAdmAmt;

        lblConsAmt.ReadOnly = false;

        if (lblConsAmt.Text != "")
        {
            ConsAmt = Convert.ToDouble(txtPropAmt.Text) + Convert.ToDouble(lblConsAmt.Text);
        }
        else
        {
            ConsAmt = Convert.ToDouble(txtPropAmt.Text) + 0;
        }
        //lblConsAmt.Text = ConsAmt.ToString();
        InstAmt = ConsAmt / Convert.ToDouble(txtPropInst.Text);
        rndInstAmt = InstAmt - (InstAmt % 10);
        rndAdmAmt = rndInstAmt * Convert.ToDouble(txtPropInst.Text);
        lblRepay.Text = rndInstAmt.ToString();
        //txtAdmAmt.Text = rndAdmAmt.ToString();
        if (lblConsAmt.Text != "")
        {
            txtAdmAmt.Text = Convert.ToString(rndAdmAmt - Convert.ToDouble(lblConsAmt.Text));
        }
        else
        {
            txtAdmAmt.Text = Convert.ToString(rndAdmAmt - 0);
        }
    }
    protected void txtPropAmt_TextChanged(object sender, EventArgs e)
    {
        CheckAndFill();
        if (lblConsAmt.Text != "" && txtAdmAmt.Text != "")
        {
            txtConsAmt.Text = Convert.ToString(Convert.ToInt64(lblConsAmt.Text.ToString()) + Convert.ToInt64(txtAdmAmt.Text.ToString()));
        }
    }
    private Boolean ValidateInst()
    {
        Boolean flg = false;
        if (txtPropInst.Text == null || txtPropInst.Text.Trim() == "")
        {
            txtPropInst.Text = "0";
            flg = false;
        }
        else
        {
            if (Convert.ToInt16(txtPropInst.Text) < 12 || Convert.ToInt16(txtPropInst.Text) > 36)
            {
                flg = false;
            }
            else
            {
                flg = true;
            }
        }
        return flg;
    }
    private void CheckAndFill()
    {
        if (txtPropInst.Text == null || txtPropInst.Text.Trim() == "")
        {
            txtPropInst.Text = "0";
        }
        if (txtPropAmt.Text == null || txtPropAmt.Text.Trim() == "")
        {
            txtPropAmt.Text = "0";
        }
        if (txtPropInst.Text != "0")
        {
            if (Convert.ToInt64(Session["NumEmpId"]) > 0 || txtEmpID.Text != "")
            {
                DataSet ds = new DataSet();
                ArrayList arraIn=new ArrayList();
                arraIn.Add(Convert.ToInt32(txtEmpID.Text));
                 ds = empDoa.GetConsolidatedTA(arraIn);
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     lblConsAmt.ReadOnly = true;
                     FindInstAmt();

                 }
                 else
                 {
                     lblConsAmt.ReadOnly = false;
                     //lblConsAmt.Text = "0";
                     FindInstAmt4FirsttimeEntry();
                     //lblRepay.Text = "0";
                 }
            }
            //else
            //{
            //    lblConsAmt.Text = "0";
            //    lblRepay.Text = "0";
            //}
        }
        
    }
    private void DisableCtrls4TA()
    {
        lblInst.Enabled=false;
        txtPropInst.Enabled=false;
        Label1.Enabled=false;
        lblConsAmt.Enabled=false;
        Label3.Enabled=false;
        lblRepay.Enabled=false;
        lblAdmAmt.Enabled=false;
        txtAdmAmt.Enabled=false;
        btnSave.Enabled = false;
    }
    private void EnableCtrls4TA()
    {
        lblInst.Enabled = true;
        txtPropInst.Enabled = true;
        Label1.Enabled = true;
        lblConsAmt.Enabled = true;
        Label3.Enabled = true;
        lblRepay.Enabled = true;
        lblAdmAmt.Enabled = true;
        txtAdmAmt.Enabled = true;
        btnSave.Enabled = true;
    }
    protected void btnDet_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = true;
    }
    private void FillLoanPurpose()
    {
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(1);
        DataSet ds = new DataSet();
        ds = Kgen.GetLoanPurpose(ArrIn);
        gblObj.FillCombo(ddlPurpose, ds, 1);

    }
    protected void txtEmpID_TextChanged(object sender, EventArgs e)
    {
        //Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        if (gblObj.WhetherLBMatch(Convert.ToInt64(Session["NumEmpId"]),Convert.ToInt16(Session["intLBID"])) == true)
        {
            gblObj.UpdateArrearToCredit();
            FillBasicDet();
            if (Eligible() == true)
            {
                txtAdmAmt.Text = "";
                txtPropAmt.Text = "";
                txtPropInst.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Not beleongs to this Localbody!", this);
            txtEmpID.Text = "";
        }
    }
    //private void UpdateArrearToCredit()
    //{
    //    ArrayList arr = new ArrayList();
    //    arr.Add(Session["NumEmpId"]);
    //    empDoa.UpdateArrearToCredit(arr);
    //}
    private void FillBasicDet()
    {
        if (txtEmpID.Text != "")
        {
            //UpdateArrearToCredit();
            DataSet ds = new DataSet();
            //Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
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
   private void FillTADetails(double  withReqId)
    {
        DataSet ds=new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(withReqId);
        ds = TAReqDao.GetTADetails(arrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txtFileNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                gblObj.StrFileNo = txtFileNo.Text.ToString();
            }
            else
            {
                txtFileNo.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[1].ToString() != "")
            {
                txtAppDate.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);
            }
            else
            {
                txtAppDate.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[9].ToString() != "")
            {
                txtEmpID.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                Session["NumEmpId"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[9]);
            }
            else
            {
                txtEmpID.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() != "")
            {
                lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            else
            {
                lblNameApplDisp.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[4].ToString() != "")
            {
                txtPropAmt.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            }
            else
            {
                txtPropAmt.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[6].ToString() != "")
            {
                txtPropInst.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            }
            else
            {
                txtPropInst.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[13].ToString() != "")
            {
                lblRepay.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            }
            else
            {
                lblRepay.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[5].ToString() != "")
            {
                txtAdmAmt.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            }
            else
            {
                txtAdmAmt.Text = "";
            }

            if (ds.Tables[0].Rows[0].ItemArray[15].ToString() != "")
            {
                lblConsAmt.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            }
            else
            {
                lblConsAmt.Text = "0";
            }

            if (txtAdmAmt.Text != "0")
            {
                txtConsAmt.Text = Convert.ToString(Convert.ToInt64(lblConsAmt.Text.ToString()) + Convert.ToInt64(txtAdmAmt.Text.ToString()));
            }
            ddlPurpose.SelectedValue = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        }
    }
    private Int64 FindConsAmt()
    {
        Int64 fltAmt = 0;
        if (Convert.ToInt64(txtPropInst.Text) > 0 && Convert.ToInt64(lblRepay.Text) > 0 && Convert.ToInt64(txtAdmAmt.Text) > 0)
        {
            fltAmt = (Convert.ToInt64(txtPropInst.Text) * Convert.ToInt64(lblRepay.Text)) - Convert.ToInt64(txtAdmAmt.Text);
        }
        return fltAmt;
    }
    //private Int64 FindConsAmtOrg()
    //{
    //    Int64 fltAmtO = 0;
    //    fltAmtO = (Convert.ToInt64(txtPropInst.Text) * Convert.ToInt64(lblRepay.Text)) - Convert.ToInt64(txtAdmAmt.Text);
    //    return fltAmtO;
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateCtrls() == true)
        {
            if (Eligible() == true)
            {
                if (ValidateFieldsTA(ddlPurpose, txtPropAmt, txtPropInst) == true)
                {
                    FindTrnType();
                    CreateSerTrn();
                    CreateTARequest();
                    if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
                    {
                        gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt64(Session["NumServiceTrnID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]), "");
                    }
                    else
                    {
                        if (gblObj.IntOldTrnType != Convert.ToInt16(Session["intTrnType"]))
                        {
                            gblObj.UppdApprovalTrnType(gblObj.IntOldTrnType, Convert.ToInt16(Session["intTrnType"]), Convert.ToInt64(Session["NumServiceTrnID"]), Convert.ToInt32(Session["intUserId"]));
                        }
                    }
                    gblObj.MsgBoxOk("Saved Successfully", this);
                    fpUpload.Enabled = true;
                }
                else
                {
                }
            }
            else
            {
                gblObj.MsgBoxOk("", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("", this);
        }
    }
    private void FindTrnType()
    {
        if (Convert.ToInt64(txtAdmAmt.Text) > 200000)
        {
            Session["intTrnType"] = 31;
        }
        else if (Convert.ToInt64(txtAdmAmt.Text) > 75000)
        {
            Session["intTrnType"] = 3;
        }
        else
        {
            Session["intTrnType"] = 2;
        }
        //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
    }
    public Boolean ValidateFieldsTA(DropDownList ddl, TextBox Ta2, TextBox Ta3)
    {
        bool Valid;
        Valid = false;
        if (Convert.ToInt16(ddl.SelectedItem.Value.ToString()) < 0)
        {
            gblObj.MsgBoxOk("SelectPurpose", this);
        }
        else if (Ta2.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter amount", this); ;
        }
        else if (Ta2.Text.Trim() != "")
            if (Convert.ToDouble(Ta2.Text) > FltMaxAdmsblTA)
            {
                gblObj.MsgBoxOk("Should be less than Max admissible amount!", this);
            }
            else if (Ta3.Text.Trim() == "")
            {
                gblObj.MsgBoxOk("Enter instalment amount", this);
            }
            else if (Ta3.Text.Trim() != "")
            {
                if (Convert.ToInt16(Ta3.Text) < 12 || Convert.ToInt16(Ta3.Text) > 36)
                {
                    gblObj.MsgBoxOk("Instalment should be < 36 and > 12!", this);
                }
                else
                {
                    Valid = true;
                }
            }
            else
            {
                gblObj.MsgBoxOk("Saved", this);
                Valid = true;
            }
        return Valid;

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
        ar.Add(txtFileNo.Text);
        ar.Add(Session["NumEmpId"]);
        ar.Add(Convert.ToInt16(Session["intLBID"]));
        ar.Add(Convert.ToInt16(Session["intTrnType"]));
        ar.Add(txtAppDate.Text);
        ar.Add(Convert.ToInt64(Session["intUserId"]));
        ar.Add(Convert.ToInt16(txtInwNo.Text));
        //ar.Add(Convert.ToInt16(Convert.ToInt16(Session["intTrnTypeStage"])));
        DataSet ds = Kgen.CreateServiceTransaction(ar);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Session["NumServiceTrnID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    private void CreateTARequest()
    {
        DataSet ds = new DataSet();

        TAReq.IntYearId = Convert.ToDateTime(txtAppDate.Text).Year;
        TAReq.IntMonthId = Convert.ToDateTime(txtAppDate.Text).Month;

        TAReq.ChvFileNo = txtFileNo.Text;
        TAReq.NumEmpId = Convert.ToInt64(Session["NumEmpId"]);
        TAReq.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
        TAReq.FltAmtProposed = Convert.ToDouble(txtPropAmt.Text);
        TAReq.FltAmtAdmissible = Convert.ToDouble(txtAdmAmt.Text);
        TAReq.IntNoOfInstProposed = Convert.ToInt16(txtPropInst.Text);
        TAReq.IntPurposeID = Convert.ToInt16(ddlPurpose.SelectedValue);
        TAReq.DtmDateOfRequest = txtAppDate.Text;
        TAReq.IntUesrID = Convert.ToInt32(Session["intUserId"]);
        if (IntDesigId != 0)
        {
            TAReq.IntDesigID = IntDesigId;
        }
        else
        {
            TAReq.IntDesigID = 0;
        }
        TAReq.FltInstAmount = Convert.ToDouble(lblRepay.Text);
        TAReq.NumWithRequestID = Convert.ToInt64(Session["NumServiceTrnID"]);
        if (lblConsAmt.Text.ToString() != "")
        {
            TAReq.FltOutstandingAmount = Convert.ToInt64(lblConsAmt.Text.ToString());
        }
        else
        {
            TAReq.FltOutstandingAmount = 0;
        }
        TAReqDao.CreateTARequest(TAReq);
    }

    private Boolean Eligible()
    {
        Boolean ValidFlg;
        if (RtrmntVldtion() == true)
        {
            if (SixMnthsValdtion() == true)
            {
                if (ChkCredit() == true)
                {
                    ValidFlg = true;
                }
                else
                {
                    ValidFlg = false;
                    gblObj.MsgBoxOk("Insufficient PF Credit", this);
                }
            }
            else
            {
                ValidFlg = false;
                gblObj.MsgBoxOk("Employee already applied for TA", this);
            }
        }
        else
        {
            ValidFlg = false;
            gblObj.MsgBoxOk("Retirement date Must less than 1 year ", this);
        }
        return ValidFlg;
    }
    private Boolean ChkCredit()
    {
        Boolean Vald;
        if (PfCrdt <= 0)
        {
            Vald = false;
        }
        else
        {
            Vald = true;
        }
        return Vald;
    }
    private Boolean SixMnthsValdtion()
    {
        Boolean Vald;
        DataSet dsV = new DataSet();
        ArrayList vArrIn = new ArrayList();
        vArrIn.Add(Session["NumEmpId"]);
        vArrIn.Add(Convert.ToInt16(Session["intTrnType"]));
        vArrIn.Add(txtAppDate.Text.ToString());
        dsV = gen.ValidateEligibility(vArrIn);
        if (Convert.ToInt16(dsV.Tables[0].Rows[0].ItemArray[0]) > 0)
        {
            Vald = false;
        }
        else
        {
            Vald = true;
        }
        return Vald;
    }
    private Boolean RtrmntVldtion()
    {
        Boolean Vald;
        if (DtmRtrmnt != "" && txtAppDate.Text.ToString()!="")
        {
            DateTime RetDt = new DateTime();
            DateTime ToDt = new DateTime();
            RetDt = Convert.ToDateTime(DtmRtrmnt);
            //ToDt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ToDt = Convert.ToDateTime(txtAppDate.Text);
            TimeSpan DaysCnt;
            DaysCnt = RetDt.Subtract(ToDt);

            if (DaysCnt.Days < 365)
            {
                Vald = false;
            }
            else
            {
                Vald = true;
            }
            return Vald;
        }
        else
        {
            Vald = true;
            return Vald;
        }
    }
    private Boolean ValidateCtrls()
    {
        Boolean flg = true;
        if (txtInwNo.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter inward No.",this);
        }
        else if (txtEmpID.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Acc. No.",this);
        }
        else if (txtAppDate.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Application Date.", this);
        }
        else if (ddlPurpose.SelectedValue == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Select purpose", this);
        }
        else if (txtPropAmt.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter proposed amount", this);
        }
        else if (txtPropInst.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter instalment amount", this);
        }
        //else if (lblConsAmt.Text == "")
        //{
        //    flg = false;
        //    gblObj.MsgBoxOk("Enter consolidate amount",this);
        //}
        else if (lblRepay.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter repayment",this );
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    protected void OkBtn_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = false;
    }
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void lblRepay_TextChanged(object sender, EventArgs e)
    {

    }
    protected void lblConsAmt_TextChanged(object sender, EventArgs e)
    {
        FindInstAmt4FirsttimeEntry();
        if (Convert.ToInt64(lblConsAmt.Text) > 0 && Convert.ToInt64(txtAdmAmt.Text) > 0)
        {
            txtConsAmt.Text = Convert.ToString(Convert.ToInt64(lblConsAmt.Text.ToString()) + Convert.ToInt64(txtAdmAmt.Text.ToString()));
        }
    }
    protected void txtAppDate_TextChanged(object sender, EventArgs e)
    {
        if (txtAppDate.Text != "")
        {
            if (Convert.ToDateTime(txtAppDate.Text).Date > DateTime.Now.Date)
            {
                txtAppDate.Text = "";
            }
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
       
            AddLinkButtons();
        

    }
    protected void txtConsAmt_TextChanged(object sender, EventArgs e)
    {

    }
    private void AddLinkButtons()
    {
        phLinkButtons.Controls.Clear();
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        //ArrIn.Add(Request.QueryString["FileID"].ToString());
        ArrIn.Add(Session["NumServiceTrnID"]);
        ds = TAReqDao.GetAttatchmentDet(ArrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string AttPath1 = Request.PhysicalApplicationPath + "files" + "\\";
          //  String AttPath1 = ConfigurationManager.AppSettings["Attpath1"].ToString();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Session["fileUrls"] = AttPath1 + ds.Tables[0].Rows[i][0].ToString();
                string fileUrls = Session["fileUrls"].ToString();
                string fileNames = ds.Tables[0].Rows[i][0].ToString();
               // strDownloadPdfLink = "/Documents/PressPack.pdf";
                //HyperLink lnkDownloadHSPressPack = new HyperLink();
                //lnkDownloadHSPressPack.Attributes.Add("onclick", "InitializeRequest('" + fileNames + "');");
                LinkButton lb = new LinkButton();
                LinkButton Dlt = new LinkButton();
                lb.Text = "Download Attachment: " + fileNames;
                phLinkButtons.Controls.Add(lb);

                Dlt.Text = "Delete";
                phLinkButtons.Controls.Add(Dlt);

                //  lb.CssClass = "head5";
                lb.CommandName = "url";
                lb.CommandArgument = fileUrls;
                lb.ID = "lbFile" + i;
                //lb.Click +=this.DownloadFile;
                lb.Attributes.Add("runat", "server");
                lb.Click += new EventHandler(this.DownloadFile);

                Dlt.CommandName = "url1";
                Dlt.CommandArgument = fileUrls;
                Dlt.ID = ds.Tables[0].Rows[i][2].ToString();
                //lb.Click +=this.DownloadFile;
                Dlt.Attributes.Add("runat", "server");
                Dlt.Click += new EventHandler(this.Delete_File);


                ////lb.Command += new CommandEventHandler(DownloadFile);
                phLinkButtons.Controls.Add(lb);
                phLinkButtons.Controls.Add(new LiteralControl("&nbsp&nbsp&nbsp&nbsp"));
                phLinkButtons.Controls.Add(Dlt);
                phLinkButtons.Controls.Add(new LiteralControl("<br>"));

                Session.Remove("HDID");

            }
        }
    }
    protected void DownloadFile(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string url = lb.CommandArgument;

        System.IO.FileInfo file = new System.IO.FileInfo(url);


        if (file.Exists)
        {
            try
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            catch (Exception)
            {

            }
        }
        else
        {
            Response.Write("This file does not exist.");
        }
    }

    protected void Delete_File(object sender, EventArgs e)
    {
        string destination = string.Empty;
        string ID = string.Empty;
        LinkButton Dlt = (LinkButton)sender;
        destination = Dlt.CommandArgument;
        ID = Dlt.ID;
        File.Delete(destination);
        string strSql = "";
        strSql = "Delete Images WHERE intID=" + Convert.ToInt32(ID);
        TAReqDao.getSearchList(strSql);
        AddLinkButtons();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (fpUpload.HasFile)
        {
			int val = 0;
    
			String FilePath = fpUpload.PostedFile.FileName;
			String Extension = Path.GetExtension(FilePath);
            //String AttPath1 = ConfigurationManager.AppSettings["files"].ToString();
            //string[] GFiles = fpUpload.FileName.Split('.');
            //if (Extension == ".jpg")
            //{
            //    fpUpload.SaveAs(AttPath1 + GFiles[0] + "-" + ".jpg");
            //    val = 1;
            //}
            //if (Extension == ".jpeg")
            //{
            //    fpUpload.SaveAs(AttPath1 + GFiles[0] + "-" + ".jpeg");
            //    val = 1;
            //}
            if (fpUpload.HasFile)
                // Call a helper method routine to save the file.
                SaveFile(fpUpload.PostedFile);
            else
                // Notify the user that a file was not uploaded.
                lblOutput.Text = "You did not specify a file to upload.";
            //if (val == 1)
            //{
                // lblAtt.Text = "";
                // Create SQL Connection 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings
                                        //["ConString"].ConnectionString;
                                      ["KPEPF_OnlineConnectionString1"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Images(ImageName,UserID,chvExtension,flgFileType,numWithRequestID)" +
                                  " VALUES (@ImageName,@UserID,@chvExtension,@flgFileType,@numWithRequestID)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlParameter ImageName = new SqlParameter
                                    ("@ImageName", SqlDbType.VarChar, 1000);
                ImageName.Value = fpUpload.FileName;
                cmd.Parameters.Add(ImageName);


                SqlParameter UserID = new SqlParameter
                                  ("@UserID", SqlDbType.Int);
                UserID.Value = Convert.ToInt32(Session["intUserId"].ToString());
                cmd.Parameters.Add(UserID);

                SqlParameter chvExtension = new SqlParameter
                      ("@chvExtension", SqlDbType.VarChar, 50);
                chvExtension.Value = Extension;
                cmd.Parameters.Add(chvExtension);

                SqlParameter flgFileType = new SqlParameter
                ("@flgFileType", SqlDbType.Int);
                flgFileType.Value = 1;
                cmd.Parameters.Add(flgFileType);

                SqlParameter numWithRequestID = new SqlParameter
                  ("@numWithRequestID", SqlDbType.Decimal );
                numWithRequestID.Value = Session["NumServiceTrnID"];
                cmd.Parameters.Add(numWithRequestID);


                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                //string strSql = "";
                //strSql = "Update Images set numFileID=" + Convert.ToInt32(Session["HDID"]) + "Where UserID=" + Convert.ToInt32(Session["EmpID"]) + " and numFileID is null";
                //InwDAO.getSearchList(strSql);
                //AddLinkButtons();

                // SendMail(Convert.ToDouble(Session["HDID"]));
                //txtImgName.Text = "";
            //}
            //else
            //{
            //    Label1.Text = "No File Uploaded..!!";
            //}
        }
        AddLinkButtons();
    }


    void SaveFile(HttpPostedFile file)
    {
        // Specify the path to save the uploaded file to.
        
        string savePath =Request.PhysicalApplicationPath + "files"+"\\";

        // Get the name of the file to upload.
        string fileName = fpUpload.FileName;

        // Create the path and file name to check for duplicates.
        string pathToCheck = savePath + fileName;

        // Create a temporary file name to use for checking duplicates.
        string tempfileName = "";

        // Check to see if a file already exists with the
        // same name as the file to upload.        
        if (System.IO.File.Exists(pathToCheck))
        {
            int counter = 2;
            while (System.IO.File.Exists(pathToCheck))
            {
                // if a file with this name already exists,
                // prefix the filename with a number.
                tempfileName = counter.ToString() + fileName;
                pathToCheck = savePath + tempfileName;
                counter++;
            }

            fileName = tempfileName;

            // Notify the user that the file name was changed.
            lblOutput.Text = "A file with the same name already exists." +
                "<br />Your file was saved as " + fileName;
        }
        else
        {
            // Notify the user that the file was saved successfully.
            lblOutput.Text = "Your file was uploaded successfully.";
        }

        // Append the name of the file to upload to the path.
        savePath += fileName;

        // Call the SaveAs method to save the uploaded
        // file to the specified directory.
        fpUpload.SaveAs(savePath);

    }

    protected void btnABCD_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ABCD.aspx");

    }
    protected void btnService_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceHistoryEntry.aspx");
    }
    protected void btnUtili_Click(object sender, EventArgs e)
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt64(Session["NumEmpId"]));
        ds=Kgen.GetPreWithdrawal(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Redirect("Reportviewer.aspx?ReportID=5");
        }
        else
        {
            gblObj.MsgBoxOk("The Employee has no previous TA",this);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CreditCardParti.aspx");
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt64(Session["NumEmpId"]));
        ds = Kgen.GetPreWithdrawal(arr);
        //if (Convert.ToDouble(txtTotal.Text.ToString()) > 0)
        //{
            Response.Redirect("Reportviewer.aspx?ReportID=7");
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("The Employee has no Credit Card yet!", this);
        //}
    }
}
