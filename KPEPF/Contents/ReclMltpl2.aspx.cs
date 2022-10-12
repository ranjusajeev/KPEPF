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

public partial class Contents_ReclMltpl2 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();
        }
    }
   
    private void InitialSettings()
    {        
        FillPfoM();
        SetGridColWidth();
    }
    private void SetGridColWidth()
    {
        for (int i = 1; i < gdvRecM.Columns.Count; i++)
        {
            gdvRecM.Columns[i].ItemStyle.Width = 1000;
        }
    }
    private void FillPfoM()
    {
        DataSet dsRecM = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIdRecMltpl"]);
        rec.IntMonthId = Convert.ToInt16(Session["intMonthIdRecMltpl"]);
        rec.IntTrnType = Convert.ToInt16(Session["intTrnType"]);
        dsRecM = recd.GetTreasuryDataMonthWiseUnP(rec);
        if (dsRecM.Tables[0].Rows.Count > 0)
        {
            gdvRecM.DataSource = dsRecM;
            gdvRecM.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecM, 1, 14);

        //Display Month//
        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["intYearIdRecMltpl"]));
        lblYearD2.Text = gen.GetYearFromIdPde(ar1);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdRecMltpl"]));
        lblYearD.Text = gen.GetMonthFromId(ar);

        if (Convert.ToInt16(Session["intTrnType"]) == 1)
        {
            lblTDet.Text = "1 - Entry missing in ST. 2 - Entry missing in Chalan. 3 - Entry missing in schedule. 4 - Unposted chalan. 5 - Un identified employee";
            lblAGDet.Text = "1* - Entry missing in TE plus. 2* - Unposted chalan. 3* - Entry missing in schedule. 4* -  Entry missing in TE minus.  5* - Chalan missing. 6* -  Un identified employee.";
        }
        else
        {
            lblTDet.Text = "1 - Entry missing in bill. 2 - Entry missing employee wise. 3 - Unposted bill. 4 - Un identified employee.";
            lblAGDet.Text = "1* - Entry missing in TE plus. 2* - Entry missing in TE minus. 3* - Entry missing in emp. wise entry. 4* -  Unposted bill.  5* - Bill missing. 6* -  Un identified employee.";
        }
    }

    protected void gdvRecM_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr1 = e.Row;
        gblObj.MergeCells(gdvRecM, gvr1, 14, 2, 7, 8, 14, "Treasury", "AG", e);
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/ReclMltpl1.aspx";
    }

}
