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
using System.Data.SqlClient;
using KPEPFClassLibrary;

public partial class Contents_Calculation : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    Approval appObj = new Approval();
    ApprovalDAO appDao = new ApprovalDAO();
    GeneralDAO gen = new GeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empD = new EmployeeDAO();
    CorrectionEntry cor = new CorrectionEntry();
    CorrectionEntryDao corrD = new CorrectionEntryDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();
            SetGridDefault();
            Session["intYearIdMax"] = gen.GetCCYearId();
        }
    }
    private void SetGridDefaultChd()
    {
        ArrayList ar = new ArrayList();
        ar.Add("fltCalcAmount");
        ar.Add("intAccNo");
        ar.Add("intYearID");
        ar.Add("chvYear");
        ar.Add("OrgAmt");
        ar.Add("IntAmt");
        ar.Add("rtInt");
        ar.Add("dtmchalan");
        ar.Add("intSlNo");
        gblObj.SetGridDefault(gdvCalc, ar);
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmchalan");
        ar.Add("fltChalanAmt");
        ar.Add("fltCalcAmount");
        ar.Add("LBName");
        ar.Add("chvEngDistName");
        ar.Add("chvCorrType");
        ar.Add("chvUser");
        ar.Add("chvYear");
        ar.Add("chvMonth");
        ar.Add("chvType");
        ar.Add("fltAmountBefore");
        gblObj.SetGridDefault(gdvBill, ar);
    }
    private void SetGridDefaultNew()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmchalan");
        ar.Add("fltChalanAmt");
        ar.Add("fltCalcAmount");
        ar.Add("LBName");
        ar.Add("chvEngDistName");
        ar.Add("chvCorrType");
        ar.Add("chvUser");
        ar.Add("chvYear");
        ar.Add("chvMonth");
        ar.Add("chvType");
        ar.Add("fltAmountBefore");
        gblObj.SetGridDefault(gdvBillCurr, ar);
    }
    private void FillCmbYr()
    {
        DataSet ds2 = new DataSet();
        ds2 = gen.GetYearCorr();
        gblObj.FillCombo(ddlYearCorr, ds2, 1);
    }
    private void InitialSettings()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 42)
        {
            pnlS.Visible = true;
            pnlB.Visible = false;
            lblHead.Text = "Correction Entry";
            FillCmbYr();
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 2)
        {
            pnlS.Visible = false;
            pnlB.Visible = true;
        }
        else
        {
            pnlS.Visible = false;
            pnlB.Visible = false;
            gblObj.MsgBoxOk("Not Activated!", this);
        }

    }
    private void CalculateCurrYr(Int32 intAccNo)
    {

    }
    private void SaveCorrEntryChild()
    {
        int yrSt = 0;
        int cntNullData = 0;
        double HidnAmt = 0;
        double HidnIntAmt = 0;
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearIdMax"]));
        DataSet dsTrn = new DataSet();
        DataSet dsCnt = new DataSet();
        dsCnt = corrD.GetCorrectionEntryCnt(ar);
        //for (int i = 11; i < 12; i++)
        //{
        SetGridDefaultChd();
        //cor.IntAccNo = Convert.ToInt32(dsCnt.Tables[0].Rows[i].ItemArray[0]);
        cor.IntAccNo = Convert.ToInt16(txtAccNoCa.Text);

        dsTrn = corrD.GetCorrectionEntry4Calc(cor);
        if (dsTrn.Tables[0].Rows.Count > 0)
        {
            gdvCalc.DataSource = dsTrn;
            gdvCalc.DataBind();
            for (int j = 0; j < gdvCalc.Rows.Count; j++)
            {
                GridViewRow gvr = gdvCalc.Rows[j];
                Label lblCalcAss = (Label)gvr.FindControl("lblCalc");
                Label lblTotalAss = (Label)gvr.FindControl("lblTotal");
                Label lblBalMthAss = (Label)gvr.FindControl("lblBalMth");
                Label lblHidnAmtAss = (Label)gvr.FindControl("lblHidnAmt");
                Label lblHdnIntAmtAss = (Label)gvr.FindControl("lblHdnIntAmt");
                Label lblTrnTpAss = (Label)gvr.FindControl("lblTrnTp");

                lblTrnTpAss.Text = dsTrn.Tables[0].Rows[j].ItemArray[11].ToString();
                cntNullData = FillBalanceMonth(gvr, lblBalMthAss, j, lblTrnTpAss);

                //Find St year
                if (gvr.Cells[5].Text.Trim() != "0" && yrSt == 0)
                {
                    yrSt = Convert.ToInt16(dsTrn.Tables[0].Rows[cntNullData].ItemArray[2]);
                }
                //Find St year

                if (Convert.ToInt16(gvr.Cells[1].Text) == yrSt && yrSt > 0)
                {
                    HidnAmt = Convert.ToDouble(gvr.Cells[5].Text);
                }
                if (Convert.ToInt16(gvr.Cells[1].Text) >= yrSt && yrSt > 0)
                {
                    if (Convert.ToDouble(gvr.Cells[5].Text) > 0 && Convert.ToInt16(gvr.Cells[1].Text) == 37)
                    {
                        GridViewRow gvrMinusOne = gdvCalc.Rows[j - 1];
                        Label lblTotalMinusOneAss = (Label)gvrMinusOne.FindControl("lblTotal");

                        FillChvCalc(gvr, j, dsTrn, lblCalcAss, Convert.ToDouble(gvr.Cells[5].Text), 0, lblBalMthAss);
                        HidnIntAmt = FillIntAmt(gvr, dsTrn, Convert.ToDouble(gvr.Cells[5].Text), 0, j, lblBalMthAss);
                        lblHdnIntAmtAss.Text = HidnIntAmt.ToString();
                        HidnAmt = HidnAmt + HidnIntAmt + Convert.ToDouble(lblTotalMinusOneAss.Text) ;
                        lblTotalAss.Text = HidnAmt.ToString();
                    }
                    else if (Convert.ToDouble(gvr.Cells[5].Text) != 0 && Convert.ToInt16(gvr.Cells[1].Text) > yrSt)
                    {
                        GridViewRow gvrMinusOne = gdvCalc.Rows[j - 1];
                        Label lblTotalMinusOneAss = (Label)gvrMinusOne.FindControl("lblTotal");

                        FillChvCalc(gvr, j, dsTrn, lblCalcAss, Convert.ToDouble(gvr.Cells[5].Text), 0, lblBalMthAss);
                        HidnIntAmt = FillIntAmt(gvr, dsTrn, Convert.ToDouble(gvr.Cells[5].Text), 0, j, lblBalMthAss);
                        lblHdnIntAmtAss.Text = HidnIntAmt.ToString();
                        HidnAmt = HidnAmt + HidnIntAmt + Convert.ToDouble(gvr.Cells[5].Text);
                        lblTotalAss.Text = HidnAmt.ToString();
                    }
                    else
                    {
                        FillChvCalc(gvr, j, dsTrn, lblCalcAss, HidnAmt, HidnIntAmt, lblBalMthAss);
                        HidnIntAmt = FillIntAmt(gvr, dsTrn, HidnAmt, HidnIntAmt, j, lblBalMthAss);
                        lblHdnIntAmtAss.Text = HidnIntAmt.ToString();
                        HidnAmt = HidnAmt + HidnIntAmt;
                        lblTotalAss.Text = HidnAmt.ToString();
                    }

                    //if (Convert.ToDouble(gvr.Cells[5].Text) > 0 && Convert.ToInt16(gvr.Cells[1].Text) > yrSt)
                    //{
                    //    GridViewRow gvrMinusOne = gdvCalc.Rows[j - 1];
                    //    Label lblTotalMinusOneAss = (Label)gvrMinusOne.FindControl("lblTotal");

                    //    FillChvCalc(gvr, j, dsTrn, lblCalcAss, Convert.ToDouble(gvr.Cells[5].Text), 0, lblBalMthAss);
                    //    HidnIntAmt = FillIntAmt(gvr, dsTrn, Convert.ToDouble(gvr.Cells[5].Text), 0, j, lblBalMthAss);
                    //    lblHdnIntAmtAss.Text = HidnIntAmt.ToString();
                    //    HidnAmt = HidnAmt + HidnIntAmt + Convert.ToDouble(gvr.Cells[5].Text);
                    //    lblTotalAss.Text = HidnAmt.ToString();
                    //}
                    //else if (Convert.ToDouble(gvr.Cells[5].Text) > 0 && Convert.ToInt16(gvr.Cells[1].Text) == yrSt)
                    //{
                    //    FillChvCalc(gvr, j, dsTrn, lblCalcAss, HidnAmt, HidnIntAmt, lblBalMthAss);
                    //    HidnIntAmt = FillIntAmt(gvr, dsTrn, HidnAmt, HidnIntAmt, j, lblBalMthAss);
                    //    lblHdnIntAmtAss.Text = HidnIntAmt.ToString();
                    //    HidnAmt = HidnAmt + HidnIntAmt;
                    //    lblTotalAss.Text = HidnAmt.ToString();
                    //}
                    //else //if (Convert.ToDouble(gvr.Cells[5].Text) == 0 && Convert.ToInt16(gvr.Cells[1].Text) > yrSt)
                    //{
                    //    FillChvCalc(gvr, j, dsTrn, lblCalcAss, Convert.ToDouble(gvr.Cells[5].Text), 0, lblBalMthAss);
                    //    HidnIntAmt = FillIntAmt(gvr, dsTrn, Convert.ToDouble(gvr.Cells[5].Text), 0, j, lblBalMthAss);
                    //    lblHdnIntAmtAss.Text = HidnIntAmt.ToString();
                    //    HidnAmt = HidnAmt + HidnIntAmt + Convert.ToDouble(gvr.Cells[5].Text);
                    //    lblTotalAss.Text = HidnAmt.ToString();
                    //}

                }
            }
        }
        SaveToDB();
        //}    For loop of Acc No
    }
    private double FillIntAmt(GridViewRow gvr, DataSet dsTrn, double HidnAmt, double HidnIntAmt, int j, Label lblBalMthAss)
    {
        double rndAmt;
        if (Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[2]) == 47 && Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[6]) == 1)
        {
            rndAmt = HidnAmt * Convert.ToDouble(gvr.Cells[4].Text) * 8 / 1200;
            HidnIntAmt = Math.Round(HidnAmt * Convert.ToDouble(gvr.Cells[4].Text) * 8 / 1200);
        }
        else if (Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[2]) == 47 && Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[6]) == 2)
        {
            rndAmt = (HidnAmt - HidnIntAmt) * Convert.ToDouble(gvr.Cells[4].Text) * 4 / 1200;
            HidnIntAmt = Math.Round((HidnAmt - HidnIntAmt) * Convert.ToDouble(gvr.Cells[4].Text) * 4 / 1200);
        }
        else
        {
            rndAmt = HidnAmt * Convert.ToDouble(gvr.Cells[4].Text) * Convert.ToInt16(lblBalMthAss.Text) / 1200;
            HidnIntAmt = Math.Round(HidnAmt * Convert.ToDouble(gvr.Cells[4].Text) * Convert.ToInt16(lblBalMthAss.Text) / 1200);
        }

        return HidnIntAmt;
    }
    private void FillChvCalc(GridViewRow gvr, int j, DataSet dsTrn, Label lblCalcAss, double HidnAmt, double HidnIntAmt, Label lblBalMthAss)
    {
        string amt = HidnAmt.ToString();
        string amt1 = gvr.Cells[4].Text.ToString();
        string amt2 = lblBalMthAss.Text.ToString();
        string finl = "";
        if (Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[2]) == 47 && Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[6]) == 1)
        {
            finl = amt + "*" + amt1 + "*" + "8/" + "1200";
        }
        else if (Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[2]) == 47 && Convert.ToInt16(dsTrn.Tables[0].Rows[j].ItemArray[6]) == 2)
        {
            amt = Convert.ToString(HidnAmt - HidnIntAmt);
            finl = amt + "*" + amt1 + "*" + "4/" + "1200";
        }
        else
        {
            if (amt2 != "12")
            {
                finl = amt + "*" + amt1 + "*" + amt2 + "/" + "1200";
            }
            else
            {
                finl = amt + "*" + amt1 + "/" + "100";
            }
        }
        lblCalcAss.Text = finl.ToString();
    }
    private int FillBalanceMonth(GridViewRow gvr, Label lblBalMthAss, int j, Label lblTrnTpAss)
    {
        int cntNullData = 0;
        if (gvr.Cells[5].Text.Trim() != "0")
        {
            if (Convert.ToInt32(lblTrnTpAss.Text) == 1)
            {
                lblBalMthAss.Text = gen.GetBalanceMonth(Convert.ToDateTime(gvr.Cells[3].Text).Month, Convert.ToDateTime(gvr.Cells[3].Text).Day).ToString();
            }
            else
            {
                lblBalMthAss.Text = gen.GetBalanceMonthWith(Convert.ToDateTime(gvr.Cells[3].Text).Month).ToString();
            }
            cntNullData = j;
        }
        else if (cntNullData > 0 && Convert.ToInt16(gvr.Cells[1].Text) == 47 && Convert.ToInt16(gvr.Cells[11].Text) == 1)
        {
            lblBalMthAss.Text = "8";
        }
        else if (cntNullData > 0 && Convert.ToInt16(gvr.Cells[1].Text) == 47 && Convert.ToInt16(gvr.Cells[11].Text) == 2)
        {
            lblBalMthAss.Text = "4";
        }
        else if (cntNullData > 0)
        {
            lblBalMthAss.Text = "12";
        }
        else
        {
            lblBalMthAss.Text = "12";
        }
        return cntNullData;
    }
    private void SaveToDB()
    {
        ArrayList ard = new ArrayList();
        ard.Add(cor.IntAccNo);
        corrD.DelCorrEntryChild(ard);
        for (int j = 0; j < gdvCalc.Rows.Count; j++)
        {
            ArrayList arr = new ArrayList();

            GridViewRow gvr = gdvCalc.Rows[j];
            Label lblCalcAss = (Label)gvr.FindControl("lblCalc");
            Label lblTotalAss = (Label)gvr.FindControl("lblTotal");
            //Label lblBalMthAss = (Label)gvr.FindControl("lblBalMth");
            //Label lblHidnAmtAss = (Label)gvr.FindControl("lblHidnAmt");
            Label lblHdnIntAmtAss = (Label)gvr.FindControl("lblHdnIntAmt");

            arr.Add(Convert.ToInt32(gvr.Cells[0].Text));     //acc no
            arr.Add(gvr.Cells[2].Text.ToString());     //chv year
            if (gvr.Cells[3].Text != "&nbsp;")
            {
                arr.Add(gvr.Cells[3].Text.ToString());     //chalan dt
            }
            else
            {
                arr.Add(DBNull.Value);     //chalan dt
            }
            arr.Add(Convert.ToDouble(gvr.Cells[5].Text));     //org amt
            arr.Add(Convert.ToDouble(gvr.Cells[4].Text));     //rt of interest
            arr.Add(Convert.ToDouble(lblHdnIntAmtAss.Text));     //interest amt
            arr.Add(Convert.ToDouble(lblTotalAss.Text));     //total
            arr.Add(lblCalcAss.Text.ToString());     //chv calc
            arr.Add(j + 1);
            corrD.SaveCorrEntryChild(arr);

        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Session["intYearIdMax"] = gen.GetCCYearId();
        //DataSet dsEmp = new DataSet();
        //dsEmp = empD.GetTotEmp4Calc();
        //if (dsEmp.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < dsEmp.Tables[0].Rows.Count; i++)
        //    {
        //        Session["intAccNoCalc"] = Convert.ToInt32(dsEmp.Tables[0].Rows[i].ItemArray[0]);
        //        CalculateCurrYr(Convert.ToInt32(Session["intAccNoCalc"]));
        //    }
        //}
        SaveCorrEntryChild();
    }
    //protected void btnOkS_Click(object sender, EventArgs e)
    //{

    //}
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        DataSet dsName = new DataSet();
        if (txtAccNo.Text != "" && txtAccNo.Text != null)
        {
            Session["intAccNoCalc"] = Convert.ToDouble(txtAccNo.Text.ToString());
            emp.NumEmpID = Convert.ToDouble(txtAccNo.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                lblAccNo.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                lblName.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                Session["flgClosed"] = Convert.ToInt16(dsName.Tables[0].Rows[0].ItemArray[2]);
            }
            else
            {
                SetGridDefault();
                lblAccNo.Text = "...";
                lblName.Text = "...";
            }
            //FillGrid();
        }
        else
        {
            gblObj.MsgBoxOk("Enter Acc. No.", this);
        }
        ddlYearCorr.SelectedValue = "0";
        SetGridDefault();
    }
    private void FillGrid()
    {
        SetGridDefault();
        DataSet dsC = new DataSet();
        emp.NumEmpID = Convert.ToInt64(Session["intAccNoCalc"]);
        //dsC = corrD.GetCorrectionEntryDet(emp);
        dsC = corrD.GetCorrectionEntryDetNw(emp);
        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvBill.DataSource = dsC;
            gdvBill.DataBind();
            for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvBill.Rows[i];
                Label lblCorrAmt = (Label)gvRw.FindControl("lblCorrAmt");
                lblCorrAmt.Text = dsC.Tables[0].Rows[i].ItemArray[5].ToString();
            }
            gblObj.SetFooterTotalsTempField(gdvBill, 10, "lblCorrAmt", 2);
        }
        else
        {
            SetGridDefault();
        }
    }
    protected void txtAccNoCa_TextChanged(object sender, EventArgs e)
    {

    }
    protected void gdvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void DeleteFromCorrEntry(ArrayList arr)
    {
        CorrectionEntryDao crrD = new CorrectionEntryDao();
        crrD.DelCorrEntry(arr);
    }
    private void FillGridNew()
    {
        SetGridDefault();
        Session["intYearIdMax"] = gen.GetCCYearId();
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["intAccNoCalc"]));
        ar.Add(Convert.ToInt64(Session["intYearIdCalc"]));
        if (Convert.ToInt16(Session["intYearIdCalc"]) <= Convert.ToInt16(Session["intYearIdMax"]))
        {
            dsC = corrD.GetCorrectionEntryDetNwLatVar(ar);
        }
        else
        {
            dsC = corrD.GetCorrectionEntryCorr(ar);
        }
        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvBill.DataSource = dsC;
            gdvBill.DataBind();
            for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvBill.Rows[i];
                Label lblSln = (Label)gvRw.FindControl("lblSln");
                lblSln.Text = (i + 1).ToString();
                double dblAmt = 0;
                //double dblCalcAmt = 0;
                dblAmt = Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[5]);
                
                //  From AG///////////
                if (Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[18]) == 4)
                {
                    gdvBill.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                    gdvBill.Rows[i].Cells[7].Font.Bold = true;
                }
                //  From AG///////////
            }
            gblObj.SetFooterTotals(gdvBill,12);
            double d = gblObj.FindGridTotal(gdvBill, 12);
            lblCons.Text = d.ToString();
        }
        else
        {
            SetGridDefault();
        }
    }
    //private void FillGridNew()
    //{
    //    SetGridDefault();
    //    DataSet dsC = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(Convert.ToInt64(Session["intAccNoCalc"]));
    //    ar.Add(Convert.ToInt64(Session["intYearIdCorr"]));
    //    dsC = corrD.GetCorrectionEntryDetNwLat(ar);
    //    if (dsC.Tables[0].Rows.Count > 0)
    //    {
    //        gdvBill.DataSource = dsC;
    //        gdvBill.DataBind();
    //        DeleteFromCorrEntry(ar);
    //        for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
    //        {
    //            int intYrId = 0;
    //            int intMth = 0;
    //            int intDy = 0;
    //            double dblAmt = 0;
    //            double dblCalcAmt = 0;
    //            int tp = 0;
    //            int intChalanId = 0;
    //            int intCorrTpe = 0;
                
    //            //////////////////////////////
    //            intMth = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[14]);
    //            intDy = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[15]);
    //            dblAmt = Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[5]);
    //            tp = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[12]);
    //            intChalanId = Convert.ToInt32(dsC.Tables[0].Rows[i].ItemArray[14]);
    //            intYrId = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]);

    //            //intYrId = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]);
    //            //if (Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]) < 50)
    //            //{
    //            //    DataSet dsy = new DataSet();
    //            //    ArrayList ary = new ArrayList();
    //            //    ary.Add(Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]));
    //            //    dsy = gen.Getyr4ABCDRpt(ary);
    //            //    if (dsy.Tables[0].Rows.Count > 0)
    //            //    {
    //            //        intYrId = Convert.ToInt16(dsy.Tables[0].Rows[0].ItemArray[0]);
    //            //    }
    //            //}
    //            //else
    //            //{
    //            //    intYrId = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]);
    //            //}
    //            //intYrId = Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]);


    //            if (Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[13]) == 1)
    //            {
    //                dblAmt = -dblAmt;
    //            }
    //            dblCalcAmt = gblObj.CalculateAdjAmt(intYrId, 52, intMth, intDy, dblAmt);
    //            GridViewRow gvRw = gdvBill.Rows[i];
    //            Label lblCorrAmt = (Label)gvRw.FindControl("lblCorrAmt");
    //            Label lblCorrType = (Label)gvRw.FindControl("lblCorrType");
    //            lblCorrAmt.Text = dblCalcAmt.ToString();
    //            lblCorrType.Text = dsC.Tables[0].Rows[i].ItemArray[16].ToString();
    //            //////////// intCorrTpe /////////////////
    //            intCorrTpe = Convert.ToInt16(lblCorrType.Text);
    //            //////////// intCorrTpe /////////////////

    //            SaveCorrectionEntry(Convert.ToInt32(txtAccNo.Text) , intChalanId, intYrId, intMth, intDy, dblCalcAmt, 200, intCorrTpe, dblAmt, dblAmt, 10, tp);
    //            ////////////////////////////////////////////////////


    //        }
    //        gblObj.SetFooterTotalsTempField(gdvBill, 10, "lblCorrAmt", 2);
    //    }
    //    else
    //    {
    //        SetGridDefault();
    //    }
    //}
    private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType, int FlgType)
    {
        CorrectionEntry crr = new CorrectionEntry();
        CorrectionEntryDao crrD = new CorrectionEntryDao();

        Session["intCCYearId"] = 52;
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
    private void FillGridCurrYr()
    {
        double dblAmtAdjusted = 0;
        SetGridDefaultNew();
        Session["intCCYearId"] = gen.GetCCYearId();
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["intAccNoCalc"]));
        ar.Add(Convert.ToInt64(Session["intYearIdCalc"]));
        dsC = gen.getCorrDetnS(ar);

        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvBillCurr.DataSource = dsC;
            gdvBillCurr.DataBind();
            for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvBillCurr.Rows[i];
                Label txtslno = (Label)gvRw.FindControl("txtslno");
                double dblAmt = 0;
                dblAmt = Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[5]);

                Label lblCorrAmt = (Label)gvRw.FindControl("lblCorrAmt");
                dblAmtAdjusted = gblObj.CalculateAdjAmt3(Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[11]), Convert.ToInt16(Session["intCCYearId"]) + 1, Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[14]), Convert.ToInt16(dsC.Tables[0].Rows[i].ItemArray[15]), dblAmt);
                lblCorrAmt.Text = dblAmtAdjusted.ToString();
                txtslno.Text = (i + 1).ToString();
            }
            gblObj.SetFooterTotals(gdvBillCurr, 9);
            gblObj.SetFooterTotalsTempField(gdvBillCurr, 10, "lblCorrAmt", 2);
        }
        else
        {
            SetGridDefaultNew();
        }

    }
    private void dd(int yrTrn, int intMth, int intDy, double dblAmtToCalc)
    {
        double dblAmtAdjusted = 0;
        Session["intCCYearId"] = gen.GetCCYearId();
        ArrayList ar = new ArrayList();
        dblAmtAdjusted = gblObj.CalculateAdjAmt(yrTrn, Convert.ToInt16(Session["intCCYearId"]) + 1, intMth, intDy, dblAmtToCalc);
    }

    //Ranjitha
    protected void btnViewAll_Click(object sender, EventArgs e)
    {

        if (ddlYearCorr.SelectedIndex > 0)
        {
            Session["intYearIdCalc"] = Convert.ToInt16(ddlYearCorr.SelectedValue);

            gdvBill.Visible = true;
            gdvBillCurr.Visible = false;
            lblCons.Text = "0";
            FillGridNew_YearWise();
        }
        else
        {
            Session["intYearIdCorr"] = 0;
        }

    }

    //Ranjitha
    private void FillGridNew_YearWise()
    {
        SetGridDefault();
        //   Session["intYearIdMax"] = gen.GetCCYearId();
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();

        ar.Add(Convert.ToInt64(Session["intYearIdCalc"]));
        {
            dsC = corrD.GetCorrectionEntryCorr_YearWise(ar);

            if (dsC.Tables[0].Rows.Count > 0)
            {
                gdvBill.DataSource = dsC;
                gdvBill.DataBind();
                for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
                {
                    GridViewRow gvRw = gdvBill.Rows[i];
                    Label lblSln = (Label)gvRw.FindControl("lblSln");
                    lblSln.Text = (i + 1).ToString();
                    double dblAmt = 0;
                    //double dblCalcAmt = 0;
                    dblAmt = Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[5]);

                    //  From AG///////////
                    if (Convert.ToDouble(dsC.Tables[0].Rows[i].ItemArray[18]) == 4)
                    {
                        gdvBill.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                        gdvBill.Rows[i].Cells[7].Font.Bold = true;
                    }
                    //  From AG///////////
                }
                //   gblObj.SetFooterTotals(gdvBill, 12);
                //  double d = gblObj.FindGridTotal(gdvBill, 12);
                //  lblCons.Text = d.ToString();
            }
            else
            {
                SetGridDefault();
            }
        }
    }
   


    protected void ddlYearCorr_SelectedIndexChanged(object sender, EventArgs e)
    {
        int y = Convert.ToInt16(Session["intYearIdMax"]);
        if (ddlYearCorr.SelectedIndex > 0)
        {
            Session["intYearIdCalc"] = Convert.ToInt16(ddlYearCorr.SelectedValue);

            gdvBill.Visible = true;
            gdvBillCurr.Visible = false;
            lblCons.Text = "0";
            FillGridNew();            
        }
        else
        {
            Session["intYearIdCorr"] = 0;
        }
 
    }
    //private void FillGridSched()
    //{
    //    Chalan chal = new Chalan();
    //    ScheduleDAO schDao = new ScheduleDAO();

    //    DataSet dsSched = new DataSet();
    //    ArrayList ar = new ArrayList();

    //    chal.NumChalanId = 1254;
    //    ar.Add(chal.NumChalanId);
    //    dsSched = schDao.CheckScheduleExist(ar);
    //    if (dsSched.Tables[0].Rows.Count > 0)
    //    {
    //        gdvAOApprovSched.DataSource = dsSched;
    //        gdvAOApprovSched.DataBind();

    //        for (int i = 0; i < dsSched.Tables[0].Rows.Count; i++)
    //        {
    //            GridViewRow gdv = gdvAOApprovSched.Rows[i];
    //            Label lblSlNoAss = (Label)gdv.FindControl("lblSlNo");
    //            lblSlNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

    //            //FillGridCmb(gdv, "ddlGO");
    //            //FillGridCmbM(gdv, "ddlFm", "ddlTm");

    //            TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
    //            txtAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[0].ToString();

    //            Label lblNameAss = (Label)gdv.FindControl("lblName");
    //            lblNameAss.Text = dsSched.Tables[0].Rows[i].ItemArray[1].ToString();

    //            CheckBox chkUnIdentAss = (CheckBox)gdv.FindControl("chkUnIdent");
    //            if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[9]) == 1)
    //            {
    //                chkUnIdentAss.Checked = true;
    //            }
    //            else
    //            {
    //                chkUnIdentAss.Checked = false;
    //            }
    //            TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
    //            txtSubnAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();
    //            TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
    //            txtRepAss.Text = dsSched.Tables[0].Rows[i].ItemArray[3].ToString();
    //            TextBox txtPfAss = (TextBox)gdv.FindControl("txtPf");
    //            txtPfAss.Text = dsSched.Tables[0].Rows[i].ItemArray[4].ToString();
    //            TextBox txtDaAss = (TextBox)gdv.FindControl("txtDa");
    //            txtDaAss.Text = dsSched.Tables[0].Rows[i].ItemArray[5].ToString();
    //            TextBox txtPayAss = (TextBox)gdv.FindControl("txtPay");
    //            txtPayAss.Text = dsSched.Tables[0].Rows[i].ItemArray[6].ToString();
    //            Label lblTotalAss = (Label)gdv.FindControl("lblTotal");
    //            lblTotalAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();



    //            //Label lblSchedMainAss = (Label)gdv.FindControl("lblSchedMain");
    //            //lblSchedMainAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

    //            Label lblSchedAss = (Label)gdv.FindControl("lblSched");
    //            lblSchedAss.Text = dsSched.Tables[0].Rows[i].ItemArray[14].ToString();

    //            Label lblAccNoAss = (Label)gdv.FindControl("lblAccNo");
    //            lblAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[12].ToString();

    //            Label lblNewAccAss = (Label)gdv.FindControl("lblNewAcc");
    //            lblNewAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[12].ToString();

    //            Label lblNewTotAss = (Label)gdv.FindControl("lblNewTot");
    //            lblNewTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();

    //            //Label lblEditModeSAss = (Label)gdv.FindControl("lblEditModeS");
    //            //lblEditModeSAss.Text = "0";

    //            //Label lblRecNoAss = (Label)gdv.FindControl("lblRecNo");
    //            //lblRecNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

    //            Label lblOTotAss = (Label)gdv.FindControl("lblOTot");
    //            lblOTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();

    //            Label lblOAccAss = (Label)gdv.FindControl("lblOAcc");
    //            lblOAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[12].ToString();

    //            //intMaxRecNo = Convert.ToInt16(lblRecNoAss.Text.ToString());

    //            DropDownList ddlGoAss = (DropDownList)gdv.FindControl("ddlGo");
    //            ddlGoAss.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

    //            DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");
    //            ddlFm.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[17].ToString();

    //            DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
    //            ddlTm.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[18].ToString();
    //        }

    //    }

    //}
}
