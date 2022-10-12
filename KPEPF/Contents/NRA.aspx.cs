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

public partial class Contents_NRA : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();

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
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //gblObj.SetAppFlagsInSession(ds);
            if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            {
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            }
            FillLoanPurpose();
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                btnSec.Visible = true;
                btnSec.Text = "Back to inbox";
                btnSec.PostBackUrl = "~/Contents/InboxService.aspx";
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    FillTADetails(Convert.ToDouble(Request.QueryString["TAReqID"]));
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
        txtInwNo.ReadOnly = true ;
        txtAppDate.ReadOnly = false;
        txtAppDate.Enabled = true;
        txtPropAmt.ReadOnly = false;
        ddlPurpose.Enabled = true;
        btnSave.Enabled = true;
    }
    private void DisableControls()
    {
        txtEmpID.ReadOnly = true;
        txtInwNo.ReadOnly = true;
        txtAppDate.ReadOnly = true;
        txtAppDate.Enabled = false;
        txtPropAmt.ReadOnly = true;
        ddlPurpose.Enabled = false;
        btnSave.Enabled = false;
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
                txtPropInst.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            }
            else
            {
                txtPropInst.Text = "";
            }
            ddlPurpose.SelectedValue = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        }
    }

    private void FillLoanPurpose()
    {
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(1);
        DataSet ds = new DataSet();
        ds = Kgen.GetLoanPurpose(ArrIn);
        gblObj.FillCombo(ddlPurpose, ds, 1);

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
        //        gblObj.MsgBoxOk("Duplicate inward No.", this);
        //    }
        //    else
        //    {
        //        txtFileNo.Text = Session["File"] + "/" + txtInwNo.Text + "/" + DateTime.Now.Year.ToString();
        //        //strFileNo = Session["File"] + "/" + txtInwNo.Text + "/" + DateTime.Now.Year.ToString();

        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter inward No.", this);
        //}
    }
    protected void txtEmpID_TextChanged(object sender, EventArgs e)
    {
        Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        if (gblObj.WhetherLBMatch(Convert.ToInt64(Session["NumEmpId"]), Convert.ToInt16(Session["intLBId"])) == true)
        {
            FillBasicDet();
            if (Eligible() == true)
            {
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
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
    protected void ddlPurpose_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = true;
    }
    protected void txtPropAmt_TextChanged(object sender, EventArgs e)
    {
        //txtPropInst.Text = FltMaxAdmsblTA.ToString();
        txtPropInst.Text = FindAdmissibleAmt().ToString();

    }
    private double FindAdmissibleAmt()
    {
        double tt = 0;
        if (Convert.ToDouble(txtPropAmt.Text) <= Convert.ToDouble(FltMaxAdmsblTA))
        {
            tt = Convert.ToDouble(txtPropAmt.Text);
        }
        else
        {
            tt = FltMaxAdmsblTA;
        }
        return tt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateCtrls() == true)
        {
            if (Eligible() == true)
            {
                if (ValidateFieldsNRA(ddlPurpose, txtPropAmt, txtPropInst) == true)
                {
                    FindTrnType();
                    CreateSerTrn();
                    CreateTARequest();
                    if (Convert.ToInt16(Session["intMenuItem"]) == 3)    //Not thru Inbox
                    {
                        gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt64(Session["NumServiceTrnID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]), "");
                    }

                    gblObj.MsgBoxOk("Saved Successfully", this);
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
        if ((Convert.ToInt64(txtPropInst.Text)) > 200000)
        {
            Session["intTrnType"] = 41;
        }
        else
        {
            Session["intTrnType"] = 4;
        }
        gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
    }    

public Boolean ValidateFieldsNRA(DropDownList ddl, TextBox Ta2, TextBox Ta3)
    {
        bool Valid;
        Valid = false;
        if (Convert.ToInt16(ddl.SelectedItem.Value.ToString()) <= 0)
        {
            gblObj.MsgBoxOk("SelectPurpose", this);
        }
        else if (Ta2.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter Amount", this); ;
        }
        else if (Ta2.Text.Trim() != "")
            if (Convert.ToDouble(Ta2.Text) > FltMaxAdmsblTA)
            {
                gblObj.MsgBoxOk("You are not eligible for this amount", this);
            }
            else if (Ta3.Text.Trim() == "")
            {
                gblObj.MsgBoxOk("You are not eligible", this);
            }
            //else if (Ta3.Text.Trim() != "")
            //{
            //    if (Convert.ToInt16(Ta3.Text) < 12 || Convert.ToInt16(Ta3.Text) > 36)
            //    {
            //        gblObj.MsgBoxOk("f", this);
            //    }
            //    else
            //    {
            //        Valid = true;
            //    }
            //}
            else
            {
                //gblObj.MsgBoxOk("f", this);
                Valid = true;
            }
        return Valid;

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
                gblObj.MsgBoxOk("Employee already applied for NRA", this);
            }
        }
        else
        {
            ValidFlg = false;
            gblObj.MsgBoxOk("REtirement date Must less than 1 year ", this);
        }

        return ValidFlg;
    }
    private Boolean RtrmntVldtion()
    {
        Boolean Vald;
        if (DtmRtrmnt != "")
        {
            DateTime RetDt = new DateTime();
            DateTime ToDt = new DateTime();
            RetDt = Convert.ToDateTime(DtmRtrmnt);
            ToDt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
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
        TAReq.FltAmtAdmissible = Convert.ToDouble(txtPropInst.Text);
        TAReq.IntNoOfInstProposed = 0;
        TAReq.IntPurposeID = Convert.ToInt16(ddlPurpose.SelectedValue);
        TAReq.DtmDateOfRequest = txtAppDate.Text;
        TAReq.IntUesrID = Convert.ToInt32(Session["intUserId"]);
        TAReq.IntDesigID = IntDesigId;
        TAReq.FltInstAmount = 0;// Convert.ToDouble(lblRepay.Text);
        TAReq.NumWithRequestID = Convert.ToInt64(Session["NumServiceTrnID"]);
        TAReqDao.CreateTARequest(TAReq);
    }
    protected void OkBtn_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = false;
    }


    private Boolean ValidateCtrls()
    {
        Boolean flg = true;
        if (txtInwNo.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter inward No.", this);
        }
        else if (txtEmpID.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Acc. No.", this);
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
        else if (txtAppDate.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Application Date.", this);
        }
        //else if (txtPropInst.Text == "")
        //{
        //    flg = false;
        //    gblObj.MsgBoxOk("Enter instalment amount", this);
        //}
        //else if (lblConsAmt.Text == "")
        //{
        //    flg = false;
        //    gblObj.MsgBoxOk("Enter consolidate amount", this);
        //}
        //else if (lblRepay.Text == "")
        //{
        //    flg = false;
        //    gblObj.MsgBoxOk("Enter repayment", this);
        //}
        else
        {
            flg = true;
        }
        return flg;
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

}