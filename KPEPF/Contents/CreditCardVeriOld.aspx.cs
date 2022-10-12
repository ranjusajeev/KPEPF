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
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KPEPFClassLibrary;


public partial class Contents_CreditCardVeri : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    GeneralDAO gen;
    Employee emp;
    EmployeeDAO empDao;

    CorrectionEntry crr;
    CorrectionEntryDao crrD;
    LedgerMDao ldgrD;
    CreditCardDao ccDao;

    OBDao obd;
    //LedgerYDao ldgrDao = new LedgerYDao();
    //CorrectionEntry crr = new CorrectionEntry();
    //CorrectionEntryDao crrD = new CorrectionEntryDao();
    //static string accno = "";
    //static string ename = "";
    //static int flgEmp = 0;
    //static int flgTrn = 0;
    //static int tt = 0;
    //static int balmnth;
    protected void Page_Load(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        Session["flgPageBack"] = 10;
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = gen.GetYearRem();
            gblObj.FillCombo(ddlYear, ds, 1);
            SetGridDefault(1);
            SetGridDefault(2);
            Session["intYearIdLedger"] = 50;
            //gblObj.GetSessionValsByCheck(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //if (Convert.ToInt16(Session["intTrnType"]) == 40)
            //{
            //    lblHead.Text = "Credit Card";
            //    btnLedger.Text = "Credit Card";

            //}
            //else
            //{
            //    lblHead.Text = "Ledger";
            //    btnLedger.Text = "Ledger";

            //}
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["intYearIdLedger"] = int.Parse(ddlYear.SelectedValue.ToString());
            gdvSerHis.Visible = false;
            if (Convert.ToInt16(Session["intYearIdLedger"]) < 50)
            {
                FillGrid1(1);
                FillGrid2(1);
                SetMisMatch(1);
            }
            else
            {
                FillGrid1(2);
                FillGrid2(2);
                SetMisMatch(2);
                //if (Convert.ToInt16(Session["intYearIdLedger"]) == 51)
                //{
                //    FillNewGrid();
                //}
            }
        }
        else
        {
            Session["intYearIdLedger"] = 0;
        }

    }
    private void FillNewGrid()
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        crrD = new CorrectionEntryDao();

        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numEmpIdLedger"]));
        ar.Add(Convert.ToInt16(Session["intYearIdLedger"]));

        dsC = crrD.GetCorrectionEntryDet51(ar);

        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvSerHis.DataSource = dsC;
            gdvSerHis.DataBind();
            gdvSerHis.Visible = true;
        }
        else
        {
            SetGridDefault51();
        }
    }
    private void SetGridDefault51()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvYear");
        ar.Add("chvMonth");
        ar.Add("chvTp");
        ar.Add("fltAmountBefore");
        ar.Add("fltCalcAmount");

        gblObj.SetGridDefault(gdvSerHis, ar);
    }
    private void SetMisMatch(int tp)
    {
        double amt = 0;
        double amt1 = 0;
        double amt2 = 0;
        double amt3 = 0;
        double amt4 = 0;

        amt1 = Convert.ToDouble(gdvCorrPrev.FooterRow.Cells[5].Text);
        amt3 = Convert.ToDouble(gdvCorrPrev.FooterRow.Cells[6].Text);
        if (tp == 1)
        {
            amt2 = Convert.ToDouble(gdvCorr.FooterRow.Cells[5].Text);
            amt4 = Convert.ToDouble(gdvCorr.FooterRow.Cells[6].Text);
        }
        else
        {
            amt2 = Convert.ToDouble(gdvAnnStmnt.FooterRow.Cells[5].Text);
            amt4 = Convert.ToDouble(gdvAnnStmnt.FooterRow.Cells[6].Text);
        }
        if (amt1 != amt2 && amt3 != amt4)
        {
            lblMisMatch.Text = "Mismatch --- Both";
        }
        else if (amt1 != amt2 && amt3 == amt4)
        {
            amt = amt2 - amt1;
            lblMisMatch.Text = "Mismatch --- Rem " + "  " + amt.ToString();
        }
        else if (amt1 == amt2 && amt3 != amt4)
        {
            amt = amt4 - amt3;
            lblMisMatch.Text = "Mismatch --- Withdrawal " + "  " + amt.ToString();
        }
        else if (Convert.ToDouble(txtOb.Text) != findOBCurr() && Convert.ToInt16(Session["intYearIdLedger"]) == 37)
        {
            amt = findOBCurr() - Convert.ToDouble(txtOb.Text);
            lblMisMatch.Text = "Mismatch --- OB " + "  " + amt.ToString();
        }
        else
        {
            lblMisMatch.Text = "";
        }
    }

    //private void SetMisMatch(int tp)
    //{
    //    double amt = 0;

    //    double amt1 = 0;
    //    double amt2 = 0;
    //    double amt3 = 0;
    //    double amt4 = 0;

    //    amt1 = Convert.ToDouble(gdvCorrPrev.FooterRow.Cells[5].Text);
    //    amt3 = Convert.ToDouble(gdvCorrPrev.FooterRow.Cells[6].Text);
    //    if (tp == 1)
    //    {
    //        amt2 = Convert.ToDouble(gdvCorr.FooterRow.Cells[5].Text);
    //        amt4 = Convert.ToDouble(gdvCorr.FooterRow.Cells[6].Text);
    //    }
    //    else
    //    {
    //        amt2 = Convert.ToDouble(gdvAnnStmnt.FooterRow.Cells[5].Text);
    //        amt4 = Convert.ToDouble(gdvAnnStmnt.FooterRow.Cells[6].Text);
    //    }
        

    //    if (amt1 != amt2 && amt3 != amt4)
    //    {
    //        lblMisMatch.Text = "Mismatch --- Both";
    //    }
    //    else if (amt1 != amt2 && amt3 == amt4)
    //    {
    //        amt = amt2 - amt1;
    //        lblMisMatch.Text = "Mismatch --- Rem " + "  " + amt.ToString();
    //    }
    //    else if (amt1 == amt2 && amt3 != amt4)
    //    {
    //        amt = amt4 - amt3;
    //        lblMisMatch.Text = "Mismatch --- Withdrawal " + "  " + amt.ToString();
    //    }
    //    else if (Convert.ToDouble(txtOb.Text) != findOBCurr() && Convert.ToInt16(Session["intYearIdLedger"]) == 37)
    //    {
    //        amt = findOBCurr() - Convert.ToDouble(txtOb.Text);
    //        lblMisMatch.Text = "Mismatch --- OB " + "  " + amt.ToString();
    //    }
    //    else
    //    {
    //        lblMisMatch.Text = "";
    //    }
    //}
    private double findOBCurr()
    {
        obd = new OBDao();
        double amt = 0;
        DataSet dso = new DataSet();
        ArrayList ar=new ArrayList();
        ar.Add(Convert.ToInt32(Session["numEmpIdLedger"]));
        dso = obd.GetObSingleCalc(ar);
        if (dso.Tables[0].Rows.Count > 0)
        {
            amt = Convert.ToDouble(dso.Tables[0].Rows[0].ItemArray[0]);
        }
        return amt;
    }
    private void FillGrid1(int intCurrYr)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numEmpIdLedger"]));
        ar.Add(Convert.ToInt16(Session["intYearIdLedger"]));
        if (intCurrYr == 1)
        {
            dsC = gen.CCard(ar);
        }
        else
        {
            dsC = gen.CCardNew(ar);
        }
        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvCorrPrev.DataSource = dsC;
            gdvCorrPrev.DataBind();
            for (int i = 0; i < gdvCorrPrev.Rows.Count; i++)
            {
                GridViewRow gvr = gdvCorrPrev.Rows[i];
                gvr.Cells[1].ToolTip = dsC.Tables[0].Rows[i].ItemArray[13].ToString() + " (" + dsC.Tables[0].Rows[i].ItemArray[25].ToString() + " )";

            }
        }
        else
        {
            SetGridDefault(1);
        }
        gblObj.SetFooterTotals(gdvCorrPrev, 5);
        gblObj.SetFooterTotals(gdvCorrPrev, 6);
        FillTxts1(dsC);
    }
    private void FillGrid2(int intCurrYr)
    {
        
        gen = new GeneralDAO();
        ldgrD=new LedgerMDao();
        ccDao = new CreditCardDao();
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numEmpIdLedger"]));
        ar.Add(Convert.ToInt16(Session["intYearIdLedger"]));
        if (intCurrYr == 1)
        {
            gdvAnnStmnt.Visible = false;
            gdvCorr.Visible = true ;
            dsC = ccDao.GetCreditCardVerified(ar);
            
            if (dsC.Tables[0].Rows.Count > 0)
            {
                gdvCorr.DataSource = dsC;
                gdvCorr.DataBind();

                for (int i = 0; i < gdvCorr.Rows.Count; i++)
                {
                    GridViewRow gvr = gdvCorr.Rows[i];
                    Label lblArrearP = (Label)gvr.FindControl("lblArrearP");
                    if (String.IsNullOrEmpty(dsC.Tables[0].Rows[i].ItemArray[6].ToString()) || String.IsNullOrEmpty(dsC.Tables[0].Rows[i].ItemArray[7].ToString()) || String.IsNullOrEmpty(dsC.Tables[0].Rows[i].ItemArray[8].ToString()))
                    {
                       // lblArrearP.Text = (Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[4]) + Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[5]) + Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[6])).ToString();
                    }
                    else
                    {
                        lblArrearP.Text = (Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[6]) + Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[7]) + Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[8])).ToString();
                    }
                }
            }
            else
            {
                SetGridDefault(2);
            }
            gblObj.SetFooterTotals(gdvCorr, 5);
            gblObj.SetFooterTotals(gdvCorr, 6);
            gdvAnnStmnt.Visible = false;
        }
        else
        {
            gdvAnnStmnt.Visible = true;
            gdvCorr.Visible = false;
            dsC = ldgrD.AnnStmnt(ar);
            if (dsC.Tables[0].Rows.Count > 0)
            {
                gdvAnnStmnt.DataSource = dsC;
                gdvAnnStmnt.DataBind();
                for (int i = 0; i < gdvAnnStmnt.Rows.Count; i++)
                {
                    GridViewRow gvr = gdvAnnStmnt.Rows[i];

                    Label lblArrear = (Label)gvr.FindControl("lblArrear");
                    if (String.IsNullOrEmpty(dsC.Tables[0].Rows[i].ItemArray[4].ToString()) || String.IsNullOrEmpty(dsC.Tables[0].Rows[i].ItemArray[5].ToString()) || String.IsNullOrEmpty(dsC.Tables[0].Rows[i].ItemArray[6].ToString()))
                    {
                        lblArrear.Text = "";
                    }
                    else
                    {
                        lblArrear.Text = (Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[4]) + Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[5]) + Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[6])).ToString();
                    }
                }
            }
            else
            {
                SetGridDefaultAnn();
            }
            gblObj.SetFooterTotals(gdvAnnStmnt, 5);
            gblObj.SetFooterTotals(gdvAnnStmnt, 6);
        }
        
        
    }
    private void FillGrid3()
    {
        gen = new GeneralDAO();
        crrD = new CorrectionEntryDao();
        emp = new Employee();
        DataSet dsC = new DataSet();
        emp.NumEmpID = Convert.ToInt64(Session["numEmpIdLedger"]);
        dsC = crrD.GetCorrectionEntryDet(emp);
        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvCons.DataSource = dsC;
            gdvCons.DataBind();
            for (int i = 0; i < gdvCons.Rows.Count; i++)
            {
                GridViewRow gvr = gdvCons.Rows[i];
                Label lblSlNo = (Label)gvr.FindControl("lblSlNo");
                lblSlNo.Text = (i+1).ToString();
            }
            gblObj.SetFooterTotals(gdvCons, 10);
        }
        else
        {
            SetGridDefault(3);
        }
    }
    private void SetGridDefault(int tp)
    {        
        if (tp == 1)
        {
            ArrayList ar = new ArrayList();
            ar.Add("SlNo");
            ar.Add("chvMonth");
            ar.Add("dtChalDate");
            ar.Add("numChalanId");
            ar.Add("SubnAmt");
            ar.Add("RefAmt");
            ar.Add("ArreatAmt");
            ar.Add("RemTotal");
            ar.Add("WihtAmt");
            ar.Add("LBName");
            ar.Add("fltCorrEntryAmt");
            gblObj.SetGridDefault(gdvCorrPrev, ar);
        } 
        else if (tp == 2)
        {
            ArrayList ar2 = new ArrayList();
            ar2.Add("SlNo");
            ar2.Add("chvMonth");
            ar2.Add("CDate");
            ar2.Add("MsAmt");
            ar2.Add("RfAmt");
            ar2.Add("DaAmt");
            ar2.Add("RemAmt");
            ar2.Add("Withdrawal");
            ar2.Add("chvEngLBName");
            ar2.Add("numChalanId");
            
            gblObj.SetGridDefault(gdvCorr, ar2);
        }
        else
        {
            ArrayList ar3 = new ArrayList();
            ar3.Add("chvType");
            ar3.Add("chvYear");
            ar3.Add("chvMonth");
            ar3.Add("chvEngDistName");
            ar3.Add("chvCorrType");
            
            ar3.Add("LBName");
            ar3.Add("dtmchalan");
            ar3.Add("fltAmountBefore");
            ar3.Add("fltChalanAmt");
            ar3.Add("fltCalcAmount");

            gblObj.SetGridDefault(gdvCons, ar3);
        }
    }
    private void SetGridDefaultAnn()
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
    //private Boolean CorrectionExistsPrev(Int32 empID)
    //{
    //    Boolean flg = true;
    //    DataSet dsCg = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(empID);
    //    crr.IntAccNo = empID;
    //    dsCg = crrD.CheckCorrectionEntry4CardGenPrev(crr);
    //    if (dsCg.Tables[0].Rows.Count > 0)
    //    {
    //        if (Convert.ToInt32(dsCg.Tables[0].Rows[0].ItemArray[0]) != 0)
    //        {
    //            flg = true;
    //        }
    //        else
    //        {
    //            flg = false;
    //        }
    //    }
    //    else
    //    {
    //        flg = false;
    //    }
    //    return flg;
    //}

    //private Boolean CorrectionExists(Int32 empID)
    //{
    //    Boolean flg = true;
    //    DataSet dsCg = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(empID);
    //    crr.IntAccNo = empID;
    //    dsCg = crrD.CheckCorrectionEntry4CardGen(crr);
    //    if (dsCg.Tables[0].Rows.Count > 0)
    //    {
    //        if (Convert.ToInt16(dsCg.Tables[0].Rows[0].ItemArray[0]) > 0)
    //        {
    //            flg = true;
    //        }
    //        else
    //        {
    //            flg = false;
    //        }
    //    }
    //    else
    //    {
    //        flg = false;
    //    }
    //    return flg;
    //}
    protected void tctAccNo_TextChanged(object sender, EventArgs e)
    {

        if (Convert.ToInt32(tctAccNo.Text) > 0)
        {
            Session["intCnt"] = 0;
            Session["numEmpIdLedger"] = Convert.ToInt32(tctAccNo.Text);
            FillNameAccNo();
            ddlYear.SelectedValue = "0";
            ClearTxts(1);
            SetGridDefault(1);
            SetGridDefault(2);
        }
        else
        {
            gblObj.MsgBoxOk("Enter Acc. No.!", this);
        }

    }
    private void FillNameAccNo()
    {
        emp = new Employee();
        empDao = new EmployeeDAO();
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(tctAccNo.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblClosed.Text = dsN.Tables[0].Rows[0].ItemArray[9].ToString();
            lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
            lblDistName.Text = dsN.Tables[0].Rows[0].ItemArray[8].ToString();
        }
        //else
        //{
        //    lblClosed.Text = "";
        //}
    }

    protected void btnLedger_Click(object sender, EventArgs e)
    {
        crrD = new CorrectionEntryDao();

        Session["intYearCalcCorr"] = gen.GetCCYearId();
        /////////// Delete from Corr ////////////////
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToDouble(Session["numEmpIdLedger"]));
        ar.Add(Convert.ToInt16(Session["intYearCalcCorr"]));
        crrD.DelCorrEntry(ar);
        /////////// Delete from Corr ////////////////

        gdvS.Visible = true;
        FillGridnS();

        

        ////gdvS.Visible = true;
        ////FillGridnS();
        
        //crrD = new CorrectionEntryDao();

        //gdvS.Visible = true;
        //FillGridnS();
        //ArrayList arn = new ArrayList();
        //DataSet dsy = new DataSet();
        //Session["intYearCalcCorr"] = gen.GetCCYearId();

        ///////////// Delete from Corr ////////////////
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToDouble(Session["numEmpIdLedger"]));
        //ar.Add(Convert.ToInt16(Session["intYearCalcCorr"]));
        //crrD.DelCorrEntry(ar);
        ///////////// Delete from Corr ////////////////

        //for (int i = 0; i < gdvS.Rows.Count; i++)
        //{
        //    int intMth = 0;
        //    int intDy = 0;
        //    double dblAmt = 0;
        //    double dblCalcAmt = 0;
        //    int tp = 0;
        //    int intChalanId = 0;
        //    int intCorrTpe = 0;
        //    int intYrId = 0;

        //    intYrId = Convert.ToInt16(gdvS.Rows[i].Cells[2].Text);
        //    intMth = Convert.ToInt16(gdvS.Rows[i].Cells[3].Text);
        //    intDy = Convert.ToInt16(gdvS.Rows[i].Cells[4].Text);
        //    dblAmt = Convert.ToDouble(gdvS.Rows[i].Cells[5].Text);
        //    tp = Convert.ToInt16(gdvS.Rows[i].Cells[8].Text);
        //    intChalanId = Convert.ToInt32(gdvS.Rows[i].Cells[9].Text);
        //    if (Convert.ToInt16(gdvS.Rows[i].Cells[6].Text) == 1)
        //    {
        //        dblAmt = -dblAmt;
        //        //dblCalcAmt = -gblObj.CalculateAdjAmt(intYrId, 52, intMth, intDy, dblAmt);
        //    }
        //    //else
        //    //{
        //    dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intYearCalcCorr"]), intMth, intDy, dblAmt);
        //    //}
        //    GridViewRow gvr = gdvS.Rows[i];
        //    Label lblAmt = (Label)gvr.FindControl("lblAmt");
        //    lblAmt.Text = dblCalcAmt.ToString();

        //    //////////// intCorrTpe /////////////////
        //    intCorrTpe = Convert.ToInt16(gdvS.Rows[i].Cells[10].Text);
        //    //////////// intCorrTpe /////////////////

        //    SaveCorrectionEntry(Convert.ToInt32(gdvS.Rows[i].Cells[1].Text), intChalanId, intYrId, intMth, intDy, dblCalcAmt, 200, intCorrTpe, dblAmt, dblAmt, 10, tp);
        //    //gdvS.Visible = false;
        //    gblObj.MsgBoxOk("Ok!!!", this);
        //}
    }
    private void FillTxts1(DataSet ds1)
    {
        if (ds1.Tables[0].Rows.Count > 0)
        {
            txtOb.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
            txtRem.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            txtInt.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            txtTot.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();
            txtWith.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
            txtCorr.Text = ds1.Tables[0].Rows[0].ItemArray[28].ToString();
            txtCB.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
        }
        else
        {
            ClearTxts(1);
        }
    }
    private void ClearTxts(int tp)
    {
        if (tp == 1)
        {
            txtOb.Text = "0";
            txtRem.Text = "0";
            txtInt.Text = "0";
            txtTot.Text = "0";
            txtWith.Text = "0";
            txtCB.Text = "0";
        }
    }
    protected void btnCorr_Click(object sender, EventArgs e)
    {
        //if (gdvCons.Visible == true)
        //{
        //    gdvCons.Visible = false;
        //}
        //else
        //{
        //    FillGrid3();
        //    gdvCons.Visible = true;
        //}
        
    }
    protected void rdSngl_SelectedIndexChanged(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();

        if (rdSngl.SelectedValue == "1")
        {
            pnlS.Visible = true;
            pnlB.Visible = false;
        }
        else
        {
            pnlS.Visible = false;
            pnlB.Visible = true;
            DataSet ds = new DataSet();
            ds = gen.GetYearRem();
            gblObj.FillCombo(ddlYearB, ds, 1);
            //SetGridDefaultnw();
        }
    }
    protected void ddlYearB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearB.SelectedIndex > 0)
        {
            btnTemp.Enabled = false;
            btnGrid.Enabled = false;
            Session["intYearCalcCorr"] = Convert.ToInt16(ddlYearB.SelectedValue);
            if (Convert.ToInt16(Session["intYearCalcCorr"]) < 50)
            {               
                FillGridn();              
            }
            else
            {
                btnTemp.Enabled = true;
                btnGrid.Enabled = true;
            }
        }
    }
    private void SetGridDefaultnw()
    {
        ArrayList ar = new ArrayList();
        ar.Add("slno");
        ar.Add("intAccNo");
        ar.Add("intYrId");
        ar.Add("RemAmt");
        ar.Add("intDay");
        ar.Add("intMonthId");
        ar.Add("tpCorr");
        ar.Add("intChalanId");
        ar.Add("tp");
        ar.Add("LCorrTp");
        ar.Add("intTblTp");
        
        gblObj.SetGridDefault(gdv2, ar);
        gdv2.Enabled = false;
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
    private void FillGridn()
    {
        crrD = new CorrectionEntryDao();

        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
        dsSched = gen.getCorrDetn(ar);
        SetGridDefaultnw();
        
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
    //private void FillGridn()
    //{
    //    crrD = new CorrectionEntryDao();
        
    //    DataSet dsSched = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
    //    if (Convert.ToDouble(Session["intYearCalcCorr"]) < 50)
    //    {
    //        dsSched = gen.getCorrDetn(ar);
    //    }
    //    else
    //    {
    //        dsSched = gen.getCorrDetn2(ar);
    //    }
    //    SetGridDefaultnw();
    //    crrD.DelCorrectionCalc();
    //    if (dsSched.Tables[0].Rows.Count > 0)
    //    {
    //        gdv2.DataSource = dsSched;
    //        gdv2.DataBind();
    //        for (int i = 0; i < gdv2.Rows.Count; i++)
    //        {
                
    //            GridViewRow gvr = gdv2.Rows[i];
    //            if (dsSched.Tables[0].Rows[i].ItemArray[5].ToString() == "3")
    //            {
    //                gvr.Cells[5].ForeColor = System.Drawing.Color.Red;
    //                gvr.Cells[5].Font.Bold = true;
    //            }
    //            else if (dsSched.Tables[0].Rows[i].ItemArray[5].ToString() == "2")
    //            {
    //                gvr.Cells[5].ForeColor = System.Drawing.Color.Green;
    //                gvr.Cells[5].Font.Bold = true;
    //            }
    //            /// //////////////////////////////////////////////
    //            ArrayList arEmp = new ArrayList();
    //            arEmp.Add(Convert.ToInt32(dsSched.Tables[0].Rows[i].ItemArray[1]));
    //            arEmp.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
    //            arEmp.Add(1);
    //            crrD.CorrectionCalcInsert(arEmp);
    //            /// //////////////////////////////////////////////
    //        }
    //    }
    //}
    private void fillCorrectionCalc()
    {

    }
    private void FillGridnS()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        Session["intYearCalcCorr"] = gen.GetCCYearId();
        ar.Add(Convert.ToDouble(Session["numEmpIdLedger"]));
        ar.Add(Convert.ToInt16(Session["intYearCalcCorr"]));
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
                dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intYearCalcCorr"]), intMth, intDy, dblAmt);

                Label lblAmt = (Label)gvr.FindControl("lblAmt");
                lblAmt.Text = dblCalcAmt.ToString();
                intCorrTpe = Convert.ToInt16(gdvS.Rows[i].Cells[10].Text);
                SaveCorrectionEntry(Convert.ToInt32(gdvS.Rows[i].Cells[1].Text), intChalanId, intYrId, intMth, intDy, dblCalcAmt, 200, intCorrTpe, dblAmt, dblAmt, 10, tp);
                gblObj.MsgBoxOk("Ok!!!", this);
                ///////////////////////////////////////////////////
            }
        }
    }
    private void delCorrectionYearwise()
    {
        crrD = new CorrectionEntryDao();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intYearCalcCorr"]));
        arr.Add(Convert.ToInt16(Session["intYearIdMax"]));
        
        crrD.DelCorrEntryBulk(arr);
    }
    //private int cntEaqual(int yr)
    //{
    //    int flg = 1;
    //    crrD = new CorrectionEntryDao();
    //    ArrayList ar = new ArrayList();
    //    DataSet ds = new DataSet();
    //    ar.Add(yr);
    //    ar.Add(Convert.ToInt16(Session["intYearIdMax"]));
    //    ds = crrD.checkCorrCount(ar);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) == 0)
    //        {
    //            flg = 0;
    //        }
    //        else
    //        {
    //            flg = 1;
    //        }
    //    }
    //    else
    //    {
    //        flg = 1;
    //    }
       
    //    return flg;
    //}
    protected void btnCorrCalc_Click(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        ArrayList arn = new ArrayList();
        DataSet dsy = new DataSet();
        int intYrId = Convert.ToInt16(Session["intYearCalcCorr"]);
        Session["intYearIdMax"] = gen.GetCCYearId();
        if (intYrId < 50)
        {
            delCorrectionYearwise();
        }
        //else if (intYrId >= 50)
        //{
        //    if (cntEaqual(intYrId) == 0)
        //    {
        //        delCorrectionYearwise();
        //    }
        //}
        for (int i = 0; i < gdv2.Rows.Count; i++)
        {
            int intMth = 0;
            int intDy = 0;
            double dblAmt = 0;
            double dblCalcAmt = 0;
            int tp = 0;
            int intChalanId = 0;
            int intCorrTpe = 0;

            intMth = Convert.ToInt16(gdv2.Rows[i].Cells[3].Text);
            intDy = Convert.ToInt16(gdv2.Rows[i].Cells[4].Text);
            dblAmt = Convert.ToDouble(gdv2.Rows[i].Cells[5].Text);
            tp = Convert.ToInt16(gdv2.Rows[i].Cells[8].Text);
            intChalanId = Convert.ToInt32(gdv2.Rows[i].Cells[9].Text);
            if (Convert.ToInt16(gdv2.Rows[i].Cells[6].Text) == 1)
            {
                dblAmt = -dblAmt;
                //dblCalcAmt = -gblObj.CalculateAdjAmt(intYrId, 52, intMth, intDy, dblAmt);
            }
            //else
            //{
            dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intYearIdMax"]), intMth, intDy, dblAmt);
            //}
            GridViewRow gvr = gdv2.Rows[i];
            Label lblAmt = (Label)gvr.FindControl("lblAmt");
            lblAmt.Text = dblCalcAmt.ToString();

            //////////// intCorrTpe /////////////////
            intCorrTpe = Convert.ToInt16(gdv2.Rows[i].Cells[10].Text);
            int intTblTp = Convert.ToInt16(gdv2.Rows[i].Cells[11].Text);
            //////////// intCorrTpe /////////////////

            SaveCorrectionEntryTblTp(Convert.ToInt32(gdv2.Rows[i].Cells[1].Text), intChalanId, intYrId, intMth, intDy, dblCalcAmt, 200, intCorrTpe, dblAmt, dblAmt, 10, tp, intTblTp);

            /// //////////////////////////////////////////////
            ArrayList arEmp = new ArrayList();
            arEmp.Add(Convert.ToInt32(Convert.ToInt32(gdv2.Rows[i].Cells[1].Text)));
            arEmp.Add(2);
            crrD.CorrectionCalcUpd(arEmp);
            /// //////////////////////////////////////////////
        }
        gblObj.MsgBoxOk("Ok" + intYrId, this);
    }
    private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType, int FlgType)
    {
        crr = new CorrectionEntry();
        crrD = new CorrectionEntryDao();
        Session["intCCYearId"] = gen.GetCCYearId();
        crr.IntAccNo = intAccNo;
        crr.IntYearID = yr;
        crr.IntMonthID = mth;
        crr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        crr.FltAmountBefore = fltAmtBfr;
        crr.FltAmountAfter = fltAmtAfr;
        crr.FltCalcAmount = amt;
        crr.FlgCorrected = 1;      //Just added not incorporated in CCard
        crr.IntChalanId = chalId;
        crr.IntSchedId = intSchedId;
        crr.FlgType = FlgType;           //Remittance
        crr.FltRoundingAmt = 0;
        crr.IntCorrectionType = intCorrTp; //Edit Chal Date
        crr.IntChalanType = ChalType;
        crrD.CreateCorrEntryCalc(crr);

    }
    private void SaveCorrectionEntryTblTp(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType, int FlgType, int tblTp)
    {
        crr = new CorrectionEntry();
        crrD = new CorrectionEntryDao();
        Session["intCCYearId"] = gen.GetCCYearId();
        crr.IntAccNo = intAccNo;
        crr.IntYearID = yr;
        crr.IntMonthID = mth;
        crr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        crr.FltAmountBefore = fltAmtBfr;
        crr.FltAmountAfter = fltAmtAfr;
        crr.FltCalcAmount = amt;
        crr.FlgCorrected = 1;      //Just added not incorporated in CCard
        crr.IntChalanId = chalId;
        crr.IntSchedId = intSchedId;
        crr.FlgType = FlgType;           //Remittance
        crr.FltRoundingAmt = 0;
        crr.IntCorrectionType = intCorrTp; //Edit Chal Date
        crr.IntChalanType = ChalType;
        crr.IntTblTp = tblTp;
        crrD.CreateCorrEntryCalcTblTp(crr);

    }
    protected void btnTemp_Click(object sender, EventArgs e)
    {
        int cnt=0;
        gen = new GeneralDAO();
        Session["intYearIdMax"] = gen.GetCCYearId();
        delCorrectionYearwise();    // delete from CorrectionEntry table
        crrD.DelCorrectionCalc();   // delete from CorrectionEntry Temp table (>50)
        /// //////////////////////////////////////////////
        DataSet dsSched = new DataSet();
        ArrayList arSch = new ArrayList();
        
        arSch.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
        dsSched = gen.getCorrDetn2(arSch);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsSched.Tables[0].Rows.Count ; i++)
            {
                ArrayList arEmp = new ArrayList();
                arEmp.Add(Convert.ToInt32(dsSched.Tables[0].Rows[i].ItemArray[1]));
                arEmp.Add(Convert.ToDouble(Session["intYearCalcCorr"]));
                arEmp.Add(Convert.ToInt32(dsSched.Tables[0].Rows[i].ItemArray[3]));
                arEmp.Add(Convert.ToDouble(dsSched.Tables[0].Rows[i].ItemArray[4]));

                arEmp.Add(Convert.ToInt32(dsSched.Tables[0].Rows[i].ItemArray[5]));
                arEmp.Add(Convert.ToDouble(dsSched.Tables[0].Rows[i].ItemArray[6]));

                arEmp.Add(Convert.ToInt32(dsSched.Tables[0].Rows[i].ItemArray[7]));
                arEmp.Add(Convert.ToDouble(dsSched.Tables[0].Rows[i].ItemArray[8]));

                arEmp.Add(Convert.ToInt32(dsSched.Tables[0].Rows[i].ItemArray[9]));
                arEmp.Add(Convert.ToDouble(dsSched.Tables[0].Rows[i].ItemArray[10]));
                arEmp.Add(1);
                arEmp.Add(1);

                crrD.CorrectionCalcInsert(arEmp);
                cnt = i;
            }
        }
        gblObj.MsgBoxOk("Ok" + cnt, this);
        /// //////////////////////////////////////////////
    }
    protected void btnGrid_Click(object sender, EventArgs e)
    {
        FillGridn50();
    }
    private void FillGridn50()
    {
        crrD = new CorrectionEntryDao();
        //gen = new GeneralDAO();
        DataSet dsSched = new DataSet();
        dsSched = crrD.getCorrDetFromTemp();
        SetGridDefaultnw();

        if (dsSched.Tables[0].Rows.Count > 0)
        {
            Session["cnt"] = Convert.ToInt16(dsSched.Tables[0].Rows.Count);
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
        gblObj.MsgBoxOk("Ok", this);
    }
}





