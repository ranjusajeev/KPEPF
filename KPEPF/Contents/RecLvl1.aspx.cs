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

public partial class Contents_RecLvl1 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    GeneralDAO gen = new GeneralDAO();
    Recl rec = new Recl();
    ReclDao recD = new ReclDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();
            if (Convert.ToInt16(Request.QueryString["intYearId"]) > 0)
            {
                FillTxts();
            }
            //if (Convert.ToInt16(Session["intTrnType"]) != 10 && Convert.ToInt16(Session["intTrnType"]) != 11 && Convert.ToInt16(Session["intTrnType"]) != 15)
            //{
            //    if (txtFile.Text.ToString() == "")      //To fill txt nd grid on back to view frm page
            //    {
            //        txtFile.Text = gblObj.StrFileNo;
            //    }
            //    FindSerTrnId();
            //    FillTrnDetails();
            //}
        }
    }
    private void FillTxts()
    {
        DataSet dsat = new DataSet();
        rec.IntYearId = Convert.ToInt16(Request.QueryString["intYearId"]);
        rec.IntSource = 1;
        dsat = recD.GetLedgerFromAGTxts(rec);
        if (dsat.Tables[0].Rows.Count > 0)
        {
            ddlYear.SelectedValue = dsat.Tables[0].Rows[0].ItemArray[7].ToString();
            txtOb.Text = dsat.Tables[0].Rows[0].ItemArray[1].ToString();
            txtCr.Text = dsat.Tables[0].Rows[0].ItemArray[2].ToString();
            txtInt.Text = dsat.Tables[0].Rows[0].ItemArray[4].ToString();
            txtDt.Text = dsat.Tables[0].Rows[0].ItemArray[3].ToString();
            txtCb.Text = dsat.Tables[0].Rows[0].ItemArray[5].ToString();
            txtYr.Text = rec.IntYearId.ToString();
        }
    }
    private void InitialSettings()
    {
        DataSet dsyr = new DataSet();
        dsyr = gen.GetYear();
        gblObj.FillCombo(ddlYear, dsyr, 1);
        SetGridDefault1();
        //SetGridDefault2();
        FillGrid(1);
        FillGrid(2);
    }
    private void FillGrid(int flg)
    {
        ArrayList ar = new ArrayList();
        DataSet dsa = new DataSet();
        ar.Add(flg);
        dsa = recD.GetLedgerFromAG(ar);
        if (flg == 1)
        {
            gdvRecM.DataSource = dsa;
            gdvRecM.DataBind();
        }
        else
        {
            gdvRecMPFO.DataSource = dsa;
            gdvRecMPFO.DataBind();
        }
    }

    //private void FillGridAG()
    //{
    //    ArrayList ar = new ArrayList();
    //    DataSet dsa = new DataSet();
    //    ar.Add(1);
    //    dsa = recD.GetLedgerFromAG(ar);
    //    gdvRecM.DataSource = dsa;
    //    gdvRecM.DataBind();
    //}
    //private void FillGridPFO()
    //{
    //    ArrayList arp = new ArrayList();

    //}
    private void SetGridDefault1()
    {
        ArrayList ar1 = new ArrayList();
        ar1.Add("chvYear");
        ar1.Add("fltOB");
        ar1.Add("fltCr");
        ar1.Add("fltDt");
        ar1.Add("fltInterest");
        ar1.Add("fltCB");
        ar1.Add("intYearId");
        ar1.Add("intSource");
        gblObj.SetGridDefault(gdvRecM, ar1);
    }
    private void SetGridDefault2()
    {
        ArrayList ar2 = new ArrayList();
        ar2.Add("chvYear");
        ar2.Add("fltOB");
        ar2.Add("fltCr");
        ar2.Add("fltDt");
        ar2.Add("fltInterest");
        ar2.Add("fltCB");
        ar2.Add("intYearId");
        ar2.Add("intSource");
        gblObj.SetGridDefault(gdvRecMPFO, ar2);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ClearTxts();
    }
    private void ClearTxts()
    {
        ddlYear.SelectedValue = "0";
        txtDt.Text = "0";
        txtOb.Text = "0";
        txtInt.Text = "0";
        txtCr.Text = "0";
        txtCb.Text = "0";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intYearRecL"]) > 0)
        {
            rec.IntYearId = Convert.ToInt16(Session["intYearRecL"]);
        }
        else
        {
            rec.IntYearId = Convert.ToInt16(txtYr.Text);
        }
        rec.IntSource = 1;
        rec.FltOB = Convert.ToDouble(txtOb.Text);
        rec.FltCr = Convert.ToDouble(txtCr.Text);
        rec.FltDt = Convert.ToDouble(txtDt.Text);
        rec.FltInt = Convert.ToDouble(txtInt.Text);
        rec.FltCB = Convert.ToDouble(txtCb.Text);
        recD.SaveLedgerYearly(rec);
        gblObj.MsgBoxOk("Added!", this);

        FillGrid(1);

        //rec.IntYearId = Convert.ToInt16(Session["intYearRecL"]);
        //rec.IntSource = 1;
        //rec.FltOB = Convert.ToDouble(txtOb.Text);
        //rec.FltOB = Convert.ToDouble(txtCr.Text);
        //rec.FltOB = Convert.ToDouble(txtDt.Text);
        //rec.FltOB = Convert.ToDouble(txtInt.Text);
        //rec.FltOB = Convert.ToDouble(txtCb.Text);

        //recD.SaveLedgerYearly(rec);
        //gblObj.MsgBoxOk("Added!", this);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["intYearRecL"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearRecL"] = 0;
        }
    }
    protected void btnPfo_Click(object sender, EventArgs e)
    {
        recD.SaveLedgerYearlyPFO();

    }
}
