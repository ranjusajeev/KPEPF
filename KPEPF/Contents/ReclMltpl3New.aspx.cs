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

public partial class Contents_ReclMltpl3New : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["flgPageBackChalView"] = 1;
            if (Convert.ToInt16(Request.QueryString["intDTreasuryId"]) > 0)
            {
                Session["flgTp"] = Convert.ToInt16(Request.QueryString["flgTp"]);
                Session["intDTreasuryIdRecMltpl"] = Convert.ToInt16(Request.QueryString["intDTreasuryId"]);
                if (Convert.ToInt16(Session["intTrnType"]) == 1)
                {
                    FillUnPDet();
                }
                else
                {
                    FillUnPDetDt();
                }
            }
            //else if (Convert.ToInt16(Session["flgPageBackChalView"]) == 1)
            //{
            //    FillUnPDet();
            //}
        }
    }
    private void FillUnPDetDt()
    {
        rec.IntYearId = Convert.ToInt16(Session["intYearIdRecMltpl"]);
        rec.IntMonthId = Convert.ToInt16(Session["intMonthIdRecMltpl"]);
        rec.IntDTId = Convert.ToInt16(Session["intDTreasuryIdRecMltpl"]);
        rec.IntTrnType = Convert.ToInt16(Session["flgTp"]);
        if (Convert.ToInt16(Session["flgTp"]) == 2 || Convert.ToInt16(Session["flgTp"]) == 3)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = true;
            gdvRecM.Columns[1].Visible = false;
            gdvRecM1.Visible = false;

            dsRecM = recd.GetUnPTrace1NewDt(rec);
            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM.DataSource = dsRecM;
                gdvRecM.DataBind();
            }
            else
            {
                Response.Redirect("ReclMltpl2New.aspx");
            }
            gblObj.SetFooterTotals(gdvRecM, 4);
        }
        else if (Convert.ToInt16(Session["flgTp"]) == 6 || Convert.ToInt16(Session["flgTp"]) == 4)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = true;
            gdvRecM.Columns[1].Visible = true;
            gdvRecM1.Visible = false;
            dsRecM = recd.GetUnPTrace1NewDt(rec);
            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM.DataSource = dsRecM;
                gdvRecM.DataBind();
            }
            else
            {
                Response.Redirect("ReclMltpl2New.aspx");
            }
            gblObj.SetFooterTotals(gdvRecM, 4);
        }
        else if (Convert.ToInt16(Session["flgTp"]) == 1)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = false;
            gdvRecM1.Visible = true;
            Session["flgTp"] = 3;
            dsRecM = recd.GetUnPTrace3(rec);

            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM1.DataSource = dsRecM;
                gdvRecM1.DataBind();
            }
            gblObj.SetFooterTotals(gdvRecM1, 4);
        }


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
        lblYearD.Text = gen.GetYearFromId(ar1);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdRecMltpl"]));
        lblYearD2.Text = gen.GetMonthFromId(ar);

        ArrayList ar2 = new ArrayList();
        ar2.Add(Convert.ToInt16(Session["intDTreasuryIdRecMltpl"]));
        lblYearD3.Text = gen.GetDisTreasuryFromId(ar2);

    }
    private void FillUnPDet()
    {
        rec.IntYearId = Convert.ToInt16(Session["intYearIdRecMltpl"]);
        rec.IntMonthId = Convert.ToInt16(Session["intMonthIdRecMltpl"]);
        rec.IntDTId = Convert.ToInt16(Session["intDTreasuryIdRecMltpl"]);
        rec.IntTrnType = Convert.ToInt16(Session["flgTp"]);
        if (Convert.ToInt16(Session["flgTp"]) == 3 || Convert.ToInt16(Session["flgTp"]) == 2)   
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = true;
            gdvRecM.Columns[1].Visible = false;
            gdvRecM1.Visible = false;

            dsRecM = recd.GetUnPTrace1New(rec);
            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM.DataSource = dsRecM;
                gdvRecM.DataBind();
            }
            else
            {
                Response.Redirect("ReclMltpl2New.aspx");
            }
            gblObj.SetFooterTotals(gdvRecM, 4);
        }
        else if (Convert.ToInt16(Session["flgTp"]) == 6 || Convert.ToInt16(Session["flgTp"]) == 4)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = true;
            gdvRecM.Columns[1].Visible = true ;
            gdvRecM1.Visible = false;
            dsRecM = recd.GetUnPTrace1New(rec);
            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM.DataSource = dsRecM;
                gdvRecM.DataBind();
            }
            else
            {
                Response.Redirect("ReclMltpl2New.aspx");
            }
            gblObj.SetFooterTotals(gdvRecM, 4);
        }
        else if (Convert.ToInt16(Session["flgTp"]) == 1)
        {
            DataSet dsRecM = new DataSet();
            gdvRecM.Visible = false;
            gdvRecM1.Visible = true;
            Session["flgTp"] = 3;
            dsRecM = recd.GetUnPTrace3(rec);

            if (dsRecM.Tables[0].Rows.Count > 0)
            {
                gdvRecM1.DataSource = dsRecM;
                gdvRecM1.DataBind();
            }
            gblObj.SetFooterTotals(gdvRecM1, 4);
        }
        

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
        lblYearD.Text = gen.GetYearFromId(ar1);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intMonthIdRecMltpl"]));
        lblYearD2.Text = gen.GetMonthFromId(ar);

        ArrayList ar2 = new ArrayList();
        ar2.Add(Convert.ToInt16(Session["intDTreasuryIdRecMltpl"]));
        lblYearD3.Text = gen.GetDisTreasuryFromId(ar2);

    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/ReclMltpl2New.aspx";
    }
}