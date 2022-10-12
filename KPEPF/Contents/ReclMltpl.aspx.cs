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

public partial class Contents_ReclMltpl : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Convert.ToInt16(Request.QueryString["intYearId"]) > 0)
            {
                Session["intYearIdRecMltpl"] = Convert.ToInt16(Request.QueryString["intYearId"]);
                FillAg();
                FillAgSplit(Convert.ToInt16(Session["intYearIdAG"]));
                FillPfo();
                FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]));
            }
            if (Convert.ToInt16(Request.QueryString["intYearIdAG"]) > 0)
            {
                Session["intYearIdAG"] = Convert.ToInt16(Request.QueryString["intYearIdAG"]);
                FillAg();
                FillAgSplit(Convert.ToInt16(Session["intYearIdAG"]));
                FillPfo();
                FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]));
            }
            if (Convert.ToInt16(Request.QueryString["intYearId"]) == 0 && Convert.ToInt16(Request.QueryString["intYearIdAG"]) == 0)
            {
                InitialSettings();
            }
            //else
            //{
            //    InitialSettings();
            //}
            //Session["flgPageBack"] = 1;
            //if (Convert.ToInt16(Session["flgFilterMode"]) > 0)
            //{
            //    FillBack();
            //}
            //else
            //{

            //}
        }
    }
    private void FillPfoM(int yr)
    {
        DataSet dsRecM = new DataSet();
        rec.IntYearId = yr;
        rec.IntTrnType = Convert.ToInt16(Session["intTrnType"]);
        dsRecM = recd.GetPfoDataMonthWise(rec);
        if (dsRecM.Tables[0].Rows.Count > 0)
        {
            gdvRecM.DataSource = dsRecM;
            gdvRecM.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecM, 1, 7);

        //Display year//
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearIdRecMltpl"]));
        lblYearD.Text = gen.GetYearFromIdPde(ar);
        //Display year//
    }
    protected void rdTrnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdTrnType.Items[0].Selected == true)
        {
            Session["intTrnType"] = 1;
        }
        else
        {
            Session["intTrnType"] = 2;
        }
        FillAg();
        FillPfo();
        FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]));
    }
    private void InitialSettings()
    {
        //rdTrnType.Items[0].Selected = true;
        //Session["intTrnType"] = 1;
        //Session["flgFilterMode"] = 1;
        //pnlNo.Visible = true;
        //pnlLb.Visible = false;
        //pnlTreas.Visible = false;
        //FillDdls(1);
        if (Convert.ToInt16(Session["intMonthIdRecMltpl"]) == 0)   //Fill on Back from Treasury Det
        {
            Session["intYearIdRecMltpl"] = 18;
        }
        Session["intTrnType"] = 1;
        SetGridsDefault();
        FillAg();
        FillAgSplit(44);
        FillPfo();
        FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]));
    }
    private void FillAg()
    {
        DataSet dsAg1 = new DataSet();

        dsAg1 = recd.GetAGData();
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAg.DataSource = dsAg1;
            gdvRecAg.DataBind();
        }
    }
    private void FillPfo()
    {
        DataSet dsAg1 = new DataSet();
        rec.IntTrnType = Convert.ToInt16(Session["intTrnType"]);
        dsAg1 = recd.GetPfoData(rec);
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecPF.DataSource = dsAg1;
            gdvRecPF.DataBind();
        }
        
    }
    private void SetGridsDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("chvYear");
        ar.Add("TotAmtCr");
        ar.Add("TotAmtDt");
        ar.Add("intYearId");
        ar.Add("int1");
        ar.Add("int2");
        gblObj.SetGridDefault(gdvRecAg, ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add("chvYear");
        ar1.Add("PostedT");
        ar1.Add("PostedAG");
        ar1.Add("UnpostedT");
        ar1.Add("UnpostedAG");
        ar1.Add("intYearId");
        ar1.Add("TotP");
        ar1.Add("TotAg");
        ar1.Add("GTot");
        gblObj.SetGridDefault(gdvRecPF, ar1);

        //ArrayList ar2 = new ArrayList();
        //ar2.Add("chvMonth");
        //ar2.Add("CrPostedT");
        //ar2.Add("CrUnpostedT");
        //ar2.Add("CrPostedAG");
        //ar2.Add("CrUnpostedAG");
        //gblObj.SetGridDefault(gdvRecM, ar2);
    }
    protected void gdvRecPF_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCells(gdvRecPF, gvr, 7, 1, 3, 4, 6, "Posted", "Unposted", e);
    }
    protected void gdvRecM_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr1 = e.Row;
        gblObj.MergeCells(gdvRecM, gvr1, 7, 1, 3, 4, 6, "Posted", "Unposted", e);
    }
    protected void gdvRecAGMth_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr2 = e.Row;
        gblObj.MergeCells(gdvRecAGMth, gvr2, 7, 1, 3, 4, 6, "Credit", "Debit", e);
    }
    private void FillAgSplit(int yr)
    {
        //DataSet dsAg1 = new DataSet();
        //ArrayList arr = new ArrayList();
        //arr.Add(yr);
        //dsAg1 = recd.GetAGDataSplit(arr);
        //if (dsAg1.Tables[0].Rows.Count > 0)
        //{
        //    gdvRecAGMth.DataSource = dsAg1;
        //    gdvRecAGMth.DataBind();
        //}
        //gblObj.SetFooterTotalsMltpl(gdvRecAGMth, 1, 7);
        //lblYearDAG.Text = gen.GetYearFromIdPde(arr);

        DataSet dsAg1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(yr);
        dsAg1 = recd.GetAGDataSplit(arr);
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAgCr.DataSource = dsAg1;
            gdvRecAgCr.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecAgCr, 1, 3);
        lblYearDAG.Text = gen.GetYearFromIdPde(arr);

        if (Convert.ToInt16(Request.QueryString["intTp"]) == 1)
        {
            lblTrnTp.Text = "Credit";
        }
        else
        {
            lblTrnTp.Text = "Debit";
        }
        lblYrAGCr.Text = gen.GetYearFromId(arr);
    }
    protected void gdvRecPF_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //gblObj.Setdd(e);
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[0].Visible = false;
        //    e.Row.Cells[7].Visible = false;
        //}
    }

}
