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

public partial class Contents_AnnStatement : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    LedgerMDao ldgrDao = new LedgerMDao();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    static int intCCYear = 0;

    CreditCardDao ccDao = new CreditCardDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            InitialSettings();
            if (Convert.ToInt64(Session["NumEmpIdAnnStmnt"]) > 0)
            {
                FillOnBack();
            }
        }
    }
    private void FillOnBack()
    {
        
        txtAccNo.Text = Session["NumEmpIdAnnStmnt"].ToString();
        FillNameAccNo();
        DataSet dsD = new DataSet();
        dsD = gen.GetYearRem();
        gblObj.FillCombo(ddlYear, dsD, 1);
        ddlYear.SelectedValue = Session["intYearAnnStmnt"].ToString();
        if (Convert.ToInt16(Session["intYearAnnStmnt"]) >= 50)
        {
            FillGrid();
            //gdvAnnStmnt.Visible = false;
            //gdvCcVer.Visible = true;
            gdvAnnStmnt.Visible = true;
            gdvCcVer.Visible = false;
        }
        else
        {
            FillGridVerified();
            gdvAnnStmnt.Visible = false;
            gdvCcVer.Visible = true;
            //gdvAnnStmnt.Visible = true;
            //gdvCcVer.Visible = false;
        }
    }
    private void InitialSettings()
    {
        DataSet dsD = new DataSet();
        dsD = gen.GetYearRem();
        gblObj.FillCombo(ddlYear, dsD, 1);
        intCCYear = gen.GetCCYearId();
        txtAccNo.Text = "";
        ddlYear.SelectedValue = "0";
        //Session["NumEmpIdAnnStmnt"] = 0;
        SetGridDefault();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            //gblObj.IntYear = Convert.ToInt16(ddlYear.SelectedValue);
            Session["intYearAnnStmnt"] = Convert.ToInt16(ddlYear.SelectedValue);
            //if (Convert.ToInt16(Session["intYearAnnStmnt"]) == intCCYear)
            if (Convert.ToInt16(Session["intYearAnnStmnt"]) >= 50)
            {
                Session["flgPageBack"] = 3;
                FillGrid();
                gdvAnnStmnt.Visible = true;
                gdvCcVer.Visible = false;
            }
            else
            {
                //Calculate();
                Session["flgPageBack"] = 2;
                FillGridVerified();
                gdvAnnStmnt.Visible = false;
                gdvCcVer.Visible = true;
            }
        }
    }
    //private int Calculate()
    //{
    //    int curYr = 0;
    //    return curYr;
    //}
    private void FillGridVerified()
    {
        DataSet dsCcVer = new DataSet();
        ArrayList arCcVer = new ArrayList();
        if (Convert.ToInt16(ddlYear.SelectedValue) >= 37 && Convert.ToInt32(txtAccNo.Text) > 0)
        {
            arCcVer.Add(Convert.ToInt32(txtAccNo.Text));
            arCcVer.Add(Convert.ToInt16(ddlYear.SelectedValue));
            dsCcVer = ccDao.GetCreditCardVerified(arCcVer);
            if (dsCcVer.Tables[0].Rows.Count > 0)
            {
                gdvCcVer.Visible = true;
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
                        gdvCcVer.Rows[i].Cells[1].ToolTip = GetNavigation(Convert.ToInt16(dsCcVer.Tables[0].Rows[i].ItemArray[13]), Convert.ToInt16(dsCcVer.Tables[0].Rows[i].ItemArray[14]));
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
                //SetGridDefault();
            }

            //SetColor(dsCcVer);
            gblObj.SetFooterTotalsMltpl(gdvCcVer, 2,8);
        }
    }
    private string GetNavigation(int strInput1, int strInput2)
    {
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
        DataSet ds = new DataSet();
        Double fltAmt = 0;
        Double fltAmtP = 0;
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0 && Convert.ToInt32(txtAccNo.Text) > 0)
        {
            ar.Add(Convert.ToInt32(txtAccNo.Text));
            ar.Add(Convert.ToInt16(ddlYear.SelectedValue));
            ds = ldgrDao.AnnStmnt(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvAnnStmnt.Visible = true;
                gdvAnnStmnt.DataSource = ds;
                gdvAnnStmnt.DataBind();
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Can highlight those from Ag
                    if (ds.Tables[0].Rows[i].ItemArray[28].ToString() == "2")
                    {
                        gdvAnnStmnt.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                        gdvAnnStmnt.Rows[i].Cells[7].Font.Bold = true;
                        gdvAnnStmnt.Rows[i].Cells[7].ToolTip = GetNavigationCurrAg(Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[19]));
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
            //SetColor(ds);
            gblObj.SetFooterTotals(gdvAnnStmnt, 7);
        }
    }
    //private void FillGrid()
    //{
    //    DataSet ds = new DataSet();
    //    Double fltAmt = 0;
    //    Double fltAmtP = 0;
    //    ArrayList ar = new ArrayList();
    //    if (Convert.ToInt16(ddlYear.SelectedValue) > 0 && Convert.ToInt32(txtAccNo.Text)>0) 
    //    {
    //        ar.Add(Convert.ToInt32(txtAccNo.Text));
    //        ar.Add(Convert.ToInt16(ddlYear.SelectedValue));
    //        ds = ldgrDao.AnnStmnt(ar);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            gdvAnnStmnt.Visible = true;
    //            gdvAnnStmnt.DataSource = ds;
    //            gdvAnnStmnt.DataBind();
    //            //Can highlight those from Ag
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                if (ds.Tables[0].Rows[i].ItemArray[28].ToString() == "2")
    //                {
    //                    gdvAnnStmnt.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
    //                    gdvAnnStmnt.Rows[i].Cells[7].Font.Bold = true;
    //                }

    //                if (ds.Tables[0].Rows[i].ItemArray[29].ToString() == "2")
    //                {
    //                    gdvAnnStmnt.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
    //                    gdvAnnStmnt.Rows[i].Cells[8].Font.Bold = true;
    //                }
    //                //Can navigate With det////////////
    //                if (Convert.ToBoolean(ds.Tables[0].Rows[i].ItemArray[14].Equals(DBNull.Value)))
    //                {
                        
    //                }
    //                else
    //                {
    //                    gdvAnnStmnt.Rows[i].Cells[8].ToolTip = GetNavigationCurr(Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[16]));
    //                }
    //                //Can navigate With det////////////

    //                //make null dos dup with amts /////
    //                if (i > 0)
    //                {
    //                    if (!DBNull.Value.Equals(ds.Tables[0].Rows[i].ItemArray[14]))
    //                    {
    //                        fltAmt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[14]);
    //                        if (!DBNull.Value.Equals(ds.Tables[0].Rows[i-1].ItemArray[14]))
    //                        {
    //                            fltAmtP = Convert.ToDouble(ds.Tables[0].Rows[i-1].ItemArray[14]);
    //                        }
    //                        if (fltAmt == fltAmtP)
    //                        {
    //                            gdvAnnStmnt.Rows[i].Cells[8].Text = "";
    //                        }
    //                        else
    //                        {

    //                        }
    //                    }
    //                    else
    //                    {
    //                        fltAmt = 0;
    //                    }

    //                    //if(System.DbNull.Value(ds.Tables[0].Rows[i].ItemArray[14]), "0",ds.Tables[0].Rows[i].ItemArray[14])
    //                    //{

    //                    //}
    //                }
    //                //if (i == 0 || Convert.IsDBNull(ds.Tables[0].Rows[i].ItemArray[14]))
    //                //{
    //                //    fltAmt = 0;
                        
    //                //}
    //                //else
    //                //{
    //                //    fltAmt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[14]);
    //                //    if (Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[14]) == fltAmt)
    //                //    {
    //                //        gdvAnnStmnt.Rows[i].Cells[8].Text = "";
    //                //    }
    //                //}
    //                //make null dos dup with amts ////////////
    //            }
    //            //Can highlight those from Ag
    //        }
    //        else
    //        {
    //            SetGridDefault();
    //        }
    //        //SetColor(ds);
    //        gblObj.SetFooterTotals(gdvAnnStmnt, 7);
    //    }       
    //}
    private string GetNavigationCurrAg(double chalanId)
    {
       string strOutput = "";
       DataSet ds = new DataSet();
       ArrayList ar = new ArrayList();
       ar.Add(chalanId);
       ds = ldgrDao.GetAgDet(ar);
       if (ds.Tables[0].Rows.Count > 0)
       {
           strOutput = ds.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + "-" + ds.Tables[0].Rows[0].ItemArray[2].ToString();
       }
        return strOutput;
    }
    private string GetNavigationPrevAg(double chalanId)
    {
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
        string strOutput = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList arm = new ArrayList();
        ar.Add(Convert.ToInt32(txtAccNo.Text));
        ar.Add(Convert.ToInt16(ddlYear.SelectedValue));
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
        string strOutput = "";
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ArrayList arm = new ArrayList();
        ar.Add(Convert.ToInt32(txtAccNo.Text));
        ar.Add(Convert.ToInt16(ddlYear.SelectedValue));
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
        gblObj.SetGridDefault(gdvCcVer, ar);
        //gdvCcVer.Enabled = false;
    }
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccNo.Text) > 0)
        {
            Session["NumEmpIdAnnStmnt"] = Convert.ToInt32(txtAccNo.Text);
            FillNameAccNo();
            ddlYear.SelectedIndex  = 0;
        }
    }
    private void FillNameAccNo()
    {
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(txtAccNo.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    protected void gdvCcVer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gblObj.SetColWidthGrid(gdvCcVer, e, 9, 18);
    }
}
