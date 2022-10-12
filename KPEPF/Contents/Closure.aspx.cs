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
public partial class Contents_Closure : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    Closure closr = new Closure();
    ClosureDAO clsrDAO = new ClosureDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();
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
    static int intRsn;
    static int intaccno = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            FillClosureReason();
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                btnSec.Visible = true;
                btnSec.Text = "Back to inbox";
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["TAReqID"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    ReqId = Convert.ToInt32(Request.QueryString["TAReqID"]);
                    FillClosureDetails(ReqId);
                }
            }
        }

    }
    private void FillClosureReason()
    {
        //ArrayList ArrIn = new ArrayList();
        //ArrIn.Add(1);
        DataSet ds = new DataSet();
        ds = Kgen.GetClosureReason();
        gblObj.FillCombo(ddlPurpose, ds, 1);

    }
    private void FillClosureDetails(int withReqId)
    {
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(withReqId);
        ds = clsrDAO.GetClosureDetailsInbx(arrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txtFileNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            else
            {
                txtFileNo.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[10].ToString() != "")
            {
                txtAppDate.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[10]);
            }
            else
            {
                txtAppDate.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[13].ToString() != "")
            {
                txtEmpID.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            }
            else
            {
                txtEmpID.Text = "";
            }
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() != "")
            {
                lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            }
            else
            {
                lblNameApplDisp.Text = "";
            }


            ddlPurpose.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[5]);

            if (ds.Tables[0].Rows[0].ItemArray[6].ToString() != "")
            {
                txtLastSlry.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[6]);
            }
            else
            {
                txtLastSlry.Text = "";
            }

            if (ds.Tables[0].Rows[0].ItemArray[7].ToString() != "")
            {
                txtLastChalan.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[7]);
            }
            else
            {
                txtLastChalan.Text = "";
            }

            if (ds.Tables[0].Rows[0].ItemArray[8].ToString() != "")
            {
                txtDateQuitting.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[8]);
            }
            else
            {
                txtDateQuitting.Text = "";
            }

            txtPaymentOffice.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[9]);
        }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        FillBasicDet();
        pnlEmpDet.Visible = true;
    }
    protected void txtEmpID_TextChanged(object sender, EventArgs e)
    {
        //if (txtEmpID.Text != "")
        //{
        //    DataSet ds = new DataSet();
        //    Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        //    emp.NumEmpID = Convert.ToInt64(Session["NumEmpId"]);
        //    // fillpanelBasicDetails(Session["NumEmpId"]);
        //    ds = empDoa.GetEmployeeBasicDet(emp);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //        lblDesig.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //        DtmRtrmnt = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //        if (ds.Tables[0].Rows[0].ItemArray[5].ToString() != "")
        //        {
        //            PfCrdt = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[5]);
        //        }
        //        else
        //        {
        //            PfCrdt = 0;
        //        }
        //        if (ds.Tables[0].Rows[0].ItemArray[10].ToString() != "")
        //        {
        //            intDesigId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[10]);
        //        }
        //        else
        //        {
        //            intDesigId = 0;
        //        }
        //        txtEmpID.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //        lblPFNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //        //lblNameApplDisp.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //        //lblDesig.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //        lblPFCr.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //        lblLoanOutstnd.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //        lblBPay.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //        lblDBirth.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        //        lblJoinDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        //        lblDRetire.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //        lblDEnroll.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();

        //        NumEmpId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[8].ToString());
        //        ///TA////
        //        FltPndingAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[15].ToString());
        //        FltOrgTAAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[6].ToString());
        //        //IntDesigId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[10].ToString());
        //        FltPFCresdit = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[5].ToString());
        //        FltMaxAdmsblTA = ((3 * FltPFCresdit) - FltPndingAmt) / 4;
        //        DtmRtrmnt = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //        lblAdmloan.Text = FltMaxAdmsblTA.ToString(); ;
        //    }
        //    //ddlPurpose.Text = "<Select an item>";
        //}

        Session["NumEmpId"] = Convert.ToDouble(txtEmpID.Text.ToString());
        if (gblObj.WhetherLBMatch(Convert.ToInt64(Session["NumEmpId"]), Convert.ToInt16(Session["intLBId"])) == true)
        {
            FillBasicDet();
            //FillTADetFrmEmp();
            //if (Eligible() == true)
            //{
            //}
        }
        else
        {
            gblObj.MsgBoxOk("Not beleongs to this Localbody!", this);
            txtEmpID.Text = "";
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CreateServiceTransaction();
        Approval(Convert.ToInt16(Session["intFlgApp"]));

        /*-------Clousure table--------*/
        closr.NumClosureID = 1;
        closr.NumTrnID = Convert.ToInt64(Session["NumServiceTrnID"]);
       // closr.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
        closr.NumEmpID = Convert.ToDouble(txtEmpID.Text);
        closr.IntRsnID = Convert.ToInt16(ddlPurpose.SelectedValue);
        closr.DtmLastSalary = txtLastSlry.Text;
        closr.DtmLastChalan = txtLastChalan.Text;
        closr.DtmQuitting = txtDateQuitting.Text;
        closr.IntQuittingLB = Convert.ToInt32(Session["intLBID"]);
        DataSet ds = new DataSet();
        ds = clsrDAO.CreateClosure(closr); 
      
        
        gblObj.MsgBoxOk("Successfully Saved.", this); 

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
    private void CreateServiceTransaction()
    {
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        if (Request.QueryString["MEMREqID"] != null)
        {
            ArrIn.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        }
        else
        {
            if (Convert.ToInt64(Session["NumServiceTrnID"]) == 0)
            {
                ArrIn.Add(0);
            }
            else
            {
                ArrIn.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
            }
        }
        ArrIn.Add(FileNo.Text.Trim());
        ArrIn.Add(intaccno);
        ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
        ArrIn.Add(Convert.ToInt16(Session["intTrnType"]));
        ArrIn.Add(txtAppDate.Text);
        ArrIn.Add(Convert.ToInt64(Session["intUserId"]));
        if (txtInwNo.Text.ToString() != "")
        {
            ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
        }
        else
        {
            ArrIn.Add(0);
        }
        ds = Kgen.CreateServiceTransaction(ArrIn);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            //ServiceTrnID = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            Session["NumServiceTrnID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    //private void CreateSerTrn()
    //{
    //    ArrayList ar = new ArrayList();

    //    if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
    //    {
    //        ar.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
    //    }
    //    else
    //    {
    //        ar.Add(0);
    //    }
    //    ar.Add(txtFileNo.Text);
    //    ar.Add(Session["NumEmpId"]);
    //    ar.Add(Convert.ToInt16(Session["intLBID"]));
    //    ar.Add(Convert.ToInt16(Session["intTrnType"]));
    //    ar.Add(txtAppDate.Text);
    //    ar.Add(Convert.ToInt64(Session["intUserId"]));
    //    ar.Add(Convert.ToInt16(txtInwNo.Text));
    //    DataSet ds = Kgen.CreateServiceTransaction(ar);
    //    if (ds.Tables[0].Rows.Count >= 1)
    //    {
    //        Session["NumServiceTrnID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
    //    }
    //}
    protected void btnSec_Click(object sender, EventArgs e)
    {

    }
    protected void OkBtn_Click(object sender, EventArgs e)
    {
        pnlEmpDet.Visible = false;
    }

   
    private void GetRtrmntDet()
    {
       
        string dtmRtrDt;
        ArrayList vAryInDt = new ArrayList();
        ArrayList vAryInDtMarch = new ArrayList();
        DataSet dsRt = new DataSet();
        DataSet dsRtMrch = new DataSet();
        ArrayList vArIn = new ArrayList();
        vArIn.Add(Session["NumEmpId"]);
        dsRt = clsrDAO.GetRetemntDet(vArIn);    
        if (dsRt.Tables[0].Rows.Count > 0)
        {
            txtLastSlry.Text = dsRt.Tables[0].Rows[0].ItemArray[0].ToString();
            txtLastChalan.Text = dsRt.Tables[0].Rows[0].ItemArray[2].ToString() + " - " + dsRt.Tables[0].Rows[0].ItemArray[0].ToString();
            dtmRtrDt = dsRt.Tables[0].Rows[0].ItemArray[1].ToString();
          
        }
    }
    protected void ddlPurpose_SelectedIndexChanged(object sender, EventArgs e)
    {
        intRsn = Convert.ToInt16(ddlPurpose.SelectedValue);

        if (intRsn == 2)
        {
            txtDateQuitting.Enabled = false;
            GetRtrmntDet();
        }
        else
        {
            txtDateQuitting.Enabled = true;
            //btnCal.Enabled = true;
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
}
