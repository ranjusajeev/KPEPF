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

public partial class Contents_ReclNew : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["intTrnType"] = 1;
            if (Convert.ToInt16(Request.QueryString["intYearId"]) == 0 && Convert.ToInt16(Request.QueryString["intYearIdAG"]) == 0)
            {
                InitialSettings();
            }
            //rdTrnType.Items[Convert.ToInt16(Session["intTrnType"]) - 1].Selected = true;

            if (Convert.ToInt16(Request.QueryString["intYearId"]) > 0)
            {
                Session["intYearIdRecMltpl"] = Convert.ToInt16(Request.QueryString["intYearId"]);
                FillAg();

                FillAgSplit(Convert.ToInt16(Session["intYearIdAG"]));
                FillPfo(Convert.ToInt16(Session["intTrnType"]));
                FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]), Convert.ToInt16(Session["intTrnType"]));
                lblYearD.Text = getYear(Convert.ToInt16(Session["intYearIdRecMltpl"]));
                SetColorChange(Convert.ToInt16(Session["intYearIdRecMltpl"]));
                SetColorChangeAg(Convert.ToInt16(Session["intYearIdAG"]));
            }
            if (Convert.ToInt16(Request.QueryString["intYearIdAGW"]) > 0)
            {
                Session["intYearIdRecMltplW"] = Convert.ToInt16(Request.QueryString["intYearIdAGW"]);
                FillAg();
                FillAgSplitW(Convert.ToInt16(Session["intYearIdRecMltplW"]));
                FillPfo(Convert.ToInt16(Session["intTrnType"]));
                FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]), Convert.ToInt16(Session["intTrnType"]));
                lblYearD.Text = getYear(Convert.ToInt16(Session["intYearIdRecMltpl"]));
                SetColorChange(Convert.ToInt16(Session["intYearIdRecMltpl"]));
                SetColorChangeAg(Convert.ToInt16(Session["intYearIdRecMltplW"]));
            }

            if (Convert.ToInt16(Request.QueryString["intYearIdAG"]) > 0)
            {
                Session["intYearIdAG"] = Convert.ToInt16(Request.QueryString["intYearIdAG"]);
                FillAg();
                FillAgSplit(Convert.ToInt16(Session["intYearIdAG"]));
                FillPfo(Convert.ToInt16(Session["intTrnType"]));
                FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]), Convert.ToInt16(Session["intTrnType"]));
                lblYearD.Text = getYear(Convert.ToInt16(Session["intYearIdRecMltpl"]));
                SetColorChange(Convert.ToInt16(Session["intYearIdRecMltpl"]));
                SetColorChangeAg(Convert.ToInt16(Session["intYearIdAG"]));
            }
            setRdBtn();

        }
        else
        {
            //// Debit /////////////
            if (Convert.ToInt16(Session["intMonthIdRecMltpl"]) == 0)   //Fill on Back from Treasury Det
            {
                Session["intYearIdRecMltpl"] = 50;
            }
            //Session["intTrnType"] = 2;
            SetGridsDefault();
            FillAg();
            gdvRecAgDt.Visible = false;
            FillAgSplit(50);
            FillPfo(Convert.ToInt16(Session["intTrnType"]));
            FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]), Convert.ToInt16(Session["intTrnType"]));
            SetColorChange(51);
            SetColorChangeAg(51);
            //setRdBtn();
            //// Debit /////////////
        }
    }
    private void SetColorChange(int yrid)
    {
        gdvRecPF.Rows[yrid - 50].BackColor = System.Drawing.Color.Bisque;
    }
    private void SetColorChangeAg(int yrid)
    {
        if (yrid == 0)
        {
            yrid = 50;
        }
        gdvRecAg.Rows[yrid - 50].BackColor = System.Drawing.Color.Bisque;
    }
    private string getYear(int yr)
    {
        String strYr = "";
        ArrayList ary = new ArrayList();
        ary.Add(yr);
        strYr=gen.GetYearFromId(ary);
        return strYr;
    }
    private void InitialSettings()
    {
        if (Convert.ToInt16(Session["intMonthIdRecMltpl"]) == 0)   //Fill on Back from Treasury Det
        {
            Session["intYearIdRecMltpl"] = 50;
        }
        //Session["intTrnType"] = 1;
        if (Convert.ToInt16(Session["intTrnType"]) == 0)
        {
            Session["intTrnType"] = 1;
        }
        //else
        //{
        //    rdTrnType.Items[1].Selected = true;
        //}
        SetGridsDefault();
        FillAg();
        gdvRecAgDt.Visible = false;
        FillAgSplit(50);
        FillPfo(Convert.ToInt16(Session["intTrnType"]));
        FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]), Convert.ToInt16(Session["intTrnType"]));
        SetColorChange(50);
        SetColorChangeAg(50);
        //int f = Convert.ToInt16(Session["intTrnType"]);
        //if (f > 0)
        //{
        //    rdTrnType.Items[Convert.ToInt16(Session["intTrnType"]) - 1].Selected = true;
        //}
        //else
        //{
        //    rdTrnType.Items[Convert.ToInt16(Session["intTrnType"]) - 1].Selected = true;
        //}
    }
    private void FillAgSplit(int yr)
    {
        if (yr == 0)
        {
            yr = 50;
        }
        gdvRecAgCr.Visible = true;
        gdvRecAgDt.Visible = false;
        DataSet dsAg1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(yr);
        dsAg1 = recd.GetAGDataSplitCurr(arr);
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAgCr.DataSource = dsAg1;
            gdvRecAgCr.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecAgCr, 1, 3);
        lblYearDAG.Text = gen.GetYearFromIdPde(arr);

        //if (Convert.ToInt16(Request.QueryString["intTp"]) == 1)
        //{
        //    lblTrnTp.Text = "Credit";
        //}
        //else
        //{
        //    lblTrnTp.Text = "Debit";
        //}
        lblYrAGCr.Text = gen.GetYearFromId(arr);
    }
    private void FillAgSplitW(int yr)
    {
        gdvRecAgCr.Visible = false;
        gdvRecAgDt.Visible = true;
        DataSet dsAg1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(yr);
        dsAg1 = recd.GetAGDataSplitCurr(arr);
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAgDt.DataSource = dsAg1;
            gdvRecAgDt.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecAgDt, 1, 3);
        lblYearDAG.Text = gen.GetYearFromIdPde(arr);

        //if (Convert.ToInt16(Request.QueryString["intTp"]) == 1)
        //{
        //    lblTrnTp.Text = "Credit";
        //}
        //else
        //{
        //    lblTrnTp.Text = "Debit";
        //}
        lblYrAGCr.Text = gen.GetYearFromId(arr);
    }
    protected void rdTrnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdTrnType.Items[0].Selected == true)
        {
            Session["intTrnType"] = 1;
            lblTrnTp.Text = "Credit";
        }
        else
        {
            Session["intTrnType"] = 2;
            lblTrnTp.Text = "Debit";
        }
        FillAg();
        FillPfo(Convert.ToInt16(Session["intTrnType"]));
        FillPfoM(50, Convert.ToInt16(Session["intTrnType"]));
    }
    private void setRdBtn()
    {
        if (Convert.ToInt16(Session["intTrnType"])==1)
        {
            rdTrnType.Items[0].Selected = true;
        }
        else
        {
            rdTrnType.Items[1].Selected = true;
        }
    }
    private void FillPfoM(int yr, int tp)
    {
        DataSet dsRecM = new DataSet();
        rec.IntYearId = yr;
        rec.IntTrnType = tp;
        dsRecM = recd.GetPfoDataMonthWiseCurrNew(rec);

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
    private void FillAg()
    {
        DataSet dsAg1 = new DataSet();

        dsAg1 = recd.GetAGDataCurr();
        if (dsAg1.Tables[0].Rows.Count > 0)
        {
            gdvRecAg.DataSource = dsAg1;
            gdvRecAg.DataBind();
        }
    }
    private void FillPfo(int tp)
    {
        DataSet dsAg1 = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(tp);
        dsAg1 = recd.GetPfoDataCurr(ar);
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
        ar.Add("amountAGRem");
        ar.Add("amountAGWith");
        ar.Add("intYearId");
        gblObj.SetGridDefault(gdvRecAg, ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add("chvYear");
        ar1.Add("amtTP");
        ar1.Add("amtAP");
        ar1.Add("amtPTot");
        ar1.Add("amtTUP");
        ar1.Add("amtAUP");
        ar1.Add("amtUPTot");
        ar1.Add("gTot");
        ar1.Add("intYearId");
        gblObj.SetGridDefault(gdvRecPF, ar1);

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

}