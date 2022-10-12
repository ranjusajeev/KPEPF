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

public partial class Contents_CorrTemp : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    ChalanDAO chalDao = new ChalanDAO();
    KPEPFGeneralDAO kgen = new KPEPFGeneralDAO();
    AORecorrection aoRecorr = new AORecorrection();
    AORecorrectionDAO aoRecorrDAO = new AORecorrectionDAO();

    CorrectionEntry corr = new CorrectionEntry();
    CorrectionEntryDao corrDao = new CorrectionEntryDao();

    static double dblAmtAdjustedDisp = 0;
    //BillPDE blpde = new BillPDE();
    //BillPDEDao blPdeD = new BillPDEDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["numChalanId"]) > 0)
            {
                Session["numChalanId"] = Convert.ToInt32(Request.QueryString["numChalanId"]);
                Session["YearId"] = Convert.ToInt16(Request.QueryString["intYearId"]);
                Session["MonthId"] = Convert.ToInt16(Request.QueryString["MonthId"]);
                Session["dy"] = Convert.ToInt16(Request.QueryString["dy"]);
                FillC();
                FillS();
            }


            //gblObj.NumServiceTrnID = Convert.ToInt64(Request.QueryString["numTrnID"]);
            //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
            //Session["intTrnType"] = Convert.ToInt16(Request.QueryString["intTrnTypeID"]);
            //Session["NumEmpId"] = Convert.ToInt16(Request.QueryString["numEmpId"]);
            //if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 7)
            //{
            //    Response.Redirect("SubnChange.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 5)
            //{
            //    Response.Redirect("MembershipNomonation.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 2)
            //{
            //    Response.Redirect("TA.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 3)
            //{
            //    Response.Redirect("TA.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 31)
            //{
            //    Response.Redirect("TA.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 4)
            //{
            //    Response.Redirect("NRA.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 41)
            //{
            //    Response.Redirect("NRA.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 6)
            //{
            //    Response.Redirect("NomChg.aspx");
            //}
            //else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 8)
            //{
            //    Response.Redirect("TaNraConversion.aspx");
            //}
        }
    }
    private void FillS()
    {
        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToDouble(Session["numChalanId"]));
        if (Convert.ToInt16(Session["YearId"]) < 50)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        dsSched = gen.GetSched(ar);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdvs.DataSource = dsSched;
            gdvs.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillC();
    }
    private void FillC()
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt16(Session["no"]));
        ar.Add(Session["dt"].ToString());
        ar.Add(3);
        ds = chalDao.GetChalanSearchOTP(ar, 1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvc.DataSource = ds;
            gdvc.DataBind();

            gdvc.HeaderRow.Cells[3].Text = "s";
            gdvc.Enabled = true;


            //for (int i = 0; i < gdvc.Rows.Count; i++)
            //{
            //    GridViewRow gvr = gdvc.Rows[i];
            //    Label lblYearAss = (Label)gvr.FindControl("lblYear");
            //    //Label lblMonthAss = (Label)gvr.FindControl("lblMonth");
            //    //Label lblDistAss = (Label)gvr.FindControl("lblDist");

            //    lblYearAss.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            //    //lblMonthAss.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            //    //lblDistAss.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            //}
        }
        else
        {
            SetGridDefault();
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("chvName");
        ar.Add("chvEngDistName");
        ar.Add("numChalanId");
        ar.Add("flgApproval");
        ar.Add("flgPrevYear");
        ar.Add("intGroupId");
        ar.Add("PerYearId");
        ar.Add("PerMonthId");
        ar.Add("intDistID");
        ar.Add("PDEYear");
        ar.Add("intYearId");
        ar.Add("MonthId");
        ar.Add("dy");
        gblObj.SetGridDefault(gdvc, ar);
        gdvc.Enabled = false;
    }
    private void SetGridDefaultS()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("chvName");

        gblObj.SetGridDefault(gdvs, ar);
        gdvs.Enabled = false;
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int intYrId = 0;
        int intMth = 0;
        int intDy = 0;
        double dblAmtToCalc = 0;
        intYrId = Convert.ToInt16(Session["YearId"]);
        intMth = Convert.ToInt16(Session["MonthId"]);
        intDy = Convert.ToInt16(Session["dy"]);

        for (int i = 0; i < gdvs.Rows.Count; i++)
        {
            if (Convert.ToInt16(Session["Calc"]) == 1)
            {
                SaveCorrectionEntry(Convert.ToInt32(gdvs.Rows[i].Cells[1].Text), Convert.ToInt32(Session["numChalanId"]), intYrId, intMth, intDy, Convert.ToDouble(gdvs.Rows[i].Cells[2].Text), Convert.ToInt32(gdvs.Rows[i].Cells[3].Text), 8, 0, Convert.ToDouble(gdvs.Rows[i].Cells[2].Text), 10,1);
                UpdLedgerYear(Convert.ToInt32(gdvs.Rows[i].Cells[1].Text));
            }
            else if (Convert.ToInt16(Session["Calc"]) == 2)
            {
                SaveCorrectionEntry(Convert.ToInt32(gdvs.Rows[i].Cells[1].Text), Convert.ToInt32(Session["numChalanId"]), intYrId, intMth, intDy, Convert.ToDouble(gdvs.Rows[i].Cells[2].Text), Convert.ToInt32(gdvs.Rows[i].Cells[3].Text), 9, Convert.ToDouble(gdvs.Rows[i].Cells[2].Text), 0, 10,1);
            }
        }
    }
    private void UpdLedgerYear(int accno)
    {
        LedgerYDao ldgrYd = new LedgerYDao();
        ArrayList ar = new ArrayList();
        ar.Add(accno);
        ldgrYd.UpdateYearDet4GenerateCardNew(ar);
    }
    protected void txtDt_TextChanged(object sender, EventArgs e)
    {
        Session["dt"] = txtDt.Text.ToString();
    }
    protected void txtNo_TextChanged(object sender, EventArgs e)
    {
        Session["no"] = txtNo.Text.ToString();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.Items[0].Selected == true)
        {
            Session["flgTp"] = 1;
        }
        else
        {
            Session["flgTp"] = 2;
        }
    }
    protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdCategory.Items[0].Selected == true)
        {
            Session["Calc"] = 1;            // Add a chalan 
            pnlNo.Visible = true;
            pnlNo1.Visible = false;
            pnlNo2.Visible = false;
            rdSngl.Visible = false;
        }
        else if (rdCategory.Items[1].Selected == true)
        {
            Session["Calc"] = 2;            // Delete a chalan 
            pnlNo.Visible = true;
            pnlNo1.Visible = false;
            pnlNo2.Visible = false;
            rdSngl.Visible = false;
        }
        else if (rdCategory.Items[2].Selected == true)
        {
            Session["Calc"] = 3;
            pnlNo.Visible = false;
            pnlNo1.Visible = true;
            pnlNo2.Visible = false;
            rdSngl.Visible = false;
        }
        else 
        {
            Session["Calc"] = 4;
            pnlNo.Visible = false;
            pnlNo1.Visible = false;
            pnlNo2.Visible = true;
            rdSngl.Visible = true;
        }
    }
    protected void btnCalc2_Click(object sender, EventArgs e)
    {
        //ArrayList ar = new ArrayList();
        //int intYrId = 0;
        //int intMth = 0;
        //int intDy = 0;
        //double dblAmtToCalc = 0;
        //ar.Add(txtDt2.Text.ToString());
        //intYrId = kgen.gFunFindYearIdFromDate(ar);
        //intMth = Convert.ToDateTime(txtDt2.Text).Month;
        //intDy = Convert.ToDateTime(txtDt2.Text).Day;
        //dblAmtToCalc = Convert.ToDouble(txtAmt2.Text);
        //SaveCorrectionEntry(Convert.ToInt32(txtAcc.Text), Convert.ToInt32(txtChal.Text), intYrId, intMth, intDy, dblAmtToCalc, Convert.ToInt32(txtSch.Text), 4, dblAmtToCalc, dblAmtToCalc, 10,Convert.ToInt16(Session["flgTp"]));
        //txtcaAmt.Text = dblAmtAdjustedDisp.ToString();

        double dblAmtAdjusted = 0;
        Session["intCCYearId"] = gen.GetCCYearId() + 1;
        ArrayList ar = new ArrayList();
        int intYrId = 0;
        int intMth = 0;
        int intDy = 0;
        double dblAmtToCalc = 0;
        ar.Add(txtDt2.Text.ToString());
        intYrId = kgen.gFunFindYearIdFromDate(ar);
        intMth = Convert.ToDateTime(txtDt2.Text).Month;
        intDy = Convert.ToDateTime(txtDt2.Text).Day;
        dblAmtToCalc = Convert.ToDouble(txtAmt2.Text);

        dblAmtAdjusted = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intCCYearId"]), intMth, intDy, dblAmtToCalc);
        //SaveCorrectionEntry(Convert.ToInt32(txtAcc.Text), Convert.ToInt32(txtChal.Text), intYrId, intMth, intDy, dblAmtToCalc, Convert.ToInt32(txtSch.Text), 4, dblAmtToCalc, dblAmtToCalc, 10,Convert.ToInt16(Session["flgTp"]));
        txtcaAmt.Text = dblAmtAdjusted.ToString();
    }
    private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChngType, int FlgType)
    {
        Session["intCCYearId"] = 50;
        double dblAmtAdjusted = 0;
        if (intCorrTp == 9)
        {
            dblAmtAdjusted = -gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
        }
        else
        {
            dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
        }
        corr.IntAccNo = intAccNo;
        corr.IntYearID = yr;
        corr.IntMonthID = mth;
        corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        corr.FltAmountBefore = fltAmtBfr;
        corr.FltAmountAfter = fltAmtAfr;
        corr.FltCalcAmount = dblAmtAdjusted;
        corr.FlgCorrected = 1;      //Just added not incorporated in CCard
        corr.IntChalanId = chalId;
        corr.IntSchedId = intSchedId;
        corr.FlgType = FlgType;           //Remittance
        corr.FltRoundingAmt = 0;
        corr.IntCorrectionType = intCorrTp; //Edit Chal Date
        corr.IntChalanType = ChngType;
        corrDao.CreateCorrEntry(corr);
        dblAmtAdjustedDisp = dblAmtAdjusted;
    }

    protected void btnCalcO_Click(object sender, EventArgs e)
    {
        if (rdSngl.Items[0].Selected == true)
        {
            int intYrId = 0;
            int intMth = 0;
            int intDy = 0;
            double dblAmtToCalc = 0;
            intYrId = 37;
            intMth = 4;
            intDy = 1;
            dblAmtToCalc = Convert.ToDouble(txtAmtO.Text);
            //SaveCorrectionEntry(Convert.ToInt32(txtAccO.Text), Convert.ToInt32(txtAccO.Text), intYrId, intMth, intDy, dblAmtToCalc, Convert.ToInt32(txtAccO.Text), 4, dblAmtToCalc, dblAmtToCalc, 10, 3);
            txtCalcO.Text = dblAmtAdjustedDisp.ToString();
        }

        else
        {
            EmployeeDAO empd = new EmployeeDAO();
            DataSet dsEmp = new DataSet();
            dsEmp = empd.GetEmp4BulcCalc();
            if (dsEmp.Tables[0].Rows.Count > 0)
            {
                int intYrId = 37;
                int intMth = 4;
                int intDy = 1;
                for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
                {
                    double dblAmtToCalc = Convert.ToDouble(Convert.ToDouble(dsEmp.Tables[0].Rows[i].ItemArray[1]));
                    //SaveCorrectionEntry(Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]), Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]), intYrId, intMth, intDy, dblAmtToCalc, Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]), 4, dblAmtToCalc, dblAmtToCalc, 10, 3);
                    txtCalcO.Text = dblAmtAdjustedDisp.ToString();
                }
            }
        }
    }

    protected void btnSaveCorr_Click(object sender, EventArgs e)
    {
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();

        double dblAmtAdjusted = 0;
        Session["intCCYearId"] = gen.GetCCYearId() + 1;
        ArrayList ar = new ArrayList();
        int intYrId = 0;
        int intMth = 0;
        int intDy = 0;
        double dblAmtToCalc = 0;
        ar.Add(txtDt2.Text.ToString());
        intYrId = kgen.gFunFindYearIdFromDate(ar);
        intMth = Convert.ToDateTime(txtDt2.Text).Month;
        intDy = Convert.ToDateTime(txtDt2.Text).Day;
        dblAmtToCalc = Convert.ToDouble(txtAmt2.Text);
        dblAmtAdjusted = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intCCYearId"]), intMth, intDy, dblAmtToCalc);
        txtcaAmt.Text = dblAmtAdjusted.ToString();

        ////////////////////////////////////
        corr.FltAmountBefore = Convert.ToDouble(txtAmtBfr.Text);
        corr.FltAmountAfter = Convert.ToDouble(txtAmtAfr.Text);
        corr.IntAccNo = Convert.ToInt32(txtAcc.Text);
        corr.IntYearID = intYrId;
        corr.IntMonthID = intMth;
        corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        corr.FltCalcAmount = Convert.ToDouble(txtcaAmt.Text); // dblAmtAdjusted;
        corr.FlgCorrected = 1;      //Just added not incorporated in CCard
        corr.IntChalanId = Convert.ToInt64(txtChal.Text);
        corr.IntSchedId = Convert.ToInt64(txtSch.Text);
        corr.FlgType = Convert.ToInt16(RadioButtonList1.SelectedValue);           //Remittance
        corr.FltRoundingAmt = 0;
        corr.IntCorrectionType = Convert.ToInt16(txtCorrType.Text);
        corr.IntChalanType = Convert.ToInt16(txtChalType.Text);
        if (corr.IntYearID < 50)
        {
            corr.IntTblTp = 1;
        }
        else
        {
            corr.IntTblTp = 2;
        }
        corrDao.CreateCorrEntryCalcTblTp(corr);
        ////////////////////////////////////
        
    }
    //protected void btnCalc2_Click(object sender, EventArgs e)
    //{
    //    //ArrayList ar = new ArrayList();
    //    //int intYrId = 0;
    //    //int intMth = 0;
    //    //int intDy = 0;
    //    //double dblAmtToCalc = 0;
    //    //ar.Add(txtDt2.Text.ToString());
    //    //intYrId = kgen.gFunFindYearIdFromDate(ar);
    //    //intMth = Convert.ToDateTime(txtDt2.Text).Month;
    //    //intDy = Convert.ToDateTime(txtDt2.Text).Day;
    //    //dblAmtToCalc = Convert.ToDouble(txtAmt2.Text);
    //    //SaveCorrectionEntry(Convert.ToInt32(txtAcc.Text), Convert.ToInt32(txtChal.Text), intYrId, intMth, intDy, dblAmtToCalc, Convert.ToInt32(txtSch.Text), 4, dblAmtToCalc, dblAmtToCalc, 10,Convert.ToInt16(Session["flgTp"]));
    //    //txtcaAmt.Text = dblAmtAdjustedDisp.ToString();

    //    double dblAmtAdjusted = 0;
    //    //Session["intCCYearId"] = 51;
    //    Session["intCCYearId"] = gen.GetCCYearId();
    //    ArrayList ar = new ArrayList();
    //    int intYrId = 0;
    //    int intMth = 0;
    //    int intDy = 0;
    //    double dblAmtToCalc = 0;
    //    ar.Add(txtDt2.Text.ToString());
    //    intYrId = kgen.gFunFindYearIdFromDate(ar);
    //    intMth = Convert.ToDateTime(txtDt2.Text).Month;
    //    intDy = Convert.ToDateTime(txtDt2.Text).Day;
    //    dblAmtToCalc = Convert.ToDouble(txtAmt2.Text);

    //    dblAmtAdjusted = gblObj.CalculateAdjAmt(intYrId, Convert.ToInt16(Session["intCCYearId"]) + 1, intMth, intDy, dblAmtToCalc);
    //    //SaveCorrectionEntry(Convert.ToInt32(txtAcc.Text), Convert.ToInt32(txtChal.Text), intYrId, intMth, intDy, dblAmtToCalc, Convert.ToInt32(txtSch.Text), 4, dblAmtToCalc, dblAmtToCalc, 10,Convert.ToInt16(Session["flgTp"]));
    //    txtcaAmt.Text = dblAmtAdjusted.ToString();
    //}

}

