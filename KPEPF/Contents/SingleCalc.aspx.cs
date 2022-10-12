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

public partial class Contents_SingleCalc : System.Web.UI.Page
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

    //LedgerM ldgr = new LedgerM();
    //LedgerY ldgrY = new LedgerY();

    LedgerM ldgr;
    LedgerY ldgrY;

    LedgerYDao ldgrD = new LedgerYDao();
    LedgerMDao ldgrDao = new LedgerMDao();
    static int yrDor = 0;
    static int mDor = 0;

    static string accno = "";
    static string ename = "";
    static int flgEmp = 0;
    static int flgTrn = 0;
    static int tt = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlSanction.Visible = false;
            pnlCorrCalc.Visible = true;
            //FillYear();
            FillYr();
            SetGridDefault();
            SetGridDefaultn();
        }
    }
    protected void btnBulkNew_Click(object sender, EventArgs e)
    {
        Session["intYrCal"] = gen.GetCCYearId();
        if (txtAccNoP.Text == "" || txtAccNoP.Text == null || Convert.ToInt16(Session["intYearSC"]) == 0)
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            if (Convert.ToInt16(txtAccNoP.Text) > 0)
            {
                ////// Correction Entry ////////////////////////////


                ////// Correction Entry ////////////////////////////

                ////// LedgerMthlyAndLedgerYearly ////////////////////////////
                for (int i = Convert.ToInt16(Session["intYearSC"]); i <= Convert.ToInt16(Session["intYrCal"]); i++)
                {
                    DeleteFromLedgerSingleYr(Convert.ToInt32(txtAccNoP.Text), i);
                    CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(Convert.ToInt32(txtAccNoP.Text), i);

                    ///////////// Ledger Yearly Updation ///////////////////////
                    if (i == Convert.ToInt16(Session["intYrCal"]))
                    {
                        ArrayList arl = new ArrayList();
                        arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
                        ldgrD.UpdateYearDet4GenerateCardNew(arl);
                    }
                    ///////////// Ledger Yearly Updation ///////////////////////
                }
                
                gblObj.MsgBoxOk("Updated!", this);
            }
            else
            {
                gblObj.MsgBoxOk("Enter Employee!", this);
            }
        }
    }
    private void clearCorrTable(Int32 accNo)
    {
        ArrayList ar = new ArrayList();
        ar.Add(accNo);
        crrD.DelCorrEntrySingle(ar);
    }
    private void CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(Int32 accNo,int yr)
    {
        double dblTotRem = 0;
        double dblTotWith = 0;
        int chgCnt = 0;
        DataSet dsEmp = new DataSet();
        //Session["intYrCal"] = gen.GetCCYearId();

        ldgrY = new LedgerY();
        ldgr = new LedgerM();

        Session["wAmt14Int1"] = 0;
        Session["wAmt1"] = 0;
        Session["wAmt14Int2"] = 0;
        Session["wAmt2"] = 0;

        //ldgrY.IntAccNo = Convert.ToInt32(Session["intAccNo"]);
        ldgrY.IntAccNo = accNo;
        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, yr - 1);
        CalcMonthlyAmtsSingle(ldgrY.IntAccNo,yr);
        DeleteFromLedger(2);
        if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
        {
            SaveMonthlyAmtsSingle(yr);
            chgCnt = gen.NoOfTimesIntRtChgd(yr);
            if (chgCnt == 1)
            {
                ldgrY.DblIntRate = gblObj.RateOfInterest(yr);
                FillConsBoxBulk();  //Calc interest
            }
            else
            {
                int intMthCnt = 0;
                int intStMth = 0;
                int intEndMth = 0;
                int flg = 0;

                DataSet dsRt = new DataSet();
                dsRt = gen.GetDet4MltplRt(yr);
                for (int j = 0; j < chgCnt; j++)
                {
                    if (dsRt.Tables[0].Rows.Count > 0)
                    {
                        ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
                        intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
                        intStMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[2]);
                        intEndMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[3]);

                        ldgrY.DblTotOB = ldgrY.DblOB * intMthCnt;

                        CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1);
                        //ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
                        //ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
                    }
                    //dblAmtPart = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate * intMthCnt / 1200;
                    ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
                    ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
                    dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
                    dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
                }
                ldgrY.DblTotRemAmt = dblTotRem;
                ldgrY.DblTotWithAmt = dblTotWith;
                ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
                ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
                //FillConsBoxBulkMltplIntRt();
            }
            SaveYearlyAmtsSingle(0,yr);
        }
        else
        {
            FillConsBoxBulk();  //Calc interest
            SaveYearlyAmtsSingle(1,yr);
        }

    }
    //private void SaveMonthlyAmtsSingle( int yr)
    //{
    //    int k = 0;
    //    ArrayList ary = new ArrayList();
    //    DataSet dsy = new DataSet();
    //    ary.Add(ldgrY.IntAccNo);
    //    ary.Add(yr);
    //    dsy = ldgrDao.CreditCard(ary);
    //    int j = 0;
    //    if (dsy.Tables[0].Rows.Count > 0)
    //    {
    //        Session["maxRec"] = dsy.Tables[0].Rows.Count;
    //        ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
    //        for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
    //        {
    //            if (dsy.Tables[0].Rows[i].ItemArray[12].ToString() != "")
    //            {
    //                ldgr.IntDayId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[12]);
    //            }
    //            else
    //            {
    //                ldgr.IntDayId[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[9].ToString() != "")
    //            {
    //                ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[9]);
    //            }
    //            else
    //            {
    //                ldgr.IntMId[i] = 0;
    //            }

    //            if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
    //            {
    //                ldgr.DtChalDate[i] = Convert.ToDateTime(dsy.Tables[0].Rows[i].ItemArray[1]);
    //            }
    //            else
    //            {
    //                ldgr.DtChalDate[i] = Convert.ToDateTime("01/01/1960");

    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
    //            {
    //                ldgr.DblMsAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
    //            }
    //            else
    //            {
    //                ldgr.DblMsAmt[i] = 0;
    //            }

    //            if (dsy.Tables[0].Rows[i].ItemArray[3].ToString() != "")
    //            {
    //                ldgr.DblRfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[3]);
    //            }
    //            else
    //            {
    //                ldgr.DblRfAmt[i] = 0;
    //            }

    //            if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
    //            {
    //                ldgr.DblPfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[4]);
    //            }
    //            else
    //            {
    //                ldgr.DblPfAmt[i] = 0;
    //            }

    //            if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
    //            {
    //                ldgr.DblDAAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
    //            }
    //            else
    //            {
    //                ldgr.DblDAAmt[i] = 0;
    //            }

    //            if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
    //            {
    //                ldgr.DblPayAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
    //            }
    //            else
    //            {
    //                ldgr.DblPayAmt[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[11].ToString() != "")
    //            {
    //                ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[11]);
    //            }
    //            else
    //            {
    //                ldgr.DblWithAmt[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[7].ToString() != "")
    //            {
    //                ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[7]);
    //            }
    //            else
    //            {
    //                ldgr.DblTotRemMwise[i] = 0;
    //            }

    //            if (dsy.Tables[0].Rows[i].ItemArray[14].ToString() != "")
    //            {
    //                ldgr.IntLBId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[14]);
    //            }
    //            else
    //            {
    //                ldgr.IntLBId[i] = 0;
    //            }

    //            //////////To update FlgRemTorAG//////////
    //            if (dsy.Tables[0].Rows[i].ItemArray[18].ToString() != "")
    //            {
    //                ldgr.FlgRemTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //            }
    //            else
    //            {
    //                ldgr.FlgRemTorAG[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[19].ToString() != "")
    //            {
    //                ldgr.FlgWithTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[19]);
    //            }
    //            else
    //            {
    //                ldgr.FlgWithTorAG[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[20].ToString() != "")
    //            {
    //                ldgr.IntAGEntryId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[20]);
    //            }
    //            else
    //            {
    //                ldgr.IntAGEntryId[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[21].ToString() != "")
    //            {
    //                ldgr.IntAGEntryIdWith[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[21]);
    //            }
    //            else
    //            {
    //                ldgr.IntAGEntryIdWith[i] = 0;
    //            }
    //            //////////To update FlgRemTorAG//////////

    //            ArrayList arm = new ArrayList();

    //            arm.Add(ldgrY.IntAccNo);
    //            arm.Add(yr);
    //            arm.Add(ldgr.IntDayId[i]);
    //            arm.Add(ldgr.IntMId[i]);
    //            arm.Add(ldgr.DtChalDate[i]);
    //            arm.Add(ldgr.DblMsAmt[i]);
    //            arm.Add(ldgr.DblRfAmt[i]);
    //            arm.Add(ldgr.DblPfAmt[i]);
    //            arm.Add(ldgr.DblDAAmt[i]);
    //            arm.Add(ldgr.DblPayAmt[i]);
    //            arm.Add(ldgr.DblWithAmt[i]);

    //            if (i != 0 && ldgr.IntMId[i] == ldgr.IntMId[i - 1])
    //            {
    //                arm.Add(0);
    //                k = k + 1;
    //                j = i - k + 1;
    //            }
    //            else
    //            {
    //                arm.Add(ldgr.DblAmtForInt[j]);
    //                j = j + 1;
    //            }

    //            arm.Add(ldgr.IntLBId[i]);
    //            arm.Add(ldgr.FlgRemTorAG[i]);
    //            arm.Add(ldgr.FlgWithTorAG[i]);
    //            arm.Add(ldgr.IntAGEntryId[i]);
    //            arm.Add(ldgr.IntAGEntryIdWith[i]);
    //            ldgrDao.SaveLedgerM(arm);

    //        }
    //    }
    //}
    //private void SaveYearlyAmtsSingle(int yr,int flgNonTrans)
    //{
    //    ArrayList ary = new ArrayList();
    //    ary.Add(ldgrY.IntAccNo);
    //    ary.Add(yr);
    //    ary.Add(ldgrY.DblOB.ToString());
    //    ary.Add(ldgrY.DblTotRemAmt);
    //    ary.Add(Math.Round(ldgrY.DblIntAmt));
    //    ary.Add(ldgrY.DblRemOBIntAmt);
    //    ary.Add(ldgrY.DblTotWithAmt);
    //    ary.Add(ldgrY.DblCB);
    //    ary.Add(Convert.ToInt16(Session["mDoc"]));
    //    ary.Add(ldgrY.DblTotAmtForInt);
    //    ary.Add(ldgrY.DblTotWithAmtForInt);
    //    ary.Add(ldgrY.DblTotOB);
    //    ary.Add(flgNonTrans);
    //    ary.Add(ldgrY.DblCorrEntryAmt);
    //    ldgrD.SaveLedgerY(ary);
    //}
    private void CalcMonthlyAmtsBulkSingle(int accno,int yr)
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(yr);
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
            {
                //if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
                //{
                //    ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
                //}
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
        //gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    }
    //private void SaveCorrectionEntrySingle()
    //{
    //    int intMth = 0;
    //    int intDy = 0;
    //    double dblAmt = 0;
    //    double dblCalcAmt = 0;

    //    intMth = Convert.ToInt16(gdv2.Rows[i].Cells[3].Text);
    //    intDy = Convert.ToInt16(gdv2.Rows[i].Cells[4].Text);
    //    dblAmt = Convert.ToDouble(gdv2.Rows[i].Cells[5].Text);

    //    dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, 52, intMth, intDy, dblAmt);

    //    GridViewRow gvr = gdv2.Rows[i];
    //    Label lblAmt = (Label)gvr.FindControl("lblAmt");
    //    lblAmt.Text = dblCalcAmt.ToString();

    //    SaveCorrectionEntry(Convert.ToInt32(gdv2.Rows[i].Cells[1].Text), 100, intYrId, intMth, intDy, dblCalcAmt, 200, 4, dblAmt, dblAmt, 10, Convert.ToInt16(Session["flgTp"]));

    //}
    private void DeleteFromLedgerSingle(Int32 accNo)
    {
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(accNo);
        ldgrD.DelLedgerYearlySingle(arL);
    }
    private void DeleteFromLedgerSingleYr(Int32 accNo,int yr)
    {
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(accNo);
        arL.Add(yr);
        ldgrD.DelLedgerYearlySingleYrwise(arL);
    }

    private void DeleteFromLedger(int flg)
    {
        if (flg == 1)
        {
            DataSet dsL = new DataSet();
            ArrayList arL = new ArrayList();
            arL.Add(Convert.ToInt32(txtAccNoP.Text));
            arL.Add(Convert.ToInt16(Session["intYrCal"]));
            ldgrD.DelLedgerYearly(arL);
        }
        else
        {
            DataSet dsL = new DataSet();
            ArrayList arL = new ArrayList();
            arL.Add(Convert.ToInt32(Session["intAccNo"]));
            arL.Add(Convert.ToInt16(Session["intYrCal"]));
            ldgrD.DelLedgerYearly(arL);
        }

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


    //DataSet dsEmp = new DataSet();
    //    Session["intYrCal"] = gen.GetCCYearId();
    //    ldgrY.IntAccNo = Convert.ToInt32(txtAccNoP.Text);
    //    Session["intAccNo"] = ldgrY.IntAccNo;
    //    for (int i = 50; i <= Convert.ToInt16(Session["intYrCal"]); i++)
    //    {
    //        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, i - 1);
    //        ldgrY.DblIntRate = gblObj.RateOfInterest(i);
    //        CalcMonthlyAmtsBulkSingle(ldgrY.IntAccNo,i);
    //        if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
    //        {
    //            //DeleteFromLedger(2);
    //            SaveMonthlyAmtsSingle(i);
    //            FillConsBoxBulk();  //Calc interest
    //            SaveYearlyAmtsSingle(i,0);
    //        }
    //        else
    //        {
    //            FillConsBoxBulk();  //Calc interest
    //            SaveYearlyAmtsSingle(i,1);
    //        }

    //        ArrayList arl = new ArrayList();
    //        arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
    //        ldgrD.UpdateYearDet4GenerateCardNewSingle(arl);

    //    }
    private void CalcCurrentYearToLedgerMthlyAndLedgerYearly()
    {
        //double dblTotRem = 0;
        //double dblTotWith = 0;
        int chgCnt = 0;
        DataSet dsEmp = new DataSet();
        Session["intYrCal"] = gen.GetCCYearId();
        dsEmp = empDao.GetEmp4BulcCalcGroup();
        if (dsEmp.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
            {
                double dblTotRem = 0;
                double dblTotWith = 0;

                ldgrY = new LedgerY();
                ldgr = new LedgerM();

                Session["wAmt14Int1"] = 0;
                Session["wAmt1"] = 0;
                Session["wAmt14Int2"] = 0;
                Session["wAmt2"] = 0;

                ldgrY.IntAccNo = Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]);
                Session["intAccNo"] = ldgrY.IntAccNo;

                ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
                CalcMonthlyAmtsBulk(ldgrY.IntAccNo);
                //DeleteFromLedger(2);
                if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
                {
                    SaveMonthlyAmts();
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
                            if (dsRt.Tables[0].Rows.Count > 0)
                            {
                                ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
                                intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
                                intStMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[2]);
                                intEndMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[3]);

                                ldgrY.DblTotOB = ldgrY.DblOB * intMthCnt;

                                CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1);
                                //ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
                                //ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
                            }
                            //dblAmtPart = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate * intMthCnt / 1200;
                            ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
                            ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
                            dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
                            dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
                        }
                        ldgrY.DblTotRemAmt = dblTotRem;
                        ldgrY.DblTotWithAmt = dblTotWith;
                        ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
                        ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
                        //FillConsBoxBulkMltplIntRt();
                    }
                    SaveYearlyAmts(0);
                }
                else
                {
                    FillConsBoxBulk();  //Calc interest
                    SaveYearlyAmts(1);
                }
                ArrayList arl = new ArrayList();
                arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
                ldgrD.UpdateYearDet4GenerateCardNew(arl);

                /////////////////////////////
                empDao.UpdateL_Employee_Temp(arl);
                /////////////////////////////
            }
            gblObj.MsgBoxOk("completed! ", this);
        }


        //DataSet dsEmp = new DataSet();
        //Session["intYrCal"] = gen.GetCCYearId();
        //dsEmp = empDao.GetEmp4BulcCalcGroup();
        //if (dsEmp.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
        //    {
        //        ldgrY.IntAccNo = Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]);
        //        Session["intAccNo"] = ldgrY.IntAccNo;
        //        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
        //        ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
        //        CalcMonthlyAmtsBulk(ldgrY.IntAccNo);
        //        DeleteFromLedger(2);
        //        if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
        //        {
        //            SaveMonthlyAmts();
        //            FillConsBoxBulk();  //Calc interest
        //            SaveYearlyAmts(0);
        //        }
        //        else
        //        {
        //            FillConsBoxBulk();  //Calc interest
        //            SaveYearlyAmts(1);
        //        }
        //        ArrayList arl = new ArrayList();
        //        arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
        //        ldgrD.UpdateYearDet4GenerateCardNew(arl);

        //        /////////////////////////////
        //        empDao.UpdateL_Employee_Temp(arl);
        //        /////////////////////////////
        //    }
        //    gblObj.MsgBoxOk("completed! ", this);
        //}

    }
    //private void CalcCurrentYearToLedgerMthlyAndLedgerYearly()
    //{
    //    double dblTotRem = 0;
    //    double dblTotWith = 0;
    //    int chgCnt = 0;
    //    DataSet dsEmp = new DataSet();
    //    Session["intYrCal"] = gen.GetCCYearId();
    //    //dsEmp = empDao.GetEmp4BulcCalcGroup();
    //    //if (dsEmp.Tables[0].Rows.Count > 0)
    //    //{
    //    //for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
    //    //{
    //    ldgrY = new LedgerY();
    //    ldgr = new LedgerM();

    //    Session["wAmt14Int1"] = 0;
    //    Session["wAmt1"] = 0;
    //    Session["wAmt14Int2"] = 0;
    //    Session["wAmt2"] = 0;

    //    ldgrY.IntAccNo = 944;
    //    Session["intAccNo"] = ldgrY.IntAccNo;
    //    ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
    //    CalcMonthlyAmtsBulk(ldgrY.IntAccNo);
    //    DeleteFromLedger(2);
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

    //                    CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1);
    //                    //ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
    //                    //ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
    //                }
    //                //dblAmtPart = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate * intMthCnt / 1200;
    //                ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
    //                ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
    //                dblTotRem = dblTotRem + ldgrY.DblTotRemAmt;
    //                dblTotWith = dblTotWith + ldgrY.DblTotWithAmt;
    //            }
    //            ldgrY.DblTotRemAmt = dblTotRem;
    //            ldgrY.DblTotWithAmt = dblTotWith;
    //            ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
    //            ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
    //            //FillConsBoxBulkMltplIntRt();
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
    //    //}
    //    gblObj.MsgBoxOk("completed! ", this);
    //    //}

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

    private void CalcCurrentYearToLedgerMthlyAndLedgerYearlyP()
    {
        DataSet dsEmp = new DataSet();
        Session["intYrCal"] = 51;
        ldgrY.IntAccNo = Convert.ToInt32(txtAccNoP.Text);
        Session["intAccNo"] = ldgrY.IntAccNo;
        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
        ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
        CalcMonthlyAmtsBulk(ldgrY.IntAccNo);
        if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
        {
            //DeleteFromLedger(2);
            SaveMonthlyAmts();
            FillConsBoxBulk();  //Calc interest
            SaveYearlyAmts(0);
        }
        else
        {
            FillConsBoxBulk();  //Calc interest
            SaveYearlyAmts(1);
        }

        ArrayList arl = new ArrayList();
        arl.Add(Convert.ToInt32(ldgrY.IntAccNo));
        ldgrD.UpdateYearDet4GenerateCardNew(arl);


        gblObj.MsgBoxOk("completed! ", this);

        //Session["intYrCal"] = 51;
        //ldgrY.IntAccNo = Convert.ToInt32(txtAccNoP.Text);
        //ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
        //ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
        //CalcMonthlyAmtsBulk(ldgrY.IntAccNo);

        //if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
        //{
        //    SaveMonthlyAmts();
        //    FillConsBoxBulk();  //Calc interest
        //    SaveYearlyAmts(0);
        //}
        //else
        //{
        //    SaveYearlyAmts(1);
        //}
        ////////Update CorrEntry amount in LedgerYearly////////////
        //ArrayList arl = new ArrayList();
        //arl.Add(ldgrY.IntAccNo);
        //ldgrD.UpdateYearDet4GenerateCardNew(arl);
        ////////Update CorrEntry amount in LedgerYearly////////////
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
    private void SaveYearlyAmtsSingle(int flgNonTrans,int yr)
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
        ldgrD.SaveLedgerY(ary);
    }
    //private void FillConsBoxBulkMltplIntRt()
    //{
    //    double dblAmtPart = 0;
    //    int chgCnt = 0;
    //    DataSet ds = new DataSet();
    //    int intMthCnt = 0;

    //    ldgrY.DblOB = ldgrY.DblOB;
    //    ldgrY.DblTotOB = ldgrY.DblOB * 12;
    //    ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
    //    chgCnt = gen.NoOfTimesIntRtChgd(Convert.ToInt16(Session["intYrCal"]));
    //    if (chgCnt == 1)
    //    {
    //        ldgrY.DblOB = ldgrY.DblOB;
    //        ldgrY.DblTotOB = ldgrY.DblOB * 12;
    //        ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
    //        ldgrY.DblIntAmt = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
    //        ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
    //        ldgrY.DblCB = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
    //    }
    //    else
    //    {
    //        for (int i = 0; i < chgCnt; i++)
    //        {
                
    //            ds = gen.GetDet4MltplRt(Convert.ToInt16(Session["intYrCal"]), i+1);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                ldgrY.DblIntRate = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[1]);
    //                intMthCnt = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
    //                ldgrY.DblTotOB = ldgrY.DblOB * intMthCnt;
    //                ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
    //                ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
    //            }
    //            dblAmtPart = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate * intMthCnt / 1200;

    //            ldgrY.DblIntAmt = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
    //            //CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRt(i, CalcAmt));
    //        }
    //    }
    //    ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
    //    ldgrY.DblCB = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
    //}
    private void FillConsBoxBulk()
    {
        ldgrY.DblOB = ldgrY.DblOB;
        ldgrY.DblTotOB = ldgrY.DblOB * 12;
        ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt;
        ldgrY.DblIntAmt = (ldgrY.DblTotOB + ldgrY.DblTotAmtForInt - ldgrY.DblTotWithAmtForInt) * ldgrY.DblIntRate / 1200;
        ldgrY.DblRemOBIntAmt = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
        ldgrY.DblCB = ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
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
            ldgrY.IntYrId = yr;
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
    private void SaveMonthlyAmts()
    {
        int k = 0;
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(ldgrY.IntAccNo);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCard(ary);
        int j = 0;
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
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
               
                if (i !=0 && ldgr.IntMId[i] == ldgr.IntMId[i - 1])
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


        //ArrayList ary = new ArrayList();
        //DataSet dsy = new DataSet();
        //ary.Add(ldgrY.IntAccNo);
        //ary.Add(Convert.ToInt16(Session["intYrCal"]));
        //dsy = ldgrDao.CreditCard(ary);
        //if (dsy.Tables[0].Rows.Count > 0)
        //{
        //    Session["maxRec"] = dsy.Tables[0].Rows.Count;
        //    ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
        //    for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
        //    {
        //        if (dsy.Tables[0].Rows[i].ItemArray[12].ToString() != "")
        //        {
        //            ldgr.IntDayId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[12]);
        //        }
        //        else
        //        {
        //            ldgr.IntDayId[i] = 0;
        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[9].ToString() != "")
        //        {
        //            ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[9]);
        //        }
        //        else
        //        {
        //            ldgr.IntMId[i] = 0;
        //        }

        //        if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
        //        {
        //            ldgr.DtChalDate[i] = Convert.ToDateTime(dsy.Tables[0].Rows[i].ItemArray[1]);
        //        }
        //        else
        //        {
        //            ldgr.DtChalDate[i] = Convert.ToDateTime("01/01/1960");

        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
        //        {
        //            ldgr.DblMsAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
        //        }
        //        else
        //        {
        //            ldgr.DblMsAmt[i] = 0;
        //        }

        //        if (dsy.Tables[0].Rows[i].ItemArray[3].ToString() != "")
        //        {
        //            ldgr.DblRfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[3]);
        //        }
        //        else
        //        {
        //            ldgr.DblRfAmt[i] = 0;
        //        }

        //        if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
        //        {
        //            ldgr.DblPfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[4]);
        //        }
        //        else
        //        {
        //            ldgr.DblPfAmt[i] = 0;
        //        }

        //        if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
        //        {
        //            ldgr.DblDAAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
        //        }
        //        else
        //        {
        //            ldgr.DblDAAmt[i] = 0;
        //        }

        //        if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
        //        {
        //            ldgr.DblPayAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
        //        }
        //        else
        //        {
        //            ldgr.DblPayAmt[i] = 0;
        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[11].ToString() != "")
        //        {
        //            ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[11]);
        //        }
        //        else
        //        {
        //            ldgr.DblWithAmt[i] = 0;
        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[7].ToString() != "")
        //        {
        //            ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[7]);
        //        }
        //        else
        //        {
        //            ldgr.DblTotRemMwise[i] = 0;
        //        }

        //        if (dsy.Tables[0].Rows[i].ItemArray[14].ToString() != "")
        //        {
        //            ldgr.IntLBId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[14]);
        //        }
        //        else
        //        {
        //            ldgr.IntLBId[i] = 0;
        //        }

        //        //////////To update FlgRemTorAG//////////
        //        if (dsy.Tables[0].Rows[i].ItemArray[18].ToString() != "")
        //        {
        //            ldgr.FlgRemTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
        //        }
        //        else
        //        {
        //            ldgr.FlgRemTorAG[i] = 0;
        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[19].ToString() != "")
        //        {
        //            ldgr.FlgWithTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[19]);
        //        }
        //        else
        //        {
        //            ldgr.FlgWithTorAG[i] = 0;
        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[20].ToString() != "")
        //        {
        //            ldgr.IntAGEntryId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[20]);
        //        }
        //        else
        //        {
        //            ldgr.IntAGEntryId[i] = 0;
        //        }
        //        if (dsy.Tables[0].Rows[i].ItemArray[21].ToString() != "")
        //        {
        //            ldgr.IntAGEntryIdWith[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[21]);
        //        }
        //        else
        //        {
        //            ldgr.IntAGEntryIdWith[i] = 0;
        //        }
        //        //////////To update FlgRemTorAG//////////

        //        ArrayList arm = new ArrayList();
        //        arm.Add(ldgrY.IntAccNo);
        //        arm.Add(Convert.ToInt16(Session["intYrCal"]));
        //        arm.Add(ldgr.IntDayId[i]);
        //        arm.Add(ldgr.IntMId[i]);
        //        arm.Add(ldgr.DtChalDate[i]);
        //        arm.Add(ldgr.DblMsAmt[i]);
        //        arm.Add(ldgr.DblRfAmt[i]);
        //        arm.Add(ldgr.DblPfAmt[i]);
        //        arm.Add(ldgr.DblDAAmt[i]);
        //        arm.Add(ldgr.DblPayAmt[i]);
        //        arm.Add(ldgr.DblWithAmt[i]);
        //        arm.Add(ldgr.DblAmtForInt[i]);
        //        arm.Add(ldgr.IntLBId[i]);
        //        arm.Add(ldgr.FlgRemTorAG[i]);
        //        arm.Add(ldgr.FlgWithTorAG[i]);
        //        arm.Add(ldgr.IntAGEntryId[i]);
        //        arm.Add(ldgr.IntAGEntryIdWith[i]);
        //        ldgrDao.SaveLedgerM(arm);

        //    }
        //}
    }
    private void CalcMonthlyAmtsBulk4MltplRt(int accno,int cnt, int intStMth, int intEndMth,int flg,int rw)
    {
        int j = 0, k = 0, mid1=0, mid2=0;
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = cnt;
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
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
            for (int i = j; i < j+cnt; i++)
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

                if (ldgr.DblWithAmt[i] > 0)
                {

                    if (flg == 0)   // first loop ie. j=1
                    {
                        Session["wAmt1"] = Convert.ToDouble(ldgr.DblWithAmt[i]);
                        if (k == 0)      // first block
                        {
                            mid1 = cnt - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;                           
                        }
                        else                 // second block
                        {
                            mid1 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
                        }
                    }
                    else          // second loop ie. j=2
                    {
                        Session["wAmt2"] = Convert.ToDouble(ldgr.DblWithAmt[i]);
                        if (k == 0)
                        {
                            mid2 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
                        }
                        else
                        {
                            mid2 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
                        }
                    }
                    k = k + 1;
                }

                if (mid1 > 0)
                {
                    Session["wAmt14Int1"] = Convert.ToDouble(Session["wAmt1"]) * mid1;
                    //double a1 = Convert.ToDouble(Session["wAmt14Int1"]);
                }
                else
                {
                    Session["wAmt14Int1"] = Convert.ToDouble(Session["wAmt1"]) * cnt;
                    //double a1 = Convert.ToDouble(Session["wAmt14Int1"]);
                }
                if (mid2 > 0)
                {
                    Session["wAmt14Int2"] = Convert.ToDouble(Session["wAmt2"]) * mid2;
                    //double a2 = Convert.ToDouble(Session["wAmt14Int2"]);
                }
                else
                {
                    Session["wAmt14Int2"] = Convert.ToDouble(Session["wAmt2"]) * (12 - cnt);
                    //double a2 = Convert.ToDouble(Session["wAmt14Int2"]);
                }
                ldgrY.FlgNonTrans = 0;
                ldgrY.DblCorrEntryAmt = 0;
            }
            
            ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
        }
    }
    private double CalculateAmtForIntWith(int rowNo)
    {
        double amt = 0;
        if (rowNo == 0)
        {
            amt = ldgr.DblWithAmt[rowNo];
        }
        else
        {
            amt = ldgr.DblWithAmt[rowNo - 1] + ldgr.DblWithAmt[rowNo];
        }
        return amt;
    }
    private void CalcMonthlyAmtsSingle(int accno,int yr)
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(yr);
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = yr;
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
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
        //gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    }
    private void CalcMonthlyAmtsBulk(int accno)
    {
        ArrayList ary = new ArrayList();
        DataSet dsy = new DataSet();
        ary.Add(accno);
        ary.Add(Convert.ToInt16(Session["intYrCal"]));
        dsy = ldgrDao.CreditCardBulk(ary);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            Session["maxRec"] = dsy.Tables[0].Rows.Count;
            ldgrY.IntAccNo = accno;
            ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
            ldgrY.DblTotRemAmt = 0;
            ldgrY.DblTotWithAmt = 0;
            ldgrY.DblTotAmtForInt = 0;
            ldgrY.DblRemOBIntAmt = 0;
            ldgrY.DblTotWithAmtForInt = 0;
            for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
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
        //gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    }

    private int CalculateBalMonthsBulk(int mid)
    {
        int midn = 0;
        int mths = 0;
        //intMonthId = gen.GetMonthIdFromID(Convert.ToInt16(Session["mDoc"]));
        midn = gen.GetMonthIdFromID(Convert.ToInt16(mid));
        mths = 12 - midn + 1;
        return mths;
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
    protected void btnBulk_Click(object sender, EventArgs e)
    {
        if (CheckAllApp() == true)
        {
            Session["intYearIdMax"] = gen.GetCCYearId();
            ArrayList arrr = new ArrayList();
            arrr.Add(Convert.ToInt16(Session["intYearIdMax"]));
            ldgrD.DelLedgerYearlyBulk(arrr);
            CalcCurrentYearToLedgerMthlyAndLedgerYearly();
            gblObj.MsgBoxOk("Updated!", this);
            btnBulkSelection.Enabled = false;
        }
        else
        {
            gblObj.MsgBoxOk("approve all districts", this);
        }

        //int balMonth = 0;
        //int cntIntChgd = 0;
        //double CalcAmt = amt;
        //double dblIntRate = 0;

        //if (CheckAllApp() == true)
        //{
        //    CalcCurrentYearToLedgerMthlyAndLedgerYearly();
        //    gblObj.MsgBoxOk("Updated!", this);
        //    btnBulkSelection.Enabled = false;
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("approve all districts", this);
        //}

        //if (gen.NoOfTimesIntRtChgd(Convert.ToInt16(Session["intYrCal"])) == 1)
        //{
        //    dblIntRate = RateOfInterest(i);
        //    if (i == yrIdSt)
        //    {
        //        balMonth = genDao.GetBalanceMonth(mthSt, dySt);
        //        CalcAmt = Math.Round(CalcAmt + (CalcAmt * balMonth * dblIntRate / 1200));
        //    }
        //    else
        //    {
        //        CalcAmt = Math.Round(CalcAmt + (CalcAmt * dblIntRate / 100));
        //    }
        //}

        
    }
    private void DeleteYearly()
    {
        ArrayList ar = new ArrayList();
        Session["intYrCal"] = gen.GetCCYearId();
        ar.Add(Convert.ToInt16(Session["intYrCal"]));
        ldgrD.DelLedgerYearlyBulk(ar);

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
    //            Session["intAccNo"] = ldgrY.IntAccNo;
    //            ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, Convert.ToInt16(Session["intYrCal"]) - 1);
    //            ldgrY.DblIntRate = gblObj.RateOfInterest(Convert.ToInt16(Session["intYrCal"]));
    //            CalcMonthlyAmtsBulk(ldgrY.IntAccNo);

    //            if (IsData(ldgrY.DblTotRemAmt, ldgrY.DblTotWithAmt) == true)
    //            {
    //                DeleteFromLedger(2);
    //                SaveMonthlyAmts();
    //                FillConsBoxBulk();  //Calc interest
    //                SaveYearlyAmts(0);
    //            }
    //            else
    //            {
    //                SaveYearlyAmts(1);
    //            }


    //            //////Update CorrEntry amount in LedgerYearly////////////
    //            //if (IsCorrEntryExists == true)
    //            //{
    //            //    ArrayList arl = new ArrayList();
    //            //    arl.Add(ldgrY.IntAccNo);
    //            //    ldgrD.UpdateYearDet4GenerateCardNew(arl);
    //            //}
    //            //////Update CorrEntry amount in LedgerYearly////////////

    //        }
    //        UpdCorrEntryData();
    //    }
    //}
    //private void CalcMonthlyAmtsBulk(int accno)
    //{
    //    ArrayList ary = new ArrayList();
    //    DataSet dsy = new DataSet();
    //    ary.Add(accno);
    //    ary.Add(Convert.ToInt16(Session["intYrCal"]));
    //    dsy = ldgrDao.CreditCardBulk(ary);
    //    if (dsy.Tables[0].Rows.Count > 0)
    //    {
    //        Session["maxRec"] = dsy.Tables[0].Rows.Count;
    //        ldgrY.IntAccNo = accno;
    //        ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
    //        ldgrY.DblTotRemAmt = 0;
    //        ldgrY.DblTotWithAmt = 0;
    //        ldgrY.DblTotAmtForInt = 0;
    //        ldgrY.DblRemOBIntAmt = 0;
    //        ldgrY.DblTotWithAmtForInt = 0;
    //        for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
    //        {
    //            if (dsy.Tables[0].Rows[i].ItemArray[4].ToString() != "")
    //            {
    //                ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[4]);
    //            }
    //            else
    //            {
    //                ldgr.IntMId[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[1].ToString() != "")
    //            {
    //                ldgr.Dbl4Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[1]);
    //            }
    //            else
    //            {
    //                ldgr.Dbl4Amt[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[2].ToString() != "")
    //            {
    //                ldgr.Dbl5Amt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
    //            }
    //            else
    //            {
    //                ldgr.Dbl5Amt[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[5].ToString() != "")
    //            {
    //                ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
    //            }
    //            else
    //            {
    //                ldgr.DblWithAmt[i] = 0;
    //            }
    //            if (dsy.Tables[0].Rows[i].ItemArray[6].ToString() != "")
    //            {
    //                ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
    //            }
    //            else
    //            {
    //                ldgr.DblTotRemMwise[i] = 0;
    //            }
    //            ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
    //            ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
    //            ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
    //            ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];
    //            ldgrY.DblTotWithAmtForInt = ldgrY.DblTotWithAmtForInt + CalculateBalMonthsBulk(ldgr.IntMId[i]) * ldgr.DblWithAmt[i];
    //            ldgrY.FlgNonTrans = 0;
    //            ldgrY.DblCorrEntryAmt = 0;
    //        }
    //    }
    //    //gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    //}

    //private void CalcMonthlyAmts()
    //{

    //    ArrayList ary = new ArrayList();
    //    DataSet dsy = new DataSet();
    //    ary.Add(Convert.ToInt16(Session["intAccNo"]));
    //    ary.Add(Convert.ToInt16(Session["intYrCal"]));
    //    dsy = ldgrDao.CreditCardPart(ary);
    //    if (dsy.Tables[0].Rows.Count > 0)
    //    {
    //        Session["maxRec"] = dsy.Tables[0].Rows.Count;
    //        ldgrY.IntAccNo = Convert.ToInt16(Session["intAccNo"]);
    //        ldgrY.IntYrId = Convert.ToInt16(Session["intYrCal"]);
    //        ldgrY.DblTotRemAmt = 0;
    //        ldgrY.DblTotWithAmt = 0;
    //        for (int i = 0; i < Convert.ToInt16(Session["maxRec"]); i++)
    //        {
    //            if (Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[15]) <= Convert.ToInt16(Session["mDoc"]))
    //            {
    //                ldgr.IntDayId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //                ldgr.IntMId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[15]);
    //                if (dsy.Tables[0].Rows[i].ItemArray[19].ToString() != "")
    //                {
    //                    ldgr.DtChalDate[i] = Convert.ToDateTime(dsy.Tables[0].Rows[i].ItemArray[19]);
    //                }
    //                else
    //                {
    //                    ldgr.DtChalDate[i] = Convert.ToDateTime("01/01/1960");
    //                }
    //                ldgr.DblMsAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[2]);
    //                ldgr.DblRfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[3]);
    //                ldgr.DblPfAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[4]);
    //                ldgr.DblDAAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[5]);
    //                ldgr.DblPayAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[6]);
    //                ldgr.DblWithAmt[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[13]);
    //                ldgr.DblTotRemMwise[i] = Convert.ToDouble(dsy.Tables[0].Rows[i].ItemArray[7]);
    //                ldgr.DblAmtForInt[i] = CalculateAmtForInt(i);
    //                ldgr.IntLBId[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[11]);

    //                CheckDupMonth(Convert.ToInt16(Session["maxRec"]));


    //                //ldgr.FlgRemTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //                //ldgr.FlgWithTorAG[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //                //ldgr.FlgRemTorAGRem1[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //                //ldgr.FlgWithTorAGWith1[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //                //ldgr.FlgRemTorAGRem2[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);
    //                //ldgr.FlgWithTorAGWith2[i] = Convert.ToInt16(dsy.Tables[0].Rows[i].ItemArray[18]);

    //                ldgrY.DblTotAmtForInt = ldgrY.DblTotAmtForInt + ldgr.DblAmtForInt[i];
    //                ldgrY.DblTotRemAmt = ldgrY.DblTotRemAmt + ldgr.DblTotRemMwise[i];
    //                ldgrY.DblTotWithAmt = ldgrY.DblTotWithAmt + ldgr.DblWithAmt[i];
    //                //ldgrY.DblTotWithAmtForInt = ldgrY.DblTotWithAmtForInt + CalculateBalMonths(ldgr.IntMId[i]) * ldgr.DblWithAmt[i];

    //                GridViewRow gvr = gdvP.Rows[i];
    //                Label lblMthId = (Label)gvr.FindControl("lblMthId");

    //                ldgrY.DblTotWithAmtForInt = ldgrY.DblTotWithAmtForInt + CalculateBalMonths(Convert.ToInt16(lblMthId.Text)) * ldgr.DblWithAmt[i];

    //                ldgrY.FlgNonTrans = 0;
    //                ldgrY.DblCorrEntryAmt = 0;

    //                //GridViewRow gvr = gdvP.Rows[i];
    //                //Label lblAmt4Int = (Label)gvr.FindControl("lblAmt4Int");
    //                //Label lblAmt4IntW = (Label)gvr.FindControl("lblAmt4IntW");

    //                //lblAmt4Int.Text = ldgr.DblAmtForInt[i].ToString();
    //                ////lblAmt4IntW.Text = ldgrY.DblTotWithAmtForInt.ToString();
    //            }
    //        }
    //    }
    //    gblObj.SetFooterTotalsTempField(gdvP, 10, "lblAmt4Int", 2);
    //}
    private int CalculateBalMonths(int mid)
    {
        int intMonthId = 0;
        int mths = 0;
        intMonthId = gen.GetMonthIdFromID(Convert.ToInt16(Session["mDoc"]));
        mths = intMonthId - mid + 1;
        return mths;
    }

    protected void rdSngl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdSngl.Items[1].Selected == true)
        {
            Session["calcTp"] = 2;
            pnlSanction.Visible = true;
            pnlCorrCalc.Visible = false;
            btnBulkSelection.Enabled = false;
            btnBulk.Enabled = false;
            btnBulkMltplYr.Enabled = false;
            btnBulkNew.Enabled = true;
            txtAccNoP.Enabled = true;
        }
        else if (rdSngl.Items[0].Selected == true)
        {
            Session["calcTp"] = 1;
            pnlSanction.Visible = false;
            pnlCorrCalc.Visible = true;
            //FillYear();
            SetGridDefault();
            SetGridDefaultn();
            btnBulkSelection.Enabled = false;
            btnBulk.Enabled = false;
            btnBulkMltplYr.Enabled = false;
        }
        else if (rdSngl.Items[2].Selected == true)
        {
            Session["calcTp"] = 3;
            pnlSanction.Visible = true;
            pnlCorrCalc.Visible = false;
            btnBulkSelection.Enabled = true;
            btnBulk.Enabled = true;
            btnBulkMltplYr.Enabled = true;
            btnBulkNew.Enabled = false;
            txtAccNoP.Enabled = false;
            ddlYr.Enabled = false;
        }
        else if (rdSngl.Items[3].Selected == true)
        {
            Session["calcTp"] = 4;
            pnlSanction.Visible = false;
            pnlCorrCalc.Visible = true;
            //FillYear();
            SetGridDefault();
            SetGridDefaultn();
            btnBulkSelection.Enabled = false;
            btnBulk.Enabled = false;
            btnBulkMltplYr.Enabled = false;
            txtAccNoSingle.Enabled = false;
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("slno");
        ar.Add("intAccNo");
        ar.Add("RemAmt");
        ar.Add("Withdrawal");
        ar.Add("intDay");
        ar.Add("intMonthId");
        ar.Add("Ob");
        gblObj.SetGridDefault(gdvCalcCorr, ar);
        gdvCalcCorr.Enabled = false;
    }
    private void SetGridDefaultn()
    {
        ArrayList ar = new ArrayList();
        ar.Add("slno");
        ar.Add("intAccNo");
        ar.Add("intYrId");
        ar.Add("RemAmt");
        ar.Add("intDay");
        ar.Add("intMonthId");
        ar.Add("tpCorr");
        ar.Add("tp");
        gblObj.SetGridDefault(gdv2, ar);
        gdv2.Enabled = false;
    }
    //private void FillYear()
    //{
    //    DataSet ds2 = new DataSet();
    //    ds2 = gen.GetYearRem();
    //    gblObj.FillCombo(ddlYear, ds2, 1);
    //}
    private void FillYr()
    {
        DataSet dsy = new DataSet();
        dsy = kgen.GetYearOnLine();
        gblObj.FillCombo(ddlYr, dsy, 1);
    }
    private void SaveToCorrEntry()
    {
        for (int i = 0; i < gdv2.Rows.Count; i++)
        {
            int intYrId = 0;
            int intMth = 0;
            int intDy = 0;
            double dblAmt = 0;
            double dblCalcAmt = 0;
            int tp = 0;
            intMth = Convert.ToInt16(gdv2.Rows[i].Cells[3].Text);
            intDy = Convert.ToInt16(gdv2.Rows[i].Cells[4].Text);
            dblAmt = Convert.ToDouble(gdv2.Rows[i].Cells[5].Text);
            intYrId = getYearId(Convert.ToInt16(gdv2.Rows[i].Cells[2].Text));
            tp = Convert.ToInt16(gdv2.Rows[i].Cells[7].Text);
            dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, 52, intMth, intDy, dblAmt);
            GridViewRow gvr = gdv2.Rows[i];
            Label lblAmt = (Label)gvr.FindControl("lblAmt");
            lblAmt.Text = dblCalcAmt.ToString();

            SaveCorrectionEntry(Convert.ToInt32(gdv2.Rows[i].Cells[1].Text), 100, intYrId, intMth, intDy, dblCalcAmt, 200, 4, dblAmt, dblAmt, 10, tp);
        }
    }
    private void SaveToCorrEntryLat()
    {
        for (int i = 0; i < gdv2.Rows.Count; i++)
        {
            int intYrId = 0;
            int intMth = 0;
            int intDy = 0;
            double dblAmt = 0;
            double dblCalcAmt = 0;
            int tp = 0;
            intMth = Convert.ToInt16(gdv2.Rows[i].Cells[3].Text);
            intDy = Convert.ToInt16(gdv2.Rows[i].Cells[4].Text);
            dblAmt = Convert.ToDouble(gdv2.Rows[i].Cells[5].Text);
            //intYrId = getYearId(Convert.ToInt16(gdv2.Rows[i].Cells[2].Text));
            intYrId = Convert.ToInt16(gdv2.Rows[i].Cells[2].Text);
            tp = Convert.ToInt16(gdv2.Rows[i].Cells[7].Text);
            dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, 52, intMth, intDy, dblAmt);

            GridViewRow gvr = gdv2.Rows[i];
            Label lblAmt = (Label)gvr.FindControl("lblAmt");
            lblAmt.Text = dblCalcAmt.ToString();

            //Label lblyr = (Label)gvr.FindControl("lblyr");
            //lblyr.Text = dblCalcAmt.ToString();

            SaveCorrectionEntry(Convert.ToInt32(gdv2.Rows[i].Cells[1].Text), 100, intYrId, intMth, intDy, dblCalcAmt, 200, 4, dblAmt, dblAmt, 10, tp);
        }
    }
    private void SetGridDefaultnwS()
    {
        ArrayList ar = new ArrayList();
        ar.Add("slno");
        ar.Add("intAccNo");
        ar.Add("intYrId");
        ar.Add("fltChalanAmt");
        ar.Add("intDay");
        ar.Add("intMonthId");
        ar.Add("tpCorr");
        ar.Add("intChalanId");
        ar.Add("tp");
        ar.Add("LCorrTp");

        gblObj.SetGridDefault(gdvS, ar);
        gdvS.Enabled = false;
    }
    private void FillGridAndCalc()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        //Session["intYearCalcCorr"] = gen.GetCCYearId();
        //ar.Add(Convert.ToDouble(Session["numEmpIdLedger"]));
        ar.Add(Convert.ToInt16(txtAccNoSingle.Text));
        ar.Add(Convert.ToInt16(Session["intYrCal"]));
        dsSched = gen.getCorrDetnS(ar);
        SetGridDefaultnwS();
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdvS.DataSource = dsSched;
            gdvS.DataBind();
            for (int i = 0; i < gdvS.Rows.Count; i++)
            {
                GridViewRow gvr = gdvS.Rows[i];
                if (dsSched.Tables[0].Rows[i].ItemArray[5].ToString() == "3")
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.Red;
                    gvr.Cells[5].Font.Bold = true;
                }
                else if (dsSched.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.Green;
                    gvr.Cells[5].Font.Bold = true;
                }
                ///////////////////////////////////////////////////
                int intMth = 0;
                int intDy = 0;
                double dblAmt = 0;
                double dblCalcAmt = 0;
                int tp = 0;
                int intChalanId = 0;
                int intCorrTpe = 0;
                int intYrId = 0;

                intYrId = Convert.ToInt16(gdvS.Rows[i].Cells[2].Text);
                intMth = Convert.ToInt16(gdvS.Rows[i].Cells[3].Text);
                intDy = Convert.ToInt16(gdvS.Rows[i].Cells[4].Text);
                dblAmt = Convert.ToDouble(gdvS.Rows[i].Cells[5].Text);
                tp = Convert.ToInt16(gdvS.Rows[i].Cells[8].Text);
                intChalanId = Convert.ToInt32(gdvS.Rows[i].Cells[9].Text);
                if (Convert.ToInt16(gdvS.Rows[i].Cells[6].Text) == 1)
                {
                    dblAmt = -dblAmt;
                }
                dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intYrCal"]), intMth, intDy, dblAmt);

                Label lblAmt = (Label)gvr.FindControl("lblAmt");
                lblAmt.Text = dblCalcAmt.ToString();
                intCorrTpe = Convert.ToInt16(gdvS.Rows[i].Cells[10].Text);
                SaveCorrectionEntry(Convert.ToInt32(gdvS.Rows[i].Cells[1].Text), intChalanId, intYrId, intMth, intDy, dblCalcAmt, 200, intCorrTpe, dblAmt, dblAmt, 10, tp);
                gblObj.MsgBoxOk("Ok!!!", this);
                ///////////////////////////////////////////////////
            }
        }
    }
    protected void btnCorrCalc_Click(object sender, EventArgs e)
    {
        Session["intYrCal"] = gen.GetCCYearId();
        if (Convert.ToInt16(Session["calcTp"]) == 1)
        {
            if (txtAccNoSingle.Text == "" || txtAccNoSingle.Text == null)
            {
                gblObj.MsgBoxOk("Enter Employee!", this);
            }
            else
            {
                if (Convert.ToInt16(txtAccNoSingle.Text) > 0)
                {
                    /////////// Delete from Corr ////////////////
                    ArrayList ar = new ArrayList();
                    ar.Add(Convert.ToInt16(txtAccNoSingle.Text));
                    ar.Add(Convert.ToInt16(Session["intYrCal"]));
                    crrD.DelCorrEntry(ar);
                    /////////// Delete from Corr ////////////////
                    gdvS.Visible = true;
                    gdv2.Visible = false;
                    FillGridAndCalc();
                }
                else
                {
                    gblObj.MsgBoxOk("Enter Employee!", this);
                }
            }
        }
        else
        {
            // Bulk calc ////
        }
    }
    private void updateLedgerYearly(Int32 intAcc)
    {
        LedgerYDao ldgrY=new LedgerYDao();
        ArrayList ar = new ArrayList();
        ar.Add(intAcc);
        ldgrY.UpdateYearDet4GenerateCardNewSingle(ar);
    }
    private int getYearId(int intyr)
    {
        int intYrId = 0;
        ArrayList arn = new ArrayList();
        DataSet dsy = new DataSet();
        arn.Add(intyr);
        dsy = gen.Getyr4ABCDRpt(arn);
        if (dsy.Tables[0].Rows.Count > 0)
        {
            intYrId = Convert.ToInt16(dsy.Tables[0].Rows[0].ItemArray[0]);
        }
        return intYrId;
    }
    private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType, int FlgType)
    {

        //Session["intCCYearId"] = 51;
        crr.IntAccNo = intAccNo;
        crr.IntYearID = yr;
        crr.IntMonthID = mth;
        crr.IntYearIDCorrected = Convert.ToInt16(Session["intYrCal"]);
        crr.FltAmountBefore = fltAmtBfr;
        crr.FltAmountAfter = fltAmtAfr;
        crr.FltCalcAmount = amt;
        crr.FlgCorrected = 1;      //Just added not incorporated in CCard
        crr.IntChalanId = chalId;
        crr.IntSchedId = intSchedId;
        crr.FlgType = FlgType;           //Remittance
        crr.FltRoundingAmt = 0;
        crr.IntCorrectionType = intCorrTp; //Edit Chal Date
        crr.IntChalanType = ChngType;
        crrD.CreateCorrEntryCalc(crr);

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearCalcCorr"] = Convert.ToInt16(ddlYear.SelectedValue);
            //FillGrid();
            FillGridn();
        }
    }
    private void FillGridSingle()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(txtAccNoSingle.Text));
        dsSched = gen.getCorrDetnSingle(ar);
        SetGridDefaultn();
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdv2.DataSource = dsSched;
            gdv2.DataBind();
            SaveToCorrEntry();
        }
    }
    private void FillGridSingleLat()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(txtAccNoSingle.Text));
        dsSched = gen.getCorrDetnSingleLat(ar);
        SetGridDefaultn();
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdv2.DataSource = dsSched;
            gdv2.DataBind();
            SaveToCorrEntryLat();
            //for (int i = 0; i < gdv2.Rows.Count; i++)
            //{
            //    GridViewRow gvr = gdv2.Rows[i];
            //    Label lblyr = (Label)gvr.FindControl("lblyr");
            //    lblyr.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();
            //}
        }
    }
    private void FillGridn()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
        dsSched = gen.getCorrDetn(ar);
        SetGridDefaultn();
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdv2.DataSource = dsSched;
            gdv2.DataBind();
            for (int i = 0; i < gdv2.Rows.Count; i++)
            {
                GridViewRow gvr = gdv2.Rows[i];
                if (dsSched.Tables[0].Rows[i].ItemArray[5].ToString() == "3")
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.Red;
                    gvr.Cells[5].Font.Bold = true;
                }
                else if (dsSched.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.Green;
                    gvr.Cells[5].Font.Bold = true;
                }
            }
        }
    }
    private void FillGrid()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
        dsSched = gen.getCorrDet(ar);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdvCalcCorr.DataSource = dsSched;
            gdvCalcCorr.DataBind();
            
        }
    }
    protected void btnBulkSelection_Click(object sender, EventArgs e)
    {
        btnBulk.Enabled = true;
        btnBulkMltplYr.Enabled = true;
        empDao.Select_Employee_Temp();
        gblObj.MsgBoxOk("finished!!!", this);
        btnBulkSelection.Enabled = false;
    }
    protected void btnBulkMltplYr_Click(object sender, EventArgs e)
    {
        DataSet dsEmp = new DataSet();
        dsEmp = empDao.GetEmp4BulcCalcGroup();
        if (dsEmp.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
            {
                DeleteFromLedgerSingle(Convert.ToInt32(dsEmp.Tables[0].Rows[0].ItemArray[0]));
                CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]),52);
            }
        }
        gblObj.MsgBoxOk("Updated!", this);
    }

    protected void txtAccNoP_TextChanged(object sender, EventArgs e)
    {
        if (txtAccNoP.Text == "" || txtAccNoP.Text == null)
        {
            gblObj.MsgBoxOk("Enter Acc No.", this);
        }
        else
        {
            Session["intAccNo"] = Convert.ToInt32(txtAccNoP.Text);
        }
    }
    protected void ddlYr_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYr.SelectedIndex > 0)
        {
            Session["intYearSC"] = Convert.ToInt16(ddlYr.SelectedValue);
        }
        else
        {
            Session["intYearSC"] = 0;
        }
    }
}
