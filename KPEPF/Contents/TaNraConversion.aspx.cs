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

public partial class Contents_TaNraConversion : System.Web.UI.Page
{

    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();
    TA2NRACon Ta2Nra = new TA2NRACon();
    TA2NRADAO Ta2NraDAO = new TA2NRADAO();

    static string DtmRtrmnt = "";
    static double PfCrdt = 0;
    static int intDesigId;
    static Int64 ReqId = 0;
    static int NumEmpId = 0;
    static double FltOrgTAAmt = 0;
    static int IntDesigId = 0;
    static double FltPFCresdit = 0;
    static double FltMaxAdmsblTA = 0;
    static double FltPndingAmt = 0;
    static double AmntConvert = 0;
    static int noInstOrg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            {
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            }
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                btnSec.Visible = true;
                btnSec.Text = "Back to Inbox";
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    ReqId = Convert.ToInt32(Request.QueryString["TAReqID"]);
                    FillTADetails(ReqId);
                    SetControls();
                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 1)        //Through View
            {
                //btnSec.Visible = true;
                //btnSec.Text = "Back to View";
                //Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["numTrnID"]);
                //if (Session["NumServiceTrnID"] > 0)
                //{
                //    ReqId = Convert.ToInt32(Request.QueryString["TAReqID"]);
                //    FillTADetails(ReqId);
                //}

                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    btnSec.Visible = true;
                    btnSec.Text = "Back to View";
                    btnSec.PostBackUrl = "~/Contents/View.aspx";
                    FillTADetails(Convert.ToInt64(Session["NumServiceTrnID"]));
                    SetControls();
                    //FillBasicDet();
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
        btnSave.Enabled = true;
    }
    private void DisableControls()
    {
        txtEmpID.ReadOnly = true;
        txtInwNo.ReadOnly = true;
        txtAppDate.ReadOnly = true;
        txtAppDate.Enabled = false;
        btnSave.Enabled = false ;
    }
    private void FillTADetails(Int64 withReqId)
    {
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(withReqId);
        ds = Ta2NraDAO.FillTaToNra(arrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() != "")
            {
                txtFileNo.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                gblObj.StrFileNo = txtFileNo.Text.ToString();
            }
            else
            {
                txtFileNo.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() != "")
            {
                txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            }
            else
            {
                txtInwNo.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[4].ToString() != "")
            {
                txtAppDate.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[4]);
            }
            else
            {
                txtAppDate.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[1].ToString() != "")
            {
                txtEmpID.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            else
            {
                txtEmpID.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() != "")
            {
                lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            }
            else
            {
                lblNameApplDisp.Text = "";
            }

            int noInst = 0;
            int amtInst = 0;
            noInst = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[11]);
            amtInst = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[12]);
            noInstOrg = noInst;
            FltOrgTAAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[9]);
            lblLoanOutstnd.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[10]);
            txtOriginalAmnt.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[9]);
            txtPendInstal.Text = FindPendingInst(amtInst,noInst).ToString(); //Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[11]);
            txtAmntPending.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[10]);
            txtAmntConvert.Text = Convert.ToString(txtAmntPending.Text.ToString());
        }
    }
    protected void txtInwNo_TextChanged(object sender, EventArgs e)
    {
        gblObj.FillFileNo(txtInwNo, txtFileNo, Session["File"].ToString(), this, Convert.ToInt32(Session["intLBID"]));
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



                //////// Fill lbls regarding TA 2 NRA Conversion///////////
                txtOriginalAmnt.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[6].ToString());
                txtPendInstal.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[22].ToString());
                txtAmntPending.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[15].ToString());
                txtAmntConvert.Text = Convert.ToString(Convert.ToDouble(txtOriginalAmnt.Text) - Convert.ToDouble(txtAmntPending.Text));
                //////// Fill lbls regarding TA 2 NRA Conversion///////////
            }
        }
    }
    protected void txtEmpID_TextChanged(object sender, EventArgs e)
    {
        Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        if (gblObj.WhetherLBMatch(Convert.ToInt64(Session["NumEmpId"]), Convert.ToInt16(Session["intLBId"])) == true)
        {
            FillBasicDet();
            //FillTADetFrmEmp();
            if (Eligible() == true)
            {
            }
        }
        else
        {
            gblObj.MsgBoxOk("Not beleongs to this Localbody!", this);
            txtEmpID.Text = "";
        }
    }
    //private void FillTADetFrmEmp()
    //{

    //}
    private double FindPendingInst(double amtInst, int noInst)
    {
        double amt = 0;
        amt = noInst - (FltOrgTAAmt - Convert.ToDouble(lblLoanOutstnd.Text) ) / amtInst;

        return amt;
    }
    protected void OkBtn_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = false;
    }
    protected void btnDet_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = true;
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (ValidateCtrls() == true)
        {
            if (Eligible() == true)
            {
                CreateSerTrn();
                CreateTA2NRAConRequest();
                gblObj.UppdApproval(Convert.ToInt16(Session["intTrnType"]), Convert.ToInt64(Session["NumServiceTrnID"]), Convert.ToInt16(Session["intFlgApp"]), Convert.ToInt32(Session["intUserId"]), "");
                gblObj.MsgBoxOk("Saved Successfully", this);
            }
        }
       // ClearControls();

    }
    private void ClearControls()
    {
        txtOriginalAmnt.Text = "";
        txtPendInstal.Text = "";
        txtAmntPending.Text = "";
        txtAmntConvert.Text = "";
    }
    private void CreateTA2NRAConRequest()
    {

        Ta2Nra.NumTrnId = Convert.ToInt16(Session["intTrnType"]);
        Ta2Nra.NumSerTrnId = Convert.ToInt64(Session["NumServiceTrnID"]);
        Ta2Nra.NumEmpId = Convert.ToInt64(Session["NumEmpId"]);
        Ta2Nra.NumWithdrawalID = GetWithdrawReqId();
        Ta2Nra.FltAmtConverted = Convert.ToDouble(txtAmntConvert.Text);
        Ta2Nra.IntRsnId = 1;

        Ta2NraDAO.CreateTA2NRAConRequest(Ta2Nra);
    }

    private double GetWithdrawReqId()
    {
        double WithdrawId = 0;
        DataSet ds = new DataSet();
        ArrayList vArIn = new ArrayList();
        vArIn.Add(Session["NumEmpId"]);
        vArIn.Add(Convert.ToInt16(Session["intTrnType"]));
        ds = Kgen.TA2NRAGetWithdrawalId(vArIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            WithdrawId = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        return WithdrawId;
    }
    private void CreateSerTrn()
    {
        ArrayList ar = new ArrayList();

        ar.Add(0);
        ar.Add(txtFileNo.Text);
        ar.Add(Session["NumEmpId"]);
        ar.Add(Convert.ToInt16(Session["intLBID"]));
        if (Convert.ToInt64(txtAmntConvert.Text) <= 200000)
        {
            Session["intTrnType"] = 8;
        }
        else
        {
            Session["intTrnType"] = 81;
        }
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
        else if (txtAmntConvert.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("You have no pending amount to convert!", this);
        }
        else
        {
            flg = true;
        }
        return flg;
    }

    private Boolean Eligible()
    {
        //Boolean ValidFlg;
        //if (RtrmntVldtion() == true)
        //{
        //    if (SixMnthsValdtion() == true)
        //    {
        //        if (ChkCredit() == true)
        //        {
        //            ValidFlg = true;
        //        }
        //        else
        //        {
        //            ValidFlg = false;
        //            gblObj.MsgBoxOk("Insufficient PF Credit", this);
        //        }
        //    }
        //    else
        //    {
        //        ValidFlg = false;
        //        gblObj.MsgBoxOk("Employee already applied for NRA", this);
        //    }
        //}
        //else
        //{
        //    ValidFlg = false;
        //    gblObj.MsgBoxOk("REtirement date Must less than 1 year ", this);
        //}

        Boolean flg;
        if (noInstOrg - Convert.ToInt16(txtPendInstal.Text) < 3)
        {
            flg = false;
            gblObj.MsgBoxOk("You are not eligible!", this);
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    //private Boolean SixMnthsValdtion()
    //{
    //    Boolean Vald;
    //    DataSet dsV = new DataSet();
    //    ArrayList vArrIn = new ArrayList();
    //    vArrIn.Add(Session["NumEmpId"]);
    //    vArrIn.Add(Convert.ToInt16(Session["intTrnType"]));
    //    dsV = gen.ValidateEligibility(vArrIn);
    //    if (Convert.ToInt16(dsV.Tables[0].Rows[0].ItemArray[0]) > 0)
    //    {
    //        Vald = false;
    //    }
    //    else
    //    {
    //        Vald = true;
    //    }
    //    return Vald;
    //}
    //private Boolean ChkCredit()
    //{
    //    Boolean Vald;
    //    if (PfCrdt <= 0)
    //    {
    //        Vald = false;
    //    }
    //    else
    //    {
    //        Vald = true;
    //    }
    //    return Vald;
    //}
    //private Boolean RtrmntVldtion()
    //{
    //    Boolean Vald;
    //    if (DtmRtrmnt != "")
    //    {
    //        DateTime RetDt = new DateTime();
    //        DateTime ToDt = new DateTime();
    //        RetDt = Convert.ToDateTime(DtmRtrmnt);
    //        ToDt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    //        TimeSpan DaysCnt;
    //        DaysCnt = RetDt.Subtract(ToDt);

    //        if (DaysCnt.Days < 365)
    //        {
    //            Vald = false;
    //        }
    //        else
    //        {
    //            Vald = true;
    //        }
    //        return Vald;
    //    }
    //    else
    //    {
    //        Vald = true;
    //        return Vald;
    //    }
    //}
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
