

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
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KPEPFClassLibrary;

public partial class Contents_CreditCardNew2 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    LedgerYDao ldgrDao = new LedgerYDao();
    LedgerMDao ldgrDaom = new LedgerMDao();
    UserDao usrD = new UserDao();
    int yr = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillNameAccNo();
            yr = gen.GetCCYearId() + 1;
            FillGrid();
        }
    }
    private void FillNameAccNo()
    {
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(Session["NumEmpId"]);
        tctAccNo.Text = Session["NumEmpId"].ToString();
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    private int ChekFlgLogin()
    {
        int i;
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Convert.ToInt32(Session["intUserId"])));
        ds = usrD.GetUserDet(ar);
        if (ds.Tables[0].Rows[0].ItemArray[8].ToString() == "1")
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        return i;
    }

    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvMonth");
        ar.Add("ChalanDet");
        ar.Add("fltSubnAmt");
        ar.Add("fltRePaymentAmt");
        ar.Add("fltArearPFAmt");
        ar.Add("fltArearDA");
        ar.Add("fltArearPay");
        ar.Add("fltTotal");
        ar.Add("fltAllottedAmt");
        ar.Add("chvEngLBName");
        ar.Add("numChalanId");
        ar.Add("flgApprovalChal");
        ar.Add("flgApproval");
        ar.Add("flgPrevYear");
        ar.Add("intGroupId");
        ar.Add("PerYearId");
        ar.Add("PerMonthId");
        ar.Add("intDistID");
        ar.Add("PDEYear");
        gblObj.SetGridDefault(gdvAnnStmnt, ar);
        //gdvAnnStmnt.Enabled = false;
    }
    private void FillGrid()
    {
        DataSet ds = new DataSet();
        Double fltAmt = 0;
        Double fltAmtP = 0;
        ArrayList ar = new ArrayList();
        
        if (yr > 0 && Convert.ToInt32(tctAccNo.Text) > 0)
        {
            ar.Add(Convert.ToInt32(emp.NumEmpID));
            ar.Add(yr);
            ds = ldgrDaom.AnnStmnt(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvAnnStmnt.Visible = true;
                gdvAnnStmnt.DataSource = ds;
                gdvAnnStmnt.DataBind();
                //Can highlight those from Ag
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i].ItemArray[28].ToString() == "2")
                    {
                        gdvAnnStmnt.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                        gdvAnnStmnt.Rows[i].Cells[7].Font.Bold = true;
                    }

                    if (ds.Tables[0].Rows[i].ItemArray[29].ToString() == "2")
                    {
                        gdvAnnStmnt.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        gdvAnnStmnt.Rows[i].Cells[8].Font.Bold = true;
                    }

                    //make null dos dup with amts /////
                    if (i > 0)
                    {
                        if (!DBNull.Value.Equals(ds.Tables[0].Rows[i].ItemArray[14]))
                        {
                            fltAmt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[14]);
                            if (!DBNull.Value.Equals(ds.Tables[0].Rows[i - 1].ItemArray[14]))
                            {
                                fltAmtP = Convert.ToDouble(ds.Tables[0].Rows[i - 1].ItemArray[14]);
                            }
                            if (fltAmt == fltAmtP)
                            {
                                gdvAnnStmnt.Rows[i].Cells[8].Text = "";
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            fltAmt = 0;
                        }
                    }
                }
            }
            else
            {
                SetGridDefault();
            }
            gblObj.SetFooterTotals(gdvAnnStmnt, 7);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session["flg"] = 3;
        Session["flgcs"] = 1;
        btnBack.PostBackUrl = "~/Contents/CreditCardPin2.aspx";
    }
}
