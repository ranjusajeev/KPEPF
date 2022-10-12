
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using KPEPFClassLibrary;

public partial class Contents_CardGen : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    KPEPFGeneralDAO kgen = new KPEPFGeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    CorrectionEntry crr = new CorrectionEntry();
    CorrectionEntryDao crrD = new CorrectionEntryDao();
    AORecorrectionDAO aoRecrrD = new AORecorrectionDAO();

    AGDAO agD = new AGDAO();

    LedgerM ldgr = new LedgerM();
    LedgerY ldgrY = new LedgerY();
    LedgerYDao ldgrD = new LedgerYDao();
    LedgerMDao ldgrDao = new LedgerMDao();
    static int yrDor = 0;
    static int mDor = 0;

    static string accno = "";
    static string ename = "";
    static int flgEmp = 0;
    static int flgTrn = 0;
    static int tt = 1;
    static int balmnth;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            InitialSettings();         
        }
    }
    private void InitialSettings()
    {
        gblObj.GetSessionValsByCheck(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        Session["flgPageBack"] = 6;
    }
    private void FillNameAccNoP()
    {
        gen = new GeneralDAO();
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(txtAccNoP.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsN.Tables[0].Rows[0].ItemArray[2]) == 1)
            {
                gblObj.MsgBoxOk("Already Closed!!", this);
                btnSaveDor.Enabled = false;
                btnGenP.Enabled = false;
            }
            else
            {
                lblAccP.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
                lblNameP.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
                lblDistP.Text = dsN.Tables[0].Rows[0].ItemArray[11].ToString();
                if (dsN.Tables[0].Rows[0].ItemArray[11].ToString() != "")
                {
                    Session["dtClosure"] = Convert.ToDateTime(dsN.Tables[0].Rows[0].ItemArray[11]);
                    txtDtR.Text = dsN.Tables[0].Rows[0].ItemArray[11].ToString();
                    lblDistP.Text = dsN.Tables[0].Rows[0].ItemArray[11].ToString();
                    txtDtClose.Text = dsN.Tables[0].Rows[0].ItemArray[15].ToString();
                    btnGenP.Enabled = true;
                    btnCardP.Enabled = true;
                    btnLedgerP.Enabled = true;
                    btnCorrP.Enabled = true;
                    if (dsN.Tables[0].Rows[0].ItemArray[15].ToString() != "" || dsN.Tables[0].Rows[0].ItemArray[15].ToString() == null)
                    {
                        Session["mDoc"] = gen.GetMonthIdFromID(Convert.ToInt16(Convert.ToDateTime(txtDtClose.Text).Month));
                        Session["mDiff"] = (Convert.ToDateTime(txtDtClose.Text).Subtract(Convert.ToDateTime(txtDtR.Text)).Days / 30) + 1; ;
                    }
                    
                }
                else
                {
                    Session["dtClosure"] = "";
                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("No such Employee!", this);
            txtAccNoP.Text = "";
            txtDtClose.Text = "";
            txtDtR.Text = "";
            btnGenP.Enabled = false;
            btnSaveDor.Enabled = false;
        }
    }
    protected void btnGen_Click(object sender, EventArgs e)
    {
        Add2YearDetails(1);
        gblObj.MsgBoxOk("Updated!", this);
    }
    protected void btnGenBulk_Click(object sender, EventArgs e)
    {
        if (CheckAllApp() == true)
        {
            Add2YearDetails(2);
            gblObj.MsgBoxOk("Updated!", this);
        }
        else
        {
            gblObj.MsgBoxOk("approve all districts", this);
        }
    }
    private void Add2YearDetails(int flgSingl)
    {
        ArrayList arr = new ArrayList();
        if (flgSingl == 1)
        {
            arr.Add(Convert.ToInt16(Session["intAccNo"]));
        }
        else
        {
            arr.Add(0);
        }
        arr.Add(flgSingl);
        ldgrD.UpdateYearDet4GenerateCard(arr);
    }
    private Boolean CheckAllApp()
    {
        Boolean flg = true;
        DataSet dsC = new DataSet();
        dsC = aoRecrrD.CheckApp4CardGen();
        if (dsC.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsC.Tables[0].Rows[0].ItemArray[0]) == 0)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }
        else
        {
            flg = false;
        }
        return flg;
    }

    protected void txtAccNoP_TextChanged(object sender, EventArgs e)
    {
        if (txtAccNoP.Text == "" || txtAccNoP.Text == null)
        {
            gblObj.MsgBoxOk("Enter Acc No.", this);
            //SetGridDefaultP();
            btnGenP.Enabled = false;
        }
        else
        {
            Session["intAccNo"] = Convert.ToInt32(txtAccNoP.Text);
            FillNameAccNoP();
        }
    }
    private Boolean chkDOR(string dor)
    {
        Boolean flg = false;
        DataSet dsCg = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(dor);
        yrDor = kgen.gFunFindYearIdFromDate(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(DateTime.Now.ToString());

        int yrNw = kgen.gFunFindYearIdFromDate(ar1);
        //int yrNw = 50;
        if (yrDor != 0)
        {
            if (yrDor == yrNw)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }
        else
        {
            flg = false;
        }
        flg = true;
        return flg;
    }
    //private void CalcMonthlyAmtsBulk4MltplRt(int accno, int cnt, int intStMth, int intEndMth, int flg, int rw,int calcMonth)
    //{
    //    int j = 0, k = 0, mid1 = 0, mid2 = 0, maxLoop = 0;
    //    ArrayList ary = new ArrayList();
    //    DataSet dsy = new DataSet();
    //    ary.Add(accno);
    //    ary.Add(Convert.ToInt16(Session["intYrCal"]));
    //    dsy = ldgrDao.CreditCardBulk(ary);
    //    if (dsy.Tables[0].Rows.Count > 0)
    //    {
    //        //Session["maxRec"] = cnt;
    //        ldgrY.IntAccNo = accno;
    //        ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
    //        ldgrY.DblTotRemAmt = 0;
    //        ldgrY.DblTotWithAmt = 0;
    //        ldgrY.DblTotAmtForInt = 0;
    //        ldgrY.DblRemOBIntAmt = 0;
    //        ldgrY.DblTotWithAmtForInt = 0;
    //        if (flg == 0)
    //        {
    //            j = 0;
    //        }
    //        else
    //        {
    //            j = rw;
    //            maxLoop = j + cnt;
    //        }
    //        ////////////////////////////////////////////
    //        if (calcMonth < j + cnt)
    //        {
    //            maxLoop = calcMonth;
    //        }
    //        else
    //        {
    //            maxLoop = j + cnt;
    //        }
    //        /////////////////////////////////////////////
    //        //for (int i = j; i < j + cnt; i++)
    //        for (int i = j; i < maxLoop; i++)
    //        {
    //            //if (calcMonth < Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[3]))
    //            //{
    //                if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
    //                {
    //                    if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() == "0")
    //                    {
    //                        ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[7]);
    //                    }
    //                    else
    //                    {
    //                        ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
    //                    }
    //                }
    //                else
    //                {
    //                    ldgr.IntMId[i] = 0;
    //                }
    //                if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
    //                {
    //                    ldgr.Dbl4Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[1]);
    //                }
    //                else
    //                {
    //                    ldgr.Dbl4Amt[i] = 0;
    //                }
    //                if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
    //                {
    //                    ldgr.Dbl5Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
    //                }
    //                else
    //                {
    //                    ldgr.Dbl5Amt[i] = 0;
    //                }
    //                if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
    //                {
    //                    ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
    //                }
    //                else
    //                {
    //                    ldgr.DblWithAmt[i] = 0;
    //                }
    //                if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
    //                {
    //                    ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
    //                }
    //                else
    //                {
    //                    ldgr.DblTotRemMwise[i] = 0;
    //                }
    //                ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
    //                ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
    //                ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
    //                ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];

    //                if (ldgr.DblWithAmt[i] > 0)
    //                {

    //                    if (flg == 0)   // first loop ie. j=1
    //                    {
    //                        Session["wAmt1"] = Convert.ToDouble(ldgr.DblWithAmt[i]);
    //                        if (k == 0)      // first block
    //                        {
    //                            //mid1 = cnt - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;.
    //                            mid1 = maxLoop - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
    //                        }
    //                    }
    //                    else          // second loop ie. j=2
    //                    {
    //                        Session["wAmt2"] = Convert.ToDouble(ldgr.DblWithAmt[i]);
    //                        if (k == 0)       // first block
    //                        {
    //                            mid2 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
    //                        }
    //                        else         // second block
    //                        {
    //                            mid2 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
    //                        }
    //                    }
    //                    k = k + 1;
    //                }

    //                if (mid1 > 0)
    //                {
    //                    Session["wAmt14Int1"] = Convert.ToDouble(Session["wAmt1"]) * mid1;
    //                    double a1 = Convert.ToDouble(Session["wAmt14Int1"]);
    //                }
    //                else
    //                {
    //                    Session["wAmt14Int1"] = Convert.ToDouble(Session["wAmt1"]) * cnt;
    //                    double a1 = Convert.ToDouble(Session["wAmt14Int1"]);
    //                }
    //                if (mid2 > 0)
    //                {
    //                    Session["wAmt14Int2"] = Convert.ToDouble(Session["wAmt2"]) * mid2;
    //                    double a2 = Convert.ToDouble(Session["wAmt14Int2"]);
    //                }
    //                else
    //                {
    //                    Session["wAmt14Int2"] = Convert.ToDouble(Session["wAmt2"]) * (12 - cnt);
    //                    double a2 = Convert.ToDouble(Session["wAmt14Int2"]);
    //                }
    //                ldgrY.FlgNonTrans = 0;
    //                ldgrY.DblCorrEntryAmt = 0;
    //            //}

    //            ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
    //        }
    //    }
    //}
    
    //private void CalcCurrentYearToLedgerMthlyAndLedgerYearly()
    //{
    //    double dblTotRem = 0;
    //    double dblTotWith = 0;
    //    int chgCnt = 0;
    //    DataSet dsEmp = new DataSet();
    //    Session["intYrCal"] = gen.GetCCYearId();

    //    ldgrY = new LedgerY();
    //    ldgr = new LedgerM();

    //    Session["wAmt14Int1"] = 0;
    //    Session["wAmt1"] = 0;
    //    Session["wAmt14Int2"] = 0;
    //    Session["wAmt2"] = 0;

    //    ldgrY.IntAccNo = Convert.ToInt32(Session["intAccNo"]);
    //    ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
    //    DeleteFromLedger();
    //    CalcMonthlyAmtsBulk(ldgrY.IntAccNo);
    //    if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
    //    {
    //        SaveMonthlyAmts();
    //        chgCnt = gen.NoOfTimesIntRtChgd(Convert.ToInt16(Session["intYrCal"]));
    //        if (chgCnt == 1)
    //        {
    //            ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
    //            FillConsBoxBulk();  //Calc interest
    //        }
    //        else
    //        {
    //            int intMthCnt = 0;
    //            int intStMth = 0;
    //            int intEndMth = 0;
    //            int flg = 0;
    //            DataSet dsRt = new DataSet();
    //            dsRt = gen.GetDet4MltplRt(Convert.ToInt16(Session["intYrCal"]));
    //            for (int j = 0; j < chgCnt; j++)
    //            {
    //                if (dsRt.Tables[0].Rows.Count > 0)
    //                {
    //                    ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
    //                    intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
    //                    intStMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[2]);
    //                    intEndMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[3]);

    //                    ldgrY.DblTotOB = ldgrY.DblOB * intMthCnt;

    //                    CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1, Convert.ToInt16(Session["calcMonthId"]));
    //                }
    //                ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
    //                ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
    //                dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
    //                dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
    //            }
    //            ldgrY.DblTotRemAmt = dblTotRem;
    //            ldgrY.DblTotWithAmt = dblTotWith;
    //            ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
    //            ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
    //        }
    //        SaveYearlyAmts(0);
    //    }
    //    else
    //    {
    //        FillConsBoxBulk();  //Calc interest
    //        SaveYearlyAmts(1);
    //    }
    //    ArrayList arl = new ArrayList();
    //    arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
    //    ldgrD.UpdateYearDet4GenerateCardNew(arl);

    //    /////////////////////////////
    //    empDao.UpdateL_Employee_Temp(arl);
    //    /////////////////////////////
    //}
    protected void btnGenP_Click(object sender, EventArgs e)
    {
        if (txtDtClose.Text != "" && txtDtClose.Text != null)
        {
            //  find year ////////
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToDateTime(txtDtClose.Text.ToString()));
            Session["intYr"] = kgen.FindYearIdFromDate(ar);
            //  find year ////////

            SaveToEmpMst(2);
            //CalcCurrentYearToLedgerMthlyAndLedgerYearly();
            CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle();
            PDE.InnerHtml = "";
            btnCardP.Enabled = true;
            btnLedgerP.Enabled = true;
            btnCorrP.Enabled = true;
            gblObj.MsgBoxOk("Generated!", this);
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
    }
    private void CalcCurrentYearToLedgerMthlyAndLedgerYearly()
    {
        ArrayList ar = new ArrayList();
        double dblTotRem = 0;
        double dblTotWith = 0;
        int chgCnt = 0;
        DataSet dsEmp = new DataSet();
        //Session["intYrCal"] = gen.GetCCYearId();
        //txtDtClose
        ar.Add(txtDtClose.Text.ToString());
        Session["intYrCal"] = kgen.gFunFindPDEYearIdFromDateOnline(ar);
        Session["intMthCal"] = gen.GetMonthIdFromID(Convert.ToDateTime(txtDtClose.Text).Month);
        string d = Session["intYrCal"].ToString();
        ldgrY = new LedgerY();
        ldgr = new LedgerM();

        Session["wAmt14Int1"] = 0;
        Session["wAmt1"] = 0;
        Session["wAmt14Int2"] = 0;
        Session["wAmt2"] = 0;

        ldgrY.IntAccNo = Convert.ToInt32(Session["intAccNo"]);
        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
        DeleteFromLedger();

        chgCnt = gen.NoOfTimesIntRtChgd(Convert.ToInt16(Session["intYrCal"]));
        if (chgCnt == 1)
        {
            SaveMonthlyAmts();
            CalcMonthlyAmtsBulk(ldgrY.IntAccNo);
            ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
            FillConsBoxBulk();  //Calc interest
        }
        else
        {
            int intMthCnt = 0;
            int intStMth = 0;
            int intEndMth = 0;
            int flg = 0;
            DataSet dsRt = new DataSet();
            SaveMonthlyAmts();
            findCalcMonth();
            dsRt = gen.GetDet4MltplRt(Convert.ToInt16(Session["intYrCal"]));
            for (int j = 0; j < chgCnt; j++)
            {
                if (dsRt.Tables[0].Rows.Count > 0)
                {
                    ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
                    intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
                    intStMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[2]);
                    intEndMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[3]);

                    ldgrY.DblTotOB = ldgrY.DblOB * intMthCnt;

                    CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1, Convert.ToInt16(Session["calcMonthId"]));
                }
                double a = Convert.ToDouble(Session["wAmt14Int1"]);
                double b = Convert.ToDouble(Session["wAmt14Int2"]);

                ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
                ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
                dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
                dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
            }
            ldgrY.DblTotRemAmt = dblTotRem;
            ldgrY.DblTotWithAmt = dblTotWith;
            ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
            ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
        }
        SaveYearlyAmts(0);
        ArrayList arl = new ArrayList();
        arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
        ldgrD.UpdateYearDet4GenerateCardNew(arl);

        /////////////////////////////
        empDao.UpdateL_Employee_Temp(arl);
        /////////////////////////////
    }
    //private void deleteIfExists()
    //{
    //    ArrayList ard = new ArrayList();
    //    ard.Add(Convert.ToInt32(Session["intAccNo"]));
    //    ard.Add(Convert.ToInt16(Session["intYrCal"]));
    //    ldgrD.DelLedgerYearlySingleYrwise(ard);
    //}
    private void CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle()
    {
        double dblTotRem = 0;
        double dblTotWith = 0;
        int chgCnt = 0;
        DataSet dsEmp = new DataSet();
        //Session["intYrCal"] = gen.GetCCYearId();
        ldgrY = new LedgerY();
        ldgr = new LedgerM();
        ArrayList ar = new ArrayList();
        ar.Add(txtDtClose.Text.ToString());
        Session["intYrCal"] = kgen.gFunFindPDEYearIdFromDateOnline(ar);
        Session["intMthCal"] = gen.GetMonthIdFromID(Convert.ToDateTime(txtDtClose.Text).Month);
        //Session["intMthCal"] = Convert.ToDateTime(txtDtClose.Text).Month;
        int d = Convert.ToInt16(Session["intMthCal"]);
        double dblTotAmtWithBlockCalcP = 0;
        ldgrY.IntAccNo = Convert.ToInt32(Session["intAccNo"]);
        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
        DeleteFromLedger();
        CalcMonthlyAmtsSingle(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]));
        //if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
        //{
        SaveMonthlyAmtsSingle(Convert.ToInt16(Session["intYrCal"]));
        chgCnt = gen.NoOfTimesIntRtChgd(Convert.ToInt16(Session["intYrCal"]));
        if (chgCnt == 1)
        {
            ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
            FillConsBoxBulk();  //Calc interest
        }
        else
        {
            int intMthCnt = 0;
            int intStMth = 0;
            int intEndMth = 0;
            int flg = 0;

            DataSet dsRt = new DataSet();
            dsRt = gen.GetDet4MltplRt(Convert.ToInt16(Session["intYrCal"]));
            for (int j = 0; j < chgCnt; j++)
            {
                int f = Convert.ToInt16(Session["intMthCal"]);
                if (Convert.ToInt16(Session["intMthCal"]) >= Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]))
                {
                    if (dsRt.Tables[0].Rows.Count > 0)
                    {
                        ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
                        intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
                        intStMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[2]);
                        intEndMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[3]);

                        ldgrY.DblTotOB = findOBSplits(Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[5]), Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]), Convert.ToInt16(Session["intMthCal"]), ldgrY.DblOB);

                        CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1, Convert.ToInt16(Session["intYrCal"]));
                    }
                    //ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);

                    if (j == 0)
                    {
                        ldgrY.DblTotAmtWithBlock = ldgrY.DblTotAmtWithBlockCalc;
                    }
                    else
                    {
                        ldgrY.DblTotAmtWithBlock = ldgrY.DblTotAmtWithBlockCalc - dblTotAmtWithBlockCalcP;
                    }
                    dblTotAmtWithBlockCalcP = ldgrY.DblTotAmtWithBlockCalc;

                    ldgrY.DblTotWithAmtForInt = ldgrY.DblTotAmtWithBlock;
                    ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
                    dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
                    dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
                }
            }
            ldgrY.DblTotRemAmt = dblTotRem;
            ldgrY.DblTotWithAmt = dblTotWith;
            ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
            ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
            //FillConsBoxBulkMltplIntRt();
        }
        SaveYearlyAmtsSingle(0, Convert.ToInt16(Session["intYrCal"]));
        ArrayList aru = new ArrayList();
        aru.Add(Convert.ToInt32(Session["intAccNo"]));
        ldgrD.UpdateYearDet4GenerateCardNew(aru);


        //double dblTotRem = 0;
        //double dblTotWith = 0;
        //int chgCnt = 0;
        //DataSet dsEmp = new DataSet();
        ////Session["intYrCal"] = gen.GetCCYearId();
        //ldgrY = new LedgerY();
        //ldgr = new LedgerM();

        //ArrayList ar = new ArrayList();
        //ar.Add(txtDtClose.Text.ToString());
        //Session["intYrCal"] = kgen.gFunFindPDEYearIdFromDateOnline(ar);
        //Session["intMthCal"] = gen.GetMonthIdFromID(Convert.ToDateTime(txtDtClose.Text).Month);
        ////Session["intMthCal"] = Convert.ToDateTime(txtDtClose.Text).Month;
        //int d = Convert.ToInt16(Session["intMthCal"]);
        //double dblTotAmtWithBlockCalcP = 0;
        //ldgrY.IntAccNo = Convert.ToInt32(Session["intAccNo"]);
        //ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
        //DeleteFromLedger();
        //CalcMonthlyAmtsSingle(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]));
        ////if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
        ////{
        //    SaveMonthlyAmtsSingle(Convert.ToInt16(Session["intYrCal"]));
        //    chgCnt = gen.NoOfTimesIntRtChgd(Convert.ToInt16(Session["intYrCal"]));
        //    if (chgCnt == 1)
        //    {
        //        ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
        //        FillConsBoxBulk();  //Calc interest
        //    }
        //    else
        //    {
        //        int intMthCnt = 0;
        //        int intStMth = 0;
        //        int intEndMth = 0;
        //        int flg = 0;

        //        DataSet dsRt = new DataSet();
        //        dsRt = gen.GetDet4MltplRt(Convert.ToInt16(Session["intYrCal"]));
        //        for (int j = 0; j < chgCnt; j++)
        //        {
        //            if (dsRt.Tables[0].Rows.Count > 0)
        //            {
        //                ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
        //                intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
        //                intStMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[2]);
        //                intEndMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[3]);

        //                ldgrY.DblTotOB = findOBSplits(Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[5]),Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]), Convert.ToInt16(Session["intMthCal"]),ldgrY.DblOB);

        //                CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1, Convert.ToInt16(Session["intYrCal"]));
        //            }
        //            //ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);

        //            if (j == 0)
        //            {
        //                ldgrY.DblTotAmtWithBlock = ldgrY.DblTotAmtWithBlockCalc;
        //            }
        //            else
        //            {
        //                ldgrY.DblTotAmtWithBlock = ldgrY.DblTotAmtWithBlockCalc - dblTotAmtWithBlockCalcP;
        //            }
        //            dblTotAmtWithBlockCalcP = ldgrY.DblTotAmtWithBlockCalc;

        //            ldgrY.DblTotWithAmtForInt = ldgrY.DblTotAmtWithBlock;
        //            ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
        //            dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
        //            dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
        //        }
        //        ldgrY.DblTotRemAmt = dblTotRem;
        //        ldgrY.DblTotWithAmt = dblTotWith;
        //        ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
        //        ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
        //        //FillConsBoxBulkMltplIntRt();
        //    }
        //    SaveYearlyAmtsSingle(0, Convert.ToInt16(Session["intYrCal"]));
    }
    private double findOBSplits(int emth, int cnt, int mth,double amt)
    {
        double amtr = 0;
        if (emth < mth)
        {
            amtr = amt * cnt;
        }
        else
        {
            amtr = amt * (cnt - (emth - mth));
        }
        return amtr;
    }
    private void SaveYearlyAmtsSingle(int flgNonTrans, int yr)
    {
        ArrayList ary = new ArrayList();
        ary.Add(ldgrY.IntAccNo);
        ary.Add(yr);
        ary.Add(ldgrY.DblOB.ToString());
        ary.Add(ldgrY.DblTotRemAmt);
        ary.Add(Math.Round(ldgrY.DblIntAmt));
        ary.Add(ldgrY.DblRemOBIntAmt);
        ary.Add(ldgrY.DblTotWithAmt);
        ary.Add(ldgrY.DblCB);
        ary.Add(Convert.ToInt16(Session["mDoc"]));
        ary.Add(ldgrY.DblTotAmtForInt);
        ary.Add(ldgrY.DblTotWithAmtForInt);
        ary.Add(ldgrY.DblTotOB);
        ary.Add(flgNonTrans);
        ary.Add(ldgrY.DblCorrEntryAmt);
        ldgrD.SaveLedgerY(ary);
    }
    private void CalcMonthlyAmtsBulk4MltplRt(int accno, int cnt, int intStMth, int intEndMth, int flg, int rw, int yr)
    {
        int j = 0, k = 0; //, mid1=0, mid2=0;
        //Double wTot = 0;

        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(yr);
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = cnt;
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = yr;
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            if (flg == 0)
            {
                j = 0;
            }
            else
            {
                j = rw;
            }
            for (int i = j; i < j + cnt; i++)
            {
                if (Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[3]) <= Convert.ToInt16(Session["intMthCal"]))
                {
                    if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                    {
                        if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() == "0")
                        {
                            ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[7]);
                        }
                        else
                        {
                            ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
                        }
                    }
                    else
                    {
                        ldgr.IntMId[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                    {
                        ldgr.Dbl4Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[1]);
                    }
                    else
                    {
                        ldgr.Dbl4Amt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                    {
                        ldgr.Dbl5Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                    }
                    else
                    {
                        ldgr.Dbl5Amt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                    }
                    else
                    {
                        ldgr.DblWithAmt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                    {
                        ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                    }
                    else
                    {
                        ldgr.DblTotRemMwise[i] = 0;
                    }
                    ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
                    ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
                    ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
                    ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];
                    ldgrY.DblTotAmtWithBlockSingle = ldgrY.DblTotAmtWithBlockSingle + ldgr.DblWithAmt[i];
                    ldgrY.DblTotAmtWithBlockCalc = ldgrY.DblTotAmtWithBlockCalc + ldgrY.DblTotAmtWithBlockSingle;
                }
            }
        }
    }
    private void SaveMonthlyAmtsSingle(int yr)
    {
        int k = 0;
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(ldgrY.IntAccNo);
        ary.Add(yr);
        dsy = ldgrDao.CreditCard(ary);
        int j = 0;
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;    
            //Session["maxRec"] = Convert.ToInt16(Session["intMthCal"]); 
            ldgrY.IntYrId = yr;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
            {
                if (Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[17]) <= Convert.ToInt16(Session["intMthCal"]))
                {
                    if (dsy.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                    {
                        ldgr.IntDayId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[12]);
                    }
                    else
                    {
                        ldgr.IntDayId[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                    {
                        ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[9]);
                    }
                    else
                    {
                        ldgr.IntMId[i] = 0;
                    }

                    if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                    {
                        ldgr.DtChalDate[i] = Convert.ToDateTime(dsy.Tables[0].Rows[i].ItemArray[1]);
                    }
                    else
                    {
                        ldgr.DtChalDate[i] = Convert.ToDateTime("01/01/1960");

                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                    {
                        ldgr.DblMsAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                    }
                    else
                    {
                        ldgr.DblMsAmt[i] = 0;
                    }

                    if (dsy.Tables[0].Rows[i].ItemArray[3].ToString() != "")
                    {
                        ldgr.DblRfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[3]);
                    }
                    else
                    {
                        ldgr.DblRfAmt[i] = 0;
                    }

                    if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                    {
                        ldgr.DblPfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[4]);
                    }
                    else
                    {
                        ldgr.DblPfAmt[i] = 0;
                    }

                    if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        ldgr.DblDAAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                    }
                    else
                    {
                        ldgr.DblDAAmt[i] = 0;
                    }

                    if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                    {
                        ldgr.DblPayAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                    }
                    else
                    {
                        ldgr.DblPayAmt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[11].ToString() != "")
                    {
                        ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[11]);
                    }
                    else
                    {
                        ldgr.DblWithAmt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[7].ToString() != "")
                    {
                        ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[7]);
                    }
                    else
                    {
                        ldgr.DblTotRemMwise[i] = 0;
                    }

                    if (dsy.Tables[0].Rows[i].ItemArray[14].ToString() != "")
                    {
                        ldgr.IntLBId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[14]);
                    }
                    else
                    {
                        ldgr.IntLBId[i] = 0;
                    }

                    //////////To update FlgRemTorAG//////////
                    if (dsy.Tables[0].Rows[i].ItemArray[18].ToString() != "")
                    {
                        ldgr.FlgRemTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
                    }
                    else
                    {
                        ldgr.FlgRemTorAG[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                    {
                        ldgr.FlgWithTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[19]);
                    }
                    else
                    {
                        ldgr.FlgWithTorAG[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[20].ToString() != "")
                    {
                        ldgr.IntAGEntryId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[20]);
                    }
                    else
                    {
                        ldgr.IntAGEntryId[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[21].ToString() != "")
                    {
                        ldgr.IntAGEntryIdWith[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[21]);
                    }
                    else
                    {
                        ldgr.IntAGEntryIdWith[i] = 0;
                    }
                    //////////To update FlgRemTorAG//////////

                    ArrayList arm = new ArrayList();

                    arm.Add(ldgrY.IntAccNo);
                    arm.Add(ldgrY.IntYrId);
                    arm.Add(ldgr.IntDayId[i]);
                    arm.Add(ldgr.IntMId[i]);
                    arm.Add(ldgr.DtChalDate[i]);
                    arm.Add(ldgr.DblMsAmt[i]);
                    arm.Add(ldgr.DblRfAmt[i]);
                    arm.Add(ldgr.DblPfAmt[i]);
                    arm.Add(ldgr.DblDAAmt[i]);
                    arm.Add(ldgr.DblPayAmt[i]);
                    arm.Add(ldgr.DblWithAmt[i]);

                    if (i != 0 && ldgr.IntMId[i] == ldgr.IntMId[i - 1])
                    {
                        arm.Add(0);
                        k = k + 1;
                        j = i - k + 1;
                    }
                    else
                    {
                        arm.Add(ldgr.DblAmtForInt[j]);
                        j = j + 1;
                    }

                    arm.Add(ldgr.IntLBId[i]);
                    arm.Add(ldgr.FlgRemTorAG[i]);
                    arm.Add(ldgr.FlgWithTorAG[i]);
                    arm.Add(ldgr.IntAGEntryId[i]);
                    arm.Add(ldgr.IntAGEntryIdWith[i]);
                    ldgrDao.SaveLedgerM(arm);

                }
            }
        }

    }
    private void CalcMonthlyAmtsSingle(int accno, int yr)
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(yr);
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            //Session["maxRec"] = Convert.ToInt16(Session["intMthCal"]);
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = yr;
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
            {
                if (Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[3]) <= Convert.ToInt16(Session["intMthCal"]))
                {
                    if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                    {
                        if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() == "0")
                        {
                            ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[7]);
                        }
                        else
                        {
                            ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
                        }
                    }
                    else
                    {
                        ldgr.IntMId[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                    {
                        ldgr.Dbl4Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[1]);
                    }
                    else
                    {
                        ldgr.Dbl4Amt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                    {
                        ldgr.Dbl5Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                    }
                    else
                    {
                        ldgr.Dbl5Amt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                    }
                    else
                    {
                        ldgr.DblWithAmt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                    {
                        ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                    }
                    else
                    {
                        ldgr.DblTotRemMwise[i] = 0;
                    }
                    ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
                    ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
                    ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
                    ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];
                    ldgrY.DblTotWithAmtForInt = ldgrY.DblTotWithAmtForInt + CalculateBalMonthsBulk(ldgr.IntMId[i]) * ldgr.DblWithAmt[i];
                    ldgrY.FlgNonTrans = 0;
                    ldgrY.DblCorrEntryAmt = 0;
                }
            }
        }
        //gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    }
    private void findCalcMonth()
    {
        Session["calcMonthId"] = gen.GetMonthIdFromID(Convert.ToDateTime(txtDtClose.Text).Month);
        int m = Convert.ToInt16(Session["calcMonthId"]);
    }
    private void FillConsBox()
    {
        txtOb.Text = ldgrY.DblOB.ToString();
        ldgrY.DblOB = Convert.ToDouble(txtOb.Text);
        ldgrY.DblTotOB = Convert.ToDouble(txtOb.Text) * Convert.ToInt16(Session["mDoc"]);
        //txtRem.Text = gdvP.FooterRow.Cells[7].Text.ToString(); //gblObj.SetFooterTotals(gdvP, 7);
        txtRem.Text = ldgrY.DblTotRemAmt.ToString();
        ldgrY.DblTotRemAmt = Convert.ToDouble(txtRem.Text);
        ldgrY.DblIntAmt = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
        txtInt.Text = Convert.ToString(Math.Round(ldgrY.DblIntAmt));
        txtTot.Text = Convert.ToString(Convert.ToDouble(txtOb.Text) + Convert.ToDouble(txtRem.Text) + Convert.ToDouble(txtInt.Text));
        ldgrY.DblRemOBIntAmt = Convert.ToDouble(txtTot.Text);
        //txtWith.Text = gdvP.FooterRow.Cells[8].Text;
        txtWith.Text = ldgrY.DblTotWithAmt.ToString();
        ldgrY.DblTotWithAmt = Convert.ToDouble(txtWith.Text);
        txtCb.Text = Convert.ToString(Convert.ToDouble(txtTot.Text) - Convert.ToDouble(txtWith.Text));
        ldgrY.DblCB = Convert.ToDouble(txtCb.Text);
    }
    private void FillConsBoxBulk()
    {
        ldgrY.DblOB = ldgrY.DblOB;
        ldgrY.DblTotOB = ldgrY.DblOB * 12;
        ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
        ldgrY.DblIntAmt = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
        ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
        ldgrY.DblCB = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
    }

    private int FindNoOfMths(int mid)
    {
        int mths = 0;
        if (mid == 4)
            mths = 1;
        else if (mid == 5)
            mths = 2;
        else if (mid == 6)
            mths = 3;
        else if (mid == 7)
            mths = 4;
        else if (mid == 8)
            mths = 5;
        else if (mid == 9)
            mths = 6;
        else if (mid == 10)
            mths = 7;
        else if (mid == 11)
            mths = 8;
        else if (mid == 12)
            mths = 9;
        else if (mid == 1)
            mths = 10;
        else if (mid == 2)
            mths = 11;
        else if (mid == 3)
            mths = 12;
        return mths;
    }
    private Boolean IsOBPrev()
    {
        Boolean flg = true;
        if (ldgrY.DblOB == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void SaveYearlyAmts(int flgNonTrans)
    {
        ArrayList ary = new ArrayList();
        ary.Add(ldgrY.IntAccNo);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        ary.Add(ldgrY.DblOB.ToString());
        ary.Add(ldgrY.DblTotRemAmt);
        ary.Add(Math.Round(ldgrY.DblIntAmt));
        ary.Add(ldgrY.DblRemOBIntAmt);
        ary.Add(ldgrY.DblTotWithAmt);
        ary.Add(ldgrY.DblCB);
        ary.Add(Convert.ToInt16(Session["mDoc"]));
        ary.Add(ldgrY.DblTotAmtForInt);
        ary.Add(ldgrY.DblTotWithAmtForInt);
        ary.Add(ldgrY.DblTotOB);
        ary.Add(flgNonTrans);
        ary.Add(ldgrY.DblCorrEntryAmt);
        ary.Add(1);
        ldgrD.SaveLedgerYPartial(ary);

        ///////// Corr Entry /////
        ArrayList arl = new ArrayList();
        arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
        ldgrD.UpdateYearDet4GenerateCardNew(arl);
        ///////// Corr Entry /////
    }
    private void SaveMonthlyAmtsP()
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(ldgrY.IntAccNo);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCard(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            //ldgrY.IntAccNo = 758;
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
            //ldgrY.DblTotRemAmt = 0;
            //ldgrY.DblTotWithAmt = 0;
            //ldgrY.DblTotAmtForInt = 0;
            //ldgrY.DblRemOBIntAmt = 0;
            //ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
            {
                if (dsy.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                {
                    ldgr.IntDayId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[12]);
                }
                else
                {
                    ldgr.IntDayId[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                {
                    ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[9]);
                }
                else
                {
                    ldgr.IntMId[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                {
                    ldgr.DtChalDate[i] = Convert.ToDateTime(dsy.Tables[0].Rows[i].ItemArray[1]);
                }
                else
                {
                    ldgr.DtChalDate[i] = Convert.ToDateTime("01/01/1960");

                }
                if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                {
                    ldgr.DblMsAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                }
                else
                {
                    ldgr.DblMsAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[3].ToString() != "")
                {
                    ldgr.DblRfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[3]);
                }
                else
                {
                    ldgr.DblRfAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                {
                    ldgr.DblPfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[4]);
                }
                else
                {
                    ldgr.DblPfAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {
                    ldgr.DblDAAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                }
                else
                {
                    ldgr.DblDAAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                {
                    ldgr.DblPayAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                }
                else
                {
                    ldgr.DblPayAmt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[11].ToString() != "")
                {
                    ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[11]);
                }
                else
                {
                    ldgr.DblWithAmt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[7].ToString() != "")
                {
                    ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[7]);
                }
                else
                {
                    ldgr.DblTotRemMwise[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[14].ToString() != "")
                {
                    ldgr.IntLBId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[14]);
                }
                else
                {
                    ldgr.IntLBId[i] = 0;
                }

                //////////To update FlgRemTorAG//////////
                if (dsy.Tables[0].Rows[i].ItemArray[18].ToString() != "")
                {
                    ldgr.FlgRemTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
                }
                else
                {
                    ldgr.FlgRemTorAG[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                {
                    ldgr.FlgWithTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[19]);
                }
                else
                {
                    ldgr.FlgWithTorAG[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[20].ToString() != "")
                {
                    ldgr.IntAGEntryId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[20]);
                }
                else
                {
                    ldgr.IntAGEntryId[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[21].ToString() != "")
                {
                    ldgr.IntAGEntryIdWith[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[21]);
                }
                else
                {
                    ldgr.IntAGEntryIdWith[i] = 0;
                }
                //////////To update FlgRemTorAG//////////

                ArrayList arm = new ArrayList();
                arm.Add(ldgrY.IntAccNo);
                arm.Add(Convert.ToInt16(Session["intYrCal"]));
                arm.Add(ldgr.IntDayId[i]);
                arm.Add(ldgr.IntMId[i]);
                arm.Add(ldgr.DtChalDate[i]);
                arm.Add(ldgr.DblMsAmt[i]);
                arm.Add(ldgr.DblRfAmt[i]);
                arm.Add(ldgr.DblPfAmt[i]);
                arm.Add(ldgr.DblDAAmt[i]);
                arm.Add(ldgr.DblPayAmt[i]);
                arm.Add(ldgr.DblWithAmt[i]);
                arm.Add(ldgr.DblAmtForInt[i]);
                arm.Add(ldgr.IntLBId[i]);
                arm.Add(ldgr.FlgRemTorAG[i]);
                arm.Add(ldgr.FlgWithTorAG[i]);
                arm.Add(ldgr.IntAGEntryId[i]);
                arm.Add(ldgr.IntAGEntryIdWith[i]);
                ldgrDao.SaveLedgerM(arm);

            }
        }
    }

    //private void SaveMonthlyAmts()
    //{
    //    ArrayList ary = new ArrayList();
    //    DataSet dsy = new DataSet();
    //    ary.Add(ldgrY.IntAccNo);
    //    ary.Add(Convert.ToInt16(Session["intYrCal"]));
    //    dsy = ldgrDao.CreditCard(ary);
    //    if (dsy.Tables[0].Rows.Count > 0)
    //    {
    //        ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
    //        for (int i = 0; i < Convert.ToInt16(Session["calcMonthId"]); i++)
    //        {
    //            int d = 4;
    //            gblObj.MsgBoxOk(d.ToString(), this);

    //        }
    //    }
    //}

    private void SaveMonthlyAmts()
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(ldgrY.IntAccNo);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCard(ary);
        //findCalcMonth();
        if (dsy.Tables[0].Rows.Count > 0)
        {
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
            for (int i = 0; i < Convert.ToInt16(Session["intMthCal"]); i++)
            //for (int i = 0; i < 4; i++)
            {
                if (dsy.Tables[0].Rows[i].ItemArray[12].ToString() != "")
                {
                    ldgr.IntDayId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[12]);
                }
                else
                {
                    ldgr.IntDayId[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[9].ToString() != "")
                {
                    ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[9]);
                }
                else
                {
                    ldgr.IntMId[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                {
                    ldgr.DtChalDate[i] = Convert.ToDateTime(dsy.Tables[0].Rows[i].ItemArray[1]);
                }
                else
                {
                    ldgr.DtChalDate[i] = Convert.ToDateTime("01/01/1960");

                }
                if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                {
                    ldgr.DblMsAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                }
                else
                {
                    ldgr.DblMsAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[3].ToString() != "")
                {
                    ldgr.DblRfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[3]);
                }
                else
                {
                    ldgr.DblRfAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                {
                    ldgr.DblPfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[4]);
                }
                else
                {
                    ldgr.DblPfAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {
                    ldgr.DblDAAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                }
                else
                {
                    ldgr.DblDAAmt[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                {
                    ldgr.DblPayAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                }
                else
                {
                    ldgr.DblPayAmt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[11].ToString() != "")
                {
                    ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[11]);
                }
                else
                {
                    ldgr.DblWithAmt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[7].ToString() != "")
                {
                    ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[7]);
                }
                else
                {
                    ldgr.DblTotRemMwise[i] = 0;
                }

                if (dsy.Tables[0].Rows[i].ItemArray[14].ToString() != "")
                {
                    ldgr.IntLBId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[14]);
                }
                else
                {
                    ldgr.IntLBId[i] = 0;
                }

                //////////To update FlgRemTorAG//////////
                if (dsy.Tables[0].Rows[i].ItemArray[18].ToString() != "")
                {
                    ldgr.FlgRemTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
                }
                else
                {
                    ldgr.FlgRemTorAG[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[19].ToString() != "")
                {
                    ldgr.FlgWithTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[19]);
                }
                else
                {
                    ldgr.FlgWithTorAG[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[20].ToString() != "")
                {
                    ldgr.IntAGEntryId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[20]);
                }
                else
                {
                    ldgr.IntAGEntryId[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[21].ToString() != "")
                {
                    ldgr.IntAGEntryIdWith[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[21]);
                }
                else
                {
                    ldgr.IntAGEntryIdWith[i] = 0;
                }
                //////////To update FlgRemTorAG//////////

                ArrayList arm = new ArrayList();
                arm.Add(ldgrY.IntAccNo);
                arm.Add(Convert.ToInt16(Session["intYrCal"]));
                arm.Add(ldgr.IntDayId[i]);
                arm.Add(ldgr.IntMId[i]);
                arm.Add(ldgr.DtChalDate[i]);
                arm.Add(ldgr.DblMsAmt[i]);
                arm.Add(ldgr.DblRfAmt[i]);
                arm.Add(ldgr.DblPfAmt[i]);
                arm.Add(ldgr.DblDAAmt[i]);
                arm.Add(ldgr.DblPayAmt[i]);
                arm.Add(ldgr.DblWithAmt[i]);
                arm.Add(ldgr.DblAmtForInt[i]);
                arm.Add(ldgr.IntLBId[i]);
                arm.Add(ldgr.FlgRemTorAG[i]);
                arm.Add(ldgr.FlgWithTorAG[i]);
                arm.Add(ldgr.IntAGEntryId[i]);
                arm.Add(ldgr.IntAGEntryIdWith[i]);
                ldgrDao.SaveLedgerM(arm);

            }
        }
    }
    private Boolean IsData(double remAmt, double withAmt)
    {
        Boolean flg = true;
        if (remAmt == 0 && withAmt == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void CalcMonthlyAmts()
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(Convert.ToInt16(Session["intAccNo"]));
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            ldgrY.IntAccNo = Convert.ToInt16(Session["intAccNo"]);
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
            {
                if (Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[3]) <= Convert.ToInt16(Session["mDiff"]))
                {
                    if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                    {
                        ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
                    }
                    else
                    {
                        ldgr.IntMId[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                    {
                        ldgr.Dbl4Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[1]);
                    }
                    else
                    {
                        ldgr.Dbl4Amt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                    {
                        ldgr.Dbl5Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                    }
                    else
                    {
                        ldgr.Dbl5Amt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                    {
                        ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                    }
                    else
                    {
                        ldgr.DblWithAmt[i] = 0;
                    }
                    if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                    {
                        ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                    }
                    else
                    {
                        ldgr.DblTotRemMwise[i] = 0;
                    }
                    ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
                    ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
                    ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
                    ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];

                    ldgrY.DblTotWithAmtForInt = ldgrY.DblTotWithAmtForInt + CalculateBalMonthsBulk(ldgr.IntMId[i]) * ldgr.DblWithAmt[i];
                    ldgrY.FlgNonTrans = 0;
                    ldgrY.DblCorrEntryAmt = 0;

                }
            }
        }
    }
    private int CalculateBalMonths(int mid)
    {
        int intMonthId = 0;
        int mths = 0;
        intMonthId = gen.GetMonthIdFromID(Convert.ToInt16(Session["mDoc"]));
        mths = intMonthId - mid + 1;
        return mths;
    }
    private int CalculateBalMonthsBulk(int mid)
    {
        int intMonthId = 0;
        int midn = 0;
        int mths = 0;
        //intMonthId = gen.GetMonthIdFromID(Convert.ToInt16(Session["mDoc"]));
        midn = gen.GetMonthIdFromID(Convert.ToInt16(mid));
        mths = 12 - midn + 1;
        return mths;
    }
    private void CheckDupMonth(int maxRec)
    {
        for (int i = 1; i < maxRec; i++)
        {
            if (ldgr.IntMId[i] == ldgr.IntMId[i - 1])
            {
                if (ldgr.IntDayId[i] <= 4)
                {
                    ldgr.DblAmtForInt[i] = ldgr.DblAmtForInt[i - 1] + ldgr.DblTotRemMwise[i];
                    ldgr.DblAmtForInt[i - 1] = 0;
                }
                else
                {
                    ldgr.DblAmtForInt[i] = ldgr.DblAmtForInt[i - 1];
                    ldgr.DblAmtForInt[i - 1] = 0;
                }
            }
        }

    }
    private double CalculateAmtForInt(int rowNo)
    {
        double amt = 0;

        if (rowNo == 0)
        {
            amt = ldgr.Dbl4Amt[rowNo];
        }
        else
        {
            amt = ldgr.DblAmtForInt[rowNo - 1] + ldgr.Dbl5Amt[rowNo - 1] + ldgr.Dbl4Amt[rowNo];
        }
        return amt;
    }

    private double FindOB()
    {
        double amt = 0;
        ArrayList arob = new ArrayList();
        DataSet dsob = new DataSet();
        arob.Add(Convert.ToInt16(Session["intAccNo"]));
        arob.Add(Convert.ToInt16(Session["intYrCal"]) - 1);

        dsob = ldgrD.GetOB(arob);
        if (dsob.Tables[0].Rows.Count > 0)
        {
            amt = Convert.ToDouble(dsob.Tables[0].Rows[0].ItemArray[0]);
        }
        return amt;
    }
    private void DeleteFromLedger()
    {
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(Convert.ToInt16(Session["intAccNo"]));
        arL.Add(Convert.ToInt16(Session["intYrCal"]));
        ldgrD.DelLedgerYearly(arL);
    }

    protected void txtDtClose_TextChanged(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        if ((txtAccNoP.Text != "" || txtAccNoP.Text != null) && (txtDtClose.Text != "" && txtDtClose.Text != null))
        {
            string dt1;
            if (Session["dtClosure"].ToString() != null || Session["dtClosure"].ToString() != "")
            {
                dt1 = lblDistP.Text.ToString();
            }
            else
            {
                dt1 = txtDtR.Text.ToString();
            }
            string dt2 = txtDtClose.Text.ToString();
            if (gblObj.isValidDate(txtDtClose, this) == true)
            {
                //if (gblObj.CheckDate2(dt1, dt2) == true)
                //{
                
                Session["mDoc"] = gen.GetMonthIdFromID(Convert.ToInt16(Convert.ToDateTime(dt2).Month));
                Session["mDiff"] = (Convert.ToDateTime(dt2).Subtract(Convert.ToDateTime(dt1)).Days / 30) + 1;
                int a = Convert.ToInt16(Session["mDoc"]);
                int b = Convert.ToInt16(Session["mDiff"]);
                btnGenP.Enabled = true;
                btnCardP.Enabled = true;
                btnLedgerP.Enabled = true;
                btnCorrP.Enabled = true;
                //}
                //else
                //{
                //    txtDtClose.Text = "";
                //    gblObj.MsgBoxOk("Invalid date!", this);
                //}
            }
            else
            {
                txtDtClose.Text = "";
                btnGenP.Enabled = false;
                btnCardP.Enabled = false;
                btnLedgerP.Enabled = false;
                btnCorrP.Enabled = false;
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details!", this);
            btnCardP.Enabled = false;
        }
    }
    protected void btnCardP_Click(object sender, EventArgs e)
    {

        DataSet dsEmp = new DataSet();
        //Session["intYrCal"] = gen.GetCCYearId();
        emp.NumEmpID = Convert.ToInt16(Session["intAccNo"]);
        dsEmp = empDao.GetEmployeeDetails(emp, 1);
        if (dsEmp.Tables[0].Rows.Count > 0)
        {
            accno = dsEmp.Tables[0].Rows[0].ItemArray[0].ToString();
            ename = dsEmp.Tables[0].Rows[0].ItemArray[1].ToString();
            flgEmp = 0;
        }
        else
        {
            flgEmp = 1;
        }
        //////////////////ChkEmp/////////////

        //////////////////ChkTrn/////////////
        DataSet dsTrn = new DataSet();
        ArrayList arE = new ArrayList();
        arE.Add(int.Parse(Session["intAccNo"].ToString()));
        //arE.Add(int.Parse(Session["intYrCal"].ToString()));
        arE.Add(int.Parse(Session["intYr"].ToString()));
        dsTrn = ldgrD.GetYearlyDetLat(arE);
        if (dsTrn.Tables[0].Rows.Count > 0)
        {
            flgTrn = Convert.ToInt16(dsTrn.Tables[0].Rows[0].ItemArray[9]);
        }
        else
        {
            flgTrn = 1;
        }
        //////////////////ChkTrn/////////////
        if (flgEmp == 0 && flgTrn == 0)
        {
            //ds = gen.CCard(arrIn);
            string strFileName = strGenerateFileName();
            string RptHead = "Directate of Panchayath";
            string FlPath = Request.PhysicalApplicationPath + "PDF/" + strFileName;
            //GeneratePDF(FlPath, strFileName);

            if (CorrectionExists(Convert.ToInt32(Session["intAccNo"])) == true)
            {
                GeneratePDFCorrEntry(FlPath, strFileName);
            }

            else
            {
                GeneratePDF(FlPath, strFileName);
            }

        }
        else if (flgEmp == 0 && flgTrn == 1)
        {
            gblObj.MsgBoxOk("No transactions for this year.", this);
        }
        else
        {
            gblObj.MsgBoxOk("No such Account no.", this);
        }

    }
    private void GeneratePDFCorrEntry(string FlPath, string strFileName)
    {
        Document docTab1 = new Document();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        ArrayList arrIn = new ArrayList();
        ArrayList ary = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["intAccNo"]));
        arrIn.Add(Convert.ToInt32(Session["intYrCal"]));
        ds1 = gen.CCardNew(arrIn);
        if (Convert.ToInt16(ds1.Tables[0].Rows.Count) > 0)
        {
            //arrIn1.Add(Convert.ToInt32(Session["intYrCal"]));
            //ds3 = gen.Interest(arrIn1);
            arrIn1.Add(Convert.ToInt32(Session["intYrCal"]));
            ds3 = gen.InterestMltpl(arrIn1);

            float subscrip = 0, refund = 0, BF = 0, arrDA = 0, Inter = 0, Tot = 0, OB = 0, total = 0, withdrawal = 0, ToArrSub = 0;
            //PdfWriter.GetInstance(docTab1, new FileStream(Request.PhysicalApplicationPath + "/b1.pdf", FileMode.Create));
            PdfWriter writer = PdfWriter.GetInstance(docTab1, new FileStream(FlPath, FileMode.Create));

            //********* Head Print date ************
            string date;
            date = DateTime.Today.Date.ToString().Substring(0, 10);
            Phrase headphraseprint = new Phrase("Printed on " + date, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter headprint = new HeaderFooter(headphraseprint, false);
            headprint.Border = Rectangle.NO_BORDER;
            headprint.Alignment = Element.ALIGN_RIGHT;
            docTab1.Header = headprint;

            //******* Foot Page number ************

            Phrase footPhraseImg = new Phrase("Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Swaraj Bhavan(6th floor), Nanthancode, Kowdiar P.O,Tvpm Phone:- 0471-2723043  Email :- aokpepf@lsgkerala.in along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)\n\t\t\t\t\tKPEPF details of all Subscribers being updated on the website\t\t http://www.lsgkerala.gov.in/kpepf \n 4. Subscribers attention is also drawn to Rule 27 of KPEPF Rules 1976 for compliance. \n\nPage:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter footer = new HeaderFooter(footPhraseImg, true);
            footer.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            footer.Alignment = Element.ALIGN_LEFT;
            docTab1.Footer = footer;
            docTab1.Open();


            ////for (int cnt = intStYr; cnt <= intEndYr; cnt++)
            ////{

            ////    strYear = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
            int numEmpId = Convert.ToInt32(Session["intAccNo"]);
            //for (int cnt = 1; cnt <= 11; cnt++)
            //{
            Font[] fonts = new Font[1];
            fonts[0] = FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.BOLD);
            //ds2 = gen.GetEmpAccWise(1,numEmpId,"");
            //Header****    ******************
            //Paragraph head = new Paragraph(new Chunk("Kerala Municipal Pensionable Employees Central Provident Fund \n", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head = new Paragraph(new Chunk("Directorate of Panchayats Thiruvananthapuram\n", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, new Color(0, 0, 0))));
            head.Alignment = Element.ALIGN_CENTER;
            docTab1.Add(head);
            ary.Add(Convert.ToInt32(Session["intYrCal"]));
            string yr = gen.GetYearFromId(ary);
            Paragraph head1 = new Paragraph(new Chunk("KPEPF Credit Card for the year " + yr, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head2 = new Paragraph(new Chunk("[Revised]\n", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL, new Color(0, 0, 0))));
            head1.Alignment = Element.ALIGN_CENTER;
            head2.Alignment = Element.ALIGN_RIGHT;
            docTab1.Add(head1);
            docTab1.Add(head2);
            //docTab1.Add(new Phrase(new Chunk("\n")));
            //*****************************

            //First Table definision****************
            iTextSharp.text.Table tab1 = new iTextSharp.text.Table(8);
            tab1.BorderWidth = 1;
            ////tab1.BorderColor = new Color(0, 0, 0);
            //Fill Tables****************

            //Yearly data**********************
            if (ds1.Tables[0].Rows.Count != 0)
            {
                Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
                Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
                Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                docTab1.Add(Name);
                docTab1.Add(Namea);
                docTab1.Add(Acc);
            }

            //if (ds1.Tables[0].Rows.Count != 0)
            //{
            //    Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
            //    Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            //    Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

            //    docTab1.Add(Name);
            //    docTab1.Add(Namea);
            //    docTab1.Add(Acc);
            //}

            //}

            //Sub Head

            Cell cellSubHead1 = new Cell(new Chunk("Month", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead1.Rowspan = 2;
            cellSubHead1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellSubHead1.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead1.Border = 1;
            cellSubHead1.Border = Rectangle.UNDEFINED;
            //cellSubHead1.Border = Cell.RIGHT_BORDER;
            cellSubHead1.Width = 1;
            Cell cellSubHead2 = new Cell(new Chunk("Date of Remittance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead2.Width = 20;
            cellSubHead2.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead2.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead2.Border = 1;
            cellSubHead2.Border = Rectangle.UNDEFINED;
            //cellSubHead2.Border = Rectangle.RIGHT_BORDER;
            cellSubHead2.Rowspan = 2;

            Cell cellMani = new Cell(new Chunk("Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellMani.Colspan = 2;
            cellMani.HorizontalAlignment = Element.ALIGN_CENTER;
            cellMani.Border = 1;
            cellMani.Border = Rectangle.UNDEFINED;
            //cellMani.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead5 = new Cell(new Chunk("Refund of Advance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead5.Rowspan = 2;
            cellSubHead5.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead5.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead5.Border = 1;
            cellSubHead5.Border = Rectangle.UNDEFINED;
            //cellSubHead5.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead6 = new Cell(new Chunk("Arrear DA/Pay", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead6.Rowspan = 2;
            cellSubHead6.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead6.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead6.Border = 1;
            cellSubHead6.Border = Rectangle.UNDEFINED;
            //cellSubHead6.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead7 = new Cell(new Chunk("Total", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead7.Rowspan = 2;
            cellSubHead7.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead7.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead7.Border = 1;
            cellSubHead7.Border = Rectangle.UNDEFINED;
            //cellSubHead7.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead8 = new Cell(new Chunk("Withdrawals", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead8.Rowspan = 2;
            cellSubHead8.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead8.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead8.Border = 1;
            cellSubHead8.Border = Rectangle.UNDEFINED;
            //cellSubHead8.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead3 = new Cell(new Chunk("Subscription Amount", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead3.Border = 1;
            cellSubHead3.Border = Rectangle.UNDEFINED;
            //cellSubHead3.Border = Rectangle.RIGHT_BORDER;
            cellSubHead3.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead3.VerticalAlignment = Element.ALIGN_CENTER;
            Cell cellSubHead4 = new Cell(new Chunk("Arrear Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead4.Border = 1;
            cellSubHead4.Border = Rectangle.UNDEFINED;
            //cellSubHead4.Border = Rectangle.RIGHT_BORDER;
            cellSubHead4.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead4.VerticalAlignment = Element.ALIGN_CENTER;
            //tab1.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
            float[] headerwidths = { 12, 14, 14, 14, 12, 12, 12, 12 };
            tab1.Widths = headerwidths;
            tab1.WidthPercentage = 100;
            tab1.AddCell(cellSubHead1);
            tab1.AddCell(cellSubHead2);
            tab1.AddCell(cellMani);
            ////tab1.AddCell(nesthousing);
            tab1.AddCell(cellSubHead5);
            tab1.AddCell(cellSubHead6);
            tab1.AddCell(cellSubHead7);
            tab1.AddCell(cellSubHead8);
            tab1.AddCell(cellSubHead3);
            tab1.AddCell(cellSubHead4);

            tab1.Padding = 1;

            //Monthly data*************
            //ds1 = ledgerdao.GetRptMonthWs(intEmpId, cnt);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                tab1.DefaultHorizontalAlignment = Element.ALIGN_MIDDLE;
                int l = int.Parse(ds1.Tables[0].Rows.Count.ToString());
                for (int i = 0; i < l; i++)
                {
                    Cell cellRw1 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[0].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw1.Border = 1;
                    //cellRw1.Height = 100;
                    cellRw1.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[1].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw2.Border = 1;
                    cellRw2.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[2].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw3.Border = 1;
                    cellRw3.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw4 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[4].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw4.Border = 1;
                    cellRw4.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw5 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[3].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw5.Border = 1;
                    cellRw5.Border = Rectangle.RIGHT_BORDER;
                    float arrear = float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString());
                    Cell cellRw6 = new Cell(new Chunk(" " + arrear + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw6.Border = 1;
                    cellRw6.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw7 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[7].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw7.Border = 1;
                    cellRw7.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw8 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[12].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw8.Border = 1;
                    cellRw8.Border = Rectangle.RIGHT_BORDER;
                    cellRw3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw4.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw5.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw6.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw7.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw8.HorizontalAlignment = Element.ALIGN_RIGHT;

                    tab1.AddCell(cellRw1);
                    tab1.AddCell(cellRw2);
                    tab1.AddCell(cellRw3);
                    tab1.AddCell(cellRw4);
                    tab1.AddCell(cellRw5);
                    tab1.AddCell(cellRw6);
                    tab1.AddCell(cellRw7);
                    tab1.AddCell(cellRw8);


                    subscrip += float.Parse(ds1.Tables[0].Rows[i].ItemArray[2].ToString());
                    ToArrSub += float.Parse(ds1.Tables[0].Rows[i].ItemArray[4].ToString());
                    BF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[11].ToString());
                    Inter += float.Parse(ds1.Tables[0].Rows[i].ItemArray[10].ToString());
                    Tot += float.Parse(ds1.Tables[0].Rows[i].ItemArray[9].ToString());
                    OB += float.Parse(ds1.Tables[0].Rows[i].ItemArray[8].ToString());
                    refund += float.Parse(ds1.Tables[0].Rows[i].ItemArray[3].ToString());
                    //arrPF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString());
                    arrDA += (float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString()));
                    //arrPay += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                    total += float.Parse(ds1.Tables[0].Rows[i].ItemArray[7].ToString());
                    withdrawal += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                }
            }
            Cell cellTotNA = new Cell(" ");
            cellTotNA.Border = 0;
            ////////////
            //Cell cellTot1 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot1 = new Cell(new Chunk("Total ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            cellTot1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellTot1.Border = 1;
            cellTot1.Border = Rectangle.TOP_BORDER;
            Cell cellTot2 = new Cell(" ");
            cellTot2.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot2.Border = 1;
            cellTot2.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot1);
            tab1.AddCell(cellTot2);
            if (subscrip > 0)
            {
                Cell cellTot3 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
                cellTot3.Border = 1;
                cellTot3.Border = Rectangle.TOP_BORDER;
                tab1.AddCell(cellTot3);
                cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            else
            {
                Cell cellTot3 = new Cell(new Chunk(" "));
                cellTot3.Border = 3;
                cellTot3.Border = Rectangle.TOP_BORDER;
                tab1.AddCell(cellTot3);
                cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            /////////////////
            Cell cellTot4 = new Cell(new Chunk(" " + ToArrSub, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot4.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot4.Border = 1;
            cellTot4.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot4);
            Cell cellTot5 = new Cell(new Chunk(" " + refund, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot5.Border = 1;
            cellTot5.Border = Rectangle.TOP_BORDER;
            ////Cell cellTot6 = new Cell(new Chunk(" " + arrPF, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot6 = new Cell(new Chunk(" " + arrDA, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot6.Border = 1;
            cellTot6.Border = Rectangle.TOP_BORDER;
            ////Cell cellTot5 = new Cell(new Chunk(" " + arrPay, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot7 = new Cell(new Chunk(" " + total, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot7.Border = 1;
            cellTot7.Border = Rectangle.TOP_BORDER;
            Cell cellTot8 = new Cell(new Chunk(" " + withdrawal, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot8.Border = 1;
            cellTot8.Border = Rectangle.TOP_BORDER;
            //tab1.AddCell(cellTot3);
            cellTot5.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot6.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot7.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot8.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab1.AddCell(cellTot5);
            tab1.AddCell(cellTot6);
            tab1.AddCell(cellTot7);
            tab1.AddCell(cellTot8);
            docTab1.Add(tab1);
            //Second Table definision****************
            iTextSharp.text.Table tab2 = new iTextSharp.text.Table(2);
            tab2.BorderWidth = 1;
            float[] subtabwidths = { 30, 15 };
            tab2.Widths = subtabwidths;
            tab2.WidthPercentage = 45;
            tab2.Alignment = Element.ALIGN_RIGHT;
            tab2.BorderColor = new Color(0, 0, 0);

            //strYear = ds2.Tables[0].Rows[0].ItemArray[1].ToString();
            //First row************
            DataSet dst = new DataSet();
            //dst = gen.GetYearPDE();
            dst = gen.GetYearRem();
            Cell YrltDetCell1 = new Cell(new Chunk("  Balance From " + ds1.Tables[0].Rows[0].ItemArray[20].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell1.Border = 0;
            tab2.AddCell(YrltDetCell1);
            Cell YrltDetCell3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell3.Border = 0;
            tab2.AddCell(YrltDetCell3);

            //Second row************
            Cell YrltDetCell4 = new Cell(new Chunk("  Deposits and Refunds ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            //YrltDetCell4.Border = Rectangle.NO_BORDER;
            YrltDetCell4.Border = 0;
            tab2.AddCell(YrltDetCell4);
            Cell YrltDetCell6 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[9].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell6.Border = 0;
            tab2.AddCell(YrltDetCell6);

            //Third row************
            Cell YrltDetCell7 = new Cell(new Chunk("  Interest for " + ds1.Tables[0].Rows[0].ItemArray[19].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell7.Border = 0;
            tab2.AddCell(YrltDetCell7);
            Cell YrltDetCell9 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell9.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell9.Border = 0;
            tab2.AddCell(YrltDetCell9);

            //Fourth row************
            Cell YrltDetCell10 = new Cell(new Chunk("  Total Rupees ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell10.Border = 0;
            tab2.AddCell(YrltDetCell10);
            Cell YrltDetCell12 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[15].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell12.Border = 0;
            YrltDetCell12.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(YrltDetCell12);

            //Fifth row************
            Cell YrltDetCell13 = new Cell(new Chunk("  Deduct Withdrawals ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell13.Border = 0;
            tab2.AddCell(YrltDetCell13);
            Cell YrltDetCell15 = new Cell(new Chunk(" " + withdrawal + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell15.Border = 0;
            YrltDetCell15.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(YrltDetCell15);



            //Correction entry row************
            Cell CorrE1 = new Cell(new Chunk("  Corrected amount ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            CorrE1.Border = 0;
            tab2.AddCell(CorrE1);
            Cell CorrE2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[28].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            CorrE2.Border = 0;
            CorrE2.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(CorrE2);


            //Sixth row************
            Cell YrltDetCell16 = new Cell(new Chunk("  Balance on " + dst.Tables[0].Rows[tt - 1].ItemArray[3].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell16.Border = 0;
            tab2.AddCell(YrltDetCell16);
            Cell YrltDetCell18 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell18.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell18.Border = 0;
            tab2.AddCell(YrltDetCell18);
            tab2.Padding = 1;
            docTab1.Add(tab2);

            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt32(Session["intAccNo"]));
            ds = gen.getCurrentLB(arr);

            docTab1.Add(new Phrase(new Chunk("District : " + ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1].ItemArray[25].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            //docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[0].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            //docTab1.Add(new Phrase(new Chunk("\n Closing Balance in words: Rupees One Lakhs Thirteen Thousand Six Hundred Eighty-Seven Only", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n NB:-This is a computer generated document and hence requires no signature", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n Place: Thiruvananthapuram", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n Date: " + date, FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n The closing balance indicated is subject to variation on account of missing Credits/Debits if any noticed and accounted for later due to various means.", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            subscrip = 0;
            refund = 0;
            arrDA = 0;
            total = 0;
            withdrawal = 0;
            docTab1.NewPage();
            docTab1.Close();
            String frame = "<iframe  Width='100%' id ='iframePDE' scrolling='auto' runat='server'   frameborder='1' src='../PDF/" + strFileName + "' height='600'></iframe>";
            PDE.InnerHtml = frame;
            //Response.Redirect("../PDF/" + strFileName);
        }
        else
        {
            gblObj.MsgBoxOk("No data!", this);
        }
    }
    private Boolean CorrectionExists(Int32 empID)
    {
        Boolean flg = true;
        DataSet dsCg = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(empID);
        ar.Add(Convert.ToInt16(Session["intYr"]));
        dsCg = crrD.CheckCorrectionEntry4PC(ar);
        if (dsCg.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsCg.Tables[0].Rows[0].ItemArray[0]) > 0)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    private string strGenerateFileName()
    {
        string accno = Session["intAccNo"].ToString();
        string yrid = Session["intYrCal"].ToString();
        string flnm = accno + "_" + yrid + ".pdf";
        return flnm;
    }
    private void GeneratePDF(string FlPath, string strFileName)
    {
        Document docTab1 = new Document();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Session["intAccNo"]);
        arrIn.Add(Session["intYrCal"]);
        ds1 = gen.CCardLat(arrIn);
        //ds3 = gen.Interest(arrIn1);
        arrIn1.Add(Convert.ToInt32(Session["intYrCal"]));
        ds3 = gen.InterestMltpl(arrIn1);
        float subscrip = 0, refund = 0, BF = 0, arrDA = 0, Inter = 0, Tot = 0, OB = 0, total = 0, withdrawal = 0, ToArrSub = 0;
        //PdfWriter.GetInstance(docTab1, new FileStream(Request.PhysicalApplicationPath + "/b1.pdf", FileMode.Create));
        PdfWriter writer = PdfWriter.GetInstance(docTab1, new FileStream(FlPath, FileMode.Create));

        //********* Head Print date ************
        string date;
        date = DateTime.Today.Date.ToString().Substring(0, 10);
        Phrase headphraseprint = new Phrase("Printed on " + date, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
        HeaderFooter headprint = new HeaderFooter(headphraseprint, false);
        headprint.Border = Rectangle.NO_BORDER;
        headprint.Alignment = Element.ALIGN_RIGHT;
        docTab1.Header = headprint;

        //******* Foot Page number ************

        Phrase footPhraseImg = new Phrase("Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Corporation Golden Jubilee Building, opposite SMV school, Near Over bridge,Thampanoor-1 Phone:- 0471-2461043  Email :- aokpepf@lsgkerala.in  within 15 days along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)\n\t\t\t\t\tKPEPF details of all Subscribers being updated on the websit\t\t http://www.lsgkerala.gov.in/kpepf \n\nPage:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
        HeaderFooter footer = new HeaderFooter(footPhraseImg, true);
        footer.Border = iTextSharp.text.Rectangle.TOP_BORDER;
        footer.Alignment = Element.ALIGN_LEFT;
        docTab1.Footer = footer;
        docTab1.Open();


        ////for (int cnt = intStYr; cnt <= intEndYr; cnt++)
        ////{

        ////    strYear = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
        int numEmpId = int.Parse(Session["intAccNo"].ToString());
        //for (int cnt = 1; cnt <= 11; cnt++)
        //{
        Font[] fonts = new Font[1];
        fonts[0] = FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.BOLD);
        //ds2 = gen.GetEmpAccWise(1,numEmpId,"");
        //Header****    ******************
        //Paragraph head = new Paragraph(new Chunk("Kerala Municipal Pensionable Employees Central Provident Fund \n", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
        Paragraph head = new Paragraph(new Chunk("Directorate of Panchayats Thiruvananthapuram\n", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, new Color(0, 0, 0))));
        head.Alignment = Element.ALIGN_CENTER;
        docTab1.Add(head);

        ArrayList ary = new ArrayList();
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        string yr = gen.GetYearFromId(ary);
        Paragraph head1 = new Paragraph(new Chunk("KPEPF Credit Card for the year " + yr, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
        Paragraph head2 = new Paragraph(new Chunk("[Revised]\n", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL, new Color(0, 0, 0))));
        head1.Alignment = Element.ALIGN_CENTER;
        head2.Alignment = Element.ALIGN_RIGHT;
        docTab1.Add(head1);
        docTab1.Add(head2);
        docTab1.Add(new Phrase(new Chunk("\n")));
        //*****************************

        //First Table definision****************
        iTextSharp.text.Table tab1 = new iTextSharp.text.Table(8);
        tab1.BorderWidth = 1;
        if (ds1.Tables[0].Rows.Count != 0)
        {
            Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
            Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

            docTab1.Add(Name);
            docTab1.Add(Namea);
            docTab1.Add(Acc);
        }

        Cell cellSubHead1 = new Cell(new Chunk("Month", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead1.Rowspan = 2;
        cellSubHead1.HorizontalAlignment = Element.ALIGN_LEFT;
        cellSubHead1.VerticalAlignment = Element.ALIGN_CENTER;
        cellSubHead1.Border = 1;
        cellSubHead1.Border = Rectangle.UNDEFINED;
        //cellSubHead1.Border = Cell.RIGHT_BORDER;
        cellSubHead1.Width = 1;
        Cell cellSubHead2 = new Cell(new Chunk("Date of Remittance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead2.Width = 20;
        cellSubHead2.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead2.VerticalAlignment = Element.ALIGN_CENTER;
        cellSubHead2.Border = 1;
        cellSubHead2.Border = Rectangle.UNDEFINED;
        //cellSubHead2.Border = Rectangle.RIGHT_BORDER;
        cellSubHead2.Rowspan = 2;
        Cell cellMani = new Cell(new Chunk("Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellMani.Colspan = 2;
        cellMani.HorizontalAlignment = Element.ALIGN_CENTER;
        cellMani.Border = 1;
        cellMani.Border = Rectangle.UNDEFINED;
        //cellMani.Border = Rectangle.RIGHT_BORDER;
        Cell cellSubHead5 = new Cell(new Chunk("Refund of Advance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead5.Rowspan = 2;
        cellSubHead5.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead5.VerticalAlignment = Element.ALIGN_CENTER;
        cellSubHead5.Border = 1;
        cellSubHead5.Border = Rectangle.UNDEFINED;
        //cellSubHead5.Border = Rectangle.RIGHT_BORDER;
        Cell cellSubHead6 = new Cell(new Chunk("Arrear DA/Pay", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead6.Rowspan = 2;
        cellSubHead6.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead6.VerticalAlignment = Element.ALIGN_CENTER;
        cellSubHead6.Border = 1;
        cellSubHead6.Border = Rectangle.UNDEFINED;
        //cellSubHead6.Border = Rectangle.RIGHT_BORDER;
        Cell cellSubHead7 = new Cell(new Chunk("Total", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead7.Rowspan = 2;
        cellSubHead7.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead7.VerticalAlignment = Element.ALIGN_CENTER;
        cellSubHead7.Border = 1;
        cellSubHead7.Border = Rectangle.UNDEFINED;
        //cellSubHead7.Border = Rectangle.RIGHT_BORDER;
        Cell cellSubHead8 = new Cell(new Chunk("Withdrawals", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead8.Rowspan = 2;
        cellSubHead8.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead8.VerticalAlignment = Element.ALIGN_CENTER;
        cellSubHead8.Border = 1;
        cellSubHead8.Border = Rectangle.UNDEFINED;
        //cellSubHead8.Border = Rectangle.RIGHT_BORDER;
        Cell cellSubHead3 = new Cell(new Chunk("Subscription Amount", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead3.Border = 1;
        cellSubHead3.Border = Rectangle.UNDEFINED;
        //cellSubHead3.Border = Rectangle.RIGHT_BORDER;
        cellSubHead3.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead3.VerticalAlignment = Element.ALIGN_CENTER;
        Cell cellSubHead4 = new Cell(new Chunk("Arrear Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        cellSubHead4.Border = 1;
        cellSubHead4.Border = Rectangle.UNDEFINED;
        //cellSubHead4.Border = Rectangle.RIGHT_BORDER;
        cellSubHead4.HorizontalAlignment = Element.ALIGN_CENTER;
        cellSubHead4.VerticalAlignment = Element.ALIGN_CENTER;
        //tab1.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
        float[] headerwidths = { 12, 14, 14, 14, 12, 12, 12, 12 };
        tab1.Widths = headerwidths;
        tab1.WidthPercentage = 100;
        tab1.AddCell(cellSubHead1);
        tab1.AddCell(cellSubHead2);
        tab1.AddCell(cellMani);
        ////tab1.AddCell(nesthousing);
        tab1.AddCell(cellSubHead5);
        tab1.AddCell(cellSubHead6);
        tab1.AddCell(cellSubHead7);
        tab1.AddCell(cellSubHead8);
        tab1.AddCell(cellSubHead3);
        tab1.AddCell(cellSubHead4);

        tab1.Padding = 1;

        //Monthly data*************
        //ds1 = ledgerdao.GetRptMonthWs(intEmpId, cnt);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            tab1.DefaultHorizontalAlignment = Element.ALIGN_MIDDLE;
            int l = int.Parse(ds1.Tables[0].Rows.Count.ToString());
            for (int i = 0; i < l; i++)
            {
                Cell cellRw1 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[0].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw1.Border = 1;
                //cellRw1.Height = 100;
                cellRw1.Border = Rectangle.RIGHT_BORDER;
                Cell cellRw2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[1].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw2.Border = 1;
                cellRw2.Border = Rectangle.RIGHT_BORDER;
                Cell cellRw3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[2].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw3.Border = 1;
                cellRw3.Border = Rectangle.RIGHT_BORDER;
                Cell cellRw4 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[4].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw4.Border = 1;
                cellRw4.Border = Rectangle.RIGHT_BORDER;
                Cell cellRw5 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[3].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw5.Border = 1;
                cellRw5.Border = Rectangle.RIGHT_BORDER;
                float arrear = float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString());
                Cell cellRw6 = new Cell(new Chunk(" " + arrear + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw6.Border = 1;
                cellRw6.Border = Rectangle.RIGHT_BORDER;
                Cell cellRw7 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[7].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw7.Border = 1;
                cellRw7.Border = Rectangle.RIGHT_BORDER;
                Cell cellRw8 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[12].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                cellRw8.Border = 1;
                cellRw8.Border = Rectangle.RIGHT_BORDER;
                cellRw3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellRw4.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellRw5.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellRw6.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellRw7.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellRw8.HorizontalAlignment = Element.ALIGN_RIGHT;

                tab1.AddCell(cellRw1);
                tab1.AddCell(cellRw2);
                tab1.AddCell(cellRw3);
                tab1.AddCell(cellRw4);
                tab1.AddCell(cellRw5);
                tab1.AddCell(cellRw6);
                tab1.AddCell(cellRw7);
                tab1.AddCell(cellRw8);


                subscrip += float.Parse(ds1.Tables[0].Rows[i].ItemArray[2].ToString());
                ToArrSub += float.Parse(ds1.Tables[0].Rows[i].ItemArray[4].ToString());
                BF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[11].ToString());
                Inter += float.Parse(ds1.Tables[0].Rows[i].ItemArray[10].ToString());
                Tot += float.Parse(ds1.Tables[0].Rows[i].ItemArray[9].ToString());
                OB += float.Parse(ds1.Tables[0].Rows[i].ItemArray[8].ToString());
                refund += float.Parse(ds1.Tables[0].Rows[i].ItemArray[3].ToString());
                //arrPF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString());
                arrDA += (float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString()));
                //arrPay += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                total += float.Parse(ds1.Tables[0].Rows[i].ItemArray[7].ToString());
                withdrawal += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
            }
        }
        Cell cellTotNA = new Cell(" ");
        cellTotNA.Border = 0;
        //Cell cellTot1 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
        Cell cellTot1 = new Cell(new Chunk("Total ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
        cellTot1.HorizontalAlignment = Element.ALIGN_LEFT;
        cellTot1.Border = 1;
        cellTot1.Border = Rectangle.TOP_BORDER;
        Cell cellTot2 = new Cell(" ");
        cellTot2.HorizontalAlignment = Element.ALIGN_RIGHT;
        cellTot2.Border = 1;
        cellTot2.Border = Rectangle.TOP_BORDER;
        tab1.AddCell(cellTot1);
        tab1.AddCell(cellTot2);
        if (subscrip > 0)
        {
            Cell cellTot3 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot3.Border = 1;
            cellTot3.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot3);
            cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
        }
        else
        {
            Cell cellTot3 = new Cell(new Chunk(" "));
            cellTot3.Border = 3;
            cellTot3.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot3);
            cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
        }
        /////////////////
        Cell cellTot4 = new Cell(new Chunk(" " + ToArrSub, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
        cellTot4.HorizontalAlignment = Element.ALIGN_RIGHT;
        cellTot4.Border = 1;
        cellTot4.Border = Rectangle.TOP_BORDER;
        tab1.AddCell(cellTot4);
        Cell cellTot5 = new Cell(new Chunk(" " + refund, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
        cellTot5.Border = 1;
        cellTot5.Border = Rectangle.TOP_BORDER;
        ////Cell cellTot6 = new Cell(new Chunk(" " + arrPF, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
        Cell cellTot6 = new Cell(new Chunk(" " + arrDA, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
        cellTot6.Border = 1;
        cellTot6.Border = Rectangle.TOP_BORDER;
        ////Cell cellTot5 = new Cell(new Chunk(" " + arrPay, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
        Cell cellTot7 = new Cell(new Chunk(" " + total, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
        cellTot7.Border = 1;
        cellTot7.Border = Rectangle.TOP_BORDER;
        Cell cellTot8 = new Cell(new Chunk(" " + withdrawal, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
        cellTot8.Border = 1;
        cellTot8.Border = Rectangle.TOP_BORDER;
        //tab1.AddCell(cellTot3);
        cellTot5.HorizontalAlignment = Element.ALIGN_RIGHT;
        cellTot6.HorizontalAlignment = Element.ALIGN_RIGHT;
        cellTot7.HorizontalAlignment = Element.ALIGN_RIGHT;
        cellTot8.HorizontalAlignment = Element.ALIGN_RIGHT;
        tab1.AddCell(cellTot5);
        tab1.AddCell(cellTot6);
        tab1.AddCell(cellTot7);
        tab1.AddCell(cellTot8);
        docTab1.Add(tab1);
        //Second Table definision****************
        iTextSharp.text.Table tab2 = new iTextSharp.text.Table(2);
        tab2.BorderWidth = 1;
        float[] subtabwidths = { 30, 15 };
        tab2.Widths = subtabwidths;
        tab2.WidthPercentage = 45;
        tab2.Alignment = Element.ALIGN_RIGHT;
        tab2.BorderColor = new Color(0, 0, 0);

        //strYear = ds2.Tables[0].Rows[0].ItemArray[1].ToString();
        //First row************
        DataSet dst = new DataSet();
        dst = agD.GetYear();
        Cell YrltDetCell1 = new Cell(new Chunk("  Balance From " + dst.Tables[0].Rows[1].ItemArray[2].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell1.Border = 0;
        tab2.AddCell(YrltDetCell1);
        Cell YrltDetCell3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
        YrltDetCell3.Border = 0;
        tab2.AddCell(YrltDetCell3);

        //Second row************
        Cell YrltDetCell4 = new Cell(new Chunk("  Deposits and Refunds ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        //YrltDetCell4.Border = Rectangle.NO_BORDER;
        YrltDetCell4.Border = 0;
        tab2.AddCell(YrltDetCell4);
        Cell YrltDetCell6 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[9].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
        YrltDetCell6.Border = 0;
        tab2.AddCell(YrltDetCell6);

        //Third row************
        Cell YrltDetCell7 = new Cell(new Chunk("  Interest for " + ds1.Tables[0].Rows[0].ItemArray[19].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell7.Border = 0;
        tab2.AddCell(YrltDetCell7);
        Cell YrltDetCell9 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell9.HorizontalAlignment = Element.ALIGN_RIGHT;
        YrltDetCell9.Border = 0;
        tab2.AddCell(YrltDetCell9);

        //Fourth row************
        Cell YrltDetCell10 = new Cell(new Chunk("  Total Rupees ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell10.Border = 0;
        tab2.AddCell(YrltDetCell10);
        Cell YrltDetCell12 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[15].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell12.Border = 0;
        YrltDetCell12.HorizontalAlignment = Element.ALIGN_RIGHT;
        tab2.AddCell(YrltDetCell12);

        //Fifth row************
        Cell YrltDetCell13 = new Cell(new Chunk("  Deduct Withdrawals ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell13.Border = 0;
        tab2.AddCell(YrltDetCell13);
        Cell YrltDetCell15 = new Cell(new Chunk(" " + withdrawal + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell15.Border = 0;
        YrltDetCell15.HorizontalAlignment = Element.ALIGN_RIGHT;
        tab2.AddCell(YrltDetCell15);

        //Sixth row************
        Cell YrltDetCell16 = new Cell(new Chunk("  Balance on " + dst.Tables[0].Rows[1].ItemArray[3].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell16.Border = 0;
        tab2.AddCell(YrltDetCell16);
        Cell YrltDetCell18 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
        YrltDetCell18.HorizontalAlignment = Element.ALIGN_RIGHT;
        YrltDetCell18.Border = 0;
        tab2.AddCell(YrltDetCell18);
        tab2.Padding = 0;
        docTab1.Add(tab2);
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(int.Parse(Session["intAccNo"].ToString()));
        ds = gen.getCurrentLB(arr);

        docTab1.Add(new Phrase(new Chunk("District : " + ds1.Tables[0].Rows[0].ItemArray[25].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
        //docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[0].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

        docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[Convert.ToInt16(ds1.Tables[0].Rows.Count - 1)].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

        //docTab1.Add(new Phrase(new Chunk("\n Closing Balance in words: Rupees One Lakhs Thirteen Thousand Six Hundred Eighty-Seven Only", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
        docTab1.Add(new Phrase(new Chunk("\n NB:-This is a computer generated document and hence requires no signature", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
        docTab1.Add(new Phrase(new Chunk("\n Place: Thiruvananthapuram", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
        docTab1.Add(new Phrase(new Chunk("\n Date: " + date, FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

        subscrip = 0;
        refund = 0;
        arrDA = 0;
        total = 0;
        withdrawal = 0;
        docTab1.NewPage();
        docTab1.Close();
        String frame = "<iframe  Width='100%' id ='iframePDE' scrolling='auto' runat='server'   frameborder='1' src='../PDF/" + strFileName + "' height='600'></iframe>";
        PDE.InnerHtml = frame;
        //Response.Redirect("../PDF/" + strFileName);

    }

    protected void btnBulkNew_Click(object sender, EventArgs e)
    {
        if (CheckAllApp() == true)
        {
            CalcCurrentYearToLedgerMthlyAndLedgerYearly();
            gblObj.MsgBoxOk("Updated!", this);
        }
        else
        {
            gblObj.MsgBoxOk("approve all districts", this);
        }

    }
    //private void CalcCurrentYearToLedgerMthlyAndLedgerYearly()
    //{
    //    DataSet dsEmp = new DataSet();
    //    //Session["intYrCal"] = gen.GetCCYearId();
    //    Session["intYrCal"] = 50;
    //    dsEmp = empDao.GetEmp4BulcCalc();
    //    if (dsEmp.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
    //        //for (int i = 0; i < 1; i++)
    //        {

    //            ldgrY.IntAccNo = Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]);
    //            //ldgrY.IntAccNo = 5794;
    //            ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
    //            ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
    //            CalcMonthlyAmtsBulk(ldgrY.IntAccNo);

    //            if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
    //            {
    //                SaveMonthlyAmts();
    //                FillConsBoxBulk();  //Calc interest
    //                SaveYearlyAmts(0);
    //            }
    //            else
    //            {
    //                SaveYearlyAmts(1);
    //            }

    //        }
    //        UpdCorrEntryData();
    //    }

    //}
    private void UpdCorrEntryData()
    {
        ArrayList ar = new ArrayList();
        DataSet dsCr = new DataSet();
        CorrectionEntryDao crrD = new CorrectionEntryDao();
        ar.Add(Convert.ToInt16(Session["intYrCal"]));
        dsCr = crrD.GetCorrectionEntryCnt(ar);

        if (dsCr.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCr.Tables[0].Rows.Count; i++)
            {
                ArrayList arl = new ArrayList();
                arl.Add(Convert.ToInt32(dsCr.Tables[0].Rows[i].ItemArray[0]));
                ldgrD.UpdateYearDet4GenerateCardNew(arl);
            }
        }
    }

    private double FindOBBulk(int accno, int yr)
    {
        double amt = 0;
        ArrayList arob = new ArrayList();
        DataSet dsob = new DataSet();
        arob.Add(accno);
        arob.Add(yr);

        dsob = ldgrD.GetOB(arob);
        if (dsob.Tables[0].Rows.Count > 0)
        {
            if (dsob.Tables[0].Rows[0].ItemArray[0] != null)
            {
                amt = Convert.ToDouble(dsob.Tables[0].Rows[0].ItemArray[0]);
            }
            else
            {
                amt = 0;
            }
        }
        return amt;
    }

    private void CalcMonthlyAmtsBulk(int accno)
    {
        int maxForloopVal = 0;
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCardBulk(ary);
        findCalcMonth();
        maxForloopVal = Convert.ToInt16(dsy.Tables[0].Rows.Count);
        if (dsy.Tables[0].Rows.Count > 0)
        { 
            
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < maxForloopVal; i++)  
            {
                if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                {
                    ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
                }
                else
                {
                    ldgr.IntMId[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
                {
                    ldgr.Dbl4Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[1]);
                }
                else
                {
                    ldgr.Dbl4Amt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
                {
                    ldgr.Dbl5Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
                }
                else
                {
                    ldgr.Dbl5Amt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {
                    ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
                }
                else
                {
                    ldgr.DblWithAmt[i] = 0;
                }
                if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
                {
                    ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
                }
                else
                {
                    ldgr.DblTotRemMwise[i] = 0;
                }
                ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
                ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
                ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
                ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];
                ldgrY.DblTotWithAmtForInt = ldgrY.DblTotWithAmtForInt + CalculateBalMonthsBulk(ldgr.IntMId[i]) * ldgr.DblWithAmt[i];
                ldgrY.FlgNonTrans = 0;
                ldgrY.DblCorrEntryAmt = 0;
            }
        }
        //gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    }

    protected void btnSaveDor_Click(object sender, EventArgs e)
    {
        if (txtDtR.Text != "" && txtDtR.Text != "0")
        {
            SaveToEmpMst(1);
        }

        if (txtDtR.Text != "" && txtDtR.Text != null)
        {
            txtDtClose.Enabled = true;
        }
        else
        {
            txtDtClose.Enabled = false;
        }
        gblObj.MsgBoxOk("added", this);
    }
    private void SaveToEmpMst(int flgtp)
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intAccNo"]));
        if (flgtp == 1)
        {
            ar.Add(txtDtR.Text.ToString());
        }
        else
        {
            ar.Add(txtDtClose.Text.ToString());
        }
        //ar.Add(txtDtClose.Text.ToString());
        empDao.UpdateEmpDoR(ar, flgtp);
        lblDistP.Text = txtDtR.Text.ToString();
    }


    protected void txtDtR_TextChanged(object sender, EventArgs e)
    {
        if (txtDtR.Text != "" && txtDtR.Text != null)
        {
            if (gblObj.isValidDate(txtDtR, this) == true)
            {

            }
        }
    }
    protected void btnLedgerP_Click(object sender, EventArgs e)
    {
        if (txtAccNoP.Text.ToString() != "")
        {
            Session["numEmpIdLedger"] = Convert.ToInt32(Session["intAccNo"]);
            Session["intYearIdLedger"] = Convert.ToInt16(Session["intYrCal"]);
            int y = Convert.ToInt16(Session["intYrCal"]);
            int y1 = Convert.ToInt16(Session["intYr"]);
            Response.Redirect("Reportviewer.aspx?ReportID=8");

        }
        else
        {
            gblObj.MsgBoxOk("Enter Acc. No.!", this);
        }
    }
    protected void btnCorrP_Click(object sender, EventArgs e)
    {
        gblObj.SetBlankRow(gdvCorr);
        Session["numEmpIdLedger"] = txtAccNoP.Text.ToString();
        lsubFillgrid();
        Save_C_CorrectionEntry();
        Response.Redirect("Reportviewer.aspx?ReportID=9");
    }
    public void lsubFillgrid()
    {
        DataSet dsfill = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(txtAccNoP.Text));

        dsfill = crrD.FillCorrectionEntry(arr);
        if (dsfill.Tables[0].Rows.Count > 0)
        {

            gdvCorr.DataSource = dsfill;
            gdvCorr.DataBind();
            for (int i = 0; i < dsfill.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCorr.Rows[i];
                TextBox txtYrAss = (TextBox)gdv.FindControl("txtYr");
                txtYrAss.Text = dsfill.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtchlDtAss = (TextBox)gdv.FindControl("txtchlDt");
                txtchlDtAss.Text = dsfill.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAmAss = (TextBox)gdv.FindControl("txtAm");
                txtAmAss.Text = dsfill.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtRtAss = (TextBox)gdv.FindControl("txtRt");
                txtRtAss.Text = dsfill.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtmnthIdAss = (TextBox)gdv.FindControl("txtmnthId");
                txtmnthIdAss.Text = dsfill.Tables[0].Rows[i].ItemArray[5].ToString();

                TextBox txtbalmnthAss = (TextBox)gdv.FindControl("txtbalmnth");
                //txtbalmnthAss.Text = dsfill.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtyrIdAss = (TextBox)gdv.FindControl("txtyrId");
                txtyrIdAss.Text = dsfill.Tables[0].Rows[i].ItemArray[7].ToString();

                TextBox txttypeAss = (TextBox)gdv.FindControl("txttype");
                txttypeAss.Text = dsfill.Tables[0].Rows[i].ItemArray[8].ToString();
                if (Convert.ToInt32(txtAmAss.Text) != 0)
                {
                    if (Convert.ToInt32(txttypeAss.Text) == 1)
                    {
                        balmnth = CalculateBalMonthsWithDay(Convert.ToInt32(txtmnthIdAss.Text), Convert.ToDateTime(txtchlDtAss.Text).Day);
                        txtbalmnthAss.Text = balmnth.ToString();
                    }
                    else if (Convert.ToInt32(txttypeAss.Text) == 2)
                    {
                        balmnth = CalculateBalMonths(Convert.ToInt32(txtmnthIdAss.Text));
                        txtbalmnthAss.Text = balmnth.ToString();
                    }
                    else
                        txtbalmnthAss.Text = "12";
                }
            }
            lSubFillInterestAmt();
            FillCalcCol();
        }
    }
    public void FillCalcCol()
    {
        for (int i = 0; i < gdvCorr.Rows.Count; i++)
        {
            GridViewRow gdv = gdvCorr.Rows[i];
            TextBox txtAmAss = (TextBox)gdv.FindControl("txtAm");
            TextBox txtintamtAss = (TextBox)gdv.FindControl("txtintamt");
            TextBox txttotlAss = (TextBox)gdv.FindControl("txttotl");
            TextBox txtRtAss = (TextBox)gdv.FindControl("txtRt");
            TextBox txtbalmnthAss = (TextBox)gdv.FindControl("txtbalmnth");
            TextBox txtcalAss = (TextBox)gdv.FindControl("txtcal");
            TextBox txtyrIdAss = (TextBox)gdv.FindControl("txtyrId");
            if (i == 0)
            {
                if (Convert.ToInt32(txtAmAss.Text) != 0)
                {
                    txtcalAss.Text = (txtAmAss.Text + " *" + txtRtAss.Text + "*" + txtbalmnthAss.Text + "/1200");
                }
            }
            else
            {
                GridViewRow gdvm1 = gdvCorr.Rows[i - 1];
                TextBox txtyrIdAss1 = (TextBox)gdvm1.FindControl("txtyrId");
                TextBox txttotlAss1 = (TextBox)gdvm1.FindControl("txttotl");
                //TextBox txtintamtAss1 = (TextBox)gdvm1.FindControl("txtintamt");
                if (Convert.ToInt32(txtAmAss.Text) != 0)
                {
                    txtcalAss.Text = (txtAmAss.Text + " *" + txtRtAss.Text + "*" + txtbalmnthAss.Text + "/1200");
                }
                else if (Convert.ToInt32(txtyrIdAss.Text) != 47)
                {
                    if (Convert.ToInt32(txtyrIdAss.Text) != 0)
                    {
                        txtcalAss.Text = txttotlAss1.Text + "*" + txtRtAss.Text + "/100";
                    }
                }
                else
                {
                    if (Convert.ToDouble(txtRtAss.Text) == 8)
                    {
                        txtcalAss.Text = txttotlAss1.Text + "*" + "8" + "*" + "8" + "/1200";

                    }
                    else
                    {
                        GridViewRow gdvm2 = gdvCorr.Rows[i - 2];
                        TextBox txttotlAss2 = (TextBox)gdvm2.FindControl("txttotl");
                        txtcalAss.Text = txttotlAss2.Text + "*" + "8.6" + "*" + "4" + "/1200";
                    }

                }
            }
        }
    }
    public void lSubFillInterestAmt()
    {
        for (int i = 0; i < gdvCorr.Rows.Count; i++)
        {
            GridViewRow gdv3 = gdvCorr.Rows[i];
            //GridViewRow gdvm1 = gdvCorr.Rows[i - 1];
            //GridViewRow gdvm2 = gdvCorr.Rows[i - 2];
            TextBox txtAmAss = (TextBox)gdv3.FindControl("txtAm");
            TextBox txtintamtAss = (TextBox)gdv3.FindControl("txtintamt");
            TextBox txttotlAss = (TextBox)gdv3.FindControl("txttotl");

            TextBox txtRtAss = (TextBox)gdv3.FindControl("txtRt");
            TextBox txtbalmnthAss = (TextBox)gdv3.FindControl("txtbalmnth");
            TextBox txtyrIdAss = (TextBox)gdv3.FindControl("txtyrId");

            if (i == 0)
            {
                if (Convert.ToInt32(txtAmAss.Text) != 0)
                {
                    txtintamtAss.Text = Convert.ToString(Convert.ToInt32(txtAmAss.Text) * Convert.ToDouble(txtRtAss.Text) * Convert.ToInt32(txtbalmnthAss.Text) / 1200);
                    txttotlAss.Text = Convert.ToString(Convert.ToInt32(txtAmAss.Text) + Math.Round(Convert.ToDouble(txtintamtAss.Text)));
                }

            }
            else if (Convert.ToInt32(txtyrIdAss.Text) != 47)
            {
                GridViewRow gdvm1 = gdvCorr.Rows[i - 1];
                TextBox txtyrIdAss1 = (TextBox)gdvm1.FindControl("txtyrId");
                TextBox txttotlAss1 = (TextBox)gdvm1.FindControl("txttotl");
                TextBox txtintamtAss1 = (TextBox)gdvm1.FindControl("txtintamt");

                if (Convert.ToInt32(txtyrIdAss.Text) == Convert.ToInt32(txtyrIdAss1.Text))
                {
                    txtintamtAss.Text = Convert.ToString(Convert.ToInt32(txtAmAss.Text) * Convert.ToDouble(txtRtAss.Text) * Convert.ToInt32(txtbalmnthAss.Text) / 1200);
                    txttotlAss.Text = Convert.ToString(Convert.ToInt32(txtAmAss.Text) + Math.Round(Convert.ToDouble(txtintamtAss.Text)) + Convert.ToInt32(txttotlAss1.Text));
                }
                else
                {
                    if (Convert.ToInt32(txtAmAss.Text) == 0)
                    {
                        txtintamtAss.Text = Convert.ToString(Convert.ToInt32(txttotlAss1.Text) * Convert.ToDouble(txtRtAss.Text) / 100);
                        txttotlAss.Text = Convert.ToString(Convert.ToInt32(txttotlAss1.Text) + Math.Round(Convert.ToDouble(txtintamtAss.Text)));
                    }
                    else
                    {
                        txtintamtAss.Text = Convert.ToString(Convert.ToInt32(txtAmAss.Text) * Convert.ToDouble(txtRtAss.Text) * Convert.ToInt32(txtbalmnthAss.Text) / 1200);
                        txttotlAss.Text = Convert.ToString(Convert.ToInt32(txtAmAss.Text) + Math.Round(Convert.ToDouble(txtintamtAss.Text)) + Convert.ToInt32(txttotlAss1.Text));

                    }
                }
            }
            else
            {
                GridViewRow gdvm1 = gdvCorr.Rows[i - 1];
                GridViewRow gdvm2 = gdvCorr.Rows[i - 2];
                TextBox txttotlAss1 = (TextBox)gdvm1.FindControl("txttotl");
                TextBox txttotlAss2 = (TextBox)gdvm2.FindControl("txttotl");
                TextBox txtintamtAss1 = (TextBox)gdvm1.FindControl("txtintamt");

                TextBox txtRtAss21 = (TextBox)gdv3.FindControl("txtRt");

                if (Convert.ToInt32(txtAmAss.Text) == 0)
                {

                    txtbalmnthAss.Text = FindBalMonthFor21(i, gdvCorr).ToString();
                    txtintamtAss.Text = Convert.ToString(FindAmtToCalc(i, gdvCorr) * Convert.ToDouble(txtRtAss21.Text) * Convert.ToInt32(txtbalmnthAss.Text) / 1200);
                }
                txttotlAss.Text = Convert.ToString(Convert.ToInt32(txttotlAss2.Text) + Math.Round(Convert.ToDouble(txtintamtAss1.Text)) + Math.Round(Convert.ToDouble(txtintamtAss.Text)));
            }
        }

    }
    public double FindAmtToCalc(int j, GridView gdv)
    {
        double calc = 0;
        GridViewRow gdv4 = gdvCorr.Rows[j];
        GridViewRow gdvm1 = gdvCorr.Rows[j - 1];
        GridViewRow gdvm2 = gdvCorr.Rows[j - 2];
        TextBox txtRtAss = (TextBox)gdv4.FindControl("txtRt");
        TextBox txttotlAss1 = (TextBox)gdvm1.FindControl("txttotl");
        TextBox txttotlAss2 = (TextBox)gdvm2.FindControl("txttotl");
        if (Convert.ToDouble(txtRtAss.Text) == 8)
        {
            calc = Convert.ToDouble(txttotlAss1.Text);
        }
        else
        {
            calc = Convert.ToDouble(txttotlAss2.Text);
        }

        return calc;
    }

    public int FindBalMonthFor21(int i, GridView gdv)
    {
        int blmnth21 = 0;

        GridViewRow gdv1 = gdvCorr.Rows[i];
        TextBox txtRtAss = (TextBox)gdv1.FindControl("txtRt");
        if (Convert.ToDouble(txtRtAss.Text) == 8)
        {
            blmnth21 = 8;
        }
        else
        {
            blmnth21 = 4;
        }
        return blmnth21;
    }
    public int CalculateBalMonthsWithDay(int Mthid, int intDay)
    {
        int Mno = 0;
        if (intDay <= 4)
        {
            if (Mthid == 1)
            {
                Mno = 3;
            }
            else if (Mthid == 2)
            {
                Mno = 2;
            }
            else if (Mthid == 3)
            {
                Mno = 1;
            }
            else if (Mthid == 4)
            {
                Mno = 12;
            }
            else if (Mthid == 5)
            {
                Mno = 11;
            }
            else if (Mthid == 6)
            {
                Mno = 10;
            }
            else if (Mthid == 7)
            {
                Mno = 9;
            }
            else if (Mthid == 8)
            {
                Mno = 8;
            }
            else if (Mthid == 9)
            {
                Mno = 7;
            }
            else if (Mthid == 10)
            {
                Mno = 6;
            }
            else if (Mthid == 11)
            {
                Mno = 5;
            }
            else if (Mthid == 12)
            {
                Mno = 4;
            }

        }
        else
        {
            if (Mthid == 1)
                Mno = 2;
            else if (Mthid == 2)
                Mno = 1;
            else if (Mthid == 3)
                Mno = 0;
            else if (Mthid == 4)
                Mno = 11;
            else if (Mthid == 5)
                Mno = 10;
            else if (Mthid == 6)
                Mno = 9;
            else if (Mthid == 7)
                Mno = 8;
            else if (Mthid == 8)
                Mno = 7;
            else if (Mthid == 9)
                Mno = 6;
            else if (Mthid == 10)
                Mno = 5;
            else if (Mthid == 11)
                Mno = 4;
            else if (Mthid == 12)
                Mno = 3;

        }
        return Mno;

    }
    private void Save_C_CorrectionEntry()
    {
        ArrayList ard = new ArrayList();
        //Session["numEmpIdLedger"])
        ard.Add(Convert.ToInt32(Session["numEmpIdLedger"]));
        crrD.DelCorrEntryChild(ard);
        for (int j = 0; j < gdvCorr.Rows.Count; j++)
        {
            ArrayList arr = new ArrayList();

            GridViewRow gvr = gdvCorr.Rows[j];
            TextBox txtYr = (TextBox)gvr.FindControl("txtYr");        //chv year
            TextBox txtchlDt = (TextBox)gvr.FindControl("txtchlDt");        //chalan dt
            TextBox txtAm = (TextBox)gvr.FindControl("txtAm");        //org amt
            TextBox txtRt = (TextBox)gvr.FindControl("txtRt");        //rt of interest

            TextBox lblCalcAss = (TextBox)gvr.FindControl("txtcal");
            TextBox lblTotalAss = (TextBox)gvr.FindControl("txttotl");
            TextBox lblHdnIntAmtAss = (TextBox)gvr.FindControl("txtintamt");

            arr.Add(Convert.ToInt32(Session["numEmpIdLedger"]));     //acc no
            arr.Add(txtYr.Text.ToString());     //chv year
            if (txtchlDt.Text != "&nbsp;" && txtchlDt.Text != "")
            {
                arr.Add(txtchlDt.Text.ToString());     //chalan dt
            }
            else
            {
                arr.Add(DBNull.Value);     //chalan dt
            }
            arr.Add(Convert.ToDouble(txtAm.Text));     //org amt
            arr.Add(Convert.ToDouble(txtRt.Text));     //rt of interest
            arr.Add(Convert.ToDouble(lblHdnIntAmtAss.Text));     //interest amt
            arr.Add(Convert.ToDouble(lblTotalAss.Text));     //total
            arr.Add(lblCalcAss.Text.ToString());     //chv calc
            arr.Add(j + 1);
            crrD.SaveCorrEntryChild(arr);

        }
    }
}