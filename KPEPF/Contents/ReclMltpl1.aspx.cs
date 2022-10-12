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

public partial class Contents_ReclMltpl1 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Convert.ToInt16(Request.QueryString["intMonthId"]) > 0)
            {
                Session["intMonthIdRecMltpl"] = Convert.ToInt16(Request.QueryString["intMonthId"]);
                FillTreasDet();
                //FillPfo();
                //FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]));
            }
            else if (Convert.ToInt16(Session["intMonthIdRecMltpl"]) > 0)    //Back frm Det
            {
                FillTreasDet();
            }
            else
            {
                InitialSettings();
            }

        }
    }
    private void InitialSettings()
    {
        //Session["intYearIdRecMltpl"] = 18;
        //Session["intTrnType"] = 1;
        //SetGridsDefault();
        //FillAg();
        //FillPfo();
        //FillPfoM(Convert.ToInt16(Session["intYearIdRecMltpl"]));
    }
    //private void SetGridsDefault()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("chvTreasuryName");
    //    ar.Add("intDTreasuryId");

    //    ar.Add("CrPostedT");
    //    //ar.Add("PostedAG");
    //    ar.Add("CrPostedAG");
    //    ar.Add("TotP");
    //    ar.Add("CrUnpostedT");
    //    ar.Add("UnpostedAG");
    //    ar.Add("TotUP");

    //    ar.Add("Tot");
    //    gblObj.SetGridDefault(gdvRecM, ar);
    //}
    private void FillTreasDet()
    {
        DataSet dsRecM = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIdRecMltpl"]);
        rec.IntMonthId = Convert.ToInt16(Session["intMonthIdRecMltpl"]);
        rec.IntTrnType = Convert.ToInt16(Session["intTrnType"]);
        dsRecM = recd.GetTreasuryDataMonthWise(rec);
        if (dsRecM.Tables[0].Rows.Count > 0)
        {
            gdvRecM.DataSource = dsRecM;
            gdvRecM.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecM, 1, 7);

        //Display Month//
        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["intYearIdRecMltpl"]));
        lblYearD2.Text = gen.GetYearFromIdPde(ar1);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdRecMltpl"]));
        lblYearD.Text = gen.GetMonthFromId(ar);
        //Display Month//
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/ReclMltpl.aspx";
    }
    protected void gdvRecM_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr1 = e.Row;
        //gblObj.MergeCellsMltpl(gdvRecM, gvr1, 7, 2, 4, 5, 7, "Posted", "Unposted");    
        //gblObj.MergeCellsSingle(gdvRecM, gvr1, 7, 1, 3, "Posted", e);
        gblObj.MergeCells(gdvRecM, gvr1, 7, 1, 3, 4, 6, "Posted", "Unposted",e); 
    }
    protected void btnDet_Click1(object sender, EventArgs e)
    {
        btnDet.PostBackUrl = "~/Contents/ReclMltpl2.aspx";
    }
}
