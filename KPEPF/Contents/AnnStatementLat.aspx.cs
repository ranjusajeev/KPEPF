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

public partial class Contents_AnnStatementLat : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    GeneralDAO gen;
    LedgerMDao ldgrDao;
    Employee emp;
    EmployeeDAO empDao;
    static int intCCYear = 0;

    CreditCardDao ccDao;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            //InitialSettings();
            if (Convert.ToInt64(Request.QueryString["intYearId"]) > 0)
            {
                Session["intYearAnnStmnt"] = Convert.ToInt16(Request.QueryString["intYearId"]);
                if (Convert.ToInt16(Session["intYearAnnStmnt"]) <= 49)
                {
                    fillGridCons();
                    FillGridVerified();
                    Session["flgPageBack"] = 2;
                }
                else
                {
                    fillGridCons();
                    FillGrid();
                    Session["flgPageBack"] = 3;
                }
            }
            else
            {
                InitialSettings();
            }
            if (Convert.ToInt64(Session["NumEmpIdAnnStmnt"]) > 0 && Convert.ToInt64(Session["intYearAnnStmnt"]) > 0)
            {
                FillOnBack();
            }
        }
    }
    private void FillOnBack()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        txtAccNo.Text = Session["NumEmpIdAnnStmnt"].ToString();
        FillNameAccNo();
        DataSet dsD = new DataSet();
        dsD = gen.GetYearRem();
        int f = Convert.ToInt16(Session["intYearAnnStmnt"]);
        if (Convert.ToInt16(Session["intYearAnnStmnt"]) >= 50)
        {
            FillGrid();
            gdvAnnStmnt.Visible = true;
            gdvCcVer.Visible = false;
        }
        else
        {
            FillGridVerified();
            gdvAnnStmnt.Visible = false;
            gdvCcVer.Visible = true;
        }
        fillGridCons();
    }
    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        DataSet dsD = new DataSet();
        dsD = gen.GetYearRem();
        intCCYear = gen.GetCCYearId();
        txtAccNo.Text = "";
        SetGridDefaultCons();
    }
    private void FillGridVerified()
    {
        gblObj = new clsGlobalMethods();
        ccDao = new CreditCardDao();

        DataSet dsCcVer = new DataSet();
        ArrayList arCcVer = new ArrayList();
        if (Convert.ToInt16(Session["intYearAnnStmnt"]) >= 37 && Convert.ToInt32(Session["NumEmpIdAnnStmnt"]) > 0)
        {
            arCcVer.Add(Convert.ToInt32(Session["NumEmpIdAnnStmnt"]));
            arCcVer.Add(Convert.ToInt16(Session["intYearAnnStmnt"]));
            dsCcVer = ccDao.GetCreditCardVerified(arCcVer);
            if (dsCcVer.Tables[0].Rows.Count > 0)
            {
                gdvCcVer.Visible = true;
                gdvAnnStmnt.Visible = false;
                gdvCcVer.DataSource = dsCcVer;
                gdvCcVer.DataBind();               
                for (int i = 0; i < dsCcVer.Tables[0].Rows.Count; i++)
                {
                    //Can highlight those from Ag
                    if (dsCcVer.Tables[0].Rows[i].ItemArray[25].ToString() == "2")
                    {
                        gdvCcVer.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                        gdvCcVer.Rows[i].Cells[7].Font.Bold = true;
                        gdvCcVer.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        gdvCcVer.Rows[i].Cells[8].Font.Bold = true;
                        gdvCcVer.Rows[i].Cells[7].ToolTip = GetNavigationPrevAg(Convert.ToDouble(dsCcVer.Tables[0].Rows[i].ItemArray[22]));
                    }

                    //Can block those from current Ag and chalan of prev years 
                    if (dsCcVer.Tables[0].Rows[i].ItemArray[20].ToString() == "1")
                    {
                        //gdvCcVer.Rows[i].Cells[1].Enabled = false;
                        gdvCcVer.Rows[i].Cells[7].ToolTip = GetNavigation(Convert.ToInt16(dsCcVer.Tables[0].Rows[i].ItemArray[13]), Convert.ToInt16(dsCcVer.Tables[0].Rows[i].ItemArray[14]));
                    }
                    else
                    {
                        gdvCcVer.Rows[i].Cells[1].Enabled = true;
                    }
                    //Can block those from current Ag and chalan of prev years 

                    //Can navigate With det////////////
                    if (Convert.ToBoolean(dsCcVer.Tables[0].Rows[i].ItemArray[9].Equals(DBNull.Value)))
                    {

                    }
                    else
                    {
                        gdvCcVer.Rows[i].Cells[8].ToolTip = GetNavigationPrev(Convert.ToInt16(dsCcVer.Tables[0].Rows[i].ItemArray[0]));
                    }
                    //Can navigate With det////////////

                }
                
            }
            else
            {

            }
            gblObj.SetFooterTotalsMltpl(gdvCcVer, 2,8);
        }
    }
    private string GetNavigation(int strInput1, int strInput2)
    {
        gen = new GeneralDAO();

        string strOutput = "";
        ArrayList ary=new ArrayList();
        ArrayList arm=new ArrayList();
        ary.Add(strInput1);
        arm.Add(strInput2);
        strOutput = gen.GetYearFromId(ary) + '/' + gen.GetMonthFromId(arm);
        return strOutput;
    }
    private void FillGrid()
    {
        gblObj = new clsGlobalMethods();
        ldgrDao = new LedgerMDao();

        DataSet ds = new DataSet();
        Double fltAmt = 0;
        Double fltAmtP = 0;
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(Session["intYearAnnStmnt"]) > 0 && Convert.ToInt32(Session["NumEmpIdAnnStmnt"]) > 0)
        {
            ar.Add(Convert.ToInt32(Session["NumEmpIdAnnStmnt"]));
            ar.Add(Convert.ToInt16(Session["intYearAnnStmnt"]));
            ds = ldgrDao.AnnStmnt(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvAnnStmnt.Visible = true;
                gdvCcVer.Visible = false;
                gdvAnnStmnt.DataSource = ds;
                gdvAnnStmnt.DataBind();
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Can highlight those from Ag
                    if (ds.Tables[0].Rows[i].ItemArray[28].ToString() == "2" || ds.Tables[0].Rows[i].ItemArray[28].ToString() == "3")
                    {
                        int tp = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[28]);
                        gdvAnnStmnt.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                        gdvAnnStmnt.Rows[i].Cells[7].Font.Bold = true;
                        gdvAnnStmnt.Rows[i].Cells[7].ToolTip = GetNavigationCurrAg(Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[19]),tp);
                    }
                    //Can highlight those from Ag
                    if (ds.Tables[0].Rows[i].ItemArray[29].ToString() == "2")
                    {
                        gdvAnnStmnt.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        gdvAnnStmnt.Rows[i].Cells[8].Font.Bold = true;
                    }
                    //Can navigate With det////////////
                    if (Convert.ToBoolean(ds.Tables[0].Rows[i].ItemArray[14].Equals(DBNull.Value)))
                    {

                    }
                    else
                    {
                        gdvAnnStmnt.Rows[i].Cells[8].ToolTip = GetNavigationCurr(Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[16]));
                    }
                    //Can navigate With det////////////

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
            //gblObj.SetFooterTotals(gdvAnnStmnt, 7);
            gblObj.SetFooterTotalsMltpl(gdvAnnStmnt, 7, 8);
        }
    }
 
    private string GetNavigationCurrAg(double chalanId,int tp)
    {
        ldgrDao = new LedgerMDao();

        string strOutput = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(chalanId);
        if (tp == 2)
        {
            ds = ldgrDao.GetAgDet(ar);
        }
        else
        {
            ds = ldgrDao.GetAgDetBt(ar);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            strOutput = ds.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + "-" + ds.Tables[0].Rows[0].ItemArray[2].ToString();
        }
        return strOutput;
    }
    private string GetNavigationPrevAg(double chalanId)
    {
        ldgrDao = new LedgerMDao();
        string strOutput = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(chalanId);
        ds = ldgrDao.GetAgDetPrev(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            strOutput = ds.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + "-" + ds.Tables[0].Rows[0].ItemArray[2].ToString();
        }
        return strOutput;
    }
    private string GetNavigationCurr(int mth)
    {
        ldgrDao = new LedgerMDao();

        string strOutput = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList arm = new ArrayList();
        ar.Add(Convert.ToInt32(Session["NumEmpIdAnnStmnt"]));
        ar.Add(Convert.ToInt16(Session["intYearAnnStmnt"]));
        ar.Add(mth);
        ds = ldgrDao.GetWithDet(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            strOutput = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return strOutput;
    }
    private string GetNavigationPrev(int mth)
    {
        ldgrDao = new LedgerMDao();

        string strOutput = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList arm = new ArrayList();
        ar.Add(Convert.ToInt32(Session["NumEmpIdAnnStmnt"]));
        ar.Add(Convert.ToInt16(Session["intYearAnnStmnt"]));
        ar.Add(mth);
        ds = ldgrDao.GetWithDetPrev(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            strOutput = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return strOutput;
    }
    //private void SetColor(DataSet dsSt)
    //{
    //    if (dsSt.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < dsSt.Tables[0].Rows.Count; i++)
    //        {
    //            if (dsSt.Tables[0].Rows[i].ItemArray[17].ToString() == "1")
    //            {
    //                gdvAnnStmnt.Rows[i].Cells[2].ForeColor = System.Drawing.Color.Blue;
    //                gdvAnnStmnt.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Blue;
    //                gdvAnnStmnt.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Blue;
    //            }

    //            if (dsSt.Tables[0].Rows[i].ItemArray[18].ToString() == "1")
    //            {
    //                gdvAnnStmnt.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Blue;
    //            }
    //        }
    //    }
    //}
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
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
    private void SetGridDefaultCc()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("chvMonth");
        ar.Add("CDate");
        ar.Add("MsAmt");
        ar.Add("RfAmt");
        ar.Add("PfAmt");
        ar.Add("DaAmt");
        ar.Add("PayAmt");
        ar.Add("RemAmt");
        ar.Add("Withdrawal");
        ar.Add("chvEngLBName");
        ar.Add("numChalanId");
        ar.Add("flgApprovalChal");
        ar.Add("flgPrevYear");
        ar.Add("intGroupId");
        ar.Add("intMonthID");
        ar.Add("intDistID");
        ar.Add("intID");
        gblObj.SetGridDefault(gdvCcVer, ar);
        //gdvCcVer.Enabled = false;
    }
    private void SetGridDefaultCons()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("chvYear");
        ar.Add("fltTotal");
        ar.Add("fltWith");
        ar.Add("intYearId");
        gblObj.SetGridDefault(gdvCons, ar);
    }
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccNo.Text) > 0)
        {
            Session["NumEmpIdAnnStmnt"] = Convert.ToInt32(txtAccNo.Text);
            FillNameAccNo();
            //fillGridCons();
        }
    }
    private void fillGridCons()
    {
        gblObj = new clsGlobalMethods();
        ldgrDao = new LedgerMDao();

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        if (Convert.ToInt32(Session["NumEmpIdAnnStmnt"]) > 0)
        {
            ar.Add(Convert.ToInt32(Session["NumEmpIdAnnStmnt"]));
            ds = ldgrDao.AnnStmntCons(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvCons.DataSource = ds;
                gdvCons.DataBind();
            }
            gblObj.SetFooterTotalsMltpl(gdvCons, 1, 2);
        }
    }
    private void FillNameAccNo()
    {
        emp = new Employee();
        empDao = new EmployeeDAO();
        gblObj = new clsGlobalMethods();

        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(txtAccNo.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
            fillGridCons();
            SetGridDefault();
            SetGridDefaultCc();
        }
        else
        {
            gblObj.MsgBoxOk("No such Employee!!!", this);
            SetGridDefaultCons();
            SetGridDefault();
            SetGridDefaultCc();
        }
    }
    protected void gdvCcVer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gblObj.SetColWidthGrid(gdvCcVer, e, 9, 18);
    }
}
