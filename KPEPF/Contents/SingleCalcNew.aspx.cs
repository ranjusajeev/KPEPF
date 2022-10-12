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

public partial class Contents_SingleCalcNew : System.Web.UI.Page
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
    LedgerM ldgr;
    LedgerY ldgrY;

    LedgerYDao ldgrD = new LedgerYDao();
    LedgerMDao ldgrDao = new LedgerMDao();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlSanction.Visible = true;
            pnlCorrCalc.Visible = true;
            FillYr();
            setCtrls();
            //Ranjitha on 02112020
            DataSet dsAdmin = new DataSet();
            dsAdmin = crrD.GetAdminSettings();
            if (dsAdmin.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(dsAdmin.Tables[0].Rows[0].ItemArray[0]) == 1)
                {
                    btnCorrThisYear.Visible = true;
                }
                else
                {
                    btnCorrThisYear.Visible = false;
                }
            }
            //end
        }
    }
    private void setCtrls()
    {
        //btnGrp.Visible = true;
        rdCategory.Visible = true;
        if (Convert.ToInt16(Session["intUserTypeId"]) == 6)
        {
            rdCategory.Visible = false;
            btnGrp.Visible = false;
            //btnLWACalc.Visible = false;
        }
    }
    private void updateYearDetForCorrectionAmount(Int32 accno,int yr)
    {
        ArrayList ar = new ArrayList();
        ar.Add(accno);
        ar.Add(yr);
        ldgrD.updateYearDetForCorrectionAmount(ar);
    }
    protected void btnBulkNew_Click(object sender, EventArgs e)
    {
        // Calculate corr. entry from starting year and update the last card issued with the correction amount.....
        ArrayList arl = new ArrayList();
        Session["intYrCal"] = gen.GetCCYearId();
        if (txtAccNoP.Text == "" || txtAccNoP.Text == null || Convert.ToInt16(Session["intYearSC"]) == 0)
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            if (Convert.ToInt32(txtAccNoP.Text) > 0)
            {
                for (int i = Convert.ToInt16(Session["intYearSC"]); i <= Convert.ToInt16(Session["intYrCal"]) + 1; i++)
                {
                    ArrayList ar = new ArrayList();
                    updateYearDetForCorrectionAmount(Convert.ToInt32(txtAccNoP.Text), i);
                    ar.Add(Convert.ToInt32(txtAccNoP.Text));
                    ar.Add(i);
                    crrD.DelCorrEntry(ar);
                }

                saveCorr(Convert.ToInt16(Session["intYrCal"]) + 1);
                //saveCurrYear(Convert.ToInt16(Session["intYrCal"]) + 1);
                //arl.Add(Convert.ToInt32(txtAccNoP.Text));
                //ldgrD.UpdateYearDet4GenerateCardNew(arl);
                gblObj.MsgBoxOk("Updated!", this);
            }
            else
            {
                gblObj.MsgBoxOk("Enter Employee!", this);
            }
        }
    }

    private void saveCorr(int yr)
    {
        /////////// Delete from Corr ////////////////
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt32(txtAccNoP.Text));
        //ar.Add(yr);
        //crrD.DelCorrEntry(ar);
        /////////// Delete from Corr ////////////////

        gdvS.Visible = true;
        FillGridnS(yr);
    }
    protected void btnCorrThisYear_Click(object sender, EventArgs e)
    {
        // Calculate corr. entry from starting year and update the last card issued with the correction amount.....
        ArrayList arl = new ArrayList();
        Session["intYrCal"] = gen.GetCCYearId();
        if (txtAccNoP.Text == "" || txtAccNoP.Text == null || Convert.ToInt16(Session["intYearSC"]) == 0)
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            if (Convert.ToInt32(txtAccNoP.Text) > 0)
            {
                /* // Ranjitha
                for (int i = Convert.ToInt16(Session["intYearSC"]); i <= Convert.ToInt16(Session["intYrCal"]) + 1; i++)
                {
                    ArrayList ar = new ArrayList();
                    updateYearDetForCorrectionAmount(Convert.ToInt32(txtAccNoP.Text), i);
                    ar.Add(Convert.ToInt32(txtAccNoP.Text));
                    ar.Add(i);
                    crrD.DelCorrEntry(ar);
                }
                */
                ArrayList ar = new ArrayList();
                updateYearDetForCorrectionAmount(Convert.ToInt32(txtAccNoP.Text), Convert.ToInt16(Session["intYrCal"]));
                ar.Add(Convert.ToInt32(txtAccNoP.Text));
                ar.Add(Convert.ToInt16(Session["intYrCal"]));
                crrD.DelCorrEntry(ar);

                //  saveCorr(Convert.ToInt16(Session["intYrCal"]) + 1); // Ranjitha

                saveCorr_New(Convert.ToInt16(Session["intYrCal"])); // Ranjitha
                //saveCurrYear(Convert.ToInt16(Session["intYrCal"]) + 1);
                //arl.Add(Convert.ToInt32(txtAccNoP.Text));
                //ldgrD.UpdateYearDet4GenerateCardNew(arl);
                gblObj.MsgBoxOk("Updated!", this);
            }
            else
            {
                gblObj.MsgBoxOk("Enter Employee!", this);
            }
        }
    }

    //Ranjitha
    private void saveCorr_New(int yr)
    {
        /////////// Delete from Corr ////////////////
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt32(txtAccNoP.Text));
        //ar.Add(yr);
        //crrD.DelCorrEntry(ar);
        /////////// Delete from Corr ////////////////

        gdvS.Visible = true;
        FillGridnS_New(yr);
    }

    //Ranjitha

    private void FillGridnS_New(int yr)
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(txtAccNoP.Text));
        ar.Add(yr);
        dsSched = crrD.GetCorrectionEntryDetNwLat_New(ar);
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
                int intSchedId = 0;
                int intChalType = 0;
                int intCorrTpe = 0;
                int intYrId = 0;

                intYrId = Convert.ToInt16(gdvS.Rows[i].Cells[2].Text);
                intMth = Convert.ToInt16(gdvS.Rows[i].Cells[3].Text);
                intDy = Convert.ToInt16(gdvS.Rows[i].Cells[4].Text);
                dblAmt = Convert.ToDouble(gdvS.Rows[i].Cells[5].Text);
                tp = Convert.ToInt16(gdvS.Rows[i].Cells[8].Text);
                intChalanId = Convert.ToInt32(gdvS.Rows[i].Cells[9].Text);
                intSchedId = Convert.ToInt32(gdvS.Rows[i].Cells[11].Text);
                intChalType = Convert.ToInt32(gdvS.Rows[i].Cells[12].Text);
                if (Convert.ToInt16(gdvS.Rows[i].Cells[6].Text) == 1)
                {
                    dblAmt = -dblAmt;
                }
                dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intYrCal"]) + 1, intMth, intDy, dblAmt);

                Label lblAmt = (Label)gvr.FindControl("lblAmt");
                lblAmt.Text = dblCalcAmt.ToString();
                intCorrTpe = Convert.ToInt16(gdvS.Rows[i].Cells[10].Text);
                SaveCorrectionEntry(Convert.ToInt32(gdvS.Rows[i].Cells[1].Text), intChalanId, intYrId, intMth, intDy, dblCalcAmt, intSchedId, intCorrTpe, dblAmt, dblAmt, intChalType, tp);
                //gblObj.MsgBoxOk("Ok!!!", this);
                ///////////////////////////////////////////////////
            }
        }
    }

    private void saveCorrGrp(Int32 intAcc, int yr)
    {
        /////////// Delete from Corr ////////////////
        ArrayList ar = new ArrayList();
        ar.Add(intAcc);
        ar.Add(yr);
        crrD.DelCorrEntry(ar);
        /////////// Delete from Corr ////////////////

        gdvS.Visible = true;
        FillGridnSGrp(intAcc,yr);
    }
    private void saveCurrYear(int yr)
    {
        DeleteFromLedgerSingleYr(Convert.ToInt32(txtAccNoP.Text), yr);
        CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(Convert.ToInt32(txtAccNoP.Text), yr);
    }
    private void saveCurrYearGrp(Int32 intAcc, int yr)
    {
        DeleteFromLedgerSingleYr(intAcc, yr);
        CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(intAcc, yr);
    }
    private void CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(Int32 accNo,int yr)
    {
        double dblTotRem = 0;
        double dblTotWith = 0;
        int chgCnt = 0;
        DataSet dsEmp = new DataSet();
        ldgrY = new LedgerY();
        ldgr = new LedgerM();
        double dblTotAmtWithBlockCalcP = 0;

        ldgrY.IntAccNo = accNo;
        ldgrY.DblOB = FindOBBulk(ldgrY.IntAccNo, yr - 1);
        CalcMonthlyAmtsSingle(ldgrY.IntAccNo, yr);
        DeleteFromLedger(yr);
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

                        CalcMonthlyAmtsBulk4MltplRt(ldgrY.IntAccNo, intMthCnt, intStMth, intEndMth, j, Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[4]) - 1, yr);
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
                ldgrY.DblTotRemAmt = dblTotRem;
                ldgrY.DblTotWithAmt = dblTotWith;
                ldgrY.DblRemOBIntAmt = ldgrY.DblRemOBIntAmt + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt;
                ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
                //FillConsBoxBulkMltplIntRt();
            }
            SaveYearlyAmtsSingle(0, yr);
        }
        else
        {
            chgCnt = gen.NoOfTimesIntRtChgd(yr);
            if (chgCnt == 1)
            {
                ldgrY.DblIntRate = gblObj.RateOfInterest(yr);
                FillConsBoxBulk();  //Calc interest
                SaveYearlyAmtsSingle(1, yr);
            }
            else
            {
                int intMthCnt = 0;
                DataSet dsRt = new DataSet();
                dsRt = gen.GetDet4MltplRt(yr);
                for (int j = 0; j < chgCnt; j++)
                {
                    if (dsRt.Tables[0].Rows.Count > 0)
                    {
                        ldgrY.DblIntRate = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
                        intMthCnt = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
                        ldgrY.DblTotOB = ldgrY.DblOB * intMthCnt;
                    }
                    ldgrY.DblIntAmt = ldgrY.DblIntAmt + (ldgrY.DblTotOB) * ldgrY.DblIntRate / 1200;
                }
                ldgrY.DblTotRemAmt = 0;
                ldgrY.DblTotWithAmt = 0;
                ldgrY.DblRemOBIntAmt = 0 + ldgrY.DblOB + ldgrY.DblIntAmt;
                ldgrY.DblCB = ldgrY.DblCB + ldgrY.DblOB + ldgrY.DblTotRemAmt + ldgrY.DblIntAmt - ldgrY.DblTotWithAmt;
                SaveYearlyAmtsSingle(1, yr);
            }
        }
    }
    private void DeleteFromLedgerSingleYr(Int32 accNo,int yr)
    {
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(accNo);
        arL.Add(yr);
        ldgrD.DelLedgerYearlySingleYrwise(arL);
    }

    private void DeleteFromLedger(int yr)
    {
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(Convert.ToInt32(Session["intAccNo"]));
        arL.Add(yr);
        ldgrD.DelLedgerYearly(arL);
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
        ldgrD.SaveLedgerYg(ary);
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
    private void CalcMonthlyAmtsBulk4MltplRt(int accno,int cnt, int intStMth, int intEndMth,int flg,int rw,int yr)
    {
        int j = 0, k = 0 ; //, mid1=0, mid2=0;
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

                //if (ldgr.DblWithAmt[i] > 0)
                //{
                ldgrY.DblTotAmtWithBlockSingle = ldgrY.DblTotAmtWithBlockSingle + ldgr.DblWithAmt[i];
                ldgrY.DblTotAmtWithBlockCalc = ldgrY.DblTotAmtWithBlockCalc + ldgrY.DblTotAmtWithBlockSingle;
                //}
                //if (ldgr.DblWithAmt[i] > 0)
                //{

                //    if (flg == 0)   // first loop ie. j=1
                //    {
                //        Session["wAmt1"] = Convert.ToDouble(ldgr.DblWithAmt[i]);
                //        if (k == 0)      // first block
                //        {
                //            mid1 = cnt - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;                           
                //        }
                //        else                 // second block
                //        {
                //            mid1 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
                //        }
                //    }
                //    else          // second loop ie. j=2
                //    {
                //        Session["wAmt2"] = Convert.ToDouble(ldgr.DblWithAmt[i]);
                //        if (k == 0)
                //        {
                //            mid2 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
                //        }
                //        else
                //        {
                //            mid2 = 12 - gen.GetMonthIdFromID(Convert.ToInt16(ldgr.IntMId[i])) + 1;
                //        }
                //    }
                //    k = k + 1;
                //}

                //if (mid1 > 0)
                //{
                //    Session["wAmt14Int1"] = Convert.ToDouble(Session["wAmt1"]) * mid1;
                //    //double a1 = Convert.ToDouble(Session["wAmt14Int1"]);
                //}
                //else
                //{
                //    Session["wAmt14Int1"] = Convert.ToDouble(Session["wAmt1"]) * cnt;
                //    //double a1 = Convert.ToDouble(Session["wAmt14Int1"]);
                //}
                //if (mid2 > 0)
                //{
                //    Session["wAmt14Int2"] = Convert.ToDouble(Session["wAmt2"]) * mid2;
                //    //double a2 = Convert.ToDouble(Session["wAmt14Int2"]);
                //}
                //else
                //{
                //    Session["wAmt14Int2"] = Convert.ToDouble(Session["wAmt2"]) * (12 - cnt);
                //    //double a2 = Convert.ToDouble(Session["wAmt14Int2"]);
                //}
                //ldgrY.FlgNonTrans = 0;
                //ldgrY.DblCorrEntryAmt = 0;
            }
            
            //ldgrY.DblTotWithAmtForInt = Convert.ToDouble(Session["wAmt14Int1"]) + Convert.ToDouble(Session["wAmt14Int2"]);
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
    private void DeleteYearly()
    {
        ArrayList ar = new ArrayList();
        Session["intYrCal"] = gen.GetCCYearId();
        ar.Add(Convert.ToInt16(Session["intYrCal"]));
        ldgrD.DelLedgerYearlyBulk(ar);

    }
    private int CalculateBalMonths(int mid)
    {
        int intMonthId = 0;
        int mths = 0;
        intMonthId = gen.GetMonthIdFromID(Convert.ToInt16(Session["mDoc"]));
        mths = intMonthId - mid + 1;
        return mths;
    }
    private void FillYr()
    {
        DataSet dsy = new DataSet();
        dsy = kgen.GetYearOnLine();
        gblObj.FillCombo(ddlYr, dsy, 1);
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
        ar.Add("intTblTp");
        ar.Add("intLBId");
        
        gblObj.SetGridDefault(gdvS, ar);
        gdvS.Enabled = false;
    }
    private void FillGridnS(int yr)
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(txtAccNoP.Text));
        ar.Add(yr);
        dsSched = crrD.GetCorrectionEntryDetNwLat(ar);
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
                int intSchedId = 0;
                int intChalType = 0;
                int intCorrTpe = 0;
                int intYrId = 0;

                intYrId = Convert.ToInt16(gdvS.Rows[i].Cells[2].Text);
                intMth = Convert.ToInt16(gdvS.Rows[i].Cells[3].Text);
                intDy = Convert.ToInt16(gdvS.Rows[i].Cells[4].Text);
                dblAmt = Convert.ToDouble(gdvS.Rows[i].Cells[5].Text);
                tp = Convert.ToInt16(gdvS.Rows[i].Cells[8].Text);
                intChalanId = Convert.ToInt32(gdvS.Rows[i].Cells[9].Text);
                intSchedId = Convert.ToInt32(gdvS.Rows[i].Cells[11].Text);
                intChalType = Convert.ToInt32(gdvS.Rows[i].Cells[12].Text);
                if (Convert.ToInt16(gdvS.Rows[i].Cells[6].Text) == 1)
                {
                    dblAmt = -dblAmt;
                }
                dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intYrCal"]) + 1, intMth, intDy, dblAmt);

                Label lblAmt = (Label)gvr.FindControl("lblAmt");
                lblAmt.Text = dblCalcAmt.ToString();
                intCorrTpe = Convert.ToInt16(gdvS.Rows[i].Cells[10].Text);
                SaveCorrectionEntry(Convert.ToInt32(gdvS.Rows[i].Cells[1].Text), intChalanId, intYrId, intMth, intDy, dblCalcAmt, intSchedId, intCorrTpe, dblAmt, dblAmt, intChalType, tp);
                //gblObj.MsgBoxOk("Ok!!!", this);
                ///////////////////////////////////////////////////
            }
        }
    }
    private void FillGridnSGrp(Int32 accno, int yr)
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        //Session["intYearCalcCorr"] = gen.GetCCYearId();
        //ar.Add(Convert.ToDouble(Session["numEmpIdLedger"]));
        ar.Add(accno);
        ar.Add(yr);
        //dsSched = gen.getCorrDetnS(ar);
        //GetCorrectionEntryDetNwLat
        dsSched = crrD.GetCorrectionEntryDetNwLat(ar);
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
                //gblObj.MsgBoxOk("Ok!!!", this);
                ///////////////////////////////////////////////////
            }
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
        crr.IntYearIDCorrected = Convert.ToInt16(Session["intYrCal"]) + 1;
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
        if (yr < 50)
        {
            crr.IntTblTp = 1;
        }
        else
        {
            crr.IntTblTp = 2;
        }
        crrD.CreateCorrEntryCalcTblTp(crr);

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
    private void saveCorrg(Int32 accno, int yr)
    {
        /////////// Delete from Corr ////////////////
        ArrayList ar = new ArrayList();
        ar.Add(accno);
        ar.Add(yr);
        crrD.DelCorrEntry(ar);
        /////////// Delete from Corr ////////////////
        FillGridnSg(accno, yr);
    }
    private void FillGridnSg(Int32 accno, int yr)
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        //Session["intYearCalcCorr"] = gen.GetCCYearId();
        //ar.Add(Convert.ToDouble(Session["numEmpIdLedger"]));
        ar.Add(accno);
        ar.Add(yr);
        //dsSched = gen.getCorrDetnS(ar);
        //GetCorrectionEntryDetNwLat
        dsSched = crrD.GetCorrectionEntryDetNwLat(ar);
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
                //gblObj.MsgBoxOk("Ok!!!", this);
                ///////////////////////////////////////////////////
            }
        }
    }
    private void delLedger(Int32 accno,int yr)
    {
        ArrayList ary = new ArrayList();
        ary.Add(accno);
        ary.Add(yr);
        ldgrD.DelLedgerYearlySingleYrwise(ary);
    }
    protected void btnGrp_Click(object sender, EventArgs e)
    {
        //ArrayList arl = new ArrayList();
        //ArrayList ar = new ArrayList();

        //for (int j = 0; j <= gdvg.Rows.Count - 1; j++)
        //{

        //    ar.Add(Convert.ToInt32(gdvg.Rows[j].Cells[0].Text));
        //    ar.Add(Convert.ToInt16(gdvg.Rows[j].Cells[1].Text));
        //    crrD.DelCorrEntry(ar);
        //    //delLedger(Convert.ToInt32(txtAccNoP.Text), Convert.ToInt16(Session["intYearSC"]));
        //    ldgrD.DelLedgerYearlySingleYrwise(ar);
        //    saveCorrGrp(Convert.ToInt16(gdvg.Rows[j].Cells[0].Text),Convert.ToInt16(gdvg.Rows[j].Cells[1].Text));
        //    saveCurrYearGrp(Convert.ToInt16(gdvg.Rows[j].Cells[0].Text),Convert.ToInt16(gdvg.Rows[j].Cells[1].Text));
        //    arl.Add(Convert.ToInt16(gdvg.Rows[j].Cells[0].Text));
        //    ldgrD.UpdateYearDet4GenerateCardNew(arl);
        //    ldgrD.updCalGrp(ar);
        //    ar.Clear();
        //    arl.Clear();
        //    gblObj.MsgBoxOk("Updated!", this);
        //}

    }
    //private void setMode4()
    //{
    //    crrD.UpdWithdrawalsMode4();
    //}
    private void saveCurrYearg(Int32 accno, int yr)
    {
        DeleteFromLedgerSingleYr(accno, yr);
        CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(accno, yr);
    }
    protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdCategory.Items[0].Selected == true)
        {
            pnlSanction.Visible = true;
            pnlGrp.Visible = false;
        }
        else
        {
            pnlSanction.Visible = false;
            pnlGrp.Visible = true;
            FillGridnG();
        }
    }
    private void FillGridnG()
    {
        DataSet dsg = new DataSet();
        dsg = gen.getCalcGroup();
        if (dsg.Tables[0].Rows.Count > 0)
        {
            gdvg.DataSource = dsg;
            gdvg.DataBind();
        }
        else
        {
            btnGrp.Enabled = false;
            gblObj.MsgBoxOk("Nothing to update", this);
        }
    }
    protected void ddlYrGrp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLWACalc_Click(object sender, EventArgs e)
    {
        // Realculate cards from starting year upto currrent year without any corr. entry.....
        ArrayList arl = new ArrayList();
        ArrayList ar = new ArrayList();
        Session["intYrCal"] = gen.GetCCYearId();
        if (txtAccNoP.Text == "" || txtAccNoP.Text == null || Convert.ToInt16(Session["intYearSC"]) == 0)
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            if (Convert.ToInt16(txtAccNoP.Text) > 0)
            {
                for (int i = Convert.ToInt16(Session["intYearSC"]); i <= Convert.ToInt16(Session["intYrCal"]); i++)
                {
                    DeleteFromLedgerSingleYr(Convert.ToInt32(txtAccNoP.Text), i);
                    CalcCurrentYearToLedgerMthlyAndLedgerYearlySingle(Convert.ToInt32(txtAccNoP.Text), i);
                    ar.Add(Convert.ToInt32(txtAccNoP.Text));
                    ar.Add(i);
                    crrD.DelCorrEntry(ar);
                    ar.Clear();
                }
                saveCorr(Convert.ToInt16(Session["intYrCal"]));
                saveCurrYear(Convert.ToInt16(Session["intYrCal"]));
                arl.Add(Convert.ToInt32(txtAccNoP.Text));
                ldgrD.UpdateYearDet4GenerateCardNew(arl);
                gblObj.MsgBoxOk("Updated!", this);
            }
            else
            {
                gblObj.MsgBoxOk("Enter Employee!", this);
            }
        }
    }
}
