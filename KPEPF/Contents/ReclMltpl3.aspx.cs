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

public partial class Contents_ReclMltpl3 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["flgPageBackChalView"] = 1;
            if (Convert.ToInt16(Request.QueryString["intDTreasuryId"]) > 0)
            {
                Session["flgTp"] = Convert.ToInt16(Request.QueryString["flgTp"]);
                Session["intDTreasuryIdRecMltpl"] = Convert.ToInt16(Request.QueryString["intDTreasuryId"]);
                FillUnPDet();
            }
            else if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
            {
                FillUnPDet();
            }
        }
    }
    private void FillUnPDet()
    {
        //DataSet dsRecM = new DataSet();
        rec.IntYearId = Convert.ToInt16(Session["intYearIdRecMltpl"]);
        rec.IntMonthId = Convert.ToInt16(Session["intMonthIdRecMltpl"]);
        rec.IntDTId = Convert.ToInt16(Session["intDTreasuryIdRecMltpl"]);
        
        if (Convert.ToInt16(Session["flgTp"]) == 1)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = true;
            gdvRecM1.Visible = false ;
            gdvRecM2.Visible = false;

            Session["flgTp"] = 1;
            dsRecM = recd.GetUnPTrace1(rec);

            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM.DataSource = dsRecM;
                gdvRecM.DataBind();
            }
            gblObj.SetFooterTotals(gdvRecM, 3);
        }
        else if (Convert.ToInt16(Session["flgTp"]) == 2)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = false;
            gdvRecM1.Visible = true;
            gdvRecM2.Visible = false;

            Session["flgTp"] = 2;
            dsRecM = recd.GetUnPTrace2(rec);

            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM1.DataSource = dsRecM;
                gdvRecM1.DataBind();
            }
            gblObj.SetFooterTotals(gdvRecM1, 3);
        }
        else if (Convert.ToInt16(Session["flgTp"]) == 3)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = false;
            gdvRecM1.Visible = true;
            gdvRecM2.Visible = false;

            Session["flgTp"] = 3;
            dsRecM = recd.GetUnPTrace3(rec);

            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM1.DataSource = dsRecM;
                gdvRecM1.DataBind();
            }
            gblObj.SetFooterTotals(gdvRecM1, 3);
        }
        else
        {
            //DataSet dsRecM = new DataSet();
            //gdvRecM.Visible = false;
            //gdvRecM1.Visible = false;
            //gdvRecM2.Visible = true;

            //Session["flgTp"] = 3;
            //dsRecM = recd.GetUnPTrace3(rec);

            //if (dsRecM.Tables[0].Rows.Count > 0)
            //{
            //    gdvRecM2.DataSource = dsRecM;
            //    gdvRecM2.DataBind();
            //}
            //gblObj.SetFooterTotals(gdvRecM2, 3);
        }
        
        

        //Display Month//
        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["intYearIdRecMltpl"]));
        lblYearD2.Text = gen.GetYearFromIdPde(ar1);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdRecMltpl"]));
        lblYearD.Text = gen.GetMonthFromId(ar);

        ArrayList ar2 = new ArrayList();
        ar2.Add(Convert.ToInt16(Session["intDTreasuryIdRecMltpl"]));
        lblYearD3.Text = gen.GetDisTreasuryFromId(ar2);

    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/ReclMltpl2.aspx";
    }
}
