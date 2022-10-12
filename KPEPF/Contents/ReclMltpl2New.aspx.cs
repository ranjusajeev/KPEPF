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

public partial class Contents_ReclMltpl2New : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //if (Convert.ToInt16(Request.QueryString["intDTreasuryId"]) > 0)
            //{
            //    //Session["intDTreasuryIdRecMltpl"] = Convert.ToInt16(Request.QueryString["intDTreasuryId"]);
            //    FillPfoM();
            //}
            //else
            //{
                InitialSettings();
            //}
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
        float amt1, amt2;
        DataSet dsRecM = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIdRecMltpl"]);
        rec.IntMonthId = Convert.ToInt16(Session["intMonthIdRecMltpl"]);
        rec.IntTrnType = Convert.ToInt16(Session["intTrnType"]);
        dsRecM = recd.GetTreasuryDataMonthWiseUnPNewNew(rec);
        if (dsRecM.Tables[0].Rows.Count > 0)
        {
            gdvRecM.DataSource = dsRecM;
            gdvRecM.DataBind();
        }
        gblObj.SetFooterTotalsMltpl(gdvRecM, 1, 9);
        //Display Month//
        if (Convert.ToInt16(Session["intTrnType"]) == 1)
        {
            lblTp.Text = "Credit";
        }
        else
        {
            lblTp.Text = "Debit";
        }

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["intYearIdRecMltpl"]));
        lblYearD2.Text = gen.GetYearFromId(ar1);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdRecMltpl"]));
        lblYearD.Text = gen.GetMonthFromId(ar);

        if (Convert.ToInt16(Session["intTrnType"]) == 1)
        {
            lblTDet.Text = "1 -  Entry missing in Chalan. 2 -Misclassified Chalan. 3 - Unposted chalan.";
            lblAGDet.Text = "1* - Chalan without Supp. Docs. 2* - Chalan entry missing. 3* -  Unposted chalan.";
        }
        else
        {
            lblTDet.Text = "1 - Entry missing in bill. 2 - Missclassified bill 3 - Unposted bill.";
            lblAGDet.Text = "1* - Entry missing in bill. 2* - Without supp. Documents. 3* -  Unposted bill.";
        }

        //for (int i = 0; i < dsRecM.Tables[0].Rows.Count; i++)
        //{
        //    amt1=amt1+dsRecM.Tables[0].Rows[i].ite
        //}

    }

    protected void gdvRecM_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr1 = e.Row;
        //gblObj.MergeCells(gdvRecM, gvr1, 11, 1, 5, 6, 10, "Treasury", "AG", e);
        gblObj.MergeCells(gdvRecM, gvr1, 9, 1, 5, 6, 8, "Treasury", "AG", e);
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/ReclMltpl1New.aspx";
    }

}
