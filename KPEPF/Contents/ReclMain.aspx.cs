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

public partial class Contents_ReclMain : System.Web.UI.Page
{
    KPEPFGeneralDAO gendao = new KPEPFGeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();
        }
    }
    private void InitialSettings()
    {
        FillCombo();
        SetGridDefault();
        SetGridDefaultAG();

        SetGridDefault2();
        SetGridDefaultAG2();

        SetGridDefault3();
        SetGridDefaultAG3();
    }
    private void FillCombo()
    {
        DataSet ds = new DataSet();
        ds = gendao.GetYearOnLineNdPDE();
        gblObj.FillCombo(ddlYear, ds, 1);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIDRec"] = int.Parse(ddlYear.SelectedValue.ToString());
            FillTGrid1();           //From TB_LedgerDet_TRN
            FillAGGrid1();          //From TB_LedgerDet_TRN

            FillTGrid2();           //From AP_RecLevl3New
            FillAGGrid2();          //From AP_RecLevl3New

            FillTGrid3();           //From AP_RecLevl3New
            FillAGGrid3();          //From AP_RecLevl3New

            FillLedgerLbls();

        }
        else
        {
            Session["intYearIDRec"] = 0;
        }
    }
    private void FillLedgerLbls()
    {
        DataSet dsr = new DataSet();
        DataSet dsrL = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        rec.IntSource = 1;
        dsr = recd.GetReclOB(rec);
        if (dsr.Tables[0].Rows.Count > 0)
        {
            lblOb.Text = dsr.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        dsrL = recd.GetReclLedgerData(rec);
        if (dsrL.Tables[0].Rows.Count > 0)
        {
            lblInt.Text = dsrL.Tables[0].Rows[0].ItemArray[5].ToString();
            lblWith.Text = dsrL.Tables[0].Rows[0].ItemArray[4].ToString();
            lblRem.Text = dsrL.Tables[0].Rows[0].ItemArray[3].ToString();
            lblTot.Text = Convert.ToString(Convert.ToDouble(lblOb.Text.ToString()) + Convert.ToDouble(lblRem.Text.ToString()) + Convert.ToDouble(lblInt.Text.ToString()));
            lblCb.Text = dsrL.Tables[0].Rows[0].ItemArray[6].ToString();
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvShortMonth");
        ar.Add("RemAmtBfr4T");
        ar.Add("RemAmtAftr4T");
        ar.Add("total");
        ar.Add("WithAmtT");
        gblObj.SetGridDefault(gdvRecT1, ar);
    }
    private void SetGridDefault2()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvShortMonth");
        ar.Add("fltMisClassBfr");
        ar.Add("fltMisClassAftr");
        ar.Add("fltMisClassTA");
        ar.Add("total");
        gblObj.SetGridDefault(gdvRecT2, ar);
    }
    private void SetGridDefault3()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvShortMonth");
        ar.Add("fltMissingSchedBfr");
        ar.Add("fltMissingSchedAftr");
        ar.Add("fltMissingSchedTA");
        ar.Add("total");
        gblObj.SetGridDefault(gdvRecT3, ar);
    }
    private void SetGridDefaultAG()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvShortMonth");
        ar.Add("RemAmt");
        ar.Add("totalAmt");
        ar.Add("PostedAGCrPlusBfr18");
        ar.Add("fltWithdrawAmt");
        gblObj.SetGridDefault(gdvRecAG1, ar);
    }
    private void SetGridDefaultAG2()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvShortMonth");
        ar.Add("fltMisClassBfr");
        ar.Add("PostedAGCrPlusBfr18");
        ar.Add("fltMisClassTA");
        ar.Add("total");
        gblObj.SetGridDefault(gdvRecAG2, ar);
    }
    private void SetGridDefaultAG3()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvShortMonth");
        ar.Add("fltMissingSchedBfr");
        ar.Add("fltMissingSchedAftr");
        ar.Add("fltMissingSchedTA");
        ar.Add("total");
        gblObj.SetGridDefault(gdvRecAG3, ar);
    }
    private void FillTGrid1()
    {
        DataSet dsT1 = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        if (Convert.ToInt16(Session["intYearIDRec"]) <= 49)
        {
            dsT1 = recd.GetReclT1(rec);
        }
        else
        {
            dsT1 = recd.GetReclT150(rec);
        }
        if (dsT1.Tables[0].Rows.Count > 0)
        {
            gdvRecT1.DataSource = dsT1;
            gdvRecT1.DataBind();
        }
        gblObj.SetFooterTotals(gdvRecT1, 1);
        gblObj.SetFooterTotals(gdvRecT1, 2);
        gblObj.SetFooterTotals(gdvRecT1, 3);
        gblObj.SetFooterTotals(gdvRecT1, 4);
    }
    private void FillTGrid2()
    {
        DataSet dsT1 = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        dsT1 = recd.GetReclT2(rec);
        if (dsT1.Tables[0].Rows.Count > 0)
        {
            gdvRecT2.DataSource = dsT1;
            gdvRecT2.DataBind();
        }
        gblObj.SetFooterTotals(gdvRecT2, 1);
        gblObj.SetFooterTotals(gdvRecT2, 2);
        gblObj.SetFooterTotals(gdvRecT2, 3);
        gblObj.SetFooterTotals(gdvRecT2, 4);
    }
    private void FillTGrid3()
    {
        DataSet dsT3 = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        dsT3 = recd.GetReclT3(rec);
        if (dsT3.Tables[0].Rows.Count > 0)
        {
            gdvRecT3.DataSource = dsT3;
            gdvRecT3.DataBind();
        }
        gblObj.SetFooterTotals(gdvRecT3, 1);
        gblObj.SetFooterTotals(gdvRecT3, 2);
        gblObj.SetFooterTotals(gdvRecT3, 3);
        gblObj.SetFooterTotals(gdvRecT3, 4);
    }
    private void FillAGGrid1()
    {
        DataSet dsAg1 = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        if (Convert.ToInt16(Session["intYearIDRec"]) <= 49)
        {
            dsAg1 = recd.GetReclAg1(rec);
        }
        else
        {
            dsAg1 = recd.GetReclAg150(rec);
        }
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAG1.DataSource = dsAg1;
            gdvRecAG1.DataBind();
        }
        gblObj.SetFooterTotals(gdvRecAG1, 1);
        gblObj.SetFooterTotals(gdvRecAG1, 2);
        gblObj.SetFooterTotals(gdvRecAG1, 3);
        gblObj.SetFooterTotals(gdvRecAG1, 4);
    }
    private void FillAGGrid2()
    {
        DataSet dsAg1 = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        dsAg1 = recd.GetReclAg2(rec);
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAG2.DataSource = dsAg1;
            gdvRecAG2.DataBind();
        }
        gblObj.SetFooterTotals(gdvRecAG2, 1);
        gblObj.SetFooterTotals(gdvRecAG2, 2);
        gblObj.SetFooterTotals(gdvRecAG2, 3);
        gblObj.SetFooterTotals(gdvRecAG2, 4);
    }
    private void FillAGGrid3()
    {
        DataSet dsAg1 = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
        dsAg1 = recd.GetReclAg3(rec);
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAG3.DataSource = dsAg1;
            gdvRecAG3.DataBind();
        }
        gblObj.SetFooterTotals(gdvRecAG3, 1);
        gblObj.SetFooterTotals(gdvRecAG3, 2);
        gblObj.SetFooterTotals(gdvRecAG3, 3);
        gblObj.SetFooterTotals(gdvRecAG3, 4);
    }
    protected void gdvRecT1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCellsSingle(gdvRecT1, gvr, 4, 1, 3, "Credit",  e);
    }
    protected void gdvRecAG1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCellsSingle(gdvRecAG1, gvr, 4, 1, 3, "Credit_Posted_AG", e);
    }

    protected void gdvRecT2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCellsSingle(gdvRecT2, gvr, 4,1, 3,  "Credit_Suspense Acc and Other PF",  e);
    }
    protected void gdvRecAG2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCellsSingle(gdvRecAG2, gvr, 4, 1, 3, "Credit_Suspense Acc and Other PF_AG", e);
    }

    protected void gdvRecT3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCellsSingle(gdvRecT3, gvr, 4, 1, 3,"Credit_Missing Schedule",e);
    }
    protected void gdvRecAG3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCellsSingle(gdvRecAG3, gvr, 4, 1, 3, "Credit_Missing Schedule_AG", e);
    }
    protected void gdvRecT1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = gdvRecT1.Rows.Count - 1; i > 0; i--)
        {
            GridViewRow row = gdvRecT1.Rows[i];
            GridViewRow previousRow = gdvRecT1.Rows[i - 1];
            for (int j = 0; j < row.Cells.Count; j++)
            {
                if (row.Cells[j].Text == previousRow.Cells[j].Text)
                {
                    if (previousRow.Cells[j].RowSpan == 0)
                    {
                        if (row.Cells[j].RowSpan == 0)
                        {
                            previousRow.Cells[j].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                        }
                        row.Cells[j].Visible = false;
                    }
                }
            }
        }
    }

}
