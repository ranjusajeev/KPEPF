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


public partial class Contents_CreditCardParti : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();
    ApprovalDAO apprDao = new ApprovalDAO();

    public static int ccYearId = 0;
    public static int currentYearId = 0;
    public static double outAmt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["NumEmpId"] = 14415;
            GetCCardParticulars();
            GetCCardDetails();
            GetTADetails();
            //GetPreTA();
            calcul();
        }
    }
    private void GetCCardParticulars()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt64(Session["NumEmpId"]));
        ds = Kgen.GetCCardParticulars(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtOffice.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtBal.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            ccYearId =Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[4].ToString());
        }
        else
        {
            txtName.Text = "";
            txtOffice.Text = "";
            txtBal.Text = 0.ToString();
            ccYearId = 21;
        }
    }
     private void GetCCardDetails()
     {
         ArrayList arr = new ArrayList();
         DataSet ds = new DataSet();
         arr.Add(Convert.ToInt64(Session["NumEmpId"]));
         //arr.Add(ccYearId);
         ds=Kgen.GetCCardAmount(arr);
         if (ds.Tables[0].Rows.Count > 0)
         {
             if (ds.Tables[0].Rows.Count > 1)
             {
                 txtSubRef.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                 txtArrearDA.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                 txtTA.Text = ds.Tables[0].Rows[1].ItemArray[4].ToString();
             }
             else
             {
                 txtSubRef.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                 txtArrearDA.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                 txtTA.Text = 0.ToString();
             }
         }
         else
         {
             txtSubRef.Text = 0.ToString();
             txtArrearDA.Text = 0.ToString();
             txtTA.Text = 0.ToString();
         }
    }
    private void GetTADetails()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt64(Session["NumEmpId"]));
        arr.Add(ccYearId);
        ds = Kgen.GetCCParticulars(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtRequLoan.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            txtSanction.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtConsol.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtRecover.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            txtInstal.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            outAmt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[7].ToString());
        }
        else
        {
            txtRequLoan.Text = 0.ToString();
            txtSanction.Text = 0.ToString();
            txtConsol.Text = 0.ToString();
            txtRecover.Text = 0.ToString();
            txtInstal.Text = 0.ToString();
        }
    }
    private void calcul()
    {
        double  Total = Convert.ToDouble(txtBal.Text) + Convert.ToDouble(txtSubRef.Text);
        txtTotal.Text = Total.ToString();
        double netBal = Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtArrearDA.Text) - Convert.ToDouble(txtTA.Text);
        txtBalance.Text = netBal.ToString();
        double Eligibility = ((3 * netBal) - outAmt) / 4;
        txtEligi.Text = Eligibility.ToString();
        double Consol = Convert.ToDouble(txtRequLoan.Text) + Convert.ToDouble(outAmt);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt64(Session["NumEmpId"]));
        ds = Kgen.GetPreWithdrawal(arr);
        if (Convert.ToDouble(txtTotal.Text.ToString()) > 0)
        {
            Response.Redirect("Reportviewer.aspx?ReportID=7");
        }
        else
        {
            gblObj.MsgBoxOk("The Employee has no Credit Card yet!", this);
        }
    }
}
